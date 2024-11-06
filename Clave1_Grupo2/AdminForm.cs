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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBuscado = txtNombre.Text;
            string query = "SELECT * FROM clientes WHERE nombre LIKE @nombre";
            
            //Conexion a la base de datos
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
                
                //Conexion a la base de Datos
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
                btnBuscar_Click(sender, e); // Actualizar el DataGridView
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);
                string query = "DELETE FROM clientes WHERE id = @id";

                //Conexion a la base de Datos 
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
                btnBuscar_Click(sender, e); // Actualizar el DataGridView
            }
        }
    }
}
