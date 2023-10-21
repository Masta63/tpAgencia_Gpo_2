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

        #endregion

    }
}