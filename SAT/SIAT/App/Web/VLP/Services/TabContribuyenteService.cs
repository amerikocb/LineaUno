using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VLP.Contracts.v1.Request;
using VLP.Models;
using VLP.Services.Interfaces;

namespace VLP.Services
{
    public class TabContribuyenteService : ITabContribuyenteService
    {
        private readonly BDVLPContext _context;
        private readonly IMapper _mapper;

        public TabContribuyenteService(BDVLPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TabContribuyente> TabContribuyenteBuscarActivoVigente(TabContribuyenteValidoRequest request)
        {
            try
            {
                var contribuyenteRequest = _mapper.Map<TabContribuyenteValidoRequest, TabContribuyente>(request);
                var paramTipoDocumento = new SqlParameter("@TipDocumento", contribuyenteRequest.TiTipDocContribuyente);
                var paramNumDocumento = new SqlParameter("@NumDocumento", contribuyenteRequest.CNumDocContribuyente);
                TabContribuyente contribuyente = await _context.Set<TabContribuyente>().FromSql("exec spVLP_TabContribuyente_BuscarActivoVigente @TipDocumento, @NumDocumento", paramTipoDocumento, paramNumDocumento).AsNoTracking().SingleOrDefaultAsync();
                return contribuyente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar contribuyente" + ", Clase: " + this.GetType().Name + ", Metodo: TabContribuyenteBuscarActivoVigente", ex);
            }
        }
    }
}
