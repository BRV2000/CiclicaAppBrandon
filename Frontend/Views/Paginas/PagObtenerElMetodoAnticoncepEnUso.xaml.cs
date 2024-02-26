using Frontend.CapturarDatos;
using Frontend.Entidades;
using Frontend.Models;
using Newtonsoft.Json;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using System.Text;

namespace Frontend.Views.Paginas;

public partial class PagObtenerElMetodoAnticoncepEnUso : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    string LocalApi = "https://localhost:44365/api/";

	public PagObtenerElMetodoAnticoncepEnUso()
	{
		InitializeComponent();

        // Obtener la lista de historialAnticoncep desde la variable global
        var anticoncepUso = ObtenerDatosAEnviar.anticonceptivos;

        foreach (var anticonceptivo in anticoncepUso)
        {
            // Ajusta la lógica de nombres de imagen según tus necesidades
            anticonceptivo.Anti_Concep_Imagen = ObtenerRutaImagen(anticonceptivo.Anti_Concep_Nombre);
        }

        // Asignar la lista al origen de datos del CollectionView
        MostrarAnticoncepUso.ItemsSource = anticoncepUso;
    }
    private string ObtenerRutaImagen(string nombreAnticonceptivo)
    {
        // Ajusta esto según la lógica de cómo se asignan las rutas de las imágenes
        return $"Resourses/Images/{nombreAnticonceptivo.ToLower().Replace(" ", "_")}.png";
    }
    private void BTN_RegresarDelMetodoEnUso_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private async void BTN_SuspenderMetodo_Clicked(object sender, EventArgs e)
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
                ReqActualizarNotificaciones reqActualizarNotificaciones = new ReqActualizarNotificaciones();
                reqActualizarNotificaciones.session = ObtenerDatosAEnviar.Session;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqActualizarNotificaciones), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(api + "Notificaciones/actualizarNotificaciones", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResActualizarNotificaciones resActualziarNotificaciones = new ResActualizarNotificaciones();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resActualziarNotificaciones = JsonConvert.DeserializeObject<ResActualizarNotificaciones>(responseContent);
                    if (resActualziarNotificaciones.errorCode == 0 && resActualziarNotificaciones.resultado == true)
                    {
                        await DisplayAlert("EXITO", "El metodo fue suspendido", "Ok");
                        await Navigation.PopAsync();
                    }
                    else if (resActualziarNotificaciones.errorCode == 22)
                    {
                        await Navigation.PopAsync();
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
        
        //Navigation.PushAsync(new MetodosAnticonceptivos());
    }
}