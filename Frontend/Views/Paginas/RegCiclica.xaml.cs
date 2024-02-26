using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Frontend.Views;

public partial class RegCiclica : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    public RegCiclica()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void ButtonIniciarSesion(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void BtnRegistrar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(nombre.Text)
            || string.IsNullOrEmpty(priApellido.Text)
            || string.IsNullOrEmpty(segApellido.Text)
            || string.IsNullOrEmpty(Contra.Text)
            || string.IsNullOrEmpty(correo.Text)
            || (confirmarContra.Text) != (Contra.Text))
        {
            await DisplayAlert("Advertencia", "Datos faltantes", "Ok");
            return;
        }
        else
        {
            ReqIngresarUsuario reqIngresarUsuario = new ReqIngresarUsuario();
            reqIngresarUsuario.elUsuario = new Usuario();
            reqIngresarUsuario.elUsuario.nombre = nombre.Text;
            reqIngresarUsuario.elUsuario.primerApellido = priApellido.Text;
            reqIngresarUsuario.elUsuario.segundoApellido = segApellido.Text;
            reqIngresarUsuario.elUsuario.correo = correo.Text;
            reqIngresarUsuario.elUsuario.contrasena = Contra.Text;
            var confiContra = confirmarContra.Text;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(reqIngresarUsuario), Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(api + "usuario/ingresarUsuario", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResIngresarUsuario resIngresarUsuario = new ResIngresarUsuario();
                var responseContent = await response.Content.ReadAsStringAsync();
                resIngresarUsuario = JsonConvert.DeserializeObject<ResIngresarUsuario>(responseContent);
                if (resIngresarUsuario.resultado)
                {
                    await Navigation.PushAsync(new LogCiclica());
                    await DisplayAlert("REGISTRO EXITOSO", "", "Ok");
                }
                else
                {
                    await DisplayAlert("Advertencia", "Datos incorrectos", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Error de conexion", "Ok");
            }
        }

    }
}