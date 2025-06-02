using System;
using System.Data;
using ControlEscolarCore.Data;
using ControlEscolarCore.Utilities;
using NLog;
using NominaXpertCore.Model;
using Npgsql;

namespace NominaXpertCore.Data
{
    public class NominaExDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("NominaXpert.Data.NominaExDataAccess");
        private readonly PostgresSQLDataAccess _dbAccess;

        public NominaExDataAccess()
        {
            try
            {
                _dbAccess = PostgresSQLDataAccess.GetInstance();
                _logger.Info("Instancia de NominaExDataAccess creada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al inicializar NominaExDataAccess.");
                throw;
            }
        }

        /// <summary>
        /// Registra una nueva nómina externa con la información obtenida del API
        /// </summary>
        public int RegistrarNominaExterna(EmpleadosRH empleado, DateTime fechaInicio, DateTime fechaFin)
        {
            string query = @"
                INSERT INTO nomina.nomina_externa (
                    fecha_inicio, 
                    fecha_fin, 
                    estado_pago,
                    matricula,
                    nombre_empleado,
                    estatus_empleado,
                    estatus_contrato,
                    departamento,
                    salario,
                    dias_trabajados
                )
                VALUES (
                    @fechaInicio,
                    @fechaFin,
                    'Pendiente',
                    @matricula,
                    @nombreEmpleado,
                    @estatusEmpleado,
                    @estatusContrato,
                    @departamento,
                    @salario,
                    @diasTrabajados
                )
                RETURNING id;";

            try
            {
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    _dbAccess.CreateParameter("@fechaInicio", fechaInicio),
                    _dbAccess.CreateParameter("@fechaFin", fechaFin),
                    _dbAccess.CreateParameter("@matricula", empleado.matricula),
                    _dbAccess.CreateParameter("@nombreEmpleado", empleado.nombreEmpleado),
                    _dbAccess.CreateParameter("@estatusEmpleado", empleado.estatusEmpleado),
                    _dbAccess.CreateParameter("@estatusContrato", empleado.estatusContrato),
                    _dbAccess.CreateParameter("@departamento", empleado.departamento),
                    _dbAccess.CreateParameter("@salario", empleado.salario),
                    _dbAccess.CreateParameter("@diasTrabajados", empleado.diasTrabajados)
                };

                _dbAccess.Connect();
                DataTable result = _dbAccess.ExecuteQuery_Reader(query, parameters);

                if (result.Rows.Count > 0)
                {
                    int idNomina = Convert.ToInt32(result.Rows[0]["id"]);
                    _logger.Info($"Nómina externa registrada correctamente para el empleado {empleado.nombreEmpleado}, ID: {idNomina}");
                    return idNomina;
                }
                else
                {
                    throw new Exception("No se pudo obtener la ID de la nómina externa.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al registrar la nómina externa.");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si ya existe una nómina externa para el mismo empleado y período
        /// </summary>
        public bool ExisteNominaExterna(string matricula, DateTime fechaInicio, DateTime fechaFin)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM nomina.nomina_externa 
                WHERE matricula = @matricula 
                AND fecha_inicio = @fechaInicio 
                AND fecha_fin = @fechaFin";

            try
            {
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    _dbAccess.CreateParameter("@matricula", matricula),
                    _dbAccess.CreateParameter("@fechaInicio", fechaInicio),
                    _dbAccess.CreateParameter("@fechaFin", fechaFin)
                };

                _dbAccess.Connect();
                DataTable result = _dbAccess.ExecuteQuery_Reader(query, parameters);

                if (result.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(result.Rows[0][0]);
                    return count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al verificar existencia de nómina externa.");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza el estado de pago de una nómina externa
        /// </summary>
        public int ActualizarEstadoPago(int idNomina, string nuevoEstado)
        {
            string query = @"
                UPDATE nomina.nomina_externa
                SET estado_pago = @nuevoEstado
                WHERE id = @idNomina";

            try
            {
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    _dbAccess.CreateParameter("@idNomina", idNomina),
                    _dbAccess.CreateParameter("@nuevoEstado", nuevoEstado)
                };

                _dbAccess.Connect();
                int rowsAffected = _dbAccess.ExecuteNonQuery(query, parameters);

                _logger.Info($"Estado de la nómina externa ID {idNomina} actualizado a '{nuevoEstado}'. Filas afectadas: {rowsAffected}");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al actualizar el estado de pago de la nómina externa.");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todas las nóminas externas
        /// </summary>
        public DataTable ObtenerTodasNominasExternas()
        {
            string query = @"
                SELECT 
                    id,
                    fecha_inicio,
                    fecha_fin,
                    estado_pago,
                    matricula,
                    nombre_empleado,
                    estatus_empleado,
                    estatus_contrato,
                    departamento,
                    salario,
                    dias_trabajados,
                    creado_at
                FROM nomina.nomina_externa
                ORDER BY id DESC";

            try
            {
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);
                _logger.Info($"Se obtuvieron {resultado.Rows.Count} nóminas externas.");
                return resultado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener las nóminas externas.");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
} 