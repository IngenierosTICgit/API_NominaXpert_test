using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NominaXpertCore.Controller;
using NominaXpertCore.Business;
using NominaXpertCore.Model;
using ControlEscolar.Utilities;
using NLog;
using NominaXpertCore.Utilities;


namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_NominaReciboExterno : UserControl
    {
        public int IdNomina { get; set; }
        private static readonly Logger _logger = LoggingManager.GetLogger("NominaXpert.Controller.NominaExterna");
        private readonly NominaExController _nominaExController = new NominaExController();
        private readonly BonificacionController _bonificacionController;
        private readonly NominasController _nominaController;
        private readonly DeduccionController _deduccionController;
        public UC_NominaReciboExterno(int idNomina)
        {
            InitializeComponent();
            PoblaCombo();

            _nominaController = new NominasController();
            _bonificacionController = new BonificacionController();
            _deduccionController = new DeduccionController();

            this.IdNomina = idNomina;

            if (idNomina > 0)
                CargarRecibo();
            else
                MessageBox.Show("No se proporcionó una nómina válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void PoblaCombo()
        {
            var metodosPago = new Dictionary<int, string>
    {
        { 1, "Transferencia" },
        { 2, "Efectivo" },
        { 3, "Cheque" }
    };

            cboMetodoPago.DataSource = new BindingSource(metodosPago, null);
            cboMetodoPago.DisplayMember = "Value";
            cboMetodoPago.ValueMember = "Key";
            cboMetodoPago.SelectedIndex = 0; // Por defecto Transferencia
        }


        private void CargarRecibo()
        {
            try
            {
                var tabla = _nominaExController.ObtenerNominasExternas();
                var fila = tabla.Select($"id = {IdNomina}").FirstOrDefault();
                if (fila == null)
                {
                    MessageBox.Show("No se encontró la nómina externa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblNombreEmpleado.Text = fila["nombre_empleado"].ToString();
                lblDepartamento.Text = fila["departamento"].ToString();
                lblIdEmpleado.Text = fila["id_empleado"].ToString();
                lblEstado.Text = fila["estado_pago"].ToString();

                DateTime fechaInicio = Convert.ToDateTime(fila["fecha_inicio"]);
                DateTime fechaFin = Convert.ToDateTime(fila["fecha_fin"]);
                lblFechaInicio.Text = fechaInicio.ToShortDateString();
                lblFechaFin.Text = fechaFin.ToShortDateString();

                int diasTrabajados = Convert.ToInt32(fila["dias_trabajados"]);
                decimal sueldoBase = Convert.ToDecimal(fila["salario"]);
                decimal sueldoPorDia = sueldoBase / 22m;

                if (diasTrabajados <= 0)
                {
                    int diasLaborables = diasTrabajados;
                    diasTrabajados = diasLaborables > 0 ? diasLaborables : 1;
                    _logger.Warn($"No se encontraron horas trabajadas. Se asignan {diasTrabajados * 8} horas por {diasLaborables} días laborables.");
                }

                decimal sueldoPorDiasTrabajados = sueldoPorDia * diasTrabajados;
                var percepciones = _bonificacionController.ObtenerBonificacionesPorNomina(IdNomina);
                var deducciones = _deduccionController.ObtenerDeduccionesPorNomina(IdNomina);
                decimal totalPercepciones = percepciones.Sum(p => p.Monto);
                decimal totalDeducciones = deducciones.Sum(d => d.Monto);
                decimal totalNeto = sueldoPorDiasTrabajados + totalPercepciones - totalDeducciones;

                lblTotalPercepciones.Text = totalPercepciones.ToString("C");
                lblTotalDeducciones.Text = totalDeducciones.ToString("C");
                lblSueldoBase.Text = sueldoBase.ToString("C");
                lblSueldoPorHorasTrabajadas.Text = sueldoPorDiasTrabajados.ToString("C");
                lblTotalNeto.Text = totalNeto.ToString("C");
                lblMontoLetras.Text = NominaNegocio.ConvertirNumeroALetras(totalNeto);

                if (fila["estado_pago"].ToString() == "Pagado")
                {
                    btnGenerarNómina.Visible = false;
                    btnRegresar.Visible = false;
                    lblMetodoPago.Visible = false;
                    cboMetodoPago.Visible = false;
                }
                else
                {
                    btnGenerarNómina.Enabled = true;
                    btnRegresar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cargar el recibo de nómina externa");
                MessageBox.Show($"Error al cargar el recibo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UC_NominaReciboExterno_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerarNómina_Click(object sender, EventArgs e)
        {
            try
            {
                PagoController _pagoController = new PagoController();
                if (_pagoController.ExistePago(this.IdNomina))
                {
                    MessageBox.Show("Esta nómina ya fue pagada. No es posible generar otro pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboMetodoPago.SelectedItem == null || string.IsNullOrWhiteSpace(cboMetodoPago.Text))
                {
                    MessageBox.Show("Debe seleccionar un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nomina = _nominaController.BuscarNominaPorId(IdNomina);
                decimal sueldoBase = nomina.SueldoBase;

                if (_nominaController.VerificarSueldoMenorMinimo(sueldoBase))
                {
                    decimal minimo = _nominaController.ObtenerSueldoMinimo();
                    MessageBox.Show($"El sueldo base del empleado (${sueldoBase:N2}) es menor al mínimo (${minimo:N2}).", "Error - Sueldo Mínimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_nominaController.VerificarSueldoIgualMinimo(sueldoBase))
                {
                    decimal minimo = _nominaController.ObtenerSueldoMinimo();
                    DialogResult dr = MessageBox.Show($"El sueldo base del empleado (${sueldoBase:N2}) es igual al mínimo (${minimo:N2}).\n\n¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;
                }
                var tabla = _nominaExController.ObtenerNominasExternas();
                var fila = tabla.Select($"id = {IdNomina}").FirstOrDefault();

                decimal sueldoPorDia = sueldoBase / 22m;
                int diasTrabajados = Convert.ToInt32(fila["dias_trabajados"]);
                decimal sueldoPorDias = sueldoPorDia * diasTrabajados;
                var percepciones = _bonificacionController.ObtenerBonificacionesPorNomina(IdNomina);
                var deducciones = _deduccionController.ObtenerDeduccionesPorNomina(IdNomina);
                decimal totalPercepciones = percepciones.Sum(p => p.Monto);
                decimal totalDeducciones = deducciones.Sum(d => d.Monto);
                decimal totalNeto = sueldoPorDias + totalPercepciones - totalDeducciones;

                Pago nuevoPago = new Pago
                {
                    IdNomina = this.IdNomina,
                    FechaPago = DateTime.Now,
                    MontoTotal = totalNeto,
                    MontoLetras = NominaNegocio.ConvertirNumeroALetras(totalNeto),
                    MetodoPago = cboMetodoPago.Text,
                    Referencia = "Pago automático generado desde recibo de nómina"
                };

                bool exito = _pagoController.RegistrarPago(nuevoPago);

                if (exito)
                {
                    _nominaExController.ActualizarEstadoPago(this.IdNomina, "Pagado", UsuarioSesion.UsuarioId);
                    CargarRecibo();
                    MessageBox.Show("El pago ha sido registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al generar la nómina");
                MessageBox.Show($"Error al generar la nómina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPDFReciboNomina_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            Form mensajeForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(350, 220),
                Text = "Información del sistema",
                ControlBox = false
            };

            Label lblMensaje = new Label
            {
                Text = "Regresando a Deducciones Externas...",
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            mensajeForm.Controls.Add(lblMensaje);
            mensajeForm.Show();

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                mensajeForm.Invoke((MethodInvoker)delegate { mensajeForm.Close(); });
                this.Invoke((MethodInvoker)delegate
                {
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Remove(this);
                        UC_DeduccionesExternas ucVolver = new UC_DeduccionesExternas(this.IdNomina);
                        ucVolver.Dock = DockStyle.Fill;
                        parent.Controls.Add(ucVolver);
                        parent.Controls.SetChildIndex(ucVolver, 0);
                    }
                });
            };
            timer.Start();
        }
    }
}
