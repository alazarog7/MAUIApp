using PlatosApp.Pages;

namespace PlatosApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlatoFormPage), typeof(PlatoFormPage));
        }
    }
}
