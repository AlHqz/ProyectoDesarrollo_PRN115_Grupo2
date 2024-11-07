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
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }

        // Constructor
        public Cliente(int idCliente, string nombre, string telefono, string email)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        // Método para agregar un nuevo cliente a la base de datos
        public void AgregarCliente()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;"))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO clientes (nombre, telefono, email) VALUES (@nombre, @telefono, @email)", connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@telefono", Telefono);
                command.Parameters.AddWithValue("@email", Email);
                command.ExecuteNonQuery();
            }
        }

        // Método para modificar un cliente existente
        public void ModificarCliente()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;"))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE clientes SET nombre = @nombre, telefono = @telefono, email = @email WHERE idClientes = @idCliente", connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@telefono", Telefono);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@idCliente", IdCliente);
                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar un cliente
        public void EliminarCliente()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;"))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM clientes WHERE idClientes = @idCliente", connection);
                command.Parameters.AddWithValue("@idCliente", IdCliente);
                command.ExecuteNonQuery();
            }
        }
    }
}