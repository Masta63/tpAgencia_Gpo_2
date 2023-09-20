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
            Agencia = new Agencia();
            Agencia.setUsuario(new Usuario(1, "pepe", "popo", "29111222", "Juan@pepe.com", "1234", true));

            Login = new Login(Agencia);
            Login.MdiParent = this;
            Login.TransfEventoLogin += TransfDelegadoLogin;
            Login.Show();

        }


        private void TransfDelegadoLogin()
        {
            MessageBox.Show("Log correcto, Usuario: " + Agencia.nombreLogueado(), "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login.Close();
            MenuAgencia = new MenuAgencia(Agencia);
            MenuAgencia.MdiParent = this;
            MenuAgencia.Show();
        }

    }
} 