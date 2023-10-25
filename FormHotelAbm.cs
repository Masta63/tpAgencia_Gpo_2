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

            foreach (Hotel ho in agencia.getHotel())//para cada usuario en el clon de listado de usuarios de mi referencia de agencia
            {

                dataGridViewHoteles.Rows.Add(new string[] { ho.id.ToString(), ho.ubicacion.nombre, Convert.ToString(ho.capacidad), Convert.ToString(ho.costo), ho.nombre});

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
            string ubicacionTextBox = comboBoxHospedaje.Text;
            string nombre = textBoxNombre.Text;
            Int32 capacidad = Convert.ToInt32(textBoxCapacidad.Text);
            int ubicacion = agencia.obtenerNombreCiudad(ubicacionTextBox);

            if (string.IsNullOrEmpty(textBoxCapacidad.Text) || string.IsNullOrEmpty(textBoxCosto.Text) || string.IsNullOrEmpty(textBoxNombre.Text))

                MessageBox.Show("Debe completar todos los campos para poder agregar un nuevo hotel");

            else
            {

                float costo;
                if (!float.TryParse(textBoxCosto.Text, out costo))
                {
                    MessageBox.Show("El costo debe tener dos decimales");
                }


                if (agencia.agregarHotel(ubicacion, capacidad, costo, nombre))
                {
                    MessageBox.Show("Hotel agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al querer agregar un Hotel");
                }
            }
        }


        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (hotelSeleccionado != -10)
            {
                try
                {
                    int ubicacion = agencia.obtenerNombreCiudad(comboBoxHospedaje.Text);
                    Int32 capacidad = Convert.ToInt32(textBoxCapacidad.Text);
                    float costo = float.Parse(textBoxCosto.Text);
                    //int id = int.Parse(textBoxId.Text);
                    string nombre = textBoxNombre.Text;


                    string resultado = (agencia.modificarHotel(hotelSeleccionado,ubicacion, capacidad, costo, nombre));
                    switch (resultado)
                    {
                        case "exito":
                            MessageBox.Show("Hotel modificado exitosamente");
                            break;
                        case "capacidad":
                            MessageBox.Show("La capacidad es menor a la cantidad de personas que reservaron el hotel");
                            break;
                        case "error":
                            MessageBox.Show("Ocurrió un problema al querer modificar el hotel");
                            break;
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
            if (agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(agencia, Form1);
                menuAgenciaAdm.MdiParent = Form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(agencia, Form1);
                MenuAgencia.MdiParent = Form1;
                MenuAgencia.Show();
            }
        }

        private void textBoxCapacidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
