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