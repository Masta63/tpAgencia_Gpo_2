using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABMCiudadV2
{
    public partial class ABMCIUDAD : Form
    {
        List<Ciudad> listaCiudades = new List<Ciudad>();
        public Agencia oAgencia { get; set; }
        public ABMCIUDAD()
        {
            InitializeComponent();
        }

        private void ABMCIUDAD_Load(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.numericID.Value);
            if (listaCiudades.Any(c => c.Id == codigo))
            {
                MessageBox.Show("Ya existe una ciudad con este codigo asignado, reintente", "Error");
                return;
            }

            try
            {
                Ciudad oCiudad = new Ciudad(Convert.ToInt32(numericID.Value), txtNombre.Text);
                listaCiudades.Add(oCiudad);
                //Entonces agrego a la lista de ciudades de la agencia el objeto ciudad
                oAgencia.listaCiudades.Add(oCiudad);
                //Validacion para verificar que se cargo correctamente la ciudad
                string mensaje = $"Ciudad: {oCiudad.Nombre}\n";

                MessageBox.Show(mensaje, "Información de Ciudad");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Llamo el metodo que actualiza el datagridview para mostrar las ciudades
                MostrarDGV();
            }

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCiudad.SelectedRows.Count > 0)
                {
                    Ciudad seleccionadoC = (Ciudad)dgvCiudad.CurrentRow.DataBoundItem;
                    foreach (Ciudad item in listaCiudades.ToArray())
                    {
                        if (item.Id == seleccionadoC.Id)
                        {
                            listaCiudades.Remove(item);
                            //Forzamos la actualizacion, le cambio la lista por la nueva
                            //oAgencia.listaCiudades = listaCiudades;
                            oAgencia.listaCiudades.Remove(item);
                        }
                    }
                }
            }

            //if(dgvCiudad.SelectedRows.Count>0)

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MostrarDGV();

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCiudad.SelectedRows.Count > 0)
                {
                    Ciudad seleccionadoC = (Ciudad)dgvCiudad.CurrentRow.DataBoundItem;

                    seleccionadoC.Id = Convert.ToInt32(numericID.Value);
                    seleccionadoC.Nombre = txtNombre.Text;

                    MostrarDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MostrarDGV()
        {
            this.dgvCiudad.DataSource = null;
            this.dgvCiudad.DataSource = listaCiudades;
        }

        private void numericID_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
