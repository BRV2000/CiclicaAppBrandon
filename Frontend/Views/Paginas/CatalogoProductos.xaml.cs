using Frontend.CapturarDatos;
using Frontend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Views.Paginas;

public partial class CatalogoProductos : ContentPage
{
    
    public CatalogoProductos()
	{
		InitializeComponent();

        //Obtener la lista de Productos por categoria desde la variable global
        var ListaProductos = ObtenerDatosAEnviar.ListaProductos;

        //Asignar la lista al origen de datos del CollectionView
        DatosProductosPorCategoria.ItemsSource = ListaProductos;


        foreach (var producto in ListaProductos) 
        {
            producto.RutaImagen = ObtnerRutaImagen(producto.nombre);
        }



       /* this.listaProductos = new List<ListaProductos>()
        {
            new ListaProductos()
            {
               Nombre ="Calzon Mestrual",
               Precio = 10500
    },
            new ListaProductos()
            {
               Nombre ="Copa Mestrual",
               Precio = 14500
            },
            new ListaProductos()
            {
               Nombre ="Condones",
               Precio = 7500
            },
            new ListaProductos()
            {
               Nombre ="Copa mestraul esecial Ciclica",
               Precio = 15000
            },
            new ListaProductos()
            {
                Nombre ="Lubricante Ciclica",
                Precio = 17500
            }
        };

        this.BindingContext = this;*/
    }

    private string ObtnerRutaImagen(string nombre)
    {
        return $"Resources/Images/{nombre.ToLower().Replace(" ", "_")}.png";
    }

    private void BTN_RegresarCategoriaProdutos_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
