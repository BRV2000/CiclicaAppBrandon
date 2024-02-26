using Frontend.CapturarDatos;
using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Views.Paginas;

public partial class InsertarCicloMenstrual : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    public InsertarCicloMenstrual()
	{
		InitializeComponent();
		

		
	}

    private void BTN_RegresarDeIngresarCicloMenstrual_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private void DuracioDelCiclo_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    private async void Btn_IngresarCicloMenstrual_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (String.IsNullOrEmpty(DuracioDelCiclo.Text) || String.IsNullOrEmpty(DuracioDelaMenstruacion.Text))
            {
                await DisplayAlert("Advertencia", "Favor Ingresar los datos", "Ok");
                return;
            }
            else
            {
                if (int.TryParse(DuracioDelCiclo.Text, out int duracionCiclo) && int.TryParse(DuracioDelaMenstruacion.Text, out int duracionMenstruacion))
                {
                    ReqIngresarCicloMenstrual reqIngresarCicloMenstrual = new ReqIngresarCicloMenstrual();
                    reqIngresarCicloMenstrual.session = ObtenerDatosAEnviar.Session;
                    reqIngresarCicloMenstrual.elciclomenstrual = new CicloMenstrual();
                    reqIngresarCicloMenstrual.elciclomenstrual.FechaInicioCiclo = fechaCicloMenstrual.Date;
                    reqIngresarCicloMenstrual.elciclomenstrual.DuracionCiclo = duracionCiclo;
                    reqIngresarCicloMenstrual.elciclomenstrual.DuracionMenstruacion = duracionMenstruacion;

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(reqIngresarCicloMenstrual), Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    var response = await httpClient.PostAsync(api + "CicloMenstrual/IngresarCicloMenstrual", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        ResIngresarCicloMenstrual resIngresarCicloMenstrual = new ResIngresarCicloMenstrual();
                        var responseContent = await response.Content.ReadAsStringAsync();
                        resIngresarCicloMenstrual = JsonConvert.DeserializeObject<ResIngresarCicloMenstrual>(responseContent);
                        if (resIngresarCicloMenstrual.errorCode == 0 && resIngresarCicloMenstrual.resultado == true )
                        {
                            await DisplayAlert("EXITO", "Ciclo menstrual registrado", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                    }
                }
                
                
            }
        } 
        catch (Exception ex) 
        {
            // Manejar cualquier excepción inesperada
            Console.WriteLine($"Error: {ex.Message}");
            await DisplayAlert("Error", "Error interno", "OK");
        }
    }
}