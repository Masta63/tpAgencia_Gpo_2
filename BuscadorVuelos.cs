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
                DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
                btnclm.Name = "Comprar";
                btnclm.Visible = true;
                btnclm.UseColumnTextForButtonValue = true;
                btnclm.Text = "Comprar";
                btnclm.HeaderText = "";
                dataGridView1.Columns.Add(btnclm);

                foreach (Vuelo vuelo in vuelosEncontrados)
                {
                    double costoUnitario = vuelo.costo;
                    double costoTotal = costoUnitario * cantidadPax;
                    string fechaFormateada = vuelo.fecha.ToString("dd/MM/yyyy");
                    dataGridView1.Rows.Add(vuelo.id, vuelo.origen.nombre, vuelo.destino.nombre, vuelo.capacidad, costoTotal.ToString("C"), fechaFormateada, vuelo.aerolinea, vuelo.avion, "Comprar");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnaComprar = "Comprar";
            if (dataGridView1.Columns[e.ColumnIndex].Name == columnaComprar && e.RowIndex >= 0)
            {
                Usuario usuarioActualCompra = agencia.getUsuarioActual();
                int vueloId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                int cantidad = (int)numericUpDownPax.Value;

                if (usuarioActualCompra != null)
                {
                    bool compraExitosa = agencia.comprarVuelo(vueloId, usuarioActualCompra, cantidad);

                    if (compraExitosa)
                    {
                        Vuelo vueloSeleccionado = agencia.getVuelos().FirstOrDefault(v=> v.id ==vueloId);
                      
                        if(vueloSeleccionado != null)
                        {
                            vueloSeleccionado.capacidad -= cantidad;
                        }
                        int rowIndex = e.RowIndex;
                        int asientosDisponibles = vueloSeleccionado.capacidad;
                        dataGridView1.Rows[rowIndex].Cells["Cantidad"].Value = asientosDisponibles;
                       
                        
                        
                        MessageBox.Show("Reserva realiza con éxito");
                    }
                    
                }

            }
        }
    }
}
