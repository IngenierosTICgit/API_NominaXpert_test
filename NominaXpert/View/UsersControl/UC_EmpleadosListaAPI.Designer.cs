namespace NominaXpert.View.UsersControl
{
    partial class UC_EmpleadosListaAPI
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
            Departamento = new DataGridViewTextBoxColumn();
            Puesto = new DataGridViewTextBoxColumn();
            EstatusEmpleado = new DataGridViewTextBoxColumn();
            EstatusContrato = new DataGridViewTextBoxColumn();
            Salario = new DataGridViewTextBoxColumn();
            FechaIngreso = new DataGridViewTextBoxColumn();
            FechaBaja = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            bntLimpiarfiltrosfechas = new Button();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            ipbMatricula = new FontAwesome.Sharp.IconPictureBox();
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
            tableLayoutPanel1.TabIndex = 26;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { 
                matricula, 
                NombreEmpleado, 
                Departamento, 
                Puesto, 
                EstatusEmpleado, 
                EstatusContrato, 
                Salario, 
                FechaIngreso, 
                FechaBaja 
            });
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.ScrollBars = ScrollBars.Both;
            // 
            // matricula
            // 
            matricula.DataPropertyName = "matricula";
            matricula.HeaderText = "Matrícula";
            matricula.MinimumWidth = 6;
            matricula.Name = "matricula";
            matricula.ReadOnly = true;
            matricula.Width = 120;
            // 
            // NombreEmpleado
            // 
            NombreEmpleado.DataPropertyName = "nombreEmpleado";
            NombreEmpleado.HeaderText = "Nombre Empleado";
            NombreEmpleado.MinimumWidth = 6;
            NombreEmpleado.Name = "NombreEmpleado";
            NombreEmpleado.ReadOnly = true;
            NombreEmpleado.Width = 250;
            // 
            // Departamento
            // 
            Departamento.DataPropertyName = "departamento";
            Departamento.HeaderText = "Departamento";
            Departamento.MinimumWidth = 6;
            Departamento.Name = "Departamento";
            Departamento.ReadOnly = true;
            Departamento.Width = 150;
            // 
            // Puesto
            // 
            Puesto.DataPropertyName = "puesto";
            Puesto.HeaderText = "Puesto";
            Puesto.MinimumWidth = 6;
            Puesto.Name = "Puesto";
            Puesto.ReadOnly = true;
            Puesto.Width = 200;
            // 
            // EstatusEmpleado
            // 
            EstatusEmpleado.DataPropertyName = "estatusEmpleado";
            EstatusEmpleado.HeaderText = "Estatus Empleado";
            EstatusEmpleado.MinimumWidth = 6;
            EstatusEmpleado.Name = "EstatusEmpleado";
            EstatusEmpleado.ReadOnly = true;
            EstatusEmpleado.Width = 120;
            // 
            // EstatusContrato
            // 
            EstatusContrato.DataPropertyName = "estatusContrato";
            EstatusContrato.HeaderText = "Contrato";
            EstatusContrato.MinimumWidth = 6;
            EstatusContrato.Name = "EstatusContrato";
            EstatusContrato.ReadOnly = true;
            EstatusContrato.Width = 120;
            // 
            // Salario
            // 
            Salario.DataPropertyName = "salario";
            Salario.HeaderText = "Salario";
            Salario.MinimumWidth = 6;
            Salario.Name = "Salario";
            Salario.ReadOnly = true;
            Salario.Width = 100;
            // 
            // FechaIngreso
            // 
            FechaIngreso.DataPropertyName = "fechaIngreso";
            FechaIngreso.HeaderText = "Fecha de Ingreso";
            FechaIngreso.MinimumWidth = 6;
            FechaIngreso.Name = "FechaIngreso";
            FechaIngreso.ReadOnly = true;
            FechaIngreso.Width = 150;
            // 
            // FechaBaja
            // 
            FechaBaja.DataPropertyName = "fechaBaja";
            FechaBaja.HeaderText = "Fecha de Baja";
            FechaBaja.MinimumWidth = 6;
            FechaBaja.Name = "FechaBaja";
            FechaBaja.ReadOnly = true;
            FechaBaja.Width = 150;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 41, 47);
            panel2.Controls.Add(bntLimpiarfiltrosfechas);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 112);
            panel2.Name = "panel2";
            panel2.Size = new Size(1262, 92);
            panel2.TabIndex = 25;
            // 
            // bntLimpiarfiltrosfechas
            // 
            bntLimpiarfiltrosfechas.BackColor = Color.Black;
            bntLimpiarfiltrosfechas.FlatStyle = FlatStyle.Popup;
            bntLimpiarfiltrosfechas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bntLimpiarfiltrosfechas.ForeColor = Color.White;
            bntLimpiarfiltrosfechas.Location = new Point(564, 15);
            bntLimpiarfiltrosfechas.Name = "bntLimpiarfiltrosfechas";
            bntLimpiarfiltrosfechas.Size = new Size(130, 29);
            bntLimpiarfiltrosfechas.TabIndex = 24;
            bntLimpiarfiltrosfechas.Text = "Limpiar filtros";
            bntLimpiarfiltrosfechas.UseVisualStyleBackColor = false;
            bntLimpiarfiltrosfechas.Click += bntLimpiarfiltrosfechas_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ActiveCaptionText;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.DeepSkyBlue;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 32;
            btnBuscar.Location = new Point(564, 50);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(121, 36);
            btnBuscar.TabIndex = 24;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
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
            panel1.TabIndex = 24;
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
            // 
            // label2
            // 
            label2.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 63);
            label2.Name = "label2";
            label2.Size = new Size(563, 46);
            label2.TabIndex = 3;
            label2.Text = "Visualiza la información de toda la lista de empleados";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(12, 215, 253);
            label1.Location = new Point(21, 17);
            label1.Name = "label1";
            label1.Size = new Size(298, 35);
            label1.TabIndex = 0;
            label1.Text = "Lista de Empleados API";
            // 
            // UC_EmpleadosListaAPI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_EmpleadosListaAPI";
            Size = new Size(1262, 755);
            Load += UC_EmpleadosListaAPI_Load;
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
        private Button bntLimpiarfiltrosfechas;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Panel panel3;
        private FontAwesome.Sharp.IconPictureBox ipbMatricula;
        private Label lblMatricula;
        private TextBox txtMatricula;
        private Panel panel1;
        private Label lblTotaldeRegistros;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn matricula;
        private DataGridViewTextBoxColumn NombreEmpleado;
        private DataGridViewTextBoxColumn Departamento;
        private DataGridViewTextBoxColumn Puesto;
        private DataGridViewTextBoxColumn EstatusEmpleado;
        private DataGridViewTextBoxColumn EstatusContrato;
        private DataGridViewTextBoxColumn Salario;
        private DataGridViewTextBoxColumn FechaIngreso;
        private DataGridViewTextBoxColumn FechaBaja;
    }
}
