namespace Clave1_Grupo2
{
    partial class AdminForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCliente = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.groupBoxClienteInfo = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnActualizarCliente = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tabMascota = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvMascotas = new System.Windows.Forms.DataGridView();
            this.btnActualizarMascotas = new System.Windows.Forms.Button();
            this.btnEliminarMascota = new System.Windows.Forms.Button();
            this.btnModificarMascota = new System.Windows.Forms.Button();
            this.btnIngresarMascota = new System.Windows.Forms.Button();
            this.groupBoxMascotaInfo = new System.Windows.Forms.GroupBox();
            this.cmbDueno = new System.Windows.Forms.ComboBox();
            this.lblDueño = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblCastrado = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.lblRaza = new System.Windows.Forms.Label();
            this.cmbEspecie = new System.Windows.Forms.ComboBox();
            this.lblEspecie = new System.Windows.Forms.Label();
            this.txtNombreMascota = new System.Windows.Forms.TextBox();
            this.lblNombreMascota = new System.Windows.Forms.Label();
            this.tabFacturacion = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dgvFacturacion = new System.Windows.Forms.DataGridView();
            this.groupBoxFacturacion = new System.Windows.Forms.GroupBox();
            this.btnConfirmarPago = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbServicioPrestado = new System.Windows.Forms.ComboBox();
            this.lblServicioPrestado = new System.Windows.Forms.Label();
            this.tabProductosServicios = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxProductosServicios = new System.Windows.Forms.GroupBox();
            this.btnActualizarProductos = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCitas = new System.Windows.Forms.TabPage();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NombreMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCitas = new System.Windows.Forms.GroupBox();
            this.cmbMascotaCita = new System.Windows.Forms.ComboBox();
            this.cmbDuenoCita = new System.Windows.Forms.ComboBox();
            this.lblDueno = new System.Windows.Forms.Label();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.btnAgendarCita = new System.Windows.Forms.Button();
            this.btnModificarCita = new System.Windows.Forms.Button();
            this.cmbHorarioCita = new System.Windows.Forms.ComboBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.dtpFechaCita = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCita = new System.Windows.Forms.Label();
            this.lblMascota = new System.Windows.Forms.Label();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.cmbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.groupBoxClienteInfo.SuspendLayout();
            this.tabMascota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
            this.groupBoxMascotaInfo.SuspendLayout();
            this.tabFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturacion)).BeginInit();
            this.groupBoxFacturacion.SuspendLayout();
            this.tabProductosServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxProductosServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tabCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbCitas.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCliente);
            this.tabControl1.Controls.Add(this.tabMascota);
            this.tabControl1.Controls.Add(this.tabFacturacion);
            this.tabControl1.Controls.Add(this.tabProductosServicios);
            this.tabControl1.Controls.Add(this.tabCitas);
            this.tabControl1.Controls.Add(this.tabUsuarios);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 451);
            this.tabControl1.TabIndex = 1;
            // 
            // tabCliente
            // 
            this.tabCliente.Controls.Add(this.pictureBox3);
            this.tabCliente.Controls.Add(this.dgvClientes);
            this.tabCliente.Controls.Add(this.groupBoxClienteInfo);
            this.tabCliente.Location = new System.Drawing.Point(4, 22);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabCliente.Size = new System.Drawing.Size(801, 425);
            this.tabCliente.TabIndex = 0;
            this.tabCliente.Text = "Cliente";
            this.tabCliente.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Clave1_Grupo2.Properties.Resources.cliente;
            this.pictureBox3.Location = new System.Drawing.Point(490, 231);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(293, 185);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(6, 6);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(475, 410);
            this.dgvClientes.TabIndex = 1;
            // 
            // groupBoxClienteInfo
            // 
            this.groupBoxClienteInfo.Controls.Add(this.btnBuscar);
            this.groupBoxClienteInfo.Controls.Add(this.txtEmail);
            this.groupBoxClienteInfo.Controls.Add(this.btnEliminarCliente);
            this.groupBoxClienteInfo.Controls.Add(this.btnActualizarCliente);
            this.groupBoxClienteInfo.Controls.Add(this.lblEmail);
            this.groupBoxClienteInfo.Controls.Add(this.txtDireccion);
            this.groupBoxClienteInfo.Controls.Add(this.btnModificarCliente);
            this.groupBoxClienteInfo.Controls.Add(this.lblDireccion);
            this.groupBoxClienteInfo.Controls.Add(this.txtTelefono);
            this.groupBoxClienteInfo.Controls.Add(this.lblTelefono);
            this.groupBoxClienteInfo.Controls.Add(this.cmbSexo);
            this.groupBoxClienteInfo.Controls.Add(this.lblSexo);
            this.groupBoxClienteInfo.Controls.Add(this.txtApellido);
            this.groupBoxClienteInfo.Controls.Add(this.lblApellido);
            this.groupBoxClienteInfo.Controls.Add(this.txtNombre);
            this.groupBoxClienteInfo.Controls.Add(this.lblNombre);
            this.groupBoxClienteInfo.Location = new System.Drawing.Point(487, 6);
            this.groupBoxClienteInfo.Name = "groupBoxClienteInfo";
            this.groupBoxClienteInfo.Size = new System.Drawing.Size(296, 219);
            this.groupBoxClienteInfo.TabIndex = 0;
            this.groupBoxClienteInfo.TabStop = false;
            this.groupBoxClienteInfo.Text = "Información del Cliente";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(215, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(54, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Location = new System.Drawing.Point(215, 150);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCliente.TabIndex = 5;
            this.btnEliminarCliente.Text = "Eliminar";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // btnActualizarCliente
            // 
            this.btnActualizarCliente.Location = new System.Drawing.Point(215, 183);
            this.btnActualizarCliente.Name = "btnActualizarCliente";
            this.btnActualizarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarCliente.TabIndex = 6;
            this.btnActualizarCliente.Text = "Actualizar";
            this.btnActualizarCliente.UseVisualStyleBackColor = true;
            this.btnActualizarCliente.Click += new System.EventHandler(this.btnActualizarCliente_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(19, 144);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(54, 117);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Location = new System.Drawing.Point(215, 114);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnModificarCliente.TabIndex = 4;
            this.btnModificarCliente.Text = "Modificar";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(0, 120);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(54, 93);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(2, 95);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbSexo.Location = new System.Drawing.Point(53, 67);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(121, 21);
            this.cmbSexo.TabIndex = 5;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(19, 70);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 4;
            this.lblSexo.Text = "Sexo:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(53, 41);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(7, 45);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(52, 17);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // tabMascota
            // 
            this.tabMascota.Controls.Add(this.pictureBox2);
            this.tabMascota.Controls.Add(this.dgvMascotas);
            this.tabMascota.Controls.Add(this.btnActualizarMascotas);
            this.tabMascota.Controls.Add(this.btnEliminarMascota);
            this.tabMascota.Controls.Add(this.btnModificarMascota);
            this.tabMascota.Controls.Add(this.btnIngresarMascota);
            this.tabMascota.Controls.Add(this.groupBoxMascotaInfo);
            this.tabMascota.Location = new System.Drawing.Point(4, 22);
            this.tabMascota.Name = "tabMascota";
            this.tabMascota.Padding = new System.Windows.Forms.Padding(3);
            this.tabMascota.Size = new System.Drawing.Size(801, 425);
            this.tabMascota.TabIndex = 1;
            this.tabMascota.Text = "Mascota";
            this.tabMascota.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Clave1_Grupo2.Properties.Resources.mascotas;
            this.pictureBox2.Location = new System.Drawing.Point(476, 284);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 121);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // dgvMascotas
            // 
            this.dgvMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMascotas.Location = new System.Drawing.Point(10, 6);
            this.dgvMascotas.Name = "dgvMascotas";
            this.dgvMascotas.Size = new System.Drawing.Size(460, 399);
            this.dgvMascotas.TabIndex = 8;
            // 
            // btnActualizarMascotas
            // 
            this.btnActualizarMascotas.Location = new System.Drawing.Point(638, 255);
            this.btnActualizarMascotas.Name = "btnActualizarMascotas";
            this.btnActualizarMascotas.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarMascotas.TabIndex = 7;
            this.btnActualizarMascotas.Text = "Actualizar";
            this.btnActualizarMascotas.UseVisualStyleBackColor = true;
            // 
            // btnEliminarMascota
            // 
            this.btnEliminarMascota.Location = new System.Drawing.Point(718, 255);
            this.btnEliminarMascota.Name = "btnEliminarMascota";
            this.btnEliminarMascota.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarMascota.TabIndex = 6;
            this.btnEliminarMascota.Text = "Eliminar";
            this.btnEliminarMascota.UseVisualStyleBackColor = true;
            // 
            // btnModificarMascota
            // 
            this.btnModificarMascota.Location = new System.Drawing.Point(557, 255);
            this.btnModificarMascota.Name = "btnModificarMascota";
            this.btnModificarMascota.Size = new System.Drawing.Size(75, 23);
            this.btnModificarMascota.TabIndex = 5;
            this.btnModificarMascota.Text = "Modificar";
            this.btnModificarMascota.UseVisualStyleBackColor = true;
            // 
            // btnIngresarMascota
            // 
            this.btnIngresarMascota.Location = new System.Drawing.Point(476, 255);
            this.btnIngresarMascota.Name = "btnIngresarMascota";
            this.btnIngresarMascota.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarMascota.TabIndex = 3;
            this.btnIngresarMascota.Text = "Ingresar";
            this.btnIngresarMascota.UseVisualStyleBackColor = true;
            // 
            // groupBoxMascotaInfo
            // 
            this.groupBoxMascotaInfo.Controls.Add(this.cmbDueno);
            this.groupBoxMascotaInfo.Controls.Add(this.lblDueño);
            this.groupBoxMascotaInfo.Controls.Add(this.checkBox1);
            this.groupBoxMascotaInfo.Controls.Add(this.lblCastrado);
            this.groupBoxMascotaInfo.Controls.Add(this.dtpFechaNacimiento);
            this.groupBoxMascotaInfo.Controls.Add(this.lblFechaNacimiento);
            this.groupBoxMascotaInfo.Controls.Add(this.txtPeso);
            this.groupBoxMascotaInfo.Controls.Add(this.lblPeso);
            this.groupBoxMascotaInfo.Controls.Add(this.txtEdad);
            this.groupBoxMascotaInfo.Controls.Add(this.lblEdad);
            this.groupBoxMascotaInfo.Controls.Add(this.txtRaza);
            this.groupBoxMascotaInfo.Controls.Add(this.lblRaza);
            this.groupBoxMascotaInfo.Controls.Add(this.cmbEspecie);
            this.groupBoxMascotaInfo.Controls.Add(this.lblEspecie);
            this.groupBoxMascotaInfo.Controls.Add(this.txtNombreMascota);
            this.groupBoxMascotaInfo.Controls.Add(this.lblNombreMascota);
            this.groupBoxMascotaInfo.Location = new System.Drawing.Point(476, 6);
            this.groupBoxMascotaInfo.Name = "groupBoxMascotaInfo";
            this.groupBoxMascotaInfo.Size = new System.Drawing.Size(319, 243);
            this.groupBoxMascotaInfo.TabIndex = 0;
            this.groupBoxMascotaInfo.TabStop = false;
            this.groupBoxMascotaInfo.Text = "Información de la Mascota";
            // 
            // cmbDueno
            // 
            this.cmbDueno.FormattingEnabled = true;
            this.cmbDueno.Location = new System.Drawing.Point(95, 16);
            this.cmbDueno.Name = "cmbDueno";
            this.cmbDueno.Size = new System.Drawing.Size(121, 21);
            this.cmbDueno.TabIndex = 16;
            // 
            // lblDueño
            // 
            this.lblDueño.AutoSize = true;
            this.lblDueño.Location = new System.Drawing.Point(54, 20);
            this.lblDueño.Name = "lblDueño";
            this.lblDueño.Size = new System.Drawing.Size(42, 13);
            this.lblDueño.TabIndex = 15;
            this.lblDueño.Text = "Dueño:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(117, 196);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Castrado";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblCastrado
            // 
            this.lblCastrado.AutoSize = true;
            this.lblCastrado.Location = new System.Drawing.Point(66, 175);
            this.lblCastrado.Name = "lblCastrado";
            this.lblCastrado.Size = new System.Drawing.Size(0, 13);
            this.lblCastrado.TabIndex = 12;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(117, 169);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 11;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(6, 174);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(111, 13);
            this.lblFechaNacimiento.TabIndex = 10;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(95, 145);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(100, 20);
            this.txtPeso.TabIndex = 9;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(41, 147);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(56, 13);
            this.lblPeso.TabIndex = 8;
            this.lblPeso.Text = "Peso (Kg):";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(95, 120);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 20);
            this.txtEdad.TabIndex = 7;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(7, 123);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(89, 13);
            this.lblEdad.TabIndex = 6;
            this.lblEdad.Text = "Edad (en meses):";
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(95, 95);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(100, 20);
            this.txtRaza.TabIndex = 5;
            // 
            // lblRaza
            // 
            this.lblRaza.AutoSize = true;
            this.lblRaza.Location = new System.Drawing.Point(62, 98);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(35, 13);
            this.lblRaza.TabIndex = 4;
            this.lblRaza.Text = "Raza:";
            // 
            // cmbEspecie
            // 
            this.cmbEspecie.FormattingEnabled = true;
            this.cmbEspecie.Items.AddRange(new object[] {
            "Perro",
            "Gato",
            "Perico",
            "Hamster",
            "Conejo"});
            this.cmbEspecie.Location = new System.Drawing.Point(95, 70);
            this.cmbEspecie.Name = "cmbEspecie";
            this.cmbEspecie.Size = new System.Drawing.Size(121, 21);
            this.cmbEspecie.TabIndex = 3;
            // 
            // lblEspecie
            // 
            this.lblEspecie.AutoSize = true;
            this.lblEspecie.Location = new System.Drawing.Point(48, 75);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(48, 13);
            this.lblEspecie.TabIndex = 2;
            this.lblEspecie.Text = "Especie:";
            // 
            // txtNombreMascota
            // 
            this.txtNombreMascota.Location = new System.Drawing.Point(95, 45);
            this.txtNombreMascota.Name = "txtNombreMascota";
            this.txtNombreMascota.Size = new System.Drawing.Size(100, 20);
            this.txtNombreMascota.TabIndex = 1;
            // 
            // lblNombreMascota
            // 
            this.lblNombreMascota.AutoSize = true;
            this.lblNombreMascota.Location = new System.Drawing.Point(7, 48);
            this.lblNombreMascota.Name = "lblNombreMascota";
            this.lblNombreMascota.Size = new System.Drawing.Size(91, 13);
            this.lblNombreMascota.TabIndex = 0;
            this.lblNombreMascota.Text = "Nombre Mascota:";
            // 
            // tabFacturacion
            // 
            this.tabFacturacion.Controls.Add(this.pictureBox4);
            this.tabFacturacion.Controls.Add(this.dgvFacturacion);
            this.tabFacturacion.Controls.Add(this.groupBoxFacturacion);
            this.tabFacturacion.Location = new System.Drawing.Point(4, 22);
            this.tabFacturacion.Name = "tabFacturacion";
            this.tabFacturacion.Size = new System.Drawing.Size(801, 425);
            this.tabFacturacion.TabIndex = 2;
            this.tabFacturacion.Text = "Facturación";
            this.tabFacturacion.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Clave1_Grupo2.Properties.Resources.aaa;
            this.pictureBox4.Location = new System.Drawing.Point(302, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(155, 129);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // dgvFacturacion
            // 
            this.dgvFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturacion.Location = new System.Drawing.Point(3, 148);
            this.dgvFacturacion.Name = "dgvFacturacion";
            this.dgvFacturacion.Size = new System.Drawing.Size(626, 274);
            this.dgvFacturacion.TabIndex = 9;
            // 
            // groupBoxFacturacion
            // 
            this.groupBoxFacturacion.Controls.Add(this.btnConfirmarPago);
            this.groupBoxFacturacion.Controls.Add(this.txtMonto);
            this.groupBoxFacturacion.Controls.Add(this.lblMontoTotal);
            this.groupBoxFacturacion.Controls.Add(this.cmbMetodoPago);
            this.groupBoxFacturacion.Controls.Add(this.lblMetodoPago);
            this.groupBoxFacturacion.Controls.Add(this.cmbServicioPrestado);
            this.groupBoxFacturacion.Controls.Add(this.lblServicioPrestado);
            this.groupBoxFacturacion.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFacturacion.Name = "groupBoxFacturacion";
            this.groupBoxFacturacion.Size = new System.Drawing.Size(297, 139);
            this.groupBoxFacturacion.TabIndex = 0;
            this.groupBoxFacturacion.TabStop = false;
            this.groupBoxFacturacion.Text = "Facturación de Servicios";
            // 
            // btnConfirmarPago
            // 
            this.btnConfirmarPago.Location = new System.Drawing.Point(100, 98);
            this.btnConfirmarPago.Name = "btnConfirmarPago";
            this.btnConfirmarPago.Size = new System.Drawing.Size(100, 23);
            this.btnConfirmarPago.TabIndex = 6;
            this.btnConfirmarPago.Text = "Confirmar Pago";
            this.btnConfirmarPago.UseVisualStyleBackColor = true;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(100, 72);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 5;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Location = new System.Drawing.Point(32, 75);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(67, 13);
            this.lblMontoTotal.TabIndex = 4;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta Crédito",
            "Tarjeta Débito",
            "Bitcoin"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(99, 43);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(121, 21);
            this.cmbMetodoPago.TabIndex = 3;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(10, 45);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(89, 13);
            this.lblMetodoPago.TabIndex = 2;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cmbServicioPrestado
            // 
            this.cmbServicioPrestado.FormattingEnabled = true;
            this.cmbServicioPrestado.Items.AddRange(new object[] {
            "Cita Médica",
            "Compra de Alimentos",
            "Compra de Accesorios",
            "Medicamentos"});
            this.cmbServicioPrestado.Location = new System.Drawing.Point(99, 16);
            this.cmbServicioPrestado.Name = "cmbServicioPrestado";
            this.cmbServicioPrestado.Size = new System.Drawing.Size(121, 21);
            this.cmbServicioPrestado.TabIndex = 1;
            // 
            // lblServicioPrestado
            // 
            this.lblServicioPrestado.AutoSize = true;
            this.lblServicioPrestado.Location = new System.Drawing.Point(7, 20);
            this.lblServicioPrestado.Name = "lblServicioPrestado";
            this.lblServicioPrestado.Size = new System.Drawing.Size(93, 13);
            this.lblServicioPrestado.TabIndex = 0;
            this.lblServicioPrestado.Text = "Servicio Prestado:";
            // 
            // tabProductosServicios
            // 
            this.tabProductosServicios.Controls.Add(this.pictureBox1);
            this.tabProductosServicios.Controls.Add(this.groupBoxProductosServicios);
            this.tabProductosServicios.Location = new System.Drawing.Point(4, 22);
            this.tabProductosServicios.Name = "tabProductosServicios";
            this.tabProductosServicios.Size = new System.Drawing.Size(801, 425);
            this.tabProductosServicios.TabIndex = 3;
            this.tabProductosServicios.Text = "Producto/Servicios";
            this.tabProductosServicios.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clave1_Grupo2.Properties.Resources.perro_para_productos_y_servicios;
            this.pictureBox1.Location = new System.Drawing.Point(467, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxProductosServicios
            // 
            this.groupBoxProductosServicios.Controls.Add(this.btnActualizarProductos);
            this.groupBoxProductosServicios.Controls.Add(this.dgvProductos);
            this.groupBoxProductosServicios.Location = new System.Drawing.Point(6, 6);
            this.groupBoxProductosServicios.Name = "groupBoxProductosServicios";
            this.groupBoxProductosServicios.Size = new System.Drawing.Size(455, 198);
            this.groupBoxProductosServicios.TabIndex = 0;
            this.groupBoxProductosServicios.TabStop = false;
            this.groupBoxProductosServicios.Text = "Inventario de Productos y Servicios";
            // 
            // btnActualizarProductos
            // 
            this.btnActualizarProductos.Location = new System.Drawing.Point(181, 160);
            this.btnActualizarProductos.Name = "btnActualizarProductos";
            this.btnActualizarProductos.Size = new System.Drawing.Size(113, 23);
            this.btnActualizarProductos.TabIndex = 1;
            this.btnActualizarProductos.Text = "Actualizar Inventario";
            this.btnActualizarProductos.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreProducto,
            this.Descripcion,
            this.Precio,
            this.CantidadStock});
            this.dgvProductos.Location = new System.Drawing.Point(6, 19);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(443, 135);
            this.dgvProductos.TabIndex = 0;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Nombre del Producto";
            this.NombreProducto.Name = "NombreProducto";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // CantidadStock
            // 
            this.CantidadStock.HeaderText = "Cantidad en Stock";
            this.CantidadStock.Name = "CantidadStock";
            // 
            // tabCitas
            // 
            this.tabCitas.Controls.Add(this.pictureBox5);
            this.tabCitas.Controls.Add(this.dataGridView1);
            this.tabCitas.Controls.Add(this.gbCitas);
            this.tabCitas.Location = new System.Drawing.Point(4, 22);
            this.tabCitas.Name = "tabCitas";
            this.tabCitas.Size = new System.Drawing.Size(801, 425);
            this.tabCitas.TabIndex = 4;
            this.tabCitas.Text = "Citas";
            this.tabCitas.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Clave1_Grupo2.Properties.Resources.agendar_cita;
            this.pictureBox5.Location = new System.Drawing.Point(330, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(120, 105);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreMascota,
            this.FechaCita,
            this.Horario,
            this.Estado});
            this.dataGridView1.Location = new System.Drawing.Point(3, 207);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 209);
            this.dataGridView1.TabIndex = 1;
            // 
            // NombreMascota
            // 
            this.NombreMascota.HeaderText = "Nombre de Mascota";
            this.NombreMascota.Name = "NombreMascota";
            // 
            // FechaCita
            // 
            this.FechaCita.HeaderText = "Fecha de la Cita";
            this.FechaCita.Name = "FechaCita";
            // 
            // Horario
            // 
            this.Horario.HeaderText = "Horario";
            this.Horario.Name = "Horario";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // gbCitas
            // 
            this.gbCitas.Controls.Add(this.cmbMascotaCita);
            this.gbCitas.Controls.Add(this.cmbDuenoCita);
            this.gbCitas.Controls.Add(this.lblDueno);
            this.gbCitas.Controls.Add(this.btnCancelarCita);
            this.gbCitas.Controls.Add(this.btnAgendarCita);
            this.gbCitas.Controls.Add(this.btnModificarCita);
            this.gbCitas.Controls.Add(this.cmbHorarioCita);
            this.gbCitas.Controls.Add(this.lblHorario);
            this.gbCitas.Controls.Add(this.dtpFechaCita);
            this.gbCitas.Controls.Add(this.lblFechaCita);
            this.gbCitas.Controls.Add(this.lblMascota);
            this.gbCitas.Location = new System.Drawing.Point(6, 3);
            this.gbCitas.Name = "gbCitas";
            this.gbCitas.Size = new System.Drawing.Size(318, 198);
            this.gbCitas.TabIndex = 0;
            this.gbCitas.TabStop = false;
            this.gbCitas.Text = "Gestión de Citas";
            // 
            // cmbMascotaCita
            // 
            this.cmbMascotaCita.FormattingEnabled = true;
            this.cmbMascotaCita.Location = new System.Drawing.Point(110, 79);
            this.cmbMascotaCita.Name = "cmbMascotaCita";
            this.cmbMascotaCita.Size = new System.Drawing.Size(121, 21);
            this.cmbMascotaCita.TabIndex = 19;
            // 
            // cmbDuenoCita
            // 
            this.cmbDuenoCita.FormattingEnabled = true;
            this.cmbDuenoCita.Location = new System.Drawing.Point(110, 26);
            this.cmbDuenoCita.Name = "cmbDuenoCita";
            this.cmbDuenoCita.Size = new System.Drawing.Size(121, 21);
            this.cmbDuenoCita.TabIndex = 18;
            // 
            // lblDueno
            // 
            this.lblDueno.AutoSize = true;
            this.lblDueno.Location = new System.Drawing.Point(69, 30);
            this.lblDueno.Name = "lblDueno";
            this.lblDueno.Size = new System.Drawing.Size(42, 13);
            this.lblDueno.TabIndex = 17;
            this.lblDueno.Text = "Dueño:";
            // 
            // btnCancelarCita
            // 
            this.btnCancelarCita.Location = new System.Drawing.Point(172, 169);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCita.TabIndex = 16;
            this.btnCancelarCita.Text = "Cancelar";
            this.btnCancelarCita.UseVisualStyleBackColor = true;
            // 
            // btnAgendarCita
            // 
            this.btnAgendarCita.Location = new System.Drawing.Point(10, 169);
            this.btnAgendarCita.Name = "btnAgendarCita";
            this.btnAgendarCita.Size = new System.Drawing.Size(75, 23);
            this.btnAgendarCita.TabIndex = 15;
            this.btnAgendarCita.Text = "Agendar";
            this.btnAgendarCita.UseVisualStyleBackColor = true;
            // 
            // btnModificarCita
            // 
            this.btnModificarCita.Location = new System.Drawing.Point(91, 169);
            this.btnModificarCita.Name = "btnModificarCita";
            this.btnModificarCita.Size = new System.Drawing.Size(75, 23);
            this.btnModificarCita.TabIndex = 14;
            this.btnModificarCita.Text = "Modificar";
            this.btnModificarCita.UseVisualStyleBackColor = true;
            // 
            // cmbHorarioCita
            // 
            this.cmbHorarioCita.FormattingEnabled = true;
            this.cmbHorarioCita.Items.AddRange(new object[] {
            "10:00 AM",
            "11:00 AM",
            "12:00 AM",
            "2:00 PM"});
            this.cmbHorarioCita.Location = new System.Drawing.Point(110, 134);
            this.cmbHorarioCita.Name = "cmbHorarioCita";
            this.cmbHorarioCita.Size = new System.Drawing.Size(121, 21);
            this.cmbHorarioCita.TabIndex = 5;
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(7, 142);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(106, 13);
            this.lblHorario.TabIndex = 4;
            this.lblHorario.Text = "Horarios Disponibles:";
            // 
            // dtpFechaCita
            // 
            this.dtpFechaCita.Location = new System.Drawing.Point(110, 108);
            this.dtpFechaCita.Name = "dtpFechaCita";
            this.dtpFechaCita.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCita.TabIndex = 3;
            // 
            // lblFechaCita
            // 
            this.lblFechaCita.AutoSize = true;
            this.lblFechaCita.Location = new System.Drawing.Point(26, 113);
            this.lblFechaCita.Name = "lblFechaCita";
            this.lblFechaCita.Size = new System.Drawing.Size(87, 13);
            this.lblFechaCita.TabIndex = 2;
            this.lblFechaCita.Text = "Fecha de la Cita:";
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Location = new System.Drawing.Point(7, 82);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(106, 13);
            this.lblMascota.TabIndex = 0;
            this.lblMascota.Text = "Nombre de Mascota:";
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.groupBox1);
            this.tabUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Size = new System.Drawing.Size(801, 425);
            this.tabUsuarios.TabIndex = 5;
            this.tabUsuarios.Text = "Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.cmbTipoUsuario);
            this.groupBox1.Controls.Add(this.lblTipoUsuario);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.lblContraseña);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 244);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuarios";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(180, 164);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(58, 20);
            this.txtID.TabIndex = 20;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(161, 168);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 19;
            this.lblID.Text = "ID:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(230, 211);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 18;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // cmbTipoUsuario
            // 
            this.cmbTipoUsuario.FormattingEnabled = true;
            this.cmbTipoUsuario.Location = new System.Drawing.Point(83, 214);
            this.cmbTipoUsuario.Name = "cmbTipoUsuario";
            this.cmbTipoUsuario.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoUsuario.TabIndex = 17;
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.Location = new System.Drawing.Point(2, 217);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(83, 13);
            this.lblTipoUsuario.TabIndex = 16;
            this.lblTipoUsuario.Text = "Tipo de usuario:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(63, 191);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(100, 20);
            this.txtContraseña.TabIndex = 15;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(54, 166);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 14;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(2, 193);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 13;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(9, 168);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "Usuario:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(54, 117);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dirección:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(54, 93);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Teléfono:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.comboBox1.Location = new System.Drawing.Point(53, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sexo:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(53, 41);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Apellido:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(52, 17);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nombre:";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 455);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.tabControl1.ResumeLayout(false);
            this.tabCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.groupBoxClienteInfo.ResumeLayout(false);
            this.groupBoxClienteInfo.PerformLayout();
            this.tabMascota.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
            this.groupBoxMascotaInfo.ResumeLayout(false);
            this.groupBoxMascotaInfo.PerformLayout();
            this.tabFacturacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturacion)).EndInit();
            this.groupBoxFacturacion.ResumeLayout(false);
            this.groupBoxFacturacion.PerformLayout();
            this.tabProductosServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxProductosServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tabCitas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbCitas.ResumeLayout(false);
            this.gbCitas.PerformLayout();
            this.tabUsuarios.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCliente;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.GroupBox groupBoxClienteInfo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnActualizarCliente;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TabPage tabMascota;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvMascotas;
        private System.Windows.Forms.Button btnActualizarMascotas;
        private System.Windows.Forms.Button btnEliminarMascota;
        private System.Windows.Forms.Button btnModificarMascota;
        private System.Windows.Forms.Button btnIngresarMascota;
        private System.Windows.Forms.GroupBox groupBoxMascotaInfo;
        private System.Windows.Forms.ComboBox cmbDueno;
        private System.Windows.Forms.Label lblDueño;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblCastrado;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label lblRaza;
        private System.Windows.Forms.ComboBox cmbEspecie;
        private System.Windows.Forms.Label lblEspecie;
        private System.Windows.Forms.TextBox txtNombreMascota;
        private System.Windows.Forms.Label lblNombreMascota;
        private System.Windows.Forms.TabPage tabFacturacion;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView dgvFacturacion;
        private System.Windows.Forms.GroupBox groupBoxFacturacion;
        private System.Windows.Forms.Button btnConfirmarPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbServicioPrestado;
        private System.Windows.Forms.Label lblServicioPrestado;
        private System.Windows.Forms.TabPage tabProductosServicios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxProductosServicios;
        private System.Windows.Forms.Button btnActualizarProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadStock;
        private System.Windows.Forms.TabPage tabCitas;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.GroupBox gbCitas;
        private System.Windows.Forms.ComboBox cmbMascotaCita;
        private System.Windows.Forms.ComboBox cmbDuenoCita;
        private System.Windows.Forms.Label lblDueno;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Button btnAgendarCita;
        private System.Windows.Forms.Button btnModificarCita;
        private System.Windows.Forms.ComboBox cmbHorarioCita;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.DateTimePicker dtpFechaCita;
        private System.Windows.Forms.Label lblFechaCita;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
    }
}