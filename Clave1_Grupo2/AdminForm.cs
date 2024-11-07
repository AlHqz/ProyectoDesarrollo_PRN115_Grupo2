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
        public AdminForm()
        {
            InitializeComponent();
            CargarClientes(); // Cargar clientes al abrir el formulario
            dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;
        }
        private void CargarClientes()
        {
            string nombreBuscado = txtNombre.Text;
            string query = "SELECT * FROM clientes WHERE nombre LIKE @nombre";
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", "%" + nombreBuscado + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvClientes.DataSource = dt;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                txtTelefono.Enabled = true;
                txtDireccion.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                txtTelefono.Enabled = true;
                txtDireccion.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);
                string query = "UPDATE clientes SET telefono = @telefono, direccion = @direccion, email = @email WHERE id = @id";
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
                CargarClientes(); // Refresca el DataGridView con los datos actualizados
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);
                string query = "DELETE FROM clientes WHERE id = @id";
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
                CargarClientes(); // Refresca el DataGridView con los datos actualizados
            }
        }
        // Evento que actualiza los campos en el GroupBox cuando se selecciona un cliente en el DataGridView
        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                txtTelefono.Enabled = false;
                txtDireccion.Enabled = false;
                txtEmail.Enabled = false;

                txtNombre.Text = dgvClientes.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtTelefono.Text = dgvClientes.SelectedRows[0].Cells["telefono"].Value.ToString();
                txtDireccion.Text = dgvClientes.SelectedRows[0].Cells["direccion"].Value.ToString();
                txtEmail.Text = dgvClientes.SelectedRows[0].Cells["email"].Value.ToString();
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
