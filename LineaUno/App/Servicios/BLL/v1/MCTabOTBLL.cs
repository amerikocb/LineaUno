using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class MCTabOTBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public MCTabOTBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        //public async Task<List<MCTabOTListadoResponse>> BusquedaListadoOT(MCTabOTListadoRequest request)
        //{
        //    var MCTabOTDAL = new MCTabOTDAL(this.context, this.mapper);
        //    return await MCTabOTDAL.BusquedaListado(request);
        //}
    }
}
