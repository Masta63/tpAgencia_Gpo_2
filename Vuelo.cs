﻿namespace tpAgencia_Gpo_2
{


    public class Vuelo
    {

        public int id { get; set; }
        public Ciudad origen { get; set; }
        public Ciudad destino { get; set; }
        public int capacidad { get; set; }
        public int vendido { get; set; }
        public ICollection<Usuario> listPasajeros { get; set; }// ICollection en vez de List?
        public double costo { get; set; }
        public DateTime fecha { get; set; }
        public string aerolinea { get; set; }
        public string avion { get; set; }
        public List<ReservaVuelo> listMisReservas { get; set; }
        public List<VueloUsuario> vueloUsuarios { get; set; }


        public Vuelo() { }
        public Vuelo(int id, Ciudad origen, Ciudad destino, int capacidad,int vendido, double costo, DateTime fecha, string aerolinea, string avion)
        {
            this.id = id;
            this.origen = origen;
            this.destino = destino;
            this.capacidad = capacidad;
            this.vendido = vendido;
            this.costo = costo;
            this.fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
            listMisReservas = new List<ReservaVuelo>();
            listPasajeros = new List<Usuario>();
        }
        public Vuelo(Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            this.id = id;
            this.origen = origen;
            this.destino = destino;
            this.capacidad = capacidad;
            this.costo = costo;
            this.fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
            listMisReservas = new List<ReservaVuelo>();
            listPasajeros = new List<Usuario>();
        }
        public Vuelo(int id, Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            this.id = id;
            this.origen = origen;
            this.destino = destino;
            this.capacidad = capacidad;
            this.costo = costo;
            this.fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
            listMisReservas = new List<ReservaVuelo>();
            listPasajeros = new List<Usuario>();
        }

        //metodos

        public void agregarListaPasajeros(List<Usuario> usuarios)
        {
            listPasajeros.AddRange(usuarios);
        }

        public void agregarReservaAlVuelo(ReservaVuelo reserva)
        {
            listMisReservas.Add(reserva);
        }
        public string[] ToString()
        {
            string[] ciudadOrigen = origen.ToString();
            string[] ciudadDestino = origen.ToString();
            return new string[] { id.ToString(), ciudadOrigen[1], ciudadDestino[1], capacidad.ToString(), costo.ToString(), fecha.ToString(), aerolinea, avion };
        }


    }
}