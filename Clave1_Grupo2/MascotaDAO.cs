using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    internal class MascotaDAO
    {
        private string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

        // Método para obtener todas las mascotas de un cliente específico
        public List<Mascota> ObtenerMascotasPorCliente(int idCliente)
        {
            List<Mascota> mascotas = new List<Mascota>();
            string query = "SELECT * FROM mascotas WHERE idClientes = @idCliente";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Mascota mascota = new Mascota
                    {
                        IdMascota = reader.GetInt32("idMascotas"),
                        Nombre = reader.GetString("nombre"),
                        Raza = reader.GetString("raza"),
                        Especie = reader.GetString("especie"),
                        Edad = reader.GetInt32("edad"),
                        Peso = reader.GetDecimal("peso"),
                        FechaNacimiento = reader.GetDateTime("fechaNacimiento"),
                        Castrado = reader.GetBoolean("castrado"),
                        IdCliente = reader.GetInt32("idClientes")
                    };
                    mascotas.Add(mascota);
                }
            }
            return mascotas;
        }

        // Método para insertar una nueva mascota
        public bool InsertarMascota(Mascota mascota)
        {
            string query = "INSERT INTO mascotas (nombre, raza, especie, edad, peso, fechaNacimiento, castrado, idClientes) VALUES (@nombre, @raza, @especie, @edad, @peso, @fechaNacimiento, @castrado, @idClientes)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", mascota.Nombre);
                command.Parameters.AddWithValue("@raza", mascota.Raza);
                command.Parameters.AddWithValue("@especie", mascota.Especie);
                command.Parameters.AddWithValue("@edad", mascota.Edad);
                command.Parameters.AddWithValue("@peso", mascota.Peso);
                command.Parameters.AddWithValue("@fechaNacimiento", mascota.FechaNacimiento);
                command.Parameters.AddWithValue("@castrado", mascota.Castrado);
                command.Parameters.AddWithValue("@idClientes", mascota.IdCliente);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Método para actualizar los datos de una mascota
        public bool ActualizarMascota(Mascota mascota)
        {
            string query = "UPDATE mascotas SET peso = @peso, castrado = @castrado WHERE idMascotas = @idMascotas";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@peso", mascota.Peso);
                command.Parameters.AddWithValue("@castrado", mascota.Castrado);
                command.Parameters.AddWithValue("@idMascotas", mascota.IdMascota);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Método para eliminar una mascota
        public bool EliminarMascota(int idMascota)
        {
            string query = "DELETE FROM mascotas WHERE idMascotas = @idMascota";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idMascota", idMascota);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
