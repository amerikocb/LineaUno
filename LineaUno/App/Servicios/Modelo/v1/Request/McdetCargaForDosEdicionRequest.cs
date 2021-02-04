using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McdetCargaForDosEdicionRequest: ICustomMapping
    {
        public int NumCarga { get; set; }
        public int CodigoDetalle { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string ZonaEspecifica { get; set; }
        public string Prioridad { get; set; }
        public string PermisoInt { get; set; }
        public string Trabajadores { get; set; }
        public string NombreTerminal { get; set; }
        public string Usuario { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McdetCargaForDosEdicionRequest, McdetCargaForDos>()
                .ForMember(dest => dest.INumCarga, orig => orig.MapFrom(x => x.NumCarga))
                .ForMember(dest => dest.INumDetCarga, orig => orig.MapFrom(x => x.CodigoDetalle))
                .ForMember(dest => dest.VRuc, orig => orig.MapFrom(x => x.Ruc))
                .ForMember(dest => dest.VRazSocial, orig => orig.MapFrom(x => x.RazonSocial))
                .ForMember(dest => dest.VZonEspecifica, orig => orig.MapFrom(x => x.ZonaEspecifica))
                .ForMember(dest => dest.VPrioridad, orig => orig.MapFrom(x => x.Prioridad))
                .ForMember(dest => dest.VPerIntervencion, orig => orig.MapFrom(x => x.PermisoInt));
        }
    }
}
