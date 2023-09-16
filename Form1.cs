namespace tpAgencia_Gpo_2
{
    public partial class Form1 : Form
    {
        private Agencia agencia;
        private FormVuelo hijoVuelo;
        public Form1()
        {
            InitializeComponent();
            agencia = new Agencia();


            hijoVuelo = new FormVuelo(agencia);
            hijoVuelo.MdiParent = this;
            //hijoVuelo.TransfEvento += TransfDelegado;
            hijoVuelo.Show();
        }

        private void TransfDelegado()
        {

        }
    }
}