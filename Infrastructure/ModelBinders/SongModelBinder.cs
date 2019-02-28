using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;

namespace NewYearMusic.Infrastructure.ModelBinders
{
    public class SongModelBinder : IModelBinder
    {
        private IMusicService _musicService;
        public SongModelBinder(IMusicService musicService) => _musicService = musicService;
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = "id";
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var value = valueProviderResult.FirstValue;
            int parsedId = -1;
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out parsedId))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            //bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            var model = await _musicService.GetSongWithUserByIdAsync(parsedId);

            List<PropertyInfo> modelProperties = typeof(Song).GetProperties().ToList();
            modelProperties = modelProperties.Where(p=>p.Name!="Id" && p.Name!="User" && p.Name!="AppUserId").ToList();
            modelProperties.ForEach(p=>
            {
                var valuePropertyProviderResult = bindingContext.ValueProvider.GetValue(p.Name);
                if(valuePropertyProviderResult != ValueProviderResult.None)
                {
                    var propertyValue = valuePropertyProviderResult.FirstValue;
                    p.SetValue(model, Convert.ChangeType(propertyValue, p.PropertyType));
                }
            });
            bindingContext.Result = ModelBindingResult.Success(model);
            return;
        }
    }
}