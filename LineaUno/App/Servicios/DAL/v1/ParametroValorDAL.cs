using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class ParametroValorDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public ParametroValorDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<ParametroValorResponse>> ListadoMotivos_x_Categoria(int idCategoria)
        {
            try
            {
                var par = new SqlParameter("@IdCategoria", idCategoria);
                var lista = await context.Query<ParametroValorResponse>().FromSql("[dbo].[USP_OBTENER_MOTIVOS_X_CATEGORIA] @IdCategoria", par).AsNoTracking().ToListAsync();
                //var lista = await context.Query<ParametroValorResponse>().FromSql("SELECT iCodParValor AS Id, vNomParValor AS Descripcion from [dbo].[MCTabParValor] where iCodParSeccion = 2 AND iCodParametro = @IdCodPar", par).AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ParametroValorResponse>> Listar_Cat_Inconveniente()
        {
            try
            {
                var par = new SqlParameter("@IdCodPar", 13);
                //var lista = await context.Query<ParametroValorResponse>().FromSql("[dbo].[USP_OBTENER_MOTIVOS_X_CATEGORIA] @IdCategoria", par).AsNoTracking().ToListAsync();
                var lista = await context.Query<ParametroValorResponse>().FromSql("SELECT iCodParValor AS Id, vNomParValor AS Descripcion from [dbo].[MCTabParValor] where iCodParSeccion = 2 AND iCodParametro = @IdCodPar", par).AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ParametroValorResponse>> GetAllMotives()
        {
            try
            {
                var par = new SqlParameter("@IdCategoria", 12);
                //var lista = await context.Query<ParametroValorResponse>().FromSql("[dbo].[USP_OBTENER_MOTIVOS_X_CATEGORIA] @IdCategoria", par).AsNoTracking().ToListAsync();
                var lista = await context.Query<ParametroValorResponse>().FromSql("SELECT iCodParValor AS Id, vNomParValor AS Descripcion from [dbo].[MCTabParValor] where iCodParSeccion = 2 AND iCodParametro = @IdCodPar", par).AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ParametroValorResponse>> ListarValores_x_ICodParametro(int iCodParametro)
        {
            try
            {
                var par = new SqlParameter("@IdCodPar", iCodParametro);
                //var lista = await context.Query<ParametroValorResponse>().FromSql("[dbo].[USP_OBTENER_MOTIVOS_X_CATEGORIA] @IdCategoria", par).AsNoTracking().ToListAsync();
                var lista = await context.Query<ParametroValorResponse>().FromSql("SELECT iCodParValor AS Id, vNomParValor AS Descripcion from [dbo].[MCTabParValor] where iCodParSeccion = 2 AND iCodParametro = @IdCodPar", par).AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TablaValidarResponse>> ListarTabla_Validar()
        {
            try
            {           
                var lista = await context.Query<TablaValidarResponse>().FromSql("[dbo].[USP_LISTATABVALIDACION]").AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
