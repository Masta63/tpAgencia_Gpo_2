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
            this.form1 = form1;
            this.MdiParent = form1;
            this.Agencia = agencia;
            this.form1 = form1;
            MostrarDGV();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    string nombreCiudad = txtNombre.Text;

                  
                    bool resultado = Agencia.agregarCiudad(nombreCiudad);

                    if (resultado)
                    {
                       
                        string mensaje = $"Ciudad: {nombreCiudad}";
                        MessageBox.Show(mensaje, "Información de Ciudad");
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la ciudad");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar el nombre de la ciudad");
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
                if (Agencia.GetCiudades().Count >= 1)
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
                    MessageBox.Show("Debe seleccionar una ciudad");
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
                    int idCiudad = ciudadSeleccionada;
                    string nombreCiudad = txtNombre.Text;
                    int resultado = Agencia.modificarCiudad(idCiudad, nombreCiudad);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Ciudad modificada exitosamente");
                        MostrarDGV();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar la ciudad");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string? id = dgvCiudad[0, e.RowIndex]?.Value?.ToString();
                string? name = dgvCiudad[1, e.RowIndex]?.Value?.ToString();
                textCiudadId.Text = id;
                txtNombre.Text = name;
                int.Parse(id);
                ciudadSeleccionada = int.Parse(id);
            }
            catch(Exception)
            {

            }
        }

        private void FormCiudad_Load(object sender, EventArgs e)
        {

        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(Agencia, form1);
                menuAgenciaAdm.MdiParent = form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(Agencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }
    }
}
