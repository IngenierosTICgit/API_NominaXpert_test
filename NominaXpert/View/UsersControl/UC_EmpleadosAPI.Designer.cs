namespace NominaXpert.View.UsersControl
{
    partial class UC_EmpleadosAPI
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            matricula = new DataGridViewTextBoxColumn();
            NombreEmpleado = new DataGridViewTextBoxColumn();
            EstatusEmpleado = new DataGridViewTextBoxColumn();
            EstatusContrato = new DataGridViewTextBoxColumn();
            Salario = new DataGridViewTextBoxColumn();
            DiasTrabajados = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            bntLimpiarfiltrosfechas = new Button();
            label6 = new Label();
            label5 = new Label();
            DTPFechaFinNomina = new NominaXpertCore.Utilities.NominaDatePicker();
            DTPFechaInicioNomina = new NominaXpertCore.Utilities.NominaDatePicker();
            panel3 = new Panel();
            ipbMatricula = new FontAwesome.Sharp.IconPictureBox();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            lblMatricula = new Label();
            txtMatricula = new TextBox();
            panel1 = new Panel();
            lblTotaldeRegistros = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ipbMatricula).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 96F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 204);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1262, 490);
            tableLayoutPanel1.TabIndex = 23;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Cyan;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { matricula, NombreEmpleado, EstatusEmpleado, EstatusContrato, Salario, DiasTrabajados });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.DarkCyan;
            dataGridView1.Location = new Point(40, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.Size = new Size(1205, 484);
            dataGridView1.TabIndex = 0;
            // 
            // matricula
            // 
            matricula.HeaderText = "Matricula";
            matricula.MinimumWidth = 6;
            matricula.Name = "matricula";
            matricula.ReadOnly = true;
            matricula.Width = 125;
            // 
            // NombreEmpleado
            // 
            NombreEmpleado.HeaderText = "Nombre empleado";
            NombreEmpleado.MinimumWidth = 6;
            NombreEmpleado.Name = "NombreEmpleado";
            NombreEmpleado.ReadOnly = true;
            NombreEmpleado.Width = 125;
            // 
            // EstatusEmpleado
            // 
            EstatusEmpleado.HeaderText = "Estatus Empleado";
            EstatusEmpleado.MinimumWidth = 6;
            EstatusEmpleado.Name = "EstatusEmpleado";
            EstatusEmpleado.ReadOnly = true;
            EstatusEmpleado.Width = 125;
            // 
            // EstatusContrato
            // 
            EstatusContrato.HeaderText = "Contrato";
            EstatusContrato.MinimumWidth = 6;
            EstatusContrato.Name = "EstatusContrato";
            EstatusContrato.ReadOnly = true;
            EstatusContrato.Width = 125;
            // 
            // Salario
            // 
            Salario.HeaderText = "Salario";
            Salario.MinimumWidth = 6;
            Salario.Name = "Salario";
            Salario.ReadOnly = true;
            Salario.Width = 125;
            // 
            // DiasTrabajados
            // 
            DiasTrabajados.HeaderText = "Dias Trabajados";
            DiasTrabajados.MinimumWidth = 6;
            DiasTrabajados.Name = "DiasTrabajados";
            DiasTrabajados.ReadOnly = true;
            DiasTrabajados.Width = 125;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 41, 47);
            panel2.Controls.Add(bntLimpiarfiltrosfechas);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(DTPFechaFinNomina);
            panel2.Controls.Add(DTPFechaInicioNomina);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 112);
            panel2.Name = "panel2";
            panel2.Size = new Size(1262, 92);
            panel2.TabIndex = 22;
            // 
            // bntLimpiarfiltrosfechas
            // 
            bntLimpiarfiltrosfechas.BackColor = Color.Black;
            bntLimpiarfiltrosfechas.FlatStyle = FlatStyle.Popup;
            bntLimpiarfiltrosfechas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bntLimpiarfiltrosfechas.ForeColor = Color.White;
            bntLimpiarfiltrosfechas.Location = new Point(949, 11);
            bntLimpiarfiltrosfechas.Name = "bntLimpiarfiltrosfechas";
            bntLimpiarfiltrosfechas.Size = new Size(130, 29);
            bntLimpiarfiltrosfechas.TabIndex = 24;
            bntLimpiarfiltrosfechas.Text = "Limpiar filtros";
            bntLimpiarfiltrosfechas.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(770, 18);
            label6.Name = "label6";
            label6.Size = new Size(118, 22);
            label6.TabIndex = 22;
            label6.Text = "Fecha de fin:";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(577, 18);
            label5.Name = "label5";
            label5.Size = new Size(134, 22);
            label5.TabIndex = 21;
            label5.Text = "Fecha de inicio:";
            // 
            // DTPFechaFinNomina
            // 
            DTPFechaFinNomina.BorderColor = Color.FromArgb(12, 215, 253);
            DTPFechaFinNomina.BorderSize = 2;
            DTPFechaFinNomina.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DTPFechaFinNomina.Format = DateTimePickerFormat.Short;
            DTPFechaFinNomina.Location = new Point(770, 43);
            DTPFechaFinNomina.MinimumSize = new Size(0, 35);
            DTPFechaFinNomina.Name = "DTPFechaFinNomina";
            DTPFechaFinNomina.Size = new Size(147, 35);
            DTPFechaFinNomina.SkinColor = Color.FromArgb(48, 51, 59);
            DTPFechaFinNomina.TabIndex = 20;
            DTPFechaFinNomina.TextColor = Color.FromArgb(12, 215, 253);
            // 
            // DTPFechaInicioNomina
            // 
            DTPFechaInicioNomina.BorderColor = Color.FromArgb(12, 215, 253);
            DTPFechaInicioNomina.BorderSize = 2;
            DTPFechaInicioNomina.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DTPFechaInicioNomina.Format = DateTimePickerFormat.Short;
            DTPFechaInicioNomina.Location = new Point(583, 43);
            DTPFechaInicioNomina.MinimumSize = new Size(0, 35);
            DTPFechaInicioNomina.Name = "DTPFechaInicioNomina";
            DTPFechaInicioNomina.Size = new Size(147, 35);
            DTPFechaInicioNomina.SkinColor = Color.FromArgb(48, 51, 59);
            DTPFechaInicioNomina.TabIndex = 19;
            DTPFechaInicioNomina.TextColor = Color.FromArgb(12, 215, 253);
            // 
            // panel3
            // 
            panel3.Controls.Add(ipbMatricula);
            panel3.Controls.Add(lblMatricula);
            panel3.Controls.Add(txtMatricula);
            panel3.Location = new Point(40, 13);
            panel3.Name = "panel3";
            panel3.Size = new Size(509, 73);
            panel3.TabIndex = 1;
            // 
            // ipbMatricula
            // 
            ipbMatricula.BackColor = Color.FromArgb(37, 41, 47);
            ipbMatricula.ForeColor = Color.LightBlue;
            ipbMatricula.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            ipbMatricula.IconColor = Color.LightBlue;
            ipbMatricula.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbMatricula.IconSize = 40;
            ipbMatricula.Location = new Point(300, 25);
            ipbMatricula.Name = "ipbMatricula";
            ipbMatricula.Size = new Size(40, 40);
            ipbMatricula.TabIndex = 25;
            ipbMatricula.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ActiveCaptionText;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.DeepSkyBlue;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 32;
            btnBuscar.Location = new Point(949, 46);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(121, 36);
            btnBuscar.TabIndex = 24;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // lblMatricula
            // 
            lblMatricula.Dock = DockStyle.Top;
            lblMatricula.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMatricula.ForeColor = Color.White;
            lblMatricula.Location = new Point(0, 0);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(509, 29);
            lblMatricula.TabIndex = 5;
            lblMatricula.Text = "Matrícula*";
            // 
            // txtMatricula
            // 
            txtMatricula.BackColor = Color.White;
            txtMatricula.ForeColor = Color.Black;
            txtMatricula.Location = new Point(15, 32);
            txtMatricula.MaxLength = 20;
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(263, 27);
            txtMatricula.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotaldeRegistros);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 112);
            panel1.TabIndex = 21;
            // 
            // lblTotaldeRegistros
            // 
            lblTotaldeRegistros.AutoSize = true;
            lblTotaldeRegistros.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotaldeRegistros.ForeColor = Color.FromArgb(12, 215, 253);
            lblTotaldeRegistros.Location = new Point(714, 64);
            lblTotaldeRegistros.Name = "lblTotaldeRegistros";
            lblTotaldeRegistros.Size = new Size(163, 23);
            lblTotaldeRegistros.TabIndex = 7;
            lblTotaldeRegistros.Text = "Total de Registros: ";
            lblTotaldeRegistros.Click += lblTotaldeRegistros_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 63);
            label2.Name = "label2";
            label2.Size = new Size(563, 46);
            label2.TabIndex = 3;
            label2.Text = "Visualiza la información consumida de la API de RH";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(12, 215, 253);
            label1.Location = new Point(21, 17);
            label1.Name = "label1";
            label1.Size = new Size(336, 35);
            label1.TabIndex = 0;
            label1.Text = "API recibida de Empleados";
            // 
            // UC_EmpleadosAPI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_EmpleadosAPI";
            Size = new Size(1262, 755);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ipbMatricula).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Panel panel1;
        private Label lblTotaldeRegistros;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn matricula;
        private DataGridViewTextBoxColumn NombreEmpleado;
        private DataGridViewTextBoxColumn EstatusEmpleado;
        private DataGridViewTextBoxColumn EstatusContrato;
        private DataGridViewTextBoxColumn Salario;
        private DataGridViewTextBoxColumn DiasTrabajados;
        private Panel panel3;
        private FontAwesome.Sharp.IconPictureBox ipbMatricula;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Label lblMatricula;
        private TextBox txtMatricula;
        private Label label6;
        private Label label5;
        private NominaXpertCore.Utilities.NominaDatePicker DTPFechaFinNomina;
        private NominaXpertCore.Utilities.NominaDatePicker DTPFechaInicioNomina;
        private Button bntLimpiarfiltrosfechas;
    }
}
