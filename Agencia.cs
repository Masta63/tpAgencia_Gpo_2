using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Net;
using System.Xml.Linq;
using tpAgencia_Gpo_2;

public class Agencia
{
    private List<Usuario> listUsuarios;
    private List<Hotel> hoteles;
    private List<Vuelo> vuelos;
    private List<Ciudad> ciudades;
    private List<ReservaHotel> reservasHotel;
    private List<ReservaVuelo> reservasVuelo;
    private Usuario? usuarioActual { get; set; }
    private int cantVuelos;
    private int cantUsuarios = 0;
    private int cantHoteles = 0;
    private int cantIdHoteles = 0;


    //metodo constructor
    public Agencia()
    {
        hoteles = new List<Hotel>();
        vuelos = new List<Vuelo>();
        cantVuelos = 0;
        cantHoteles = 0;
        ciudades = new List<Ciudad>();
        reservasHotel = new List<ReservaHotel>();
        reservasVuelo = new List<ReservaVuelo>();
        listUsuarios = new List<Usuario>();
    }

    //INICIO METODOS DE USUARIO

    public void registrarUsuario(int id, string name, string apellido, string dni, string mail, string password, bool esAdmin)
    {
        Usuario usuario = new Usuario(id, name, apellido, dni, mail, password, esAdmin);
        listUsuarios.Add(usuario);
    }
    public List<Usuario> Usuarios
    {
        get => listUsuarios.ToList();
    }

    public void setUsuario(Usuario usuario)
    {
        listUsuarios.Add(usuario);
    }

    public void setCiudad(Ciudad ciudad)
    {
        ciudades.Add(ciudad);
    }

    public Usuario? getUsuarioActual()
    {
        return this.usuarioActual;
    }

    public bool setUsuarioActual(Usuario usuarioActual)
    {
        //cree este metodo solo para hacer pruebas en mi vista de usuario
        this.usuarioActual = usuarioActual;
        return true;
    }

    public List<Usuario> getListUsuario()
    {
        return listUsuarios;
    }

    public void cerrarSesion()
    {
        usuarioActual = null;
    }

    public string iniciarSesion(List<Usuario> usuariosSeleccionados, string InputMail, string Inputpass, bool checkAdmin)
    {
        string codigoReturn = string.Empty;
        foreach (Usuario user in usuariosSeleccionados)
        {
            if (user.mail.Equals(InputMail) && user.password == Inputpass)
            {
                codigoReturn = "OK";
                user.esAdmin = checkAdmin;
                this.usuarioActual = user;
            }
            else
            {
                user.intentosFallidos++;
                if (user.intentosFallidos == 3)
                {
                    user.bloqueado = true;
                    codigoReturn = "BLOQUEADO";
                }
                else
                {
                    codigoReturn = "MAILERROR";
                }
            }
        }
        return codigoReturn;
    }

    //-- metodos del formUsuario
    public List<Usuario> getUsuarios()
    {
        return listUsuarios.ToList();
    }

    public bool agregarUsuarioobjet(Usuario usuario)
    {
        Usuario obj = new Usuario(cantUsuarios, usuario.name, usuario.apellido, usuario.dni, usuario.mail);
        cantUsuarios++;
        listUsuarios.Add(obj);
        return true;
    }
    public bool agregarUsuario(string name, string apellido, string dni, string mail)
    {
        Usuario usuario = new Usuario(cantUsuarios, name, apellido, dni, mail);
        cantUsuarios++;
        usuario.id = listUsuarios != null ? listUsuarios.OrderByDescending(x => x.id).FirstOrDefault().id + 1 : 1;
        listUsuarios.Add(usuario);
        return true;
    }

    public bool modificarUsuario(int id, string name, string apellido, string dni, string mail)
    {
        foreach (Usuario user in listUsuarios)
        {
            if (user.id == id)
            {
                user.name = name;
                user.apellido = apellido;
                user.dni = dni;
                user.mail = mail;
                return true;
            }
        }
        return false;
    }

    public bool eliminarUsuario(int id)
    {
        foreach (Usuario user in listUsuarios)
        {
            if (user.id == id)
            {
                listUsuarios.Remove(user);
                return true;
            }
        }
        return false;
    }

    public bool modificarCredito(int id, double monto)
    {
        foreach (Usuario user in listUsuarios)
        {
            if (user.id == id)
            {
                user.credito = monto;
                return true;
            }
        }
        return false;
    }

    public bool agregarCredito(int id, double monto)
    {
        foreach (Usuario user in listUsuarios)
        {
            if (user.id == id)
            {
                user.credito += monto;
                return true;
            }
        }
        return false;
    }

    public bool eliminarCiudad(int id)
    {
        foreach (Ciudad itemCiudad in ciudades)
        {
            if (itemCiudad.id == id)
            {
                ciudades.Remove(itemCiudad);

                return true;
            }
        }
        return false;
    }


    public string? nombreLogueado()
    {
        return this.usuarioActual?.name;
    }

    public bool modificarPassword(int id, string pass)
    {
        foreach (Usuario user in listUsuarios)
        {
            if (user.id == id)
            {
                user.password = pass;
                return true;
            }
        }
        return false;

    }
    //verificar si ya existe un usuario con ese mail o dni
    //devuelve true si encuentra
    public bool ExisteUsuarioConDniOMail(string dni, string mail)
    {
        return getListUsuario().Any(u => u.dni == dni || u.mail == mail);
    }


    //FIN METODOS USUARIO





    // INICIO METODOS DE VUELO

