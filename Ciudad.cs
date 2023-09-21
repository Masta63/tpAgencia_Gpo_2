namespace tpAgencia_Gpo_2
{
    public class Ciudad
    {
        //declaracion de variables con properties
        public int Id { get; set; }
        public string nombre {  get; set; }
        public List<Hotel> Hoteles { get; set; }
        public List<Vuelo> vuelos { get; set; }



        //Constructores

        public Ciudad(int id, string nombre)
        {
            Id = id++;
            this.nombre = nombre;
            Hoteles = new List<Hotel>();
            vuelos = new List<Vuelo>();
        }

    }

        //metodos
}