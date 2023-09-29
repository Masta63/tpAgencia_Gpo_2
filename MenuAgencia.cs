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
        private BuscadorVuelos buscadorVuelos;
        private FormUsuarioSimple usuarioSimple;
        private FormMisVuelos misVuelos;
        private FormMisHoteles misHoteles;
        private FormReporteHoteles FormReporteHoteles;
        private FormReservaHotel FormReservaHotel;

        public MenuAgencia(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Agencia = agencia;
            this.Form1 = form1;


            validacionPermisos();


            FormUsuario = new FormUsuario(Agencia, form1);
            FormUsuario.MdiParent = form1;
            FormUsuario.TransfEventoFormUsuario += TransfDelegadoFormUsuario;

            FormVuelo = new FormVuelo(agencia, form1);
            FormVuelo.MdiParent = form1;
            FormVuelo.TransfEventoFormVuelo += TransfDelegadoFormVuelo;

            formCiudad = new FormCiudad(agencia, form1);
            formCiudad.MdiParent = form1;
            formCiudad.TransfEventoFormCiudad += TransfDelegadoFormCiudad;

            buscadorVuelos = new BuscadorVuelos(agencia, form1);
            buscadorVuelos.MdiParent = form1;
            buscadorVuelos.TransfEventoBuscadorVuelos += TransfDelegadoBuscadorVuelos;


            usuarioSimple = new FormUsuarioSimple(agencia, form1);
            usuarioSimple.MdiParent = form1;
            usuarioSimple.TransfEventoFormUsuarioSimple += TransfDelegadoFormUsuarioSimple;

            misVuelos = new FormMisVuelos(agencia, form1);
            misVuelos.MdiParent = form1;
            misVuelos.TransfEventoMisVuelos += TransfDelegadoMisVuelos;

            misHoteles = new FormMisHoteles(agencia, form1);
            misHoteles.MdiParent = form1;
            misHoteles.TransfEventoMisHoteles += TransfDelegadoMisHoteles;


            FormReporteHoteles = new FormReporteHoteles(agencia, form1);
            FormReporteHoteles.MdiParent = form1;
            FormReporteHoteles.TransfEventoFormCiudad += TransfDelegadoReporteHoteles;

            FormReservaHotel = new FormReservaHotel(agencia, form1, null, string.Empty);
            FormReporteHoteles.MdiParent = form1;
            FormReservaHotel.transfDelegadoFormAltaReserva += TransfDelegadoAltaReservaHotel;

        }

        private void validacionPermisos()
        {
            Usuario? ua = Agencia.getUsuarioActual();
            if (ua != null && !ua.esAdmin)
            {
                aBMToolStripMenuItem.Enabled = false;
            }
        }


        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoBuscadorVuelos();
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

        private void TransfDelegadoBuscadorVuelos()
        {
            this.MdiParent = Form1;
            this.Close();
            buscadorVuelos = new BuscadorVuelos(Agencia, Form1);
            buscadorVuelos.Show();
        }


        private void TransfDelegadoFormUsuarioSimple()
        {
            this.MdiParent = Form1;
            this.Close();
            usuarioSimple = new FormUsuarioSimple(Agencia, Form1);
            usuarioSimple.Show();

        }

        private void TransfDelegadoMisVuelos()
        {
            this.MdiParent = Form1;
            this.Close();
            misVuelos = new FormMisVuelos(Agencia, Form1);
            misVuelos.Show();
        }

        private void TransfDelegadoMisHoteles()
        {
            this.MdiParent = Form1;
            this.Close();
            misHoteles = new FormMisHoteles(Agencia, Form1);
            misHoteles.Show();
        }

        private void TransfDelegadoReporteHoteles()
        {
            this.MdiParent = Form1;
            this.Close();
            FormReporteHoteles = new FormReporteHoteles(Agencia, Form1);
            FormReporteHoteles.Show();
        }

        private void TransfDelegadoAltaReservaHotel()
        {
            this.MdiParent = Form1;
            this.Close();
            FormReservaHotel = new FormReservaHotel(Agencia, Form1, null, string.Empty);
            FormReservaHotel.Show();
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


        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoFormUsuarioSimple();
        }
        private void misvuelosencualviajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoMisVuelos();
        }

        private void hotelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoReporteHoteles();

        }

        private void reservarHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoAltaReservaHotel();
        }

        private void misHotelesquevisiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoMisHoteles();
        }
    }
}
