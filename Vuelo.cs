namespace tpAgencia_Gpo_2
{


    public class Vuelo
    {
        private List<ReservaVuelo> listMisReservas;
        private List<Usuario> listPasajeros;
        public int id { get; set; }
        public Ciudad origen { get; set; }
        public Ciudad destino { get; set; }
        public int capacidad { get; set; }
        public int vendido { get; set; }
        public List<Usuario> pasajeros
        {
            get => listPasajeros.ToList();
        }
        public double costo { get; set; }
        public DateTime fecha { get; set; }
        public string aerolinea { get; set; }
        public string avion { get; set; }
        public List<ReservaVuelo> misReservas
        {
            get => listMisReservas.ToList();
        }

        public Vuelo(int id, Ciudad origen, Ciudad destino, int capacidad, DateTime fecha, string aerolinea, string avion)
        {
            this.id = id;
            this.origen = origen;
            this.destino = destino;
            this.capacidad = capacidad;
            this.fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
            listMisReservas = new List<ReservaVuelo>();
            listPasajeros = new List<Usuario>();
        }
        //metodos
    }
}