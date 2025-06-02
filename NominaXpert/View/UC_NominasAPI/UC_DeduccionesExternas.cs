using NominaXpertCore.Controller;
using NominaXpertCore.Model;
using NominaXpertCore.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_DeduccionesExternas : UserControl
    {
        public int IdNomina { get; set; }

        private readonly DeduccionController _deduccionController;
        private readonly DetalleNominaController _detalleNominaController;
        private readonly Dictionary<int, string> _tiposDeducciones;
        private int idDeduccionEditar = -1;

        public UC_DeduccionesExternas(int idNomina)
        {
            if (idNomina <= 0)
            {
                MessageBox.Show("ID de nómina externa inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeComponent();
            this.IdNomina = idNomina;
            txtIdNomina.Text = IdNomina.ToString();

            _deduccionController = new DeduccionController();
            _detalleNominaController = new DetalleNominaController();

            _tiposDeducciones = new Dictionary<int, string>
            {
                { 1, "ISR" },
                { 2, "IMSS" },
                { 3, "INFONAVIT" },
                { 4, "FALTAS" },
                { 5, "RETARDOS" },
                { 6, "PENSION ALIMENTICIA" },
                { 7, "OTROS" }
            };

            PoblaComboTipo();
            CargarDeducciones();
        }

        private void PoblaComboTipo()
        {
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.DataSource = new BindingSource(_tiposDeducciones, null);
            cboTipo.DisplayMember = "Value";
            cboTipo.ValueMember = "Key";
            cboTipo.SelectedValue = 1;

            if (cboTipo.SelectedValue == null && cboTipo.Items.Count > 0)
                cboTipo.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvDeducciones.ReadOnly = true;
            dgvDeducciones.AllowUserToDeleteRows = false;
        }

        public void CargarDeducciones()
        {
            try
            {
                ConfigurarDataGridView();
                dgvDeducciones.Rows.Clear();

                var deducciones = _deduccionController.ObtenerDeduccionesPorNomina(this.IdNomina);

                foreach (var d in deducciones)
                {
                    dgvDeducciones.Rows.Add(
                        d.Id,
                        d.IdNomina,
                        _tiposDeducciones[d.IdTipo],
                        d.Monto
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar deducciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void txtIdNomina_TextChanged(object sender, EventArgs e)
        {
            txtIdNomina.Text = IdNomina.ToString();
        }

        private void LimpiarCampos()
        {
            txtMonto.Clear();
            cboTipo.SelectedValue = 1;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.ObtenerIdUsuarioActual();

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0 || monto != Math.Round(monto, 2))
            {
                MessageBox.Show("Ingresa un monto válido (positivo, máximo 2 decimales).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var deduccion = new Deduccion
            {
                IdNomina = this.IdNomina,
                IdTipo = Convert.ToInt32(cboTipo.SelectedValue),
                Monto = monto
            };

            try
            {
                _deduccionController.RegistrarDeduccion(deduccion, idUsuario);

                var detalle = new DetalleNomina
                {
                    IdNomina = this.IdNomina,
                    Descripcion = "Deducción registrada desde nómina externa",
                    Monto = monto,
                    Tipo = "Deducción"
                };

                _detalleNominaController.RegistrarDetalleNomina(detalle);

                MessageBox.Show("Deducción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarDeducciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la deducción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.ObtenerIdUsuarioActual();

            if (dgvDeducciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una deducción para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvDeducciones.SelectedRows[0].Cells["Id"].Value);
            var confirm = MessageBox.Show("¿Estás seguro de eliminar esta deducción?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _deduccionController.EliminarDeduccion(id, IdNomina, idUsuario);
                    MessageBox.Show("Deducción eliminada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDeducciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.ObtenerIdUsuarioActual();

            if (btnModificar.Text == "Modificar")
            {
                if (dgvDeducciones.SelectedRows.Count > 0)
                {
                    var row = dgvDeducciones.SelectedRows[0];

                    if (row.Cells["Id"].Value != null && row.Cells["Tipo"].Value != null && row.Cells["Monto"].Value != null)
                    {
                        idDeduccionEditar = Convert.ToInt32(row.Cells["Id"].Value);
                        var tipo = row.Cells["Tipo"].Value.ToString();
                        var monto = Convert.ToDecimal(row.Cells["Monto"].Value);

                        cboTipo.SelectedIndex = cboTipo.FindStringExact(tipo);
                        txtMonto.Text = monto.ToString();

                        btnModificar.Text = "Guardar Cambios";
                        btnGuardar.Visible = false;
                        MessageBox.Show("Modifica el monto o tipo y presiona 'Guardar Cambios' para actualizar.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una deducción para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (idDeduccionEditar <= 0)
                {
                    MessageBox.Show("No hay deducción seleccionada para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Ingresa un monto válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var deduccion = new Deduccion
                {
                    Id = idDeduccionEditar,
                    IdNomina = this.IdNomina,
                    IdTipo = Convert.ToInt32(cboTipo.SelectedValue),
                    Monto = monto
                };

                try
                {
                    var rowsAffected = _deduccionController.ActualizarDeduccion(deduccion, idUsuario);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Deducción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDeducciones();
                        LimpiarCampos();

                        btnGuardar.Visible = true;
                        btnModificar.Text = "Modificar";
                        idDeduccionEditar = -1;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la deducción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la deducción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            Form msg = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(350, 220),
                Text = "Información del sistema",
                ControlBox = false
            };

            Label lbl = new Label
            {
                Text = "Regresando a Percepciones...",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            msg.Controls.Add(lbl);
            msg.Show();

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                msg.Invoke((MethodInvoker)(() => msg.Close()));
                this.Invoke((MethodInvoker)delegate
                {
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Remove(this);
                        var percepciones = new UC_PercepcionesExternas(IdNomina);
                        percepciones.Dock = DockStyle.Fill;
                        parent.Controls.Add(percepciones);
                        parent.Controls.SetChildIndex(percepciones, 0);
                    }
                });
            };
            timer.Start();
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            // Crear un formulario de notificación temporal
            Form mensajeForm = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(350, 220),
                Text = "Información del sistema",
                ControlBox = false // Evita que se cierre manualmente
            };

            Label lblMensaje = new Label
            {
                Text = "Generando Recibo de Nómina del Empleado...",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            mensajeForm.Controls.Add(lblMensaje);
            mensajeForm.Show();

            // Configurar temporizador para cerrar mensaje y cambiar de UC
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                mensajeForm.Invoke((MethodInvoker)(() => mensajeForm.Close()));

                // Cambiar a UC_NominaReciboExterno en el hilo principal
                this.Invoke((MethodInvoker)delegate
                {
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Remove(this);

                        // Redirige al recibo de nómina externa
                        UC_NominaReciboExterno ucRecibo = new UC_NominaReciboExterno(this.IdNomina);
                        ucRecibo.Dock = DockStyle.Fill;

                        parent.Controls.Add(ucRecibo);
                        parent.Controls.SetChildIndex(ucRecibo, 0); // Mostrar al frente
                    }
                });
            };
            timer.Start();
        }
    }
}
