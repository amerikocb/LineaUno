using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class McdetCargaForDosDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McdetCargaForDosDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<List<McdetCargaForDosListadoResponse>> BusquedaDetalle(McdetCargaForDosListadoRequest request)
        {
            try
            {
                var McdetCargaForDosListado = await context.McdetCargaForDos.Where(x => x.INumCarga == request.CodigoCarga).AsNoTracking().ToListAsync();
                return mapper.Map<List<McdetCargaForDos>, List<McdetCargaForDosListadoResponse>>(McdetCargaForDosListado);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<McdetCargaForDosBusquedaEdicionResponse> BusquedaEdicion(McdetCargaForDosBusquedaEdicionRequest request)
        {
            try
            {
                var McdetCargaForDosBusquedaEdicion = await context.McdetCargaForDos.Where(x => x.INumCarga == request.NumCarga &&
                                                                                                x.INumDetCarga == request.CodigoDetalle).AsNoTracking().FirstOrDefaultAsync();
                return mapper.Map<McdetCargaForDos, McdetCargaForDosBusquedaEdicionResponse>(McdetCargaForDosBusquedaEdicion);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<McdetCargaForDosEdicionResponse> Edicion(McdetCargaForDosEdicionRequest request)
        {
            try
            {
                int actualizadoCorrectamente = 0;
                var McdetCargaForDosEdicion = await context.McdetCargaForDos.Where(x => x.INumCarga == request.NumCarga &&
                                                                                        x.INumDetCarga == request.CodigoDetalle).AsNoTracking().FirstOrDefaultAsync();
                if (McdetCargaForDosEdicion != null) {
                    McdetCargaForDosEdicion.VRuc = request.Ruc;
                    McdetCargaForDosEdicion.VRazSocial = request.RazonSocial;
                    McdetCargaForDosEdicion.VZonEspecifica = request.ZonaEspecifica;
                    McdetCargaForDosEdicion.VPrioridad = request.Prioridad;
                    McdetCargaForDosEdicion.VPerIntervencion = request.PermisoInt;

                    context.McdetCargaForDos.Update(McdetCargaForDosEdicion);
                    actualizadoCorrectamente = await context.SaveChangesAsync();
                }
                if (!string.IsNullOrEmpty(request.Trabajadores))
                {
                    //var pt = await context.McmaePt.Where(t => t.VNumPt == McdetCargaForDosEdicion.VNumPt).AsNoTracking().FirstOrDefaultAsync();

                    var trab = request.Trabajadores.Split(',');
                    var trabajadoresToDisable = await context.McmaeCargaTraForDos.Where(x => x.INumCarga == request.NumCarga &&
                                                                                x.INumDetCarga == request.CodigoDetalle &&
                                                                                !trab.Contains(x.ICodTrabjador.ToString()) &&
                                                                                x.BEstRegistro == true).AsNoTracking().ToListAsync();

                    foreach (var item in trab)
                    {
                        var traForDos = await context.McmaeCargaTraForDos.Where(x => x.INumCarga == request.NumCarga &&
                                                                                x.INumDetCarga == request.CodigoDetalle &&
                                                                                x.ICodTrabjador == int.Parse(item)).AsNoTracking().FirstOrDefaultAsync();

                        if (traForDos == null)
                        {
                            McmaeCargaTraForDos tpt = new McmaeCargaTraForDos
                            {
                                INumCarga = request.NumCarga,
                                INumDetCarga = request.CodigoDetalle,
                                BEstRegistro = true,
                                VCodUsuCreacion = request.Usuario,
                                SdFecCreacion = DateTime.Now,
                                CNomTerCreacion = request.NombreTerminal,
                                ICodTrabjador = int.Parse(item)

                            };

                            await context.McmaeCargaTraForDos.AddAsync(tpt);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            traForDos.CNomTerModificacion = request.NombreTerminal;
                            traForDos.VCodUsuModificacion = request.Usuario;
                            traForDos.SdFecModificacion = DateTime.Now;
                            traForDos.BEstRegistro = true;

                            context.McmaeCargaTraForDos.Update(traForDos);
                            int r = await context.SaveChangesAsync();
                        }
                    }

                    if (trabajadoresToDisable != null)
                    {
                        foreach (var item in trabajadoresToDisable)
                        {
                            item.BEstRegistro = false;
                            context.McmaeCargaTraForDos.Update(item);
                            int r = await context.SaveChangesAsync();
                        }
                    }
                }
                if (actualizadoCorrectamente > 0)
                {
                    return new McdetCargaForDosEdicionResponse
                    {
                        Exito = true,
                        Mensaje = "Detalle de carga fue actualizado exitosamente."
                    };
                }
                else {
                    return new McdetCargaForDosEdicionResponse
                    {
                        Exito = false,
                        Mensaje = "Detalle de carga no fue actualizado correctamente."
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResStringResponse> ListarTrabajadores_Carga(int numCarga, int numDetCarga)
        {
            try
            {
                var par = new SqlParameter("@NumCarga", numCarga);
                var par1 = new SqlParameter("@NumDetalleCarga", numDetCarga);
                //var lista = await context.Query<ParametroValorResponse>().FromSql("[dbo].[USP_LISTA_MOTIVOS_NOT] @IdCategoria", par).AsNoTracking().ToListAsync();
                var result = await context.Query<ResStringResponse>().FromSql("[dbo].[USP_OBTENER_TRABAJADORES_CARGADETALLE] @NumCarga, @NumDetalleCarga", parameters: new[] { par, par1 }).AsNoTracking().FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
