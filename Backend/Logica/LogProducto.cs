using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogProducto
    {
        public ResObtenerProductos obtenerProductosPorCategoria(ReqObtenerProductos req)
        {
            ResObtenerProductos res = new ResObtenerProductos();
            try
            {
                //LLEGARON TODOS LOS DATOS
                //Enviar a base de datos
                int? errorId = 0;
                int? idReturn = 0;//idusuario
                string errorDescripcion = "";

                if (LogSession.ErroresSession(req.session))
                {
                    res.resultado = false;
                    res.errorCode = (int)EnumErrores.SessionInvalida;
                    res.errorMensaje = "Session nula o vacia";
                }
                else
                {
                    int? userId = LogSession.obtenerSession(req.session).Session_User_Id;
                    conexionlinqDataContext miLinq = new conexionlinqDataContext();
                    List<SP_ObtenerProductosPorCategoriaPorIDResult> miListaDeLinq = new List<SP_ObtenerProductosPorCategoriaPorIDResult>();
                    miListaDeLinq = miLinq.SP_ObtenerProductosPorCategoriaPorID(userId, req.categoriaProductoId, ref idReturn, ref errorId, ref errorDescripcion).ToList();
                    if (errorId == 0)
                    {
                        res.resultado = true;
                        res.listaProductos = this.armarListaDeProductosPorCategoria(miListaDeLinq);
                    }
                    else
                    {
                        Console.WriteLine("Error al obtener categorias. Descripcion del error: " + errorDescripcion);
                        res.resultado = false;
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        private List<Producto> armarListaDeProductosPorCategoria(List<SP_ObtenerProductosPorCategoriaPorIDResult> listaProductosLinq)
        {
            List<Producto> ListaDevolver = new List<Producto>();

            foreach (SP_ObtenerProductosPorCategoriaPorIDResult cadaLinq in listaProductosLinq)
            {
                Producto misProductos = new Producto();

                misProductos.idProducto = cadaLinq.PROD_ID;
                misProductos.skuProducto = cadaLinq.PROD_SKU;
                misProductos.nombre = cadaLinq.PROD_NOMBRE;
                misProductos.cantidad = cadaLinq.PROD_CANTIDAD;
                misProductos.precio = cadaLinq.PROD_PRECIO;
                misProductos.fechaIngreso = cadaLinq.PROD_FECHA_INGR;
                misProductos.status = cadaLinq.PROD_STATUS;
                misProductos.idTipo = cadaLinq.PROD_TIPO_ID;

                ListaDevolver.Add(misProductos);

            }
            return ListaDevolver;
        }
        public ResFiltrarProductosPorColor filtrarProductosPorColor(ReqFiltrarProductosPorColor req)
        {
            ResFiltrarProductosPorColor res = new ResFiltrarProductosPorColor();
            try
            {
                //LLEGARON TODOS LOS DATOS
                //Enviar a base de datos
                int? errorId = 0;
                int? idReturn = 0;//idusuario
                string errorDescripcion = "";

                conexionlinqDataContext miLinq = new conexionlinqDataContext();
                List<sp_FiltrarProductosPorColorResult> miListaDeLinq = new List<sp_FiltrarProductosPorColorResult>();
                miListaDeLinq = miLinq.sp_FiltrarProductosPorColor(req.ColorId, ref idReturn, ref errorId, ref errorDescripcion).ToList();
                if (errorId == 0)
                {
                    res.resultado = true;
                    res.listaProductosPorColor = this.armarListaProductosPorColor(miListaDeLinq);
                }
                else
                {
                    Console.WriteLine("Error al obtener categorias. Descripcion del error: " + errorDescripcion);
                    res.resultado = false;
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        private List<Producto> armarListaProductosPorColor(List<sp_FiltrarProductosPorColorResult> listaProductosPorColorLinq)
        {
            List<Producto> ListaDevolver = new List<Producto>();

            foreach (sp_FiltrarProductosPorColorResult cadaLinq in listaProductosPorColorLinq)
            {
                Producto misProductos = new Producto();

                misProductos.idProducto = cadaLinq.PROD_ID;
                misProductos.nombre = cadaLinq.PROD_NOMBRE;
                misProductos.cantidad = cadaLinq.PROD_CANTIDAD;
                misProductos.precio = cadaLinq.PROD_PRECIO;

                ListaDevolver.Add(misProductos);

            }
            return ListaDevolver;
        }
        public ResFiltrarProductosPorRangoDePrecios filtrarProductosPorRangoDePrecios(ReqFiltrarProductosPorRangoDePrecios req)
        {
            ResFiltrarProductosPorRangoDePrecios res = new ResFiltrarProductosPorRangoDePrecios();
            try
            {
                //LLEGARON TODOS LOS DATOS
                //Enviar a base de datos
                int? errorId = 0;
                int? idReturn = 0;//idusuario
                string errorDescripcion = "";

                conexionlinqDataContext miLinq = new conexionlinqDataContext();
                List<sp_FiltrarProductosPorRangoDePreciosResult> miListaDeLinq = new List<sp_FiltrarProductosPorRangoDePreciosResult>();
                miListaDeLinq = miLinq.sp_FiltrarProductosPorRangoDePrecios(req.montoMinimo, req.montoMaximo, ref idReturn, ref errorId, ref errorDescripcion).ToList();
                if (errorId == 0)
                {
                    res.resultado = true;
                    res.listaProductosPorRangoDePrecios = this.armarListaProductosPorRangoDePrecios(miListaDeLinq);
                }
                else
                {
                    Console.WriteLine("Error al obtener categorias. Descripcion del error: " + errorDescripcion);
                    res.resultado = false;
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.errorMensaje = "Error interno";
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        private List<Producto> armarListaProductosPorRangoDePrecios(List<sp_FiltrarProductosPorRangoDePreciosResult> listaProductosPorRangoDePreciosLinq)
        {
            List<Producto> ListaDevolver = new List<Producto>();

            foreach (sp_FiltrarProductosPorRangoDePreciosResult cadaLinq in listaProductosPorRangoDePreciosLinq)
            {
                Producto misProductos = new Producto();

                misProductos.idProducto = cadaLinq.PROD_ID;
                misProductos.nombre = cadaLinq.PROD_NOMBRE;
                misProductos.cantidad = cadaLinq.PROD_CANTIDAD;
                misProductos.precio = cadaLinq.PROD_PRECIO;

                ListaDevolver.Add(misProductos);

            }
            return ListaDevolver;
        }
    }
}
