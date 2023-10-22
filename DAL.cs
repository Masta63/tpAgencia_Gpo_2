using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;//debemos agregar para poder usar los metodos de conexion dy reader

namespace tpAgencia_Gpo_2
{
    class DAL
    {
        private String connectionStr; //atributo que vamos a usar frecuentemente

        public DAL()
        {
            //cargar la cadena de conexion desde el archivo properties
            //proyecto-> propiedades->recursos-> crear o abrir
            //en el valor va el conection string que tenemos de la base de datos
            connectionStr = Properties.Resources.ConnectionStr; //debemos cargar cada uno en nuestra resoursces el string para urilizarlo
        }


        // -- METODOS DE USUARIO --
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //string con la consulta que quiero realizar
            string queryString = "SELECT * from Usuario";


            //creo conexion con la base de datos el using al finalizar el metodo utiliza el dispose y cierra la conexion para ahorrar recursos
            using (SqlConnection conex = new SqlConnection(connectionStr))//OBJETO<--1
            {

                SqlCommand command = new SqlCommand(queryString, conex);//OBJETO<--2
                try
                {

                    conex.Open();//metodo que ejecuta la conexion con la base de datos

                    //OBJETO<--3
                    SqlDataReader reader = command.ExecuteReader();// creo el objeto para leer la base de datos y ejecutar el comando
                    Usuario aux;

                    while (reader.Read())//metodo devuelve true mientras siga leyendo una fila sigue el bucle
                    {
                        //leo la fila, la carga en la variable aux y la agrega a mis usuarios para trabajar en tiempo de ejecucion 
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetDouble(8), reader.GetBoolean(9));
                        misUsuarios.Add(aux);

                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;

        }

        //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
        //[idUsuario],[dni],[nombre],[apellido],[mail],[password],[intentosFallidos],[bloqueado],[credito],[esAdmin]
        public int agregarUsuario(string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string queryString = "INSERT INTO [dbo].[Usuario] ([dni],[nombre],[apellido],[mail],[password],[intentosFallidos],[bloqueado],[credito],[esAdmin]) VALUES (@dni,@nombre,@apellido,@mail,@password,@intentosFallidos,@bloqueado,@credito,@esadm);";
            using (SqlConnection connection =
                new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));//definimos los parametros las condiciones que queremos que respete
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@intentosFallidos", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@credito", SqlDbType.Float));
                command.Parameters["@dni"].Value = Dni;//estos valores hace referencia a los parametros que definimos arriba 
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadm"].Value = EsADM;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@credito"].Value = 0;
                command.Parameters["@intentosFallidos"].Value = 0;


                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    //no abrimos un datareader, con este metodo capturamos la cantidad de filas afectadas
                    //si creamos un datareader esta mal xk no necesita ser leida una tabla
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([idUsuario]) FROM [dbo].[Usuario]";// con esta consulta capturamos el ultimo agregado, no es lo optimo sino que tenga un where para filtrar por dni
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);//guardamos el id del nuevo usuario en una variable
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoUsuario;
            }
        }

        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int eliminarUsuario(int Id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Usuario] WHERE [idUsuario]=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = Id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int modificarUsuario(int Id, string Nombre, string Apellido, int Dni, string Mail)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuario] SET nombre = @nombre, apellido = @apellido, dni = @dni, mail = @mail WHERE [idUsuario] = @id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters["@id"].Value = Id;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@mail"].Value = Mail;
                try
                {
                    connection.Open();
                    // Esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }


        public int agregoCreditoUsuario(int idUsuario, double nuevoCredito)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [tp_agencia].[dbo].[Usuario] SET [credito] = [credito] + @credito  WHERE [idUsuario] = @idUsuario;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@credito", SqlDbType.Float));

                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@credito"].Value = nuevoCredito;

                try
                {
                    conex.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //modificar el password

        public int modificarPassword(int idUsuario, string nuevaPassword)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [tp_agencia].[dbo].[Usuario] SET [password] = @nuevaPassword WHERE [idUsuario] = @idUsuario;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@nuevaPassword", SqlDbType.NVarChar));

                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@nuevaPassword"].Value = nuevaPassword;

                try
                {
                    conex.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        // -- FIN METODOS DE USUARIO

        public List<Ciudad> inicializarCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();


            string queryString = "SELECT * from Ciudad";



            using (SqlConnection conex = new SqlConnection(connectionStr))
            {

                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {

                    conex.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    Ciudad aux;

                    while (reader.Read())
                    {
                        aux = new Ciudad(reader.GetInt32(0), reader.GetString(1));
                        ciudades.Add(aux);

                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ciudades;

        }

        public List<Vuelo> inicializarVuelos()
        {
            List<Vuelo> vuelos = new List<Vuelo>();

            string queryString = "SELECT V.*, C1.nombre AS OrigenNombre, C2.nombre AS DestinoNombre FROM Vuelo AS V " +
                                "INNER JOIN Ciudad AS C1 ON V.IdOrigen = C1.IdCiudad " +
                                "INNER JOIN Ciudad AS C2 ON V.IdDestino = C2.IdCiudad";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);

                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Vuelo aux;

                    while (reader.Read())
                    {

                        Ciudad origen = new Ciudad(reader.GetInt32(1), reader.GetString(9));
                        Ciudad destino = new Ciudad(reader.GetInt32(2), reader.GetString(10));

                        int? vendido = null;
                        if (!reader.IsDBNull(4))
                        {
                            vendido = reader.GetInt32(4);
                        }



                        aux = new Vuelo(reader.GetInt32(0), origen, destino, reader.GetInt32(3), reader.GetDouble(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8));
                        vuelos.Add(aux);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return vuelos;
        }

        
        public int agregarVuelo(int idOrigen, int idDestino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            int resultadoQuery;
            int idNuevoVuelo = -1;
            string queryString = "INSERT INTO [dbo].[Vuelo]([idOrigen], [idDestino], [capacidad], [costo],[fecha], [aerolinea], [avion]) VALUES (@idOrigen, @idDestino, @capacidad,@costo, @fecha, @aerolinea,@avion);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idOrigen", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idDestino", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@aerolinea", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@avion", SqlDbType.NVarChar));
                cmd.Parameters["@idOrigen"].Value = idOrigen;
                cmd.Parameters["@idDestino"].Value = idDestino;
                cmd.Parameters["@capacidad"].Value = capacidad;

                cmd.Parameters["@costo"].Value = costo;
                cmd.Parameters["@fecha"].Value = fecha;
                cmd.Parameters["@aerolinea"].Value = aerolinea;
                cmd.Parameters["@avion"].Value = avion;

                try
                {
                    conex.Open();
                    resultadoQuery = cmd.ExecuteNonQuery();

                    string ConsultaId = "SELECT MAX([idVuelo]) FROM [dbo].[Vuelo]";
                    cmd = new SqlCommand(ConsultaId, conex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    idNuevoVuelo = reader.GetInt32(0);
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoVuelo;
            }


        }

        public int eliminarVuelo(int id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Vuelo] WHERE idVuelo=@id";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                try
                {
                    conex.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;

                }
            }
        }


        public int modificarVuelo(int id, int idOrigen, int idDestino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Vuelo] SET idOrigen=@idOrigen, idDestino=@idDestino, capacidad=@capacidad, costo=@costo, fecha=@fecha, aerolinea=@aerolinea, avion=@avion WHERE idVuelo=@id;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idOrigen", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idDestino", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@aerolinea", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@avion", SqlDbType.NVarChar));
                cmd.Parameters["@id"].Value = id;
                cmd.Parameters["@idOrigen"].Value = idOrigen;
                cmd.Parameters["@idDestino"].Value = idDestino;
                cmd.Parameters["@capacidad"].Value = capacidad;
                cmd.Parameters["@costo"].Value = costo;
                cmd.Parameters["@fecha"].Value = fecha;
                cmd.Parameters["@aerolinea"].Value = aerolinea;
                cmd.Parameters["@avion"].Value = avion;
                try
                {
                    conex.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }


        #region reservaHotel
        public List<ReservaHotel> traerReservasPorHotel(Hotel hotel)
        {
            List<ReservaHotel> reservasPorHotel = new List<ReservaHotel>();
            string queryString = "SELECT * FROM [sistema].[dbo].[ReservaHotel] as res inner join [sistema].[dbo].[Usuario] as u on res.idUsuario = u.idUsuario where idHotel=" + hotel.id;
            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario miUsuario = new Usuario(reader.GetInt32(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetInt32(12), reader.GetBoolean(13), reader.GetDouble(14), reader.GetBoolean(15));
                        ReservaHotel reserva = new ReservaHotel(hotel, miUsuario, reader.GetDateTime(2), reader.GetDateTime(3), reader.GetDouble(4));
                        reservasPorHotel.Add(reserva);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return reservasPorHotel;
        }

        public List<Usuario> traerMisHuespedesPorHotel(Hotel hotel)
        {
            List<Usuario> huespedes = new List<Usuario>();
            string queryString = "SELECT *  FROM [sistema].[dbo].[Hotel_Usuario] as hu inner join [sistema].[dbo].[Usuario] as u on hu.idUsuario = u.idUsuario where hu.idHotel =" + hotel.id;

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario misHuespedes = new Usuario(reader.GetInt32(1), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetInt32(9), reader.GetBoolean(10), reader.GetDouble(11), reader.GetBoolean(12));
                        huespedes.Add(misHuespedes);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return huespedes;
        }

        public List<Hotel> inicializarHoteles()
        {
            List<Hotel> Hoteles = new List<Hotel>();
            string queryString = "SELECT *  FROM [sistema].[dbo].[Hotel] as h inner join [sistema].[dbo].[Ciudad] as c on h.ubicacion = c.idCiudad";
            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Hotel aux;
                    while (reader.Read())
                    {
                        Ciudad auxCiudad = new Ciudad(reader.GetInt32(5), reader.GetString(6));
                        aux = new Hotel(reader.GetInt32(0), auxCiudad, reader.GetInt32(2), reader.GetDouble(3), reader.GetString(4));
                        ReservaHotel? reserva = null;
                        foreach (var item in traerReservasPorHotel(aux))
                        {
                            reserva = new ReservaHotel(item.miHotel, item.miUsuario, item.fechaDesde, item.fechaHasta, item.pagado);
                            aux.listMisReservas.Add(reserva);
                        }
                        aux.listHuespedes = traerMisHuespedesPorHotel(aux);
                        Hoteles.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Hoteles;
        }


        public int agregarReserva(Int32 idUsuario, DateTime fechaDesde, DateTime fechaHasta, double pagado, Int32 idHotel)
        {
            int resultadoQuery;
            int idNuevaReservaHotel = -1;
            string queryString = "INSERT INTO [dbo].[ReservaHotel]([idUsuario],[fechaDesde],[fechaHasta],[pagado],[idHotel]) VALUES (@idUsuario, @fechaDesde, @fechaHasta,@pagado, @idHotel);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@fechaDesde", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@pagado", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@fechaDesde"].Value = fechaDesde;
                cmd.Parameters["@fechaHasta"].Value = fechaHasta;
                cmd.Parameters["@pagado"].Value = pagado;
                cmd.Parameters["@idHotel"].Value = idHotel;

                try
                {
                    conex.Open();
                    resultadoQuery = cmd.ExecuteNonQuery();

                    string ConsultaId = "SELECT MAX([idReservaHotel]) FROM [dbo].[ReservaHotel]";
                    cmd = new SqlCommand(ConsultaId, conex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    idNuevaReservaHotel = reader.GetInt32(0);
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaReservaHotel;
            }

        }

        public int modificarCapacidadHotel(Int32 idHotel, int capacidad)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Hotel] SET capacidad=@capacidad WHERE idHotel=@idHotel;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));

                cmd.Parameters["@idHotel"].Value = idHotel;
                cmd.Parameters["@capacidad"].Value = capacidad;

                try
                {
                    conex.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //reutilice este metodo para usuario y para vuelo
        public int modificarCreditoUsuario(Int32 idUsuario, double nuevoCredito)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuario] SET credito=@credito WHERE idUsuario=@idUsuario;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@credito", SqlDbType.Float));

                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@credito"].Value = nuevoCredito;

                try
                {
                    conex.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }




        #endregion

    }
}