using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    public class Producto
    {
        public int IdInventario { get; set; }  // ID del producto en inventario
        public string Nombre { get; set; }      // Nombre del producto
        public double Precio { get; set; }      // Precio del producto

        public Producto(int idInventario, string nombre, double precio)
        {
            IdInventario = idInventario;
            Nombre = nombre;
            Precio = precio;
        }

        // Esto permite que el ComboBox muestre el nombre del producto directamente
        public override string ToString()
        {
            return Nombre;
        }
    }
}
