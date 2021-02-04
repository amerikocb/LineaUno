using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VLP.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using VLP.Models;

namespace VLP.Contracts.v1.Request
{
    public class TabContribuyenteValidoRequest: ICustomMapping
    {
        public byte TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } 

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<TabContribuyenteValidoRequest, TabContribuyente>()
                .ForMember(dest => dest.TiTipDocContribuyente, orig => orig.MapFrom(x => x.TipoDocumento))
                .ForMember(dest => dest.CNumDocContribuyente, orig => orig.MapFrom(x => x.NumeroDocumento));
        }
    }
}
