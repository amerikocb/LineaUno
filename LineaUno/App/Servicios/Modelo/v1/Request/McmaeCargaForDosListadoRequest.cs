using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McmaeCargaForDosListadoRequest : ICustomMapping
    {
        public bool Activo { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McmaeCargaForDosListadoRequest, McmaeCargaForDos>()
                .ForMember(dest => dest.BEstRegistro, orig => orig.MapFrom(x => x.Activo));
        }
    }
}
