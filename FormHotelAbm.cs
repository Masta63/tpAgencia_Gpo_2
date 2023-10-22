using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static tpAgencia_Gpo_2.FormVuelo;

namespace tpAgencia_Gpo_2
{
    public partial class FormHotelAbm : Form
    {
        private Agencia agencia;
        private int hotelSeleccionado;
        public TransfDelegadoFormHotel TransfEventoFormHotel;
        private Form1 Form1;


        public FormHotelAbm(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            this.Form1 = form1;
            List<Ciudad> ciudades = agencia.GetCiudades();

            foreach (Ciudad c in ciudades)
            {
                comboBoxHospedaje.Items.Add(c.nombre);
            }

        }

        private void actualizarDatos()
        {
            dataGridViewHoteles.Rows.Clear();

            foreach (Hotel hotel in agencia.getHotel())
            {
                dataGridViewHoteles.Rows.Add(hotel.ToString());

                textBoxId.Text = "";
                textBoxNombre.Text = "";
                comboBoxHospedaje.Text = "";
                textBoxCapacidad.Text = "";
                textBoxCosto.Text = "";
            }
        }

        public delegate void TransfDelegadoFormHotel();

        private void FormHotelAbm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBoxCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxHospedaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string? id = dataGridViewHoteles[0, e.RowIndex]?.Value?.ToString();
                string? ubicacion = dataGridViewHoteles[1, e.RowIndex]?.Value?.ToString();
                string? capacidad = dataGridViewHoteles[2, e.RowIndex]?.Value?.ToString();
                string? costo = dataGridViewHoteles[3, e.RowIndex]?.Value?.ToString();
                string? nombre = dataGridViewHoteles[4, e.RowIndex]?.Value?.ToString();

                textBoxId.Text = id;
                comboBoxHospedaje.Text = ubicacion;
                textBoxCapacidad.Text = capacidad;
                textBoxCosto.Text = costo;
                textBoxNombre.Text = nombre;


                hotelSeleccionado = int.Parse(id);
            }
            catch (Exception)
            {
            }

        }

        private void buttonActualizarInformacion_Click(object sender, EventArgs e)
        {
            actualizarDatos();
            hotelSeleccionado = 1;

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string ubicacion = comboBoxHospedaje.Text;


            Ciudad ciudadHospedaje = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == ubicacion);


            //string.IsNullOrEmpty(textBoxId.Text) Eliminar si el proyecto esta co,
            if (ciudadHospedaje == null || string.IsNullOrEmpty(textBoxCapacidad.Text) || string.IsNullOrEmpty(textBoxCosto.Text) || string.IsNullOrEmpty(textBoxNombre.Text))

                MessageBox.Show("Debe completar todos los campos para poder agregar un nuevo hotel");

            else
            {
                int capacidad;
                if (!int.TryParse(textBoxCapacidad.Text, out capacidad))
                {
                    MessageBox.Show("La capacidad debe ser un número válido");
                }

                double costo;
                if (!double.TryParse(textBoxCosto.Text, out costo))
                {
                    MessageBox.Show("El costo debe tener dos decimales");
                }


                if (agencia.agregarHotel(ciudadHospedaje, capacidad, costo, textBoxNombre.Text)) { 
                    MessageBox.Show("Hotel agregado exitosamente");
                }
                else
                    MessageBox.Show("Ocurrió un error al querer agregar un Hotel");
            }
        }


        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (hotelSeleccionado != -10)
            {
                try
                {
                    var ubicacion1 = comboBoxHospedaje.Text;
                    Ciudad ciudadHospedaje1 = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == ubicacion1);
                    int capacidad = int.Parse(textBoxCapacidad.Text);
                    double costo = double.Parse(textBoxCosto.Text);
                    int id = int.Parse(textBoxId.Text);


                    if (agencia.modificarHotel(hotelSeleccionado, ciudadHospedaje1, capacidad, costo, textBoxNombre.Text))
                    {
                        MessageBox.Show("Datos del hotel modificado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema al querer modificar los datos del hotel");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error al querer convertir los datos");
                }
            }
            else
                MessageBox.Show("Debe seleccionar un hotel");
        }



        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (hotelSeleccionado != -10)
            {
                if (agencia.eliminarHotel(hotelSeleccionado))
                {
                    MessageBox.Show("Hotel eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Hubo un problema al eliminar el Hotel");
                }
            }
            else
                MessageBox.Show("Debe seleccionar un Hotel");
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(agencia, Form1);
            MenuAgencia.MdiParent = Form1;
            MenuAgencia.Show();
        }

        private void textBoxCapacidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
