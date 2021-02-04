using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator
{
    public class ValidationResultModel
    {
        public string Mensaje { get; }

        public int StatusCode { get; }

        public List<ValidationError> Errores { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            StatusCode = 422;
            Mensaje = "Validacion Fallida en campos enviados";
            Errores = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
