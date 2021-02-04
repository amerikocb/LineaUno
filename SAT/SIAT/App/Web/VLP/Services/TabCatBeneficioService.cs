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
    public class TabCatBeneficioService: ITabCatBeneficioService
    {
        private readonly BDVLPContext _context;
        private readonly IMapper _mapper;

        public TabCatBeneficioService(BDVLPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TabCatBeneficioDisfrutaResponse>> TabCatBeneficioListarPorEstado(bool activos)
        {
            List<TabCatBeneficioDisfrutaResponse> listaCatBeneficioRespuesta = new List<TabCatBeneficioDisfrutaResponse>();
            List<TabCatBeneficio> listaCatBeneficioModel;

            try
            {
                listaCatBeneficioModel = await _context.TabCatBeneficio.Where(x => x.BEstActivo == activos).AsNoTracking().OrderBy(x => x.VNomCatBeneficio).ToListAsync();

                TabBeneficioService _tabBeneficioService = new TabBeneficioService(_context, _mapper);

                List<TabBeneficio> listaBeneficio = new List<TabBeneficio>();

                foreach (var institucion in listaCatBeneficioModel)
                {
                    institucion.TabBeneficio = await _tabBeneficioService.TabBeneficioListarPorCategoriaYEstado(institucion.SiCodCatBeneficio, activos);
                    listaCatBeneficioRespuesta.Add(_mapper.Map<TabCatBeneficio, TabCatBeneficioDisfrutaResponse>(institucion));
                }
                
                return listaCatBeneficioRespuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categoria de beneficios" + ", Clase: " + this.GetType().Name + ", Metodo: TabCatBeneficioListarPorEstado", ex);
            }
        }
    }
}
