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
    public partial class FormVuelo : Form
    {
        private Agencia agencia;
        private int vueloSeleccionado;
        public TransfDelegadoFormVuelo TransfEventoFormVuelo;
        private Form1 Form1;

        public FormVuelo(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            List<Ciudad> ciudades = agencia.GetCiudades();
            this.Form1 = form1;
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
                string idCOrigen = agencia.obtenerCiudadPorId(vue.origen.id);
                string idCDestino = agencia.obtenerCiudadPorId(vue.destino.id);

                dataGridView1.Rows.Add(vue.id, idCOrigen, idCDestino, vue.capacidad, vue.costo, vue.fecha, vue.aerolinea, vue.avion);

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
        public delegate void TransfDelegadoFormVuelo();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch(Exception)
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string origen = comboBox1.Text;
            string destino = comboBox2.Text;
            int idCOrigen = agencia.obtenerNombreCiudad(origen);
            int idCDestino = agencia.obtenerNombreCiudad(destino);


            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Debe completar todos los campos para poder agregar un nuevo vuelo");
            }
            else
            {
                if (idCOrigen == -1 || idCDestino == -1)
                {
                    MessageBox.Show("Debe seleccionar una ciudad");
                    return;
                }

                int capacidad;
                if (!int.TryParse(textBox3.Text, out capacidad))
                {
                    MessageBox.Show("La capacidad debe ser un número válido");
                    return;
                }

                double costo;
                if (!double.TryParse(textBox4.Text, out costo))
                {
                    MessageBox.Show("El costo debe ser un número válido");
                    return;
                }

                DateTime fecha;
                if (!DateTime.TryParse(dateTimePicker1.Text, out fecha))
                {
                    MessageBox.Show("Debe elegir una fecha");
                    return;
                }

                if (agencia.agregarVuelo(idCOrigen, idCDestino, capacidad, costo, fecha, textBox6.Text, textBox7.Text))
                {
                    MessageBox.Show("Vuelo agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al querer agregar un vuelo");
                }
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

                    //Ciudad ciudadOrigen = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == origen);
                    //Ciudad ciudadDestino = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == destino);

                    int idOrigen = agencia.obtenerNombreCiudad(origen);
                    int idDestino = agencia.obtenerNombreCiudad(destino);

                    int capacidad = int.Parse(textBox3.Text);
                    double costo = double.Parse(textBox4.Text);
                    DateTime fecha = DateTime.Parse(dateTimePicker1.Text);

                    string resultado = (agencia.modificarVuelo(vueloSeleccionado, idOrigen, idDestino, capacidad, costo, fecha, textBox6.Text, textBox7.Text));
                    switch (resultado)
                    {
                        case "exito":
                            MessageBox.Show("Vuelo modificado exitosamente");
                            break;
                        case "capacidad":
                            MessageBox.Show("La capacidad es menor a la cantidad de personas que reservaron el vuelo");
                            break;
                        case "error":
                            MessageBox.Show("Ocurrió un problema al querer modificar el vuelo");
                            break;
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

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(agencia, Form1);
            MenuAgencia.MdiParent = Form1;
            MenuAgencia.Show();
        }
    }
}
