using NominaXpertCore.Controller;
using Microsoft.AspNetCore.Mvc;
using NominaXpertCore.Model;

namespace API_NominaXpert
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominaXpertControllerAPI : ControllerBase
    {
        private readonly NominasController _nominasController;
        private readonly ILogger<NominaXpertControllerAPI> _logger;

        public NominaXpertControllerAPI(NominasController nominasController, ILogger<NominaXpertControllerAPI> logger)
        {
            _nominasController = nominasController;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las nóminas del sistema (equivalente a CargarNominasPorDefecto)
        /// </summary>
        /// <returns>Lista completa de nóminas</returns>
        [HttpGet("nominas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NominaConsulta>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTodasLasNominas()
        {
            try
            {
                var nominas = _nominasController.DesplegarNominasConDatosCompletos();

                _logger.LogInformation($"Se obtuvieron {nominas.Count} nóminas del sistema");

                return Ok(nominas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las nóminas");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Obtiene las nóminas filtradas por estado de pago
        /// </summary>
        /// <param name="estado">Estado de pago (Todos, Pendiente, Pagado)</param>
        /// <returns>Lista de nóminas filtradas por estado</returns>
        [HttpGet("nominas/estado/{estado}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NominaConsulta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNominasPorEstado(string estado)
        {
            try
            {
                // Validar estados permitidos
                var estadosPermitidos = new[] { "Todos", "Pendiente", "Pagado", "Rechazado" };
                if (!estadosPermitidos.Contains(estado, StringComparer.OrdinalIgnoreCase))
                {
                    return BadRequest("Estado inválido. Estados permitidos: Todos, Pendiente, Pagado, Rechazado");
                }

                // Obtener todas las nóminas
                var nominas = _nominasController.DesplegarNominasConDatosCompletos();

                // Filtrar por estado si no es "Todos"
                if (!estado.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                {
                    nominas = nominas.Where(n => n.EstadoPago.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                _logger.LogInformation($"Se encontraron {nominas.Count} nóminas con estado '{estado}'");

                return Ok(nominas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener nóminas por estado: {estado}");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Obtiene las nóminas filtradas por rango de fechas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del periodo</param>
        /// <param name="fechaFin">Fecha de fin del periodo</param>
        /// <returns>Lista de nóminas en el rango de fechas</returns>
        [HttpGet("nominas/fechas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NominaConsulta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNominasPorFechas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                // Validar que la fecha de fin no sea anterior a la fecha de inicio
                if (fechaFin < fechaInicio)
                {
                    return BadRequest("La fecha de fin no puede ser anterior a la fecha de inicio.");
                }

                var nominas = _nominasController.BuscarNominasPorFechas(fechaInicio, fechaFin);

                _logger.LogInformation($"Se encontraron {nominas.Count} nóminas entre {fechaInicio:dd/MM/yyyy} y {fechaFin:dd/MM/yyyy}");

                return Ok(nominas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener nóminas por rango de fechas");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Obtiene las nóminas filtradas por matrícula de empleado
        /// </summary>
        /// <param name="matricula">Matrícula del empleado</param>
        /// <returns>Lista de nóminas del empleado</returns>
        [HttpGet("nominas/empleado/{matricula}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NominaConsulta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNominasPorMatricula(string matricula)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(matricula))
                {
                    return BadRequest("La matrícula no puede estar vacía");
                }

                var nominas = _nominasController.BuscarNominasPorMatriculaYFechas(
                    matricula.Trim(),
                    DateTime.MinValue,
                    DateTime.MinValue
                );

                if (nominas.Count == 0)
                {
                    return NotFound($"No se encontraron nóminas para la matrícula: {matricula}");
                }

                _logger.LogInformation($"Se encontraron {nominas.Count} nóminas para la matrícula: {matricula}");

                return Ok(nominas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener nóminas por matrícula: {matricula}");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Obtiene las nóminas con estado "Pagado" dentro de un rango de fechas (método original mejorado)
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del periodo a buscar</param>
        /// <param name="fechaFin">Fecha de fin del periodo a buscar</param>
        /// <returns>Lista de nóminas pagadas en el rango de fechas especificado</returns>
        [HttpGet("nominas-pagadas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NominaConsulta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNominasPagadas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                // Validar que la fecha de fin no sea anterior a la fecha de inicio
                if (fechaFin < fechaInicio)
                {
                    return BadRequest("La fecha de fin no puede ser anterior a la fecha de inicio.");
                }

                // Obtener las nóminas filtradas por fechas
                var nominas = _nominasController.BuscarNominasPorFechas(fechaInicio, fechaFin);

                // Filtrar solo las nóminas con estado "Pagado"
                var nominasPagadas = nominas.Where(n => n.EstadoPago.Equals("Pagado", StringComparison.OrdinalIgnoreCase)).ToList();

                _logger.LogInformation($"Se encontraron {nominasPagadas.Count} nóminas pagadas entre {fechaInicio:dd/MM/yyyy} y {fechaFin:dd/MM/yyyy}");

                return Ok(nominasPagadas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las nóminas pagadas");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Obtiene una nómina específica por su ID
        /// </summary>
        /// <param name="id">ID de la nómina</param>
        /// <returns>Detalle de la nómina</returns>
        [HttpGet("nomina/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NominaConsulta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNominaPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El ID de la nómina debe ser mayor a 0");
                }

                var nomina = _nominasController.BuscarNominaPorId(id);

                if (nomina == null)
                {
                    return NotFound($"No se encontró la nómina con ID: {id}");
                }

                _logger.LogInformation($"Se obtuvo la nómina con ID: {id}");

                return Ok(nomina);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la nómina con ID: {id}");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Obtiene un resumen estadístico de las nóminas
        /// </summary>
        /// <returns>Estadísticas de nóminas</returns>
        [HttpGet("nominas/estadisticas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEstadisticasNominas()
        {
            try
            {
                var nominas = _nominasController.DesplegarNominasConDatosCompletos();

                var estadisticas = new
                {
                    TotalNominas = nominas.Count,
                    NominasPendientes = nominas.Count(n => n.EstadoPago == "Pendiente"),
                    NominasPagadas = nominas.Count(n => n.EstadoPago == "Pagado"),
                    MontoTotalPagado = nominas.Where(n => n.EstadoPago == "Pagado").Sum(n => n.MontoTotal),
                    MontoTotalPendiente = nominas.Where(n => n.EstadoPago == "Pendiente").Sum(n => n.MontoTotal)
                };

                _logger.LogInformation("Se generaron las estadísticas de nóminas");

                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estadísticas de nóminas");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }

        /// <summary>
        /// Búsqueda avanzada de nóminas con múltiples filtros
        /// </summary>
        /// <param name="matricula">Matrícula del empleado (opcional)</param>
        /// <param name="estado">Estado de pago (opcional)</param>
        /// <param name="fechaInicio">Fecha de inicio (opcional)</param>
        /// <param name="fechaFin">Fecha de fin (opcional)</param>
        /// <returns>Lista de nóminas filtradas</returns>
        [HttpGet("nominas/busqueda")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NominaConsulta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BusquedaAvanzadaNominas(
            [FromQuery] string? matricula = null,
            [FromQuery] string? estado = null,
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null)
        {
            try
            {
                // Validar fechas si ambas están presentes
                if (fechaInicio.HasValue && fechaFin.HasValue && fechaFin < fechaInicio)
                {
                    return BadRequest("La fecha de fin no puede ser anterior a la fecha de inicio.");
                }

                List<NominaConsulta> nominas;

                // Si se proporciona matrícula, buscar por matrícula y fechas
                if (!string.IsNullOrWhiteSpace(matricula))
                {
                    nominas = _nominasController.BuscarNominasPorMatriculaYFechas(
                        matricula.Trim(),
                        fechaInicio ?? DateTime.MinValue,
                        fechaFin ?? DateTime.MinValue
                    );
                }
                // Si se proporcionan fechas pero no matrícula
                else if (fechaInicio.HasValue && fechaFin.HasValue)
                {
                    nominas = _nominasController.BuscarNominasPorFechas(fechaInicio.Value, fechaFin.Value);
                }
                // Si no se proporcionan filtros específicos, obtener todas
                else
                {
                    var nominas = _nominasController.DesplegarNominasConDatosCompletos();
                }

                // Filtrar por estado si se proporciona
                if (!string.IsNullOrWhiteSpace(estado) && !estado.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                {
                    nominas = nominas.Where(n => n.EstadoPago.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                _logger.LogInformation($"Búsqueda avanzada completada. Se encontraron {nominas.Count} nóminas");

                return Ok(nominas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en la búsqueda avanzada de nóminas");
                return StatusCode(500, "Error interno del servidor al procesar la solicitud");
            }
        }
    }
}