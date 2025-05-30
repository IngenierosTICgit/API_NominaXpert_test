// Crear un nuevo modelo SOLO para las respuestas de la API
// Agregar este archivo: NominaApiResponse.cs

using System;

namespace NominaXpertCore.Model
{
    /// <summary>
    /// Modelo limpio para las respuestas de la API de nóminas
    /// </summary>
    public class NominaApiResponse
    {
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoPago { get; set; }

        // Información del empleado (limpia)
        public string NombreEmpleado { get; set; }
        public string DepartamentoEmpleado { get; set; }
        public string RfcEmpleado { get; set; }
        public decimal SueldoBase { get; set; }

        // Información del pago
        public decimal MontoTotal { get; set; }
        public string MontoLetras { get; set; }

        // Constructor por defecto
        public NominaApiResponse()
        {
            EstadoPago = "Pendiente";
            NombreEmpleado = string.Empty;
            DepartamentoEmpleado = string.Empty;
            RfcEmpleado = string.Empty;
            MontoLetras = string.Empty;
        }

        // Método para convertir desde NominaConsulta
        public static NominaApiResponse FromNominaConsulta(NominaConsulta nomina)
        {
            return new NominaApiResponse
            {
                IdNomina = nomina.IdNomina,
                IdEmpleado = nomina.IdEmpleado,
                FechaInicio = nomina.FechaInicio,
                FechaFin = nomina.FechaFin,
                EstadoPago = nomina.EstadoPago,
                NombreEmpleado = nomina.NombreEmpleado,
                DepartamentoEmpleado = nomina.DepartamentoEmpleado,
                RfcEmpleado = nomina.RfcEmpleado,
                SueldoBase = nomina.SueldoBase,
                MontoTotal = nomina.MontoTotal,
                MontoLetras = nomina.MontoLetras
            };
        }

        // Método para convertir una lista
        public static List<NominaApiResponse> FromNominaConsultaList(List<NominaConsulta> nominas)
        {
            return nominas.Select(n => FromNominaConsulta(n)).ToList();
        }
    }
}