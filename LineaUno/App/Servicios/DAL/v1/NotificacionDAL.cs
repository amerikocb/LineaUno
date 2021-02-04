using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class NotificacionDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public NotificacionDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<NotificacionBanResponse>> ListarNotificaciones_Bandeja()
        {
            try
            {
                var lista = await context.Query<NotificacionBanResponse>().FromSql("EXEC dbo.USP_LISTANOTBANDEJA").AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MotivosIncResponse>> ListarMotivosInconv_x_PT(int pt, int detPt)
        {
            try
            {
                var par = new SqlParameter("@PT", pt);
                var par1 = new SqlParameter("@DetPT", detPt);
                //var lista = await context.Query<ParametroValorResponse>().FromSql("[dbo].[USP_LISTA_MOTIVOS_NOT] @IdCategoria", par).AsNoTracking().ToListAsync();
                var lista = await context.Query<MotivosIncResponse>().FromSql("[dbo].[USP_LISTA_MOTIVOS_NOT] @PT, @DetPT", parameters: new[] { par, par1 }).AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PedidoTrabajoAccionesResponse> ResponderInconvenientePT(MCMovBanPTRequest request)
        {
            try
            {
                //MovBand
                var maxIdBan = await context.McmovBanPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(b => (int?)b.INumDesBanPt) ?? 0;

                var mov = await context.McmovBanPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                       && m.INumDetPt == request.iNumDetPT
                                                       && m.BEstRegistro == true
                                                       && m.INumDesBanPt == maxIdBan).AsNoTracking().FirstOrDefaultAsync() ?? null;
                var MCMovBanPT = new McmovBanPt
                {
                    BEstRegistro = true,
                    INumIdPt = request.iNumIdPT,
                    INumDetPt = request.iNumDetPT,
                    SdFecCreacion = DateTime.Now,
                    VCodUsuCreacion = request.vCodUsuarioCreacion,
                    INumDesBanPt = maxIdBan == 0 ? 1 : maxIdBan + 1,
                    CTipBandeja = "2",
                    CEstBandeja = "1",
                    ICodTraResponsable = mov.ICodTraResponsable,
                    vContenido = request.Mensaje,
                    SdFecIngreso = DateTime.Now,
                    CNomTerCreacion = request.Terminal
                };


                await context.McmovBanPt.AddAsync(MCMovBanPT);
                await context.SaveChangesAsync();

                mov.SdFecFinalizacion = DateTime.Now;
                mov.VCodUsuModificacion = request.vCodUsuarioCreacion;
                mov.CNomTerModificacion = request.Terminal;
                mov.SdFecModificacion = DateTime.Now;
                mov.CEstBandeja = "2";

                context.McmovBanPt.Update(mov);
                await context.SaveChangesAsync();

                if (request.Rutas != null)
                {
                    if (request.Rutas.Count() > 0)
                    {
                        foreach (var ruta in request.Rutas)
                        {
                            var maxIdAdj = await context.McmaeAdjPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                            && m.INumDetPt == request.iNumDetPT
                                                            && m.BEstRegistro == true).MaxAsync(b => (int?)b.INumDetAdjT) ?? 0;
                            var adjunto = new McmaeAdjPt
                            {
                                INumIdPt = request.iNumIdPT,
                                INumDetPt = request.iNumDetPT,
                                SdFecCreacion = DateTime.Now,
                                CNomTerCreacion = request.Terminal,
                                INumDetAdjT = maxIdAdj == 0 ? 1 : maxIdAdj + 1,
                                VRutaAdjunto = ruta,
                                ITipAdjunto = 2,
                                BEstRegistro = true,
                                VCodUsuCreacion = request.vCodUsuarioCreacion
                            };

                            await context.McmaeAdjPt.AddAsync(adjunto);
                            await context.SaveChangesAsync();

                        }
                    }
                }

                if (!string.IsNullOrEmpty(request.Email))
                {
                    var mailRequest = new McSendMailRequest
                    {
                        Asunto = "Se ha registrado una incidencia para el pedido de trabajo " + request.PedidoTrabajo,
                        Texto_Notificar = !string.IsNullOrEmpty(request.Mensaje) ? request.Mensaje : "Se ha registrado una incidencia para el pedido de trabajo " + request.PedidoTrabajo,
                        Cuenta_Notificar = request.Email,
                        Cuentas_Copias = "",
                        Profile_Correo = ""
                    };
                    //Descomentar la línea siguiente para enviar correo electrónico al responsable
                    SendMail(mailRequest);
                }

                return new PedidoTrabajoAccionesResponse
                {
                    Exito = true,
                    Mensaje = "Operacion realizada exitosamente"
                };

            }
            catch (Exception ex)
            {
                return new PedidoTrabajoAccionesResponse
                {
                    Exito = false,
                    Mensaje = "Ha ocurrido un error inesperado " + ex.Message
                };
            }
        }

        public async void SendMail(McSendMailRequest request)
        {
            try
            {
                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@ASUNTO",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 255,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Asunto
                        },
                        new SqlParameter() {
                            ParameterName = "@TEXTO_NOTIFICAR",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 4000,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Texto_Notificar
                        },
                        new SqlParameter() {
                            ParameterName = "@CUENTA_NOTIFICAR",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 255,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Cuenta_Notificar
                        },
                        new SqlParameter() {
                            ParameterName = "@CUENTAS_COPIAS",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = -1,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Cuentas_Copias
                        },
                        new SqlParameter() {
                            ParameterName = "@PROFILE_CORREO",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Profile_Correo
                        }};
                var result = await Task.Run(() => context.Database.ExecuteSqlCommand("EXEC [dbo].[USP_ENVIOEMAIL_LINEAUNO] @ASUNTO, @TEXTO_NOTIFICAR, @CUENTA_NOTIFICAR, @CUENTAS_COPIAS, @PROFILE_CORREO", param));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}