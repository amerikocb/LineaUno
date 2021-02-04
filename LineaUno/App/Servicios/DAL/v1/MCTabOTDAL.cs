using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class MCTabOTDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;
       
        public MCTabOTDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }


        //public async Task<List<MCTabOTListadoResponse>> BusquedaListado(MCTabOTListadoRequest request)
        //{
        //    try
        //    {
        //        var mcTabOTListado = await context.MCTabOT.Where(x => x.bEstRegistro == request.Activo).AsNoTracking().ToListAsync();
        //        return mapper.Map<List<MCTabOT>, List<MCTabOTListadoResponse>>(mcTabOTListado);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
