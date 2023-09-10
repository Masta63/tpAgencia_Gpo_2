using System;

namespace tpAgencia_Gpo_2
{
    public class Usuario 
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string mail { get; set; }
        public string pasword { get; set; }
        public int intentosFallidos { get; set; }
        public Boolean bloqueado { get; set; }
        public List<ReservaHotel> misReservasHoteles { get => misReservasHoteles.ToList(); }
        public List<ReservaVuelo> misReservasVuelo { get => misReservasVuelo.ToList(); }

        public Double credito { get; set; }
        public Boolean esAdmin { get; set; }
        public List<Hotel> hotelesVisitados { get; set; }
        public List<Vuelo> vuelosTomados { get; set; }

        //constructres
        public Usuario()
        {
        }

        public Usuario(int id, string name, string apellido, int dni, bool esAdmin)
        {
            this.id = id;
            this.nombre = name;
            this.apellido = apellido;
            this.dni = dni;
            this.esAdmin = false;
        }

        //metodos

        public void setReservaHotel(ReservaHotel reserva)
        {
            misReservasHoteles.Add(reserva);
        }


    }
}