    //ver lo que explicó el profesor
    public void cargarCredito(int idUsuario, double importe)
    {

        this.usuarioActual.credito += importe;

    }
    public bool agregarVuelo(Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
    {

        vuelos.Add(new Vuelo(cantVuelos, origen, destino, capacidad, costo, fecha, aerolinea, avion));
        cantVuelos++;
        return true;
    }

    public bool modificarVuelo(int id, Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
    {
        foreach (Vuelo vuelo in vuelos)
        {
            if (vuelo.id == id)
            {
                vuelo.origen = origen;
                vuelo.destino = destino;
                vuelo.capacidad = capacidad;
                vuelo.costo = costo;
                vuelo.fecha = fecha;
                vuelo.aerolinea = aerolinea;
                vuelo.avion = avion;
                return true;
            }
        }
        return false;
    }

    public bool eliminarVuelo(int id)
    {
        foreach (Vuelo vuelo in vuelos)
        {
            if (vuelo.id == id)

            {
                vuelos.Remove(vuelo);
                return true;
            }
        }
        return false;
    }

    public List<Vuelo> getVuelos()
    {
        return vuelos.ToList();
    }


    public List<Ciudad> GetCiudades()
    {
        return ciudades.ToList();
    }
    // Reporte de vuelos
    public List<Vuelo> buscarVuelos(Ciudad origen, Ciudad destino, DateTime fecha, int cantidadPax)
    {
        List<Vuelo> vuelosDisponibles = new List<Vuelo>();
        foreach (Vuelo vuelo in vuelos)
        {

            if (vuelo.origen.nombre == origen.nombre && vuelo.destino.nombre == destino.nombre && vuelo.fecha.Date == fecha.Date && vuelo.capacidad >= cantidadPax)
            {
                vuelosDisponibles.Add(vuelo);
            }

        }
        return vuelosDisponibles.ToList();

    }

    public bool comprarVuelo(int vueloId, Usuario usuarioActual, int cantidad)
    {
        Vuelo vuelo = vuelos.FirstOrDefault(v => v.id == vueloId);
        if (vuelo != null && cantidad > 0 && cantidad <= vuelo.capacidad - vuelo.vendido)
        {
            double costoTotal = vuelo.costo * cantidad;
            if (usuarioActual.credito >= costoTotal)
            {
                usuarioActual.credito -= costoTotal;
                vuelo.vendido += cantidad;

                for (int i = 0; i < cantidad; i++)
                {
                    ReservaVuelo reserva = new ReservaVuelo(vuelo, usuarioActual);
                    vuelo.misReservas.Add(reserva);
                    usuarioActual.agregarReservaVuelo(reserva);
                }

                return true;
            }
            MessageBox.Show("No tienes suficiente crédito para realizar la compra");
        }


        return false;

    }

    //FIN METODOS DE VUELO
    public List<Vuelo> misVuelos(Usuario usuario)
    {
        DateTime fechaActual = DateTime.Now;
        List<Vuelo> vuelosPasados = new List<Vuelo>();

        foreach (ReservaVuelo reserva in usuario.misReservasVuelo)
        {
            if (reserva.miVuelo.fecha < fechaActual)
            {
                vuelosPasados.Add(reserva.miVuelo);
            }


        }
        return vuelosPasados;
    }

    //METODO DE RESERVA DE VUELO DE LUCAS - REVISAR -
    public List<Vuelo> misReservasVuelos(Usuario usuario)
    {
        DateTime fechaActual = DateTime.Now;
        List<Vuelo> vuelosReservados = new List<Vuelo>();

        foreach (ReservaVuelo reserva in usuario.misReservasVuelo)
        {
            if (reserva.miVuelo.fecha > fechaActual)
            {
                vuelosReservados.Add(reserva.miVuelo);
            }


        }
        return vuelosReservados;
    }

    //METODO DE RESERVA DE HOTEL
    public List<Hotel> misReservasHoteles(Usuario usuario)
    {
        DateTime fechaActual = DateTime.Now;
        List<Hotel> hotelesReservados = new List<Hotel>();

        foreach (ReservaHotel reserva in usuario.misReservasHoteles)
        {
            if (reserva.fechaHasta.Date >= fechaActual.Date)
            {
                hotelesReservados.Add(reserva.miHotel);
            }


        }
        return hotelesReservados;
    }

    public List<Hotel> getHoteles()
    {
        return hoteles.ToList();
    }

    public void setHotel(Hotel hotel)
    {
        hoteles.Add(hotel);
    }


    //INICIO METODOS DE HOTEL

    public bool agregarHotel(Ciudad ubicacion, int capacidad, double costo, string nombre)
    {

        hoteles.Add(new Hotel(cantIdHoteles, ubicacion, capacidad, costo, nombre));
        cantHoteles++;
        cantIdHoteles++;
        return true;
    }

    public bool modificarHotel(int id, Ciudad ubicacion, int capacidad, double costo, string nombre)
    {
        foreach (Hotel hotel in hoteles)
        {
            if (hotel.id == id)
            {
                hotel.ubicacion = ubicacion;
                hotel.capacidad = capacidad;
                hotel.costo = costo;
                hotel.nombre = nombre;
                return true;
            }
        }
        return false;
    }

    public bool eliminarHotel(int id)
    {
        foreach (Hotel hotel in hoteles)
        {
            if (hotel.id == id)

            {
                hoteles.Remove(hotel);
                return true;
            }
        }
        return false;
    }

    public List<Hotel> getHotel()
    {
        return hoteles.ToList();
    }



    //FIN METODOS DE HOTEL


    public void setReservasHotel(ReservaHotel reservaHotel)
    {
        reservasHotel.Add(reservaHotel);
    }
    public List<ReservaHotel>  getReservasHotel()
    {
        return reservasHotel.ToList();
    }
}
