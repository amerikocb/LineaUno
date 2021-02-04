using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class MCTabOTListadoRequest : ICustomMapping
    {
        public bool Activo { get; set; }

        public void CreateMappings(Profile configuration)
        {
            //configuration.CreateMap<MCTabOTListadoRequest, MCTabOT>()
            //    .ForMember(dest => dest.bEstRegistro, orig => orig.MapFrom(x => x.Activo));
        }
    }
}
