namespace tpAgencia_Gpo_2
{
    public partial class Form1 : Form
    {
        private Agencia agencia;
        private FormVuelo hijoVuelo;
        private FormUsuario hijoUsuario;
        public Form1()
        {
            InitializeComponent();
            agencia = new Agencia();//unica instancia de agencia que se debe usar en todos los form

            hijoUsuario = new FormUsuario(agencia);
            hijoUsuario.MdiParent = this;
            //metodo delegado aca asigno a la variable el metodo
            hijoUsuario.Show();

            //hijoVuelo = new FormVuelo(agencia);
            //hijoVuelo.MdiParent = this;
            ////hijoVuelo.TransfEvento += TransfDelegado;
            //hijoVuelo.Show();
        }

        private void TransfDelegado()
        {

        }
    }
}