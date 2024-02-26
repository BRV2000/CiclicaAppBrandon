using Backend.Entidades;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CicloMenstrualController : ApiController
    {
        //API para ingresar Ciclo Menstrual
        [HttpPost]
        [Route("api/CicloMenstrual/IngresarCicloMenstrual")]
        public ResIngresarCicloMenstrual IngresarCicloMenstrual(ReqIngresarCicloMenstrual req)
        {
            LogCicloMenstrual miLogica = new LogCicloMenstrual();
            return miLogica.IngresarCicloMenstrual(req);
        }

        //API para obtener Historial de Ciclos Menstruales de un usuario
        [HttpPost]
        [Route("api/CicloMenstrual/historialCicloMenstrual")]
        public ResHistorialCicloMenstrual HistorialCicloMenstrual(ReqHistorialCicloMenstrual req)
        {
            //ReqHistorialCicloMenstrual req = new ReqHistorialCicloMenstrual();
            LogCicloMenstrual miLogica = new LogCicloMenstrual();
            return miLogica.HistorialCicloMenstrual(req);
        }
    }


}