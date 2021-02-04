using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using Microsoft.AspNetCore.Http;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McmaeCargaForDosRequest : ICustomMapping
    {
        public string UsuarioCreacion { get; set; }
        public string TerminalCreacion { get; set; }
        public IFormFile File { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McmaeCargaForDosRequest, McmaeCargaForDos>()
                .ForMember(dest => dest.VCodUsuCreacion, orig => orig.MapFrom(x => x.UsuarioCreacion))
                .ForMember(dest => dest.CNomTerCreacion, orig => orig.MapFrom(x => x.TerminalCreacion));
        }
    }
}
