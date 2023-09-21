using System;
using tpAgencia_Gpo_2;

public class Agencia
{
    private List<Usuario> listUsuarios;
    private List<Hotel> hoteles;
    private List<Vuelo> vuelos;
    private List<Ciudad> ciudades;
    private List<ReservaHotel> reservasHotel;
    private List<ReservaVuelo> reservasVuelo;
    private Usuario usuarioActual { get; set; }
    private int cantVuelos;
    private int cantUsuarios = 0;
    private Usuario UsuarioActual;

    //metodo constructor
    public Agencia()
    {
        hoteles = new List<Hotel>();
        vuelos = new List<Vuelo>();
        cantVuelos = 0;
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

    public Usuario getUsuarioActual()
    {
        return UsuarioActual;
    }

    public List<Usuario> getListUsuario()
    {
        return listUsuarios;
    }


    public bool iniciarSesion(string pass, string mail)
    {
        bool encontre = false;
        foreach (Usuario user in listUsuarios)
        {
            if (user.password.Equals(pass) && user.mail.Equals(mail))
            {
                encontre = true;
                UsuarioActual = user;
            }
        }
        return encontre;
    }


    //public bool IniciarSesion(String mail, String password)
    //{
    //    foreach (Usuario usuario in usuarios)
    //    {
    //        if (usuario.mail.Equals(mail) && usuario.password.Equals(password))
    //        {
    //            if (!usuario.bloqueado)
    //            {
    //                usuarioActual = usuario;
    //                return true; // Sesión iniciada con éxito
    //            }
    //            else
    //            {
    //                return false; // Usuario bloqueado
    //            }
    //        }
    //    }
    //    // Si no se encuentra el usuario o la contraseña es incorrecta se agrega un intento fallido
    //    foreach (Usuario usuario in usuarios)
    //    {
    //        if (usuario.mail.Equals(mail))
    //        {
    //            usuario.agregarIntentoFallido();
    //            return false;
    //        }
    //    }

    //    return false; // Usuario no encontrado
    //}

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



    public string nombreLogueado()
    {
        return UsuarioActual.name;
    }


    //FIN METODOS USUARIO




    // INICIO METODOS DE VUELO

    //ver lo que explicó el profesor
    public void cargarCredito(int idUsuario, double importe)
    {

        usuarioActual.credito += importe;

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

    //Método solo para las pruebas de vuelo, hay que borrarlo y agregar el que pase Nati
    public List<Ciudad> GetCiudades()
    {
        ciudades.Add(new Ciudad(1, "Bariloche"));
        ciudades.Add(new Ciudad(2, "Mendoza"));
        ciudades.Add(new Ciudad(3, "Buenos Aires"));
        return ciudades.ToList();
    }

    //FIN METODOS DE VUELO
}
