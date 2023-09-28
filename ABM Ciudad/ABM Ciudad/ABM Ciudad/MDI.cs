using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABM_Ciudad
{
    public partial class MDI : Form
    {
        //Instancio un objeto de tipo agencia
        public Agencia oAgencia = new Agencia();
        public MDI()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void agenciaFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte agencia = new Reporte();
            agencia.MdiParent = this;
            //Le digo que el bjeto que tiene como propiedad en el otro form, le envio el mio, y cuando guarde en el mio y vuelva al original
            //Quedan los datos guardados en el padre, entonces cuando le pase los datos a los hijos, queda para todos
            agencia.oAgencia = this.oAgencia;
            agencia.Show();
        }

        private void ciudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMCiudad aBMCiudad = new ABMCiudad();
            aBMCiudad.MdiParent = this;
            aBMCiudad.oAgencia = this.oAgencia;
            aBMCiudad.Show();
        }

        private void agenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
