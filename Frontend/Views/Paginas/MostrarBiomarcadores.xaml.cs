using Frontend.CapturarDatos;
using Frontend.Models;
using System.Globalization;

namespace Frontend.Views.Paginas;

public partial class MostrarBiomarcadores : ContentPage
{
    
	public MostrarBiomarcadores()
	{
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
        InitializeComponent();

        var historialBiomarcadores = ObtenerDatosAEnviar.historialbiomarcadors;

        DatosDeBiomarcadores.ItemsSource = historialBiomarcadores;
    }

    private void BTN_RegresarDeBiomarcadores_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Btn_RegistroBiomarcadores_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new IngresarBiomarcadores());
    }
}