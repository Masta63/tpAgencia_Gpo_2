using Microsoft.SqlServer.Server;
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
    public partial class FormReporteCiudad : Form
    {
        public Agencia oAgencia { get; set; }
        public TransfDelegadoFormReporteCiudades TransfEventoFormReporteCiudad;
        private Form1 Form1;
        public FormReporteCiudad(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.oAgencia = agencia;
            this.Form1 = form1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public delegate void TransfDelegadoFormReporteCiudades();
        private void Reporte_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            //Traemos los datos de la lista de ciudades del objeto agencia
            dataGridView1.DataSource = oAgencia.GetCiudades();
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (oAgencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(oAgencia, Form1);
                menuAgenciaAdm.MdiParent = Form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(oAgencia, Form1);
                MenuAgencia.MdiParent = Form1;
                MenuAgencia.Show();
            }
        }
    }
}
