using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaXpert.View.UC_NominasAPI
{
    public partial class UC_PercepcionesExternas : UserControl
    {
        public int IdNomina { get; set; }

        public UC_PercepcionesExternas()
        {
            InitializeComponent();
        }

        private void UC_PercepcionesExternas_Load(object sender, EventArgs e)
        {
            if (IdNomina <= 0)
            {
                MessageBox.Show("Error: No se ha especificado una nómina válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Aquí puedes cargar los datos de la nómina usando el IdNomina
            CargarDatosNomina();
        }

        private void CargarDatosNomina()
        {
            try
            {
                // TODO: Implementar la carga de datos de la nómina
                // Por ejemplo:
                // var nominaExController = new NominaExController();
                // var datosNomina = nominaExController.ObtenerNominaPorId(IdNomina);
                // Mostrar los datos en la interfaz
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de la nómina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
