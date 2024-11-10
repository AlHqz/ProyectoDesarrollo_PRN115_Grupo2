using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    internal class FacturacionDB
    {
        private MySqlConnection connection;

        public FacturacionDB(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }

        public void InsertarFacturacion(string servicioPrestado, string metodoPago, decimal monto)
        {
            string query = "INSERT INTO facturacion (ServicioPrestado, MetododePago, MontoTotal) VALUES (@servicioPrestado, @metodoPago, @monto)";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@servicioPrestado", servicioPrestado);
            cmd.Parameters.AddWithValue("@metodoPago", metodoPago);
            cmd.Parameters.AddWithValue("@monto", monto);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable ObtenerFacturaciones()
        {
            string query = "SELECT * FROM facturacion";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
