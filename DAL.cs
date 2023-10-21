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