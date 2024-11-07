using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_Grupo2
{
    internal class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Castrado { get; set; }
        public int IdCliente { get; set; }

        public Mascota() { }
        public Mascota(string nombre, string raza, string especie, int edad, decimal peso, DateTime fechaNacimiento, bool castrado, int idClientes)
        {
            Nombre = nombre;
            Raza = raza;
            Especie = especie;
            Edad = edad;
            Peso = peso;
            FechaNacimiento = fechaNacimiento;
            Castrado = castrado;
            IdCliente = idClientes;
        }
    }
}