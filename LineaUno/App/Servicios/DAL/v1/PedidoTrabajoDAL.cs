using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class PedidoTrabajoDAL
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public PedidoTrabajoDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<PedidoTrabajoResponse>> Listar()
        {
            try
            {
                var lista = await context.Query<PedidoTrabajoResponse>().FromSql("EXEC dbo.USP_LISTAPT").AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PedidoTrabajoResponse>> Listar_PT_Gantt(string pt, string desc, string fi, string fn)
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

                var lista = await context.Query<PedidoTrabajoResponse>().FromSql("[dbo].[USP_LISTARPTGANTT] @PT, @Desc, @F_INI, @F_FIN", parameters: new[] { par1, par2, par3, par4 }).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PedidoTrabajoBResponse>> Listar_x_Bandeja()
        {
            try
            {
                var lista = await context.Query<PedidoTrabajoBResponse>().FromSql("[dbo].[USP_LISTAPTBANDEJA]").AsNoTracking().ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PedidoTrabajoAccionesResponse> IniciarPedidoTrabajo(MCMovEstadoPTRequest request)
        {
            try
            {
                var inconvenienteNotRespons = await context.McmovBanPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                                          && m.INumDetPt == request.iNumDetPT
                                                                          && m.CEstBandeja == "1"
                                                                          && m.CTipBandeja == "1"
                                                                          && m.BEstRegistro == true).AsNoTracking().AsNoTracking().FirstOrDefaultAsync();

                if (inconvenienteNotRespons == null)
                {
                    var maxIdEst = await context.McmovEstPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(m => (int?)m.INumDetEstPt) ?? 0;
                    var MCMovEstadoPT = new McmovEstPt
                    {
                        BEstRegistro = true,
                        CEstPt = "E",
                        INumIdPt = request.iNumIdPT,
                        INumDetPt = request.iNumDetPT,
                        SdFecCreacion = DateTime.Now,
                        SdFecIniEstado = DateTime.Now,
                        VCodUsuCreacion = request.vCodUsuarioCreacion,
                        INumDetEstPt = maxIdEst == 0 ? 1 : maxIdEst + 1,
                        CNomTerCreacion = request.Terminal
                    };


                    await context.McmovEstPt.AddAsync(MCMovEstadoPT);
                    await context.SaveChangesAsync();

                    var McMaePT = await context.McmaePt.Where(x => x.INumIdPt == request.iNumIdPT).AsNoTracking().FirstOrDefaultAsync();

                    McMaePT.CEstPt = "E";
                    McMaePT.VCodUsuModificacion = request.vCodUsuarioCreacion;
                    McMaePT.SdFecModificacion = DateTime.Now;
                    McMaePT.CNomTerModificacion = request.Terminal;

                    context.McmaePt.Update(McMaePT);
                    await context.SaveChangesAsync();

                    return new PedidoTrabajoAccionesResponse
                    {
                        Exito = true,
                        Mensaje = "Operacion realizada exitosamente"
                    };
                } else
                {
                    return new PedidoTrabajoAccionesResponse
                    {
                        Exito = false,
                        Mensaje = "PT tiene incidente pendiente de responder "
                    };
                }
                

            }
            catch (Exception ex)
            {
                return new PedidoTrabajoAccionesResponse
                {
                    Exito = false,
                    Mensaje = "Ha ocurrido un error inesperado " + ex.InnerException.Message
                };
            }
        }

        public async Task<PedidoTrabajoAccionesResponse> RegistrarInconvenientePT(MCMovBanPTRequest request)
        {
            try
            {

                var listaMotivos = !string.IsNullOrEmpty(request.VTipInconveniente)? request.VTipInconveniente.Split(','): null;
                //Movimiento de Estado
                var maxIdEst = await context.McmovEstPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(m => (int?)m.INumDetEstPt)?? 0;

                var mov = await context.McmovEstPt.Where(m => m.INumIdPt == request.iNumIdPT 
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true
                                                        && m.INumDetEstPt == maxIdEst).AsNoTracking().FirstOrDefaultAsync()?? null;
                var MCMovEstadoPT = new McmovEstPt
                {
                    BEstRegistro = true,
                    CEstPt = "I",
                    INumIdPt = request.iNumIdPT,
                    INumDetPt = request.iNumDetPT,
                    SdFecCreacion = DateTime.Now,
                    SdFecIniEstado = DateTime.Now,
                    VCodUsuCreacion = request.vCodUsuarioCreacion,
                    INumDetEstPt = mov == null ? 1 : mov.INumDetEstPt + 1,
                    CNomTerCreacion = request.Terminal
                };


                await context.McmovEstPt.AddAsync(MCMovEstadoPT);
                await context.SaveChangesAsync();

                //Actualizar registro anterior
                mov.SdFecFinEstado = DateTime.Now;
                mov.VCodUsuModificacion = request.vCodUsuarioCreacion;
                mov.CNomTerModificacion = request.Terminal;
                mov.SdFecModificacion = DateTime.Now;

                context.McmovEstPt.Update(mov);
                await context.SaveChangesAsync();

                //MovBand
                var maxIdBan = await context.McmovBanPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(b => (int?)b.INumDesBanPt)?? 0;


                var MCMovBanPT = new McmovBanPt
                {
                    BEstRegistro = true,
                    INumIdPt = request.iNumIdPT,
                    INumDetPt = request.iNumDetPT,
                    SdFecCreacion = DateTime.Now,
                    VCodUsuCreacion = request.vCodUsuarioCreacion,
                    INumDesBanPt = maxIdBan == 0 ? 1 : maxIdBan + 1,
                    CTipBandeja = "1",
                    CEstBandeja = "1",
                    ICodTraResponsable = request.ICodTraResponsable,
                    vContenido = request.Mensaje,
                    SdFecIngreso = DateTime.Now,
                    CNomTerCreacion = request.Terminal
                };

                await context.McmovBanPt.AddAsync(MCMovBanPT);
                await context.SaveChangesAsync();

                var maxIdMovInc = await context.McmovIncPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(b => (int?)b.INumDetIncPt) ?? 0;
                if (listaMotivos != null)
                {
                    foreach (var item in listaMotivos)
                    {
                        var MCMovIncPT = new McmovIncPT
                        {
                            BEstRegistro = true,
                            INumIdPt = request.iNumIdPT,
                            INumDetPt = request.iNumDetPT,
                            INumDetIncPt = maxIdMovInc == 0 ? 1 : maxIdMovInc + 1,
                            SdFecCreacion = DateTime.Now,
                            VCodUsuCreacion = request.vCodUsuarioCreacion,
                            ICodCatInconveniente = int.Parse(item.Split('|')[1]),
                            ICodMotInconveniente = int.Parse(item.Split('|')[0]),
                            CNomTerCreacion = request.Terminal
                        };

                        await context.McmovIncPt.AddAsync(MCMovIncPT);
                        await context.SaveChangesAsync();

                        maxIdMovInc += 1;
                    }
                }

                if (!string.IsNullOrEmpty(request.VDescInconveniente))
                {
                    var maxIdMovInc1 = await context.McmovIncPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(b => (int?)b.INumDetIncPt) ?? 0;
                    var MCMovIncPT = new McmovIncPT
                    {
                        BEstRegistro = true,
                        INumIdPt = request.iNumIdPT,
                        INumDetPt = request.iNumDetPT,
                        INumDetIncPt = maxIdMovInc1 == 0 ? 1 : maxIdMovInc1 + 1,
                        SdFecCreacion = DateTime.Now,
                        VCodUsuCreacion = request.vCodUsuarioCreacion,
                        ICodCatInconveniente = request.IdCategoria,
                        CNomTerCreacion = request.Terminal,
                        vDesMotInconveniente = request.VDescInconveniente
                    };

                    await context.McmovIncPt.AddAsync(MCMovIncPT);
                    await context.SaveChangesAsync();
                }

                var McMaePT = await context.McmaePt.Where(x => x.INumIdPt == request.iNumIdPT).AsNoTracking().FirstOrDefaultAsync();

                McMaePT.CEstPt = "I";
                McMaePT.VCodUsuModificacion = request.vCodUsuarioCreacion;
                McMaePT.CNomTerModificacion = request.Terminal;
                McMaePT.SdFecModificacion = DateTime.Now;

                context.McmaePt.Update(McMaePT);
                await context.SaveChangesAsync();

                if (request.Rutas != null)
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
                            ITipAdjunto = 1,
                            BEstRegistro = true,
                            VCodUsuCreacion = request.vCodUsuarioCreacion
                        };

                        await context.McmaeAdjPt.AddAsync(adjunto);
                        await context.SaveChangesAsync();

                    }
                }

                if (!string.IsNullOrEmpty(request.Email))
                {
                    var mailRequest = new McSendMailRequest
                    {
                        Asunto = "Se ha registrado una incidencia para el pedido de trabajo " + request.PedidoTrabajo,
                        Texto_Notificar = !string.IsNullOrEmpty(request.Mensaje)? request.Mensaje: "Se ha registrado una incidencia para el pedido de trabajo " + request.PedidoTrabajo,
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

        public async void SendMail (McSendMailRequest request)
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

        public async Task<PedidoTrabajoAccionesResponse> FinalizarPedidoTrabajo(MCMovEstadoPTRequest request)
        {
            try
            {
                var maxIdEst = await context.McmovEstPt.Where(m => m.INumIdPt == request.iNumIdPT
                                                        && m.INumDetPt == request.iNumDetPT
                                                        && m.BEstRegistro == true).MaxAsync(m => (int?)m.INumDetEstPt) ?? 0;
                var MCMovEstadoPT = new McmovEstPt
                {
                    BEstRegistro = true,
                    CEstPt = "T",
                    INumIdPt = request.iNumIdPT,
                    INumDetPt = request.iNumDetPT,
                    SdFecCreacion = DateTime.Now,
                    SdFecIniEstado = DateTime.Now,
                    VCodUsuCreacion = request.vCodUsuarioCreacion,
                    INumDetEstPt = maxIdEst == 0 ? 1 : maxIdEst + 1,
                    CNomTerCreacion = request.Terminal
                };


                await context.McmovEstPt.AddAsync(MCMovEstadoPT);
                await context.SaveChangesAsync();

                var McMaePT = await context.McmaePt.Where(x => x.INumIdPt == request.iNumIdPT).AsNoTracking().FirstOrDefaultAsync();

                McMaePT.CEstPt = "T";
                McMaePT.VCodUsuModificacion = request.vCodUsuarioCreacion;
                McMaePT.SdFecModificacion = DateTime.Now;
                McMaePT.CNomTerModificacion = request.Terminal;

                context.McmaePt.Update(McMaePT);
                await context.SaveChangesAsync();

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
                    Mensaje = "Ha ocurrido un error inesperado " + ex.InnerException.Message
                };
            }
        }

    }
}