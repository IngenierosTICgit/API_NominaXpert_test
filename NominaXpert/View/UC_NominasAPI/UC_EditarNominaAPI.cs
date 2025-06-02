using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NominaXpertCore.Business;
using NominaXpertCore.Controller;
using NominaXpert.Utilities;
using NominaXpertCore.Utilities;
using NominaXpert.View.UsersControl;

namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_EditarNominaAPI : UserControl
    {
        private readonly NominasController _nominasController;
        private readonly NominaExController _nominasExController = new NominaExController();
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }

        public UC_EditarNominaAPI(int idNomina)
        {
            InitializeComponent();
            _nominasController = new NominasController();
            this.IdNomina = idNomina;

            if (idNomina > 0)
                txtNoNomina.Text = idNomina.ToString();
        }

        private void PoblaEstatus()
        {
            Dictionary<int, string> list_estatus = new Dictionary<int, string>
            {
                { 1, "Pendiente" },
                { 2, "Pagado" },
                { 3, "Rechazado" }
            };
            cBoxEstatusNomina.DataSource = new BindingSource(list_estatus, null);
            cBoxEstatusNomina.DisplayMember = "Value";
            cBoxEstatusNomina.ValueMember = "Key";
            cBoxEstatusNomina.SelectedValue = 1;
        }

        private void UC_EditarNominaAPI_Load_1(object sender, EventArgs e)
        {
            PoblaEstatus();

            int idUsuario = UsuarioSesion.UsuarioId;
            int idRol = _nominasController.ObtenerRolUsuario(idUsuario);

            if (idRol == -1)
            {
                MessageBox.Show("No se pudo obtener el rol del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idRol != 1 && idRol != 2 && idRol != 5)
            {
                MessageBox.Show("Lo siento, no tienes permisos suficientes para editar nómina.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoNomina.Text))
            {
                MessageBox.Show("El campo de Nómina no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNoNomina.Text.Trim(), out int idNomina))
            {
                MessageBox.Show("El No. de Nómina debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nomina = _nominasExController.BuscarNominaPorId(idNomina);
                if (nomina == null)
                {
                    MessageBox.Show("No se encontró la nómina.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtNombreEmpleado.Text = nomina.NombreEmpleado;
                txtEstadoDePago.Text = nomina.EstadoPago;

                bool esAuditor = UsuarioSesion.RolNombre == "Autorizador";
                bool esAdministrador = UsuarioSesion.RolNombre == "Administrador";

                if (nomina.EstadoPago == "Pagado" && !esAuditor && !esAdministrador)
                {
                    btnActualizarCambios.Visible = false;
                    btnModificar.Visible = false;
                    cBoxEstatusNomina.Visible = false;
                    lblEstatusNomina.Visible = false;
                    lblDatosObligatorios.Visible = false;
                }
                else
                {
                    btnActualizarCambios.Visible = true;
                    btnModificar.Visible = true;
                    cBoxEstatusNomina.Visible = true;
                    lblEstatusNomina.Visible = true;
                    lblDatosObligatorios.Visible = true;
                }

                this.IdNomina = nomina.IdNomina;
                this.IdEmpleado = nomina.IdEmpleado;

                cBoxEstatusNomina.SelectedIndex = cBoxEstatusNomina.FindStringExact(nomina.EstadoPago);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la nómina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarCambios_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoNomina.Text))
            {
                MessageBox.Show("El campo de No. de Nómina no puede estar vacío", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.IdNomina <= 0)
            {
                MessageBox.Show("Debes buscar primero la nómina para actualizar su estado.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoEstado = cBoxEstatusNomina.Text;
            int idUsuario = UsuarioSesion.ObtenerIdUsuarioActual();

            if (idUsuario == -1)
            {
                MessageBox.Show("No se pudo obtener el ID del usuario. Por favor, inicia sesión.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form mensajeForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(350, 220),
                Text = "Información del sistema",
                ControlBox = false
            };

            Label lblMensaje = new Label
            {
                Text = "Generando cambio en el estatus de la Nómina del Empleado...",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            mensajeForm.Controls.Add(lblMensaje);
            mensajeForm.Show();

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                mensajeForm.Invoke((MethodInvoker)delegate
                {
                    mensajeForm.Close();
                    var resultado = _nominasExController.ActualizarEstadoPago(this.IdNomina, nuevoEstado, idUsuario);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Estado de pago actualizado correctamente.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEstadoDePago.Text = nuevoEstado;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                timer.Dispose();
            };
            timer.Start();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (this.IdNomina <= 0)
            {
                MessageBox.Show("Debes buscar primero la nómina antes de modificar percepciones y deducciones.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form mensajeForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(350, 220),
                Text = "Información del sistema",
                ControlBox = false
            };

            Label lblMensaje = new Label
            {
                Text = "Cargando Nómina del Empleado...",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            mensajeForm.Controls.Add(lblMensaje);
            mensajeForm.Show();

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                mensajeForm.Invoke((MethodInvoker)delegate
                {
                    mensajeForm.Close();
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Remove(this);
                        UC_NominaPercepciones ucRecibo = new UC_NominaPercepciones(this.IdNomina);
                        ucRecibo.Dock = DockStyle.Fill;
                        parent.Controls.Add(ucRecibo);
                        parent.Controls.SetChildIndex(ucRecibo, 0);
                    }
                });
                timer.Dispose();
            };
            timer.Start();
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (this.IdNomina <= 0)
            {
                MessageBox.Show("Debes buscar primero una nómina para visualizar el recibo.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form mensajeForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(350, 220),
                Text = "Cargando Recibo",
                ControlBox = false
            };

            Label lblMensaje = new Label
            {
                Text = "Generando vista previa del recibo de nómina...",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
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
                        UC_NominaReciboExterno recibo = new UC_NominaReciboExterno(this.IdNomina);
                        recibo.Dock = DockStyle.Fill;
                        parent.Controls.Add(recibo);
                        parent.Controls.SetChildIndex(recibo, 0);
                    }
                });
            };
            timer.Start();
        }
    }
}

