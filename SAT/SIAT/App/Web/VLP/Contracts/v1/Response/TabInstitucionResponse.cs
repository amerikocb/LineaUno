using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VLP.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using VLP.Models;

namespace VLP.Contracts.v1.Response
{
    public class TabInstitucionResponse : ICustomMapping
    {
        public byte Categoria { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public byte Prioridad { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<TabInstitucion, TabInstitucionResponse>()
                .ForMember(dest => dest.Categoria, orig => orig.MapFrom(x => x.TiCodCatInstitucion))
                .ForMember(dest => dest.Nombre, orig => orig.MapFrom(x => x.VNomInstitucion))
                .ForMember(dest => dest.Logo, orig => orig.MapFrom(x => x.VImgLogo))
                .ForMember(dest => dest.Prioridad, orig => orig.MapFrom(x => x.TiNumPrioridad));
        }
    }
}
