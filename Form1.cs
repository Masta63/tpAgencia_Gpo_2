namespace tpAgencia_Gpo_2
{
    public partial class Form1 : Form
    {



        private Agencia Agencia;
        private Login Login;
        private MenuAgencia MenuAgencia;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Agencia = new Agencia();
            Agencia.setUsuario(new Usuario(1, "pepe", "popo", "29111222", "Juan@pepe.com", "1234", true));
            Agencia.setUsuario(new Usuario(2, "juana", "lola", "33333333", "Juana@lola.com", "1234", true));
            Agencia.setUsuario(new Usuario(3, "pablo", "lopez", "22222222", "Pablo@lopez.com", "1234", true));

            Agencia.setCiudad(new Ciudad(1, "Bariloche"));
            Agencia.setCiudad(new Ciudad(2, "Mendoza"));
            Agencia.setCiudad(new Ciudad(3, "Buenos Aires"));

            Login = new Login(Agencia);
            Login.MdiParent = this;
            Login.TransfEventoLogin += TransfDelegadoLogin;
            Login.Show();

            //Vuelos hardcodeados

            Agencia.agregarVuelo(Agencia.GetCiudades()[0], Agencia.GetCiudades()[1], 20, 50000, new DateTime(2023, 10, 30), "AA", "Airbus");
            Agencia.agregarVuelo(Agencia.GetCiudades()[1], Agencia.GetCiudades()[2], 50, 100000, new DateTime(2023, 10, 20), "AA", "Airbus320");
            Agencia.agregarVuelo(Agencia.GetCiudades()[2], Agencia.GetCiudades()[0], 2, 200000, new DateTime(2023, 10, 10), "JetSmart", "Airbus300");
            Agencia.agregarVuelo(Agencia.GetCiudades()[0], Agencia.GetCiudades()[1], 2, 200000, new DateTime(2023, 09, 10), "JetSmart", "Airbus300");



        }



        private void TransfDelegadoLogin()
        {
            MessageBox.Show("Log correcto, Usuario: " + Agencia.nombreLogueado(), "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login.Close();
            MenuAgencia = new MenuAgencia(Agencia, this);
            MenuAgencia.MdiParent = this;
            MenuAgencia.Show();
        }


    }
}