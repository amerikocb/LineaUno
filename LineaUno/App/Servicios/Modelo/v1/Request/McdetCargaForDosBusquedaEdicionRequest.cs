using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McdetCargaForDosBusquedaEdicionRequest: ICustomMapping
    {
        public int NumCarga { get; set; }

        public int CodigoDetalle { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<McdetCargaForDosBusquedaEdicionRequest, McdetCargaForDos>()
                 .ForMember(dest => dest.INumCarga, orig => orig.MapFrom(x => x.NumCarga))
                 .ForMember(dest => dest.INumDetCarga, orig => orig.MapFrom(x => x.CodigoDetalle));
        }
    }
}
