using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class McMaeTrabajadorDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McMaeTrabajadorDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<MCTrabajadorResponse>> ListarTrabajadores_Rec()
        {
            try
            {
                var lista = await context.Query<MCTrabajadorResponse>().FromSql("SELECT iCodTrabajador IdTrabajador, vNomTrabajador NombreTrabajador from MCMaeTrabajador where cTipTrabajador = 'REC' and bEstRegistro = 1").AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}