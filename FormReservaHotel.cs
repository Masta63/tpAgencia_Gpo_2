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
using static tpAgencia_Gpo_2.FormReporteHoteles;

namespace tpAgencia_Gpo_2
{
    public partial class FormReservaHotel : Form
    {
        public TransfDelegadoFormAltaReserva transfDelegadoFormAltaReserva;
        private Agencia Agencia;
        private Form1 Form1;
        public FormReservaHotel(Agencia agencia, Form1 form1, ReservaHotel? reservaHotel, string cantHuesp)
        {
            InitializeComponent();
            this.Agencia = agencia;
            //armarComboHoteles();
            this.Form1 = form1;

            if (reservaHotel != null)
            {
                boxHoteles.Text = reservaHotel.miHotel.nombre;
                fechaDesde.Value = reservaHotel.fechaDesde;
                fechaHasta.Value = reservaHotel.fechaHasta;
                textBoxMonto.Text = Convert.ToString(reservaHotel.pagado);
                textCantPer.Text = cantHuesp;
                dataGridViewHotel.Rows.Add(new string[] { reservaHotel.miHotel.nombre, Convert.ToString(reservaHotel.pagado), Convert.ToString(reservaHotel.miHotel.capacidad), reservaHotel.fechaDesde.ToLongTimeString(), reservaHotel.fechaHasta.ToLongTimeString() });
            }

        }

        private void armarComboHoteles()
        {
            foreach (var itemHoteles in Agencia.getHoteles())
            {
                boxHoteles.Items.Add(itemHoteles.nombre);
            }
        }


        public delegate void TransfDelegadoFormAltaReserva();
        private void buttonComprar_Click(object sender, EventArgs e)
        {

            if (validacionesInput())
            {
                if (traerDisponibilidad())
                    MessageBox.Show("Reservado");
            }
        }

        private bool traerDisponibilidad()
        {

            DateTime fechaIngreso = fechaDesde.Value;
            DateTime fechaEgreso = fechaHasta.Value;
            bool disponibilidad = false;
            bool estaRango = false;
            int cantPer = 0;

            Hotel? hotelSeleccionado = Agencia.getHoteles().Where(x => x.nombre == boxHoteles.Text).FirstOrDefault();

            if (validaciones(hotelSeleccionado))
            {
                ReservaHotel? reservaHotel = null;
                foreach (var itemReserva in hotelSeleccionado.misReservas)
                {
                    if (itemReserva.miHotel.id == hotelSeleccionado.id)
                    {
                        if (itemReserva.fechaDesde < fechaIngreso && itemReserva.fechaHasta > fechaIngreso)
                        {
                            estaRango = true;

                        }

                        if (itemReserva.fechaDesde < fechaEgreso && itemReserva.fechaHasta > fechaEgreso)
                        {
                            estaRango = true;
                        }
                    }
                    else
                    {
                        estaRango = false;
                    }
                    cantPer++;
                }
                if (!estaRango && Convert.ToInt32(textCantPer.Text) <= hotelSeleccionado.capacidad && hotelSeleccionado.costo == Convert.ToDouble(textBoxMonto.Text))
                {
                    int savePersonas = hotelSeleccionado.capacidad;
                    reservaHotel = new ReservaHotel(hotelSeleccionado, Agencia.getUsuarioActual(),fechaIngreso, fechaEgreso, Convert.ToDouble(textBoxMonto.Text));
                    hotelSeleccionado.capacidad = hotelSeleccionado.capacidad - Convert.ToInt32(textCantPer.Text);

                    Usuario usuarioActual = Agencia.getUsuarioActual();
                    usuarioActual.setReservaHotel(reservaHotel);
                    Agencia.setUsuario(usuarioActual);
                    Agencia.setReservasHotel(reservaHotel);
                    hotelSeleccionado.capacidad = savePersonas;
                    Agencia.getUsuarioActual().setReservaHotel(reservaHotel);

                }


                dataGridViewHotel.Rows.Clear();
                if (reservaHotel != null)
                {
                    dataGridViewHotel.Rows.Add(new string[] { hotelSeleccionado.nombre, textBoxMonto.Text, Convert.ToString(hotelSeleccionado.capacidad), fechaIngreso.ToLongTimeString(), fechaEgreso.ToLongTimeString() });
                    disponibilidad = true;
                }
            }
            return disponibilidad;
        }

        private bool validacionesInput()
        {
            if (textCantPer.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar cantidad de personas");
                return false;
            }

            if (boxHoteles.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un hotel");
                return false;
            }
            if (textBoxMonto.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un monto");
                return false;
            }
            return true;
        }
        private bool validaciones(Hotel? hotelSeleccionado)
        {
            if (Convert.ToInt32(textCantPer.Text) > hotelSeleccionado.capacidad)
            {
                MessageBox.Show("No hay capacidad");
                return false;
            }
            if (hotelSeleccionado.costo > Convert.ToDouble(textBoxMonto.Text))
            {
                MessageBox.Show("No cubre el costo");
                return false;
            }
            if (hotelSeleccionado.costo < Convert.ToDouble(textBoxMonto.Text))
            {
                MessageBox.Show("El costo es mayor");
                return false;
            }
            return true;
        }

        private void dataGridViewHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReservaHotel_Load(object sender, EventArgs e)
        {

        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(Agencia, Form1);
            MenuAgencia.MdiParent = Form1;
            MenuAgencia.Show();
        }
    }
}
