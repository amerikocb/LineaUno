using AutoMapper;
using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class ParametroValorBLL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public ParametroValorBLL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<ParametroValorResponse>> ListadoMotivos_x_Categoria(int idCategoria)
        {
            return await new ParametroValorDAL(context, mapper).ListadoMotivos_x_Categoria(idCategoria);
        }

        public async Task<List<ParametroValorResponse>> Listar_Cat_Inconveniente()
        {
            return await new ParametroValorDAL(context, mapper).Listar_Cat_Inconveniente();
        }

        public async Task<List<ParametroValorResponse>> ListarValores_x_ICodParametro(int iCodParametro)
        {
            return await new ParametroValorDAL(context, mapper).ListarValores_x_ICodParametro(iCodParametro);
        }

        public async Task<List<TablaValidarResponse>> ListarTabla_Validar()
        {
            return await new ParametroValorDAL(context, mapper).ListarTabla_Validar();
        }
    }
}
