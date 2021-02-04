using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Response
{
    public class MCTabOTListadoResponse: ICustomMapping
    {
        public string Codigo { get; set; }
        public string NumeroOT { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
        public string Usuario_creacion { get; set; }
        public DateTime Fecha_creacion { get; set; }

        public void CreateMappings(Profile configuration)
        {
            //configuration.CreateMap<MCTabOT, MCTabOTListadoResponse>()
            //    .ForMember(dest => dest.Codigo, orig => orig.MapFrom(x => x.iNumIdOT))
            //    .ForMember(dest => dest.NumeroOT, orig => orig.MapFrom(x => x.vNumOT))
            //    .ForMember(dest => dest.Estado, orig => orig.MapFrom(x => x.cEstOT))
            //    .ForMember(dest => dest.Activo, orig => orig.MapFrom(x => x.bEstRegistro))
            //    .ForMember(dest => dest.Usuario_creacion, orig => orig.MapFrom(x => x.vCodUsuCreacion))
            //    .ForMember(dest => dest.Fecha_creacion, orig => orig.MapFrom(x => x.sdFecCreacion));
        }
    }
}
