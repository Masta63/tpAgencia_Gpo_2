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
using static tpAgencia_Gpo_2.FormCiudad;

namespace tpAgencia_Gpo_2
{
    public partial class FormReporteHoteles : Form
    {
        public TransfDelegadoFormReporteHoteles TransfEventoFormCiudad;
        private Agencia Agencia;
        public FormReporteHoteles(Agencia agencia)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Agencia = agencia;
            armarComboCiudades();
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

        private void botonBuscar_Click(object sender, EventArgs e)
        {

            if (fechaDesde.Value == null)
            {
                MessageBox.Show("se debe ingresar fecha desde");

            }

            if (string.IsNullOrEmpty(textCantPer.Text))
            {
                MessageBox.Show("se debe ingresar cantidad de persona");

            }


            if (fechaHasta.Value == null)
            {
                MessageBox.Show("se debe ingresar cantidad de persona");

            }
            if (boxCiudades.SelectedItem == null)
            {
                MessageBox.Show("se debe ingresar ciudad");

            }

            if (fechaDesde.Value != null && !string.IsNullOrEmpty(textCantPer.Text) && fechaHasta.Value != null && boxCiudades.SelectedItem != null)
            {

                string ciudadSeleccionada = boxCiudades.SelectedItem.ToString();
                DateTime fechaIngreso = fechaDesde.Value;
                DateTime fechaEgreso = fechaHasta.Value;

                int userVal = int.Parse(textCantPer.Text);



                bool estaRango = false;
                int cantPer = 0;

                List<Hotel> hotelesDisponibles = new List<Hotel>();

                foreach (var itemHotel in Agencia.getHoteles())
                {
                    if (itemHotel.ubicacion.nombre == ciudadSeleccionada)
                    {
                        foreach (var itemReserva in itemHotel.misReservas)
                        {
                            if (itemReserva.miHotel.id == itemHotel.id)
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
                        if (!estaRango && Convert.ToInt32(textCantPer.Text) < itemHotel.capacidad)
                            hotelesDisponibles.Add(itemHotel);
                    }
                }

                bool disponibilidad = false;
                dataGridViewHotel.Rows.Clear();
                if (hotelesDisponibles.Count > 0)
                {
                    foreach (var itemHotel in hotelesDisponibles)
                    {
                        dataGridViewHotel.Rows.Add(new string[] { Convert.ToString(itemHotel.id), itemHotel.ubicacion.nombre, Convert.ToString(itemHotel.capacidad), Convert.ToString(itemHotel.costo), itemHotel.nombre });
                        disponibilidad = true;
                    }
                }

                if (!disponibilidad)
                    MessageBox.Show("No hay hoteles disponbiles");

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
