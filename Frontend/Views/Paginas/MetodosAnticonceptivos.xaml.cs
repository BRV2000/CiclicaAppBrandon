using Frontend.CapturarDatos;
using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;
using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace Frontend.Views.Paginas;

public partial class MetodosAnticonceptivos : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    //string LocalApi = "https://localhost:44365/api/";
    public MetodosAnticonceptivos()
	{
		InitializeComponent();
	}
    private void BTN_RegresarDeAnticonceptivos_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void BTN_PastillasAnticonceptivas_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 1;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Inyeccion_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 2;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Diu_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 3;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Parche_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 4;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Implante_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 5;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Anillo_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 6;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private async void BTN_HistorialAnticonceptivo_Clicked(object sender, EventArgs e)
    {
         try
         {
             if (ObtenerDatosAEnviar.Session == null)
             {
                 await DisplayAlert("Advertencia", "No hay una session", "Ok");
                 return;
             }
             else
             {
                 ReqHistorialAnticonceptivos reqHistorialAnticonceptivos = new ReqHistorialAnticonceptivos();
                 reqHistorialAnticonceptivos.session = ObtenerDatosAEnviar.Session;

                 var jsonContent = new StringContent(JsonConvert.SerializeObject(reqHistorialAnticonceptivos), Encoding.UTF8, "application/json");
                 HttpClient httpClient = new HttpClient();
                 var response = await httpClient.PostAsync(api + "Notifi_Anticonceptivos/historialAnticonceptivos", jsonContent);
                 if (response.IsSuccessStatusCode)
                 {
                     ResHistorialAnticonceptivos resHistorialAnticonceptivos = new ResHistorialAnticonceptivos();
                     var responseContent = await response.Content.ReadAsStringAsync();
                     resHistorialAnticonceptivos = JsonConvert.DeserializeObject<ResHistorialAnticonceptivos>(responseContent);
                     if (resHistorialAnticonceptivos.errorCode == 0)
                     {
                         ObtenerDatosAEnviar.historialAnticoncep = resHistorialAnticonceptivos.HistorialAnticonceptivo;
                         await Navigation.PushAsync(new PagHistorialAnticoncep());
                     }
                     else if (resHistorialAnticonceptivos.errorCode == 23)
                     {
                         await DisplayAlert("NO HAY REGISTRO", "", "Ok");                       
                     }
                 }
                 else
                 {
                    await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                }
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
             await DisplayAlert("Error", "Error interno", "OK");
         }
        //Navigation.PushAsync(new PagHistorialAnticoncep());

    }
}