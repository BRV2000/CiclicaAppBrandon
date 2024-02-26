using Backend.Entidades;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class NotifiAnticoncepController : ApiController
    {
        [HttpPost]
        [Route("api/Notificaciones/InsertarNotificaciones")]
        public ResInsertarNotificaciones InsertarNotificaciones(ReqInsertarNotificaciones req)
        {
            LogNotifiAnticoncep miLogica = new LogNotifiAnticoncep();
            return miLogica.InsertarNotificaciones(req);
        }

        [HttpPost]
        [Route("api/Notificaciones/actualizarNotificaciones")]
        public ResActualizarNotificaciones actualizarNotificaciones(ReqActualizarNotificaciones req)
        {
            LogNotifiAnticoncep miLogica = new LogNotifiAnticoncep();
            return miLogica.actualizarNotificaciones(req);
        }

        [HttpPost]
        [Route("api/Anticonceptivos/obtenerAnticonceptivos")]
        public ResObtenerAnticonceptivos obtenerAnticonceptivos(ReqObtenerAnticonceptivos req)
        {
            
            LogNotifiAnticoncep miLogica = new LogNotifiAnticoncep();

            return miLogica.obtenerAnticonceptivos(req);
        }
        [HttpPost]
        [Route("api/Notifi_Anticonceptivos/historialAnticonceptivos")]
        public ResHistorialAnticonceptivos historialAnticonceptivos(ReqHistorialAnticonceptivos req)
        {
            
            LogNotifiAnticoncep miLogica = new LogNotifiAnticoncep();

            return miLogica.historialAnticonceptivos(req);
        }
        [HttpPost]
        [Route("api/Consejos/mostrarConsejos")]
        public ResMostrarConsejos mostrarConsejos(ReqMostrarConsejos req)
        {
            
            LogNotifiAnticoncep miLogica = new LogNotifiAnticoncep();

            return miLogica.mostrarConsejos(req);
        }
    }
}