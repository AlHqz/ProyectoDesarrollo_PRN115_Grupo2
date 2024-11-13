using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Clave1_Grupo2
{
    public partial class AdminForm : Form
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;");
        private List<Mascota> listaMascotas = new List<Mascota>();
        private int idDuenoSeleccionado = -1;
        private bool enModoBusqueda = false;
        private List<Cliente> listaClientes = new List<Cliente>();
        private Timer timer;
        private FacturacionDB facturacionDB;
        private Cita cita;
        private int idClienteSeleccionado = -1;

        public AdminForm()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            facturacionDB = new FacturacionDB(connectionString);
            cita = new Cita(connectionString);
            CargarClientes();
            CargarClientesMascotas();
            BloquearControles();
            cmbDueño.Enabled = true;
            CargarClientesMascotas();
            dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;
            DeshabilitarCampos();
            cmbSexo.Items.Add("Masculino");
            cmbSexo.Items.Add("Femenino");
            cmbSexo.Enabled = false;
            CargarClientesCita();
            ActualizarDataGridView();
            LoadData();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            CargarClientesCita();
        }
        private void CargarClientes()
        {
            string query = "SELECT * FROM clientes";
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                listaClientes.Clear(); // Limpia la lista antes de cargar nuevos datos
                foreach (DataRow row in dt.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(row["idClientes"]),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Telefono = row["telefono"].ToString(),
                        Direccion = row["direccion"].ToString(),
                        Email = row["email"].ToString(),
                        Sexo = row["sexo"].ToString()
                    };
                    listaClientes.Add(cliente);
                }

                dgvClientes.DataSource = dt; // Muestra los datos en el DataGridView
            }
        }


        private void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;

            // Deshabilitar ComboBox de sexo
            cmbSexo.Enabled = false;
        }

        // Habilita solo los campos permitidos para modificación
        private void HabilitarCamposModificables()
        {
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void BuscarClientes()
        {
            string nombreBuscado = txtNombre.Text.Trim();
            string apellidoBuscado = txtApellido.Text.Trim();

            string query = "SELECT * FROM clientes WHERE 1=1";
            if (!string.IsNullOrEmpty(nombreBuscado))
            {
                query += " AND nombre LIKE @nombre";
            }
            if (!string.IsNullOrEmpty(apellidoBuscado))
            {
                query += " AND apellido LIKE @apellido";
            }

            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (!string.IsNullOrEmpty(nombreBuscado))
                {
                    cmd.Parameters.AddWithValue("@nombre", "%" + nombreBuscado + "%");
                }
                if (!string.IsNullOrEmpty(apellidoBuscado))
                {
                    cmd.Parameters.AddWithValue("@apellido", "%" + apellidoBuscado + "%");
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                listaClientes.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(row["idClientes"]),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Telefono = row["telefono"].ToString(),
                        Direccion = row["direccion"].ToString(),
                        Email = row["email"].ToString(),
                        Sexo = row["sexo"].ToString()
                    };
                    listaClientes.Add(cliente);
                }

                dgvClientes.DataSource = dt; // Actualiza el DataGridView con los resultados
            }

            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!enModoBusqueda)
            {
                // Activar modo de búsqueda
                enModoBusqueda = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtNombre.Focus();
            }
            else
            {
                // Ejecutar búsqueda y luego desactivar modo de búsqueda
                BuscarClientes();
                enModoBusqueda = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtNombre.Clear();
                txtApellido.Clear();
            }
        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                HabilitarCamposModificables(); // Habilitar solo teléfono, dirección y email
            }
        }


        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["idClientes"].Value);
                string query = "UPDATE clientes SET telefono = @telefono, direccion = @direccion, email = @email WHERE idClientes = @id";
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@id", clienteId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Cliente actualizado correctamente.");
                CargarClientes(); // Refresca el DataGridView con todos los clientes después de actualizar
                DeshabilitarCampos();
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["idClientes"].Value);
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Paso 1: Eliminar registros en la tabla `usuarios`
                    string deleteUsuariosQuery = "DELETE FROM usuarios WHERE idClientes = @id";
                    using (MySqlCommand cmdUsuarios = new MySqlCommand(deleteUsuariosQuery, conn))
                    {
                        cmdUsuarios.Parameters.AddWithValue("@id", clienteId);
                        cmdUsuarios.ExecuteNonQuery();
                    }

                    // Paso 2: Eliminar el cliente en la tabla `clientes`
                    string deleteClientesQuery = "DELETE FROM clientes WHERE idClientes = @id";
                    using (MySqlCommand cmdClientes = new MySqlCommand(deleteClientesQuery, conn))
                    {
                        cmdClientes.Parameters.AddWithValue("@id", clienteId);
                        cmdClientes.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                MessageBox.Show("Cliente y sus usuarios eliminados correctamente.");
                CargarClientes();
                DeshabilitarCampos();
            }
            }
            // Evento que actualiza los campos en el GroupBox cuando se selecciona un cliente en el DataGridView
            private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                object cellValue = dgvClientes.SelectedRows[0].Cells["idClientes"].Value;

                if (cellValue != DBNull.Value)
                {
                    int clienteId = Convert.ToInt32(cellValue);

                    Cliente clienteSeleccionado = listaClientes.FirstOrDefault(c => c.IdCliente == clienteId);

                    if (clienteSeleccionado != null)
                    {
                        txtNombre.Text = clienteSeleccionado.Nombre;
                        txtApellido.Text = clienteSeleccionado.Apellido;
                        txtTelefono.Text = clienteSeleccionado.Telefono;
                        txtDireccion.Text = clienteSeleccionado.Direccion;
                        txtEmail.Text = clienteSeleccionado.Email;

                        if (clienteSeleccionado.Sexo == "Masculino")
                        {
                            cmbSexo.SelectedIndex = 0;
                        }
                        else if (clienteSeleccionado.Sexo == "Femenino")
                        {
                            cmbSexo.SelectedIndex = 1;
                        }
                    }
                }
                else
                {
                    // Si el valor es DBNull, puedes decidir qué hacer. Por ejemplo:
                    MessageBox.Show("El ID del cliente es nulo. Verifique los datos seleccionados.");
                }
            }
            else
            {
            }
        }
        //Terminar sobre clientes


        //Inicia Mascotas
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
        private void CargarClientesMascotas()
        {
            try
            {
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT idClientes, CONCAT(nombre, ' ', apellido) AS nombreCompleto FROM clientes", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    var clientes = new List<KeyValuePair<int, string>>();
                    while (reader.Read())
                    {
                        clientes.Add(new KeyValuePair<int, string>(
                            Convert.ToInt32(reader["idClientes"]),
                            reader["nombreCompleto"].ToString()
                        ));
                    }
                    reader.Close();

                    // Actualizar el ComboBox solo si hay cambios
                    if (!clientes.SequenceEqual(cmbDueño.Items.Cast<KeyValuePair<int, string>>().ToList()))
                    {
                        cmbDueño.Items.Clear();
                        foreach (var cliente in clientes)
                        {
                            cmbDueño.Items.Add(cliente);
                        }
                        cmbDueño.DisplayMember = "Value";
                        cmbDueño.ValueMember = "Key";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
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

                    dgvMascotas.DataSource = dt;

                    // Actualizar la lista de mascotas
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
        private void cmbDueño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDueño.SelectedItem != null)
            {
                var selectedCliente = (KeyValuePair<int, string>)cmbDueño.SelectedItem;
                idDuenoSeleccionado = selectedCliente.Key;
                CargarMascotas(idDuenoSeleccionado);

                // Si hay al menos una mascota, selecciona la primera y muestra sus datos
                if (dgvMascotas.Rows.Count > 0)
                {
                    dgvMascotas.Rows[0].Selected = true;
                    MostrarDatosMascotaSeleccionada();
                }
            }
        }

        private void MostrarDatosMascotaSeleccionada()
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMascotas.SelectedRows[0];

                // Verifica que cada celda no sea null antes de asignar los valores
                txtNombreMascota.Text = row.Cells["nombre"]?.Value?.ToString() ?? string.Empty;
                cmbEspecie.Text = row.Cells["especie"]?.Value?.ToString() ?? string.Empty;
                txtRaza.Text = row.Cells["raza"]?.Value?.ToString() ?? string.Empty;
                txtEdad.Text = row.Cells["edad"]?.Value?.ToString() ?? string.Empty;
                txtPeso.Text = row.Cells["peso"]?.Value?.ToString() ?? string.Empty;
                dtpFechaNacimiento.Value = row.Cells["fechaNacimiento"]?.Value != null ? Convert.ToDateTime(row.Cells["fechaNacimiento"].Value) : DateTime.Now;
                checkBox1.Checked = row.Cells["castrado"]?.Value != null && Convert.ToBoolean(row.Cells["castrado"].Value);
            }
        }

        private void dgvMascotas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                object cellValue = dgvMascotas.SelectedRows[0].Cells["idMascotas"].Value;

                if (cellValue != DBNull.Value)
                {
                    int mascotaId = Convert.ToInt32(cellValue);

                    Mascota mascotaSeleccionada = listaMascotas.FirstOrDefault(m => m.IdMascotas == mascotaId);

                    if (mascotaSeleccionada != null)
                    {
                        txtNombreMascota.Text = mascotaSeleccionada.NombreMascota;
                        cmbEspecie.Text = mascotaSeleccionada.Especie;
                        txtRaza.Text = mascotaSeleccionada.Raza;
                        txtEdad.Text = mascotaSeleccionada.EdadEnMeses.ToString();
                        txtPeso.Text = mascotaSeleccionada.Peso.ToString();
                        dtpFechaNacimiento.Value = mascotaSeleccionada.FechaNacimiento;
                        checkBox1.Checked = mascotaSeleccionada.Castrado;
                    }
                }
                else
                {
                    // Si el valor es DBNull, puedes decidir qué hacer. Por ejemplo:
                    MessageBox.Show("El ID de la mascota es nulo. Verifique los datos seleccionados.");
                }
            }
        }

        private void btnIngresarMascota_Click(object sender, EventArgs e)
        {
            if (idDuenoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un dueño para registrar una mascota.");
                return;
            }

            // Habilitar todos los controles
            HabilitarControles();

            // Limpiar todos los controles excepto el ComboBox del dueño
            LimpiarControles();
            txtNombreMascota.Focus();
        }

        private void btnModificarMascota_Click(object sender, EventArgs e)
        {
            txtPeso.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void btnActualizarMascotas_Click(object sender, EventArgs e)
        {
            if (idDuenoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un dueño para registrar o actualizar una mascota.");
                return;
            }

            if (dgvMascotas.SelectedRows.Count > 0 && dgvMascotas.SelectedRows[0].Cells["idMascotas"].Value != null)
            {
                // Actualizar mascota existente
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
                // Ingresar nueva mascota
                Mascota nuevaMascota = new Mascota
                {
                    IdDueno = idDuenoSeleccionado,
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

            CargarMascotas(idDuenoSeleccionado);
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
                CargarMascotas(idDuenoSeleccionado);

            }

            timer = new Timer();
            timer.Interval = 5000; // Intervalo en milisegundos (5 segundos)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CargarClientesMascotas();
        }

        private void btnVerificarConexion_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Cerrado de sesión con éxito.");
            Application.Exit();
        }

        //Iniciar Pestaña de ProductosStock

        private void btnActualizarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM inventario";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvProductos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //Terminar lo de productosStock


        //Inicia pestaña Facturacion
        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            string servicioPrestado = cmbServicioPrestado.SelectedItem.ToString();
            string metodoPago = cmbMetodoPago.SelectedItem.ToString();
            decimal monto = decimal.Parse(txtMonto.Text);

            facturacionDB.InsertarFacturacion(servicioPrestado, metodoPago, monto);

            LoadData();
            ClearFields();
        }

        private void LoadData()
        {
            try
            {
                DataTable table = facturacionDB.ObtenerFacturaciones();
                dgvFacturacion.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            cmbServicioPrestado.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = -1;
            txtMonto.Clear();
        }

        //Finaliza pestaña Facturacion

        //Inicia pestaña citas
        private void CargarClientesCita()
        {
            cita.CargarClientesCita(cmbDueñoCita);
        }

        private void CargarMascotasCita(int idCliente)
        {
            cmbMascotaCita.Items.Clear();
            cita.CargarMascotasCita(idCliente, cmbMascotaCita);
        }

        private void CargarHorarios()
        {
            DateTime fechaSeleccionada = dtpFechaCita.Value;
            cmbHorarioCita.Items.Clear();

            List<string> horarios = cita.CargarHorarios(fechaSeleccionada);
            foreach (string hora in horarios)
            {
                cmbHorarioCita.Items.Add(hora);
            }
        }
        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            if (cmbDueñoCita.SelectedItem != null && cmbMascotaCita.SelectedItem != null && cmbHorarioCita.SelectedItem != null)
            {
                int idCliente = ((Cliente)cmbDueñoCita.SelectedItem).IdCliente;
                int idMascota = ((Mascota)cmbMascotaCita.SelectedItem).IdMascotas;
                DateTime fecha = dtpFechaCita.Value;
                TimeSpan hora = TimeSpan.Parse(cmbHorarioCita.SelectedItem.ToString());

                cita.AgendarCita(idCliente, idMascota, fecha, hora);
                ActualizarDataGridView();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos para agendar la cita.");
            }
        }

        private void btnModificarCita_Click(object sender, EventArgs e)
        {
            int idCita = ObtenerIdCitaSeleccionada();
            if (idCita != -1)
            {
                DateTime nuevaFecha = dtpFechaCita.Value;
                TimeSpan nuevaHora = TimeSpan.Parse(cmbHorarioCita.SelectedItem.ToString());

                cita.ModificarCita(idCita, nuevaFecha, nuevaHora);
                ActualizarDataGridView();
                LimpiarCampos();
            }
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            int idCita = ObtenerIdCitaSeleccionada();
            cita.CancelarCita(idCita);

            MessageBox.Show("Su cita ha sido cancelada.");
            ActualizarDataGridView();
            LimpiarCampos();
        }
        private void ActualizarDataGridView()
        {
            dgvCitas.DataSource = cita.ObtenerCitas();
        }
        private void cmbDueñoCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDueñoCita.SelectedItem != null)
            {
                Cliente clienteSeleccionado = (Cliente)cmbDueñoCita.SelectedItem;
                idClienteSeleccionado = clienteSeleccionado.IdCliente;

                // Cargar nombres de las mascotas asociadas al cliente seleccionado
                CargarMascotasCita(idClienteSeleccionado);
            }
        }

        private void dtpFechaCita_ValueChanged(object sender, EventArgs e)
        {
            CargarHorarios();
        }
        private void LimpiarCampos()
        {
            cmbDueñoCita.SelectedIndex = -1;
            cmbMascotaCita.SelectedIndex = -1;
            dtpFechaCita.Value = DateTime.Now;
            cmbHorarioCita.Items.Clear();
        }

        private int ObtenerIdCitaSeleccionada()
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCitas.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["idCita"].Value);
            }
            else
            {
                MessageBox.Show("No hay ninguna cita seleccionada.");
                return -1;
            }
        }

        //Pestaña usuarios

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Paso 1: Insertar los datos del cliente en la tabla 'clientes'
                string queryCliente = "INSERT INTO clientes (nombre, apellido, sexo, telefono, direccion, email) " +
                                      "VALUES (@nombre, @apellido, @sexo, @telefono, @direccion, @email)";

                using (MySqlCommand cmd = new MySqlCommand(queryCliente, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombreInfo.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtApellidoInfo.Text);
                    cmd.Parameters.AddWithValue("@sexo", cmbSexoInfo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefonoInfo.Text);
                    cmd.Parameters.AddWithValue("@direccion", txtDireccionInfo.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmailInfo.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                // Paso 2: Obtener el idCliente recién insertado
                string queryGetIdCliente = "SELECT LAST_INSERT_ID()";
                int idCliente = 0;
                using (MySqlCommand cmd = new MySqlCommand(queryGetIdCliente, connection))
                {
                    connection.Open();
                    idCliente = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                }

                // Paso 3: Insertar los datos del usuario en la tabla 'usuarios'
                string queryUsuario = "INSERT INTO usuarios (username, password, rol, idClientes) " +
                                      "VALUES (@username, @password, @rol, @idClientes)";
                
                using (MySqlCommand cmd = new MySqlCommand(queryUsuario, connection))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsuarioInfo.Text);
                    cmd.Parameters.AddWithValue("@password", txtContraseña.Text); // Recuerda encriptar la contraseña si es necesario
                    cmd.Parameters.AddWithValue("@rol", cmbTipoUsuario.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@idClientes", idCliente);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Usuario registrado exitosamente.");

                // Limpiar los campos después del registro exitoso
                LimpiarCamposUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        // Función para limpiar los campos de entrada
        private void LimpiarCamposUsuarios()
        {
            txtNombreInfo.Text = "";
            txtApellidoInfo.Text = "";
            cmbSexoInfo.SelectedIndex = -1; // Deselecciona el ComboBox
            txtTelefonoInfo.Text = "";
            txtDireccionInfo.Text = "";
            txtEmailInfo.Text = "";
            txtUsuarioInfo.Text = "";
            txtID.Text = "";
            txtContraseña.Text = "";
            cmbTipoUsuario.SelectedIndex = -1; // Deselecciona el ComboBox
        }
    }
}