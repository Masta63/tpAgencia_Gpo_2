namespace tpAgencia_Gpo_2
{


    public class Vuelo
    {
        public int id { get; set; }
        public Ciudad Origen { get; set; }
        public Ciudad destino { get; set; }
        public int capacidad { get; set; }
        public int vendido { get; set; }
        public List<Usuario> pasajeros { get; set; }
        public double costo { get; set; }
        public DateTime Fecha { get; set; }
        public string aerolinea { get; set; }
        public string avion { get; set; }
        public List<ReservaVuelo> misReservas { get; }

        //metodo constructor
        public Vuelo()
        {
        }

        public Vuelo(int id, Ciudad origen, Ciudad destino, int capacidad, DateTime fecha, string aerolinea, string avion)
        {
            this.id = id;
            Origen = origen;
            this.destino = destino;
            this.capacidad = capacidad;
            Fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
        }

        //metodos
    }
}