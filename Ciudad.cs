namespace tpAgencia_Gpo_2
{
    public class Ciudad
    {
        //declaracion de variables con properties
        public int Id { get; set; }
        public string nombre {  get; set; }
        private List<Hotel> Hoteles { get; set; }
        private List<Vuelo> Vuelos { get; set; }



        //Constructores

        public Ciudad(int id, string nombre)
        {
            Id = id++;
            this.nombre = nombre;
            Hoteles = new List<Hotel>();
            Vuelos = new List<Vuelo>();
        }

    }

        //metodos
}