using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Infrastructure.ModelBinders
{
    public class SongModelBinderProvider: IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType == typeof(Song))
                return new BinderTypeModelBinder(typeof(SongModelBinder));

            return null;
}
    }
}