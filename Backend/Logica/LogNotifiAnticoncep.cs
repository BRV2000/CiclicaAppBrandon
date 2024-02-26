using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Backend.Logica
{
    public class LogNotifiAnticoncep
    {
        //Metodos para cada procedimiento de la base de datos.
        public ResInsertarNotificaciones InsertarNotificaciones(ReqInsertarNotificaciones req)
        {
            ResInsertarNotificaciones res = new ResInsertarNotificaciones();
            try
            {
                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else if (req.notifiAnticoncep.Notifi_Anti_Concep_ID >= 7)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.AnticonceptivoInexistente;
                    res.errorMensaje = "Anticonceptivo inexistente";
                }
                else if (req.notifiAnticoncep.Notifi_Start_Time == null)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.AnticonceptivoInexistente;
                    res.errorMensaje = "Hora faltante";
                }
                else if (req.notifiAnticoncep.Notifi_Start_Date == null)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.AnticonceptivoInexistente;
                    res.errorMensaje = "Fecha faltante";
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;
                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.sp_InsertarNotificacion(ref idReturn, ref errorId, ref errorDescripcion, userId, req.notifiAnticoncep.Notifi_Anti_Concep_ID, req.notifiAnticoncep.Notifi_Start_Date, req.notifiAnticoncep.Notifi_Start_Time);
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.resultado = true;
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.ErrorDeNotificacion;
                        res.errorMensaje = "Error Al Insertar Notificacion";
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorCode = (int)EnumErrores.ErrorInterno;
                res.errorMensaje = "Error Interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        public ResActualizarNotificaciones actualizarNotificaciones(ReqActualizarNotificaciones req)
        {
            ResActualizarNotificaciones res = new ResActualizarNotificaciones();
            try
            {
                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;
                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.sp_ActualizarNotificacion(ref idReturn, ref errorId, ref errorDescripcion, userId);
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.resultado = true;

                    }
                    else if (errorId == 22 && idReturn != 0)
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.EstadoDeNotifi_0;
                        res.errorMensaje = "Estado Notificacion en 0";
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.ErrorDeNotificacion;
                        res.errorMensaje = "Error Al Actualizar Notificacion";
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorCode = (int)EnumErrores.ErrorInterno;
                res.errorMensaje = "Error Interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        public ResObtenerAnticonceptivos obtenerAnticonceptivos(ReqObtenerAnticonceptivos req)
        {
            ResObtenerAnticonceptivos res = new ResObtenerAnticonceptivos();
            try
            {
                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;
                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    List<sp_ObtenerAnticonceptivosResult> listaDeAnticoncep = new List<sp_ObtenerAnticonceptivosResult>(); //Todos los Select ocupan guardar la Lista de los elementos de DB
                    listaDeAnticoncep = miLinq.sp_ObtenerAnticonceptivos(ref idReturn, ref errorId, ref errorDescripcion, userId).ToList();
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.ListaDeAnticoncepDatos= ArmarListaAnticoncep(listaDeAnticoncep);
                        res.resultado = true;
                        res.errorCode = 0;
                        res.errorMensaje = "Exitoso";
                    }
                    else if (errorId == 22 && idReturn != 0)
                    {
                        res.ListaDeAnticoncepDatos = ArmarListaAnticoncep(listaDeAnticoncep);
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.EstadoDeNotifi_0;
                        res.errorMensaje = "Estado Notificacion en 0";
                    }
                    else if (errorId == 23 && idReturn != 0)
                    {
                        res.ListaDeAnticoncepDatos = ArmarListaAnticoncep(listaDeAnticoncep);
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.SinRegistro;
                        res.errorMensaje = "No hay registro de notificaciones";
                    }
                    else 
                    {
                        Console.WriteLine("Error al obtener el anticonceptivo. Descripción del error: " + errorDescripcion);
                        res.resultado = false;
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorCode = (int)EnumErrores.ErrorInterno;
                res.errorMensaje = "Error Interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        } 
        public  ResHistorialAnticonceptivos historialAnticonceptivos(ReqHistorialAnticonceptivos req)
        {
            ResHistorialAnticonceptivos res = new ResHistorialAnticonceptivos();
            try
            {
                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;
                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    List<sp_MostrarHistorialAnticonceptivosResult> HistorialNotifiAnticoncep = new List<sp_MostrarHistorialAnticonceptivosResult>(); //Todos los Select ocupan guardar la Lista de los elementos de DB
                    HistorialNotifiAnticoncep = miLinq.sp_MostrarHistorialAnticonceptivos(ref idReturn, ref errorId, ref errorDescripcion, userId).ToList();
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.HistorialAnticonceptivo = ArmarHistorialAnticoncep(HistorialNotifiAnticoncep);
                        res.resultado = true;
                    }
                    else if (errorId == 23 && idReturn != 0)
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.SinRegistro;
                        res.errorMensaje = "Sin registro";
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.ErrorDeNotificacion;
                        res.errorMensaje = "Error al mostrar Historial";
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorCode = (int)EnumErrores.ErrorInterno;
                res.errorMensaje = "Error Interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        public  ResMostrarConsejos mostrarConsejos(ReqMostrarConsejos req)
        {
            ResMostrarConsejos res = new ResMostrarConsejos();
            try
            {
               if (LogSession.ErroresSession(req.session))
               {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
               }
                else                
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;
                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    List<sp_MostrarConsejosResult> MostrarConsejos = new List<sp_MostrarConsejosResult>(); //Todos los Select ocupan guardar la Lista de los elementos de DB
                    MostrarConsejos = miLinq.sp_MostrarConsejos(ref idReturn, ref errorId, ref errorDescripcion, userId).ToList();
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.MostrarLosConsejos = ArmarConsejos(MostrarConsejos);
                        res.resultado = true;
                    }
                    else if (errorId == 23 && idReturn != 0)
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.SinRegistro;
                        res.errorMensaje = "Sin registro";
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.ErrorDeNotificacion;
                        res.errorMensaje = "Error al mostrar consejos";
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorCode = (int)EnumErrores.ErrorInterno;
                res.errorMensaje = "Error Interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        //Metodos Factoriales para cada Obtener de la base de datos.
        private static List<Anticonceptivos> ArmarListaAnticoncep(List<sp_ObtenerAnticonceptivosResult> AnticoncepLinq)
        {
            List<Anticonceptivos> listaDeAnticoncepDatos = new List<Anticonceptivos>();

            foreach (sp_ObtenerAnticonceptivosResult cadalinq in AnticoncepLinq)
            {
                Anticonceptivos ElAnticoncepADevolver = new Anticonceptivos();

                ElAnticoncepADevolver.Anti_Concep_ID = cadalinq.ANTI_CONCEP_ID;
                ElAnticoncepADevolver.Anti_Concep_Nombre = cadalinq.ANTI_CONCEP_NOMBRE;
                ElAnticoncepADevolver.Anti_Concep_Efectividad = cadalinq.ANTI_EFECTIVIDAD;

                listaDeAnticoncepDatos.Add(ElAnticoncepADevolver);
            }
            return listaDeAnticoncepDatos;
        }
        private static List<Consejos> ArmarConsejos(List<sp_MostrarConsejosResult> ConsejosLinq)
        {
            List<Consejos> MostrarLosConsejos = new List<Consejos>();

            foreach (sp_MostrarConsejosResult MostrarConsjLinq in ConsejosLinq)
            {
                Consejos MostrarConsj = new Consejos();

                MostrarConsj.Consj_ID = MostrarConsjLinq.CONSJ_ID;
                MostrarConsj.Consj_Consejo = MostrarConsjLinq.CONSJ_CONSEJO;

                MostrarLosConsejos.Add(MostrarConsj);
            }

            return MostrarLosConsejos;
        }
        private static List<Notifi_Anticonceptivos> ArmarHistorialAnticoncep(List<sp_MostrarHistorialAnticonceptivosResult> historyAnticoncepLinq)
        {
            List<Notifi_Anticonceptivos> HistorialAnticonceptivo = new List<Notifi_Anticonceptivos>();

            foreach (sp_MostrarHistorialAnticonceptivosResult NotifiAnticoncepLinq in historyAnticoncepLinq)
            {
                Notifi_Anticonceptivos NotifiAnticoncep = new Notifi_Anticonceptivos();

                NotifiAnticoncep.Anti_Concep_Nombre = NotifiAnticoncepLinq.ANTI_CONCEP_NOMBRE;
                NotifiAnticoncep.Notifi_Start_Date = NotifiAnticoncepLinq.NOTIFI_START_DATE;
                NotifiAnticoncep.Notifi_Fecha_Final = NotifiAnticoncepLinq.NOTIFI_FECHA_FINAL;

                HistorialAnticonceptivo.Add(NotifiAnticoncep);
            }

            return HistorialAnticonceptivo;
        }

    }
}
