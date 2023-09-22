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
    public partial class BuscadorVuelos : Form
    {
        private Agencia agencia;
        private Form1 form1;
        public TransfDelegadoBuscadorVuelos TransfEventoBuscadorVuelos;
        public BuscadorVuelos(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.agencia = agencia;
            this.form1 = form1;
            List<Ciudad> ciudades = agencia.GetCiudades();
            foreach (Ciudad c in ciudades)
            {
                comboBoxCorigen.Items.Add(c.nombre);
            }

            foreach (Ciudad c in ciudades)
            {
                comboBoxCdestino.Items.Add(c.nombre);
            }

        }
        public delegate void TransfDelegadoBuscadorVuelos();
        private void actualizarDatos()
        {
            dataGridView1.Rows.Clear();

            foreach (Vuelo vue in agencia.getVuelos())
            {
                dataGridView1.Rows.Add(vue.ToString());




            }
        }
        private void comboBoxCorigen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cOrigen = comboBoxCorigen.Text;
            string cDestino = comboBoxCdestino.Text;
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            int cantidadPax = (int)numericUpDownPax.Value;

            Ciudad ciudadOrigen = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == cOrigen);
            Ciudad ciudadDestino = agencia.GetCiudades().FirstOrDefault(ciudad => ciudad.nombre == cDestino);

            List<Vuelo> vuelosEncontrados = agencia.buscarVuelos(ciudadOrigen, ciudadDestino, fechaSeleccionada, cantidadPax);

            dataGridView1.Rows.Clear();

            if (vuelosEncontrados.Count >0)
            {
                foreach (Vuelo vuelo in vuelosEncontrados)
                {
                    dataGridView1.Rows.Add(vuelo.ToString());
                }
            }
          
                else
                {
                    MessageBox.Show("No hay vuelos disponibles");
                }
           

           
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(agencia, form1);
            MenuAgencia.MdiParent = form1;
            MenuAgencia.Show();
        }
    }
}
