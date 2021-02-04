using AutoMapper;
using System;
using System.Reflection;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            LoadStandardMappings();
            LoadCustomMappings();
        }
        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.Load("LineaUno.App.Servicios.Modelo.SMC"));

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
