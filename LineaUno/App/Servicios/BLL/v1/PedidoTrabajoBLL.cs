using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class PedidoTrabajoBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public PedidoTrabajoBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<PedidoTrabajoResponse>> Listar()
        {
            return await new PedidoTrabajoDAL(context, mapper).Listar();    
        }

        public async Task<List<PedidoTrabajoResponse>> Listar_PT_Gantt(string pt, string desc, string fi, string fn)
        {
            return await new PedidoTrabajoDAL(context, mapper).Listar_PT_Gantt(pt, desc, fi, fn);
        }

        //
        public async Task<List<PedidoTrabajoBResponse>> Listar_x_Bandeja()
        {
            return await new PedidoTrabajoDAL(context, mapper).Listar_x_Bandeja();
        }

        public async Task<PedidoTrabajoAccionesResponse> Iniciar(MCMovEstadoPTRequest request)
        {
            var pedidoTrabajoDAL = new PedidoTrabajoDAL(this.context, this.mapper);
            return await pedidoTrabajoDAL.IniciarPedidoTrabajo(request);
        }

        public async Task<PedidoTrabajoAccionesResponse> RegistrarIncidencia(MCMovBanPTRequest request)
        {
            var pedidoTrabajoDAL = new PedidoTrabajoDAL(this.context, this.mapper);
            return await pedidoTrabajoDAL.RegistrarInconvenientePT(request);
        }

        public async Task<PedidoTrabajoAccionesResponse> Finalizar(MCMovEstadoPTRequest request)
        {
            var pedidoTrabajoDAL = new PedidoTrabajoDAL(this.context, this.mapper);
            return await pedidoTrabajoDAL.FinalizarPedidoTrabajo(request);
        }

    }
}