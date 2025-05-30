using System;

namespace NominaXpertCore.Model
{
    public class NominaConsulta
    {
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoPago { get; set; }
        public Empleado DatosEmpleado { get; set; }

        // Nuevas propiedades agregadas para el pago
        public decimal MontoTotal { get; set; }
        public string MontoLetras { get; set; }

        // NUEVAS PROPIEDADES: Datos directos del empleado (para API)
        public string NombreEmpleadoDirecto { get; set; }
        public string DepartamentoEmpleadoDirecto { get; set; }
        public string RfcEmpleadoDirecto { get; set; }
        public decimal SueldoBaseDirecto { get; set; }

        // Constructor predeterminado
        public NominaConsulta()
        {
            IdNomina = 0; // ID por defecto
            IdEmpleado = 0; // ID empleado por defecto
            FechaInicio = DateTime.Now.Date; // Fecha actual sin hora
            FechaFin = DateTime.Now.Date; // Fecha actual sin hora
            EstadoPago = "Pendiente"; // Estado inicial por defecto
            DatosEmpleado = null; // Relación no cargada inicialmente
            MontoTotal = 0; // Monto inicial
            MontoLetras = string.Empty; // Monto en letras vacío
                                        // Inicializar las nuevas propiedades
            NombreEmpleadoDirecto = string.Empty;
            DepartamentoEmpleadoDirecto = string.Empty;
            RfcEmpleadoDirecto = string.Empty;
            SueldoBaseDirecto = 0;
        }

        // Constructor parcial (con datos clave sin relaciones)
        public NominaConsulta(int idNomina, int idEmpleado, DateTime fechaInicio, DateTime fechaFin, string estadoPago)
        {
            IdNomina = idNomina;
            IdEmpleado = idEmpleado;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            EstadoPago = estadoPago;
            DatosEmpleado = null;
            MontoTotal = 0;
            MontoLetras = string.Empty;

            // Inicializar las nuevas propiedades
            NombreEmpleadoDirecto = string.Empty;
            DepartamentoEmpleadoDirecto = string.Empty;
            RfcEmpleadoDirecto = string.Empty;
            SueldoBaseDirecto = 0;
        }

        // Constructor completo (incluyendo el objeto Empleado relacionado)
        // Constructor completo
        public NominaConsulta(int idNomina, int idEmpleado, DateTime fechaInicio, DateTime fechaFin, string estadoPago, Empleado datosEmpleado, decimal montoTotal, string montoLetras)
        {
            IdNomina = idNomina;
            IdEmpleado = idEmpleado;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            EstadoPago = estadoPago;
            DatosEmpleado = datosEmpleado;
            MontoTotal = montoTotal;
            MontoLetras = montoLetras;

            // Inicializar las nuevas propiedades
            NombreEmpleadoDirecto = string.Empty;
            DepartamentoEmpleadoDirecto = string.Empty;
            RfcEmpleadoDirecto = string.Empty;
            SueldoBaseDirecto = 0;
        }
        // PROPIEDADES CALCULADAS (mantener compatibilidad con código existente)
        // Estas propiedades ahora priorizan los valores directos si están disponibles
        public string NombreEmpleado =>
            !string.IsNullOrEmpty(NombreEmpleadoDirecto) ? NombreEmpleadoDirecto :
            DatosEmpleado?.DatosPersonales?.NombreCompleto ?? "Sin Nombre";

        public string DepartamentoEmpleado =>
            !string.IsNullOrEmpty(DepartamentoEmpleadoDirecto) ? DepartamentoEmpleadoDirecto :
            DatosEmpleado?.Departamento ?? "Sin Departamento";

        public string RfcEmpleado =>
            !string.IsNullOrEmpty(RfcEmpleadoDirecto) ? RfcEmpleadoDirecto :
            DatosEmpleado?.DatosPersonales?.Rfc ?? "Sin RFC";

        public decimal SueldoBase =>
            SueldoBaseDirecto > 0 ? SueldoBaseDirecto :
            DatosEmpleado?.Sueldo ?? 0;
    }
}
