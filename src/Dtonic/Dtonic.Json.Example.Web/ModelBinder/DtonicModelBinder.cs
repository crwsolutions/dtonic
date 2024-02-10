using Dtonic.Dto.Base;
using Dtonic.Dto.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dtonic.Json.Example.Web.ModelBinder;

public sealed class DtonicModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        if (Activator.CreateInstance(bindingContext.ModelType) is IDtonic dto)
        {
            var parsedDto = dto.Parse(bindingContext.HttpContext.Request.Body).Result;
            bindingContext.Result = ModelBindingResult.Success(parsedDto);
        }

        return Task.CompletedTask;
    }
}
