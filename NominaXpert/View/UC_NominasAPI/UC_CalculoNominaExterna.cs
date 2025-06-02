using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NominaXpert.Model;

using Newtonsoft.Json;
using System.Net.Http;


namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_CalculoNominaExterna : UserControl
    {
        private readonly ApiService _apiService = new ApiService();
        private bool _isLoading = false;

        public UC_CalculoNominaExterna()
        {
            InitializeComponent();
            ConfigurarToolTips();
            ConfigurarProgressBar();
        }

        private void ConfigurarProgressBar()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Visible = false;
        }

        private void ConfigurarToolTips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(ipbMatricula, "Ejemplo: E-2025-0001");
        }

        private void MostrarCarga(bool mostrar)
        {
            _isLoading = mostrar;
            progressBar1.Visible = mostrar;
            btnBuscar.Enabled = !mostrar;
            txtMatricula.Enabled = !mostrar;
            dtpFechaInicioNomina.Enabled = !mostrar;
            dtpFechaFinNomina.Enabled = !mostrar;
        }

        private async Task BuscarEmpleado()
        {
            if (_isLoading) return;

            string matricula = txtMatricula.Text.Trim();
            DateTime fechaInicio = dtpFechaInicioNomina.Value;
            DateTime fechaFin = dtpFechaFinNomina.Value;

            // Validaciones
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Por favor, ingrese la matrícula del empleado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MostrarCarga(true);
                var empleados = await _apiService.ObtenerInfoAsync(matricula, fechaInicio, fechaFin);

                if (empleados == null || empleados.Count == 0)
                {
                    MessageBox.Show("No se encontró información para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    return;
                }

                var empleado = empleados.First();
                MostrarDatosEmpleado(empleado);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de conexión: No se pudo conectar con el servidor. Por favor, verifique su conexión a internet.",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("La solicitud ha excedido el tiempo de espera. Por favor, intente nuevamente.",
                    "Tiempo de espera agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarCampos();
            }
            catch (JsonReaderException)
            {
                MessageBox.Show("Error al procesar la respuesta del servidor. Por favor, contacte al administrador.",
                    "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
            finally
            {
                MostrarCarga(false);
            }
        }

        private void MostrarDatosEmpleado(EmpleadosRH empleado)
        {
            txtNombreEmpleado.Text = empleado.nombreEmpleado;
            txtEstatusEmpleado.Text = empleado.estatusEmpleado;
            ContratoEstatus.Text = empleado.estatusContrato;
            txtDiasLaborados.Text = empleado.diasTrabajados.ToString();
            txtSueldoBase.Text = $"$ {empleado.salario:N2}";
        }

        private void LimpiarCampos()
        {
            txtNombreEmpleado.Clear();
            txtEstatusEmpleado.Clear();
            ContratoEstatus.Clear();
            txtDiasLaborados.Clear();
            txtSueldoBase.Text = "  $";
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await BuscarEmpleado();
        }

        private void UC_CalculoNominaExterna_Load(object sender, EventArgs e)
        {
            // Configurar fechas por defecto
            dtpFechaInicioNomina.Value = DateTime.Now.AddDays(-15);
            dtpFechaFinNomina.Value = DateTime.Now;
        }

        private async void btnBuscar_Click_1(object sender, EventArgs e)
        {
            await BuscarEmpleado();
        }
    }
}
