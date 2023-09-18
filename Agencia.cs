using System;
using tpAgencia_Gpo_2;
//hola

public class Agencia
{
    private List<Usuario> listUsuarios;
    private List<Hotel> Hoteles;
    private List<Vuelo> Vuelos;
    private List<Ciudad> Ciudades;
    private List<ReservaHotel> ReservasHotel;
    private List<ReservaVuelo> ReservasVuelo;
    private Usuario UsuarioActual;


    public List<Usuario> Usuarios
    {
        get => listUsuarios.ToList();
    }


    //metodo constructor
    public Agencia()
    {

        listUsuarios = new List<Usuario>();
    }


    public void setUsuario(Usuario usuario)
    {
        listUsuarios.Add(usuario);
    }

    public bool iniciarSesion(string pass, string mail)
    {
        bool encontre = false;
        foreach (Usuario user in listUsuarios)
        {
            if (user.pasword.Equals(pass) && user.mail.Equals(mail))
            {
                encontre = true;
                UsuarioActual = user;
            }
        }
        return encontre;
    }

    public string nombreLogueado()
    {
        return UsuarioActual.name;
    }


}
