using _20240326.ConexionDatos;
using _20240326.Models;
using _20240326.Pages;
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
            var param = new Dictionary<string, object> {
                { nameof(Plato), new Plato()}
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage),param);
        }
        async void OnElementoCambiado(object sender, SelectionChangedEventArgs e) {
            Debug.WriteLine("[EVENTO] Boton ElementoCambiado clickeado.");
            var param = new Dictionary<string, object> {
                { nameof(Plato),e.CurrentSelection.FirstOrDefault() as Plato}
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }
    }

}
