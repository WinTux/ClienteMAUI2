using _20240326.ConexionDatos;
using System.Diagnostics;

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
        async void OnAddPlatoClic(object sender, EventArgs e) {
            Debug.WriteLine("[EVENTO] Boton AddPlato clickeado.");
        }
        async void OnElementoCambiado(object sender, SelectionChangedEventArgs e) {
            Debug.WriteLine("[EVENTO] Boton ElementoCambiado clickeado.");
        }
    }

}
