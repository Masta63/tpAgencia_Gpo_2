using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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

        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();


            string queryString = "SELECT * from Usuario";



            using (SqlConnection conex = new SqlConnection(connectionStr))
            {

                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {

                    conex.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;

                    while (reader.Read())
                    {
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

        #region AbmHoteles


        public int agregarHotel(int idHotel, Ciudad ubicacion, int capacidad, float costo, string nombre, int idMisReservas)
        {
            int resultadoQuery;
            int idNuevoHotel = -1;
            string queryString = "INSERT INTO [dbo].[Hotel]([idHotel], [ubicacion], [capacidad], [costo], [nombre], [idMisReservas]) VALUES (@idHotel, @ubicacion, @capacidad ,@costo, @nombre, @idMisReservas);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@idMisReservas", SqlDbType.Int));
                cmd.Parameters["@idHotel"].Value = idHotel;
                cmd.Parameters["@ubicacion"].Value = ubicacion;
                cmd.Parameters["@capacidad"].Value = capacidad;
                cmd.Parameters["@costo"].Value = costo;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@idMisReservas"].Value = idMisReservas;


                try
                {
                    conex.Open();
                    resultadoQuery = cmd.ExecuteNonQuery();

                    string ConsultaId = "SELECT MAX([idHotel]) FROM [dbo].[Hotel]";
                    cmd = new SqlCommand(ConsultaId, conex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                   idNuevoHotel = reader.GetInt32(0);
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoHotel;
            }


        }

        public int eliminarHotel(int id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Hotel] WHERE idHotel=@id";
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


        public int modificarHotel(int idHotel, Ciudad ubicacion, int capacidad, float costo, string nombre, int idMisReservas)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Hotel] SET idHotel=@idHotel, ubicacion = @ubicacion, capacidad=@capacidad, costo=@costo, nombre=@nombre, idMisReservas=@idMisReservas WHERE idHotel=@id;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@idMisReservas", SqlDbType.Int));
                cmd.Parameters["@idHotel"].Value = idHotel;
                cmd.Parameters["@ubicacion"].Value = ubicacion;
                cmd.Parameters["@capacidad"].Value = capacidad;
                cmd.Parameters["@costo"].Value = costo;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@idMisReservas"].Value = idMisReservas;
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