using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace tpAgencia_Gpo_2
{
    public class Usuario 
    {

        public List<Hotel> listHotelesVisitados;

        public int id { get; set; }
        public string name { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public List<ReservaHotel> listMisReservasHoteles { get; set; }

        public List<ReservaVuelo> listMisReservasVuelo { get; set; }
        public List<Vuelo> listVuelosTomados { get; set; }

        public double credito { get; set; }
        public bool esAdmin { get; set; }

        public List<Hotel> hotelesVisitados { get; set; }


        public List<Vuelo> vuelosTomados { get; set; }


        //constructor para formUsuario
        public Usuario( string name, string apellido, string dni, string mail)
        {
            
            this.name = name;
            this.apellido = apellido;
            this.dni = dni;
            this.mail = mail;
            password = "password";
            esAdmin = false;
            listMisReservasHoteles = new List<ReservaHotel>();
            listMisReservasVuelo = new List<ReservaVuelo>();
            listHotelesVisitados = new List<Hotel>();
            listVuelosTomados = new List<Vuelo>();
        }
        //constructor para formUsuario
        public Usuario(int id,string name, string apellido, string dni, string mail)
        {
            this.id = id;
            this.name = name;
            this.apellido = apellido;
            this.dni = dni;
            this.mail = mail;
            password = "password";
            esAdmin = false;
            listMisReservasHoteles = new List<ReservaHotel>();
            listMisReservasVuelo = new List<ReservaVuelo>();
            listHotelesVisitados = new List<Hotel>();
            listVuelosTomados = new List<Vuelo>();
        }
        public Usuario(int id, string name, string apellido, string dni, string mail, string password)
        {
            this.id = id;
            this.name = name;
            this.apellido = apellido;
            this.dni = dni;
            this.esAdmin = false;
            this.password = password;
            this.mail = mail;
            listMisReservasHoteles = new List<ReservaHotel>();
            listMisReservasVuelo = new List<ReservaVuelo>();
            listHotelesVisitados = new List<Hotel>();
            listVuelosTomados = new List<Vuelo>();
        }


        //metodos

        public void setReservaHotel(ReservaHotel reserva)
        {
            listMisReservasHoteles.Add(reserva);
        }

        public void agregarIntentoFallido()
        {
            intentosFallidos++;
            if (intentosFallidos >= 3)
            {
                bloqueado = true;
            }
        }

        public void agregarReservaVuelo(ReservaVuelo reserva)
        {
            listMisReservasVuelo.Add(reserva);
        }

        public void agregarVueloTomado(Vuelo vuelo)
        {
            listVuelosTomados.Add(vuelo);
        }

        public void agregarHotelVisitado(Hotel hotel)
        {
            listHotelesVisitados.Add(hotel);
        }

    }
}