using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VLP.ConfigureServices.NeedfulClasses.FluentValidator
{
    public class ValidationFailedRequest: ObjectResult
    {
        public ValidationFailedRequest(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
