using _20240326.ConexionDatos;
using AudioToolbox;

namespace _20240326
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos restConexionDatos;

        public MainPage(IRestConexionDatos restConexionDatos)
        {
            InitializeComponent();
            this.restConexionDatos = restConexionDatos;
        }
        protected async override void OnAppearing() { 
            base.OnAppearing();
            coleccionPlatosView.ItemsSource = await restConexionDatos.GetPlatosAsync();
        }
        
    }

}
