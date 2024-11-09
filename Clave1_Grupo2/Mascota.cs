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
        public int IdMascotas { get; set; }
        public int IdDueno { get; set; }
        public string NombreMascota { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public int EdadEnMeses { get; set; }
        public double Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Castrado { get; set; }
        public Mascota() { }
        public Mascota(int idMascotas, int idDueno, string nombreMascota, string especie, string raza, int edadEnMeses, double peso, DateTime fechaNacimiento, bool castrado)
        {
            IdMascotas = idMascotas;
            IdDueno = idDueno;
            NombreMascota = nombreMascota;
            Especie = especie;
            Raza = raza;
            EdadEnMeses = edadEnMeses;
            Peso = peso;
            FechaNacimiento = fechaNacimiento;
            Castrado = castrado;
        }
        public override string ToString()
        {
            return $"{NombreMascota} ({Especie}), Raza: {Raza}, Edad: {EdadEnMeses} meses, Peso: {Peso} kg, Castrado: {(Castrado ? "Sí" : "No")}";
        }
    }
}