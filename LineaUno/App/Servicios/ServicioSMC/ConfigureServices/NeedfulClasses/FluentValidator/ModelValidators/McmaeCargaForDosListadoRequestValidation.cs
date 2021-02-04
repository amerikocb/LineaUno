using FluentValidation;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator.ModelValidators
{
    public class McmaeCargaForDosListadoRequestValidation : AbstractValidator<McmaeCargaForDosListadoRequest>
    {
        public McmaeCargaForDosListadoRequestValidation()
        {
            RuleFor(m => m.Activo).NotEmpty();
        }
    }
}
