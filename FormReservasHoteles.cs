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
                       reservas.miHotel.nombre, reservas.miHotel.capacidad, reservas.fechaDesde, reservas.fechaHasta, reservas.miHotel.id, reservas.miHotel.costo);
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
                string? idHotel = dataGridView1[7, e.RowIndex]?.Value?.ToString().Trim();

                textBoxidHotel.Text = idHotel;
                textBox_id.Text = id;
                textCosto.Text = costo;
                dateTimePickerFechaDesde.Value = Convert.ToDateTime(fechaDesde);
                dateTimePickerFechaHasta.Value = Convert.ToDateTime(fechaHasta);
                button1.Enabled = true;
                button2.Enabled = true;
                dateTimePickerFechaDesde.Enabled = true;
                dateTimePickerFechaHasta.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agencia.eliminarRerservaHotel(Convert.ToInt32(textBox_id.Text), Convert.ToDouble(textCosto.Text));
            refrescar();
            textBox_id.Text = "";
            textCosto.Text = "";
            dateTimePickerFechaDesde.Value = Convert.ToDateTime(DateTime.Now);
            dateTimePickerFechaHasta.Value = Convert.ToDateTime(DateTime.Now);
            button1.Enabled = false;
            button2.Enabled = false;
            dateTimePickerFechaDesde.Enabled = false;
            dateTimePickerFechaHasta.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 idHotel = Convert.ToInt32(textBoxidHotel.Text);
            Int32 idReservaHotel = Convert.ToInt32(textBox_id.Text);
            DateTime fechaDesde = dateTimePickerFechaDesde.Value;
            DateTime fechaHasta = dateTimePickerFechaHasta.Value;

            Hotel miHotel = agencia.getHoteles().FirstOrDefault(x => x.id == Convert.ToInt32(textBoxidHotel.Text));
            TimeSpan ts = fechaHasta.Date.Subtract(fechaDesde.Date);
            double costo = (ts.Days + 1) * miHotel.costo;


            if (agencia.TraerDisponibilidadHotelParaEdicion(miHotel, fechaDesde, fechaHasta, 1))
            {
                agencia.editarReservaHotel(fechaDesde, fechaHasta, costo, idReservaHotel);
                refrescar();
                textBox_id.Text = "";
                textCosto.Text = "";
                button1.Enabled = false;
                button2.Enabled = false;
                dateTimePickerFechaDesde.Enabled = false;
                dateTimePickerFechaHasta.Enabled = false;
            }
            else
            {
                MessageBox.Show("No hay disponibilidad");
            }
        }

        private void dateTimePickerFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            caluclarCostoParaFecha();
        }

        private void dateTimePickerFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            caluclarCostoParaFecha();
        }

        private void caluclarCostoParaFecha()
        {

            if (dateTimePickerFechaHasta.Value.Date < dateTimePickerFechaDesde.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a fecha hasta");
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                Hotel miHotel = agencia.getHoteles().FirstOrDefault(x => x.id == Convert.ToInt32(textBoxidHotel.Text));
                TimeSpan ts = dateTimePickerFechaHasta.Value.Date.Subtract(dateTimePickerFechaDesde.Value.Date);
                double costo = (ts.Days + 1) * miHotel.costo;
                textCosto.Text = Convert.ToString(costo);
                button1.Enabled = true;
                button2.Enabled = true;
                dateTimePickerFechaDesde.Enabled = true;
                dateTimePickerFechaHasta.Enabled = true;
            }
        }

        private void textBoxidHotel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
