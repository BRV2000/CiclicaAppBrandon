using Backend.AccesoDatos;
using Backend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogCategoriaProducto
    {
        public ResObtenerCategoriaProductos obtenerCategoriasDeProductos(ReqObtenerCategoriaProductos req)
        {
            ResObtenerCategoriaProductos res = new ResObtenerCategoriaProductos();
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
                    List<sp_MostrarCategoriasProductosResult> miListaDeLinq = new List<sp_MostrarCategoriasProductosResult>();
                    miListaDeLinq = miLinq.sp_MostrarCategoriasProductos(userId, ref idReturn, ref errorId, ref errorDescripcion).ToList();
                    if (errorId == 0)
                    {
                        res.listaCategoriaProductos = this.armarListaCategoriasDeProductos(miListaDeLinq);
                    }
                    else
                    {
                        Console.WriteLine("Error al obtener categorias. Descrpcion del error: " + errorDescripcion);
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
        private List<CategoriaProductos> armarListaCategoriasDeProductos(List<sp_MostrarCategoriasProductosResult> listaCategoriaProductosLinq)
        {
            List<CategoriaProductos> ListaDevolver = new List<CategoriaProductos>();

            foreach (sp_MostrarCategoriasProductosResult cadaLinq in listaCategoriaProductosLinq)
            {
                CategoriaProductos miCategoriaProductos = new CategoriaProductos();

                miCategoriaProductos.idCategoriaProducto = cadaLinq.CTG_PROD_ID;
                miCategoriaProductos.nombre = cadaLinq.CTG_PROD_NOMBRE;
                miCategoriaProductos.descripcion = cadaLinq.CTG_PROD_DESCRIPCION;

                ListaDevolver.Add(miCategoriaProductos);

            }
            return ListaDevolver;
        }
    }
}
