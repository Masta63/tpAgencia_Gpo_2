using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace tpAgencia_Gpo_2
{
    public partial class MenuAgencia : Form
    {
        private Agencia Agencia;
        private FormUsuario FormUsuario;
        private FormVuelo FormVuelo;
        private Form1 Form1;
        private FormCiudad formCiudad;
        public MenuAgencia(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.Agencia = agencia;
            this.Form1 = form1;
            FormUsuario = new FormUsuario(Agencia, form1);
            FormUsuario.MdiParent = form1;
            FormUsuario.TransfEventoFormUsuario += TransfDelegadoFormUsuario;

            FormVuelo = new FormVuelo(agencia, form1);
            FormVuelo.MdiParent = form1;
            FormVuelo.TransfEventoFormVuelo += TransfDelegadoFormVuelo;

            formCiudad = new FormCiudad(agencia, form1);
            formCiudad.MdiParent = form1;
            formCiudad.TransfEventoFormCiudad += TransfDelegadoFormCiudad;
        }

        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void opcionesUsuarioComunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuAgencia_Load(object sender, EventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agencia.cerrarSesion();
            this.Close();
            Form1.Close();
        }
        private void TransfDelegadoFormUsuario()
        {
            this.MdiParent = Form1;
            this.Close();
            FormUsuario = new FormUsuario(Agencia, Form1);
            FormUsuario.Show();
        }

        private void TransfDelegadoFormVuelo()
        {
            this.MdiParent = Form1;
            this.Close();
            FormVuelo = new FormVuelo(Agencia, Form1);
            FormVuelo.Show();
        }

        private void TransfDelegadoFormCiudad()
        {
            this.MdiParent = Form1;
            this.Close();
            formCiudad = new FormCiudad(Agencia, Form1);
            formCiudad.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoFormUsuario();
        }

        private void vuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoFormVuelo();
        }

        private void ciudadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoFormCiudad();
        }
    }
}
