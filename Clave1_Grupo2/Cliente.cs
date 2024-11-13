using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    internal class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }

        // Método para obtener un cliente de la base de datos basado en el username
        public static Cliente ObtenerClientePorId(int idClientes)
        {
            Cliente cliente = null;
            string connectionString = "Server=localhost;Database=catdog_veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM cliente WHERE idClientes = @idClientes";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idClientes", idClientes);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                IdCliente = reader.GetInt32("idClientes"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Sexo = reader.GetString("sexo"),
                                Telefono = reader.GetString("telefono"),
                                Direccion = reader.GetString("direccion"),
                                Email = reader.GetString("email")
                            };
                        }
                    }
                }
            }
            return cliente;
        }

        // Método para actualizar los datos del cliente en la base de datos
        public bool ActualizarDatos()
        {
            bool actualizado = false;

            string connectionString = "Server=localhost;Database=catdog_veterinaria;Uid=root;Pwd=portillo;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE cliente SET telefono = @telefono, direccion = @direccion, email = @correo " +
                                   "WHERE idClientes = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@telefono", Telefono);
                        cmd.Parameters.AddWithValue("@direccion", Direccion);
                        cmd.Parameters.AddWithValue("@correo", Email);
                        cmd.Parameters.AddWithValue("@id", IdCliente);

                        actualizado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar datos del cliente: " + ex.Message);
                }
            }

            return actualizado;
        }
    }
}