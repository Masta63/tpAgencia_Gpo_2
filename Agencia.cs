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
    private DAL DB; //clase adicional para intercambio con base de datos // esta clase se debe remover


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
    public void cerrarContexto()
    {
        contexto.Dispose();//continuar
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


    public void setUsuario(Usuario usuario)
    {
        listUsuarios.Add(usuario);
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
        bool esValido = true;
        foreach (Usuario u in listUsuarios)
        {
            if (u.dni == Dni)
            {
                esValido = false;
            }
        }
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
                return false;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public bool eliminarUsuarioDal(int Id)
    {
        DB.eliminarUsuarioHotel(Id);
        DB.eliminarReservaHoteldeUsuario(Id);
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


    public bool modificarUsuarioDal(int Id, string Nombre, string Apellido, int Dni, string Mail, string pass)
    {
        //primero me aseguro que lo pueda agregar a la base
        //int Id, string Nombre, string Apellido, string Dni, string Mail
        if (DB.modificarUsuarioConContraseña(Id, Nombre, Apellido, Dni, Mail, pass) == 1)
        {
            try
            {
                //Ahora sí lo MODIFICO en la lista
                for (int i = 0; i < listUsuarios.Count; i++)
                    if (listUsuarios[i].id == Id)
                    {
                        listUsuarios[i].name = Nombre;
                        listUsuarios[i].apellido = Apellido;
                        listUsuarios[i].mail = Mail;
                        listUsuarios[i].dni = Dni.ToString();
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
        try
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
        catch (Exception)
        {

            throw;
        }
    }

    public bool modificarPasswordDal(int id, string text)
    {
        try
        {
            if (DB.modificarPassword(id, text) == 1)
            {
                return modificarPassword(id, text);
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
        try
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
        catch (Exception)
        {

            throw;
        }
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
        if (DB.eliminarCiudad(id) == 1)
        {
            try
            {
                foreach (Ciudad itemCiudad in ciudades)
                {
                    if (itemCiudad.id == id)
                    {
                        ciudades.Remove(itemCiudad);

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        return false;
    }

    public bool agregarCiudad(string nombre)
    {

        int idNuevoCiudad;
        idNuevoCiudad = DB.agregarCiudad(nombre);
        if (idNuevoCiudad != -1)
        {
            Ciudad nuevo = new Ciudad(idNuevoCiudad, nombre);
            ciudades.Add(nuevo);
            return true;
        }
        else
        {
            return false;
        }

    }

    public int modificarCiudad(int id, string nombre)
    {
        if (DB.modificarCiudad(id, nombre) == 1)
        {
            foreach (Ciudad c in ciudades)
            {
                if (c.id == id)
                {
                    c.nombre = nombre;

                    return 1;
                }
            }
            return 1;
        }
        return -1;
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


    //Deberían buscar un objeto reservaVuelo con el idReserva, el vuelo no cambia, sólo cantidad o monto. El vuelo de esa reserva ya lo deberían tener por referencia
    //(solo que no vincularon al inicio), es reservaVuelo.miVuelo. Usar RecargarMisReservasVuelo aquí no tiene sentido, al modificar el objeto reserva por referencia,
    //la lista de reservas del usuario ya apunta al objeto modificado pero ustedes la están recargando de forma continua desde la base.
    //A ver, si cambia la cantidad, hay que cambiar la cantidad en reserva y también en vuelo, ver si son más o menos pasajeros y agregar o quitar pasajeros según corresponda en la property vendido,
    //no en capacidad (línea 557 mal), ojo tienen que validar que el vuelo tenga capacidad. Lo que modifica costo es la reservaVuelo no el vuelo que mantiene su costo por persona. Línea 556 mal.
    //usuarioActual.credito = usuarioActual.credito - vuelo.costo; pero no validamos si lo q paga ahora es más o menos que antes quizás tenemos que sumarle crédito, y si le tenemos que restar,
    //tiene crédito suficiente?
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
                            vuelo.capacidad = vuelo.capacidad - cantidad;
                            DB.modificarCapacidadVuelo(vuelo.id, vuelo.capacidad);
                            usuarioActual.credito = usuarioActual.credito - vuelo.costo;
                            DB.modificarCreditoUsuario(usuarioActual.id, usuarioActual.credito);
                            RecargarMisReservasVuelo();

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
    public void RecargarMisReservasVuelo()
    {

        List<ReservaVuelo> nuevasReservas = DB.traerReservasVuelo(usuarioActual.id);


        usuarioActual.listMisReservasVuelo = nuevasReservas;
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
        List<Vuelo> vuelosDisponibles = new List<Vuelo>();
        foreach (Vuelo vuelo in contexto.vuelos)
        {

            if (vuelo.origen.nombre == origen.nombre && vuelo.destino.nombre == destino.nombre && vuelo.fecha.Date == fecha.Date && vuelo.capacidad >= cantidadPax + vuelo.vendido)
            {
                vuelosDisponibles.Add(vuelo);
            }

        }
        return vuelosDisponibles;

    }
    public bool vincularVueloUsuarios(int vueloId, int usuarioId, int cant )
    {
        try {
            Vuelo vu = contexto.vuelos.Where(v => v.id == vueloId).FirstOrDefault();
            Usuario us = contexto.usuarios.Where(u => u.id == usuarioId).FirstOrDefault();
            VueloUsuario vueloUsuarioSelected = contexto.vueloUsuarios.Where(vus => vus.idUsuario == usuarioId && vus.idVuelo == vueloId).FirstOrDefault();
            if (us != null && vu !=null && vueloUsuarioSelected != null) 
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
        Vuelo vuelo = contexto.vuelos.Where(v=> v.id == vueloId).FirstOrDefault();
        
        if (contexto.vueloUsuarios.Any(vu=> vu.idVuelo == vueloId && vu.idUsuario == usuarioActual.id))
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
                usuarioActual.listMisReservasVuelo.Add(reserva);
                usuarioActual.credito = usuarioActual.credito - reserva.pagado;
                //esta linea revisar
                usuarioActual.listVuelosTomados.Add(vuelo);
                vincularVueloUsuarios(vueloId, usuarioActual.id, cantidad);
         
                contexto.SaveChanges();
                return "exito";
               
            }
            return "sinSaldo";

        }
        return "error";

    }


    public List<Vuelo> misVuelos(Usuario usuarioActual)
    {

        List<ReservaVuelo> reservasVuelo = contexto.reservaVuelos.Where(rv => rv.idUsuario == usuarioActual.id).ToList();
        return usuarioActual.listVuelosTomados = reservasVuelo.Select(reserva => reserva.miVuelo).ToList();
    }

    
    public string eliminarReservaVuelo(int reservaVueloId)
    {
        try
        {
            ReservaVuelo reservaVuelo = contexto.reservaVuelos.SingleOrDefault(rv => rv.idReservaVuelo == reservaVueloId);
            Vuelo v = contexto.vuelos.Where(v => v.id == reservaVuelo.idVuelo).FirstOrDefault();

            if (reservaVuelo != null)
            {
                DateTime fechaActual = DateTime.Now;

                if (v.fecha >= fechaActual)
                {
                    double costoTotalReserva = reservaVuelo.pagado;
                    usuarioActual.credito += costoTotalReserva;

                    int cantReservas = (int)(reservaVuelo.pagado / v.costo);
                    v.vendido -= cantReservas;
                    v.listMisReservas.Remove(reservaVuelo);
                    usuarioActual.listMisReservasVuelo.Remove(reservaVuelo);
                    contexto.SaveChanges();
                    return  "ReservaEliminada";

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
        Ciudad ubicacion = ciudades.FirstOrDefault(ciudad => ciudad.id == ubicacionHotel);
        int idNuevoHotel;
        idNuevoHotel = DB.agregarHotel(ubicacionHotel, capacidad, costo, nombre);
        if (idNuevoHotel != -1)
        {
            Hotel nuevo = new Hotel(ubicacion, capacidad, costo, nombre);
            nuevo.id = idNuevoHotel;
            hoteles.Add(nuevo);
            return true;
        }
        else
        {
            return false;
        }
    }



    public string modificarHotel(int idHotel, int ubicacionHotel, int capacidad, float costo, string nombre)
    {

        Ciudad nuevaUbicacion = ciudades.FirstOrDefault(ciudad => ciudad.id == ubicacionHotel);
        if (DB.modificarHotel(idHotel, ubicacionHotel, capacidad, costo, nombre) == 1)
        {
            try
            {
                foreach (Hotel hotel in hoteles)
                {
                    if (hotel.id == idHotel)
                    {
                        hotel.ubicacion = nuevaUbicacion;
                        hotel.capacidad = capacidad;
                        hotel.costo = costo;
                        hotel.nombre = nombre;

                        return "exito";


                    }

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
        DB.eliminarReservaHotel(idHotel);
        DB.eliminarHotelUsuario(idHotel);
        if (DB.eliminarHotel(idHotel) == 1)
        {
            try
            {
                foreach (Hotel h in hoteles)
                    if (h.id == idHotel)
                    {
                        hoteles.Remove(h);
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
            return false;
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
    public bool TraerDisponibilidadHotelParaEdicion(Hotel hotel, DateTime fechaIngreso, DateTime fechaEgreso, Int32 cantReserva)
    {
        bool estaRango = false;
        bool porHotel = true;
        int cantPer = 0;
        bool tieneReservas = false;
        bool hayDisponibilidad = false;

        porHotel = true;
        foreach (var itemReserva in hotel.listMisReservas)
        {
            estaRango = this.verificacionRango(itemReserva, hotel, fechaIngreso, fechaEgreso);

            if (porHotel)
            {
                hotel.disponibilidad = hotel.capacidad;
                porHotel = false;
            }

            if (estaRango)
            {
                hotel.disponibilidad = hotel.disponibilidad - 1;
                cantPer = hotel.disponibilidad;
            }
            else
            {
                cantPer = hotel.capacidad;
            }
            tieneReservas = true;
        }

        if (!tieneReservas)
        {
            hotel.disponibilidad = hotel.capacidad;
            hayDisponibilidad = true;
        }

        if (cantReserva <= cantPer)
            hayDisponibilidad = true;

        return hayDisponibilidad;
    }
    public List<Hotel> TraerDisponibilidadHotel(string ciudadSeleccionada, DateTime fechaIngreso, DateTime fechaEgreso, string cantReserva)
    {
        bool estaRango = false;
        bool porHotel = true;
        int cantPer = 0;
        bool tieneReservas = false;
        List<Hotel> hotelesDisponibles = new List<Hotel>();

        foreach (var itemHotel in this.getHoteles())
        {
            if (itemHotel.ubicacion.nombre.Trim().ToUpper() == ciudadSeleccionada.Trim().ToUpper())
            {
                porHotel = true;
                foreach (var itemReserva in itemHotel?.listMisReservas)
                {
                    estaRango = this.verificacionRango(itemReserva, itemHotel, fechaIngreso, fechaEgreso);

                    if (porHotel)
                    {
                        itemHotel.disponibilidad = itemHotel.capacidad;
                        porHotel = false;
                    }

                    if (estaRango)
                    {
                        itemHotel.disponibilidad = itemHotel.disponibilidad - 1;
                        cantPer = itemHotel.disponibilidad;
                    }
                    else
                    {
                        cantPer = itemHotel.capacidad;
                    }
                    tieneReservas = true;
                }


                if (!tieneReservas)
                {
                    itemHotel.disponibilidad = itemHotel.capacidad;
                    hotelesDisponibles.Add(itemHotel);
                }

                if (Convert.ToInt32(cantReserva) <= cantPer)
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


    public void eliminarRerservaHotel(Int32 idReservaHotel, double costo, Int32 idHotel)
    {
        this.elimiarReservaHotelContext(idReservaHotel);
        Usuario usuarioActual = this.getUsuarioActual();
        usuarioActual.credito = usuarioActual.credito + costo;
        this.modificarCreditoContext(usuarioActual.id, usuarioActual.credito);
        ReservaHotel reservaHotel = this.getUsuarioActual().listMisReservasHoteles.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
        this.getUsuarioActual().listMisReservasHoteles.Remove(reservaHotel);

    }

    public void devolverDinero(DateTime fechaDesde, DateTime fechaHasta, List<ReservaHotel> misReservas, Int32 idReservaHotel, Hotel miHotel)
    {
        double costo = 0;
        ReservaHotel miReserva = misReservas.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
        TimeSpan tsseleccion = fechaHasta.Date.Subtract(fechaDesde.Date);
        TimeSpan tsBase = miReserva.fechaHasta.Date.Subtract(miReserva.fechaDesde.Date);
        Int32 sumarCostoPorDia = (tsseleccion.Days + 1) - (tsBase.Days + 1);
        costo = this.usuarioActual.credito + (sumarCostoPorDia * miHotel.costo);
        this.modificarCreditoContext(this.usuarioActual.id, costo);
        this.getUsuarioActual().credito = costo;
    }

    public void editarReservaHotel(DateTime fechaDesde, DateTime fechaHasta, double pagado, Int32 idReservaHotel)
    {
        this.modificarReservaHotelContext(fechaDesde, fechaHasta, pagado, idReservaHotel);
        ReservaHotel reservaHotelUsuarioActual = this.usuarioActual.listMisReservasHoteles.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
        Usuario usuario = this.getUsuarioActual();
        foreach (var itemreserva in usuario.listMisReservasHoteles)
        {
            if (itemreserva.idReservaHotel == reservaHotelUsuarioActual.idReservaHotel)
            {
                itemreserva.fechaDesde = fechaDesde;
                itemreserva.fechaHasta = fechaHasta;
                itemreserva.pagado = pagado;
            }
        }
        this.modificarUsuarioActual(usuario);
    }


    public ReservaHotel? GenerarReserva(Hotel hotelSeleccionado, DateTime fechaIngreso, DateTime fechaEgreso, string textBoxMonto)
    {
        TimeSpan ts = fechaEgreso.Date.Subtract(fechaIngreso.Date);
        double costo = ((ts.Days + 1) * hotelSeleccionado.costo);
        ReservaHotel? reservaHotel = null;
        Usuario? usuarioActual = null;
        if (costo == Convert.ToDouble(textBoxMonto))
        {
            try
            {
                reservaHotel = new ReservaHotel(hotelSeleccionado, this.getUsuarioActual(), fechaIngreso, fechaEgreso, Convert.ToDouble(textBoxMonto));
                this.generarReservaContext(reservaHotel);
                HotelUsuario? hotelUsuario = contexto.HotelUsuario.Where(x => x.idUsuario == reservaHotel.miUsuario.id && x.idHotel == reservaHotel.miHotel.id).FirstOrDefault();
                this.generarHotelUsuario(hotelUsuario, reservaHotel);
                usuarioActual = this.getUsuarioActual();
                usuarioActual.credito = this.getUsuarioActual().credito - Convert.ToDouble(textBoxMonto);
                modificarCreditoContext(reservaHotel.miUsuario.id, usuarioActual.credito);
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

    #endregion


    #region reservaHoteles Context


    public List<Hotel> misHotelesQueVisiteContext(Int32 idUsuario)
    {
        try
        {
            List<Hotel> hotels = new List<Hotel>();
            List<HotelUsuario> HotelUsuario = contexto.HotelUsuario.Where(x => x.idUsuario == idUsuario).ToList();

            foreach (var itemHotelUsuario in HotelUsuario)
            {
                Hotel hotel = contexto.hoteles.FirstOrDefault(x => x.id == itemHotelUsuario.idHotel);
                hotels.Add(hotel);
            }
            return hotels;
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


    public bool modificarCreditoContext(Int32 idUsuario, double nuevoCredito)
    {
        try
        {
            Usuario? usuario = contexto.usuarios.Where(u => u.id == idUsuario).FirstOrDefault();

            if (usuario != null)
            {
                usuario.credito = nuevoCredito;
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

    public bool modificarReservaHotelContext(DateTime fechaDesde, DateTime fechaHasta, double pagado, Int32 idReservaHotel)
    {
        try
        {
            ReservaHotel? reservaHotel = contexto.reservaHoteles.FirstOrDefault(x => x.idReservaHotel == idReservaHotel);
            reservaHotel.fechaDesde = fechaDesde;
            reservaHotel.fechaHasta = fechaHasta;
            reservaHotel.pagado = pagado;
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