using AutoMapper;

namespace VLP.ConfigureServices.NeedfulClasses.AutoMapper.Interfaces
{
    public interface ICustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
