using NominaXpert.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;
    // Obtener la URL desde el archivo  configuración
    private readonly string _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] ?? throw new InvalidOperationException("La clave 'ApiBaseUrl' no está configurada en AppSettings.");

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task<List<EmpleadosRH>> ObtenerInfoAsync(string matricula, DateTime fechaInicio, DateTime fechaFin)
    {
        try
        {
            string endpoint = "RecursosHumanosControllerAPI_test/obtenerInfo";

            // Formatear fechas en yyyy-MM-dd para evitar confusiones
            string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
            string fechaFinStr = fechaFin.ToString("yyyy-MM-dd");

            string queryString = $"?matricula={Uri.EscapeDataString(matricula)}&fechaInicio={fechaInicioStr}&fechaFin={fechaFinStr}";

            HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + endpoint + queryString);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                // Dependiendo si la API devuelve una lista o un objeto:
                // Si es un solo objeto:
                // return new List<EmpleadosRH> { JsonConvert.DeserializeObject<EmpleadosRH>(json) };

                // Si es lista:
                return JsonConvert.DeserializeObject<List<EmpleadosRH>>(json);
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener info: {response.StatusCode} - {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en API: {ex.Message}");
            throw;
        }
    }

}
