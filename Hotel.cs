using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpAgencia_Gpo_2
{
    public class Hotel
    {

        private List<Usuario> listHuespedes;
        private List<ReservaHotel> listMisReservas;

        //declaracion de variables publicac on properties
        public int id { get; set; }
        public Ciudad ubicacion { get; set; }
        public int capacidad { get; set; }
        public double costo { get; set; }
        public List<Usuario> huespedes 
        {
            get => listHuespedes.ToList();           
        }
        public string nombre { get; set; }

        public List<ReservaHotel> misReservas
        {
            get => listMisReservas.ToList();
        }


        //metodos constructores
        public Hotel(int id, Ciudad ubicacion, int capacidad, double costo, string nombre, List<Usuario> listHuespedes, List<ReservaHotel> listMisReservas)
        {
            this.id = id;
            this.ubicacion = ubicacion;
            this.capacidad = capacidad;
            this.costo = costo;
            this.listHuespedes = listHuespedes;
            this.listMisReservas = listMisReservas;
            this.nombre = nombre;
        }

        public Hotel(int id, Ciudad ubicacion, int capacidad, double costo, string nombre)
        {
            this.id = id;
            this.ubicacion = ubicacion;
            this.capacidad = capacidad;
            this.costo = costo;
            listHuespedes = new List<Usuario>();
            listMisReservas = new List<ReservaHotel>();
            this.nombre = nombre;
        }


        //metodos
        public string[] ToString()
        {
            
            return new string[] { id.ToString(),  capacidad.ToString(), costo.ToString(), nombre.ToString() };
        }
    }
}
