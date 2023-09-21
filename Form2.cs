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

namespace tpAgencia_Gpo_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private List<Hotel> hoteles;
        private void Form2_Load(object sender, EventArgs e)
        {
            hoteles = new List<Hotel>();
            {
                new Hotel(1, new Ciudad(1, "San carlos de Bariloche"), 10, 33500, "Faena");
                new Hotel(2, new Ciudad(2, "San Rafael"), 10, 34500, "Minguito Hotel");
                new Hotel(3, new Ciudad(3, "Ciudad Autonoma de Buenos Aires"), 10, 63500, "Hogwarts");
                new Hotel(4, new Ciudad(4, "Formosa"), 10, 31500, "HotelHotelcito");
                new Hotel(5, new Ciudad(5, "Colon"), 10, 32200, "Alto Hotel");
                new Hotel(6, new Ciudad(6, "Viedma"), 10, 61500, "Juan hotel");
            }

            boxCiudades.Items.Add("San carlos de Bariloche");
            boxCiudades.Items.Add("San Rafael");
            boxCiudades.Items.Add("Ciudad Autonoma de Buenos Aires");
            boxCiudades.Items.Add("Formosa");
            boxCiudades.Items.Add("Colon");
            boxCiudades.Items.Add("Viedma");

        }

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
            // Filtrar hoteles disponibles
            string ciudadSeleccionada = boxCiudades.SelectedItem.ToString();
            DateTime fechaIngreso = fechaDesde.Value;
            DateTime fechaEgreso = fechaHasta.Value;
            int userVal = int.Parse(textBox1.Text);


            var hotelesDisponibles = hoteles.Where(h =>
            h.Ubicacion.nombre == ciudadSeleccionada &&
            h.Capacidad >= userVal
            ).ToList();

            // Mostrar los resultados en el DataGridView
            if (hotelesDisponibles.Any())
            {
                dataGridViewHotel.DataSource = hotelesDisponibles;
            }
            else
            {
                MessageBox.Show("No se encontraron hoteles disponibles para los criterios seleccionados.");
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
