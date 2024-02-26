using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using Frontend.Entidades;
using Frontend.Models;
using Frontend.CapturarDatos;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Views.Paginas;


public partial class AnticoncepFechaYHora : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    //string LocalApi = "https://localhost:44365/api/";
    public AnticoncepFechaYHora()
	{
        InitializeComponent();
	}
    private void BTN_RegresarDeFechaYHora_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private async void BTN_GuardarNotifi_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay una session", "Ok");
                await Navigation.PushAsync(new LogCiclica());
            }
            else
            {
                // Crear la solicitud para la API
                ReqInsertarNotificaciones reqInsertarNotificaciones = new ReqInsertarNotificaciones();
                reqInsertarNotificaciones.session = ObtenerDatosAEnviar.Session;
                reqInsertarNotificaciones.notifiAnticoncep = new Notificaciones();
                reqInsertarNotificaciones.notifiAnticoncep.Notifi_Anti_Concep_ID = ObtenerDatosAEnviar.IdAnticoncep;
                reqInsertarNotificaciones.notifiAnticoncep.Notifi_Start_Date = DatePicker_Fecha.Date;

                // Obtén la fecha actual
                DateTime fechaActual = DateTime.Now;

                // Obtén la hora seleccionada del TimePicker
                TimeSpan horaSeleccionada = TimePicker_Hora.Time;

                // Combina la fecha actual con la hora seleccionada
                DateTime fechaHoraSeleccionada = fechaActual.Date + horaSeleccionada;

                // Asigna la fecha y hora combinada a tu propiedad
                reqInsertarNotificaciones.notifiAnticoncep.Notifi_Start_Time = fechaHoraSeleccionada; 

                // Crear una instancia del cliente de la API
                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqInsertarNotificaciones), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();

                // Llamar al método de la API y esperar la respuesta
                var response = await httpClient.PostAsync(api + "Notificaciones/InsertarNotificaciones", jsonContent);

                // Verificar el resultado de la API
                if (response.IsSuccessStatusCode)
                {
                    ResInsertarNotificaciones resInsertarNotificaciones = new ResInsertarNotificaciones();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resInsertarNotificaciones = JsonConvert.DeserializeObject<ResInsertarNotificaciones>(responseContent);
                    if (resInsertarNotificaciones.errorCode == 0 && resInsertarNotificaciones.resultado == true)
                    {
                        await DisplayAlert("EXITO", "", "Ok");
                        await Navigation.PopAsync();
                    }
                    else if (resInsertarNotificaciones.errorCode == 21)
                    {
                        await DisplayAlert("NO EXISTE EL ANTICONCEPTIVO SELECCIONADO", "", "Ok");
                        
                    }
                    else
                    {
                        await DisplayAlert("YA TIENES UN REGISTRO", "", "Ok");
                    }
                }
                else
                {
                    // La llamada a la API no fue exitosa
                    await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                }
            }

        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción inesperada
            Console.WriteLine($"Error: {ex.Message}");
            await DisplayAlert("Error", "Error interno", "OK");
        }
        //Navigation.PushAsync(new PagObtenerElMetodoAnticoncepEnUso());
    }
}