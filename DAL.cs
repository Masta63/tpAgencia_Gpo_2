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
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetBoolean(7),reader.GetDouble(8),reader.GetBoolean(9));
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
        public int agregarUsuario(string Dni, string Nombre, string Apellido, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string queryString = "INSERT INTO [dbo].[Usuarios] ([DNI],[Nombre],[apellido],[Mail],[Password],[EsADM],[Bloqueado]) VALUES (@dni,@nombre,@mail,@password,@esadm,@bloqueado);";
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
                command.Parameters["@dni"].Value = Dni;//estos valores hace referencia a los parametros que definimos arriba 
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadm"].Value = EsADM;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    //no abrimos un datareader, con este metodo capturamos la cantidad de filas afectadas
                    //si creamos un datareader esta mal xk no necesita ser leida una tabla
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuarios]";// con esta consulta capturamos el ultimo agregado, no es lo optimo sino que tenga un where para filtrar por dni
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

        // -- FIN METODOS DE USUARIO


        //public List<Vuelo> inicializarVuelos()
        //{
        //    List<Vuelo> misUsuarios = new List<Vuelo>();


        //    string queryString = "SELECT * from Vuelo";



        //    using (SqlConnection conex = new SqlConnection(connectionStr))
        //    {

        //        SqlCommand command = new SqlCommand(queryString, conex);
        //        try
        //        {

        //            conex.Open();


        //            SqlDataReader reader = command.ExecuteReader();
        //            Vuelo aux;

        //            while (reader.Read())
        //            {
        //                aux = new Vuelo(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetDateTime(5), reader.GetString(6), reader.GetString(7));
        //                misUsuarios.Add(aux);

        //            }
        //            reader.Close();

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return misUsuarios;

        //}





    }
}