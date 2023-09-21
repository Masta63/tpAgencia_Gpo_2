namespace ABMCIUDAD
{
    public partial class Form1 : Form
    {
        List<Ciudad> listaCiudades = new List<Ciudad>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                        if (item.Id == seleccionadoC.Id)
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

        private void numericID_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}