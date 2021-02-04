using FluentValidation;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator.ModelValidators
{
    public class McdetCargaForDosEdicionRequestValidation : AbstractValidator<McdetCargaForDosEdicionRequest>
    {
        public McdetCargaForDosEdicionRequestValidation()
        {
            RuleFor(m => m.CodigoDetalle).NotEmpty();
            //RuleFor(m => m.Ruc).NotNull();
            //RuleFor(m => m.RazonSocial).NotEmpty();
            RuleFor(m => m.ZonaEspecifica).NotEmpty();
            RuleFor(m => m.Prioridad).NotEmpty();
            RuleFor(m => m.PermisoInt).NotEmpty();
        }
    }
}
