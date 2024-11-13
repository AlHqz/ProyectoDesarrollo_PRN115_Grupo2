using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    public class CarritoItem
    {
        public string Categoria { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal => Precio * Cantidad;

        public CarritoItem(string categoria, string nombreProducto, double precio, int cantidad)
        {
            Categoria = categoria;
            NombreProducto = nombreProducto;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
