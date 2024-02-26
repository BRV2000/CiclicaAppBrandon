using Frontend.CapturarDatos;
using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Views.Paginas;

public partial class IngresarBiomarcadores : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    public IngresarBiomarcadores()
	{
		InitializeComponent();
	}

    private void BTN_RegresarDeIngresarBiomarcador_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void BTN_Calamada_Clicked(object sender, EventArgs e)
    {
        int valor = 1;
        ObtenerDatosAEnviar.IdEstadoAnimo = valor;
    }

    private void BTN_Feliz_Clicked(object sender, EventArgs e)
    {
        int valor = 2;
        ObtenerDatosAEnviar.IdEstadoAnimo = valor;
    }

    private void BTN_Cambios_Humor_Clicked(object sender, EventArgs e)
    {
        int valor = 3;
        ObtenerDatosAEnviar.IdEstadoAnimo = valor;
    }

    private void BTN_Triste_Clicked(object sender, EventArgs e)
    {
        int valor = 4;
        ObtenerDatosAEnviar.IdEstadoAnimo = valor;
    }

    private void BTN_Enojada_Clicked(object sender, EventArgs e)
    {
        int valor = 5;
        ObtenerDatosAEnviar.IdEstadoAnimo = valor;
    }

    private void BTN_Sensible_Clicked(object sender, EventArgs e)
    {
        int valor = 6;
        ObtenerDatosAEnviar.IdEstadoAnimo = valor;
    }

    private void BTN_bajoCerrado_Clicked(object sender, EventArgs e)
    {
        int valorCevix = 1;
        ObtenerDatosAEnviar.IdCamCervix = valorCevix;
    }

    private void BTN_altoAbierto_Clicked(object sender, EventArgs e)
    {
        int valorCevix = 2;
        ObtenerDatosAEnviar.IdCamCervix = valorCevix;
    }

    private void BTN_MedioSemiabierto_Clicked(object sender, EventArgs e)
    {
        int valorCevix = 3;
        ObtenerDatosAEnviar.IdCamCervix = valorCevix;
    }

    private void BTN_TodoBien_Clicked(object sender, EventArgs e)
    {
        int valorsint = 1;
        ObtenerDatosAEnviar.IdSintomas = valorsint;
    }

    private void BTN_Colicos_Clicked(object sender, EventArgs e)
    {
        int valorsint = 2;
        ObtenerDatosAEnviar.IdSintomas = valorsint;
    }

    private void BTN_dolorAbdominal_Clicked(object sender, EventArgs e)
    {
        int valorsint = 3;
        ObtenerDatosAEnviar.IdSintomas = valorsint;
    }
    private void dolorCabeza_Clicked(object sender, EventArgs e)
    {
        int valorsint = 4;
        ObtenerDatosAEnviar.IdSintomas = valorsint;
    }

    private void BTN_pechosSensibles_Clicked(object sender, EventArgs e)
    {
        int valorsint = 5;
        ObtenerDatosAEnviar.IdSintomas = valorsint;
    }

    private void BTN_acne_Clicked(object sender, EventArgs e)
    {
        int valorsint = 6;
        ObtenerDatosAEnviar.IdSintomas = valorsint;
    }
    private void BTN_rojoOscuro_Clicked(object sender, EventArgs e)
    {
        int valorTsang = 1;
        ObtenerDatosAEnviar.IdSTang = valorTsang; 
    }


    private void BTN_rosado_Clicked(object sender, EventArgs e)
    {
        int valorTsang = 2;
        ObtenerDatosAEnviar.IdSTang = valorTsang;
    }

    

    private void BTN_negro_Clicked(object sender, EventArgs e)
    {
        int valorTsang = 3;
        ObtenerDatosAEnviar.IdSTang = valorTsang;
    }

    private void BTN_amarilloVerde_Clicked(object sender, EventArgs e)
    {
        int valorTsang = 4;
        ObtenerDatosAEnviar.IdSTang = valorTsang;
    }

    private void BTN_gris_Clicked(object sender, EventArgs e)
    {
        int valorTsang = 5;
        ObtenerDatosAEnviar.IdSTang = valorTsang;
    }

    private void BTN_MarronOscuro_Clicked(object sender, EventArgs e)
    {
        int valorTsang = 6;
        ObtenerDatosAEnviar.IdSTang = valorTsang;
    }

    private void BTN_escasoAusente_Clicked(object sender, EventArgs e)
    {
        int valormenstrua = 1;
        ObtenerDatosAEnviar.IdSangradoMenstr = valormenstrua;
    }

    private void BTN_moderado_Clicked(object sender, EventArgs e)
    {
        int valormenstrua = 2;
        ObtenerDatosAEnviar.IdSangradoMenstr = valormenstrua;
    }

    private void BTN_abundante_Clicked(object sender, EventArgs e)
    {
        int valormenstrua = 3;
        ObtenerDatosAEnviar.IdSangradoMenstr = valormenstrua;
    }

    private void BTN_bajo_Clicked(object sender, EventArgs e)
    {
        string valorLibido = "bajo";
        ObtenerDatosAEnviar.Libido = valorLibido;
    }

    private void BTN_Neutro_Clicked(object sender, EventArgs e)
    {
        string valorLibido = "neutro";
        ObtenerDatosAEnviar.Libido = valorLibido;
    }

    private void BTN_elevado_Clicked(object sender, EventArgs e)
    {
        string valorLibido = "elevado";
        ObtenerDatosAEnviar.Libido = valorLibido;
    }

    private void BTN_NingunoEscaso_Clicked(object sender, EventArgs e)
    {
        int valorMocoCervix = 1;
        ObtenerDatosAEnviar.IdMocoCervix = valorMocoCervix;
    }

    private void BTN_suaveModerado_Clicked(object sender, EventArgs e)
    {
        int valorMocoCervix = 2;
        ObtenerDatosAEnviar.IdMocoCervix = valorMocoCervix;
    }

    private void BTN_fuerteAbundante_Clicked(object sender, EventArgs e)
    {
        int valorMocoCervix = 3;
        ObtenerDatosAEnviar.IdMocoCervix = valorMocoCervix;
    }

    private void BTN_suaveAbundate_Clicked(object sender, EventArgs e)
    {
        int valorMocoCervix = 4;
        ObtenerDatosAEnviar.IdMocoCervix = valorMocoCervix;
    }

    private void BTN_fuerteModerado_Clicked(object sender, EventArgs e)
    {
        int valorMocoCervix = 5;
        ObtenerDatosAEnviar.IdMocoCervix = valorMocoCervix;
    }

    private void BTN_ningunoEscaso_Clicked_1(object sender, EventArgs e)
    {
        int valorTF = 1;
        ObtenerDatosAEnviar.IdTF = valorTF;
    }
    
    private void BTN_suaveModeradoTF_Clicked(object sender, EventArgs e)
    {
        int valorTF = 2;
        ObtenerDatosAEnviar.IdTF = valorTF;
    }

    private void BTN_fuerteAbundanteTF_Clicked(object sender, EventArgs e)
    {
        int valorTF = 3;
        ObtenerDatosAEnviar.IdTF = valorTF;
    }
    private void BTN_suaveAbundanteTF_Clicked(object sender, EventArgs e)
    {
        int valorTF = 4;
        ObtenerDatosAEnviar.IdTF = valorTF;
    }

    private void BTN_fuerteModeradoTF_Clicked(object sender, EventArgs e)
    {
        int valorTF = 5;
        ObtenerDatosAEnviar.IdTF = valorTF;
    }

    private async void Btn_IngresarBiomarcador_Clicked(object sender, EventArgs e)
    {
        try 
        {
            if (String.IsNullOrEmpty(tempbasal.Text))
            {
                await DisplayAlert("Advertencia", "Favor Ingresar los Temperatura Basal", "Ok");
                return;
            }
            else
            {
                if (decimal.TryParse(tempbasal.Text, out decimal temperaturabasal))
                {
                    ReqIngresarBiomarcadores reqIngresarBiomarcadores = new ReqIngresarBiomarcadores();
                    reqIngresarBiomarcadores.session = ObtenerDatosAEnviar.Session;
                    reqIngresarBiomarcadores.elBiomarcador = new Biomarcadores();
                    reqIngresarBiomarcadores.elBiomarcador.Fecha = fechaBiomarcador.Date;
                    reqIngresarBiomarcadores.elBiomarcador.Temp_Basal = temperaturabasal;
                    if (ObtenerDatosAEnviar.IdEstadoAnimo == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar los estado animo", "Ok");
                        return;
                    }
                    else if (ObtenerDatosAEnviar.IdCamCervix == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar un cambio  cervix", "Ok");
                        return;
                    }
                    else if (ObtenerDatosAEnviar.IdSintomas == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar un sintoma  ", "Ok");
                        return;
                    }
                    else if (ObtenerDatosAEnviar.IdSTang == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar un tipo sangrado", "Ok");
                        return;
                    }
                    else if (ObtenerDatosAEnviar.IdSangradoMenstr == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor selecionar cantidad de sangrado", "Ok");
                        return;
                    }
                    else if (string.IsNullOrEmpty(ObtenerDatosAEnviar.Libido))
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar un tipo deseo sexual", "Ok");
                        return;
                    }
                    else if (ObtenerDatosAEnviar.IdMocoCervix == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar un tipo de moco cervical", "Ok");
                        return;
                    }
                    else if (ObtenerDatosAEnviar.IdTF == 0)
                    {
                        await DisplayAlert("Advertencia", "Favor Ingresar un tipo de flujo", "Ok");
                        return;
                    }
                    else
                    {
                        
                        reqIngresarBiomarcadores.elBiomarcador.EstadoAnimo_ID = ObtenerDatosAEnviar.IdEstadoAnimo;
                        reqIngresarBiomarcadores.elBiomarcador.CamCervixId = ObtenerDatosAEnviar.IdCamCervix;
                        reqIngresarBiomarcadores.elBiomarcador.Sint_Id = ObtenerDatosAEnviar.IdSintomas;
                        reqIngresarBiomarcadores.elBiomarcador.T_Sang_Id = ObtenerDatosAEnviar.IdSTang;
                        reqIngresarBiomarcadores.elBiomarcador.Cant_MenstruacionId = ObtenerDatosAEnviar.IdSangradoMenstr;
                        reqIngresarBiomarcadores.elBiomarcador.Libido = ObtenerDatosAEnviar.Libido;
                        reqIngresarBiomarcadores.elBiomarcador.MocoCervixId = ObtenerDatosAEnviar.IdMocoCervix;
                        reqIngresarBiomarcadores.elBiomarcador.Tipo_FlujoId = ObtenerDatosAEnviar.IdTF;
                        reqIngresarBiomarcadores.elBiomarcador.Libido = ObtenerDatosAEnviar.Libido;
                        reqIngresarBiomarcadores.elBiomarcador.Notas = Notas.Text;
                        
                        //ojo aca me dio error
                        var jsonContent = new StringContent(JsonConvert.SerializeObject(reqIngresarBiomarcadores), Encoding.UTF8, "application/json");
                        HttpClient httpClient = new HttpClient();

                        var response = await httpClient.PostAsync(api + "Biomarcadores/IngresarBiomarcador", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            ResIngresarBiomarcadores resIngresarBiomarcadores = new ResIngresarBiomarcadores();
                            var responseContent = await response.Content.ReadAsStringAsync();
                            resIngresarBiomarcadores = JsonConvert.DeserializeObject<ResIngresarBiomarcadores>(responseContent);
                            if (resIngresarBiomarcadores.errorCode == 0)
                            {
                                await DisplayAlert("EXITO", "Biomarcador registrado", "Ok");
                            }
                        }
                        else
                        {
                            await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                        }
                    }

                }
            }
        }
        catch (Exception ex) 
        {
            
        }
    }
}