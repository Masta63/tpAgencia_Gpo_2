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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static tpAgencia_Gpo_2.BuscadorVuelos;

namespace tpAgencia_Gpo_2
{
    public partial class FormReservasVuelos : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        private int reservaSeleccionad;
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
            reservaSeleccionad = -1;
        }
        private void MostrarVuelos()
        {
            dataGridView1.Rows.Clear();

            if (usuarioActual != null)
            {
                
                List<ReservaVuelo> misReservasVuelo = agencia.getUsuarioActual().listMisReservasVuelo;

               
                int cantidadReservas = misReservasVuelo.Count;



                foreach (var vuelos in misReservasVuelo)
                {

                    dataGridView1.Rows.Add(
                        vuelos.idReservaVuelo,
                        vuelos.miVuelo.id,
                        vuelos.miVuelo.origen.nombre,
                        vuelos.miVuelo.destino.nombre,
                      vuelos.pagado,
                        vuelos.miVuelo.fecha.ToString("dd/MM/yyyy"),
                        vuelos.miVuelo.aerolinea,
                        vuelos.miVuelo.avion);


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


                textBoxIdReserva.Text = idReserva;
                textBoxId.Text = id;
                textBoxOrigen.Text = Origen;
                textBoxDestino.Text = Destino;
                textBoxFecha.Text = Fecha;
                textBoxAerolinea.Text = Aerolinea;

                textBox1.Text = Costo;


                vueloSeleccionado = int.Parse(id);
                reservaSeleccionad = int.Parse(idReserva);
            }
            catch (Exception)
            {
            }

        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (vueloSeleccionado != -1)
            {
                try
                {
                    int nuevaCantidad = int.Parse(textBoxCantidad.Text);
                    double nuevoCosto = agencia.CalcularNuevoCosto(vueloSeleccionado, nuevaCantidad);
                    string resultado = (agencia.modificarReservaVuelo(vueloSeleccionado, reservaSeleccionad, nuevaCantidad, nuevoCosto));
                    MostrarVuelos();
                    switch (resultado)
                    {
                        case "reservaModificada":
                            MessageBox.Show("Vuelo modificado exitosamente");
                            MostrarVuelos();
                            dataGridView1.Invalidate();
                            dataGridView1.Update();
                            break;
                        case "capacidad":
                            MessageBox.Show("No hay más lugar disponible para este vuelo");
                            break;
                        case "credito":
                            MessageBox.Show("No tenes suficiente credito para comprar");
                            break;
                        case "fecha":
                            MessageBox.Show("No podes modificar esta reserva porque ya fue usada");
                            break;
                        case "error":
                            MessageBox.Show("Ocurrió un problema al querer modificar el vuelo");
                            break;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error ");
                }
            }
            else
                MessageBox.Show("Debe seleccionar un vuelo");
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (textBoxIdReserva.Text != string.Empty)
            {
               
                  string resultado =  agencia.eliminarReservaVuelo(Convert.ToInt32(textBoxIdReserva.Text));
                    MostrarVuelos();
                    textBoxId.Text = "";
                    textBoxOrigen.Text = "";
                    textBoxDestino.Text = "";
                    textBoxFecha.Text = "";
                    textBoxAerolinea.Text = "";
                switch (resultado)
                {
                    case "ReservaEliminada":
                    case "ok": 
                        MessageBox.Show("Reserva eliminada exitosamente");
                        break;
                    case "Fecha":
                        MessageBox.Show("No puede eliminar la reserva porque la misma ya pasó");
                        break;
                    case "error":
                        MessageBox.Show("Ocurrió un error");
                        break;
                }
               
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vuelo");
            }
           
        }
    }
}
