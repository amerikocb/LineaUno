using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLP.Contracts.v1.Response;
using VLP.Models;
using VLP.Services.Interfaces;

namespace VLP.Services
{
    public class TabBeneficioService: ITabBeneficioService
    {
        private readonly BDVLPContext _context;
        private readonly IMapper _mapper;

        public TabBeneficioService(BDVLPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TabBeneficio>> TabBeneficioListarPorCategoriaYEstado(byte categoria, bool activos)
        {
            List<TabBeneficio> listaBeneficio;

            try
            {
                //DateTime serverTime = _context.Query<DateTime>().FromSql("SELECT GETDATE()").AsEnumerable().FirstOrDefault();
                listaBeneficio = await _context.TabBeneficio.Where(x => x.BEstActivo == activos && x.SiCodCatBeneficio == categoria).AsNoTracking().OrderBy(x => x.TiNumPrioridad).ToListAsync();
                return listaBeneficio;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar beneficios" + ", Clase: " + this.GetType().Name + ", Metodo: TabBeneficioListarPorCategoriaYEstado", ex);
            }
        }
    }
}
