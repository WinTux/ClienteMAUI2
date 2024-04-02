using _20240326.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace _20240326.ConexionDatos
{
    internal class RestConexionDatos : IRestConexionDatos
    {
        public readonly HttpClient HttpClient;
        private readonly string url;
        private readonly string dominio;
        private readonly JsonSerializerOptions opcionesJson;
        public RestConexionDatos()
        {
            HttpClient = new HttpClient();
            dominio = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5241" : "http://localhost:5241";
            url = $"{dominio}/api";
            opcionesJson = new JsonSerializerOptions { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task AddPlatoAsync(Plato plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet/red");
                return;
            }
            try
            {
                string platoSer = JsonSerializer.Serialize<Plato>(plato, opcionesJson);
                StringContent contenido = new StringContent(platoSer, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpClient.PostAsync($"{url}/plato", contenido);
                if(response.IsSuccessStatusCode)
                    Debug.WriteLine($"[RED] Se ha registrado satisfactoriamente.");
                else
                    Debug.WriteLine($"[RED] Sin respuesta HTTP exitosa (2XX).");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
            return;
        }

        public async Task DeletePlatoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet/red");
                return;
            }
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"{url}/plato/{id}");
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine($"[RED] Se ha eliminado satisfactoriamente.");
                else
                    Debug.WriteLine($"[RED] Sin respuesta HTTP exitosa (2XX).");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
            return;
        }

        public async Task<List<Plato>> GetPlatosAsync()
        {
            List<Plato>  platos = new List<Plato>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) {
                Debug.WriteLine("[RED] Sin acceso a internet/red");
                return platos;
            }
            try { 
                HttpResponseMessage response = await HttpClient.GetAsync($"{url}/plato");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    platos = JsonSerializer.Deserialize<List<Plato>>(contenido, opcionesJson);
                }
                else {
                    Debug.WriteLine("[RED] Sin respuesta HTTP exitosa (2XX).");
                }
            } catch (Exception e) {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
            return platos;
        }

        public async Task UpdatePlatoAsync(Plato plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet/red");
                return;
            }
            try
            {
                string platoSer = JsonSerializer.Serialize<Plato>(plato, opcionesJson);
                StringContent contenido = new StringContent(platoSer, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpClient.PutAsync($"{url}/plato/{plato.Id}", contenido);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine($"[RED] Se ha modificado satisfactoriamente.");
                else
                    Debug.WriteLine($"[RED] Sin respuesta HTTP exitosa (2XX).");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
            return;
        }
    }
}
