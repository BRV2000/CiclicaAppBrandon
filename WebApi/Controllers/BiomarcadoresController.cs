using Backend.Entidades;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BiomarcadoresController : ApiController
    {
        [HttpPost]
        [Route("api/Biomarcadores/IngresarBiomarcador")]
        public ResIngresarBiomarcadores ingresarBiomarcadores(ReqIngresarBiomarcadores req)
        {
            LogBiomarcadores miLogica = new LogBiomarcadores();
            return miLogica.IngresarBiomarcador(req);
        }

        [HttpPost]
        [Route("api/DatosBiomarcadores/obtenerBiomarcadores")]
        public ResObtenerBiomarcadores ObtenerBiomarcadores(ReqObtenerBiomarcadores req) 
        {
            LogBiomarcadores miLogica = new LogBiomarcadores();
            return miLogica.obtenerBiomarcadores(req);
        }
    }
    
}