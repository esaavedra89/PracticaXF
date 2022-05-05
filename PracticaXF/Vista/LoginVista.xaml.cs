
using PracticaXF.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticaXF.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginVista : ContentPage
    {
        public LoginVista()
        {
            InitializeComponent();

            // Oculta la barra de navegación para la vista.
            NavigationPage.SetHasNavigationBar(this, false);

            // Binding con la clase donde se realizará la lógica de la vista.
            BindingContext = new LoginVistaModelo();
        }
    }
}