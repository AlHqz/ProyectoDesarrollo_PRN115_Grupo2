using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Clave1_Grupo2
{
    public partial class ClienteForm : Form
    {
        private string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
        private int idClientes;
        private string nombreCompleto;
        private int idMascotaSeleccionada;
        private Cliente clienteActual;
        private List<Mascota> listaMascotas = new List<Mascota>();
        private int idClienteActual = -1;
        private List<CarritoItem> carrito = new List<CarritoItem>();
        private Dictionary<string, double> productosEnInventario = new Dictionary<string, double>();
        private int idCitaSeleccionada;
        public ClienteForm(int idClientes, string nombreCompleto)
        {
            InitializeComponent();
            this.idClientes = idClientes;
            this.nombreCompleto = nombreCompleto;
            this.idClienteActual = idClientes;
            CargarDatosCliente();
            CargarProductos();
            ConfigurarComboBoxes();
            btnModificarCliente.Text = "Modificar";
            cmbDueño.Items.Add(nombreCompleto);
            cmbDueño.SelectedIndex = 0;
            cmbDueño.Enabled = false;
            CargarMascotas(idClienteActual);
            CargarMascotasCliente(idClienteActual);
            CargarHorariosDisponibles();
            BloquearControles();
            cmbTipoServicio.SelectedIndex = -1;
            cmbHorarioCita.SelectedIndex = -1;
        }

        private void CargarDatosCliente()
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta para obtener los datos del cliente basándose en el idClientes
                    string query = "SELECT nombre, apellido, sexo, telefono, direccion, email FROM clientes WHERE idClientes = @idClientes";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idClientes", idClientes);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenar los campos del formulario con los datos del cliente
                                txtNombre.Text = reader["nombre"].ToString();
                                txtApellido.Text = reader["apellido"].ToString();
                                cmbSexo.Text = reader["sexo"].ToString();
                                txtTelefono.Text = reader["telefono"].ToString();
                                txtDireccion.Text = reader["direccion"].ToString();
                                txtEmail.Text = reader["email"].ToString();

                                // Bloquear todos los campos inicialmente
                                txtNombre.Enabled = false;
                                txtApellido.Enabled = false;
                                cmbSexo.Enabled = false;
                                txtTelefono.Enabled = false;
                                txtDireccion.Enabled = false;
                                txtEmail.Enabled = false;

                                // Guardar los datos en clienteActual para usarlos posteriormente
                                clienteActual = new Cliente
                                {
                                    IdCliente = idClientes,
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    Email = reader["email"].ToString(),
                                    Sexo = reader["sexo"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
                }
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (btnModificarCliente.Text == "Modificar")
            {
                // Habilitar solo los campos que pueden ser modificados
                txtTelefono.Enabled = true;
                txtDireccion.Enabled = true;
                txtEmail.Enabled = true;

                // Cambiar el texto del botón a "Guardar"
                btnModificarCliente.Text = "Guardar";
            }
            else
            {
                // Guardar cambios en la base de datos
                ActualizarDatosCliente();

                // Deshabilitar los campos después de editar
                txtTelefono.Enabled = false;
                txtDireccion.Enabled = false;
                txtEmail.Enabled = false;

                // Cambiar el texto del botón de nuevo a "Modificar"
                btnModificarCliente.Text = "Modificar";

                MessageBox.Show("Has modificado tus datos correctamente.");
            }
        }

        private void ActualizarDatosCliente()
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para actualizar los datos del cliente
                    string query = "UPDATE clientes SET telefono = @telefono, direccion = @direccion, email = @email WHERE idClientes = @idClientes";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@idClientes", idClientes);

                        cmd.ExecuteNonQuery();
                    }

                    // Actualizar el objeto clienteActual con los nuevos datos
                    clienteActual.Telefono = txtTelefono.Text.Trim();
                    clienteActual.Direccion = txtDireccion.Text.Trim();
                    clienteActual.Email = txtEmail.Text.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del cliente: " + ex.Message);
                }
            }

            //inici logica pestaña Mascota

        }
        private void BloquearControles()
        {
            txtNombreMascota.Enabled = false;
            cmbEspecie.Enabled = false;
            txtRaza.Enabled = false;
            txtEdad.Enabled = false;
            txtPeso.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void HabilitarControles()
        {
            txtNombreMascota.Enabled = true;
            cmbEspecie.Enabled = true;
            txtRaza.Enabled = true;
            txtEdad.Enabled = true;
            txtPeso.Enabled = true;
            dtpFechaNacimiento.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void LimpiarControles()
        {
            txtNombreMascota.Text = string.Empty;
            cmbEspecie.SelectedIndex = -1;
            txtRaza.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtPeso.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Now;
            checkBox1.Checked = false;
        }
        private void CargarMascotas(int idCliente)
        {
            try
            {
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT idMascotas, nombre, especie, raza, `edad (meses)` AS edad, `peso (kg)` AS peso, fechaNacimiento, castrado FROM mascotas WHERE idClientes = @idClientes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idClientes", idCliente);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Asigna el DataTable al DataGridView
                    dgvMascotas.DataSource = dt;

                    // Actualiza la lista de mascotas
                    listaMascotas.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        listaMascotas.Add(new Mascota
                        {
                            IdMascotas = Convert.ToInt32(row["idMascotas"]),
                            NombreMascota = row["nombre"].ToString(),
                            Especie = row["especie"].ToString(),
                            Raza = row["raza"].ToString(),
                            EdadEnMeses = Convert.ToInt32(row["edad"]),
                            Peso = Convert.ToDouble(row["peso"]),
                            FechaNacimiento = Convert.ToDateTime(row["fechaNacimiento"]),
                            Castrado = Convert.ToBoolean(row["castrado"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mascotas: " + ex.Message);
            }
        }

        // Muestra los detalles de la mascota seleccionada en los controles de edición
        private void MostrarDatosMascotaSeleccionada()
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMascotas.SelectedRows[0];
                txtNombreMascota.Text = row.Cells["nombre"]?.Value?.ToString() ?? string.Empty;
                cmbEspecie.Text = row.Cells["especie"]?.Value?.ToString() ?? string.Empty;
                txtRaza.Text = row.Cells["raza"]?.Value?.ToString() ?? string.Empty;
                txtEdad.Text = row.Cells["edad"]?.Value?.ToString() ?? string.Empty;
                txtPeso.Text = row.Cells["peso"]?.Value?.ToString() ?? string.Empty;
                dtpFechaNacimiento.Value = row.Cells["fechaNacimiento"]?.Value != null ? Convert.ToDateTime(row.Cells["fechaNacimiento"].Value) : DateTime.Now;
                checkBox1.Checked = row.Cells["castrado"]?.Value != null && Convert.ToBoolean(row.Cells["castrado"].Value);

                BloquearControles();
            }
        }

        private void dgvMascotas_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosMascotaSeleccionada();
        }

        private void btnIngresarMascota_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            LimpiarControles();
            txtNombreMascota.Focus();
        }

        private void btnModificarMascota_Click(object sender, EventArgs e)
        {
            txtPeso.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count > 0 && dgvMascotas.SelectedRows[0].Cells["idMascotas"].Value != null)
            {
                int idMascota = Convert.ToInt32(dgvMascotas.SelectedRows[0].Cells["idMascotas"].Value);

                string query = "UPDATE mascotas SET `peso (kg)` = @peso, castrado = @castrado WHERE idMascotas = @idMascotas";
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@peso", double.Parse(txtPeso.Text));
                    cmd.Parameters.AddWithValue("@castrado", checkBox1.Checked);
                    cmd.Parameters.AddWithValue("@idMascotas", idMascota);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Datos de la mascota actualizados.");
            }
            else
            {
                Mascota nuevaMascota = new Mascota
                {
                    IdDueno = idClienteActual,
                    NombreMascota = txtNombreMascota.Text,
                    Especie = cmbEspecie.Text,
                    Raza = txtRaza.Text,
                    EdadEnMeses = int.Parse(txtEdad.Text),
                    Peso = double.Parse(txtPeso.Text),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Castrado = checkBox1.Checked
                };

                string query = "INSERT INTO mascotas (idClientes, nombre, especie, raza, `edad (meses)`, `peso (kg)`, fechaNacimiento, castrado) " +
                               "VALUES (@idClientes, @nombre, @especie, @raza, @edad, @peso, @fechaNacimiento, @castrado)";
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idClientes", nuevaMascota.IdDueno);
                    cmd.Parameters.AddWithValue("@nombre", nuevaMascota.NombreMascota);
                    cmd.Parameters.AddWithValue("@especie", nuevaMascota.Especie);
                    cmd.Parameters.AddWithValue("@raza", nuevaMascota.Raza);
                    cmd.Parameters.AddWithValue("@edad", nuevaMascota.EdadEnMeses);
                    cmd.Parameters.AddWithValue("@peso", nuevaMascota.Peso);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", nuevaMascota.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@castrado", nuevaMascota.Castrado);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Mascota registrada exitosamente.");
            }

            CargarMascotas(idClienteActual);
            BloquearControles();
        }

        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                int idMascota = Convert.ToInt32(dgvMascotas.SelectedRows[0].Cells["idMascotas"].Value);

                string query = "DELETE FROM mascotas WHERE idMascotas = @idMascotas";
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idMascotas", idMascota);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Mascota eliminada exitosamente.");
                CargarMascotas(idClienteActual);
            }
        }
        //inicia pestaña Compras
        private void ConfigurarComboBoxes()
        {
            cmbCategoria.Items.AddRange(new string[] { "Medicamentos", "Alimentos", "Otros" });
            cmbCategoria.SelectedIndex = -1; // No seleccionar nada al inicio

            cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta de Crédito", "Tarjeta de Débito", "Bitcoin" });
            cmbMetodoPago.SelectedIndex = -1; // No seleccionar nada al inicio
        }
        private void CargarProductos()
        {
            string query = "SELECT `Nombre Producto`, `Precio ($)` FROM inventario";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    productosEnInventario.Clear();
                    cmbProductoSeleccionado.Items.Clear();

                    while (reader.Read())
                    {
                        string nombreProducto = reader["Nombre Producto"].ToString();
                        double precio = Convert.ToDouble(reader["Precio ($)"]);
                        productosEnInventario.Add(nombreProducto, precio);
                        cmbProductoSeleccionado.Items.Add(nombreProducto);
                    }
                }
            }
            cmbProductoSeleccionado.SelectedIndex = -1; // No seleccionar nada al inicio
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            // Validar selección de categoría y producto
            if (cmbCategoria.SelectedItem == null || cmbProductoSeleccionado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una categoría y un producto.");
                return;
            }

            string categoria = cmbCategoria.SelectedItem.ToString();
            string nombreProducto = cmbProductoSeleccionado.SelectedItem.ToString();
            double precio = productosEnInventario[nombreProducto];
            int cantidad = (int)nudCantidad.Value;

            // Agregar el item al carrito
            CarritoItem nuevoItem = new CarritoItem(categoria, nombreProducto, precio, cantidad);
            carrito.Add(nuevoItem);

            MessageBox.Show("Producto agregado al carrito.");

            // Limpiar controles de entrada
            cmbCategoria.SelectedIndex = -1;
            cmbProductoSeleccionado.SelectedIndex = -1;
            nudCantidad.Value = 1;

            // Actualizar DataGridView y monto total
            ActualizarCarrito();
            CalcularMontoTotal();
        }
        private void CalcularMontoTotal()
        {
            double montoTotal = 0;
            foreach (var item in carrito)
            {
                montoTotal += item.Subtotal;
            }
            txtMontoTotal.Text = montoTotal.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void ActualizarCarrito()
        {
            dgvProductos.Rows.Clear();

            foreach (var item in carrito)
            {
                dgvProductos.Rows.Add(item.Categoria, item.NombreProducto, item.Precio.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")), item.Cantidad, item.Subtotal.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")));
            }
        }

        private void btnRealizarCompra_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agrega productos antes de realizar la compra.");
                return;
            }

            if (cmbMetodoPago.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un método de pago.");
                return;
            }

            string metodoPago = cmbMetodoPago.SelectedItem.ToString();
            double montoTotal = 0;
            foreach (var item in carrito)
            {
                montoTotal += item.Subtotal;
            }

            MessageBox.Show($"Gracias por su compra. Monto total: ${montoTotal:F2}. Has pagado con {metodoPago}.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar el carrito y actualizar la interfaz
            carrito.Clear();
            ActualizarCarrito();
            CalcularMontoTotal();
            cmbMetodoPago.SelectedIndex = -1;
        }

        //inicia pestaña citas
        private void CargarMascotasCliente(int idCliente)
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT idMascotas, nombre FROM mascotas WHERE idClientes = @idCliente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbNombreMascota.Items.Clear();

                        while (reader.Read())
                        {
                            int idMascota = reader.GetInt32("idMascotas");
                            string nombreMascota = reader.GetString("nombre");

                            cmbNombreMascota.Items.Add(new { Id = idMascota, Nombre = nombreMascota });
                        }
                    }
                }
            }

            cmbNombreMascota.DisplayMember = "Nombre";
            cmbNombreMascota.ValueMember = "Id";
        }
        private int ObtenerIdMascotaSeleccionada()
        {
            if (cmbNombreMascota.SelectedItem != null)
            {
                dynamic selectedItem = cmbNombreMascota.SelectedItem;
                return selectedItem.Id;
            }
            return -1; // Retorna -1 si no se selecciona ninguna mascota
        }
        private void CargarHorariosDisponibles()
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT idHorario, Hora FROM horarios WHERE Disponible = 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idHorario = reader.GetInt32("idHorario");
                        TimeSpan hora = reader.GetTimeSpan("Hora");

                        // Convertir TimeSpan a string con formato "HH:mm"
                        string horaFormatted = hora.ToString(@"hh\:mm");

                        cmbHorarioCita.Items.Add(new { Id = idHorario, Hora = horaFormatted });
                    }
                }
            }

            cmbHorarioCita.DisplayMember = "Hora";
            cmbHorarioCita.ValueMember = "Id";
        }
        private void cmbNombreMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreMascota.SelectedItem != null)
            {
                dynamic selectedMascota = cmbNombreMascota.SelectedItem;
                txtNombreMascotaCita.Text = selectedMascota.Id.ToString(); // Muestra el ID de la mascota
                idMascotaSeleccionada = selectedMascota.Id; // Actualizar idMascotaSeleccionada
            }
        }
        private void AgendarCita()
        {
            if (cmbNombreMascota.SelectedItem == null || cmbHorarioCita.SelectedItem == null || cmbTipoServicio.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona la mascota, horario y tipo de servicio.");
                return;
            }

            dynamic selectedMascota = cmbNombreMascota.SelectedItem;
            int idMascota = selectedMascota.Id;
            DateTime fechaCita = dtpFechaCita.Value.Date; // Solo la fecha
            dynamic horarioSeleccionado = cmbHorarioCita.SelectedItem;
            string horaCita = horarioSeleccionado.Hora; // Horario en formato string "HH:mm"
            string tipoServicio = cmbTipoServicio.SelectedItem.ToString();

            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO cita (idClientes, idMascotas, Fecha, Hora, Estado, TipoServicio) VALUES (@idClientes, @idMascotas, @Fecha, @Hora, 'Confirmado', @TipoServicio)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idClientes", idClienteActual);
                    cmd.Parameters.AddWithValue("@idMascotas", idMascota);
                    cmd.Parameters.AddWithValue("@Fecha", fechaCita);
                    cmd.Parameters.AddWithValue("@Hora", horaCita); // Guardar la hora seleccionada correctamente
                    cmd.Parameters.AddWithValue("@TipoServicio", tipoServicio);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cita agendada exitosamente.");
                }
            }

            CargarCitas(); // Actualiza el DataGridView con las citas
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            try
            {
                if (idMascotaSeleccionada == 0 || cmbHorarioCita.SelectedItem == null || string.IsNullOrEmpty(cmbTipoServicio.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }

                // Obtén el horario seleccionado y otros detalles
                var horarioSeleccionado = (dynamic)cmbHorarioCita.SelectedItem;
                int idHorario = horarioSeleccionado.Id;
                string horaSeleccionada = horarioSeleccionado.Hora;  // Asegúrate de que aquí obtienes la hora como string o TimeSpan
                DateTime fechaCita = dtpFechaCita.Value;
                string tipoServicio = cmbTipoServicio.Text;

                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificación de duplicados
                    string verificarDuplicado = "SELECT COUNT(*) FROM cita WHERE idMascotas = @idMascotas AND Fecha = @Fecha AND Hora = @Hora";
                    using (MySqlCommand verificarCmd = new MySqlCommand(verificarDuplicado, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@idMascotas", idMascotaSeleccionada);
                        verificarCmd.Parameters.AddWithValue("@Fecha", fechaCita);
                        verificarCmd.Parameters.AddWithValue("@Hora", horaSeleccionada);

                        int existeCita = Convert.ToInt32(verificarCmd.ExecuteScalar());
                        if (existeCita > 0)
                        {
                            MessageBox.Show("Ya existe una cita en este horario para esta mascota.");
                            return;
                        }
                    }

                    // Inserción de la cita en la base de datos
                    string query = "INSERT INTO cita (idClientes, idMascotas, Fecha, Hora, Estado, TipoServicio) VALUES (@idClientes, @idMascotas, @Fecha, @Hora, 'Confirmado', @TipoServicio)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idClientes", idClientes);
                        cmd.Parameters.AddWithValue("@idMascotas", idMascotaSeleccionada);
                        cmd.Parameters.AddWithValue("@Fecha", fechaCita);
                        cmd.Parameters.AddWithValue("@Hora", horaSeleccionada);  // Guardamos la hora específica seleccionada
                        cmd.Parameters.AddWithValue("@TipoServicio", tipoServicio);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cita agendada exitosamente.");
                    }
                }

                // Actualiza el DataGridView después de agendar la cita
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agendar la cita: " + ex.Message);
            }
        }
        private void CargarCitas()
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT c.idCita, m.nombre AS NombreMascota, c.Fecha, c.Hora, c.Estado, c.TipoServicio " +
                               "FROM cita c " +
                               "INNER JOIN mascotas m ON c.idMascotas = m.idMascotas " +
                               "WHERE c.idClientes = @idClientes";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idClientes", idClienteActual);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvCitas.Rows.Clear(); // Limpiar filas anteriores

                        while (reader.Read())
                        {
                            int idCita = reader.GetInt32("idCita"); // Asegúrate de que esta columna exista en tu consulta
                            string nombreMascota = reader.GetString("NombreMascota");
                            DateTime fecha = reader.GetDateTime("Fecha");
                            TimeSpan hora = reader.GetTimeSpan("Hora"); // Obtener el valor como TimeSpan
                            string horaStr = hora.ToString(@"hh\:mm"); // Formato de hora
                            string estado = reader.GetString("Estado");
                            string tipoServicio = reader.GetString("TipoServicio");

                            // Agregar los datos en el orden correcto, incluyendo idCita
                            dgvCitas.Rows.Add(idCita, nombreMascota, fecha.ToShortDateString(), horaStr, estado, tipoServicio);
                        }
                    }
                }
            }
        }
        private void dgvCitas_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada
            if (dgvCitas.CurrentRow != null)
            {
                // Selecciona la fila actual
                DataGridViewRow filaSeleccionada = dgvCitas.CurrentRow;

                // Asigna los valores de la fila a los controles correspondientes
                cmbNombreMascota.Text = filaSeleccionada.Cells["NombreMascota"].Value.ToString(); // Asegúrate de que el nombre de la columna sea correcto
                dtpFechaCita.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value); // Asegúrate de que el nombre de la columna sea correcto
                cmbHorarioCita.Text = filaSeleccionada.Cells["Hora"].Value.ToString(); // Asegúrate de que el nombre de la columna sea correcto
                cmbTipoServicio.Text = filaSeleccionada.Cells["TipoServicio"].Value.ToString(); // Asegúrate de que el nombre de la columna sea correcto

                // Aquí se puede obtener el ID de la cita seleccionada
                idCitaSeleccionada = Convert.ToInt32(filaSeleccionada.Cells["idCita"].Value); // Asegúrate de que el nombre de la columna sea correcto

            }
        }
    }
}