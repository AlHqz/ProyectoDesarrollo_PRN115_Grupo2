using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    internal class CitaItem
    {
        public int IdCita { get; set; }
        public int IdClientes { get; set; }
        public int IdMascotas { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Estado { get; set; }
        public string NombreMascota { get; set; }
    }
}
