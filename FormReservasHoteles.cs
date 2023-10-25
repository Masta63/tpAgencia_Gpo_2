using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tpAgencia_Gpo_2.FormReservaHotel;

namespace tpAgencia_Gpo_2
{
    public partial class FormReservasHoteles : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        public TransfDelegadoReservasHoteles TransfEventoReservasHoteles;
        public FormReservasHoteles(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            this.form1 = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.Load += FormReservasHoteles_Load;
        }

        public delegate void TransfDelegadoReservasHoteles();

        private void FormReservasHoteles_Load(object sender, EventArgs e)
        {
            MostrarHoteles();
        }

        private void refrescar()
        {
            dataGridView1.Rows.Clear();

            if (usuarioActual != null)
            {
                foreach (var reservas in agencia.getUsuarioActual().listMisReservasHoteles)
                {
                    TimeSpan ts = reservas.fechaHasta.Date.Subtract(reservas.fechaDesde.Date);
                    double costo = ((ts.Days + 1) * reservas.miHotel.costo);

                    dataGridView1.Rows.Add(
                        reservas.idReservaHotel,
                        reservas.miHotel.ubicacion.nombre,
                        costo,
                       reservas.miHotel.nombre, reservas.miHotel.capacidad, reservas.fechaDesde, reservas.fechaHasta);
                }
            }
        }

        private void MostrarHoteles()
        {
            refrescar();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string? id = dataGridView1[0, e.RowIndex]?.Value?.ToString().Trim();
                string? ubicacion = dataGridView1[1, e.RowIndex]?.Value?.ToString().Trim();
                string? costo = dataGridView1[2, e.RowIndex]?.Value?.ToString().Trim();
                string? nombre = dataGridView1[3, e.RowIndex]?.Value?.ToString().Trim();
                string? capacidad = dataGridView1[4, e.RowIndex]?.Value?.ToString().Trim();
                string? fechaDesde = dataGridView1[5, e.RowIndex]?.Value?.ToString().Trim();
                string? fechaHasta = dataGridView1[6, e.RowIndex]?.Value?.ToString().Trim();


                textBox_id.Text = id;
                textUbicacion.Text = ubicacion;
                textCosto.Text = costo;
                textBoxName.Text = nombre;
                textBoxCapacidad.Text = capacidad;
                dateTimePickerFechaDesde.Value = Convert.ToDateTime(fechaDesde);
                dateTimePickerFechaHasta.Value = Convert.ToDateTime(fechaHasta);
                button1.Enabled = true;

                //(usuarioSeleccionado = int.Parse(id);
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agencia.eliminarRerservaHotel(Convert.ToInt32(textBox_id.Text));
            refrescar();
            textBox_id.Text = "";
            textUbicacion.Text = "";
            textCosto.Text = "";
            textBoxName.Text = "";
            textBoxCapacidad.Text = "";
            dateTimePickerFechaDesde.Value = Convert.ToDateTime(DateTime.Now);
            dateTimePickerFechaHasta.Value = Convert.ToDateTime(DateTime.Now);
            button1.Enabled = false;
        }
    }
}
