namespace ABMCiudadV2
{
	public partial class Mdi : Form
	{
		//Instancio un objeto de tipo agencia
		public Agencia oAgencia = new Agencia();
		public Mdi()
		{
			InitializeComponent();
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void abmCiudadToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void Mdi_Load(object sender, EventArgs e)
		{

		}

		private void ciudadABMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ABMCIUDAD aBMCiudad = new ABMCIUDAD();
			aBMCiudad.MdiParent = this;
			aBMCiudad.oAgencia = this.oAgencia;
			aBMCiudad.Show();
		}

		private void reportesABMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Reporte agencia = new Reporte();
			agencia.MdiParent = this;
			//Le digo que el bjeto que tiene como propiedad en el otro form, le envio el mio, y cuando guarde en el mio y vuelva al original
			//Quedan los datos guardados en el padre, entonces cuando le pase los datos a los hijos, queda para todos
			agencia.oAgencia = this.oAgencia;
			agencia.Show();
		}
	}
}