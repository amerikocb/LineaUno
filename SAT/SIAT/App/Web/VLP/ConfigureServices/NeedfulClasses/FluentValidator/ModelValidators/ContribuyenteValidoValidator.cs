using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLP.Contracts.v1.Request;

namespace VLP.ConfigureServices.NeedfulClasses.FluentValidator.ModelValidators
{
    public class ContribuyenteValidoValidator: AbstractValidator<TabContribuyenteValidoRequest>
    {
        public ContribuyenteValidoValidator()
        {
            RuleFor(m => m.TipoDocumento).NotEmpty();
            RuleFor(m => m.NumeroDocumento).NotEmpty().Length(8, 12);
        }
    }
}
