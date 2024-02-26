using System.Web.Http;
using Backend.Entidades;
using Backend.Logica;

namespace WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: Usuario
        [HttpPost]
        [Route("api/usuario/ingresarUsuario")]
        public ResIngresarUsuario IngresarUsuario(ReqIngresarUsuario req)
        {
            LogUsuario miLogica = new LogUsuario();
            return miLogica.IngresarUsuario(req);
        }

        [HttpPost]
        [Route("api/usuario/loginUsuario")]
        public ResLoginUsuario LoginUsuario(ReqLoginUsuario req)
        {
            LogUsuario miLogica = new LogUsuario();
            return miLogica.LoginUsuario(req);
        }
    }
}