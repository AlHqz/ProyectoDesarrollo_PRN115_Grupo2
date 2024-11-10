using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave1_Grupo2
{
    public class Cita
    {
        private readonly string connectionString;

        public Cita(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AgendarCita(int idCliente, int idMascota, DateTime fecha, TimeSpan hora)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Cita (idClientes, idMascotas, Fecha, Hora, Confirmada) VALUES (@idCliente, @idMascota, @fecha, @hora, true)", conn);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idMascota", idMascota);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);

                cmd.ExecuteNonQuery();
            }
        }
        public void ModificarCita(int idCita, DateTime nuevaFecha, TimeSpan nuevaHora)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Cita SET Fecha = @fecha, Hora = @hora WHERE idCita = @idCita", conn);
                cmd.Parameters.AddWithValue("@fecha", nuevaFecha);
                cmd.Parameters.AddWithValue("@hora", nuevaHora);
                cmd.Parameters.AddWithValue("@idCita", idCita);

                cmd.ExecuteNonQuery();
            }
        }
        public void CancelarCita(int idCita)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Cita WHERE idCita = @idCita", conn);
                cmd.Parameters.AddWithValue("@idCita", idCita);

                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ObtenerCitas()
        {
            DataTable citasTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Cita", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(citasTable);
            }

            return citasTable;
        }
    public void CargarClientesCita(ComboBox cmbDueñoCita)
        {
            cmbDueñoCita.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT idClientes, Nombre, Apellido FROM clientes", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbDueñoCita.Items.Add(new Cliente
                    {
                        IdCliente = Convert.ToInt32(reader["idClientes"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString()
                    });
                }
                reader.Close();
            }
        }

        public void CargarMascotasCita(int idCliente, ComboBox cmbMascotaCita)
        {
            cmbMascotaCita.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT NombreMascota FROM mascotas WHERE idClientes = @idCliente", conn);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbMascotaCita.Items.Add(reader["NombreMascota"].ToString());
                }
                reader.Close();
            }
        }
        public List<string> CargarHorarios(DateTime fecha)
        {
            List<string> horariosDisponibles = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Hora FROM horarios WHERE Fecha = @fecha AND Disponible = true", conn);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    horariosDisponibles.Add(reader["Hora"].ToString());
                }
                reader.Close();
            }

            return horariosDisponibles;
        }
    }
}