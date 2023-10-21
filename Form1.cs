namespace tpAgencia_Gpo_2
{
    public partial class Form1 : Form
    {



        private Agencia Agencia;
        private Login Login;
        private MenuAgencia MenuAgencia;
        private MenuAgenciaAdm MenuAgenciaAdm;
        private FormUsuarioSimple usuarioSimple;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Agencia = new Agencia();
         
            //cargaCiudades();


            Login = new Login(Agencia);
            Login.MdiParent = this;
            Login.TransfEventoLogin += TransfDelegadoLogin;
            Login.Show();



            //Vuelos hardcodeados

            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Bariloche"), Agencia.obtenerNombreCiudad("Mendoza"), 20, 50000, new DateTime(2023, 10, 30), "AA", "Airbus");
            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Mendoza"), Agencia.obtenerNombreCiudad("Buenos Aires"), 50, 100000, new DateTime(2023, 10, 20), "AA", "Airbus320");
            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Bariloche"), Agencia.obtenerNombreCiudad("Buenos Aires"), 2, 200000, new DateTime(2023, 10, 10), "JetSmart", "Airbus300");
            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Buenos Aires"), Agencia.obtenerNombreCiudad("Mendoza"), 2, 200000, new DateTime(2023, 09, 10), "JetSmart", "Airbus300");

            //cargaDeHotelesConReservaYusuarios();
        }





        private void cargaCiudades()
        {
            Agencia.setCiudad(new Ciudad(1, "Bariloche"));
            Agencia.setCiudad(new Ciudad(2, "buenos aires"));
            Agencia.setCiudad(new Ciudad(3, "san juan"));
            Agencia.setCiudad(new Ciudad(4, "calamuchita"));
        }

        private void cargaDeHotelesConReservaYusuarios()
        {

            Ciudad? ciudadParaHotelBariloche = Agencia.GetCiudades().ToList().Where(x => x.id == 1).FirstOrDefault();
            Ciudad? ciudadParaHotel2 = Agencia.GetCiudades().ToList().Where(x => x.id == 2).FirstOrDefault();
            Ciudad? ciudadParaHotel3 = Agencia.GetCiudades().ToList().Where(x => x.id == 3).FirstOrDefault();

            List<Usuario> ListHuespedesFaena = new List<Usuario>();
            Usuario usuarioFaena = Agencia.getUsuarios().ToList().Where(x => x.id == 1).FirstOrDefault();
            ListHuespedesFaena.Add(usuarioFaena);
            Usuario usuarioFaena2 = Agencia.getUsuarios().ToList().Where(x => x.id == 2).FirstOrDefault();
            ListHuespedesFaena.Add(usuarioFaena2);


            Hotel hotelFaena = new Hotel(1, ciudadParaHotelBariloche, 2, 1000, "Faena", ListHuespedesFaena, Agencia.getReservasHotel());
            Hotel hotelHilton = new Hotel(2, ciudadParaHotelBariloche, 2, 1000, "Hilton", ListHuespedesFaena, Agencia.getReservasHotel());
            ReservaHotel reservaHotel = new ReservaHotel(hotelFaena, usuarioFaena2, new DateTime(2023, 03, 01), new DateTime(2023, 03, 14), 1000);
            ReservaHotel reservaHotel2 = new ReservaHotel(hotelFaena, usuarioFaena2, new DateTime(2023, 03, 15), new DateTime(2023, 03, 20), 1000);
            Agencia.setReservasHotel(reservaHotel);
            Agencia.setReservasHotel(reservaHotel2);


            List<Usuario> ListHuespedesHilton = new List<Usuario>();
            Usuario usuarioHilton = Agencia.getUsuarios().ToList().Where(x => x.id == 1).FirstOrDefault();
            ListHuespedesHilton.Add(usuarioHilton);

            Agencia.setHotel(hotelFaena);
            Agencia.setHotel(hotelHilton);
        }

        private void TransfDelegadoLogin()
        {
            MessageBox.Show("Log correcto, Usuario: " + Agencia.nombreLogueado(), "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login.Close();

            if (Agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm = new MenuAgenciaAdm(Agencia, this);
                MenuAgenciaAdm.MdiParent = this;
                MenuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia = new MenuAgencia(Agencia, this);
                MenuAgencia.MdiParent = this;
                MenuAgencia.Show();
            }
        }


    }
}