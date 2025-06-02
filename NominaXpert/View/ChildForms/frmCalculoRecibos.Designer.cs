namespace NominaXpert.View.Forms
{
    partial class frmCalculoRecibos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelBar = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            btnEstatusNomina = new FontAwesome.Sharp.IconButton();
            btnCalculoNomina = new FontAwesome.Sharp.IconButton();
            panelContainer = new Panel();
            panelBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBar
            // 
            panelBar.BackColor = Color.FromArgb(48, 51, 59);
            panelBar.Controls.Add(iconButton2);
            panelBar.Controls.Add(iconButton1);
            panelBar.Controls.Add(btnEstatusNomina);
            panelBar.Controls.Add(btnCalculoNomina);
            panelBar.Dock = DockStyle.Top;
            panelBar.Location = new Point(0, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1244, 64);
            panelBar.TabIndex = 6;
            // 
            // iconButton2
            // 
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            iconButton2.IconColor = Color.FromArgb(12, 215, 253);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.Location = new Point(677, 3);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(10, 0, 20, 0);
            iconButton2.Size = new Size(276, 61);
            iconButton2.TabIndex = 4;
            iconButton2.Text = "Estatus de Nóminas API";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            iconButton2.Click += iconButton2_Click;
            // 
            // iconButton1
            // 
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            iconButton1.IconColor = Color.FromArgb(12, 215, 253);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.Location = new Point(435, 0);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(10, 0, 20, 0);
            iconButton1.Size = new Size(236, 61);
            iconButton1.TabIndex = 3;
            iconButton1.Text = "Cálculo Nómina API";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // btnEstatusNomina
            // 
            btnEstatusNomina.Cursor = Cursors.Hand;
            btnEstatusNomina.FlatAppearance.BorderSize = 0;
            btnEstatusNomina.FlatStyle = FlatStyle.Flat;
            btnEstatusNomina.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstatusNomina.ForeColor = Color.White;
            btnEstatusNomina.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            btnEstatusNomina.IconColor = Color.FromArgb(12, 215, 253);
            btnEstatusNomina.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstatusNomina.IconSize = 32;
            btnEstatusNomina.Location = new Point(205, 3);
            btnEstatusNomina.Name = "btnEstatusNomina";
            btnEstatusNomina.Padding = new Padding(10, 0, 20, 0);
            btnEstatusNomina.Size = new Size(224, 61);
            btnEstatusNomina.TabIndex = 2;
            btnEstatusNomina.Text = "Estatus de Nóminas";
            btnEstatusNomina.TextAlign = ContentAlignment.MiddleLeft;
            btnEstatusNomina.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstatusNomina.UseVisualStyleBackColor = false;
            btnEstatusNomina.Click += btnEstatusNomina_Click;
            // 
            // btnCalculoNomina
            // 
            btnCalculoNomina.Cursor = Cursors.Hand;
            btnCalculoNomina.FlatAppearance.BorderSize = 0;
            btnCalculoNomina.FlatStyle = FlatStyle.Flat;
            btnCalculoNomina.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalculoNomina.ForeColor = Color.White;
            btnCalculoNomina.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            btnCalculoNomina.IconColor = Color.FromArgb(12, 215, 253);
            btnCalculoNomina.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCalculoNomina.IconSize = 32;
            btnCalculoNomina.Location = new Point(3, 3);
            btnCalculoNomina.Name = "btnCalculoNomina";
            btnCalculoNomina.Padding = new Padding(10, 0, 20, 0);
            btnCalculoNomina.Size = new Size(210, 61);
            btnCalculoNomina.TabIndex = 0;
            btnCalculoNomina.Text = "Cálculo Nómina";
            btnCalculoNomina.TextAlign = ContentAlignment.MiddleLeft;
            btnCalculoNomina.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCalculoNomina.UseVisualStyleBackColor = false;
            btnCalculoNomina.Click += btnCalculoNomina_Click;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 64);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1244, 594);
            panelContainer.TabIndex = 7;
            // 
            // frmCalculoRecibos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1244, 658);
            Controls.Add(panelContainer);
            Controls.Add(panelBar);
            Name = "frmCalculoRecibos";
            Text = "Cálculos y Recibos";
            panelBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnCalculoNomina;
        private Panel panelContainer;
        private Panel panelBar;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton btnEstatusNomina;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}