using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Infrastructure.ModelBinders
{
    public class SongModelBinderProvider: IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Song))
                return new SongModelBinder();

            return null;
}
    }
}