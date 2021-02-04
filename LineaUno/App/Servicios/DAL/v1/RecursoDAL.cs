using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class RecursoDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public RecursoDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<RecursoResponse>> Listar()
        {
            try
            {
                var lista = await context.Query<RecursoResponse>().FromSql("EXEC dbo.USP_LISTARECURSO").AsNoTracking().ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RecursoResponse>> Listar_Recursos_PT_Gantt(string pt, string desc, string fi, string fn)
        {

            try
            {
                SqlParameter par1 = new SqlParameter("@PT", System.Data.SqlDbType.VarChar, 200);
                SqlParameter par2 = new SqlParameter("@Desc", System.Data.SqlDbType.VarChar, 1000);
                SqlParameter par3 = new SqlParameter("@F_INI", System.Data.SqlDbType.VarChar, 15);
                SqlParameter par4 = new SqlParameter("@F_FIN", System.Data.SqlDbType.VarChar, 15);

                if (string.IsNullOrEmpty(pt)) par1.Value = DBNull.Value; else par1.Value = pt;
                if (string.IsNullOrEmpty(desc)) par2.Value = DBNull.Value; else par2.Value = desc;
                if (string.IsNullOrEmpty(fi)) par3.Value = DBNull.Value; else par3.Value = fi;
                if (string.IsNullOrEmpty(fn)) par4.Value = DBNull.Value; else par4.Value = fn;

                var lista = await context.Query<RecursoResponse>().FromSql("[dbo].[USP_LISTARECURSOSPTGANTT] @PT, @Desc, @F_INI, @F_FIN", parameters: new[] { par1, par2, par3, par4 }).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}