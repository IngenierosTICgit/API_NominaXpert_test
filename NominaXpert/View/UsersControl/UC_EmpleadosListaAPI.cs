using NominaXpert.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaXpert.View.UsersControl
{
    public partial class UC_EmpleadosListaAPI : UserControl
    {
        private readonly ApiService _apiService = new ApiService();
        private List<EmpleadosRH> _empleadosList;
        private LoadingForm _loadingForm;

        public UC_EmpleadosListaAPI()
        {
            InitializeComponent();
            _apiService = new ApiService();
            ConfigurarDataGridView();
            _loadingForm = new LoadingForm();
        }

        private void ConfigurarDataGridView()
        {
            // No permitir eliminar columnas ni modificar datos
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.ReadOnly = true;

            // Encabezado centrado y en negritas para todas las columnas
            var headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;

            // Configurar el estilo de las celdas
            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.FromArgb(45, 45, 48);
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.White;
            cellStyle.SelectionBackColor = Color.Teal;
            cellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle = cellStyle;

            // Configurar columnas específicas
            dataGridView1.Columns["matricula"].Width = 120;
            dataGridView1.Columns["nombreEmpleado"].Width = 250;
            dataGridView1.Columns["departamento"].Width = 150;
            dataGridView1.Columns["puesto"].Width = 200;
            dataGridView1.Columns["estatusEmpleado"].Width = 120;
            dataGridView1.Columns["estatusContrato"].Width = 120;
            dataGridView1.Columns["salario"].Width = 100;
            dataGridView1.Columns["fechaIngreso"].Width = 120;
            dataGridView1.Columns["fechaBaja"].Width = 120;

            // Centrar estatus y contrato
            dataGridView1.Columns["estatusEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["estatusContrato"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Salario a la derecha con formato de moneda
            dataGridView1.Columns["salario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["salario"].DefaultCellStyle.Format = "C0";

            // Formato de fechas
            dataGridView1.Columns["fechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["fechaBaja"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // ToolTip para ipbMatricula
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(ipbMatricula, "Ejemplo: E-2025-0001");

            // Configurar el estilo de la tabla
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 48);
            dataGridView1.GridColor = Color.DarkCyan;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.RowTemplate.Height = 35;
        }

        private void UC_EmpleadosListaAPI_Load(object sender, EventArgs e)
        {
            CargarTodosEmpleadosAsync();
        }

        private async Task CargarTodosEmpleadosAsync()
        {
            try
            {
                _loadingForm.Show();
                _loadingForm.UpdateMessage("Cargando datos de empleados...");
                Application.DoEvents();

                // Llamada a la API para obtener todos los empleados
                _empleadosList = await _apiService.ObtenerTodosEmpleadosAsync();

                // Asignar la lista al DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _empleadosList;

                // Actualizar etiqueta con total registros
                lblTotaldeRegistros.Text = $"Total de Registros: {_empleadosList.Count}";

                _loadingForm.Hide();
                MessageBox.Show("Datos cargados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingForm.Hide();
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarEmpleados()
        {
            try
            {
                _loadingForm.Show();
                _loadingForm.UpdateMessage("Filtrando empleados...");
                Application.DoEvents();

                string matricula = txtMatricula.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(matricula))
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = _empleadosList;
                }
                else
                {
                    var empleadosFiltrados = _empleadosList.Where(e => 
                        e.matricula.ToLower().Contains(matricula)).ToList();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = empleadosFiltrados;
                }

                lblTotaldeRegistros.Text = $"Total de Registros: {((List<EmpleadosRH>)dataGridView1.DataSource).Count}";
                
                _loadingForm.Hide();
                MessageBox.Show("Filtrado completado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _loadingForm.Hide();
                MessageBox.Show($"Error al filtrar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarEmpleados();
        }

        private void bntLimpiarfiltrosfechas_Click(object sender, EventArgs e)
        {
            txtMatricula.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _empleadosList;
            lblTotaldeRegistros.Text = $"Total de Registros: {_empleadosList.Count}";
        }
    }

    public class LoadingForm : Form
    {
        private Label lblMessage;
        private ProgressBar progressBar;

        public LoadingForm()
        {
            InitializeLoadingForm();
        }

        private void InitializeLoadingForm()
        {
            this.Size = new Size(300, 100);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.TopMost = true;

            lblMessage = new Label
            {
                Text = "Cargando...",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };

            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Height = 20,
                Dock = DockStyle.Bottom,
                Margin = new Padding(10)
            };

            this.Controls.Add(lblMessage);
            this.Controls.Add(progressBar);
        }

        public void UpdateMessage(string message)
        {
            if (lblMessage.InvokeRequired)
            {
                lblMessage.Invoke(new Action(() => lblMessage.Text = message));
            }
            else
            {
                lblMessage.Text = message;
            }
        }
    }
}
