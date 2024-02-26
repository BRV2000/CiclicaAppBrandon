using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Backend.Logica
{
    public class LogSession
    {

        public static Session obtenerSession(String session) {
            Session objetoSession = new Session();
           
            try {
                int? errorId = 0;
                int? idReturn = 0;//idusuario
                string errorDescripcion = "";
                conexionlinqDataContext miLinq = new conexionlinqDataContext();
                List<sp_ObtenerSessionResult> listaDeSesionesBasDatos = new List<sp_ObtenerSessionResult>(); //Todos los Select ocupan guardar la Lista de los elementos de DB
                listaDeSesionesBasDatos = miLinq.sp_ObtenerSession(session, ref idReturn, ref errorId, ref errorDescripcion).ToList();
                if (errorId == 0)
                {
                    //Agregar resto de campos 
                    objetoSession = armarUnaSesion(listaDeSesionesBasDatos.First());
                }
                else
                {
                    Console.WriteLine("Error al obtener la sesión. Descripción del error: " + errorDescripcion);
                    objetoSession = null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                objetoSession = null;
            }
            return objetoSession;
        }

        public static string ingresarSession(int idUsuario)
        {
            int? errorId = 0;
            int? idReturn = 0;//idusuario
            string errorDescripcion = "";

            conexionlinqDataContext miLinq = new conexionlinqDataContext();
            string session = Guid.NewGuid().ToString();
            miLinq.sp_IngresarSession(idUsuario, session ,ref idReturn, ref errorId, ref errorDescripcion);
            if (errorId == 0 && idReturn != 0)
            {
                //Agregar resto de campos 
                return session;
            }
            else
            {
                return null;
            }
        }

          public static Boolean ErroresSession(String session)
          {
            if (string.IsNullOrEmpty(session))
            {
                return true;
            } 
            else 
            {
                Session sessionEvaluar = new Session();
                sessionEvaluar = LogSession.obtenerSession(session);

                if (sessionEvaluar == null)
                {
                    return true;
                }
                else if (!sessionEvaluar.Session_Estado)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
          }

        //Factoria, para deserializar los datos de BD

        private static Session armarUnaSesion(sp_ObtenerSessionResult sessionLinq)
        {
            if (sessionLinq == null)
            {
                return null;
            }
            else
            {
                Session laSesionDevolver = new Session();

                laSesionDevolver.SessionId = sessionLinq.SESSION_ID;
                laSesionDevolver.Session_User_Id = sessionLinq.SESSION_USER_ID;
                laSesionDevolver.SessionCod = sessionLinq.SESSION;
                laSesionDevolver.Session_Fecha_Inicio = (DateTime)sessionLinq.SESSION_FECHA_INICIO;
                laSesionDevolver.Session_Fecha_Final = (DateTime?)sessionLinq.SESSION_FECHA_FINAL;
                laSesionDevolver.Session_Estado = (bool)sessionLinq.SESSION_ESTADO;

                return laSesionDevolver;
            }
        }

        /*public static Boolean cerrarSession(String session) 
        {
            Session cerrarSession = new Session();
            try
            {
                int? errorId = 0;
                int? idReturn = 0;//idusuario
                string errorDescripcion = "";
                //checkear si es req.session o solo session
                int? userId = LogSession.obtenerSession(session).Session_User_Id;

                conexionlinqDataContext miLinq = new conexionlinqDataContext();
                miLinq.sp_CerrarSesionActual(userId,  ref idReturn, ref errorId, ref errorDescripcion);
                if (errorId == 0)
                {
                    return true;
                }
                else 
                {
                    return false;   
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            
        }*/
    }
}
