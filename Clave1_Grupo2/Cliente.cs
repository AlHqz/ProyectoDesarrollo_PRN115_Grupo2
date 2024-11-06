using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    class Cliente
    {
        public Cliente()
        {
        }
        private int idCliente { get; set; }
        private List<Mascota> mascotas { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string sexo { get; set; }
        protected string email { get; set; }
        protected int telefono { get; set; }
        protected string direccion { get; set; }
    }
}
