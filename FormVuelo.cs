using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpAgencia_Gpo_2
{
    public partial class FormVuelo : Form
    {
        private Agencia agencia;
        private int vueloSeleccionado;



        public FormVuelo(Agencia agencia)
        {
            InitializeComponent();
            this.agencia = agencia;
            List<Ciudad> ciudades = agencia.GetCiudades();
            foreach (Ciudad c in ciudades)
            {
                comboBox1.Items.Add(c.nombre);
            }
            foreach (Ciudad c in ciudades)
            {
                comboBox2.Items.Add(c.nombre);
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            actualizarDatos();
            vueloSeleccionado = -1;
        }
        private void actualizarDatos()
        {
            dataGridView1.Rows.Clear();

            foreach (Vuelo vue in agencia.getVuelos())
            {
                dataGridView1.Rows.Add(vue.ToString());

                textBox8.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1[0, e.RowIndex].Value.ToString();
            string Origen = dataGridView1[1, e.RowIndex].Value.ToString();
            string Destino = dataGridView1[2, e.RowIndex].Value.ToString();
            string Capacidad = dataGridView1[3, e.RowIndex].Value.ToString();
            string Costo = dataGridView1[4, e.RowIndex].Value.ToString();
            string Fecha = dataGridView1[5, e.RowIndex].Value.ToString();
            string Aerolinea = dataGridView1[6, e.RowIndex].Value.ToString();
            string Avion = dataGridView1[7, e.RowIndex].Value.ToString();
            textBox8.Text = id;
            comboBox1.Text = Origen;
            comboBox2.Text = Destino;
            textBox3.Text = Capacidad;
            textBox4.Text = Costo;
            dateTimePicker1.Text = Fecha;
            textBox6.Text = Aerolinea;
            textBox7.Text = Avion;

            vueloSeleccionado = int.Parse(id);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cOrigen = comboBox1.Text;
            string cDestino = comboBox2.Text;

            Ciudad ciudadOrigen = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == cOrigen);
            Ciudad ciudadDestino = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == cDestino);



            if (ciudadOrigen == null || ciudadDestino == null || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))

                MessageBox.Show("Debe completar todos los campos para poder agregar un nuevo vuelo");

            else
            {
                int capacidad;
                if (!int.TryParse(textBox3.Text, out capacidad))
                {
                    MessageBox.Show("La capacidad debe ser un número válido");
                }

                double costo;
                if (!double.TryParse(textBox4.Text, out costo))
                {
                    MessageBox.Show("El costo debe tener dos decimales");
                }

                DateTime fecha;
                if (!DateTime.TryParse(dateTimePicker1.Text, out fecha))
                {
                    MessageBox.Show("Debe elegir una fecha");
                }

                if (agencia.agregarVuelo(ciudadOrigen, ciudadDestino, capacidad, costo, fecha, textBox6.Text, textBox7.Text))
                    MessageBox.Show("Vuelo agregado exitosamente");
                else
                    MessageBox.Show("Ocurrió un error al querer agregar un vuelo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (vueloSeleccionado != -1)
            {
                try
                {
                    string origen = comboBox1.Text;
                    string destino = comboBox2.Text;

                    Ciudad ciudadOrigen = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == origen);
                    Ciudad ciudadDestino = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == destino);

                    int capacidad = int.Parse(textBox3.Text);
                    double costo = double.Parse(textBox4.Text);
                    DateTime fecha = DateTime.Parse(dateTimePicker1.Text);

                    if (agencia.modificarVuelo(vueloSeleccionado, ciudadOrigen, ciudadDestino, capacidad, costo, fecha, textBox6.Text, textBox7.Text))
                    {
                        MessageBox.Show("Vuelo modificado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema al querer modificar el vuelo");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error al querer convertir los datos");
                }
            }
            else
                MessageBox.Show("Debe seleccionar un vuelo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vueloSeleccionado != -1)
            {
                if (agencia.eliminarVuelo(vueloSeleccionado))
                {
                    MessageBox.Show("Vuelo eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Hubo un problema al eliminar el vuelo");
                }
            }
            else
                MessageBox.Show("Debe seleccionar un vuelo");
        }
    }
}
