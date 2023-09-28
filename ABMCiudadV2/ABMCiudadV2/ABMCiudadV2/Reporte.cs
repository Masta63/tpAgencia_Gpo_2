using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABMCiudadV2
{
	public partial class Reporte : Form
	{
		public Agencia oAgencia { get; set; }
		public Reporte()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Reporte_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = null;
			//Traemos los datos de la lista de ciudades del objeto agencia
			dataGridView1.DataSource = oAgencia.listaCiudades;
		}
	}
}
