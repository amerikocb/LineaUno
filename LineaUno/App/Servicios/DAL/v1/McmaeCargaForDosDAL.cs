using AutoMapper;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Reflection;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class McmaeCargaForDosDAL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McmaeCargaForDosDAL(BDLINEAUNOContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<McmaeCargaForDosResponse> CargaExcel(McmaeCargaForDosRequest request)
        {
            try
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
                var log1 = LogManager.GetLogger(typeof(McmaeCargaForDosDAL));


                var file = request.File;

                if (file == null || file.Length <= 0)
                {
                    return new McmaeCargaForDosResponse
                    {
                        Exito = false,
                        Mensaje = "Archivo no ha sido seleccionado."
                    };
                }


                if (!(Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(file.FileName).Equals(".xls", StringComparison.OrdinalIgnoreCase)))
                {
                    return new McmaeCargaForDosResponse
                    {
                        Exito = false,
                        Mensaje = "Extension de archivo no soportada."
                    };
                }

                List<McdetCargaForDos> actividades = new List<McdetCargaForDos>();

                List<McmaeCargaTraForDos> tecnicos = new List<McmaeCargaTraForDos>();

                List<ErrorCargaExcel> errores = new List<ErrorCargaExcel>();

                var TabValidar = await context.Query<TablaValidarResponse>().FromSql("EXEC dbo.USP_LISTATABVALIDACION").AsNoTracking().ToListAsync();

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row1 = 2; row1 <= rowCount; row1++)
                        {
                            if (worksheet.Cells[row1, 1].Value != null)
                            {
                                string sMsjError = "";
                                DateTime fromDateValue;
                                var formats = new[] { "HH:mm:ss" };
                                int iCanTecnico = 0;                               

                                string sVNumPt = Convert.ToString(worksheet.Cells[row1, 1].Text).Trim();
                                if (sVNumPt.Length > 15)
                                {
                                    sMsjError += "Longitud Numero PT Excede,";
                                }

                                string sVParFecha = Convert.ToString(worksheet.Cells[row1, 2].Text);
                                if (DateTime.TryParse(sVParFecha, out fromDateValue) == false)
                                {
                                    sMsjError += "Formato Fecha,";
                                }

                                string sVHorInicio = Convert.ToString(worksheet.Cells[row1, 3].Text);
                                if (DateTime.TryParseExact(sVHorInicio, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue) == false)
                                {
                                    sMsjError += "Formato Hora Inicio,";
                                }

                                string sVHorFin = Convert.ToString(worksheet.Cells[row1, 4].Text);
                                if (DateTime.TryParseExact(sVHorFin, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue) == false)
                                {
                                    sMsjError += "Formato Hora Fin,";
                                }

                                var cAreResponsable = Convert.ToString(worksheet.Cells[row1, 5].Text).Trim();
                                if (TabValidar.Exists(x => x.Nombre == cAreResponsable && x.NomTabla == "ARE"))
                                {
                                    sMsjError += "";
                                }
                                else
                                {
                                    sMsjError += "Verificar Area Responsable,";
                                }

                                var cVZona = Convert.ToString(worksheet.Cells[row1, 8].Text).Trim();
                                if (TabValidar.Exists(x => x.Nombre == cVZona && x.NomTabla == "ZON"))
                                {
                                    sMsjError += "";
                                }
                                else
                                {
                                    sMsjError += "Verificar Zona,";
                                }

                                var cVTipActividad = Convert.ToString(worksheet.Cells[row1, 12].Text).Trim();
                                if (TabValidar.Exists(x => x.Nombre == cVTipActividad && x.NomTabla == "TAC"))
                                {
                                    sMsjError += "";
                                }
                                else
                                {
                                    sMsjError += "Verificar Tipo Actividad,";
                                }

                                var cVPrioridad = Convert.ToString(worksheet.Cells[row1, 13].Text).Trim();
                                if (TabValidar.Exists(x => x.Nombre == cVPrioridad && x.NomTabla == "PRI"))
                                {
                                    sMsjError += "";
                                }
                                else
                                {
                                    sMsjError += "Verificar Prioridad,";
                                }

                                if (errores.Exists(x => x.NumPT == sVNumPt))
                                {
                                    sMsjError = "Numero PT Duplicado,"+ sMsjError;
                                }
                                
                                var cVSupResConcar = Convert.ToString(worksheet.Cells[row1, 16].Text).Trim();
                                if (TabValidar.Exists(x => x.Nombre == cVSupResConcar && x.NomTabla == "TRA" && x.Tipo == "SUP"))
                                {
                                    sMsjError += "";
                                }
                                else
                                {
                                    sMsjError += "Verificar Supervisor,";
                                }

                                var cVRecurso1 = Convert.ToString(worksheet.Cells[row1, 22].Text).Trim();
                                if (cVRecurso1.Length > 0)                  
                                {
                                    if (TabValidar.Exists(x => x.Nombre == cVRecurso1 && x.NomTabla == "TRA" && x.Tipo == "REC"))
                                    {
                                        iCanTecnico += 1;    
                                    }
                                    else
                                    {
                                        sMsjError += "Verificar Tecnico 1,";
                                    }
                                }
                                var cVRecurso2 = Convert.ToString(worksheet.Cells[row1, 23].Text).Trim();
                                if (cVRecurso2.Length > 0)               
                                {
                                    if (TabValidar.Exists(x => x.Nombre == cVRecurso2 && x.NomTabla == "TRA" && x.Tipo == "REC"))
                                    {
                                        iCanTecnico += 1;
                                    }
                                    else
                                    {
                                        sMsjError += "Verificar Tecnico 2,";
                                    }
                                }
                                var cVRecurso3 = Convert.ToString(worksheet.Cells[row1, 24].Text).Trim();
                                if (cVRecurso3.Length > 0)                           
                                {
                                    if (TabValidar.Exists(x => x.Nombre == cVRecurso3 && x.NomTabla == "TRA" && x.Tipo == "REC"))
                                    {
                                        iCanTecnico += 1;
                                    }
                                    else
                                    {
                                        sMsjError += "Verificar Tecnico 3,";
                                    }
                                }

                                var cVRecurso4 = Convert.ToString(worksheet.Cells[row1, 25].Text).Trim();
                                if (cVRecurso4.Length > 0)                          
                                {
                                    if (TabValidar.Exists(x => x.Nombre == cVRecurso4 && x.NomTabla == "TRA" && x.Tipo == "REC"))
                                    {
                                        iCanTecnico += 1;
                                    }
                                    else
                                    {
                                        sMsjError += "Verificar Tecnico 4,";
                                    }
                                }

                                var cVRecurso5 = Convert.ToString(worksheet.Cells[row1, 26].Text).Trim();
                                if (cVRecurso5.Length > 0)                           
                                {
                                    if (TabValidar.Exists(x => x.Nombre == cVRecurso5 && x.NomTabla == "TRA" && x.Tipo == "REC"))
                                    {
                                        iCanTecnico += 1;
                                    }
                                    else
                                    {
                                        sMsjError += "Verificar Tecnico 5,";
                                    }
                                }

                                if (iCanTecnico == 0)
                                {
                                    sMsjError += "Especificar Algun Tecnico,";
                                }


                                var cVTeresConcar = Convert.ToString(worksheet.Cells[row1, 18].Text).Trim();
                                if (TabValidar.Exists(x => x.Nombre == cVTeresConcar && x.NomTabla == "TRA" && x.Tipo == "TEC"))
                                {
                                    sMsjError += "";
                                }
                                else
                                {
                                    sMsjError += "Verificar Tecnico Encargado,";
                                }

                                if (sMsjError.Length > 0)
                                {
                                    sMsjError = sMsjError.Substring(0, sMsjError.Length - 1);
                                }

                                errores.Add(new ErrorCargaExcel
                                {
                                    NumFila = row1,
                                    NumPT = sVNumPt,
                                    DesError = sMsjError
                                });                       
                            }
                        }

                        errores.RemoveAll(x => (x.DesError == ""));

                        if (errores.Count > 0)
                        {
                            

                            for (int i = 0; i < errores.Count; i++)
                            {
                                log1.Error(Convert.ToString(errores[i].NumFila) + " - "+ errores[i].DesError);
                            }

                            return new McmaeCargaForDosResponse
                            {
                                Exito = false,
                                Mensaje = "No fue posible cargar el archivo Excel"
                            };  
                        }

                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 1].Value != null)
                            {

                                string cVNumPt = Convert.ToString(worksheet.Cells[row, 1].Text).Trim(); 

                                string cVParFecha = Convert.ToString(worksheet.Cells[row, 2].Text).Trim();

                                string cVHorInicio = Convert.ToString(worksheet.Cells[row, 3].Text).Trim();

                                string cVHorFin = Convert.ToString(worksheet.Cells[row, 4].Text).Trim();

                                var cAreResponsable = Convert.ToString(worksheet.Cells[row, 5].Text).Trim();

                                var cVRazSocial = worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim();
                                if (cVRazSocial.Length > 200)
                                {
                                    cVRazSocial = cVRazSocial.Substring(0, 200);
                                }

                                var cVZona = Convert.ToString(worksheet.Cells[row, 8].Text).Trim(); 

                                var cVSecLinea = worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim();
                                if (cVSecLinea.Length > 25)
                                {
                                    cVSecLinea = cVSecLinea.Substring(0, 25);
                                }
                                
                                var cVZonEspecifica = worksheet.Cells[row, 10].Value == null ? "" : worksheet.Cells[row, 10].Value.ToString().Trim();
                                if (cVZonEspecifica.Length > 150)
                                {
                                    cVZonEspecifica = cVZonEspecifica.Substring(0, 150);
                                }

                                var cVDesActividad = worksheet.Cells[row, 11].Value == null ? "" : worksheet.Cells[row, 11].Value.ToString().Trim();
                                if (cVDesActividad.Length > 200)
                                {
                                    cVDesActividad = cVDesActividad.Substring(0, 200);
                                }

                                var cVTipActividad = Convert.ToString(worksheet.Cells[row, 12].Text).Trim(); 

                                var cVPrioridad = Convert.ToString(worksheet.Cells[row, 13].Text).Trim(); 

                                var cVPerIntervencion = worksheet.Cells[row, 14].Value == null ? "" : worksheet.Cells[row, 14].Value.ToString().Trim();
                                if (cVPerIntervencion.Length > 200)
                                {
                                    cVPerIntervencion = cVPerIntervencion.Substring(0, 200);
                                }

                                var cVRecMedios = worksheet.Cells[row, 15].Value == null ? "" : worksheet.Cells[row, 15].Value.ToString().Trim();
                                if (cVRecMedios.Length > 200)
                                {
                                    cVRecMedios = cVRecMedios.Substring(0, 200);
                                }

                                var cVSupResConcar = Convert.ToString(worksheet.Cells[row, 16].Text).Trim(); 

                                var cVCelSupResponsable = worksheet.Cells[row, 17].Value == null ? "" : worksheet.Cells[row, 17].Value.ToString().Trim();
                                if (cVCelSupResponsable.Length > 200)
                                {
                                    cVCelSupResponsable = cVCelSupResponsable.Substring(0, 200);
                                }

                                var cVTeresConcar = Convert.ToString(worksheet.Cells[row, 18].Text).Trim(); 

                                var cVCelTeresponsable = worksheet.Cells[row, 19].Value == null ? "" : worksheet.Cells[row, 19].Value.ToString().Trim();
                                if (cVCelTeresponsable.Length > 200)
                                {
                                    cVCelTeresponsable = cVCelTeresponsable.Substring(0, 200);
                                }

                                var cVResTercero = worksheet.Cells[row, 20].Value == null ? "" : worksheet.Cells[row, 20].Value.ToString().Trim();
                                if (cVResTercero.Length > 150)
                                {
                                    cVResTercero = cVResTercero.Substring(0, 150);
                                }

                                var cVCelTercero = worksheet.Cells[row, 21].Value == null ? "" : worksheet.Cells[row, 21].Value.ToString().Trim();
                                if (cVCelTercero.Length > 25)
                                {
                                    cVCelTercero = cVCelTercero.Substring(0, 25);
                                }

                                var cVRecurso1 = Convert.ToString(worksheet.Cells[row, 22].Text).Trim();

                                var cVRecurso2 = Convert.ToString(worksheet.Cells[row, 23].Text).Trim();

                                var cVRecurso3 = Convert.ToString(worksheet.Cells[row, 24].Text).Trim();

                                var cVRecurso4 = Convert.ToString(worksheet.Cells[row, 25].Text).Trim();

                                var cVRecurso5 = Convert.ToString(worksheet.Cells[row, 26].Text).Trim();

                                if (cVRecurso1.Length > 0)
                                 {
                                    var iCRecurso1 = TabValidar.Find(x => x.Nombre == cVRecurso1 && x.NomTabla == "TRA" && x.Tipo == "REC");
                                    tecnicos.Add(new McmaeCargaTraForDos
                                    {
                                        INumDetCarga = row - 1,
                                        ICodTrabjador = iCRecurso1.Codigo,
                                        BEstRegistro = true,
                                        VCodUsuCreacion = request.UsuarioCreacion,                                      
                                        CNomTerCreacion = request.TerminalCreacion
                                    });
                                }

                                if (cVRecurso2.Length > 0)
                                {
                                    var iCRecurso2 = TabValidar.Find(x => x.Nombre == cVRecurso2 && x.NomTabla == "TRA" && x.Tipo == "REC");
                                    tecnicos.Add(new McmaeCargaTraForDos
                                    {
                                        INumDetCarga = row - 1,
                                        ICodTrabjador = iCRecurso2.Codigo,
                                        BEstRegistro = true,
                                        VCodUsuCreacion = request.UsuarioCreacion,
                                        CNomTerCreacion = request.TerminalCreacion
                                    });
                                }

                                if (cVRecurso3.Length > 0)
                                {
                                    var iCRecurso3 = TabValidar.Find(x => x.Nombre == cVRecurso3 && x.NomTabla == "TRA" && x.Tipo == "REC");
                                    tecnicos.Add(new McmaeCargaTraForDos
                                    {
                                        INumDetCarga = row - 1,
                                        ICodTrabjador = iCRecurso3.Codigo,
                                        BEstRegistro = true,
                                        VCodUsuCreacion = request.UsuarioCreacion,
                                        CNomTerCreacion = request.TerminalCreacion
                                    });
                                }


                                if (cVRecurso4.Length > 0)
                                {
                                    var iCRecurso4 = TabValidar.Find(x => x.Nombre == cVRecurso4 && x.NomTabla == "TRA" && x.Tipo == "REC");
                                    tecnicos.Add(new McmaeCargaTraForDos
                                    {
                                        INumDetCarga = row - 1,
                                        ICodTrabjador = iCRecurso4.Codigo,
                                        BEstRegistro = true,
                                        VCodUsuCreacion = request.UsuarioCreacion,
                                        CNomTerCreacion = request.TerminalCreacion
                                    });
                                }

                                if (cVRecurso5.Length > 0)
                                {
                                    var iCRecurso5 = TabValidar.Find(x => x.Nombre == cVRecurso5 && x.NomTabla == "TRA" && x.Tipo == "REC");
                                    tecnicos.Add(new McmaeCargaTraForDos
                                    {
                                        INumDetCarga = row - 1,
                                        ICodTrabjador = iCRecurso5.Codigo,
                                        BEstRegistro = true,
                                        VCodUsuCreacion = request.UsuarioCreacion,
                                        CNomTerCreacion = request.TerminalCreacion
                                    });
                                }


                                actividades.Add(new McdetCargaForDos
                                {
                                    INumDetCarga = row - 1,
                                    VNumPt = cVNumPt, //worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim(),
                                    VParFecha = cVParFecha, //worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim(),
                                    VHorInicio = cVHorInicio, //worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim(),
                                    VHorFin = cVHorFin, // worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim(),
                                    VAreResponsable = cAreResponsable, //worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim(),
                                    VRuc = worksheet.Cells[row, 6].Value == null ? "" : worksheet.Cells[row, 6].Value.ToString().Trim(),
                                    VRazSocial = cVRazSocial, // worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim(),
                                    VZona = cVZona, //worksheet.Cells[row, 8].Value == null ? "" : worksheet.Cells[row, 8].Value.ToString().Trim(),
                                    VSecLinea = cVSecLinea, //worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim(),
                                    VZonEspecifica = cVZonEspecifica, //worksheet.Cells[row, 10].Value == null ? "" : worksheet.Cells[row, 10].Value.ToString().Trim(),
                                    VDesActividad = cVDesActividad, //worksheet.Cells[row, 11].Value == null ? "" : worksheet.Cells[row, 11].Value.ToString().Trim(),
                                    VTipActividad = cVTipActividad, //worksheet.Cells[row, 12].Value == null ? "" : worksheet.Cells[row, 12].Value.ToString().Trim(),
                                    VPrioridad = cVPrioridad, //worksheet.Cells[row, 13].Value == null ? "" : worksheet.Cells[row, 13].Value.ToString().Trim(),
                                    VPerIntervencion = cVPerIntervencion, //worksheet.Cells[row, 14].Value == null ? "" : worksheet.Cells[row, 14].Value.ToString().Trim(),
                                    VRecMedios = cVRecMedios, //worksheet.Cells[row, 15].Value == null ? "" : worksheet.Cells[row, 15].Value.ToString().Trim(),
                                    VSupResConcar = cVSupResConcar, //worksheet.Cells[row, 16].Value == null ? "" : worksheet.Cells[row, 16].Value.ToString().Trim(),
                                    VCelSupResponsable = cVCelSupResponsable, //worksheet.Cells[row, 17].Value == null ? "" : worksheet.Cells[row, 17].Value.ToString().Trim(),
                                    VTeresConcar = cVTeresConcar, // worksheet.Cells[row, 18].Value == null ? "" : worksheet.Cells[row, 18].Value.ToString().Trim(),
                                    VCelTeresponsable = cVCelTeresponsable, //worksheet.Cells[row, 19].Value == null ? "" : worksheet.Cells[row, 19].Value.ToString().Trim(),
                                    VResTercero = cVResTercero, //worksheet.Cells[row, 20].Value == null ? "" : worksheet.Cells[row, 20].Value.ToString().Trim(),
                                    VCelTercero = cVCelTercero, //worksheet.Cells[row, 21].Value == null ? "" : worksheet.Cells[row, 21].Value.ToString().Trim(),
                                    vTecnicoUno = cVRecurso1,
                                    vTecnicoDos = cVRecurso2,
                                    vTecnicoTres = cVRecurso3,
                                    vTecnicoCuatro = cVRecurso4,
                                    vTecnicoCinco = cVRecurso5,
                                    VCodUsuCreacion = request.UsuarioCreacion,
                                    CNomTerCreacion = request.TerminalCreacion
                                });
                            }
                        }
                    }
                }

                var McmaeCargaForDos = mapper.Map<McmaeCargaForDosRequest, McmaeCargaForDos>(request);

                McmaeCargaForDos.BEstRegistro = true;
                McmaeCargaForDos.McdetCargaForDos = actividades;
                McmaeCargaForDos.McmaeCargaTraForDos = tecnicos;

                await GrabarMaeCargaActividad(McmaeCargaForDos);
                if (McmaeCargaForDos.INumCarga > 0)
                {
                    return new McmaeCargaForDosResponse
                    {
                        Exito = true,
                        Mensaje = "Archivo cargado exitosamente."                        
                };
                }
                else
                {
                    return new McmaeCargaForDosResponse
                    {
                        Exito = false,
                        Mensaje = "No fue posible cargar el archivo Excel"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GrabarMaeCargaActividad(McmaeCargaForDos McmaeCargaForDos)
        {
            int codigo = 0;
            try
            {
                await context.McmaeCargaForDos.AddAsync(McmaeCargaForDos);
                codigo = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
            return codigo;
        }

        public async void GrabarListaDetCargaActividad(List<McdetCargaForDos> ListMcdetCargaForDos)
        {
            try
            {
                await context.McdetCargaForDos.AddRangeAsync(ListMcdetCargaForDos);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<McmaeCargaForDosListadoResponse>> BusquedaCabecera(McmaeCargaForDosListadoRequest request)
        {
            try
            {
                var maeCargaActividadListado = await context.McmaeCargaForDos.Where(x => x.BEstRegistro == request.Activo).AsNoTracking().ToListAsync();
                return mapper.Map<List<McmaeCargaForDos>, List<McmaeCargaForDosListadoResponse>>(maeCargaActividadListado);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoTrabajoAccionesResponse> ProcesarPlantilla(int numC, string user, string compu)
        {
            try
            {
                SqlParameter par1 = new SqlParameter("@piINumCarga", System.Data.SqlDbType.VarChar, 200);
                SqlParameter par2 = new SqlParameter("@pvUsuario", System.Data.SqlDbType.VarChar, 1000);
                SqlParameter par3 = new SqlParameter("@pcNomTer", System.Data.SqlDbType.VarChar, 15);

                if (string.IsNullOrEmpty(numC.ToString())) par1.Value = DBNull.Value; else par1.Value = numC;
                if (string.IsNullOrEmpty(user)) par2.Value = DBNull.Value; else par2.Value = user;
                if (string.IsNullOrEmpty(compu)) par3.Value = DBNull.Value; else par3.Value = compu;

                await Task.Run(() => context.Database.ExecuteSqlCommand("[dbo].[USP_PROCESAFORDOS] @piINumCarga, @pvUsuario, @pcNomTer", parameters: new[] { par1, par2, par3 }));
                //var lista = await context.Query<int>().FromSql("[dbo].[USP_PROCESAFORDOS] @piINumCarga, @pvUsuario, @pcNomTer", parameters: new[] { par1, par2, par3 }).AsNoTracking().ToListAsync();
                return new PedidoTrabajoAccionesResponse
                {
                    Exito = true,
                    Mensaje = "Procesado exitosamente"
                };
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return new PedidoTrabajoAccionesResponse
                {
                    Exito = false,
                    Mensaje = "Verificar la Plantilla de Carga"
                };
            }
        }
    }
}
