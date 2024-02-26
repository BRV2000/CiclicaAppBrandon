using Frontend.Views;
using Frontend.Views.Paginas;

namespace Frontend
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogCiclica());
           //MainPage = new AppShell(); //PagObtenerElMetodoAnticoncepEnUso();
        }
    }
}