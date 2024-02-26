using Frontend.CapturarDatos;
using Frontend.Entidades;
using Frontend.Views.Paginas;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Frontend.Views;

public partial class LogCiclica : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
   // string LocalApi = "https://localhost:44365/api/";
    public LogCiclica()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new RegCiclica());
    }
    private async void Btn_Ingresar_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(LoginCorreo.Text) || string.IsNullOrEmpty(LoginContraseña.Text))
        {
            await DisplayAlert("Advertencia", "Ingresa el Correo y contraseña", "Ok");
            return;
        }
        else
        {
            ReqLoginUsuario reqLoginUsuario = new ReqLoginUsuario();
            reqLoginUsuario.userLog = new Login();
            reqLoginUsuario.userLog.correo = LoginCorreo.Text;
            reqLoginUsuario.userLog.contrasena = LoginContraseña.Text;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(reqLoginUsuario), Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(api + "usuario/loginUsuario", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResLoginUsuario resLoginUsuario = new ResLoginUsuario();
                var responseContent = await response.Content.ReadAsStringAsync();
                resLoginUsuario = JsonConvert.DeserializeObject<ResLoginUsuario>(responseContent);
                if (resLoginUsuario.resultado == true)
                {
                    ObtenerDatosAEnviar.Session = resLoginUsuario.session;
                    // En LogCiclica después de la autenticación exitosa
                    if (ObtenerDatosAEnviar.Session == null)
                    {
                        await DisplayAlert("Advertencia", "No hay una session", "Ok");
                        return;
                    }
                    else
                    {
                        ReqMostrarConsejos reqMostrarConsejos = new ReqMostrarConsejos();
                        reqMostrarConsejos.session = ObtenerDatosAEnviar.Session;

                        var jsonContentt = new StringContent(JsonConvert.SerializeObject(reqMostrarConsejos), Encoding.UTF8, "application/json");
                        HttpClient httpClientt = new HttpClient();
                        var responses = await httpClientt.PostAsync(api + "Consejos/mostrarConsejos", jsonContentt);

                        if (responses.IsSuccessStatusCode)
                        {
                            ResMostrarConsejos resMostrarConsejos = new ResMostrarConsejos();
                            var responseContentt = await responses.Content.ReadAsStringAsync();
                            resMostrarConsejos = JsonConvert.DeserializeObject<ResMostrarConsejos>(responseContentt);
                            if (resMostrarConsejos.errorCode == 0 && resMostrarConsejos.resultado == true)
                            {
                                ObtenerDatosAEnviar.consejos = resMostrarConsejos.MostrarLosConsejos;
                                Application.Current.MainPage = new AppShell();
                            }
                            else if (resMostrarConsejos.errorCode == 23)
                            {
                                Application.Current.MainPage = new AppShell();
                            }
                        }
                        else
                        {
                            Application.Current.MainPage = new AppShell();
                            await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Correo y contraseña incorrectos o session ya activa", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Error de conexion", "Ok");
            }
        }

    }
}