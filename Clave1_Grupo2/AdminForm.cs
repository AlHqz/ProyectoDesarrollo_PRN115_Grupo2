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

namespace Clave1_Grupo2
{
    public partial class AdminForm : Form
    {
        private bool enModoBusqueda = false;
        private List<Cliente> listaClientes = new List<Cliente>();
        public AdminForm()
        {
            InitializeComponent();
            CargarClientes(); // Cargar todos los clientes al abrir el formulario
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

        private MascotaDAO mascotaDAO = new MascotaDAO();

        private void CargarMascotas(int idCliente)
        {
            List<Mascota> mascotas = mascotaDAO.ObtenerMascotasPorCliente(idCliente);
            dgvMascotas.DataSource = mascotas;
        }

        private void btnIngresarMascota_Click(object sender, EventArgs e)
        {
            Mascota nuevaMascota = new Mascota
            {
                Nombre = txtNombreMascota.Text,
                Raza = txtRaza.Text,
                Especie = cmbEspecie.SelectedItem.ToString(),
                Edad = int.Parse(txtEdad.Text),
                Peso = decimal.Parse(txtPeso.Text),
                FechaNacimiento = dtpFechaNacimiento.Value,
                Castrado = checkBox1.Checked,
                IdCliente = ((Cliente)cmbDueno.SelectedItem).IdCliente // Asegúrate de tener el cliente seleccionado
            };

            if (mascotaDAO.InsertarMascota(nuevaMascota))
            {
                MessageBox.Show("Mascota ingresada correctamente.");
                CargarMascotas(nuevaMascota.IdCliente);
            }
            else
            {
                MessageBox.Show("Error al ingresar la mascota.");
            }
        }

        private void btnModificarMascota_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarMascotas_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                Mascota mascota = (Mascota)dgvMascotas.SelectedRows[0].DataBoundItem;
                mascota.Peso = decimal.Parse(txtPeso.Text);
                mascota.Castrado = checkBox1.Checked;

                if (mascotaDAO.ActualizarMascota(mascota))
                {
                    MessageBox.Show("Mascota actualizada correctamente.");
                    CargarMascotas(mascota.IdCliente);
                }
                else
                {
                    MessageBox.Show("Error al actualizar la mascota.");
                }
            }
        }
    }
}
