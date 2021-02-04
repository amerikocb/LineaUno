using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class NotificacionBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public NotificacionBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<NotificacionBanResponse>> ListarNotificaciones_Bandeja()
        {
            return await new NotificacionDAL(this.context, mapper).ListarNotificaciones_Bandeja();
        }

        public async Task<PedidoTrabajoAccionesResponse> ResponderInconvenientePT(MCMovBanPTRequest request)
        {
            var notificacionDAL = new NotificacionDAL(this.context, this.mapper);
            return await notificacionDAL.ResponderInconvenientePT(request);
        }

        public async Task<List<MotivosIncResponse>> ListarMotivosInconv_x_PT(int pt, int detPt)
        {
            return await new NotificacionDAL(this.context, mapper).ListarMotivosInconv_x_PT(pt, detPt);
        }

    }
}