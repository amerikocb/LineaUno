using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{

    public class McMaeTrabajadorBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McMaeTrabajadorBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<MCTrabajadorResponse>> ListarTrabajadores_Rec()
        {
            return await new McMaeTrabajadorDAL(context, mapper).ListarTrabajadores_Rec();
        }

    }
}