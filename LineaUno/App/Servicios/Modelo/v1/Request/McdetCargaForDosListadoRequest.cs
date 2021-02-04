using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McdetCargaForDosListadoRequest: ICustomMapping
    {
        public int CodigoCarga { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McdetCargaForDosListadoRequest, McdetCargaForDos>()
                .ForMember(dest => dest.INumCarga, orig => orig.MapFrom(x => x.CodigoCarga));
        }
    }
}
