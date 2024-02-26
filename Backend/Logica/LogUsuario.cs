using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Collections.Specialized.BitVector32;

namespace Backend.Logica
{
    public class LogUsuario
    {
        public ResIngresarUsuario IngresarUsuario(ReqIngresarUsuario req)
        {
            ResIngresarUsuario res = new ResIngresarUsuario();

            try
            {
                if (String.IsNullOrEmpty(req.elUsuario.nombre))
                {
                    res.resultado = false;
                    res.errorMensaje = "Nombre faltante";
                    res.errorCode = (int)EnumErrores.NombreFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.primerApellido))
                {
                    res.resultado = false;
                    res.errorMensaje = "Primer Apellido faltante";
                    res.errorCode = (int)EnumErrores.PrimerApellidoFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.segundoApellido))
                {
                    res.resultado = false;
                    res.errorMensaje = "Segundo Apellido faltante";
                    res.errorCode = (int)EnumErrores.SegundoApellidoFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.correo))
                {
                    res.resultado = false;
                    res.errorMensaje = "Correo faltante";
                    res.errorCode = (int)EnumErrores.CorreoFaltante;
                }
                else if (String.IsNullOrEmpty(req.elUsuario.contrasena))
                {
                    res.resultado = false;
                    res.errorMensaje = "Contrasena faltante";
                    res.errorCode = (int)EnumErrores.ContrasenaFaltante;
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.sp_IngresarUsuario(req.elUsuario.nombre, req.elUsuario.primerApellido, req.elUsuario.segundoApellido, req.elUsuario.correo, req.elUsuario.contrasena, ref idReturn, ref errorId, ref errorDescripcion);
                    if (errorId == 0 && idReturn != 0)
                    {
                        //Exitoso
                        res.resultado = true;
                    }
                    else
                    {
                        //Error en la base de datos
                        res.resultado = false;
                        res.errorMensaje = "Error interno";
                        res.errorCode = (int)EnumErrores.ErrorInterno;
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                res.errorCode = (int)EnumErrores.ErrorInterno;
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        public ResLoginUsuario LoginUsuario(ReqLoginUsuario req)
        {
            ResLoginUsuario res = new ResLoginUsuario();

            try
            {
                if (String.IsNullOrEmpty(req.userLog.correo))
                {
                    res.resultado = false;
                    res.errorMensaje = "Correo faltante";
                    res.errorCode = (int)EnumErrores.CorreoFaltante;
                }
                else if (String.IsNullOrEmpty(req.userLog.contrasena))
                {
                    res.resultado = false;
                    res.errorMensaje = "Contrasena faltante";
                    res.errorCode = (int)EnumErrores.ContrasenaFaltante;
                }
                else
                {
                    //LLEGARON TODOS LOS DATOS p
                    //Enviar a base de datos
                    int? errorId = 0;
                    int? idReturn = 0;//idusuario
                    string errorDescripcion = "";

                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    miLinq.SP_LoginUsuario(req.userLog.correo, req.userLog.contrasena, ref idReturn, ref errorId, ref errorDescripcion);

                    string session = LogSession.ingresarSession((int)idReturn);
          
                    if (errorId == 0 && idReturn != 0 && session != null) //Validar correo , contrasena y  **si la session se creo
                    {
                        //Exitoso
                        res.resultado = true;
                        res.session = session; 
                    }
                    else
                    {
                        //Error en la base de datos
                        res.session = null;
                        res.resultado = false;
                        res.errorMensaje = "Error de login";
                        res.errorCode = (int)EnumErrores.ErrorLogin;
                        Console.WriteLine(errorDescripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                res.session = null;
                res.resultado = false;
                res.errorMensaje = "Error interno";
                res.errorCode = (int)EnumErrores.ErrorInterno;
                Console.WriteLine(ex.Message);
            }
            return res;
        }
    }
 }
