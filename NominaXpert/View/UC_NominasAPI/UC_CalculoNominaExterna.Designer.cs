namespace NominaXpert.View.UC_NominasAPI
{
    partial class UC_CalculoNominaExterna
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            gBoxPrestacionesLey = new GroupBox();
            dtpFechaFinNomina = new Utilities.NominaDatePicker();
            dtpFechaInicioNomina = new Utilities.NominaDatePicker();
            panel10 = new Panel();
            ipbMatricula = new FontAwesome.Sharp.IconPictureBox();
            txtMatricula = new TextBox();
            lblMatricula = new Label();
            label1 = new Label();
            panel3 = new Panel();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            label6 = new Label();
            lblDatosObligatorios = new Label();
            progressBar1 = new ProgressBar();
            gBoxDatosEmpleado = new GroupBox();
            panel2 = new Panel();
            ContratoEstatus = new TextBox();
            label3 = new Label();
            panel5 = new Panel();
            txtEstatusEmpleado = new TextBox();
            label2 = new Label();
            btnCalculoNominaExternas = new FontAwesome.Sharp.IconButton();
            panel4 = new Panel();
            txtNombreEmpleado = new TextBox();
            lblNombreCompleto = new Label();
            panel6 = new Panel();
            txtSueldoBase = new TextBox();
            lblSueldoBase = new Label();
            panel7 = new Panel();
            txtDiasLaborados = new TextBox();
            lblDiasLaborados = new Label();
            panel1 = new Panel();
            lblDescripcionCN = new Label();
            lblCalculoNominas = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            gBoxPrestacionesLey.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ipbMatricula).BeginInit();
            panel3.SuspendLayout();
            gBoxDatosEmpleado.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 125);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1262, 566);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(37, 41, 47);
            flowLayoutPanel1.Controls.Add(gBoxPrestacionesLey);
            flowLayoutPanel1.Controls.Add(gBoxDatosEmpleado);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(66, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1129, 560);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // gBoxPrestacionesLey
            // 
            gBoxPrestacionesLey.Controls.Add(dtpFechaFinNomina);
            gBoxPrestacionesLey.Controls.Add(dtpFechaInicioNomina);
            gBoxPrestacionesLey.Controls.Add(panel10);
            gBoxPrestacionesLey.Controls.Add(label1);
            gBoxPrestacionesLey.Controls.Add(panel3);
            gBoxPrestacionesLey.Controls.Add(label6);
            gBoxPrestacionesLey.Controls.Add(lblDatosObligatorios);
            gBoxPrestacionesLey.Controls.Add(progressBar1);
            gBoxPrestacionesLey.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            gBoxPrestacionesLey.ForeColor = Color.White;
            gBoxPrestacionesLey.Location = new Point(3, 3);
            gBoxPrestacionesLey.Name = "gBoxPrestacionesLey";
            gBoxPrestacionesLey.Size = new Size(1126, 236);
            gBoxPrestacionesLey.TabIndex = 9;
            gBoxPrestacionesLey.TabStop = false;
            gBoxPrestacionesLey.Text = "Selección de Período";
            // 
            // dtpFechaFinNomina
            // 
            dtpFechaFinNomina.BorderColor = Color.FromArgb(12, 215, 253);
            dtpFechaFinNomina.BorderSize = 2;
            dtpFechaFinNomina.Font = new Font("Segoe UI", 9.5F);
            dtpFechaFinNomina.Format = DateTimePickerFormat.Short;
            dtpFechaFinNomina.Location = new Point(234, 165);
            dtpFechaFinNomina.MinimumSize = new Size(0, 35);
            dtpFechaFinNomina.Name = "dtpFechaFinNomina";
            dtpFechaFinNomina.Size = new Size(163, 35);
            dtpFechaFinNomina.SkinColor = Color.FromArgb(48, 51, 59);
            dtpFechaFinNomina.TabIndex = 19;
            dtpFechaFinNomina.TextColor = Color.FromArgb(12, 215, 253);
            // 
            // dtpFechaInicioNomina
            // 
            dtpFechaInicioNomina.BorderColor = Color.FromArgb(12, 215, 253);
            dtpFechaInicioNomina.BorderSize = 2;
            dtpFechaInicioNomina.Font = new Font("Segoe UI", 9.5F);
            dtpFechaInicioNomina.Format = DateTimePickerFormat.Short;
            dtpFechaInicioNomina.Location = new Point(26, 165);
            dtpFechaInicioNomina.MinimumSize = new Size(0, 35);
            dtpFechaInicioNomina.Name = "dtpFechaInicioNomina";
            dtpFechaInicioNomina.Size = new Size(171, 35);
            dtpFechaInicioNomina.SkinColor = Color.FromArgb(48, 51, 59);
            dtpFechaInicioNomina.TabIndex = 18;
            dtpFechaInicioNomina.TextColor = Color.FromArgb(12, 215, 253);
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(37, 41, 47);
            panel10.Controls.Add(ipbMatricula);
            panel10.Controls.Add(txtMatricula);
            panel10.Controls.Add(lblMatricula);
            panel10.Location = new Point(26, 80);
            panel10.Name = "panel10";
            panel10.Size = new Size(371, 43);
            panel10.TabIndex = 14;
            // 
            // ipbMatricula
            // 
            ipbMatricula.BackColor = Color.FromArgb(37, 41, 47);
            ipbMatricula.ForeColor = Color.LightBlue;
            ipbMatricula.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            ipbMatricula.IconColor = Color.LightBlue;
            ipbMatricula.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbMatricula.IconSize = 40;
            ipbMatricula.Location = new Point(328, -1);
            ipbMatricula.Name = "ipbMatricula";
            ipbMatricula.Size = new Size(40, 40);
            ipbMatricula.TabIndex = 6;
            ipbMatricula.TabStop = false;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(126, 3);
            txtMatricula.MaxLength = 20;
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(178, 30);
            txtMatricula.TabIndex = 5;
            // 
            // lblMatricula
            // 
            lblMatricula.Dock = DockStyle.Top;
            lblMatricula.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMatricula.ForeColor = Color.White;
            lblMatricula.Location = new Point(0, 0);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(371, 29);
            lblMatricula.TabIndex = 4;
            lblMatricula.Text = "Matrícula *";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(26, 140);
            label1.Name = "label1";
            label1.Size = new Size(139, 22);
            label1.TabIndex = 17;
            label1.Text = "Fecha de inicio:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(37, 41, 47);
            panel3.Controls.Add(btnBuscar);
            panel3.Location = new Point(467, 124);
            panel3.Name = "panel3";
            panel3.Size = new Size(303, 43);
            panel3.TabIndex = 9;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.ForeColor = SystemColors.ActiveCaptionText;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.DeepSkyBlue;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 32;
            btnBuscar.Location = new Point(3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(286, 36);
            btnBuscar.TabIndex = 23;
            btnBuscar.Text = "Buscar Fecha y Matrícula";
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(234, 140);
            label6.Name = "label6";
            label6.Size = new Size(118, 22);
            label6.TabIndex = 16;
            label6.Text = "Fecha de fin:";
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.ForeColor = Color.IndianRed;
            lblDatosObligatorios.Location = new Point(26, 38);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(171, 23);
            lblDatosObligatorios.TabIndex = 13;
            lblDatosObligatorios.Text = "Datos obligatorios *";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(467, 177);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(303, 23);
            progressBar1.TabIndex = 20;
            progressBar1.Visible = false;
            // 
            // gBoxDatosEmpleado
            // 
            gBoxDatosEmpleado.Controls.Add(panel2);
            gBoxDatosEmpleado.Controls.Add(panel5);
            gBoxDatosEmpleado.Controls.Add(btnCalculoNominaExternas);
            gBoxDatosEmpleado.Controls.Add(panel4);
            gBoxDatosEmpleado.Controls.Add(panel6);
            gBoxDatosEmpleado.Controls.Add(panel7);
            gBoxDatosEmpleado.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            gBoxDatosEmpleado.ForeColor = Color.White;
            gBoxDatosEmpleado.Location = new Point(3, 245);
            gBoxDatosEmpleado.Name = "gBoxDatosEmpleado";
            gBoxDatosEmpleado.Size = new Size(1111, 236);
            gBoxDatosEmpleado.TabIndex = 10;
            gBoxDatosEmpleado.TabStop = false;
            gBoxDatosEmpleado.Text = "Datos de busquedad";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 41, 47);
            panel2.Controls.Add(ContratoEstatus);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(26, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 43);
            panel2.TabIndex = 17;
            // 
            // ContratoEstatus
            // 
            ContratoEstatus.Location = new Point(115, 3);
            ContratoEstatus.MaxLength = 20;
            ContratoEstatus.Name = "ContratoEstatus";
            ContratoEstatus.ReadOnly = true;
            ContratoEstatus.Size = new Size(189, 30);
            ContratoEstatus.TabIndex = 5;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(342, 29);
            label3.TabIndex = 4;
            label3.Text = "Contrato*";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(37, 41, 47);
            panel5.Controls.Add(txtEstatusEmpleado);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(390, 43);
            panel5.Name = "panel5";
            panel5.Size = new Size(342, 43);
            panel5.TabIndex = 16;
            // 
            // txtEstatusEmpleado
            // 
            txtEstatusEmpleado.Location = new Point(115, 3);
            txtEstatusEmpleado.MaxLength = 20;
            txtEstatusEmpleado.Name = "txtEstatusEmpleado";
            txtEstatusEmpleado.ReadOnly = true;
            txtEstatusEmpleado.Size = new Size(189, 30);
            txtEstatusEmpleado.TabIndex = 5;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(342, 29);
            label2.TabIndex = 4;
            label2.Text = "Estatus*";
            // 
            // btnCalculoNominaExternas
            // 
            btnCalculoNominaExternas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCalculoNominaExternas.BackColor = Color.Black;
            btnCalculoNominaExternas.Cursor = Cursors.Hand;
            btnCalculoNominaExternas.FlatAppearance.BorderColor = Color.Lime;
            btnCalculoNominaExternas.FlatAppearance.BorderSize = 2;
            btnCalculoNominaExternas.FlatStyle = FlatStyle.Flat;
            btnCalculoNominaExternas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalculoNominaExternas.ForeColor = Color.Azure;
            btnCalculoNominaExternas.IconChar = FontAwesome.Sharp.IconChar.CircleRight;
            btnCalculoNominaExternas.IconColor = Color.Lime;
            btnCalculoNominaExternas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCalculoNominaExternas.IconSize = 32;
            btnCalculoNominaExternas.Location = new Point(922, 171);
            btnCalculoNominaExternas.Name = "btnCalculoNominaExternas";
            btnCalculoNominaExternas.Size = new Size(148, 40);
            btnCalculoNominaExternas.TabIndex = 12;
            btnCalculoNominaExternas.Text = "Siguente";
            btnCalculoNominaExternas.TextAlign = ContentAlignment.MiddleRight;
            btnCalculoNominaExternas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCalculoNominaExternas.UseVisualStyleBackColor = false;
            btnCalculoNominaExternas.Click += btnCalculoNominaExternas_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtNombreEmpleado);
            panel4.Controls.Add(lblNombreCompleto);
            panel4.Location = new Point(5, 97);
            panel4.Name = "panel4";
            panel4.Size = new Size(752, 42);
            panel4.TabIndex = 10;
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.Location = new Point(205, 3);
            txtNombreEmpleado.MaxLength = 100;
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.ReadOnly = true;
            txtNombreEmpleado.Size = new Size(544, 30);
            txtNombreEmpleado.TabIndex = 4;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.Dock = DockStyle.Top;
            lblNombreCompleto.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreCompleto.ForeColor = Color.White;
            lblNombreCompleto.Location = new Point(0, 0);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(752, 29);
            lblNombreCompleto.TabIndex = 3;
            lblNombreCompleto.Text = "Nombre del Empleado ";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtSueldoBase);
            panel6.Controls.Add(lblSueldoBase);
            panel6.Location = new Point(763, 97);
            panel6.Name = "panel6";
            panel6.Size = new Size(346, 42);
            panel6.TabIndex = 12;
            // 
            // txtSueldoBase
            // 
            txtSueldoBase.Location = new Point(115, 3);
            txtSueldoBase.MaxLength = 100;
            txtSueldoBase.Name = "txtSueldoBase";
            txtSueldoBase.ReadOnly = true;
            txtSueldoBase.Size = new Size(192, 30);
            txtSueldoBase.TabIndex = 4;
            txtSueldoBase.Text = "  $";
            // 
            // lblSueldoBase
            // 
            lblSueldoBase.Dock = DockStyle.Top;
            lblSueldoBase.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSueldoBase.ForeColor = Color.White;
            lblSueldoBase.Location = new Point(0, 0);
            lblSueldoBase.Name = "lblSueldoBase";
            lblSueldoBase.Size = new Size(346, 29);
            lblSueldoBase.TabIndex = 3;
            lblSueldoBase.Text = "Sueldo base";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtDiasLaborados);
            panel7.Controls.Add(lblDiasLaborados);
            panel7.Location = new Point(12, 169);
            panel7.Name = "panel7";
            panel7.Size = new Size(318, 42);
            panel7.TabIndex = 13;
            // 
            // txtDiasLaborados
            // 
            txtDiasLaborados.Location = new Point(154, 0);
            txtDiasLaborados.MaxLength = 2;
            txtDiasLaborados.Name = "txtDiasLaborados";
            txtDiasLaborados.ReadOnly = true;
            txtDiasLaborados.Size = new Size(128, 30);
            txtDiasLaborados.TabIndex = 4;
            // 
            // lblDiasLaborados
            // 
            lblDiasLaborados.AutoSize = true;
            lblDiasLaborados.Dock = DockStyle.Top;
            lblDiasLaborados.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiasLaborados.ForeColor = Color.White;
            lblDiasLaborados.Location = new Point(0, 0);
            lblDiasLaborados.Name = "lblDiasLaborados";
            lblDiasLaborados.Size = new Size(142, 23);
            lblDiasLaborados.TabIndex = 3;
            lblDiasLaborados.Text = "Días Laborados: ";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDescripcionCN);
            panel1.Controls.Add(lblCalculoNominas);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 125);
            panel1.TabIndex = 2;
            // 
            // lblDescripcionCN
            // 
            lblDescripcionCN.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcionCN.ForeColor = Color.White;
            lblDescripcionCN.Location = new Point(32, 73);
            lblDescripcionCN.Name = "lblDescripcionCN";
            lblDescripcionCN.Size = new Size(743, 32);
            lblDescripcionCN.TabIndex = 4;
            lblDescripcionCN.Text = "Genera el cálculo de la nómina del empleado y permite realizar el recibo de la misma.";
            // 
            // lblCalculoNominas
            // 
            lblCalculoNominas.AutoSize = true;
            lblCalculoNominas.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCalculoNominas.ForeColor = Color.FromArgb(12, 215, 253);
            lblCalculoNominas.Location = new Point(32, 19);
            lblCalculoNominas.Name = "lblCalculoNominas";
            lblCalculoNominas.Size = new Size(253, 35);
            lblCalculoNominas.TabIndex = 1;
            lblCalculoNominas.Text = "Cálculo de Nóminas";
            // 
            // UC_CalculoNominaExterna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "UC_CalculoNominaExterna";
            Size = new Size(1262, 705);
            Load += UC_CalculoNominaExterna_Load;
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            gBoxPrestacionesLey.ResumeLayout(false);
            gBoxPrestacionesLey.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ipbMatricula).EndInit();
            panel3.ResumeLayout(false);
            gBoxDatosEmpleado.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox gBoxDatosEmpleado;
        private Panel panel2;
        private TextBox ContratoEstatus;
        private Label label3;
        private Panel panel5;
        private TextBox txtEstatusEmpleado;
        private Label label2;
        private Panel panel4;
        private TextBox txtNombreEmpleado;
        private Label lblNombreCompleto;
        private Panel panel6;
        private TextBox txtSueldoBase;
        private Label lblSueldoBase;
        private GroupBox gBoxPrestacionesLey;
        private Utilities.NominaDatePicker dtpFechaFinNomina;
        private Utilities.NominaDatePicker dtpFechaInicioNomina;
        private Panel panel10;
        private FontAwesome.Sharp.IconPictureBox ipbMatricula;
        private TextBox txtMatricula;
        private Label lblMatricula;
        private Label label1;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Label label6;
        private FontAwesome.Sharp.IconButton btnCalculoNominaExternas;
        private Label lblDatosObligatorios;
        private Panel panel7;
        private TextBox txtDiasLaborados;
        private Label lblDiasLaborados;
        private Panel panel1;
        private Label lblDescripcionCN;
        private Label lblCalculoNominas;
        private ProgressBar progressBar1;
    }
}
