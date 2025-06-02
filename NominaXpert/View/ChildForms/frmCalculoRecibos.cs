using FontAwesome.Sharp;
using NominaXpertCore.Controller;
using NominaXpert.Utilities;
using NominaXpert.View.UC_NominasAPI;
using NominaXpert.View.UsersControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaXpert.View.Forms
{
    public partial class frmCalculoRecibos : Form
    {
        public int IdNomina { get; set; }
        public frmCalculoRecibos()
        {
            InitializeComponent();
            Formas.InitializePanel(panelBar); // Inicializa el borde izquierdo en el panel
            CargarUserControlInicial();
            ConfigurarPermisos();
        }


        private void CargarUserControlInicial()
        {
            UC_NominaCalculo1 uc = new UC_NominaCalculo1();
            addUsersControl(uc); // Usamos el mismo método que para los botones

        }
        private void addUsersControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnCalculoNomina_Click(object sender, EventArgs e)
        {
            UC_NominaCalculo1 uc = new UC_NominaCalculo1();
            Utilities.Formas.ActivateButton(sender, Formas.RGBColors.ChangeColor);
            addUsersControl(uc);
        }

        private void btnEstatusNomina_Click(object sender, EventArgs e)
        {
            UC_NominaEditar uce = new UC_NominaEditar(this.IdNomina);
            Utilities.Formas.ActivateButton(sender, Formas.RGBColors.ChangeColor);
            addUsersControl(uce);
        }
        private void ConfigurarPermisos()
        {
            var controller = new UsuariosController();
            btnCalculoNomina.Enabled = controller.TienePermiso("NOM_ADD");
            btnEstatusNomina.Enabled = controller.TienePermiso("NOM_EDIT");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            UC_CalculoNominaExterna uceext = new UC_CalculoNominaExterna();
            Utilities.Formas.ActivateButton(sender, Formas.RGBColors.ChangeColor);
            addUsersControl(uceext);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            UC_EditarNominaAPI a = new UC_EditarNominaAPI();
            Utilities.Formas.ActivateButton(sender, Formas.RGBColors.ChangeColor);
            addUsersControl(a);
        }
    }

}
