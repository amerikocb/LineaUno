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
    public class TabInstitucionService : ITabInstitucionService
    {
        private readonly BDVLPContext _context;
        private readonly IMapper _mapper;

        public TabInstitucionService(BDVLPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TabInstitucionResponse>> TabInstitucionListarPorEstadoEnOrdenPrioridadAsc(bool activos)
        {
            List<TabInstitucionResponse> listaInstitucionesRespuesta = new List<TabInstitucionResponse>();
            List<TabInstitucion> listaInstituciones;

            try
            {
                listaInstituciones = await _context.TabInstitucion.Where(x => x.BEstActivo == activos).AsNoTracking().OrderBy(x => x.TiNumPrioridad).ToListAsync();
                foreach (var institucion in listaInstituciones)
                {
                    listaInstitucionesRespuesta.Add(_mapper.Map<TabInstitucion, TabInstitucionResponse>(institucion));
                }
                return listaInstitucionesRespuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar institución" + ", Clase: " + this.GetType().Name + ", Metodo: TabInstitucionListarPorEstadoEnOrdenPrioridadAsc", ex);
            }
        }
    }
}
