using PracticaXF.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticaXF.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeVista : ContentPage
    {
        public HomeVista()
        {
            InitializeComponent();
            BindingContext = new HomeVistaModelo();
        }
    }
}