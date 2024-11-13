namespace Clave1_Grupo2
{
    partial class VeterinarioForm
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
            this.tabControlVeterinario = new System.Windows.Forms.TabControl();
            this.tabMascota = new System.Windows.Forms.TabPage();
            this.dgvMascotas = new System.Windows.Forms.DataGridView();
            this.groupBoxMascotaInfo = new System.Windows.Forms.GroupBox();
            this.cmbNombreClienteMascota = new System.Windows.Forms.ComboBox();
            this.btnBuscarMascota = new System.Windows.Forms.Button();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.tabConsultas = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbRegistroConsulta = new System.Windows.Forms.GroupBox();
            this.btnGuardarConsulta = new System.Windows.Forms.Button();
            this.txtIndicaciones = new System.Windows.Forms.TextBox();
            this.lblIndicaciones = new System.Windows.Forms.Label();
            this.txtDescripcionConsulta = new System.Windows.Forms.TextBox();
            this.lblSintomas = new System.Windows.Forms.Label();
            this.txtSintomas = new System.Windows.Forms.TextBox();
            this.lblDescripcionConsulta = new System.Windows.Forms.Label();
            this.tabCuadroVacunas = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvVacunas = new System.Windows.Forms.DataGridView();
            this.NombreVacuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAplicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProximaFechaAplicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBuscarVacunas = new System.Windows.Forms.GroupBox();
            this.cmbBuscarMascota = new System.Windows.Forms.ComboBox();
            this.btnBuscarVacunas = new System.Windows.Forms.Button();
            this.lblMascota = new System.Windows.Forms.Label();
            this.gbRegistroVacunas = new System.Windows.Forms.GroupBox();
            this.btnGuardarVacuna = new System.Windows.Forms.Button();
            this.dtpProximaFechaAplicacion = new System.Windows.Forms.DateTimePicker();
            this.lblProximaFechaAplicacion = new System.Windows.Forms.Label();
            this.dtpFechaAplicacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAplicacion = new System.Windows.Forms.Label();
            this.txtNombreVacuna = new System.Windows.Forms.TextBox();
            this.lblNombreVacuna = new System.Windows.Forms.Label();
            this.tabControlVeterinario.SuspendLayout();
            this.tabMascota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
            this.groupBoxMascotaInfo.SuspendLayout();
            this.tabConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbRegistroConsulta.SuspendLayout();
            this.tabCuadroVacunas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacunas)).BeginInit();
            this.gbBuscarVacunas.SuspendLayout();
            this.gbRegistroVacunas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlVeterinario
            // 
            this.tabControlVeterinario.Controls.Add(this.tabMascota);
            this.tabControlVeterinario.Controls.Add(this.tabConsultas);
            this.tabControlVeterinario.Controls.Add(this.tabCuadroVacunas);
            this.tabControlVeterinario.Location = new System.Drawing.Point(-1, 0);
            this.tabControlVeterinario.Name = "tabControlVeterinario";
            this.tabControlVeterinario.SelectedIndex = 0;
            this.tabControlVeterinario.Size = new System.Drawing.Size(802, 450);
            this.tabControlVeterinario.TabIndex = 1;
            // 
            // tabMascota
            // 
            this.tabMascota.Controls.Add(this.dgvMascotas);
            this.tabMascota.Controls.Add(this.groupBoxMascotaInfo);
            this.tabMascota.Location = new System.Drawing.Point(4, 22);
            this.tabMascota.Name = "tabMascota";
            this.tabMascota.Padding = new System.Windows.Forms.Padding(3);
            this.tabMascota.Size = new System.Drawing.Size(794, 424);
            this.tabMascota.TabIndex = 0;
            this.tabMascota.Text = "Mascota";
            this.tabMascota.UseVisualStyleBackColor = true;
            // 
            // dgvMascotas
            // 
            this.dgvMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMascotas.Location = new System.Drawing.Point(0, 64);
            this.dgvMascotas.Name = "dgvMascotas";
            this.dgvMascotas.Size = new System.Drawing.Size(785, 354);
            this.dgvMascotas.TabIndex = 10;
            this.dgvMascotas.SelectionChanged += new System.EventHandler(this.dgvMascotas_SelectionChanged);
            // 
            // groupBoxMascotaInfo
            // 
            this.groupBoxMascotaInfo.Controls.Add(this.cmbNombreClienteMascota);
            this.groupBoxMascotaInfo.Controls.Add(this.btnBuscarMascota);
            this.groupBoxMascotaInfo.Controls.Add(this.lblNombreCliente);
            this.groupBoxMascotaInfo.Location = new System.Drawing.Point(7, 6);
            this.groupBoxMascotaInfo.Name = "groupBoxMascotaInfo";
            this.groupBoxMascotaInfo.Size = new System.Drawing.Size(445, 52);
            this.groupBoxMascotaInfo.TabIndex = 2;
            this.groupBoxMascotaInfo.TabStop = false;
            this.groupBoxMascotaInfo.Text = "Información de la Mascota";
            // 
            // cmbNombreClienteMascota
            // 
            this.cmbNombreClienteMascota.FormattingEnabled = true;
            this.cmbNombreClienteMascota.Location = new System.Drawing.Point(115, 17);
            this.cmbNombreClienteMascota.Name = "cmbNombreClienteMascota";
            this.cmbNombreClienteMascota.Size = new System.Drawing.Size(121, 21);
            this.cmbNombreClienteMascota.TabIndex = 12;
            // 
            // btnBuscarMascota
            // 
            this.btnBuscarMascota.Location = new System.Drawing.Point(251, 14);
            this.btnBuscarMascota.Name = "btnBuscarMascota";
            this.btnBuscarMascota.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarMascota.TabIndex = 11;
            this.btnBuscarMascota.Text = "Buscar";
            this.btnBuscarMascota.UseVisualStyleBackColor = true;
            this.btnBuscarMascota.Click += new System.EventHandler(this.btnBuscarMascota_Click);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(7, 20);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(111, 13);
            this.lblNombreCliente.TabIndex = 0;
            this.lblNombreCliente.Text = "Nombre  de la Cliente:";
            // 
            // tabConsultas
            // 
            this.tabConsultas.Controls.Add(this.pictureBox1);
            this.tabConsultas.Controls.Add(this.gbRegistroConsulta);
            this.tabConsultas.Location = new System.Drawing.Point(4, 22);
            this.tabConsultas.Name = "tabConsultas";
            this.tabConsultas.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsultas.Size = new System.Drawing.Size(794, 424);
            this.tabConsultas.TabIndex = 1;
            this.tabConsultas.Text = "Consultas";
            this.tabConsultas.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clave1_Grupo2.Properties.Resources.mascota;
            this.pictureBox1.Location = new System.Drawing.Point(411, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // gbRegistroConsulta
            // 
            this.gbRegistroConsulta.Controls.Add(this.btnGuardarConsulta);
            this.gbRegistroConsulta.Controls.Add(this.txtIndicaciones);
            this.gbRegistroConsulta.Controls.Add(this.lblIndicaciones);
            this.gbRegistroConsulta.Controls.Add(this.txtDescripcionConsulta);
            this.gbRegistroConsulta.Controls.Add(this.lblSintomas);
            this.gbRegistroConsulta.Controls.Add(this.txtSintomas);
            this.gbRegistroConsulta.Controls.Add(this.lblDescripcionConsulta);
            this.gbRegistroConsulta.Location = new System.Drawing.Point(9, 11);
            this.gbRegistroConsulta.Name = "gbRegistroConsulta";
            this.gbRegistroConsulta.Size = new System.Drawing.Size(396, 366);
            this.gbRegistroConsulta.TabIndex = 0;
            this.gbRegistroConsulta.TabStop = false;
            this.gbRegistroConsulta.Text = "Registrar Consulta";
            // 
            // btnGuardarConsulta
            // 
            this.btnGuardarConsulta.Location = new System.Drawing.Point(216, 335);
            this.btnGuardarConsulta.Name = "btnGuardarConsulta";
            this.btnGuardarConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarConsulta.TabIndex = 12;
            this.btnGuardarConsulta.Text = "Guardar";
            this.btnGuardarConsulta.UseVisualStyleBackColor = true;
            this.btnGuardarConsulta.Click += new System.EventHandler(this.btnGuardarConsulta_Click);
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.Location = new System.Drawing.Point(130, 227);
            this.txtIndicaciones.Multiline = true;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(239, 102);
            this.txtIndicaciones.TabIndex = 5;
            // 
            // lblIndicaciones
            // 
            this.lblIndicaciones.AutoSize = true;
            this.lblIndicaciones.Location = new System.Drawing.Point(60, 230);
            this.lblIndicaciones.Name = "lblIndicaciones";
            this.lblIndicaciones.Size = new System.Drawing.Size(70, 13);
            this.lblIndicaciones.TabIndex = 4;
            this.lblIndicaciones.Text = "Indicaciones:";
            // 
            // txtDescripcionConsulta
            // 
            this.txtDescripcionConsulta.Location = new System.Drawing.Point(129, 124);
            this.txtDescripcionConsulta.Multiline = true;
            this.txtDescripcionConsulta.Name = "txtDescripcionConsulta";
            this.txtDescripcionConsulta.Size = new System.Drawing.Size(239, 97);
            this.txtDescripcionConsulta.TabIndex = 3;
            // 
            // lblSintomas
            // 
            this.lblSintomas.AutoSize = true;
            this.lblSintomas.Location = new System.Drawing.Point(75, 20);
            this.lblSintomas.Name = "lblSintomas";
            this.lblSintomas.Size = new System.Drawing.Size(55, 13);
            this.lblSintomas.TabIndex = 2;
            this.lblSintomas.Text = "Síntomas:";
            // 
            // txtSintomas
            // 
            this.txtSintomas.Location = new System.Drawing.Point(132, 17);
            this.txtSintomas.Multiline = true;
            this.txtSintomas.Name = "txtSintomas";
            this.txtSintomas.Size = new System.Drawing.Size(237, 101);
            this.txtSintomas.TabIndex = 1;
            // 
            // lblDescripcionConsulta
            // 
            this.lblDescripcionConsulta.AutoSize = true;
            this.lblDescripcionConsulta.Location = new System.Drawing.Point(6, 127);
            this.lblDescripcionConsulta.Name = "lblDescripcionConsulta";
            this.lblDescripcionConsulta.Size = new System.Drawing.Size(125, 13);
            this.lblDescripcionConsulta.TabIndex = 0;
            this.lblDescripcionConsulta.Text = "Descripción de Consulta:";
            // 
            // tabCuadroVacunas
            // 
            this.tabCuadroVacunas.Controls.Add(this.pictureBox2);
            this.tabCuadroVacunas.Controls.Add(this.dgvVacunas);
            this.tabCuadroVacunas.Controls.Add(this.gbBuscarVacunas);
            this.tabCuadroVacunas.Controls.Add(this.gbRegistroVacunas);
            this.tabCuadroVacunas.Location = new System.Drawing.Point(4, 22);
            this.tabCuadroVacunas.Name = "tabCuadroVacunas";
            this.tabCuadroVacunas.Size = new System.Drawing.Size(794, 424);
            this.tabCuadroVacunas.TabIndex = 2;
            this.tabCuadroVacunas.Text = "Cuadro Vacunas";
            this.tabCuadroVacunas.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Clave1_Grupo2.Properties.Resources.vacunas;
            this.pictureBox2.Location = new System.Drawing.Point(355, 75);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(180, 129);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // dgvVacunas
            // 
            this.dgvVacunas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacunas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreVacuna,
            this.FechaAplicacion,
            this.ProximaFechaAplicacion});
            this.dgvVacunas.Location = new System.Drawing.Point(6, 75);
            this.dgvVacunas.Name = "dgvVacunas";
            this.dgvVacunas.Size = new System.Drawing.Size(343, 131);
            this.dgvVacunas.TabIndex = 15;
            // 
            // NombreVacuna
            // 
            this.NombreVacuna.HeaderText = "Nombre de la Vacuna";
            this.NombreVacuna.Name = "NombreVacuna";
            // 
            // FechaAplicacion
            // 
            this.FechaAplicacion.HeaderText = "Fecha de Aplicación";
            this.FechaAplicacion.Name = "FechaAplicacion";
            // 
            // ProximaFechaAplicacion
            // 
            this.ProximaFechaAplicacion.HeaderText = "Próxima Fecha de Aplicación";
            this.ProximaFechaAplicacion.Name = "ProximaFechaAplicacion";
            // 
            // gbBuscarVacunas
            // 
            this.gbBuscarVacunas.Controls.Add(this.cmbBuscarMascota);
            this.gbBuscarVacunas.Controls.Add(this.btnBuscarVacunas);
            this.gbBuscarVacunas.Controls.Add(this.lblMascota);
            this.gbBuscarVacunas.Location = new System.Drawing.Point(3, 3);
            this.gbBuscarVacunas.Name = "gbBuscarVacunas";
            this.gbBuscarVacunas.Size = new System.Drawing.Size(346, 71);
            this.gbBuscarVacunas.TabIndex = 14;
            this.gbBuscarVacunas.TabStop = false;
            this.gbBuscarVacunas.Text = "Buscar Vacunas por Mascota";
            // 
            // cmbBuscarMascota
            // 
            this.cmbBuscarMascota.FormattingEnabled = true;
            this.cmbBuscarMascota.Location = new System.Drawing.Point(110, 17);
            this.cmbBuscarMascota.Name = "cmbBuscarMascota";
            this.cmbBuscarMascota.Size = new System.Drawing.Size(121, 21);
            this.cmbBuscarMascota.TabIndex = 14;
            // 
            // btnBuscarVacunas
            // 
            this.btnBuscarVacunas.Location = new System.Drawing.Point(10, 44);
            this.btnBuscarVacunas.Name = "btnBuscarVacunas";
            this.btnBuscarVacunas.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarVacunas.TabIndex = 13;
            this.btnBuscarVacunas.Text = "Buscar";
            this.btnBuscarVacunas.UseVisualStyleBackColor = true;
            this.btnBuscarVacunas.Click += new System.EventHandler(this.btnBuscarVacunas_Click);
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Location = new System.Drawing.Point(7, 20);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(106, 13);
            this.lblMascota.TabIndex = 0;
            this.lblMascota.Text = "Nombre de Mascota:";
            // 
            // gbRegistroVacunas
            // 
            this.gbRegistroVacunas.Controls.Add(this.btnGuardarVacuna);
            this.gbRegistroVacunas.Controls.Add(this.dtpProximaFechaAplicacion);
            this.gbRegistroVacunas.Controls.Add(this.lblProximaFechaAplicacion);
            this.gbRegistroVacunas.Controls.Add(this.dtpFechaAplicacion);
            this.gbRegistroVacunas.Controls.Add(this.lblFechaAplicacion);
            this.gbRegistroVacunas.Controls.Add(this.txtNombreVacuna);
            this.gbRegistroVacunas.Controls.Add(this.lblNombreVacuna);
            this.gbRegistroVacunas.Location = new System.Drawing.Point(7, 212);
            this.gbRegistroVacunas.Name = "gbRegistroVacunas";
            this.gbRegistroVacunas.Size = new System.Drawing.Size(381, 132);
            this.gbRegistroVacunas.TabIndex = 0;
            this.gbRegistroVacunas.TabStop = false;
            this.gbRegistroVacunas.Text = "Registrar Nueva Vacuna";
            // 
            // btnGuardarVacuna
            // 
            this.btnGuardarVacuna.Location = new System.Drawing.Point(10, 101);
            this.btnGuardarVacuna.Name = "btnGuardarVacuna";
            this.btnGuardarVacuna.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarVacuna.TabIndex = 13;
            this.btnGuardarVacuna.Text = "Guardar";
            this.btnGuardarVacuna.UseVisualStyleBackColor = true;
            this.btnGuardarVacuna.Click += new System.EventHandler(this.btnGuardarVacuna_Click);
            // 
            // dtpProximaFechaAplicacion
            // 
            this.dtpProximaFechaAplicacion.Location = new System.Drawing.Point(151, 66);
            this.dtpProximaFechaAplicacion.Name = "dtpProximaFechaAplicacion";
            this.dtpProximaFechaAplicacion.Size = new System.Drawing.Size(200, 20);
            this.dtpProximaFechaAplicacion.TabIndex = 5;
            // 
            // lblProximaFechaAplicacion
            // 
            this.lblProximaFechaAplicacion.AutoSize = true;
            this.lblProximaFechaAplicacion.Location = new System.Drawing.Point(7, 68);
            this.lblProximaFechaAplicacion.Name = "lblProximaFechaAplicacion";
            this.lblProximaFechaAplicacion.Size = new System.Drawing.Size(147, 13);
            this.lblProximaFechaAplicacion.TabIndex = 4;
            this.lblProximaFechaAplicacion.Text = "Próxima Fecha de Aplicación:";
            // 
            // dtpFechaAplicacion
            // 
            this.dtpFechaAplicacion.Location = new System.Drawing.Point(110, 41);
            this.dtpFechaAplicacion.Name = "dtpFechaAplicacion";
            this.dtpFechaAplicacion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaAplicacion.TabIndex = 3;
            // 
            // lblFechaAplicacion
            // 
            this.lblFechaAplicacion.AutoSize = true;
            this.lblFechaAplicacion.Location = new System.Drawing.Point(7, 44);
            this.lblFechaAplicacion.Name = "lblFechaAplicacion";
            this.lblFechaAplicacion.Size = new System.Drawing.Size(107, 13);
            this.lblFechaAplicacion.TabIndex = 2;
            this.lblFechaAplicacion.Text = "Fecha de Aplicación:";
            // 
            // txtNombreVacuna
            // 
            this.txtNombreVacuna.Location = new System.Drawing.Point(106, 17);
            this.txtNombreVacuna.Name = "txtNombreVacuna";
            this.txtNombreVacuna.Size = new System.Drawing.Size(100, 20);
            this.txtNombreVacuna.TabIndex = 1;
            // 
            // lblNombreVacuna
            // 
            this.lblNombreVacuna.AutoSize = true;
            this.lblNombreVacuna.Location = new System.Drawing.Point(7, 20);
            this.lblNombreVacuna.Name = "lblNombreVacuna";
            this.lblNombreVacuna.Size = new System.Drawing.Size(102, 13);
            this.lblNombreVacuna.TabIndex = 0;
            this.lblNombreVacuna.Text = "Nombre de Vacuna:";
            // 
            // VeterinarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlVeterinario);
            this.Name = "VeterinarioForm";
            this.Text = "VeterinarioForm";
            this.tabControlVeterinario.ResumeLayout(false);
            this.tabMascota.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
            this.groupBoxMascotaInfo.ResumeLayout(false);
            this.groupBoxMascotaInfo.PerformLayout();
            this.tabConsultas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbRegistroConsulta.ResumeLayout(false);
            this.gbRegistroConsulta.PerformLayout();
            this.tabCuadroVacunas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacunas)).EndInit();
            this.gbBuscarVacunas.ResumeLayout(false);
            this.gbBuscarVacunas.PerformLayout();
            this.gbRegistroVacunas.ResumeLayout(false);
            this.gbRegistroVacunas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlVeterinario;
        private System.Windows.Forms.TabPage tabMascota;
        private System.Windows.Forms.DataGridView dgvMascotas;
        private System.Windows.Forms.GroupBox groupBoxMascotaInfo;
        private System.Windows.Forms.Button btnBuscarMascota;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TabPage tabConsultas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbRegistroConsulta;
        private System.Windows.Forms.Button btnGuardarConsulta;
        private System.Windows.Forms.TextBox txtIndicaciones;
        private System.Windows.Forms.Label lblIndicaciones;
        private System.Windows.Forms.TextBox txtDescripcionConsulta;
        private System.Windows.Forms.Label lblSintomas;
        private System.Windows.Forms.TextBox txtSintomas;
        private System.Windows.Forms.Label lblDescripcionConsulta;
        private System.Windows.Forms.TabPage tabCuadroVacunas;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvVacunas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreVacuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAplicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProximaFechaAplicacion;
        private System.Windows.Forms.GroupBox gbBuscarVacunas;
        private System.Windows.Forms.Button btnBuscarVacunas;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.GroupBox gbRegistroVacunas;
        private System.Windows.Forms.Button btnGuardarVacuna;
        private System.Windows.Forms.DateTimePicker dtpProximaFechaAplicacion;
        private System.Windows.Forms.Label lblProximaFechaAplicacion;
        private System.Windows.Forms.DateTimePicker dtpFechaAplicacion;
        private System.Windows.Forms.Label lblFechaAplicacion;
        private System.Windows.Forms.TextBox txtNombreVacuna;
        private System.Windows.Forms.Label lblNombreVacuna;
        private System.Windows.Forms.ComboBox cmbNombreClienteMascota;
        private System.Windows.Forms.ComboBox cmbBuscarMascota;
    }
}