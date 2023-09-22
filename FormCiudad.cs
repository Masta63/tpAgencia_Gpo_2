using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace tpAgencia_Gpo_2
{
    public partial class FormCiudad : Form
    {
        private Agencia Agencia;
        public TransfDelegadoFormCiudad TransfEventoFormCiudad;
        private int ciudadSeleccionada;
        private Form1 form1;
        public FormCiudad(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Agencia = agencia;
            this.form1 = form1;
            MostrarDGV();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Agencia.GetCiudades().OrderByDescending(x => x.id).FirstOrDefault().id + 1;

                Ciudad oCiudad = new Ciudad(Convert.ToInt32(id), txtNombre.Text);
                Agencia.setCiudad(oCiudad);
                textCiudadId.Text = Convert.ToString(id);
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
            dgvCiudad.Rows.Clear();
            foreach (var itemCiudad in Agencia.GetCiudades())
            {
                dgvCiudad.Rows.Add(new string[] { itemCiudad.id.ToString(), itemCiudad.nombre });
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (Agencia.GetCiudades().Count > 1)
                {
                    if (Agencia.eliminarCiudad(Convert.ToInt32(ciudadSeleccionada)))
                    {
                        textCiudadId.Text = " ";
                        txtNombre.Text = "";
                        MessageBox.Show("Eliminado con éxito");
                    }
                    else
                        MessageBox.Show("Problemas al eliminar");
                }
                else
                    MessageBox.Show("Debe seleccionar un usuario");
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
                if (ciudadSeleccionada != -1)
                {
                    foreach (Ciudad itemCiudad in Agencia.GetCiudades())
                    {
                        if (itemCiudad.id == ciudadSeleccionada)
                            itemCiudad.nombre = txtNombre.Text;
                    }

                    MostrarDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvCiudad[0, e.RowIndex].Value.ToString();
            string name = dgvCiudad[1, e.RowIndex].Value.ToString();
            textCiudadId.Text = id;
            txtNombre.Text = name;
            int.Parse(id);
            ciudadSeleccionada = int.Parse(id);
        }

        private void FormCiudad_Load(object sender, EventArgs e)
        {

        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(Agencia, form1);
            MenuAgencia.MdiParent = form1;
            MenuAgencia.Show();
        }
    }
}
