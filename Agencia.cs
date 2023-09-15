using System;
using tpAgencia_Gpo_2;

public class Agencia
{
	private List<Usuario> Usuarios;
	private List<Hotel> Hoteles;
	private List<Vuelo> Vuelos;
	private List<Ciudad> Ciudades;
	private List<ReservaHotel> ReservasHotel;
	private List<ReservaVuelo> ReservasVuelo;
	private Usuario UsuarioActual { get; set; };

	//metodo constructor
	public Agencia()
	{
	}


    public void registrarUsuario(int id, string name, string apellido, int dni, string mail, string password, bool esAdmin)
    {
        Usuario usuario = new Usuario(id,name,apellido,dni,mail, password, esAdmin);
        Usuarios.add(usuario);
    }

    public bool IniciarSesion(String mail, String password)
    {
        foreach (Usuario usuario in Usuarios)
        {
            if (usuario.mail == mail && usuario.password == password)
            {
                if (!usuario.bloqueado)
                {
                    //UsuarioActual.usuario; nose
                    return true; // Sesión iniciada con éxito
                }
                else
                {
                    return false; // Usuario bloqueado
                }
            }
        }
        // Si no se encuentra el usuario o la contraseña es incorrecta se agrega un intento fallido
        foreach (Usuario usuario in Usuarios)
        {
            if (usuario.mail == mail))
            {
                usuario.agregarIntentoFallido();
                return false;
            }
        }

        return false; // Usuario no encontrado
    }
}
