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
         
            Login = new Login(Agencia, this);
            Login.MdiParent = this;
            Login.TransfEventoLogin += TransfDelegadoLogin;
            Login.Show();



            //Vuelos hardcodeados

            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Bariloche"), Agencia.obtenerNombreCiudad("Mendoza"), 20, 50000, new DateTime(2023, 10, 30), "AA", "Airbus");
            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Mendoza"), Agencia.obtenerNombreCiudad("Buenos Aires"), 50, 100000, new DateTime(2023, 10, 20), "AA", "Airbus320");
            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Bariloche"), Agencia.obtenerNombreCiudad("Buenos Aires"), 2, 200000, new DateTime(2023, 10, 10), "JetSmart", "Airbus300");
            //Agencia.agregarVuelo(Agencia.obtenerNombreCiudad("Buenos Aires"), Agencia.obtenerNombreCiudad("Mendoza"), 2, 200000, new DateTime(2023, 09, 10), "JetSmart", "Airbus300");

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