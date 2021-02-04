using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{

    public class RecursoBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public RecursoBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<RecursoResponse>> Listar()
        {
            return await new RecursoDAL(context, mapper).Listar();
        }

        public async Task<List<RecursoResponse>> Listar_Recursos_PT_Gantt(string pt, string desc, string fi, string fn)
        {
            return await new RecursoDAL(context, mapper).Listar_Recursos_PT_Gantt(pt, desc, fi, fn);
        }

    }
}