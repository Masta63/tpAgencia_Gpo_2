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
        private String connectionStr;

        public DAL()
        {
            //Cargo cadena de conexion
            connectionStr = Properties.Resources.ConnectionStr;
        }

        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Definimos el string con la consulta a realizar
            string queryString = "SELECT * from Usuarios";

            //Creamos conexion SQL con using, cuando finaliza, la conexion se cierra

            using(SqlConnection con = new SqlConnection(connectionStr))
            {
                //Defino el comando a enviar al motor SQL con la consulta
                SqlCommand command= new SqlCommand(queryString, con);
                try
                {
                    //Abro conexion
                    con.Open();

                    //Datareader para obtener resultados
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;

                    while(reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6));
                        misUsuarios.Add(aux);

                    }
                    reader.Close();

                } catch(Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }
            }
            return misUsuarios;

        }
      
        
        


    }
}
