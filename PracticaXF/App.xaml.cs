using PracticaXF.Vista;
using Xamarin.Forms;

namespace PracticaXF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // New NavigationPage es importante para soportar la navegación entre vistas dentro de la App.
            // MainPage indica la vista principal para la App.
            MainPage = new NavigationPage(new LoginVista());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
