using Dtonic.Dto.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Dtonic.Json.Example.Web.ModelBinder;

public class DtonicBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.Metadata.ModelType.GetInterface(nameof(IDtonic)) != null)
        {
            return new BinderTypeModelBinder(typeof(DtonicModelBinder));
        }

        return null;
    }
}
