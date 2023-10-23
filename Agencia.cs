using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using tpAgencia_Gpo_2;
using static System.Net.Mime.MediaTypeNames;

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
    private DAL DB; //clase adicional para intercambio con base de datos

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
        DB = new DAL();//inicializar constructor
        inicializarAtributos();//inicializo los metodos de la clase DB
    }

    private void inicializarAtributos()
    {
        //aca deberiamos agregar los metodos para inicializar vuelos hoteles paises etc

        listUsuarios = DB.inicializarUsuarios();//metodo para inicializar usuarios
        hoteles = DB.inicializarHoteles();
        ciudades = DB.inicializarCiudades();
        vuelos = DB.inicializarVuelos();
        //le asigno todo lo del metodo a la sita de la clase logica que trabaja en tiempo de ejecucion
    }


    //INICIO METODOS DE USUARIO


    public string login(string? _contraseña, string? _mail)
    {
        if (_contraseña != null && _mail != "" && _contraseña != null && _mail != "")
        {
            Usuario? usuarioSeleccionados = this.getUsuarios().Where(x => x?.mail.Trim() == _mail).FirstOrDefault();
            return validacionEstadoUsuario(usuarioSeleccionados, _mail, _contraseña);
        }
        else
        {
            return "INGRESARDATOS";
        }
    }



    private string validacionEstadoUsuario(Usuario? usuarioSeleccionados, string mailInput, string Inputpass)
    {
        return this.iniciarSesion(usuarioSeleccionados, mailInput, Inputpass);
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

    public void cerrarSesion()
    {
        usuarioActual = null;
    }

    public string iniciarSesion(Usuario? usuarioSeleccionados, string inputMail, string inputpass)
    {
        string codigoReturn;
        if (usuarioSeleccionados == null)
        {

            codigoReturn = "FALTAUSUARIO";
        }
        else if (usuarioSeleccionados.mail.Trim().Equals(inputMail) && usuarioSeleccionados.password.Trim() == inputpass)
        {
            codigoReturn = "OK";
            this.usuarioActual = usuarioSeleccionados;
            this.usuarioActual.listMisReservasHoteles = DB.traerMisReservasHotel(usuarioSeleccionados.id);
        }
        else
        {
            usuarioSeleccionados.intentosFallidos++;
            if (usuarioSeleccionados.intentosFallidos == 3)
            {
                usuarioSeleccionados.bloqueado = true;
                codigoReturn = "BLOQUEADO";
            }
            else
            {
                codigoReturn = "MAILERROR";
            }
        }

        return codigoReturn;
    }

    //-- metodos del formUsuario
    public List<Usuario> getUsuarios()
    {
        return listUsuarios.ToList();
    }

    public bool agregarUsuarioDal(string Dni, string Nombre, string apellido, string Mail, string Password, bool EsADM, bool Bloqueado)
    {
        //comprobación para que no me agreguen usuarios con DNI duplicado
        bool esValido = true;
        foreach (Usuario u in listUsuarios)
        {
            if (u.dni == Dni)
            {
                esValido = false;
            }
        }
        if (esValido)
        {
            int idNuevoUsuario;
            idNuevoUsuario = DB.agregarUsuario(Dni, Nombre, apellido, Mail, Password, EsADM, Bloqueado);
            //compruebo que se pudo agregar a la base y se le asignó un ID
            if (idNuevoUsuario != -1)
            {
                //Ahora sí lo agrego en la lista
                Usuario nuevo = new Usuario(idNuevoUsuario, Dni, Nombre, apellido, Mail, Password, EsADM, Bloqueado);
                listUsuarios.Add(nuevo);
                return true;
            }
            else
            {
                //algo salió mal con la query porque no generó un id válido
                return false;
            }
        }
        else
            return false;
    }


    public bool eliminarUsuarioDal(int Id)
    {
        //primero me aseguro que lo pueda eliminar en la base
        if (DB.eliminarUsuario(Id) == 1)
        {
            try
            {
                //Ahora sí lo elimino en la lista
                foreach (Usuario u in listUsuarios)
                    if (u.id == Id)
                    {
                        listUsuarios.Remove(u);
                        return true;
                    }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            //algo salió mal con la query porque no generó 1 registro
            return false;
        }
    }

    public bool modificarUsuarioDal(int Id, int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
    {
        //primero me aseguro que lo pueda agregar a la base
        if (DB.modificarUsuario(Id, Dni, Nombre, Mail, Password, EsADM, Bloqueado) == 1)
        {
            try
            {
                //Ahora sí lo MODIFICO en la lista
                for (int i = 0; i < listUsuarios.Count; i++)
                    if (listUsuarios[i].id == Id)
                    {
                        listUsuarios[i].name = Nombre;
                        listUsuarios[i].mail = Mail;
                        listUsuarios[i].password = Password;
                        listUsuarios[i].esAdmin = EsADM;
                        listUsuarios[i].bloqueado = Bloqueado;
                    }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            //algo salió mal con la query porque no generó 1 registro
            return false;
        }
    }
    //modifico el creidto del usuario en ABM
    public bool modificarCreditoDal(int id, double monto)
    {
        if (DB.modificarCreditoUsuario(id, monto) == 1)
        {
            return modificarCredito(id, monto);//reutilizo metodo anterior
        }
        else
        {
            return false;
        }
    }
    //agrego credito en el ABM
    public bool AgregarCreditoDal(int id, double monto)
    {
        if (DB.agregoCreditoUsuario(id, monto) == 1)
        {
            return agregarCredito(id, monto);//reutilizo metodo anterior
        }
        else
        {
            return false;
        }
    }


    //metodo anterior
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

    //metodo anterior
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


    public bool agregarUsuario(string name, string apellido, string dni, string mail)
    {
        Usuario usuario = new Usuario(cantUsuarios, name, apellido, dni, mail);
        cantUsuarios++;
        usuario.id = listUsuarios != null ? listUsuarios.OrderByDescending(x => x.id).FirstOrDefault().id + 1 : 1;
        listUsuarios.Add(usuario);
        return true;
    }

    //metodo del formRegistro de Usuario
    /*
    public bool agregarUsuario(string name, string apellido, string dni, string mail, string pass)
    {
        Usuario usuario = new Usuario(cantUsuarios, name, apellido, dni, mail);
        cantUsuarios++;
        usuario.id = listUsuarios != null ? listUsuarios.OrderByDescending(x => x.id).FirstOrDefault().id + 1 : 1;
        listUsuarios.Add(usuario);
        return true;
    }
    */
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
    public bool existeUsuarioConDniOMail(string dni, string mail)
    {
        return getUsuarios().Any(u => u.dni == dni || u.mail == mail);
    }


    //FIN METODOS USUARIO





    // INICIO METODOS DE VUELO

    public int obtenerNombreCiudad(string nombre)
    {
        Ciudad ciudad = ciudades.FirstOrDefault(ciudad => ciudad.nombre == nombre);
        return ciudad != null ? ciudad.id : -1;
    }
    public string obtenerCiudadPorId(int id)
    {
        Ciudad ciudad = ciudades.FirstOrDefault(ciudad => ciudad.id == id);
        return ciudad != null ? ciudad.nombre : string.Empty;
    }
    public bool agregarVuelo(int idOrigen, int idDestino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
    {

        Ciudad cOrigen = ciudades.FirstOrDefault(ciudad => ciudad.id == idOrigen);
        Ciudad cDestino = ciudades.FirstOrDefault(ciudad => ciudad.id == idDestino);
        int idNuevoVuelo;
        idNuevoVuelo = DB.agregarVuelo(idOrigen, idDestino, capacidad, costo, fecha, aerolinea, avion);
        if (idNuevoVuelo != -1)
        {
            Vuelo nuevo = new Vuelo(idNuevoVuelo, cOrigen, cDestino, capacidad, costo, fecha, aerolinea, avion);
            vuelos.Add(nuevo);
            return true;
        }
        else
        {
            return false;
        }

    }

    public string modificarVuelo(int id, int origen, int destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
    {
        Ciudad cOrigen = ciudades.FirstOrDefault(ciudad => ciudad.id == origen);
        Ciudad cDestino = ciudades.FirstOrDefault(ciudad => ciudad.id == destino);
        if (DB.modificarVuelo(id, origen, destino, capacidad, costo, fecha, aerolinea, avion) == 1)
        {
            try
            {
                foreach (Vuelo vuelo in vuelos)
                {
                    if (vuelo.id == id)
                    {
                        int cantReservas = vuelo.listPasajeros.Count;
                        if (capacidad >= cantReservas)
                        {
                            vuelo.origen = cOrigen;
                            vuelo.destino = cDestino;
                            vuelo.costo = costo;
                            vuelo.fecha = fecha;
                            vuelo.aerolinea = aerolinea;
                            vuelo.avion = avion;
                            vuelo.capacidad = capacidad;

                            return "exito";
                        }
                        else
                        {
                            return "capacidad";
                        }
                    }

                }
            }
            catch (Exception e)
            {
                return "error";
            }
        }
        return "error";
    }
    public string modificarReservaVuelo(int idVuelo, int idReserva, int cantidad, double costo)
    {
        if (DB.modificarReservaVuelo(idVuelo, idReserva, cantidad, costo) == 1)
        {
            try
            {
                foreach (Vuelo vuelo in vuelos)
                {
                    if (vuelo.id == idVuelo)
                    {
                        int cantReservas = vuelo.listPasajeros.Count;
                        if (vuelo.capacidad >= cantReservas)
                        {

                            vuelo.costo = costo;


                            return "exito";
                        }
                        else
                        {
                            return "capacidad";
                        }
                    }

                }
            }
            catch (Exception e)
            {
                return "error";
            }
        }
        return "error";
    }

    public double CalcularNuevoCosto(int vueloId, int nuevaCantidad)
    {

        double costoBase = ObtenerCostoBase(vueloId);
        double nuevoCosto = costoBase * nuevaCantidad;
        return nuevoCosto;
    }
    public double ObtenerCostoBase(int vueloId)
    {
        Vuelo vuelo = vuelos.FirstOrDefault(v => v.id == vueloId);

        if (vuelo != null)
        {
            return vuelo.costo;
        }
        else
        {

            return 0;
        }
    }
    public bool eliminarVuelo(int id)
    {
        DateTime fechaActual = DateTime.Now;
        if (DB.eliminarVuelo(id) == 1)
        {

            try
            {


                foreach (Vuelo vuelo in vuelos)
                {
                    if (vuelo.id == id)

                    {
                        if (vuelo.fecha > fechaActual)
                        {

                            foreach (ReservaVuelo reservas in vuelo.listMisReservas)
                            {
                                reservas.miUsuario.credito += reservas.pagado;
                            }
                        }
                        vuelos.Remove(vuelo);

                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
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

            if (vuelo.origen.nombre == origen.nombre && vuelo.destino.nombre == destino.nombre && vuelo.fecha.Date == fecha.Date && vuelo.capacidad >= cantidadPax + vuelo.vendido)
            {
                vuelosDisponibles.Add(vuelo);
            }

        }
        return vuelosDisponibles;

    }


    public string comprarVuelo(int vueloId, Usuario usuarioActual, int cantidad)
    {
        Vuelo vuelo = vuelos.FirstOrDefault(v => v.id == vueloId);

        if (vuelo != null && cantidad > 0 && cantidad <= vuelo.capacidad - vuelo.vendido)
        {
            double costoTotal = vuelo.costo * cantidad;
            if (usuarioActual.credito >= costoTotal)
            {
                usuarioActual.credito -= costoTotal;
                vuelo.vendido += cantidad;

                //List<Usuario> pax = new List<Usuario>();
                for (int i = 0; i < cantidad; i++)
                {
                    vuelo.listPasajeros.Add(usuarioActual);
                }
                ReservaVuelo reserva = new ReservaVuelo(vuelo, usuarioActual, costoTotal);
                int reservaId = DB.agregarReservaVuelo(vueloId, costoTotal, usuarioActual.id);

                if (reservaId != -1)
                {

                    usuarioActual.agregarReservaVuelo(reserva);
                    usuarioActual.agregarVueloTomado(vuelo);
                    vuelo.agregarReservaAlVuelo(reserva);



                    return "exito";
                }
                else
                {
                    // Maneja el caso en que la inserción en la base de datos falle.
                    return "error";
                }
            }
            return "sinSaldo";

        }
        return "error";

    }

    //FIN METODOS DE VUELO
    public List<Vuelo> misVuelos(Usuario usuarioActual)
    {
        return usuarioActual.listVuelosTomados.ToList();
    }

    //METODO DE RESERVA DE VUELO DE LUCAS - REVISAR -
    public List<Vuelo> misReservasVuelos(Usuario usuario)
    {
        DateTime fechaActual = DateTime.Now;
        List<Vuelo> vuelosReservados = new List<Vuelo>();

        foreach (ReservaVuelo reserva in usuario.listMisReservasVuelo)
        {

            vuelosReservados.Add(reserva.miVuelo);



        }
        return vuelosReservados;
    }

    //METODO DE RESERVA DE HOTEL
    public List<Hotel> misReservasHoteles(Usuario usuario)
    {
        DateTime fechaActual = DateTime.Now;
        List<Hotel> hotelesReservados = new List<Hotel>();

        foreach (ReservaHotel reserva in usuario.listMisReservasHoteles)
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

    public Hotel? getHotelesByHotel(string boxHoteles)
    {
        return getHoteles()?.FirstOrDefault(x => x.nombre == boxHoteles);
    }


    public void setHotel(Hotel hotel)
    {
        hoteles.Add(hotel);
    }


    //INICIO METODOS DE HOTEL

    public bool agregarHotel(Ciudad ubicacion, int capacidad, double costo, string nombre)
    {


        int cant = hoteles.OrderByDescending(x => x.id).FirstOrDefault().id + 1;

        hoteles.Add(new Hotel(cant, ubicacion, capacidad, costo, nombre));
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
    public List<ReservaHotel> getReservasHotel()
    {
        return reservasHotel.ToList();
    }


    public bool estaRangoParaLaReserva(Hotel hotelSeleccionado, DateTime fechaIngreso, DateTime fechaEgreso)
    {
        bool estaRango = false;
        foreach (var itemReserva in hotelSeleccionado.listMisReservas)
        {
            estaRango = this.verificacionRango(itemReserva, hotelSeleccionado, fechaIngreso, fechaEgreso);
        }
        return estaRango;
    }

    public List<Hotel> TraerDisponibilidadHotel(string ciudadSeleccionada, DateTime fechaIngreso, DateTime fechaEgreso, string textCantPer)
    {
        bool estaRango = false;
        int cantPer = 0;

        List<Hotel> hotelesDisponibles = new List<Hotel>();

        foreach (var itemHotel in this.getHoteles())
        {
            if (itemHotel.ubicacion.nombre.Trim().ToUpper() == ciudadSeleccionada.Trim().ToUpper())
            {
                foreach (var itemReserva in itemHotel.listMisReservas)
                {
                    estaRango = this.verificacionRango(itemReserva, itemHotel, fechaIngreso, fechaEgreso);

                    if (estaRango)
                        break;

                    cantPer++;
                }
                if (!estaRango && Convert.ToInt32(textCantPer) <= itemHotel.capacidad)
                    hotelesDisponibles.Add(itemHotel);
            }
        }

        return hotelesDisponibles;
    }

    private bool verificacionRango(ReservaHotel itemReserva, Hotel itemHotel, DateTime fechaIngreso, DateTime fechaEgreso)
    {
        bool estaRango = false;

        if (itemReserva.miHotel.id == itemHotel.id)
        {
            if (itemReserva.fechaDesde < fechaIngreso && itemReserva.fechaHasta > fechaIngreso)
            {
                estaRango = true;

            }

            if (itemReserva.fechaDesde < fechaEgreso && itemReserva.fechaHasta > fechaEgreso)
            {
                estaRango = true;
            }
        }
        else
        {
            estaRango = false;
        }
        return estaRango;
    }


    public ReservaHotel? GenerarReserva(Hotel hotelSeleccionado, DateTime fechaIngreso, DateTime fechaEgreso, string textBoxMonto, string textCantPer)
    {
        bool estaRango = this.estaRangoParaLaReserva(hotelSeleccionado, fechaIngreso, fechaEgreso);

        TimeSpan ts = fechaEgreso.Date.Subtract(fechaIngreso.Date);
        double costo = ((ts.Days + 1) * hotelSeleccionado.costo);

        if (!estaRango && Convert.ToInt32(textCantPer) <= hotelSeleccionado.capacidad && costo == Convert.ToDouble(textBoxMonto))
        {
            //genera objeto reserva en memoria
            ReservaHotel reservaHotel = new ReservaHotel(hotelSeleccionado, this.getUsuarioActual(), fechaIngreso, fechaEgreso, Convert.ToDouble(textBoxMonto));
            DB.agregarReserva(reservaHotel.miUsuario.id, reservaHotel.fechaDesde.Date, reservaHotel.fechaHasta.Date, reservaHotel.pagado, reservaHotel.miHotel.id);

            if (!DB.traerHotel_Usuario(reservaHotel.miHotel.id, reservaHotel.miUsuario.id))
            {
                DB.agregarRelacionUsuarioHotel(reservaHotel.miUsuario.id, reservaHotel.miHotel.id);
            }

            //Recalcula la capacidad del hotel
            hotelSeleccionado.capacidad = hotelSeleccionado.capacidad - Convert.ToInt32(textCantPer);
            DB.modificarCapacidadHotel(reservaHotel.miHotel.id, hotelSeleccionado.capacidad);

            Usuario usuarioActual = this.getUsuarioActual();

            //le resta el credito al usuario
            usuarioActual.credito = usuarioActual.credito - Convert.ToDouble(textBoxMonto);
            DB.modificarCreditoUsuario(reservaHotel.miUsuario.id, usuarioActual.credito);

            //agregar la nueva reserva en memoria
            usuarioActual.listMisReservasHoteles.Add(reservaHotel);

            //setea el usuario actual
            this.setUsuario(usuarioActual);
            return reservaHotel;
        }
        else
        {
            return null;
        }
    }
}