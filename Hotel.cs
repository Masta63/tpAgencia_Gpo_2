using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpAgencia_Gpo_2
{
    public class Hotel
    {
        //declaracion de variables publicac on properties
        public int Id { get; set; }
        public Ciudad Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public double costo { get; set; }
        public List<Usuario> Huespedes { get; set; }
        public string nombre { get; set; }

        //metodos constructores
        public Hotel(int id, Ciudad ubicacion, int capacidad, double costo, string nombre)
        {
            Id = id;
            Ubicacion = ubicacion;
            Capacidad = capacidad;
            this.costo = costo;
            Huespedes = new List<Usuario>();
            this.nombre = nombre;
        }

        public Hotel()
        {
        }

        //metodos
    }
}
