using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogCicloMenstrual
    {   //Metodo para ingresar un ciclo menstrual
        public ResIngresarCicloMenstrual IngresarCicloMenstrual(ReqIngresarCicloMenstrual req)
        {
            ResIngresarCicloMenstrual res = new ResIngresarCicloMenstrual();
            try
            {
                //Solicitar los datos a ingresar
                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else if (req.elcicloMenstrual.FechaInicioCiclo == null)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.FechaFaltante;
                    res.errorMensaje = "Fecha Faltante";
                }
                else if (req.elcicloMenstrual.DuracionCiclo == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.DuracionCicloFaltante;
                    res.errorMensaje = "Duracion Ciclo Faltante";
                }
                else if (req.elcicloMenstrual.DuracionMenstruacion == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.DuracionMenstrualFaltante;
                    res.errorMensaje = "Duracion Menstruacion Faltante";
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
                    miLinq.sp_IngresarRegistroCicloMenstrual(userId, req.elcicloMenstrual.FechaInicioCiclo, req.elcicloMenstrual.DuracionCiclo, req.elcicloMenstrual.DuracionMenstruacion, ref idReturn, ref errorId, ref errorDescripcion);
                    if (errorId == 0 && idReturn != 0)
                    {
                        res.resultado = true;
                        res.menstruacionId = (int)idReturn;
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.ErrorCicloMenstrual;
                        res.errorMensaje = "Error Ciclo Menstrual";
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
        //Metodo para Obtener UN solo Ciclo Menstrual
       

        //Metodo Obtener historial de Ciclos Menstruales 
        public ResHistorialCicloMenstrual HistorialCicloMenstrual(ReqHistorialCicloMenstrual req)
        {
            ResHistorialCicloMenstrual res = new ResHistorialCicloMenstrual();
            try
            {
                int? errorId = 0;
                int? idReturn = 0;//idusuario
                string errorDescripcion = "";
               if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else
                {
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    List<sp_ObtenerHistorialCicloMenstrualResult> HistorialCicloMenstrual = new List<sp_ObtenerHistorialCicloMenstrualResult>();
                    HistorialCicloMenstrual = miLinq.sp_ObtenerHistorialCicloMenstrual(userId,ref idReturn,ref errorId, ref errorDescripcion).ToList();
                    if (errorId == 0)
                    {
                        //Muestra lista de los ciclos menstruales 
                        res.ListaDeHistorialCiclo = armarHistorialCiclo(HistorialCicloMenstrual);

                    }
                    else 
                    {
                        Console.WriteLine("Error al obtener la ciclo. Descripción del error: " + errorDescripcion);
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

        //Factory para historial de ciclos menstruales
        private List<CicloMenstrual> armarHistorialCiclo(List<sp_ObtenerHistorialCicloMenstrualResult> ListaDeHistorialCicloLinq)
        {
            List<CicloMenstrual> listaDevolver = new List<CicloMenstrual>();
            foreach (sp_ObtenerHistorialCicloMenstrualResult HistorialCicloLinq in ListaDeHistorialCicloLinq)
            {
                CicloMenstrual miHistorialCiclo = new CicloMenstrual();
                miHistorialCiclo.MenstruacionId = HistorialCicloLinq.MENSTRUACION_ID;
                miHistorialCiclo.UsuarioId = HistorialCicloLinq.USUARIO_ID;
                miHistorialCiclo.DuracionCiclo = HistorialCicloLinq.CICMENS_DURACION_CICLO;
                miHistorialCiclo.DuracionMenstruacion = HistorialCicloLinq.CICMENS_DURACION_MENSTRUACION;
                miHistorialCiclo.FechaInicioCiclo = (DateTime)HistorialCicloLinq.CICMENS_FECHA_INICIO_CICLO;

                listaDevolver.Add(miHistorialCiclo); // Aquí debes usar listaDevolver en lugar de listaHistorial
            }
            return listaDevolver;
        }

    }
}
