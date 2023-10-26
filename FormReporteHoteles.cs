using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static tpAgencia_Gpo_2.FormCiudad;

namespace tpAgencia_Gpo_2
{
    public partial class FormReporteHoteles : Form
    {
        public TransfDelegadoFormReporteHoteles TransfEventoFormCiudad;
        private Agencia Agencia;
        private Form1 Form1;
        private FormReservaHotel FormReservaHotel;
        public FormReporteHoteles(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.Agencia = agencia;
            armarComboCiudades();
            this.Form1 = form1;
        }

        private void armarComboCiudades()
        {

            foreach (var itemCiudades in Agencia.GetCiudades())
            {
                boxCiudades.Items.Add(itemCiudades.nombre);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public delegate void TransfDelegadoFormReporteHoteles();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


        private bool validaciones()
        {
            bool ingresar = false;


            if (fechaDesde.Value > fechaHasta.Value)
            {
                MessageBox.Show("La fecha desde tiene que ser menor o igual a la de fecha hasta");
                ingresar = true;
            }

            if (fechaDesde.Value == null)
            {
                MessageBox.Show("Se debe ingresar fecha desde");
                ingresar = true;
            }


            if (fechaHasta.Value == null)
            {
                MessageBox.Show("Se debe ingresar cantidad de persona");
                ingresar = true;
            }
            if (boxCiudades.SelectedItem == null)
            {
                MessageBox.Show("Se debe ingresar ciudad");
                ingresar = true;
            }
            return ingresar;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (!validaciones())
            {
                if (!traerDisponibilidad())
                    MessageBox.Show("No hay hoteles disponbiles");
            }
        }


        private bool traerDisponibilidad()
        {
            string ciudadSeleccionada = boxCiudades.SelectedItem.ToString();
            DateTime fechaIngreso = fechaDesde.Value;
            DateTime fechaEgreso = fechaHasta.Value;
            List<Hotel> hotelesDisponibles = Agencia.TraerDisponibilidadHotel(ciudadSeleccionada, fechaIngreso, fechaEgreso, "1");
            bool disponibilidad = false;
            dataGridViewHotel.Rows.Clear();
            if (hotelesDisponibles.Count > 0)
            {
                foreach (var itemHotel in hotelesDisponibles)
                {
                    TimeSpan ts = fechaEgreso.Date.Subtract(fechaIngreso.Date);
                    double costo = ((ts.Days + 1) * itemHotel.costo);
                    int disp = itemHotel.capacidad != itemHotel.disponibilidad ? itemHotel.disponibilidad : itemHotel.capacidad;
                    dataGridViewHotel.Rows.Add(new string[] { Convert.ToString(itemHotel.id), itemHotel.ubicacion.nombre, Convert.ToString(disp), Convert.ToString(costo), itemHotel.nombre, fechaIngreso.ToShortDateString(), fechaEgreso.ToShortDateString() });
                    disponibilidad = true;
                }
            }

            return disponibilidad;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string? id = dataGridViewHotel?[0, e.RowIndex]?.Value?.ToString();
                string? nombre = dataGridViewHotel?[4, e.RowIndex]?.Value?.ToString();

                labelIdComprar.Text = id;
                labelNombreHotel.Text = nombre;
            }
            catch (Exception)
            {
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void irAreservar(ReservaHotel reservaHotel)
        {
            this.MdiParent = Form1;
            this.Close();
            FormReservaHotel = new FormReservaHotel(Agencia, Form1, reservaHotel);
            FormReservaHotel.Show();
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            double monto = Agencia.getUsuarioActual().credito;

            if (!string.IsNullOrEmpty(TextMonto.Text))
            {
                if (monto < Convert.ToDouble(TextMonto.Text))
                {
                    MessageBox.Show("No tiene suficiente credito");
                }
            }

            if (string.IsNullOrEmpty(labelIdComprar.Text))
                MessageBox.Show("Debe seleccionar una reserva para comprar");

            if (string.IsNullOrEmpty(TextMonto.Text))
                MessageBox.Show("Debe seleccionar una monto para comprar");

            if (!string.IsNullOrEmpty(labelIdComprar.Text) && !string.IsNullOrEmpty(TextMonto.Text) && monto >= Convert.ToDouble(TextMonto.Text) && !string.IsNullOrEmpty(TextMonto.Text))
            {
                Hotel? hotelSeleccionado = Agencia.getHoteles().Where(x => x.id == Convert.ToInt32(labelIdComprar.Text)).FirstOrDefault();
                ReservaHotel reservaHotel = new ReservaHotel(hotelSeleccionado, Agencia.getUsuarioActual(), fechaDesde.Value, fechaHasta.Value, Convert.ToInt32(TextMonto.Text));
                this.irAreservar(reservaHotel);
            }
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {


            this.Close();
            if (Agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(Agencia, Form1);
                menuAgenciaAdm.MdiParent = Form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(Agencia, Form1);
                MenuAgencia.MdiParent = Form1;
                MenuAgencia.Show();
            }


        }
    }
}
