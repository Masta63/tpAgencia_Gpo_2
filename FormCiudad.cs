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
    public partial class FormCiudad : Form
    {
        List<Ciudad> listaCiudades = new List<Ciudad>();
        public TransfDelegadoFormCiudad TransfEventoFormCiudad;
        public FormCiudad()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(this.numericID.Value);
            if (listaCiudades.Any(c => c.id == codigo))
            {
                MessageBox.Show("Ya existe una ciudad con este codigo asignado, reintente", "Error");
                return;
            }

            try
            {
                Ciudad oCiudad = new Ciudad(Convert.ToInt32(numericID.Value), txtNombre.Text);
                listaCiudades.Add(oCiudad);

                //Validacion para verificar que se cargo correctamente la ciudad
                string mensaje = $"Ciudad: {oCiudad.nombre}\n";

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
        public delegate void TransfDelegadoFormCiudad();
        public void MostrarDGV()
        {
            this.dgvCiudad.DataSource = null;
            this.dgvCiudad.DataSource = listaCiudades;
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
                        if (item.id == seleccionadoC.id)
                        {
                            listaCiudades.Remove(item);
                        }
                    }
                }
            }
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

                    seleccionadoC.id = Convert.ToInt32(numericID.Value);
                    seleccionadoC.nombre = txtNombre.Text;

                    MostrarDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
