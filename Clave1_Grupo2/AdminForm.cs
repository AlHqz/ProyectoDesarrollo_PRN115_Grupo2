using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private List<Mascota> listaMascotas = new List<Mascota>();
        private int idDuenoSeleccionado = -1;
        private bool enModoBusqueda = false;
        private List<Cliente> listaClientes = new List<Cliente>();
        private Timer timer;

        public AdminForm()
        {
            InitializeComponent();
            CargarClientes();
            CargarClientesMascotas();
            BloquearControles();
            cmbDueño.Enabled = true; // Mantener el ComboBox habilitado
            CargarClientesMascotas();
            dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;

            // Deshabilitar todos los campos de entrada por defecto
            DeshabilitarCampos();


            cmbSexo.Items.Add("Masculino");
            cmbSexo.Items.Add("Femenino");

            // Deshabilitar el ComboBox de sexo para que no sea editable
            cmbSexo.Enabled = false;
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

        // Evento del botón Modificar Cliente
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
                string query = "DELETE FROM clientes WHERE idClientes = @id";
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", clienteId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Cliente eliminado correctamente.");
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

                    // Aquí debes obtener la lista de mascotas desde tu fuente de datos
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
    }
}