using NominaXpertCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NominaXpertCore.Model;
using NLog;
using NominaXpertCore.Utilities;
using ControlEscolarCore.Utilities;
using Npgsql;
using System.Data;
using ControlEscolarCore.Data;
using NominaXpertCore.Business;


namespace NominaXpertCore.Controller
{
    public class NominaExController
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("NominaXpert.Controller.NominaExController");
        private readonly NominaExDataAccess _nominaExDataAccess;
        private readonly AuditoriaDataAccess _auditoriaDataAccess;

        public NominaExController()
        {
            _nominaExDataAccess = new NominaExDataAccess();
            _auditoriaDataAccess = new AuditoriaDataAccess();
        }

        public bool GuardarNominaExterna(EmpleadosRH empleado, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                // Verificar si ya existe una nómina para este empleado y período
                if (_nominaExDataAccess.ExisteNominaExterna(empleado.matricula, fechaInicio, fechaFin))
                {
                    _logger.Warn($"Ya existe una nómina externa para el empleado {empleado.nombreEmpleado} en el período especificado.");
                    return false;
                }

                // Registrar la nueva nómina externa
                int idNomina = _nominaExDataAccess.RegistrarNominaExterna(empleado, fechaInicio, fechaFin);

                if (idNomina > 0)
                {
                    _logger.Info($"Nómina externa guardada exitosamente. ID: {idNomina}");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al guardar la nómina externa");
                throw;
            }
        }

        public DataTable ObtenerNominasExternas()
        {
            try
            {
                return _nominaExDataAccess.ObtenerTodasNominasExternas();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener las nóminas externas");
                throw;
            }
        }

        public bool ActualizarEstadoPago(int idNomina, string nuevoEstado)
        {
            try
            {
                int resultado = _nominaExDataAccess.ActualizarEstadoPago(idNomina, nuevoEstado);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el estado de pago de la nómina {idNomina}");
                throw;
            }
        }

        public int ActualizarEstadoPago(int idNomina, string nuevoEstado, int idUsuario)
        {
            try
            {
                // Registrar la auditoría de la acción de actualización del estado de pago
                var nomina = _nominaExDataAccess.BuscarNominaPorId(idNomina); // Obtenemos la nómina para detalles adicionales
                if (nomina != null)
                {
                    string detalleAccion = $"Se actualizó el estado de la nómina del empleado [ID: {nomina.IdEmpleado}] " +
                                           $"para el periodo {nomina.FechaInicio.ToShortDateString()} - {nomina.FechaFin.ToShortDateString()} " +
                                           $"a {nuevoEstado}.";

                    // Llamar al método de auditoría para registrar la acción, incluyendo el idUsuario
                    _auditoriaDataAccess.RegistrarAuditoria(idUsuario, "edición de nómina", detalleAccion);
                }

                // Realizar la actualización del estado de pago en la base de datos
                _logger.Info($"NominasController -> ActualizarEstadoPago ejecutado para nómina {idNomina} nuevo estado: {nuevoEstado}");
                return _nominaExDataAccess.ActualizarEstadoPago(idNomina, nuevoEstado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al actualizar el estado de pago.");
                return 0; // Retorna 0 en caso de error
            }
        }
    }
} 