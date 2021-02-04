using FluentValidation;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator.ModelValidators
{
    public class DomUsuarioAutenticacionRequestValidation: AbstractValidator<DomUsuarioAutenticacionRequest>
    {
        public DomUsuarioAutenticacionRequestValidation()
        {
            RuleFor(m => m.Usuario).NotEmpty();
             RuleFor(m => m.Contrasena).NotEmpty();
        }
    }
}
