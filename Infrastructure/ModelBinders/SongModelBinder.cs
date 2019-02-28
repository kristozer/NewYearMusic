using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using NewYearMusic.Domain.Interfaces;

namespace NewYearMusic.Infrastructure.ModelBinders
{
    public class SongModelBinder : IModelBinder
    {
        private IMusicService _musicService;
        public SongModelBinder(IMusicService musicService) => _musicService = musicService;
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            //bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            //var model = _musicService.GetSongWithUserByIdAsync(value.Id)
            //bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}