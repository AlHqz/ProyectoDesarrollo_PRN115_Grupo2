using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clave1_Grupo2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioLogin.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingresa el usuario y la contraseña.");
                return;
            }

            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Primero, validamos el usuario y obtenemos el idClientes y el rol desde la tabla usuarios
                    string queryUsuario = "SELECT rol, idClientes FROM usuarios WHERE username = @username AND password = @password";

                    using (MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn))
                    {
                        cmdUsuario.Parameters.AddWithValue("@username", usuario);
                        cmdUsuario.Parameters.AddWithValue("@password", contraseña);

                        using (MySqlDataReader readerUsuario = cmdUsuario.ExecuteReader())
                        {
                            if (readerUsuario.Read())
                            {
                                string rol = readerUsuario["rol"].ToString();
                                int idClientes = readerUsuario["idClientes"] != DBNull.Value ? Convert.ToInt32(readerUsuario["idClientes"]) : 0;

                                readerUsuario.Close(); // Cerramos el reader antes de la segunda consulta

                                // Segunda consulta para obtener el nombre y apellido del cliente en la tabla clientes
                                string queryCliente = "SELECT nombre, apellido FROM clientes WHERE idClientes = @idClientes";
                                using (MySqlCommand cmdCliente = new MySqlCommand(queryCliente, conn))
                                {
                                    cmdCliente.Parameters.AddWithValue("@idClientes", idClientes);

                                    using (MySqlDataReader readerCliente = cmdCliente.ExecuteReader())
                                    {
                                        if (readerCliente.Read())
                                        {
                                            string nombreCompleto = $"{readerCliente["nombre"]} {readerCliente["apellido"]}";

                                            MessageBox.Show("Inicio de sesión exitoso.");

                                            switch (rol)
                                            {
                                                case "Cliente":
                                                    // Pasa idClientes y nombreCompleto al formulario ClienteForm
                                                    new ClienteForm(idClientes, nombreCompleto).Show();
                                                    break;
                                                case "Admin":
                                                    new AdminForm().Show();
                                                    break;
                                                case "Veterinario":
                                                    new VeterinarioForm().Show();
                                                    break;
                                                default:
                                                    MessageBox.Show("Rol desconocido.");
                                                    break;
                                            }
                                            this.Hide();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo obtener el nombre del cliente.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}