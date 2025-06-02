using NominaXpertCore.Controller;
using NominaXpertCore.Model;
using NominaXpertCore.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_PercepcionesExternas : UserControl
    {
        public int IdNomina { get; set; }
        private int idBonificacionEditar = -1;

        private readonly BonificacionController _bonificacionController;
        private readonly DetalleNominaController _detalleNominaController;
        private readonly Dictionary<int, string> _tiposPercepciones;

        public UC_PercepcionesExternas(int idNomina)
        {
            if (idNomina <= 0)
            {
                MessageBox.Show("ID de nómina externa inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeComponent();
            this.IdNomina = idNomina;

            _bonificacionController = new BonificacionController();
            _detalleNominaController = new DetalleNominaController();
            _tiposPercepciones = new Dictionary<int, string>
            {
                { 1, "Horas Extras" },
                { 2, "Comisión" },
                { 3, "Incentivo" },
                { 4, "Asistencia" },
                { 5, "Puntualidad" },
                { 6, "Retroactivo" },
                { 7, "Otros" }
            };

            PoblaComboTipo();
            CargarBonificacionesExternas();
        }

        private void PoblaComboTipo()
        {
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.DataSource = new BindingSource(_tiposPercepciones, null);
            cboTipo.DisplayMember = "Value";
            cboTipo.ValueMember = "Key";
            cboTipo.SelectedValue = 1;

            if (cboTipo.SelectedValue == null && cboTipo.Items.Count > 0)
                cboTipo.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvPercepciones.ReadOnly = true;
            dgvPercepciones.AllowUserToDeleteRows = false;
        }

        public void CargarBonificacionesExternas()
        {
            try
            {
                ConfigurarDataGridView();
                dgvPercepciones.Rows.Clear();
                var bonificaciones = _bonificacionController.ObtenerBonificacionesPorNomina(IdNomina);

                foreach (var b in bonificaciones)
                {
                    dgvPercepciones.Rows.Add(
                        b.Id,
                        b.IdNomina,
                        _tiposPercepciones[b.IdTipo],
                        b.Monto
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar percepciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtMonto.Clear();
            cboTipo.SelectedValue = 1;
        }

        private void UC_PercepcionesExternas_Load(object sender, EventArgs e)
        {
            // Ya se carga desde el constructor
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.ObtenerIdUsuarioActual();

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0 || monto != Math.Round(monto, 2))
            {
                MessageBox.Show("Ingresa un monto válido (positivo, máximo 2 decimales).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bonificacion = new Bonificacion
            {
                IdNomina = this.IdNomina,
                IdTipo = Convert.ToInt32(cboTipo.SelectedValue),
                Monto = monto
            };

            try
            {
                _bonificacionController.RegistrarBonificacion(bonificacion, idUsuario);

                var detalle = new DetalleNomina
                {
                    IdNomina = this.IdNomina,
                    Descripcion = "Percepción registrada desde nómina externa",
                    Monto = monto,
                    Tipo = "Ingreso"
                };

                _detalleNominaController.RegistrarDetalleNomina(detalle);

                MessageBox.Show("Percepción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarBonificacionesExternas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la percepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUsuario = UsuarioSesion.ObtenerIdUsuarioActual();

            if (dgvPercepciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una percepción para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvPercepciones.SelectedRows[0].Cells["Id"].Value);
            var confirm = MessageBox.Show("¿Estás seguro de eliminar esta percepción?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _bonificacionController.EliminarBonificacion(id, IdNomina, idUsuario);
                    MessageBox.Show("Percepción eliminada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBonificacionesExternas();
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
                // MODO: Seleccionar para editar
                if (dgvPercepciones.SelectedRows.Count > 0)
                {
                    var row = dgvPercepciones.SelectedRows[0];

                    if (row.Cells["Id"].Value != null && row.Cells["Tipo"].Value != null && row.Cells["Monto"].Value != null)
                    {
                        idBonificacionEditar = Convert.ToInt32(row.Cells["Id"].Value);
                        var tipo = row.Cells["Tipo"].Value.ToString();
                        var monto = Convert.ToDecimal(row.Cells["Monto"].Value);

                        // Cargar valores en los campos
                        cboTipo.SelectedIndex = cboTipo.FindStringExact(tipo);
                        txtMonto.Text = monto.ToString();

                        // Cambiar estado del botón
                        btnModificar.Text = "Guardar Cambios";
                        btnGuardar.Visible = false;

                        MessageBox.Show("Modifica el monto o tipo y presiona 'Guardar Cambios' para actualizar.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una percepción para modificar.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // MODO: Guardar Cambios
                if (idBonificacionEditar <= 0)
                {
                    MessageBox.Show("No hay percepción seleccionada para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Ingresa un monto válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var bonificacion = new Bonificacion
                {
                    Id = idBonificacionEditar,
                    IdNomina = this.IdNomina,
                    IdTipo = Convert.ToInt32(cboTipo.SelectedValue),
                    Monto = monto
                };

                try
                {
                    var rowsAffected = _bonificacionController.ActualizarBonificacion(bonificacion, idUsuario);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Percepción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarBonificacionesExternas();
                        LimpiarCampos();

                        // Restaurar botones
                        btnModificar.Text = "Modificar";
                        btnGuardar.Visible = true;
                        idBonificacionEditar = -1;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la percepción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la percepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSiguientePerExt_Click(object sender, EventArgs e)
        {
            // Crear un formulario de notificación temporal
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
                Text = "Guardando Percepciones...",
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            mensajeForm.Controls.Add(lblMensaje);
            mensajeForm.Show();

            // Temporizador para cerrar el mensaje y cambiar de UserControl
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, ev) =>
            {
                timer.Stop();
                mensajeForm.Invoke((MethodInvoker)delegate { mensajeForm.Close(); });

                // Cambiar UC en el hilo principal
                this.Invoke((MethodInvoker)delegate
                {
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Remove(this);

                        // Siguiente pantalla: UC_DeduccionesExternas (ajústalo si tiene otro nombre)
                        var ucDeducciones = new UC_DeduccionesExternas(); //this.IdNomina
                        ucDeducciones.Dock = DockStyle.Fill;

                        parent.Controls.Add(ucDeducciones);
                        parent.Controls.SetChildIndex(ucDeducciones, 0); // Poner al frente
                    }
                });
            };
            timer.Start();
        }

        private void txtIdNomina_TextChanged(object sender, EventArgs e)
        {
            txtIdNomina.Text = this.IdNomina.ToString();
        }
    }
}
