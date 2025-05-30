﻿namespace NominaXpert.View.Forms
{
    partial class frmAdminEmpleados
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
            btnListaEmpleados = new FontAwesome.Sharp.IconButton();
            btnEmpleadoAPI = new FontAwesome.Sharp.IconButton();
            btnCargaBar = new FontAwesome.Sharp.IconButton();
            btnListadoBar = new FontAwesome.Sharp.IconButton();
            panelContainer = new Panel();
            panelBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBar
            // 
            panelBar.BackColor = Color.FromArgb(48, 51, 59);
            panelBar.Controls.Add(btnListaEmpleados);
            panelBar.Controls.Add(btnEmpleadoAPI);
            panelBar.Controls.Add(btnCargaBar);
            panelBar.Controls.Add(btnListadoBar);
            panelBar.Dock = DockStyle.Top;
            panelBar.Location = new Point(0, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1262, 64);
            panelBar.TabIndex = 2;
            // 
            // btnListaEmpleados
            // 
            btnListaEmpleados.Cursor = Cursors.Hand;
            btnListaEmpleados.FlatAppearance.BorderSize = 0;
            btnListaEmpleados.FlatStyle = FlatStyle.Flat;
            btnListaEmpleados.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListaEmpleados.ForeColor = Color.White;
            btnListaEmpleados.IconChar = FontAwesome.Sharp.IconChar.UsersRectangle;
            btnListaEmpleados.IconColor = Color.FromArgb(12, 215, 253);
            btnListaEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListaEmpleados.IconSize = 32;
            btnListaEmpleados.Location = new Point(532, 2);
            btnListaEmpleados.Name = "btnListaEmpleados";
            btnListaEmpleados.Padding = new Padding(10, 0, 20, 0);
            btnListaEmpleados.Size = new Size(240, 61);
            btnListaEmpleados.TabIndex = 6;
            btnListaEmpleados.Text = "Lista empleados API";
            btnListaEmpleados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnListaEmpleados.UseVisualStyleBackColor = false;
            btnListaEmpleados.Click += btnListaEmpleados_Click;
            // 
            // btnEmpleadoAPI
            // 
            btnEmpleadoAPI.Cursor = Cursors.Hand;
            btnEmpleadoAPI.FlatAppearance.BorderSize = 0;
            btnEmpleadoAPI.FlatStyle = FlatStyle.Flat;
            btnEmpleadoAPI.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmpleadoAPI.ForeColor = Color.White;
            btnEmpleadoAPI.IconChar = FontAwesome.Sharp.IconChar.CodeCompare;
            btnEmpleadoAPI.IconColor = Color.FromArgb(12, 215, 253);
            btnEmpleadoAPI.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEmpleadoAPI.IconSize = 32;
            btnEmpleadoAPI.Location = new Point(328, 0);
            btnEmpleadoAPI.Name = "btnEmpleadoAPI";
            btnEmpleadoAPI.Padding = new Padding(10, 0, 20, 0);
            btnEmpleadoAPI.Size = new Size(199, 61);
            btnEmpleadoAPI.TabIndex = 5;
            btnEmpleadoAPI.Text = "Empleado API";
            btnEmpleadoAPI.TextAlign = ContentAlignment.MiddleLeft;
            btnEmpleadoAPI.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpleadoAPI.UseVisualStyleBackColor = false;
            btnEmpleadoAPI.Click += btnEmpleadoAPI_Click;
            // 
            // btnCargaBar
            // 
            btnCargaBar.Cursor = Cursors.Hand;
            btnCargaBar.FlatAppearance.BorderSize = 0;
            btnCargaBar.FlatStyle = FlatStyle.Flat;
            btnCargaBar.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargaBar.ForeColor = Color.White;
            btnCargaBar.IconChar = FontAwesome.Sharp.IconChar.Upload;
            btnCargaBar.IconColor = Color.FromArgb(12, 215, 253);
            btnCargaBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCargaBar.IconSize = 32;
            btnCargaBar.Location = new Point(136, 3);
            btnCargaBar.Name = "btnCargaBar";
            btnCargaBar.Padding = new Padding(10, 0, 20, 0);
            btnCargaBar.Size = new Size(186, 61);
            btnCargaBar.TabIndex = 4;
            btnCargaBar.Text = "Carga Masiva";
            btnCargaBar.TextAlign = ContentAlignment.MiddleLeft;
            btnCargaBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCargaBar.UseVisualStyleBackColor = false;
            btnCargaBar.Click += btnCargaBar_Click;
            // 
            // btnListadoBar
            // 
            btnListadoBar.Cursor = Cursors.Hand;
            btnListadoBar.FlatAppearance.BorderSize = 0;
            btnListadoBar.FlatStyle = FlatStyle.Flat;
            btnListadoBar.Font = new Font("Corbel", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListadoBar.ForeColor = Color.White;
            btnListadoBar.IconChar = FontAwesome.Sharp.IconChar.UsersLine;
            btnListadoBar.IconColor = Color.FromArgb(12, 215, 253);
            btnListadoBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListadoBar.IconSize = 32;
            btnListadoBar.Location = new Point(3, 3);
            btnListadoBar.Name = "btnListadoBar";
            btnListadoBar.Padding = new Padding(10, 0, 20, 0);
            btnListadoBar.Size = new Size(141, 61);
            btnListadoBar.TabIndex = 1;
            btnListadoBar.Text = "Listado";
            btnListadoBar.TextAlign = ContentAlignment.MiddleLeft;
            btnListadoBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnListadoBar.UseVisualStyleBackColor = false;
            btnListadoBar.Click += btnListadoBar_Click;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelContainer.Location = new Point(0, 64);
            panelContainer.Name = "panelContainer";
            panelContainer.Padding = new Padding(10, 0, 20, 0);
            panelContainer.Size = new Size(1262, 705);
            panelContainer.TabIndex = 3;
            // 
            // frmAdminEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1262, 769);
            Controls.Add(panelContainer);
            Controls.Add(panelBar);
            Name = "frmAdminEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Empleados";
            panelBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelBar;
        private Panel panelContainer;
        private FontAwesome.Sharp.IconButton btnListadoBar;
        private FontAwesome.Sharp.IconButton btnCargaBar;
        private FontAwesome.Sharp.IconButton btnEmpleadoAPI;
        private FontAwesome.Sharp.IconButton btnListaEmpleados;
    }
}