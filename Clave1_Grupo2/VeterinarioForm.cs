using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave1_Grupo2
{
    public partial class VeterinarioForm : Form
    {
        private int idMascotaSeleccionada = -1;
        public VeterinarioForm()
        {
            InitializeComponent();
            CargarClientes();
        }
        private void CargarClientes()
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            string query = "SELECT idClientes, CONCAT(nombre, ' ', apellido) AS nombreCompleto FROM clientes";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Limpia el ComboBox antes de agregar elementos nuevos
                    cmbNombreClienteMascota.Items.Clear();

                    // Llenado del ComboBox con clientes
                    while (reader.Read())
                    {
                        // Obtiene el idClientes y el nombre completo
                        int idCliente = reader.GetInt32("idClientes");
                        string nombreCompleto = reader.GetString("nombreCompleto");

                        // Agrega cada cliente como un elemento en el ComboBox
                        cmbNombreClienteMascota.Items.Add(new KeyValuePair<int, string>(idCliente, nombreCompleto));
                    }

                    reader.Close();

                    // Define las propiedades DisplayMember y ValueMember
                    cmbNombreClienteMascota.DisplayMember = "Value";
                    cmbNombreClienteMascota.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                }
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

                    // Configura los encabezados de las columnas después de cargar los datos
                    dgvMascotas.Columns["edad"].HeaderText = "Edad (meses)";
                    dgvMascotas.Columns["peso"].HeaderText = "Peso (kg)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mascotas: " + ex.Message);
            }
        }
        private void cmbNombreClienteMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreClienteMascota.SelectedItem != null)
            {
                var selectedCliente = (KeyValuePair<int, string>)cmbNombreClienteMascota.SelectedItem;
                int idClienteSeleccionado = selectedCliente.Key;
                CargarMascotas(idClienteSeleccionado);
            }
        }

        private void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            if (cmbNombreClienteMascota.SelectedItem != null)
            {
                var selectedCliente = (KeyValuePair<int, string>)cmbNombreClienteMascota.SelectedItem;
                int idClienteSeleccionado = selectedCliente.Key;
                CargarMascotas(idClienteSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un cliente.");
            }
        }
        //Inicia pestaña Consultas

        public void SetIdMascotaSeleccionada(int idMascota)
        {
            idMascotaSeleccionada = idMascota;
        }
        private void btnGuardarConsulta_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado una mascota
            if (idMascotaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una mascota para registrar la consulta.");
                return;
            }

            string sintomas = txtSintomas.Text;
            string descripcion = txtDescripcionConsulta.Text;
            string indicaciones = txtIndicaciones.Text;

            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            string query = "INSERT INTO consultas (idMascotas, sintomas, descripcionConsulta, indicaciones) " +
                           "VALUES (@idMascotas, @sintomas, @descripcionConsulta, @indicaciones)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idMascotas", idMascotaSeleccionada);
                    cmd.Parameters.AddWithValue("@sintomas", sintomas);
                    cmd.Parameters.AddWithValue("@descripcionConsulta", descripcion);
                    cmd.Parameters.AddWithValue("@indicaciones", indicaciones);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Consulta guardada exitosamente.");
                LimpiarCamposConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la consulta: " + ex.Message);
            }
        }

        private void LimpiarCamposConsulta()
        {
            txtSintomas.Text = string.Empty;
            txtDescripcionConsulta.Text = string.Empty;
            txtIndicaciones.Text = string.Empty;
        }
        private void dgvMascotas_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                idMascotaSeleccionada = Convert.ToInt32(dgvMascotas.SelectedRows[0].Cells["idMascotas"].Value);
            }
        }
        //Pestaña Vacunas

        private void CargarMascotasEnBuscarMascota()
        {
            try
            {
                // Conexión a la base de datos
                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta para obtener todas las mascotas
                    string query = "SELECT idMascotas, nombre FROM mascotas";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Limpia el ComboBox antes de agregar nuevos elementos
                    cmbBuscarMascota.Items.Clear();

                    // Revisa si se obtuvieron registros
                    if (reader.HasRows)
                    {
                        // Llena el ComboBox con las mascotas
                        while (reader.Read())
                        {
                            int idMascota = reader.GetInt32("idMascotas");
                            string nombreMascota = reader.GetString("nombre");

                            // Agrega cada mascota como un elemento en el ComboBox
                            cmbBuscarMascota.Items.Add(new KeyValuePair<int, string>(idMascota, nombreMascota));
                        }
                    }

                    reader.Close();

                    // Define las propiedades DisplayMember y ValueMember
                    cmbBuscarMascota.DisplayMember = "Value";
                    cmbBuscarMascota.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mascotas: " + ex.Message);
            }
        }
        private void btnBuscarVacunas_Click(object sender, EventArgs e)
        {
            if (cmbBuscarMascota.SelectedItem != null)
            {
                var selectedMascota = (KeyValuePair<int, string>)cmbBuscarMascota.SelectedItem;
                int idMascotaSeleccionada = selectedMascota.Key;
                CargarVacunas(idMascotaSeleccionada);
            }
            else
            {
                MessageBox.Show("Seleccione una mascota para ver las vacunas.");
            }
        }
        private void CargarVacunas(int idMascota)
        {
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
            string query = "SELECT nombreVacuna, fechaAplicacion, proximaFechaAplicacion FROM vacunas WHERE idMascotas = @idMascotas";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMascotas", idMascota);

                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvVacunas.DataSource = dt;

                    dgvVacunas.Columns["nombreVacuna"].HeaderText = "Nombre de la Vacuna";
                    dgvVacunas.Columns["fechaAplicacion"].HeaderText = "Fecha de Aplicación";
                    dgvVacunas.Columns["proximaFechaAplicacion"].HeaderText = "Próxima Fecha de Aplicación";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las vacunas: " + ex.Message);
                }
            }
        }

        private void btnGuardarVacuna_Click(object sender, EventArgs e)
        {
            if (cmbBuscarMascota.SelectedItem != null)
            {
                var selectedMascota = (KeyValuePair<int, string>)cmbBuscarMascota.SelectedItem;
                int idMascotaSeleccionada = selectedMascota.Key;
                string nombreVacuna = txtNombreVacuna.Text;
                DateTime fechaAplicacion = dtpFechaAplicacion.Value;
                DateTime proximaFechaAplicacion = dtpProximaFechaAplicacion.Value;

                string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";
                string query = "INSERT INTO vacunas (idMascotas, nombreVacuna, fechaAplicacion, proximaFechaAplicacion) " +
                               "VALUES (@idMascotas, @nombreVacuna, @fechaAplicacion, @proximaFechaAplicacion)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idMascotas", idMascotaSeleccionada);
                    cmd.Parameters.AddWithValue("@nombreVacuna", nombreVacuna);
                    cmd.Parameters.AddWithValue("@fechaAplicacion", fechaAplicacion);
                    cmd.Parameters.AddWithValue("@proximaFechaAplicacion", proximaFechaAplicacion);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vacuna guardada exitosamente.");

                        LimpiarCamposVacuna(); // Limpia los campos
                        CargarVacunas(idMascotaSeleccionada); // Actualiza el DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la vacuna: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una mascota para registrar la vacuna.");
            }
        }
        private void LimpiarCamposVacuna()
        {
            txtNombreVacuna.Text = string.Empty;
            dtpFechaAplicacion.Value = DateTime.Now;
            dtpProximaFechaAplicacion.Value = DateTime.Now;
        }
    }

}