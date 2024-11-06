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

            // Cadena de conexión (ajusta con tus credenciales de MySQL)
            string connectionString = "Server=localhost;Database=catdog veterinaria;Uid=root;Pwd=portillo;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para verificar usuario y contraseña
                    string query = "SELECT rol FROM usuarios WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", usuario);
                        cmd.Parameters.AddWithValue("@password", contraseña);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string rol = result.ToString();
                            MessageBox.Show("Inicio de sesión exitoso.");

                            // Redirección según el rol
                            switch (rol)
                            {
                                case "Admin":
                                    new AdminForm().Show();
                                    break;
                                case "Cliente":
                                    new ClienteForm().Show();
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
                            MessageBox.Show("Usuario o contraseña incorrectos.");
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