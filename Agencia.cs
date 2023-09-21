using System;
using tpAgencia_Gpo_2;
//hola

public class Agencia
{
	private List<Usuario> usuarios;
	private List<Hotel> hoteles;
	private List<Vuelo> vuelos;
	private List<Ciudad> ciudades;
	private List<ReservaHotel> reservasHotel;
	private List<ReservaVuelo> reservasVuelo;
	private Usuario usuarioActual { get; set; }
    private int cantVuelos;
    private int cantUsuarios = 0;

    //metodo constructor
    public Agencia()
	{
        usuarios = new List<Usuario>();
        hoteles = new List<Hotel>();
        vuelos = new List<Vuelo>();
        cantVuelos = 0;
        ciudades = new List<Ciudad>();
        reservasHotel = new List<ReservaHotel>();
        reservasVuelo = new List<ReservaVuelo>();
    }

    //INICIO METODOS DE USUARIO

    public void registrarUsuario(int id, string name, string apellido, string dni, string mail, string password, bool esAdmin)
    {
        Usuario usuario = new Usuario(id, name, apellido, dni, mail, password, esAdmin);
        usuarios.Add(usuario);
    }

    public bool IniciarSesion(String mail, String password)
    {
        foreach (Usuario usuario in usuarios)
        {
            if (usuario.mail.Equals(mail) && usuario.password.Equals(password))
            {
                if (!usuario.bloqueado)
                {
                    usuarioActual = usuario;
                    return true; // Sesión iniciada con éxito
                }
                else
                {
                    return false; // Usuario bloqueado
                }
            }
        }
        // Si no se encuentra el usuario o la contraseña es incorrecta se agrega un intento fallido
        foreach (Usuario usuario in usuarios)
        {
            if (usuario.mail.Equals(mail))
            {
                usuario.agregarIntentoFallido();
                return false;
            }
        }

        return false; // Usuario no encontrado
    }

    //-- metodos del formUsuario
    public List<Usuario> getUsuarios()
    {
        return usuarios.ToList();
    }

    public bool agregarUsuarioobjet(Usuario usuario)
    {
        Usuario obj = new Usuario(cantUsuarios,usuario.name,usuario.apellido,usuario.dni,usuario.mail);
        cantUsuarios++;
        usuarios.Add(obj);
        return true;
    }
    public bool agregarUsuario(string name, string apellido, string dni, string mail)
    {
        Usuario usuario = new Usuario(cantUsuarios, name, apellido, dni, mail);
        cantUsuarios++;
        usuarios.Add(usuario);
        return true;
    }

    public bool modificarUsuario(int id, string name, string apellido, string dni, string mail)
    {
        foreach (Usuario user in usuarios)
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
        foreach (Usuario user in usuarios)
        {
            if (user.id == id)
            {
                usuarios.Remove(user);
                return true;
            }
        }
        return false;
    }

    public bool modificarCredito(int id, double monto)
    {
        foreach (Usuario user in usuarios)
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
        foreach (Usuario user in usuarios)
        {
            if (user.id == id)
            {
                user.credito += monto;
                return true;
            }
        }
        return false;
    }



    //FIN METODOS USUARIO



















    // INICIO METODOS DE VUELO

    //ver lo que explicó el profesor
    public void cargarCredito(int idUsuario, double importe)
    {
     
        usuarioActual.credito += importe;
      
    }
    public bool agregarVuelo(Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion )
    {
       
        vuelos.Add(new Vuelo(cantVuelos,origen, destino, capacidad, costo, fecha, aerolinea, avion));
        cantVuelos++;
        return true;
    }

    public bool modificarVuelo(int id, Ciudad origen, Ciudad destino, int capacidad,double costo, DateTime fecha, string aerolinea, string avion)
    {
        foreach (Vuelo vuelo in vuelos)
        {
            if(vuelo.id == id)
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
        foreach(Vuelo vuelo in vuelos)
        { 
            if(vuelo.id == id)

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
