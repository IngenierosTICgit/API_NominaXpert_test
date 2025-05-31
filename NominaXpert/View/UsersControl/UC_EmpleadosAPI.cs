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

namespace NominaXpert.View.UsersControl
{
    public partial class UC_EmpleadosAPI : UserControl
    {
        private readonly ApiService _apiService = new ApiService();

        public UC_EmpleadosAPI()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Encabezado centrado y en negritas para todas las columnas
            var headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;

            // NombreEmpleado ocupa más espacio
            dataGridView1.Columns["NombreEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Centrar estatus y contrato (solo datos)
            dataGridView1.Columns["EstatusEmpleado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["EstatusContrato"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Salario a la derecha (solo datos)
            dataGridView1.Columns["Salario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ToolTip para ipbMatricula
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(ipbMatricula, "Ejemplo: E-2025-0001");

            // No permitir eliminar columnas ni modificar datos
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.ReadOnly = true;
        }


        private async Task BuscarEmpleados()
        {
            string matricula = txtMatricula.Text.Trim();
            DateTime fechaInicio = DTPFechaInicioNomina.Value;
            DateTime fechaFin = DTPFechaFinNomina.Value;

            try
            {
                var empleados = await _apiService.ObtenerInfoAsync(matricula, fechaInicio, fechaFin);

                dataGridView1.Rows.Clear();

                if (empleados == null || empleados.Count == 0)
                {
                    MessageBox.Show("No se encontró información para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTotaldeRegistros.Text = "Total de Registros: 0";
                    return;
                }

                foreach (var emp in empleados)
                {
                    dataGridView1.Rows.Add(emp.matricula, emp.nombreEmpleado, emp.estatusEmpleado, emp.estatusContrato, emp.salario, emp.diasTrabajados, emp.rfc, emp.departamento);
                }
                lblTotaldeRegistros.Text = $"Total de Registros: {dataGridView1.Rows.Count-1}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la API: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTotaldeRegistros_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuscar_Click_1(object sender, EventArgs e)
        {
            await BuscarEmpleados(); 
        }
    }
}
