using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogBiomarcadores
    {
        public ResIngresarBiomarcadores IngresarBiomarcador(ReqIngresarBiomarcadores req)
        {
            ResIngresarBiomarcadores res = new ResIngresarBiomarcadores();
            try 
            {
                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session Invalida";
                }
                else if (req.elBiomarcador.CamCervixId == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdCambioCervicalFaltante;
                    res.errorMensaje = "Datos cervicales faltante";
                }
                else if (req.elBiomarcador.EstadoAnimo_ID == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdEstadoAnimoFaltante;
                    res.errorMensaje = "Estado Animo faltante";
                }
                else if (req.elBiomarcador.Sint_Id == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdSintomasFaltante;
                    res.errorMensaje = "Sintoma faltante";
                }
                else if (req.elBiomarcador.T_Sang_Id == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdTipoSangradoFaltante;
                    res.errorMensaje = "tipo de sagrado faltante";
                }
                else if (req.elBiomarcador.Cant_MenstruacionId == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdCantidadMentruacion;
                    res.errorMensaje = "cantidad menstruacion faltante";
                }
                else if (req.elBiomarcador.MocoCervixId == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdMocoCervix;
                    res.errorMensaje = "Moco cervical faltante";
                }
                else if (req.elBiomarcador.Tipo_FlujoId == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.IdTipoFlujoFaltante;
                    res.errorMensaje = "Tipo de flujo faltante";
                }
                else if (req.elBiomarcador.Fecha == null)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.FechaBiomarcador;
                    res.errorMensaje = "Fecha de biomarcador faltante";
                }
                else if (req.elBiomarcador.Temp_Basal == 0)
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.TempBasalFaltante;
                    res.errorMensaje = "Temperatura basal faltante";
                }
                else if (string.IsNullOrEmpty(req.elBiomarcador.Libido))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.Libidofaltante;
                    res.errorMensaje = "";
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
                    //se debe corregir el sp 

                    miLinq.spInsertarBiomarcadores(userId, req.elBiomarcador.CamCervixId, req.elBiomarcador.EstadoAnimo_ID,
                        req.elBiomarcador.Sint_Id, req.elBiomarcador.T_Sang_Id, req.elBiomarcador.Cant_MenstruacionId, req.elBiomarcador.MocoCervixId,
                        req.elBiomarcador.Tipo_FlujoId, req.elBiomarcador.Fecha, req.elBiomarcador.Notas, req.elBiomarcador.Temp_Basal, req.elBiomarcador.Libido, ref idReturn, ref errorId, ref errorDescripcion);
                    if (errorId == 0)

                    {
                        res.resultado = true;
                    }
                    else
                    {
                        res.resultado = false;
                        res.errorCode = (int)EnumErrores.ErrorDatosBiometricos;
                        res.errorMensaje = "Error de datos biometricos";
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

        public ResObtenerBiomarcadores obtenerBiomarcadores(ReqObtenerBiomarcadores req)
        {
            ResObtenerBiomarcadores res = new ResObtenerBiomarcadores();
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
                    List<spObtenerBiomarcadoresResult> ObtenerBiomarcadores= new List<spObtenerBiomarcadoresResult>();

                    ObtenerBiomarcadores = miLinq.spObtenerBiomarcadores(userId, ref idReturn, ref errorId, ref errorDescripcion).ToList();
                    if (errorId == 0)
                    {
                        //Muestra una lista con el ciclo menstrual (aunque sea solo 1)
                        res.ListadeBiomarcadores = armarListaBiomarcadores(ObtenerBiomarcadores);
                        res.resultado = true;
                        
                    }
                    else
                    {
                        Console.WriteLine("Error al obtener la ciclo. Descripción del error: " + errorDescripcion);
                        res.resultado = false;
                    }
                }
            }
            catch(Exception ex) 
            {
                res.resultado = false;
                res.errorCode = (int)EnumErrores.ErrorInterno;
                res.errorMensaje = "Error Interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        private static List<DatosBiomarcadores> armarListaBiomarcadores(List<spObtenerBiomarcadoresResult> listaBiomarcadoresLinq)
        {
            List<DatosBiomarcadores> listaDevolver = new List<DatosBiomarcadores>();
            foreach (spObtenerBiomarcadoresResult ListadeBiomarcadoresLinq in listaBiomarcadoresLinq)
            {
                DatosBiomarcadores misBiomarcadores = new DatosBiomarcadores();
                //registro diario
                misBiomarcadores.cambioCervix_Altura= ListadeBiomarcadoresLinq.CAM_CVX_ALTURA;         
                misBiomarcadores.cambioCervix_Apertura = ListadeBiomarcadoresLinq.CAM_CVX_APERTURA_CERVX;
                misBiomarcadores.cambioCervix_Descripcion = ListadeBiomarcadoresLinq.CAM_CVX_DESCRIPCION;
                //Estado Animo
                misBiomarcadores.EstadoAnimo_Nombre = ListadeBiomarcadoresLinq.EST_ANIM_NOMBRE;
                //Sintomas
                misBiomarcadores.Sint_Nombre = ListadeBiomarcadoresLinq.SINT_NOMBRE;
                //tipo sangrado
                misBiomarcadores.T_Sang_Nombre = ListadeBiomarcadoresLinq.TSANG_NOMBRE;
                //Cantidad Menstrua
                misBiomarcadores.Cant_Menstruacion_Nombre = ListadeBiomarcadoresLinq.CM_NOMBRE;
                //Moco Cervix
                misBiomarcadores.MocoC_Olor = ListadeBiomarcadoresLinq.MC_OLOR;
                misBiomarcadores.MocoC_Cantidad = ListadeBiomarcadoresLinq.MC_CANTIDAD;
                //registro diario 
                misBiomarcadores.bioFecha = (DateTime)ListadeBiomarcadoresLinq.REG_FECHA;
                misBiomarcadores.bioNotas = ListadeBiomarcadoresLinq.REG_NOTAS;
                misBiomarcadores.bioTemp_Basal = (decimal)ListadeBiomarcadoresLinq.REG_TEMP_BASAL;
                misBiomarcadores.bioLibido = ListadeBiomarcadoresLinq.REG_LIBIDO;
                //Tipo flujo
                misBiomarcadores.TipoF_Olor = ListadeBiomarcadoresLinq.TPO_F_OLOR;
                misBiomarcadores.TipoF_Cantidad = ListadeBiomarcadoresLinq.TPO_F_CANTIDAD;

                listaDevolver.Add(misBiomarcadores);
            }
            return listaDevolver;
        }
    }
}
