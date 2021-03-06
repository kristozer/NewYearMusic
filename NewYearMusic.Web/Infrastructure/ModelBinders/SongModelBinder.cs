using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;

namespace NewYearMusic.Web.Infrastructure.ModelBinders
{
    public class SongModelBinder : IModelBinder
    {
        private readonly IMusicService _musicService;
        private readonly UserManager<AppUser> _userManager;
        public SongModelBinder(IMusicService musicService, UserManager<AppUser> userManager)
        {
            _musicService = musicService;
            _userManager = userManager;
        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            Song model = null;
            var nameSong = bindingContext.ValueProvider.GetValue("Name").FirstValue;
            var authorSong = bindingContext.ValueProvider.GetValue("Author").FirstValue;
            var descriptionSong = bindingContext.ValueProvider.GetValue("Description").FirstValue;
            var modelName = "id";
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            if (valueProviderResult != ValueProviderResult.None)
            {
                var value = valueProviderResult.FirstValue;
                if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int parsedId))
                {

                    bindingContext.Result = ModelBindingResult.Failed();
                    return;
                }
                model = await _musicService.GetSongWithUserByIdAsync(parsedId);
                model.ChangeAuthor(authorSong);
                model.ChangeName(nameSong);
                model.ChangeDescription(descriptionSong);
                model.ChangeEditionDate(DateTime.Now);
            }
            if (model == null)
            {
                var userValue = bindingContext.ValueProvider.GetValue("User");
                if (!bindingContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    bindingContext.ModelState.AddModelError("User", "Пользователь не зарегистрирован");
                    bindingContext.Result = ModelBindingResult.Failed();
                    return;
                }
                var userSong = await _userManager.FindByNameAsync(bindingContext.HttpContext.User.Identity.Name);
                model = new Song(nameSong, userSong, DateTime.Now, authorSong, descriptionSong);
            }
            bindingContext.Result = ModelBindingResult.Success(model);
            return;
        }
    }
}