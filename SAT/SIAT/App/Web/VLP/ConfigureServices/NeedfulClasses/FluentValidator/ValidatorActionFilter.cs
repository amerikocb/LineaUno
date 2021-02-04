using Microsoft.AspNetCore.Mvc.Filters;

namespace VLP.ConfigureServices.NeedfulClasses.FluentValidator
{
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedRequest(context.ModelState);
            }
        }
    }
}
