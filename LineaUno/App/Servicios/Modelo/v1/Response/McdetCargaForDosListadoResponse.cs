using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Response
{
    public class McdetCargaForDosListadoResponse : ICustomMapping
    {
        public int NumCarga { get; set; }
        public int NumDetCarga { get; set; }
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
            configuration.CreateMap<McdetCargaForDos, McdetCargaForDosListadoResponse>()
                .ForMember(dest => dest.NumCarga, orig => orig.MapFrom(x => x.INumCarga))
                .ForMember(dest => dest.NumDetCarga, orig => orig.MapFrom(x => x.INumDetCarga))
                .ForMember(dest => dest.NumPT, orig => orig.MapFrom(x => x.VNumPt))
                .ForMember(dest => dest.ParFecha, orig => orig.MapFrom(x => x.VParFecha))
                .ForMember(dest => dest.HorInicio, orig => orig.MapFrom(x => x.VHorInicio))
                .ForMember(dest => dest.HorFin, orig => orig.MapFrom(x => x.VHorFin))
                .ForMember(dest => dest.AreResponsable, orig => orig.MapFrom(x => x.VAreResponsable))
                .ForMember(dest => dest.Ruc, orig => orig.MapFrom(x => x.VRuc))
                .ForMember(dest => dest.RazSocial, orig => orig.MapFrom(x => x.VRazSocial))
                .ForMember(dest => dest.Zona, orig => orig.MapFrom(x => x.VZona))
                .ForMember(dest => dest.SecLinea, orig => orig.MapFrom(x => x.VSecLinea))
                .ForMember(dest => dest.ZonEspecifica, orig => orig.MapFrom(x => x.VZonEspecifica))
                .ForMember(dest => dest.DesActividad, orig => orig.MapFrom(x => x.VDesActividad))
                .ForMember(dest => dest.TipActividad, orig => orig.MapFrom(x => x.VTipActividad))
                .ForMember(dest => dest.Prioridad, orig => orig.MapFrom(x => x.VPrioridad))
                .ForMember(dest => dest.PerIntervencion, orig => orig.MapFrom(x => x.VPerIntervencion))
                .ForMember(dest => dest.RecMedios, orig => orig.MapFrom(x => x.VRecMedios))
                .ForMember(dest => dest.SupResConcar, orig => orig.MapFrom(x => x.VSupResConcar))
                .ForMember(dest => dest.CelSupResponsable, orig => orig.MapFrom(x => x.VCelSupResponsable))
                .ForMember(dest => dest.TEResConcar, orig => orig.MapFrom(x => x.VTeresConcar))
                .ForMember(dest => dest.CelTEResponsable, orig => orig.MapFrom(x => x.VCelTeresponsable))
                .ForMember(dest => dest.ResTercero, orig => orig.MapFrom(x => x.VResTercero))
                .ForMember(dest => dest.CelTercero, orig => orig.MapFrom(x => x.VCelTercero))
                .ForMember(dest => dest.CodUsuCreacion, orig => orig.MapFrom(x => x.VCodUsuCreacion))
                .ForMember(dest => dest.NomTerCreacion, orig => orig.MapFrom(x => x.CNomTerCreacion));
        }
    }
}
