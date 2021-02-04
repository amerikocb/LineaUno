using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Response
{
    public class McmaeCargaForDosListadoResponse: ICustomMapping
    {
        public int NumCarga { get; set; }
        public string Estado { get; set; }
        public string TipCarga { get; set; }       
        public string CodUsuCreacion { get; set; }
        public DateTime sdFEcCreacion { get; set; }      

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McmaeCargaForDos, McmaeCargaForDosListadoResponse>()
                .ForMember(dest => dest.NumCarga, orig => orig.MapFrom(x => x.INumCarga))
                .ForMember(dest => dest.Estado, orig => orig.MapFrom(x => x.CEstado))
                .ForMember(dest => dest.TipCarga, orig => orig.MapFrom(x => x.CTipCarga))              
                .ForMember(dest => dest.CodUsuCreacion, orig => orig.MapFrom(x => x.VCodUsuCreacion))
                .ForMember(dest => dest.sdFEcCreacion, orig => orig.MapFrom(x => x.SdFecCreacion));           
        }
    }
}
