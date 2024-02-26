using Frontend.CapturarDatos;
using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;


namespace Frontend.Views.Paginas;
public partial class TiendaCiclica : ContentPage
{
    /*public List<CategoriaProductos> ListaCategoriaProductos { get; set; } = new List<CategoriaProductos>
    {
        new CategoriaProductos { idCategoriaProducto = 1, nombre = "Mestruacion" },
        new CategoriaProductos { idCategoriaProducto = 2, nombre = "Postparto" },
        new CategoriaProductos { idCategoriaProducto = 3, nombre = "Menopausia"},
        new CategoriaProductos { idCategoriaProducto = 4, nombre = "Aprendizaje"},

    };*/
    string api = "https://webapiciclica.azurewebsites.net/api/";
    /*string LocalApi = "https://localhost:44365/api/";*/

    public TiendaCiclica()
	{
		InitializeComponent();
	}

    private async void BTN_ProductosMestrucion_Clicked(object sender, EventArgs e)
    {
        //Asigno una variable igual al ID de la categoria de Productos
        int idCategProduct = 1;
        //Almacena el ID en las variables globales
        ObtenerDatosAEnviar.CategoriaProductoId = idCategProduct;
        // Continua con el catalogo
        // Navigation.PushAsync(new CatalogoProductos());

        //--------------------------------------------------------------------------------------

        try {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay session", "Ok");
                return;
            }
            else
            {
                ReqObtenerProductos reqObtenerProductos = new ReqObtenerProductos();
                reqObtenerProductos.session = ObtenerDatosAEnviar.Session;
                reqObtenerProductos.categoriaProductoId = idCategProduct;
                reqObtenerProductos.categoriaProductoId = ObtenerDatosAEnviar.CategoriaProductoId;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqObtenerProductos), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(api + "Producto/ObtenerProductosPorCategoriaID", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResObtenerProductos resObtenerProductos = new ResObtenerProductos();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resObtenerProductos = JsonConvert.DeserializeObject<ResObtenerProductos>(responseContent);
                    if (resObtenerProductos.errorCode == 0)
                    {
                        ObtenerDatosAEnviar.ListaProductos = resObtenerProductos.listaProductos;
                        await Navigation.PushAsync(new CatalogoProductos());

                    }
                    else if (resObtenerProductos.errorCode == 23)
                    {
                        await DisplayAlert("No hay Productos", "", "Ok");
                        await Navigation.PushAsync(new CatalogoProductos());
                    }
                    else
                    {
                        await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Error de conexion", "Ok");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            await DisplayAlert("No hubo respuesta", "", "Ok");
        }
    }

    private async void BTN_ProductosAprendizaje_Clicked(object sender, EventArgs e)
    {
        //Asigno una variable igual al ID de la categoria de Productos
        int idCategProduct = 4;
        //Almacena el ID en las variables globales
        ObtenerDatosAEnviar.CategoriaProductoId = idCategProduct;
        // Continua con el catalogo
        //Navigation.PushAsync(new CatalogoProductos());

        try
        {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay session", "Ok");
                return;
            }
            else
            {
                ReqObtenerProductos reqObtenerProductos = new ReqObtenerProductos();
                reqObtenerProductos.session = ObtenerDatosAEnviar.Session;
                reqObtenerProductos.categoriaProductoId = idCategProduct;
                reqObtenerProductos.categoriaProductoId = ObtenerDatosAEnviar.CategoriaProductoId;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqObtenerProductos), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(api + "Producto/ObtenerProductosPorCategoriaID", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResObtenerProductos resObtenerProductos = new ResObtenerProductos();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resObtenerProductos = JsonConvert.DeserializeObject<ResObtenerProductos>(responseContent);
                    if (resObtenerProductos.errorCode == 0)
                    {
                        ObtenerDatosAEnviar.ListaProductos = resObtenerProductos.listaProductos;
                        await Navigation.PushAsync(new CatalogoProductos());

                    }
                    else if (resObtenerProductos.errorCode == 23)
                    {
                        await DisplayAlert("No hay Productos", "", "Ok");
                        await Navigation.PushAsync(new CatalogoProductos());
                    }
                    else
                    {
                        await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Error de conexion", "Ok");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            await DisplayAlert("No hubo respuesta", "", "Ok");
        }
    }



    private async void BTN_ProductosPosparto_Clicked(object sender, EventArgs e)
    {
        //Asigno una variable igual al ID de la categoria de Productos
        int idCategProduct = 2;
        //Almacena el ID en las variables globales
        ObtenerDatosAEnviar.CategoriaProductoId = idCategProduct;
        // Continua con el catalogo
        //Navigation.PushAsync(new CatalogoProductos());
        try
        {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay session", "Ok");
                return;
            }
            else
            {
                ReqObtenerProductos reqObtenerProductos = new ReqObtenerProductos();
                reqObtenerProductos.session = ObtenerDatosAEnviar.Session;
                reqObtenerProductos.categoriaProductoId = idCategProduct;
                reqObtenerProductos.categoriaProductoId = ObtenerDatosAEnviar.CategoriaProductoId;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqObtenerProductos), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(api + "Producto/ObtenerProductosPorCategoriaID", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResObtenerProductos resObtenerProductos = new ResObtenerProductos();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resObtenerProductos = JsonConvert.DeserializeObject<ResObtenerProductos>(responseContent);
                    if (resObtenerProductos.errorCode == 0)
                    {
                        ObtenerDatosAEnviar.ListaProductos = resObtenerProductos.listaProductos;
                        await Navigation.PushAsync(new CatalogoProductos());

                    }
                    else if (resObtenerProductos.errorCode == 23)
                    {
                        await DisplayAlert("No hay Productos", "", "Ok");
                        await Navigation.PushAsync(new CatalogoProductos());
                    }
                    else
                    {
                        await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Error de conexion", "Ok");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            await DisplayAlert("No hubo respuesta", "", "Ok");
        }
    }

    private async void BTN_ProductosMenopausia_Clicked(object sender, EventArgs e)
    {
        //Asigno una variable igual al ID de la categoria de Productos
        int idCategProduct = 3;
        //Almacena el ID en las variables globales
        ObtenerDatosAEnviar.CategoriaProductoId = idCategProduct;
        // Continua con el catalogo
        //Navigation.PushAsync(new CatalogoProductos());
        try
        {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay session", "Ok");
                return;
            }
            else
            {
                ReqObtenerProductos reqObtenerProductos = new ReqObtenerProductos();
                reqObtenerProductos.session = ObtenerDatosAEnviar.Session;
                reqObtenerProductos.categoriaProductoId = idCategProduct;
                reqObtenerProductos.categoriaProductoId = ObtenerDatosAEnviar.CategoriaProductoId;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqObtenerProductos), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(api + "Producto/ObtenerProductosPorCategoriaID", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResObtenerProductos resObtenerProductos = new ResObtenerProductos();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resObtenerProductos = JsonConvert.DeserializeObject<ResObtenerProductos>(responseContent);
                    if (resObtenerProductos.errorCode == 0)
                    {
                        ObtenerDatosAEnviar.ListaProductos = resObtenerProductos.listaProductos;
                        await Navigation.PushAsync(new CatalogoProductos());

                    }
                    else if (resObtenerProductos.errorCode == 23)
                    {
                        await DisplayAlert("No hay Productos", "", "Ok");
                        await Navigation.PushAsync(new CatalogoProductos());
                    }
                    else
                    {
                        await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Error de conexion", "Ok");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            await DisplayAlert("No hubo respuesta", "", "Ok");
        }
    }
}