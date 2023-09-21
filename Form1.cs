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
            Agencia.setUsuario(new Usuario(2, "juana", "lola", "33333333", "Juana@lola.com", "1234", true));
            Agencia.setUsuario(new Usuario(3, "pablo", "lopez", "22222222", "Pablo@lopez.com", "1234", true));

            Login = new Login(Agencia);
            Login.MdiParent = this;
            Login.TransfEventoLogin += TransfDelegadoLogin;
            Login.Show();

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