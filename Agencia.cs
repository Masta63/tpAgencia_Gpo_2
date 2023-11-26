using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using tpAgencia_Gpo_2;
using static System.Net.Mime.MediaTypeNames;
using static Azure.Core.HttpHeader;
using Microsoft.EntityFrameworkCore;

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
    


    private MiContexto contexto; //Agrego la clase con el contexto de entity



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
        //DB = new DAL();//inicializar constructor
        inicializarAtributos();//inicializo los metodos de la clase DB/entity

    }//conexion
    #region conexion y carga

    public void cerrar()
    {
        contexto.Dispose();
    }

    private void inicializarAtributos()
    {


        try
        {
            //creo el contexto
            contexto = new MiContexto();
            //forma de cargar la tabla, un load para cada dbset de clase
            contexto.usuarios.Load();
            contexto.reservaHoteles.Load();
            contexto.hoteles.Load();
            contexto.vuelos.Include(v => v.listPasajeros).Include(v => v.listMisReservas).Include(v => v.vueloUsuarios).Load();
            contexto.vueloUsuarios.Load();
            contexto.ciudades.Load();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

    }
    #endregion

    //metodos de sesion
    #region Metodos de sesion

    public string login(string? _contraseña, string? _mail)
    {
        if (_contraseña != null && _mail != "" && _contraseña != null && _mail != "")
        {
            Usuario usuarioSeleccionados = contexto.usuarios.Where(u => u.mail == _mail).FirstOrDefault();
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
        else if (usuarioSeleccionados.mail.Trim().Equals(inputMail) && usuarioSeleccionados.password.Trim() == inputpass && !usuarioSeleccionados.bloqueado)
        {
            codigoReturn = "OK";
            this.usuarioActual = usuarioSeleccionados;
        }
        else
        {
            usuarioSeleccionados.intentosFallidos++;
            this.IngresarIntentosFallidosContext(usuarioSeleccionados);
            this.modificarUsuarioActual(usuarioSeleccionados);
            if (usuarioSeleccionados.intentosFallidos >= 3)
            {
                IngresarUsuarioBloqueadoContext();
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
    #endregion

    //INICIO METODOS DE USUARIO

    #region metodos usuarios


    //-- metodos del formUsuario
    public List<Usuario> getUsuarios()
    {
        return contexto.usuarios.ToList();
    }

    public bool agregarUsuarioContexto(string Dni, string Nombre, string apellido, string Mail, string Password, bool EsADM, bool Bloqueado)
    {
        //comprobación para que no me agreguen usuarios con DNI duplicado
        bool esValido = existeUsuarioConDniOMail(Dni,Mail);
        
        try
        {
            if (esValido)
            {
                Usuario nuevo = new Usuario { dni = Dni, name = Nombre, apellido = apellido, mail = Mail, password = Password, esAdmin = EsADM, bloqueado = Bloqueado };
                contexto.usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("ya existe un usuario registrado con ese mail o Dni");
                return false;
            }
                
        }
        catch (Exception)
        {

            throw;
        }
    }


    public bool eliminarUsuarioContext(int Id)
    {
        
        Usuario u = contexto.usuarios.Where(u => u.id == Id).FirstOrDefault();
        if (u != null)
        {

            try
            {
                contexto.usuarios.Remove(u);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }

        }
        else
        {
            //algo salió mal con la query porque no generó 
            return false;
        }


    }


    public bool modificarUsuariocontexto(int Id, string Nombre, string Apellido, string Dni, string Mail, string pass, bool admin, bool bloqueado)
    {
        //busco usuario y lo asocio a la variable
        Usuario u = contexto.usuarios.Where(u => u.id == Id).FirstOrDefault();
        if (u != null)
        {
            try
            {
                u.name = Nombre;
                u.apellido = Apellido;
                u.dni = Dni.ToString();
                u.mail = Mail;
                u.password = u.password;
                u.esAdmin = admin;
                u.bloqueado = bloqueado;
                contexto.usuarios.Update(u);
                contexto.SaveChanges();
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
    public bool modificarCreditoContexto(int id, double monto)
    {
        Usuario u = contexto.usuarios.Where(u => u.id == id).FirstOrDefault();
        if (u != null)
        {
            u.credito = monto;

            contexto.usuarios.Update(u);
            contexto.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
    //agrego credito en el ABM
    public bool AgregarCreditoContexto(int id, double monto)
    {
        try
        {
            Usuario u = contexto.usuarios.Where(u => u.id == id).FirstOrDefault();
            if (u != null)

            {
                u.credito += monto;
                contexto.usuarios.Update(u);
                contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public bool modificarPasswordContexto(int id, string text)
    {
        try
        {
            Usuario u = contexto.usuarios.Where(u => u.id == id).FirstOrDefault();
            if (u != null)
            {
                u.password = text;
                contexto.usuarios.Update(u);
                contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }



    public string? nombreLogueado()
    {
        return this.usuarioActual?.name;
    }

    //verificar si ya existe un usuario con ese mail o dni
    //devuelve true si encuentra
    public bool existeUsuarioConDniOMail(string dni, string mail)
    {
        
        return contexto.usuarios.Any(u => u.dni == dni || u.mail == mail);
    }

    #endregion
    //FIN METODOS USUARIO


    //metodos de ciudad
    #region Metodos de Ciudad


    public void setCiudad(Ciudad ciudad)
    {
        contexto.ciudades.Add(ciudad);
    }

    public bool eliminarCiudad(int id)
    {
        try
        {
            Ciudad ciudadAEliminar = contexto.ciudades.Where(c => c.id == id).FirstOrDefault();
            if (ciudadAEliminar != null)
            {
                contexto.ciudades.Remove(ciudadAEliminar);
                contexto.SaveChanges();
                return true;

            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool agregarCiudad(string nombre)
    {
        try
        {
            Ciudad city = new Ciudad(nombre);
            contexto.ciudades.Add(city);
            contexto.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

    }

    public int modificarCiudad(int id, string nombre)
    {

        Ciudad ciudadAModificar = contexto.ciudades.Where(ciudad => ciudad.id == id).FirstOrDefault();
        if (ciudadAModificar != null)
        {
            ciudadAModificar.nombre = nombre;
            contexto.ciudades.Update(ciudadAModificar);
            contexto.SaveChanges();
            return 1;
        }
        else
        {
            return -1;
        }
    }

    #endregion



    // INICIO METODOS DE VUELO
    #region Metodos de vuelo

    public int obtenerNombreCiudad(string nombre)
    {
        Ciudad ciudad = contexto.ciudades.FirstOrDefault(ciudad => ciudad.nombre == nombre);
        return ciudad != null ? ciudad.id : -1;
    }
    public string obtenerCiudadPorId(int id)
    {
        Ciudad ciudad = contexto.ciudades.FirstOrDefault(ciudad => ciudad.id == id);
        return ciudad != null ? ciudad.nombre : string.Empty;
    }

    // ABM Vuelos
    public bool agregarVuelo(int idOrigen, int idDestino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
    {

        Ciudad cOrigen = contexto.ciudades.Where(c => c.id == idOrigen).FirstOrDefault();
        Ciudad cDestino = contexto.ciudades.Where(c => c.id == idDestino).FirstOrDefault();
        try
        {
            Vuelo nuevo = new Vuelo(cOrigen, cDestino, capacidad, costo, fecha, aerolinea, avion);
            contexto.vuelos.Add(nuevo);
            contexto.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }



    public string modificarVuelo(int id, int origen, int destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
    {
        Ciudad cOrigen = contexto.ciudades.Where(c => c.id == origen).FirstOrDefault();
        Ciudad cDestino = contexto.ciudades.Where(c => c.id == destino).FirstOrDefault();

        try
        {
            Vuelo vueloModificado = contexto.vuelos.Where(v => v.id == id).FirstOrDefault();

            if (vueloModificado != null)
            {
                int disponibilidad = vueloModificado.capacidad - vueloModificado.vendido;
                if (capacidad >= disponibilidad)
                {
                    vueloModificado.origen = cOrigen;
                    vueloModificado.destino = cDestino;
                    vueloModificado.costo = costo;
                    vueloModificado.fecha = fecha;
                    vueloModificado.aerolinea = aerolinea;
                    vueloModificado.avion = avion;
                    vueloModificado.capacidad = capacidad;
                    contexto.vuelos.Update(vueloModificado);
                    contexto.SaveChanges();
                    return "exito";
                }
                {
                    return "capacidad";
                }
            }

        }
        catch (Exception e)
        {
            return "error";
        }

        return "error";
    }

    public bool eliminarVuelo(int id)
    {
        DateTime fechaActual = DateTime.Now;
        try
        {

            bool salida = false;
            Vuelo vueloAEliminar = contexto.vuelos.Where(v => v.id == id).FirstOrDefault();

            if (vueloAEliminar != null)

            {
                if (vueloAEliminar.fecha > fechaActual)
                {
                    vueloAEliminar.listMisReservas.ForEach(r => r.miUsuario.credito += r.pagado);
                }

                contexto.vuelos.Remove(vueloAEliminar);
                salida = true;

            }


            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        catch (Exception e)
        {
            return false;
        }
    }


    public string modificarReservaVuelo(int idVuelo, int idReserva, int cantidad, double costo)
    {
        DateTime fechaActual = DateTime.Now;
        try
        {
            ReservaVuelo rv = contexto.reservaVuelos.Where(rv => rv.idReservaVuelo == idReserva).FirstOrDefault();
            Vuelo v = contexto.vuelos.Where(v => v.id == idVuelo).FirstOrDefault();
            Usuario u = contexto.usuarios.Where(u => u.id == usuarioActual.id).FirstOrDefault();
            VueloUsuario vueloUsuarioSelected = contexto.vueloUsuarios.Where(vus => vus.idUsuario == usuarioActual.id && vus.idVuelo == idVuelo).FirstOrDefault();

            if (rv != null)
            {
                if (v.fecha >= fechaActual)
                {
                    int cantReservas = (int)(rv.pagado / v.costo);
                    if (cantidad > cantReservas)
                    {
                        //Calculo la diferencia
                        int diferencia = cantidad - cantReservas;
                        double nuevoMonto = diferencia * v.costo;
                        int disponibilidad = v.capacidad - v.vendido;
                        if (disponibilidad > diferencia)
                        {

                            //verifico si tiene credito
                            if (u.credito > nuevoMonto)
                            {
                                //le cobro la diferencia 
                                usuarioActual.credito = usuarioActual.credito - nuevoMonto;
                                //actualizo el valor pagado de la nueva reserva 
                                rv.pagado = rv.pagado + nuevoMonto;
                                //sumo vendido de la diferencia a vuelo
                                v.vendido += diferencia;
                                vueloUsuarioSelected.cantidad += diferencia;
                                contexto.SaveChanges();
                                return "reservaModificada";
                            }
                            else
                            {
                                return "credito";
                                //el usuario no tiene credito suficiente
                            }
                        }
                        else
                        {
                            return "capacidad";
                        }
                    }
                    else
                    {   //si la diferencia es menor
                        int diferencia = cantReservas - cantidad;
                        double nuevoMonto = diferencia * v.costo;
                        if (nuevoMonto > 0)
                        {
                            //devuelvo el dinero al usuario
                            usuarioActual.credito = usuarioActual.credito + nuevoMonto;
                            //actualizo el valor pagado en reserva
                            rv.pagado = rv.pagado - nuevoMonto;
                            //resto vendido a vuelo
                            v.vendido -= diferencia;
                            vueloUsuarioSelected.cantidad -= diferencia;
                            contexto.SaveChanges();
                            return "reservaModificada";
                        }
                        if (nuevoMonto == 0)
                        {
                            return "nomodifica";
                        }
                        else
                        {
                            return "error";
                        }

                    }
                }
                else
                {
                    return "fecha";
                }

            }
        }
        catch (Exception e)
        {
            return "error";
        }

        return "error";
    }

    public string eliminarReservaVuelo(int reservaVueloId)
    {
        try
        {
            ReservaVuelo reservaVuelo = contexto.reservaVuelos.SingleOrDefault(rv => rv.idReservaVuelo == reservaVueloId);
            Vuelo v = contexto.vuelos.Where(v => v.id == reservaVuelo.idVuelo).FirstOrDefault();
            VueloUsuario vueloUsuarioSelected = contexto.vueloUsuarios.Where(vus => vus.idUsuario == usuarioActual.id && vus.idVuelo == reservaVuelo.idVuelo).FirstOrDefault();

            if (reservaVuelo != null)
            {
                DateTime fechaActual = DateTime.Now;

                if (v.fecha >= fechaActual)
                {
                    double costoTotalReserva = reservaVuelo.pagado;
                    usuarioActual.credito += costoTotalReserva;
                    //calculo la cant de reservas para luego eliminarlo de la lista de reservas del vuelo y del usuario
                    int cantReservas = (int)(reservaVuelo.pagado / v.costo);
                    v.vendido -= cantReservas;
                    v.listMisReservas.Remove(reservaVuelo);
                    usuarioActual.listMisReservasVuelo.Remove(reservaVuelo);
                    //elimino la relacion vuelo usuario
                    var vueloUsuarioAEliminar = contexto.vueloUsuarios
                    .Where(vus => vus.idUsuario == usuarioActual.id && vus.idVuelo == reservaVuelo.idVuelo);

                    contexto.vueloUsuarios.RemoveRange(vueloUsuarioAEliminar);
                    //
                    contexto.reservaVuelos.Remove(reservaVuelo);
                    contexto.SaveChanges();
                    return "ReservaEliminada";

                }
                else
                {
                    return "Fecha";
                }
            }
            return "ok";
        }
        catch (Exception e)
        {
            return "error";
        }

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

    public List<Vuelo> getVuelos()
    {
        return contexto.vuelos.ToList();
    }


    public List<Ciudad> GetCiudades()
    {
        return contexto.ciudades.ToList();
    }
    // Reporte de vuelos
    public List<Vuelo> buscarVuelos(Ciudad origen, Ciudad destino, DateTime fecha, int cantidadPax)
    {


        var vuelosDisponibles = contexto.vuelos.Where(vuelo => vuelo.origen.nombre == origen.nombre && vuelo.destino.nombre == destino.nombre && vuelo.fecha.Date == fecha.Date && vuelo.capacidad >= cantidadPax + vuelo.vendido).ToList();

        return vuelosDisponibles;

    }
    public bool vincularVueloUsuarios(int vueloId, int usuarioId, int cant)
    {
        try
        {
            Vuelo vu = contexto.vuelos.Where(v => v.id == vueloId).FirstOrDefault();
            Usuario us = contexto.usuarios.Where(u => u.id == usuarioId).FirstOrDefault();
            VueloUsuario vueloUsuarioSelected = contexto.vueloUsuarios.Where(vus => vus.idUsuario == usuarioId && vus.idVuelo == vueloId).FirstOrDefault();
            if (us != null && vu != null && vueloUsuarioSelected != null)
            {
                us.listVuelosTomados.Add(vu);
                contexto.usuarios.Update(us);
                contexto.SaveChanges();


                vueloUsuarioSelected.cantidad = cant;
                contexto.vueloUsuarios.Update(vueloUsuarioSelected);
                contexto.SaveChanges();

            }
            else
            {
                vueloUsuarioSelected = new VueloUsuario();
                {
                    vueloUsuarioSelected.idVuelo = vueloId;
                    vueloUsuarioSelected.idUsuario = usuarioId;
                    vueloUsuarioSelected.cantidad = cant;
                }
                contexto.vueloUsuarios.Add(vueloUsuarioSelected);
                contexto.SaveChanges();

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }


    }

    public string comprarVuelo(int vueloId, Usuario usuarioActual, int cantidad)
    {
        Vuelo vuelo = contexto.vuelos.Where(v => v.id == vueloId).FirstOrDefault();

        if (contexto.vueloUsuarios.Any(vu => vu.idVuelo == vueloId && vu.idUsuario == usuarioActual.id))
        {
            return "yaCompro";
        }

        if (vuelo != null && cantidad > 0 && cantidad <= vuelo.capacidad - vuelo.vendido)
        {
            double costoTotal = vuelo.costo * cantidad;
            if (usuarioActual.credito >= costoTotal)
            {
                usuarioActual.credito -= costoTotal;
                vuelo.vendido += cantidad;
                vuelo.listPasajeros.Add(usuarioActual);

                ReservaVuelo reserva = new ReservaVuelo(vuelo, usuarioActual, costoTotal);
                contexto.reservaVuelos.Add(reserva);

                vincularVueloUsuarios(vueloId, usuarioActual.id, cantidad);

                contexto.SaveChanges();
                return "exito";

            }
            return "sinSaldo";

        }
        return "error";

    }


    //public List<Vuelo> misVuelos(Usuario usuarioActual)
    //{

    //    //List<ReservaVuelo> reservasVuelo = contexto.reservaVuelos.Where(rv => rv.idUsuario == usuarioActual.id).ToList();
    //    //return usuarioActual.listVuelosTomados = reservasVuelo.Select(reserva => reserva.miVuelo).ToList();

    //    List<VueloUsuario> vueloUsuario = contexto.vueloUsuarios.Where(vu => vu.idUsuario == usuarioActual.id).ToList();

    //    List<Vuelo> misVuelos = vueloUsuario.Select(vu => vu.vuelo).ToList();

    //    return misVuelos;
    //}



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

    #endregion
    //FIN METODOS DE VUELO





    //INICIO METODOS DE HOTEL
    #region Metodos hotel

    public bool agregarHotel(int ubicacionHotel, Int32 capacidad, float costo, string nombre)
    {
        Ciudad ubicacion = contexto.ciudades.FirstOrDefault(ciudad => ciudad.id == ubicacionHotel);
        if (ubicacion != null)
        {
            Hotel nuevoHotel = new Hotel(ubicacion, capacidad, costo, nombre);
            contexto.hoteles.Add(nuevoHotel);
            contexto.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }


    public string modificarHotel(int idHotel, int ubicacionHotel, int capacidad, float costo, string nombre)
    {

        Ciudad nuevaUbicacion = contexto.ciudades.FirstOrDefault(ciudad => ciudad.id == ubicacionHotel);

        if (nuevaUbicacion == null)
        {
            return "fallo1";
        }

        if (nuevaUbicacion != null)
        {
            try
            {
                Hotel hotelAModificar = contexto.hoteles.FirstOrDefault(hotel => hotel.id == idHotel);

                if (hotelAModificar != null)
                {
                    hotelAModificar.ubicacion = nuevaUbicacion;
                    hotelAModificar.capacidad = capacidad;
                    hotelAModificar.costo = costo;
                    hotelAModificar.nombre = nombre;
                    contexto.hoteles.Update(hotelAModificar);
                    contexto.SaveChanges();

                    return "exito";
                }
                else
                {
                    return "fallo2";
                }
            }
            catch (Exception e)
            {
                return "fallo2";
            }
        }

        return "fallo3";
    }

    public bool eliminarHotel(int idHotel)
    {

        try
        {
            var hotelAEliminar = contexto.hoteles.FirstOrDefault(hotel => hotel.id == idHotel);
            var miUsuario = contexto.usuarios.FirstOrDefault(x => x.id == getUsuarioActual().id);
            if (hotelAEliminar != null)
            {
                double monto = 0;

                foreach (var reservaHotel in hotelAEliminar.listMisReservas)
                {

                    monto += reservaHotel.pagado;
                    contexto.reservaHoteles.RemoveRange(reservaHotel);
                }

                double total = miUsuario.credito + monto;
                miUsuario.credito = total;
                this.getUsuarioActual().credito = total;
                contexto.usuarios.Update(miUsuario);
                contexto.hoteles.Remove(hotelAEliminar);
                contexto.SaveChanges();

                return true;

            }
            return false; //no se encontró el id del hotel
        }
        catch (Exception)
        {
            return false; //excepcion al eliminar el hotel
        }

    }


    #endregion

    //FIN METODOS DE HOTEL


    //METODO DE RESERVA DE HOTEL
    #region Reserva de hotel
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
        return contexto.hoteles.ToList();
    }

    public Hotel? getHotelesByHotel(string boxHoteles)
    {
        return getHoteles()?.FirstOrDefault(x => x.nombre == boxHoteles);
    }


    public void setHotel(Hotel hotel)
    {
        hoteles.Add(hotel);
    }

    public void setReservasHotel(ReservaHotel reservaHotel)
    {
        reservasHotel.Add(reservaHotel);
    }
    public List<ReservaHotel> getReservasHotel()
    {
        return contexto.reservaHoteles.ToList();
    }
    //al modificar la fecha verifica la disponibilidad para ese rango de fecha nuevo
    public bool TraerDisponibilidadHotelParaEdicion(Int32 idhotel, DateTime fechaIngreso, DateTime fechaEgreso, Int32 cantPersonas, Int32 idReservaHotel)
    {
        Hotel miHotel = this.getHoteles().FirstOrDefault(x => x.id == Convert.ToInt32(idhotel));
        bool estaRango = false;
        bool entrorango = false;
        int difcantPer = miHotel.capacidad;
        bool hayDisponibilidad = false;
        int total = 0;
        // recorre sobre el hotel, las reservas de ese hotel
        foreach (var itemReserva in miHotel.listMisReservas)
        {   // verifica si la fecha seleccionada esta en el rango de las fechas reservadas
            estaRango = this.verificacionRango(itemReserva, miHotel, fechaIngreso, fechaEgreso);
            //si esta en rango, resta la capacidad del hotel sobre la cantidad de personas que reservaron esa fecha
            if (estaRango)
            {
                // si es la reserva que estoy editando
                if (itemReserva.idReservaHotel == idReservaHotel)
                {
                    //le pasa la nueva cantidad de personas y se la resta a la capacidad
                    itemReserva.cantidadPersonas = cantPersonas;
                    difcantPer = difcantPer - itemReserva.cantidadPersonas;
                }
                else
                {
                    difcantPer = difcantPer - itemReserva.cantidadPersonas;
                }
                entrorango = true;
            }
        }
        //si entro dentro de rango, significa que esta validando sobre un rango de fecha de reserva, estoy quiere 
        //decir que la resta de la cantidad de personas elejidas para la edicion ya esta contemplada por lo tanto solo se le pasa el monto, si la nueva edicion
        //no esta dentro de un rango la resta se realiza
        if (entrorango)
            total = difcantPer;
        else
            total = difcantPer - cantPersonas;

        //si la cantidad de personas contabilizadas por cada reserva y las nuevas ingresadas, "total" es menor siginifica que hay capacidad ya que total es menos a capacidad del hotel
        if (miHotel.capacidad >= total && total >= 0)
            hayDisponibilidad = true;

        return hayDisponibilidad;
    }
    public List<Hotel> TraerDisponibilidadHotel(string ciudadSeleccionada, DateTime fechaIngreso, DateTime fechaEgreso, Int32 cantPersonas)
    {
        bool estaRango;
        int difCantPer = 0;
        List<Hotel> hotelesDisponibles = new List<Hotel>();
        //recorre por cada hotel las reservas
        foreach (var itemHotel in this.getHoteles())
        {
            if (itemHotel.ubicacion.nombre.Trim().ToUpper() == ciudadSeleccionada.Trim().ToUpper())
            {
                difCantPer = itemHotel.capacidad;
                foreach (var itemReserva in itemHotel?.listMisReservas)
                {
                    //Verifica si esta en rango de fecha seleccionada con respecto a la fechas de las reservas que hay en el hotel
                    estaRango = this.verificacionRango(itemReserva, itemHotel, fechaIngreso, fechaEgreso);
                    if (estaRango)
                    {
                        //si esta en rango, le va restando la cantidad de personas por reserva a la capacidad total sobre ese rango de fecha que debe coincidir con el rango de fecha seleccionado
                        difCantPer = difCantPer - itemReserva.cantidadPersonas;
                    }
                }
                //a esa resta que se le hizo de la capacidad total, se le resta tamb la cantidad de personas que se ingreso en esa alta de reserva
                int total = difCantPer - cantPersonas;
                //se agrega a la lista si el hotel esta disponible, si hay disponibilidad en esa fecha.
                if (itemHotel.capacidad >= total && total >= 0)
                    hotelesDisponibles.Add(itemHotel);
            }
        }

        return hotelesDisponibles;
    }
    //Corrobora si esta en el reango de las fechas de las reservas del hotel
    private bool verificacionRango(ReservaHotel itemReserva, Hotel itemHotel, DateTime fechaIngreso, DateTime fechaEgreso)
    {
        bool estaRango = false;

        if (itemReserva.miHotel.id == itemHotel.id)
        {

            if ((itemReserva.fechaDesde.Date >= fechaIngreso.Date) && (itemReserva.fechaHasta.Date <= fechaEgreso.Date))
            {
                estaRango = true;
            }

            if (fechaIngreso.Date >= itemReserva.fechaDesde && fechaIngreso.Date <= itemReserva.fechaHasta.Date)
            {
                estaRango = true;
            }

            if (fechaEgreso.Date <= itemReserva.fechaHasta.Date && fechaEgreso.Date >= itemReserva.fechaDesde.Date)
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


    public void eliminarRerservaHotel(Int32 idReservaHotel, double costo)
    {
        //elimina el hotel de la base
        this.elimiarReservaHotelContext(idReservaHotel);
        //Trae el usuario actual y le suma a su credito el valor de la reserva eliminada
        Usuario usuarioActual = this.getUsuarioActual();
        usuarioActual.credito = usuarioActual.credito + costo;
        //Modifica el credito del usuario en la base
        this.modificarCreditoContext(usuarioActual);
        //Trae desde la memoria del usuario actual, las listas de sus reservas y la elimina de la memoria del usuario actual
        ReservaHotel reservaHotel = this.getUsuarioActual().listMisReservasHoteles.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
        this.getUsuarioActual().listMisReservasHoteles.Remove(reservaHotel);
    }

    public void devolverDineroOsumarDinero(DateTime fechaDesde, DateTime fechaHasta, List<ReservaHotel> misReservas, Int32 idReservaHotel, Hotel miHotel)
    {
        double costo = 0;
        ReservaHotel miReserva = misReservas.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
        TimeSpan tsseleccion = fechaHasta.Date.Subtract(fechaDesde.Date);
        TimeSpan tsBase = miReserva.fechaHasta.Date.Subtract(miReserva.fechaDesde.Date);
        Int32 sumarCostoPorDia = (tsseleccion.Days + 1) - (tsBase.Days + 1);
        //si da positivo la  suma de  (sumarCostoPorDia * miHotel.costo) va a sumar si da negativo va a restar porque + * - es menos
        costo = this.usuarioActual.credito + (sumarCostoPorDia * miHotel.costo);
        this.getUsuarioActual().credito = costo;
        this.modificarCreditoContext(this.getUsuarioActual());
    }

    public void editarReservaHotel(DateTime fechaDesde, DateTime fechaHasta, double pagado, Int32 idReservaHotel, Int32 idHotel, Int32 cantPers)
    {
        //Trae el hotel buscandolo en el contexto por id hotel
        Hotel miHotel = this.getHoteles().FirstOrDefault(x => x.id == idHotel);
        //si la fecha es mayor a la editada, suma el costo a lo que tenia, si es menor se lo resta 
        this.devolverDineroOsumarDinero(fechaDesde, fechaHasta, this.getUsuarioActual().listMisReservasHoteles, idReservaHotel, miHotel);
        //Modifica la reserva en la base
        this.modificarReservaHotelContext(fechaDesde, fechaHasta, pagado, idReservaHotel, cantPers);
        ReservaHotel reservaHotelUsuarioActual = this.getUsuarioActual().listMisReservasHoteles.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
        //Modifica la reserva en la reserva del usuario actual
        Usuario usuarioActual = this.getUsuarioActual();
        foreach (var itemreserva in usuarioActual.listMisReservasHoteles)
        {
            if (itemreserva.idReservaHotel == reservaHotelUsuarioActual.idReservaHotel)
            {
                itemreserva.cantidadPersonas = cantPers;
                itemreserva.fechaDesde = fechaDesde;
                itemreserva.fechaHasta = fechaHasta;
                itemreserva.pagado = pagado;
            }
        }

        this.modificarUsuarioActual(usuarioActual);
    }


    public ReservaHotel? GenerarReserva(string nombreHotel, DateTime fechaIngreso, DateTime fechaEgreso, string textBoxMonto, string cantidadPersonas)
    {
        //Busco el hotel por nombre
        Hotel hotelSeleccionado = this.getHotelesByHotel(nombreHotel);
        //Calcula el costo por rango de fechas, sobre el costo que sale el hotel lo multiplica por cantidad de dias
        TimeSpan ts = fechaEgreso.Date.Subtract(fechaIngreso.Date);
        double costo = ((ts.Days + 1) * hotelSeleccionado.costo);
        ReservaHotel? reservaHotel = null;
        Usuario? usuarioActual = null;
        //Verifica que el costo calculado sea igual al costo ingresado
        if (costo == Convert.ToDouble(textBoxMonto))
        {
            try
            {
                //crea un objeto reserva hotel
                reservaHotel = new ReservaHotel(hotelSeleccionado, this.getUsuarioActual(), fechaIngreso, fechaEgreso, Convert.ToDouble(textBoxMonto), Convert.ToInt32(cantidadPersonas));
                //Genera la reserva en la base a traves del context
                this.generarReservaContext(reservaHotel);
                //obtiene el objeto de la tabla intermedia correspondiente al id usuario y al hotel
                HotelUsuario? hotelUsuario = contexto.HotelUsuario.Where(x => x.idUsuario == reservaHotel.miUsuario.id && x.idHotel == reservaHotel.miHotel.id).FirstOrDefault();
                //Modifica la tabla intermedia o genera un registro nuevo dependiendo si existe esa relacion de hotel, usuario
                this.generarHotelUsuario(hotelUsuario, reservaHotel);
                //se obtiene el usuario actual, se le resta el credito para que quede registrado en memoria
                usuarioActual = this.getUsuarioActual();
                usuarioActual.credito = this.getUsuarioActual().credito - Convert.ToDouble(textBoxMonto);
                //se modifica el dato en la base a traves del context
                modificarCreditoContext(usuarioActual);
                this.modificarUsuarioActual(usuarioActual);
            }
            catch (Exception)
            {
                return null;
            }
            //setea el usuario actual
            return reservaHotel;
        }
        else
        {
            return null;
        }
    }

    public void modificarUsuarioActual(Usuario usuario)
    {
        this.usuarioActual = usuario;
    }

    public List<Hotel> traerMisHoteles(Int32 idUsuario)
    {
        return this.misHotelesQueVisiteContext(idUsuario);
    }
    //Calcula el costo directamente con datos de fecha, verifica cuantos dias hay entre fechas y lo multiplica por lo que sale el hotel por dia
    public double CalcularCostoParaEdicion(DateTime fechaDesde, DateTime fechaHasta, Int32 idHotel)
    {
        Hotel miHotel = this.getHoteles().FirstOrDefault(x => x.id == idHotel);
        TimeSpan ts = fechaHasta.Date.Subtract(fechaDesde.Date);
        return (ts.Days + 1) * miHotel.costo;
    }

    //Calcula el costo desde la reserva, verifica cuantos dias hay entre fechas y lo multiplica por lo que sale el hotel por dia
    public double CalcularCosto(DateTime fechaHasta, DateTime fechaDesde, double costo)
    {
        TimeSpan ts = fechaHasta.Date.Subtract(fechaDesde.Date);
        return ((ts.Days + 1) * costo);
    }
    //Verifica si esta en rango de fecha seleccionada, si esta en rango resta sobre la cantidad de personas que esta en la reserva sobre la capasidad que existe en ese rengo de fechas
    public int calcularDisponibilidad(Hotel itemHotel, DateTime fechaIngreso, DateTime fechaEgreso)
    {
        int difCantPer = itemHotel.capacidad;
        bool estaRango;
        foreach (var itemMiReserva in itemHotel.listMisReservas)
        {
            estaRango = this.verificacionRango(itemMiReserva, itemHotel, fechaIngreso, fechaEgreso);
            if (estaRango)
            {
                difCantPer = difCantPer - itemMiReserva.cantidadPersonas;
            }
        }
        return difCantPer;
    }

    #endregion


    #region reservaHoteles Context


    public List<Hotel>? misHotelesQueVisiteContext(Int32 idUsuario)
    {
        try
        {
            var listHoteles = from hu in contexto.HotelUsuario
                              join h in contexto.hoteles on hu.idHotel equals h.id
                              where hu.idUsuario == idUsuario
                              select new { h }.h;
            return listHoteles.ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public bool generarHotelUsuario(HotelUsuario? hotelUsuario, ReservaHotel reservaHotel)
    {
        try
        {
            //si no existe el hotel crea una nueva realacion y genera como registro que se visito una ves a ese hotel, si no modifica la cantidad sumandole uno a esa visita
            if (hotelUsuario == null)
            {
                contexto.HotelUsuario.Add(new HotelUsuario() { idHotel = reservaHotel.miHotel.id, idUsuario = reservaHotel.miUsuario.id, cantidad = 1 });
            }
            else
            {
                hotelUsuario.cantidad++;
                contexto.HotelUsuario.Update(hotelUsuario);
            }
            contexto.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public bool generarReservaContext(ReservaHotel reservaHotel)
    {
        try
        {
            contexto.reservaHoteles.Add(reservaHotel);
            contexto.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public bool modificarCreditoContext(Usuario usuarioActual)
    {
        try
        {
            Usuario? usuario = contexto.usuarios.Where(u => u.id == usuarioActual.id).FirstOrDefault();

            if (usuario != null)
            {
                usuario.credito = usuarioActual.credito;
                contexto.usuarios.Update(usuario);
                contexto.SaveChanges();
                return true;
            }
            else
                return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool modificarReservaHotelContext(DateTime fechaDesde, DateTime fechaHasta, double pagado, Int32 idReservaHotel, Int32 cantPers)
    {
        try
        {
            ReservaHotel? reservaHotel = contexto.reservaHoteles.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
            reservaHotel.fechaDesde = fechaDesde;
            reservaHotel.fechaHasta = fechaHasta;
            reservaHotel.pagado = pagado;
            reservaHotel.cantidadPersonas = cantPers;
            contexto.reservaHoteles.Update(reservaHotel);
            contexto.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool elimiarReservaHotelContext(Int32 idReservaHotel)
    {
        try
        {
            ReservaHotel reservaHotel = contexto.reservaHoteles.Where(x => x.idReservaHotel == idReservaHotel).FirstOrDefault();
            if (reservaHotel != null)
            {
                contexto.reservaHoteles.Remove(reservaHotel);
                contexto.SaveChanges();
                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void volverIntentosFallidosCeroContext()
    {
        try
        {
            Usuario usuario = this.getUsuarioActual();
            usuario.intentosFallidos = 0;
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void IngresarIntentosFallidosContext(Usuario usu)
    {
        try
        {
            Usuario usuario = contexto.usuarios.FirstOrDefault(x => x.id == usu.id);
            usuario.intentosFallidos = usuario.intentosFallidos;
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void IngresarUsuarioBloqueadoContext()
    {
        try
        {
            Usuario usuario = this.getUsuarioActual();
            usuario.bloqueado = true;
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion
}

