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
using static tpAgencia_Gpo_2.BuscadorVuelos;

namespace tpAgencia_Gpo_2
{
    public partial class FormReservasVuelos : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        private int vueloSeleccionado;
        public TransfDelegadoReservasVuelos TransfEventoReservasVuelos;
        public FormReservasVuelos(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            this.form1 = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.Load += FormReservasVuelos_Load;
        }

        public delegate void TransfDelegadoReservasVuelos();

        private void FormReservasVuelos_Load(object sender, EventArgs e)
        {
            MostrarVuelos();
            vueloSeleccionado = -1;
        }
        private void MostrarVuelos()
        {
            dataGridView1.Rows.Clear();

            if (usuarioActual != null)
            {
                List<Vuelo> vuelosFuturos = agencia.misReservasVuelos(usuarioActual);

                var vuelosIguales = vuelosFuturos.GroupBy(v => v.id).Select(group => new
                {
                    Vuelo = group.Key,
                    Cantidad = group.Count(),
                    MontoTotal = group.Sum(v => v.costo)
                });

                foreach (var vuelosAgrupado in vuelosIguales)
                {
                    Vuelo vuelo = vuelosFuturos.FirstOrDefault(v => v.id == vuelosAgrupado.Vuelo);
                    if (vuelo != null)
                    {

                        dataGridView1.Rows.Add(
                            vuelo.id,
                            vuelo.origen.nombre,
                            vuelo.destino.nombre,
                            vuelosAgrupado.MontoTotal,
                            vuelo.fecha.ToString("dd/MM/yyyy"),
                            vuelo.aerolinea, vuelo.avion, vuelosAgrupado.Cantidad);
                    }

                }



            }

        }



        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(agencia, form1);
                menuAgenciaAdm.MdiParent = form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(agencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }

        private void FormReservasVuelos_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            //    string Origen = dataGridView1.Rows[e.RowIndex].Cells["Origen"].Value.ToString();
            //    string Destino = dataGridView1.Rows[e.RowIndex].Cells["Destino"].Value.ToString();
            //    string Costo = dataGridView1.Rows[e.RowIndex].Cells["Costo"].Value.ToString();
            //    string Fecha = dataGridView1.Rows[e.RowIndex].Cells["Fecha"].Value.ToString();
            //    string Aerolinea = dataGridView1.Rows[e.RowIndex].Cells["Aerolinea"].Value.ToString();
            //    string Cantidad = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();


            //    textBoxOrigen.Text = Origen;
            //    textBoxDestino.Text = Destino;
            //    textBoxFecha.Text = Cantidad;
            //    textBoxAerolinea.Text = Aerolinea;
            //    textBoxCantidad.Text = Cantidad;
            //    textBox1.Text = Costo;


            //    //vueloSeleccionado = int.Parse(id);
            //}
            //catch (Exception)
            //{
            //}

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idReserva = dataGridView1.Rows[e.RowIndex].Cells["idReserva"].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                string Origen = dataGridView1.Rows[e.RowIndex].Cells["Origen"].Value.ToString();
                string Destino = dataGridView1.Rows[e.RowIndex].Cells["Destino"].Value.ToString();
                string Costo = dataGridView1.Rows[e.RowIndex].Cells["Costo"].Value.ToString();
                string Fecha = dataGridView1.Rows[e.RowIndex].Cells["Fecha"].Value.ToString();
                string Aerolinea = dataGridView1.Rows[e.RowIndex].Cells["Aerolinea"].Value.ToString();
                string Cantidad = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();

                textBoxIdReserva.Text = idReserva;
                textBoxId.Text = id;
                textBoxOrigen.Text = Origen;
                textBoxDestino.Text = Destino;
                textBoxFecha.Text = Cantidad;
                textBoxAerolinea.Text = Aerolinea;
                textBoxCantidad.Text = Cantidad;
                textBox1.Text = Costo;


                vueloSeleccionado = int.Parse(id);
            }
            catch (Exception)
            {
            }

        }

        ////CONTROLAR LA CONEXIÓN CON LA BASE CUANDO FUNCIONE AGREGAR USUARIO
        private void Modificar_Click(object sender, EventArgs e)
        {
            if (vueloSeleccionado != -1)
            {
                try
                {
                    int nuevaCantidad = int.Parse(textBoxCantidad.Text);
                    double nuevoCosto = agencia.CalcularNuevoCosto(vueloSeleccionado, nuevaCantidad);
                    //string resultado = (agencia.modificarReservaVuelo(vueloSeleccionado, nuevaCantidad, nuevoCosto));
                    //switch (resultado)
                    //{
                    //    case "exito":
                    //        MessageBox.Show("Vuelo modificado exitosamente");
                    //        break;
                    //    case "capacidad":
                    //        MessageBox.Show("La capacidad es menor a la cantidad de personas que reservaron el vuelo");
                    //        break;
                    //    case "error":
                    //        MessageBox.Show("Ocurrió un problema al querer modificar el vuelo");
                    //        break;
                    //}
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error ");
                }
            }
            else
                MessageBox.Show("Debe seleccionar un vuelo");
        }
    }
}
