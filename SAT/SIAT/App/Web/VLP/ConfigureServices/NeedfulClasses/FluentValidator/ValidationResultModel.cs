using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VLP.ConfigureServices.NeedfulClasses.FluentValidator
{
    public class ValidationResultModel
    {
        public string Message { get; }

        public int StatusCode { get; }

        public List<ValidationError> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            StatusCode = 422;
            Message = "Validacion Fallida";
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
