using _20240326.Pages;

namespace _20240326
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GestionPlatosPage), typeof(GestionPlatosPage));
        }
    }
}
