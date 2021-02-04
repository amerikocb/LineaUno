using System;
using System.Collections.Generic;
using AutoMapper;
using VLP.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
    using VLP.Models;

namespace VLP.Contracts.v1.Response
{
    public class TabCatBeneficioDisfrutaResponse : ICustomMapping
    {
        public string Categoria { get; set; }

        public virtual ICollection<TabBeneficioDisfrutaResponse> Beneficios { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<TabCatBeneficio, TabCatBeneficioDisfrutaResponse>()
                .ForMember(dest => dest.Categoria, orig => orig.MapFrom(x => x.VNomCatBeneficio))
                .ForMember(dest => dest.Beneficios, orig => orig.MapFrom(x => x.TabBeneficio));

            //configuration.CreateMap<TabBeneficio, TabBeneficioDisfrutaResponse>()
            //    .ForMember(dest => dest.Nombre, orig => orig.MapFrom(x => x.VNomBeneficio))
            //    .ForMember(dest => dest.Detalle, orig => orig.MapFrom(x => x.VDetBeneficio))
            //    .ForMember(dest => dest.Descuento, orig => orig.MapFrom(x => x.VTxtDescuento))
            //    .ForMember(dest => dest.FechaInicio, orig => orig.MapFrom(x => x.SdFecVigInicio))
            //    .ForMember(dest => dest.FechaFin, orig => orig.MapFrom(x => x.SdFecVigFin))
            //    .ForMember(dest => dest.Prioridad, orig => orig.MapFrom(x => x.TiNumPrioridad))
            //    .ForMember(dest => dest.Imagen, orig => orig.MapFrom(x => x.VImgBeneficio));
        }
    }
}
