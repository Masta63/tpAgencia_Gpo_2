using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpAgencia_Gpo_2
{
    internal class Hotel
    {
        //declaracion de variables publicac on properties
        public int Id { get; set; }
        public Ciudad ubicacion { get; set; }
        public int capacidad { get; set; }
        public double costo { get; set; }
        public List<Usuario> huespedes { get; set; }
        public string nombre { get; set; }

        public List<ReservaHotel> misReservas { get; set; }

        //metodos constructores
        public Hotel(int id, Ciudad ubicacion, int capacidad, double costo, string nombre)
        {
            Id = id;
            this.ubicacion = ubicacion;
            this.capacidad = capacidad;
            this.costo = costo;
            huespedes = new List<Usuario>();
            this.nombre = nombre;
        }

        public Hotel()
        {
        }

        //metodos
    }
}
