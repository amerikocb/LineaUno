using FluentValidation;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator.ModelValidators
{
    public class McmaeCargaForDosRequestValidation : AbstractValidator<McmaeCargaForDosRequest>
    {
        public McmaeCargaForDosRequestValidation()
        {
            RuleFor(m => m.UsuarioCreacion).NotEmpty();
            RuleFor(m => m.TerminalCreacion).NotEmpty();
            RuleFor(m => m.File).NotEmpty();
        }
    }
}
