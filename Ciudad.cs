using System;

namespace tpAgencia_Gpo_2
{
    public class Ciudad
    {
        private List<Hotel> listHoteles;
        private List<Vuelo> listVuelos;

        //declaracion de variables con properties
        public int id { get; set; }
        public string nombre {  get; set; }
        public List<Hotel> hoteles 
        {
            get => listHoteles.ToList();
        }
        public List<Vuelo> vuelos 
        { 
            get => listVuelos.ToList();        
        }

        //Constructores
        public Ciudad(int id, string nombre)
        {
            id = id++;
            this.nombre = nombre;
            listHoteles = new List<Hotel>();
            listVuelos = new List<Vuelo>();
        }

        //metodos
        public string[] ToString()
        {
            return new string[] { id.ToString(), nombre.ToString() };
        }

    }

   

    
}