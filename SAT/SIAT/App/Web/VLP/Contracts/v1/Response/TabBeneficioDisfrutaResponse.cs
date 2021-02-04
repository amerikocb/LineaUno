using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VLP.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using VLP.Models;

namespace VLP.Contracts.v1.Response
{
    public class TabBeneficioDisfrutaResponse: ICustomMapping
    {
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte Prioridad { get; set; }
        public string Imagen { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<TabBeneficio, TabBeneficioDisfrutaResponse>()
                .ForMember(dest => dest.Nombre, orig => orig.MapFrom(x => x.VNomBeneficio))
                .ForMember(dest => dest.Detalle, orig => orig.MapFrom(x => x.VDetBeneficio))
                .ForMember(dest => dest.FechaInicio, orig => orig.MapFrom(x => x.SdFecVigInicio))
                .ForMember(dest => dest.FechaFin, orig => orig.MapFrom(x => x.SdFecVigFin))
                .ForMember(dest => dest.Prioridad, orig => orig.MapFrom(x => x.TiNumPrioridad))
                .ForMember(dest => dest.Imagen, orig => orig.MapFrom(x => x.VImgBeneficio));
        }
    }
}
