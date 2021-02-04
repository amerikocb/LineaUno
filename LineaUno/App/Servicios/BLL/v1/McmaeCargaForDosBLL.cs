using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class McmaeCargaForDosBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McmaeCargaForDosBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<McmaeCargaForDosResponse> CargaExcel(McmaeCargaForDosRequest request)
        {
            var McmaeCargaForDosDAL = new McmaeCargaForDosDAL(this.context, this.mapper);
            return await McmaeCargaForDosDAL.CargaExcel(request);
        }

        public async Task<List<McmaeCargaForDosListadoResponse>> BusquedaCabecera(McmaeCargaForDosListadoRequest request)
        {
            var McmaeCargaForDosDAL = new McmaeCargaForDosDAL(this.context, this.mapper);
            return await McmaeCargaForDosDAL.BusquedaCabecera(request);
        }

        public async Task<PedidoTrabajoAccionesResponse> ProcesarPlantilla(int numC, string user, string compu)
        {
            var McmaeCargaForDosDAL = new McmaeCargaForDosDAL(this.context, this.mapper);
            return await McmaeCargaForDosDAL.ProcesarPlantilla(numC, user, compu);
        }
    }
}
