using Frontend.CapturarDatos;
using Frontend.Entidades;
using Frontend.Models;
using System.Globalization;

namespace Frontend.Views.Paginas;

public partial class HistorialCicloMenstrual : ContentPage
{
    
    public HistorialCicloMenstrual()
	{
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
        InitializeComponent();

        var historialCiclomenstrual = ObtenerDatosAEnviar.cicloMenstruals;

        DatosDelCicloMenstrual.ItemsSource = historialCiclomenstrual;
    }

    private void BTN_RegresarDeHistorialCicloMenstrual_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}