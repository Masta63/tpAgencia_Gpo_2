using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;//debemos agregar para poder usar los metodos de conexion dy reader
using System.Transactions;
using System.Data.Common;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

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

        public int modificarUsuarioConContraseña(int Id, string Nombre, string Apellido, int Dni, string Mail, string nuevaContraseña)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
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

                if (!string.IsNullOrEmpty(nuevaContraseña))
                {
                    // Si se proporciona una nueva contraseña, se incluye en la actualización
                    queryString = "UPDATE [dbo].[Usuario] SET nombre = @nombre, apellido = @apellido, dni = @dni, mail = @mail, password = @nuevaContraseña WHERE [idUsuario] = @id;";
                    command.Parameters.Add(new SqlParameter("@nuevaContraseña", SqlDbType.NVarChar));
                    command.Parameters["@nuevaContraseña"].Value = nuevaContraseña;
                }
                else
                {
                    // Si no se proporciona una nueva contraseña, se excluye de la actualización
                    queryString = "UPDATE [dbo].[Usuario] SET nombre = @nombre, apellido = @apellido, dni = @dni, mail = @mail WHERE [idUsuario] = @id;";
                }

                command.CommandText = queryString;
                command.Connection = connection;

                try
                {
                    connection.Open();
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

        //CONTROLAR LA CONEXIÓN CON LA BASE CUANDO FUNCIONE AGREGAR USUARIO
        public int modificarReservaVuelo(int idVuelo, int idReserva, int cantidad, double costo)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[ReservaVuelo] SET pagado=@costo  WHERE idReservaVuelo=@idReserva;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));

                cmd.Parameters["@id"].Value = idVuelo;
                cmd.Parameters["@costo"].Value = costo;

                string getVueloIdQuery = "SELECT idVuelo FROM [dbo].[ReservaVuelo] WHERE idReservaVuelo = @id;";
                int vueloId = -1;
                try
                {
                    conex.Open();

                    using (SqlCommand getVueloIdCmd = new SqlCommand(getVueloIdQuery, conex))
                    {
                        getVueloIdCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        getVueloIdCmd.Parameters["@id"].Value = idVuelo;

                        using (SqlDataReader reader = getVueloIdCmd.ExecuteReader())
                        {
                            reader.Read();

                            vueloId = reader.GetInt32(0);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                string updateCapacidadQuery = "UPDATE [dbo].[Vuelo] SET capacidad = capacidad + @cantidad WHERE idVuelo = @idVuelo;";
                try
                {
                    using (SqlCommand updateCapacidadCmd = new SqlCommand(updateCapacidadQuery, conex))
                    {
                        updateCapacidadCmd.Parameters.Add(new SqlParameter("@idVuelo", SqlDbType.Int));
                        updateCapacidadCmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                        updateCapacidadCmd.Parameters["@idVuelo"].Value = vueloId;
                        updateCapacidadCmd.Parameters["@cantidad"].Value = cantidad;

                        updateCapacidadCmd.ExecuteNonQuery();
                    }
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }



                //    try
                //    {
                //        conex.Open();
                //        return cmd.ExecuteNonQuery();
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //        return 0;
                //    }
            }
        }

        public int eliminarMiReservaVuelo(int Id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[ReservaVuelo] WHERE [idReservaVuelo]=@idReservaVuelo";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idReservaVuelo", SqlDbType.Int));
                command.Parameters["@idReservaVuelo"].Value = Id;
                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int agregarReservaVuelo(int idVuelo, double costo, int idUsuario)
        {
            int resultadoQuery;
            int idNuevaReservaVuelo = -1;
            string queryString = "INSERT INTO [dbo].[ReservaVuelo]([idVuelo], [idUsuario], [pagado]) VALUES (@idVuelo, @idUsuario, @costo);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idVuelo", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));

                cmd.Parameters["@idVuelo"].Value = idVuelo;
                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@costo"].Value = costo;


                try
                {
                    conex.Open();
                    resultadoQuery = cmd.ExecuteNonQuery();

                    string ConsultaId = "SELECT MAX([idReservaVuelo]) FROM [dbo].[ReservaVuelo]";
                    cmd = new SqlCommand(ConsultaId, conex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    idNuevaReservaVuelo = reader.GetInt32(0);
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaReservaVuelo;
            }


        }
        public bool usuarioHaCompradoVuelo(int idUsuario, int idVuelo)
        {
            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                string queryString = "SELECT COUNT(*) FROM [dbo].[Vuelo_Usuario] WHERE [idUsuario] = @idUsuario AND [idVuelo] = @idVuelo;";
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int)).Value = idUsuario;
                cmd.Parameters.Add(new SqlParameter("@idVuelo", SqlDbType.Int)).Value = idVuelo;

                conex.Open();
                int count = (int)cmd.ExecuteScalar();

                // Si count es mayor que 0, significa que el usuario ya compró el vuelo
                return count > 0;
            }
        }
        public int agregarVueloAUsuario(int idVuelo, int idUsuario, int cantidad)
        {
            int resultadoQuery;
            int idNuevaReservaVuelo = -1;
            string queryString = "INSERT INTO [dbo].[Vuelo_Usuario]([idVuelo],[idUsuario],[cantidad]) VALUES (@idVuelo, @idUsuario, @cantidad);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idVuelo", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                cmd.Parameters["@idVuelo"].Value = idVuelo;
                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@cantidad"].Value = cantidad;

                try
                {
                    conex.Open();
                    resultadoQuery = cmd.ExecuteNonQuery();

                    string ConsultaId = "SELECT MAX([idUsuario]), MAX([idVuelo]) FROM [dbo].[Vuelo_Usuario]";
                    cmd = new SqlCommand(ConsultaId, conex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    idNuevaReservaVuelo = reader.GetInt32(0);
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaReservaVuelo;
            }

        }

        public int modificarCapacidadVuelo(int idVuelo, int capacidad)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Vuelo] SET capacidad=@capacidad WHERE idVuelo=@idVuelo;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idVuelo", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));

                cmd.Parameters["@idVuelo"].Value = idVuelo;
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
        public Vuelo ObtenerVueloPorID(int vueloID)
        {
            Vuelo vuelo = null;
            string queryString = "SELECT * FROM [sistema].[dbo].[Vuelo] WHERE id = " + vueloID;

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Ciudad origen = new Ciudad(reader.GetInt32(1), reader.GetString(9));
                        Ciudad destino = new Ciudad(reader.GetInt32(2), reader.GetString(10));
                        vuelo = new Vuelo(
                            reader.GetInt32(0), origen, destino, reader.GetInt32(3), reader.GetDouble(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8));

                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return vuelo;
        }

        public List<ReservaVuelo> traerReservasVuelo(int idUsuario)
        {
            List<ReservaVuelo> reservasVuelos = new List<ReservaVuelo>();
            string queryString = "SELECT * FROM [dbo].[ReservaVuelo] as re inner join [dbo].[Usuario] as s on re.idUsuario = s.idUsuario inner join [dbo].[Vuelo] as h on re.idVuelo = h.idVuelo  where s.idUsuario = " + idUsuario;
            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ReservaVuelo aux;

                    while (reader.Read())
                    {
                        Ciudad ciudadOrigen = traerCiudadPorId(reader.GetInt32(15));
                        Ciudad ciudadDestino = traerCiudadPorId(reader.GetInt32(16));
                        Usuario usuario = this.traerUsuarioPorId(reader.GetInt32(4));
                        Vuelo vuelo = new Vuelo(reader.GetInt32(1), ciudadOrigen, ciudadDestino, reader.GetInt32(17), reader.GetDouble(19), reader.GetDateTime(20), reader.GetString(21), reader.GetString(22));
                        aux = new ReservaVuelo(vuelo, usuario, reader.GetDouble(3));
                        aux.idReservaVuelo = reader.GetInt32(0);
                        reservasVuelos.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return reservasVuelos;

        }
        public int ObtenerCantidadComprada(int idVuelo, int idUsuario)
        {
            int cantidadComprada = 0;

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                string queryString = "SELECT [cantidad] FROM [dbo].[Vuelo_Usuario] WHERE [idvuelo] = @idVuelo AND [idusuario] = @idUsuario";
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idReserva", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters["@idReserva"].Value = idVuelo;
                cmd.Parameters["@idUsuario"].Value = idUsuario;

                try
                {
                    conex.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        cantidadComprada = reader.GetInt32(reader.GetOrdinal("cantidad"));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return cantidadComprada;
        }
        #region reservaHotel

        public int modificarReservaHotel(DateTime fechaDesde, DateTime fechaHasta, double pagado, Int32 idReservaHotel)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE[dbo].[ReservaHotel] SET [fechaDesde] =@fechaDesde ,[fechaHasta] =@fechaHasta ,[pagado] =@pagado  WHERE idReservaHotel = @idReservaHotel;";

            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@fechaDesde", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@pagado", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@idReservaHotel", SqlDbType.Int));

                cmd.Parameters["@fechaDesde"].Value = fechaDesde;
                cmd.Parameters["@fechaHasta"].Value = fechaHasta;
                cmd.Parameters["@pagado"].Value = pagado;
                cmd.Parameters["@idReservaHotel"].Value = idReservaHotel;

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

        public int eliminarMiReserva(int Id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[ReservaHotel] WHERE [idReservaHotel]=@idReservaHotel";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idReservaHotel", SqlDbType.Int));
                command.Parameters["@idReservaHotel"].Value = Id;
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



        public Usuario? traerUsuarioPorId(Int32 idUsuario)
        {
            Usuario? aux = null;
            //string con la consulta que quiero realizar
            string queryString = "SELECT * from Usuario where idUsuario =" + idUsuario;
            //creo conexion con la base de datos el using al finalizar el metodo utiliza el dispose y cierra la conexion para ahorrar recursos
            using (SqlConnection conex = new SqlConnection(connectionStr))//OBJETO<--1
            {
                SqlCommand command = new SqlCommand(queryString, conex);//OBJETO<--2
                try
                {

                    conex.Open();//metodo que ejecuta la conexion con la base de datos
                    //OBJETO<--3
                    SqlDataReader reader = command.ExecuteReader();// creo el objeto para leer la base de datos y ejecutar el comando
                    while (reader.Read())//metodo devuelve true mientras siga leyendo una fila sigue el bucle
                    {
                        //leo la fila, la carga en la variable aux y la agrega a mis usuarios para trabajar en tiempo de ejecucion 
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetDouble(8), reader.GetBoolean(9));

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return aux;
        }

        public Ciudad? traerCiudadPorId(Int32 idCiudad)
        {
            Ciudad? aux = null;
            //string con la consulta que quiero realizar
            string queryString = "SELECT * FROM [dbo].[Ciudad] where idCiudad =" + idCiudad;
            //creo conexion con la base de datos el using al finalizar el metodo utiliza el dispose y cierra la conexion para ahorrar recursos
            using (SqlConnection conex = new SqlConnection(connectionStr))//OBJETO<--1
            {
                SqlCommand command = new SqlCommand(queryString, conex);//OBJETO<--2
                try
                {

                    conex.Open();//metodo que ejecuta la conexion con la base de datos
                    //OBJETO<--3
                    SqlDataReader reader = command.ExecuteReader();// creo el objeto para leer la base de datos y ejecutar el comando
                    while (reader.Read())//metodo devuelve true mientras siga leyendo una fila sigue el bucle
                    {
                        //leo la fila, la carga en la variable aux y la agrega a mis usuarios para trabajar en tiempo de ejecucion 
                        aux = new Ciudad(reader.GetInt32(0), reader.GetString(1));

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return aux;
        }

        public List<ReservaHotel> traerMisReservasHotel(Int32 idUsuario)
        {
            List<ReservaHotel> reservaHotels = new List<ReservaHotel>();

            //string con la consulta que quiero realizar
            string queryString = "SELECT *  FROM [sistema].[dbo].[ReservaHotel] as re inner join [sistema].[dbo].[Usuario]  as s on re.idUsuario = s.idUsuario inner join [sistema].[dbo].[Hotel] as h on re.idHotel = h.idHotel  where s.idUsuario =" + idUsuario;


            //creo conexion con la base de datos el using al finalizar el metodo utiliza el dispose y cierra la conexion para ahorrar recursos
            using (SqlConnection conex = new SqlConnection(connectionStr))//OBJETO<--1
            {

                SqlCommand command = new SqlCommand(queryString, conex);//OBJETO<--2
                try
                {

                    conex.Open();//metodo que ejecuta la conexion con la base de datos

                    //OBJETO<--3
                    SqlDataReader reader = command.ExecuteReader();// creo el objeto para leer la base de datos y ejecutar el comando
                    ReservaHotel aux;

                    while (reader.Read())//metodo devuelve true mientras siga leyendo una fila sigue el bucle
                    {
                        Ciudad ciudad = traerCiudadPorId(reader.GetInt32(17));
                        Hotel hotel = new Hotel(reader.GetInt32(5), ciudad, reader.GetInt32(18), reader.GetDouble(19), reader.GetString(20));
                        Usuario usuario = this.traerUsuarioPorId(reader.GetInt32(1));
                        //leo la fila, la carga en la variable aux y la agrega a mis usuarios para trabajar en tiempo de ejecucion 
                        aux = new ReservaHotel(hotel, usuario, reader.GetDateTime(2), reader.GetDateTime(3), reader.GetDouble(4));
                        aux.idReservaHotel = reader.GetInt32(0);
                        reservaHotels.Add(aux);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return reservaHotels;

        }

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
            string queryString = "SELECT *  FROM [dbo].[Hotel] as h inner join [dbo].[Ciudad] as c on h.ubicacion = c.idCiudad";
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

        public int agregarRelacionUsuarioHotel(Int32 idUsuario, Int32 idHotel)
        {
            int resultadoQuery;
            int idNuevaReservaHotel = -1;
            string queryString = "INSERT INTO [dbo].[Hotel_Usuario]([idUsuario],[idHotel],[cantidad]) VALUES (@idUsuario, @idHotel, @cantidad);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@idHotel"].Value = idHotel;
                cmd.Parameters["@cantidad"].Value = 1;

                try
                {
                    conex.Open();
                    resultadoQuery = cmd.ExecuteNonQuery();

                    string ConsultaId = "SELECT MAX([idUsuario]), MAX([idHotel]) FROM [dbo].[Hotel_Usuario]";
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

        public int traerCantidadDeUsuarioHotel(Int32 idUsuario, Int32 idHotel)
        {
            Int32 cantidad = 0;
            //string con la consulta que quiero realizar
            string queryString = "SELECT * FROM [sistema].[dbo].[Hotel_Usuario] where idHotel=" + idHotel + " and idUsuario=" + idUsuario
;
            //creo conexion con la base de datos el using al finalizar el metodo utiliza el dispose y cierra la conexion para ahorrar recursos
            using (SqlConnection conex = new SqlConnection(connectionStr))//OBJETO<--1
            {
                SqlCommand command = new SqlCommand(queryString, conex);//OBJETO<--2
                try
                {

                    conex.Open();//metodo que ejecuta la conexion con la base de datos
                    //OBJETO<--3
                    SqlDataReader reader = command.ExecuteReader();// creo el objeto para leer la base de datos y ejecutar el comando
                    while (reader.Read())//metodo devuelve true mientras siga leyendo una fila sigue el bucle
                    {
                        //leo la fila, la carga en la variable aux y la agrega a mis usuarios para trabajar en tiempo de ejecucion 
                        cantidad = reader.GetInt32(2);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return cantidad;
        }


        public int modificarCantidadDeVisitantes(Int32 idHotel, Int32 idUsuario, int cantidad)
        {
            Int32 cantidadBase = this.traerCantidadDeUsuarioHotel(idUsuario, idHotel);
            Int32 cantidadTotal = cantidadBase + cantidad;



            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Hotel_Usuario] SET cantidad=@cantidad WHERE idHotel=@idHotel and idUsuario =@idUsuario;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));

                cmd.Parameters["@idHotel"].Value = idHotel;
                cmd.Parameters["@idUsuario"].Value = idUsuario;
                cmd.Parameters["@cantidad"].Value = cantidadTotal;

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

        public bool traerHotel_Usuario(Int32 idHotel, Int32 idUsuario)
        {
            bool existe = false;
            string queryString = "SELECT * FROM [sistema].[dbo].[Hotel_Usuario]  where idHotel=" + idHotel + "and idUsuario=" + idUsuario;

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, conex);
                try
                {
                    conex.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) != null && reader.GetInt32(1) != null)
                        {
                            existe = true;
                        }
                        else
                        {
                            existe = false;
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return existe;
        }


        #endregion

        #region ABM Hotel

        public int agregarHotel(int ubicacion, int capacidad, float costo, string nombre)
        {
            int resultadoQuery;
            int idNuevoHotel = -1;
            string queryString = "INSERT INTO [dbo].[Hotel]([ubicacion], [capacidad], [costo], [nombre]) VALUES (@ubicacion, @capacidad ,@costo, @nombre);";

            using (SqlConnection conex = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                cmd.Parameters["@ubicacion"].Value = ubicacion;
                cmd.Parameters["@capacidad"].Value = capacidad;
                cmd.Parameters["@costo"].Value = costo;
                cmd.Parameters["@nombre"].Value = nombre;

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

        public int eliminarHotel(int idHotel)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Hotel] WHERE idHotel=@idHotel";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters["@idHotel"].Value = idHotel;

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


        public int modificarHotel(int idHotel, int ubicacion, int capacidad, float costo, string nombre)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Hotel] SET ubicacion = @ubicacion, capacidad=@capacidad, costo=@costo, nombre=@nombre WHERE idHotel=@idHotel;";
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conex);
                cmd.Parameters.Add(new SqlParameter("@idHotel", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@capacidad", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@costo", SqlDbType.Float));
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                cmd.Parameters["@idHotel"].Value = idHotel;
                cmd.Parameters["@ubicacion"].Value = ubicacion;
                cmd.Parameters["@capacidad"].Value = capacidad;
                cmd.Parameters["@costo"].Value = costo;
                cmd.Parameters["@nombre"].Value = nombre;
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