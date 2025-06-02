using NominaXpertCore.Model;
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
            string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
            string fechaFinStr = fechaFin.ToString("yyyy-MM-dd");

            string queryString = $"?matricula={Uri.EscapeDataString(matricula)}&fechaInicio={fechaInicioStr}&fechaFin={fechaFinStr}";

            HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + endpoint + queryString);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<EmpleadosRH>(); // Retorna lista vacía si no se encuentra
            }

            string json = await response.Content.ReadAsStringAsync();

            // Deserializar el objeto JSON único
            var empleado = JsonConvert.DeserializeObject<EmpleadosRH>(json);

            if (empleado != null && !string.IsNullOrEmpty(empleado.matricula))
                return new List<EmpleadosRH> { empleado };

            return new List<EmpleadosRH>(); // Lista vacía si el objeto es null
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en API: {ex.Message}");
            throw;
        }
    }

    public async Task<List<EmpleadosRH>> ObtenerTodosEmpleadosAsync()
    {
        try
        {
            string endpoint = "RecursosHumanosControllerAPI_test/obtenerTodosEmpleados";

            HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + endpoint);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<EmpleadosRH>(); // Lista vacía si no encuentra
            }

            string json = await response.Content.ReadAsStringAsync();

            // Aquí deserializas una lista de empleados (array JSON)
            var empleados = JsonConvert.DeserializeObject<List<EmpleadosRH>>(json);

            return empleados ?? new List<EmpleadosRH>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en API ObtenerTodosEmpleados: {ex.Message}");
            throw;
        }
    }



}
