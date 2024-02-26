using Backend.Entidades;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
            [HttpPost]
            [Route("api/CategoriaProductos/MostrarCategoriaProductos")]
            public ResObtenerCategoriaProductos ObtenerCategoriaProductos(ReqObtenerCategoriaProductos req)
            {
                LogCategoriaProducto miLogica = new LogCategoriaProducto();
                return miLogica.obtenerCategoriasDeProductos(req);
            }

            [HttpPost]
            [Route("api/Producto/ObtenerProductosPorCategoriaID")]
            public ResObtenerProductos ObtenerProductos(ReqObtenerProductos req)
            {
                LogProducto miLogica = new LogProducto();
                return miLogica.obtenerProductosPorCategoria(req);
            }

            [HttpPost]
            [Route("api/Producto/FiltrarProductosPorColor")]
            public ResFiltrarProductosPorColor FiltrarProductosPorColor(ReqFiltrarProductosPorColor req)
            {
                LogProducto miLogica = new LogProducto();
                return miLogica.filtrarProductosPorColor(req);
            }

            [HttpPost]
            [Route("api/Producto/FiltrarProductosPorRangoDePrecios")]
            public ResFiltrarProductosPorRangoDePrecios FiltrarProductosPorRangoDePrecios(ReqFiltrarProductosPorRangoDePrecios req)
            {
                LogProducto miLogica = new LogProducto();
                return miLogica.filtrarProductosPorRangoDePrecios(req);
            }
    }
}