using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Response
{
    public class McdetCargaForDosBusquedaEdicionResponse: ICustomMapping
    {
        public int NumCarga { get; set; }
        public int CodigoDetalle { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string ZonaEspecifica { get; set; }
        public string Prioridad { get; set; }
        public string PermisoInt { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McdetCargaForDos, McdetCargaForDosBusquedaEdicionResponse>()
                .ForMember(dest => dest.NumCarga, orig => orig.MapFrom(x => x.INumCarga))
                .ForMember(dest => dest.CodigoDetalle, orig => orig.MapFrom(x => x.INumDetCarga))
                .ForMember(dest => dest.Ruc, orig => orig.MapFrom(x => x.VRuc))
                .ForMember(dest => dest.RazonSocial, orig => orig.MapFrom(x => x.VRazSocial))
                .ForMember(dest => dest.ZonaEspecifica, orig => orig.MapFrom(x => x.VZonEspecifica))
                .ForMember(dest => dest.Prioridad, orig => orig.MapFrom(x => x.VPrioridad))
                .ForMember(dest => dest.PermisoInt, orig => orig.MapFrom(x => x.VPerIntervencion));
        }
    }
}
