using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tpAgencia_Gpo_2.BuscadorVuelos;

namespace tpAgencia_Gpo_2
{
    public partial class FormMisVuelos : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        public TransfDelegadoMisVuelos TransfEventoMisVuelos;
        public FormMisVuelos(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            this.form1 = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.Load += FormMisVuelos_Load;
        }

        public delegate void TransfDelegadoMisVuelos();

        private void FormMisVuelos_Load(object sender, EventArgs e)
        {
            MostrarVuelos();
           

        }
      

        private void MostrarVuelos()
        {
            dataGridView1.Rows.Clear();

            if (usuarioActual != null)
            {
                List<ReservaVuelo> misReservasVuelo = agencia.getUsuarioActual().listMisReservasVuelo;

                foreach (var vuelos in misReservasVuelo)
                {

                    dataGridView1.Rows.Add(

                        vuelos.miVuelo.origen.nombre,
                        vuelos.miVuelo.destino.nombre,
                        vuelos.pagado,
                        vuelos.miVuelo.fecha.ToString("dd/MM/yyyy"),
                        vuelos.miVuelo.aerolinea,
                        vuelos.miVuelo.avion);
                 }

            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Modificar/Cancelar"].Index)
            {
                
            }
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(agencia, form1);
                menuAgenciaAdm.MdiParent = form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(agencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }
    }
}
