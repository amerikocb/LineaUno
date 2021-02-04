using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McdetCargaForDosRequest : ICustomMapping
    {
        public string NumPT { get; set; }
        public string ParFecha { get; set; }
        public string HorInicio { get; set; }
        public string HorFin { get; set; }
        public string AreResponsable { get; set; }
        public string Ruc { get; set; }
        public string RazSocial { get; set; }
        public string Zona { get; set; }
        public string SecLinea { get; set; }
        public string ZonEspecifica { get; set; }
        public string DesActividad { get; set; }
        public string TipActividad { get; set; }
        public string Prioridad { get; set; }
        public string PerIntervencion { get; set; }
        public string RecMedios { get; set; }
        public string SupResConcar { get; set; }
        public string CelSupResponsable { get; set; }
        public string TEResConcar { get; set; }
        public string CelTEResponsable { get; set; }
        public string ResTercero { get; set; }
        public string CelTercero { get; set; }
        public string CodUsuCreacion { get; set; }
        public string NomTerCreacion { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McdetCargaForDosRequest, McdetCargaForDos>()
                .ForMember(dest => dest.VCodUsuCreacion, orig => orig.MapFrom(x => x.CodUsuCreacion))
                .ForMember(dest => dest.CNomTerCreacion, orig => orig.MapFrom(x => x.NomTerCreacion))
                .ForMember(dest => dest.VNumPt, orig => orig.MapFrom(x => x.NumPT))
                .ForMember(dest => dest.VParFecha, orig => orig.MapFrom(x => x.ParFecha))
                .ForMember(dest => dest.VHorInicio, orig => orig.MapFrom(x => x.HorInicio))
                .ForMember(dest => dest.VHorFin, orig => orig.MapFrom(x => x.HorFin))
                .ForMember(dest => dest.VAreResponsable, orig => orig.MapFrom(x => x.AreResponsable))
                .ForMember(dest => dest.VRuc, orig => orig.MapFrom(x => x.Ruc))
                .ForMember(dest => dest.VRazSocial, orig => orig.MapFrom(x => x.RazSocial))
                .ForMember(dest => dest.VZona, orig => orig.MapFrom(x => x.Zona))
                .ForMember(dest => dest.VSecLinea, orig => orig.MapFrom(x => x.SecLinea))
                .ForMember(dest => dest.VZonEspecifica, orig => orig.MapFrom(x => x.ZonEspecifica))
                .ForMember(dest => dest.VDesActividad, orig => orig.MapFrom(x => x.DesActividad))
                .ForMember(dest => dest.VTipActividad, orig => orig.MapFrom(x => x.TipActividad))
                .ForMember(dest => dest.VPrioridad, orig => orig.MapFrom(x => x.Prioridad))
                .ForMember(dest => dest.VPerIntervencion, orig => orig.MapFrom(x => x.PerIntervencion))
                .ForMember(dest => dest.VRecMedios, orig => orig.MapFrom(x => x.RecMedios))
                .ForMember(dest => dest.VSupResConcar, orig => orig.MapFrom(x => x.SupResConcar))
                .ForMember(dest => dest.VCelSupResponsable, orig => orig.MapFrom(x => x.CelSupResponsable))
                .ForMember(dest => dest.VTeresConcar, orig => orig.MapFrom(x => x.TEResConcar))
                .ForMember(dest => dest.VCelTeresponsable, orig => orig.MapFrom(x => x.CelTEResponsable))
                .ForMember(dest => dest.VResTercero, orig => orig.MapFrom(x => x.ResTercero))
                .ForMember(dest => dest.VCelTercero, orig => orig.MapFrom(x => x.CelTercero));
        }
    }
}
