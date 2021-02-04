using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class McdetCargaForDosBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McdetCargaForDosBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<List<McdetCargaForDosListadoResponse>> BusquedaDetalle(McdetCargaForDosListadoRequest request)
        {
            var McdetCargaForDosDAL = new McdetCargaForDosDAL(this.context, this.mapper);
            return await McdetCargaForDosDAL.BusquedaDetalle(request);
        }

        public async Task<McdetCargaForDosBusquedaEdicionResponse> BusquedaEdicion(McdetCargaForDosBusquedaEdicionRequest request)
        {
            var McdetCargaForDosDAL = new McdetCargaForDosDAL(this.context, this.mapper);
            return await McdetCargaForDosDAL.BusquedaEdicion(request);
        }

        public async Task<McdetCargaForDosEdicionResponse> Edicion(McdetCargaForDosEdicionRequest request)
        {
            var McdetCargaForDosDAL = new McdetCargaForDosDAL(this.context, this.mapper);
            return await McdetCargaForDosDAL.Edicion(request);
        }

        public async Task<ResStringResponse> ListarTrabajadores_Carga(int numCarga, int numDetCarga)
        {
            var McdetCargaForDosDAL = new McdetCargaForDosDAL(this.context, this.mapper);
            return await McdetCargaForDosDAL.ListarTrabajadores_Carga(numCarga, numDetCarga);
        }
    }
}
