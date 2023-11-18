namespace tpAgencia_Gpo_2
{
    partial class FormReporteHoteles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fechaHasta = new DateTimePicker();
            fechaDesde = new DateTimePicker();
            label1 = new Label();
            botonBuscar = new Button();
            label3 = new Label();
            label4 = new Label();
            dataGridViewHotel = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            ubicacion = new DataGridViewTextBoxColumn();
            capacidad = new DataGridViewTextBoxColumn();
            costo = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            Fdesde = new DataGridViewTextBoxColumn();
            FHasta = new DataGridViewTextBoxColumn();
            boxCiudades = new ComboBox();
            buttonComprar = new Button();
            Volver_desde_usuario = new Button();
            tituloreporte = new Label();
            labelTituloComprar = new Label();
            labelIdComprar = new Label();
            labelNombreHotel = new Label();
            TextMonto = new TextBox();
            label5 = new Label();
            cantPerstext = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHotel).BeginInit();
            SuspendLayout();
            // 
            // fechaHasta
            // 
            fechaHasta.Location = new Point(314, 177);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(200, 23);
            fechaHasta.TabIndex = 0;
            // 
            // fechaDesde
            // 
            fechaDesde.Location = new Point(44, 177);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(200, 23);
            fechaDesde.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 71);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 3;
            label1.Text = "Indique la ciudad";
            label1.Click += label1_Click;
            // 
            // botonBuscar
            // 
            botonBuscar.Location = new Point(707, 273);
            botonBuscar.Name = "botonBuscar";
            botonBuscar.Size = new Size(75, 23);
            botonBuscar.TabIndex = 5;
            botonBuscar.Text = "Buscar";
            botonBuscar.UseVisualStyleBackColor = true;
            botonBuscar.Click += botonBuscar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 148);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 7;
            label3.Text = "Fecha desde:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(314, 148);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha hasta:";
            // 
            // dataGridViewHotel
            // 
            dataGridViewHotel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHotel.Columns.AddRange(new DataGridViewColumn[] { id, ubicacion, capacidad, costo, nombre, Fdesde, FHasta });
            dataGridViewHotel.Location = new Point(0, 273);
            dataGridViewHotel.Name = "dataGridViewHotel";
            dataGridViewHotel.RowTemplate.Height = 25;
            dataGridViewHotel.Size = new Size(701, 150);
            dataGridViewHotel.TabIndex = 9;
            dataGridViewHotel.CellContentClick += dataGridView1_CellContentClick;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.Name = "id";
            // 
            // ubicacion
            // 
            ubicacion.HeaderText = "ubicacion";
            ubicacion.Name = "ubicacion";
            // 
            // capacidad
            // 
            capacidad.HeaderText = "disponibilidad";
            capacidad.Name = "capacidad";
            // 
            // costo
            // 
            costo.HeaderText = "costo";
            costo.Name = "costo";
            // 
            // nombre
            // 
            nombre.HeaderText = "nombre";
            nombre.Name = "nombre";
            // 
            // Fdesde
            // 
            Fdesde.HeaderText = "FechaDesde";
            Fdesde.Name = "Fdesde";
            // 
            // FHasta
            // 
            FHasta.HeaderText = "FechaHasta";
            FHasta.Name = "FHasta";
            // 
            // boxCiudades
            // 
            boxCiudades.FormattingEnabled = true;
            boxCiudades.Location = new Point(44, 106);
            boxCiudades.Name = "boxCiudades";
            boxCiudades.Size = new Size(121, 23);
            boxCiudades.TabIndex = 10;
            boxCiudades.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // buttonComprar
            // 
            buttonComprar.Location = new Point(12, 245);
            buttonComprar.Name = "buttonComprar";
            buttonComprar.Size = new Size(119, 23);
            buttonComprar.TabIndex = 12;
            buttonComprar.Text = "Ir a Comprar";
            buttonComprar.UseVisualStyleBackColor = true;
            buttonComprar.Click += buttonComprar_Click;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(12, 436);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 13;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // tituloreporte
            // 
            tituloreporte.AutoSize = true;
            tituloreporte.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            tituloreporte.Location = new Point(12, 9);
            tituloreporte.Name = "tituloreporte";
            tituloreporte.Size = new Size(190, 36);
            tituloreporte.TabIndex = 34;
            tituloreporte.Text = "Reservas hotel";
            // 
            // labelTituloComprar
            // 
            labelTituloComprar.AutoSize = true;
            labelTituloComprar.Location = new Point(214, 253);
            labelTituloComprar.Name = "labelTituloComprar";
            labelTituloComprar.Size = new Size(125, 15);
            labelTituloComprar.TabIndex = 35;
            labelTituloComprar.Text = "Comprar por n° Hotel:";
            // 
            // labelIdComprar
            // 
            labelIdComprar.AutoSize = true;
            labelIdComprar.Location = new Point(340, 254);
            labelIdComprar.Name = "labelIdComprar";
            labelIdComprar.Size = new Size(0, 15);
            labelIdComprar.TabIndex = 36;
            // 
            // labelNombreHotel
            // 
            labelNombreHotel.AutoSize = true;
            labelNombreHotel.Location = new Point(377, 254);
            labelNombreHotel.Name = "labelNombreHotel";
            labelNombreHotel.Size = new Size(0, 15);
            labelNombreHotel.TabIndex = 37;
            // 
            // TextMonto
            // 
            TextMonto.Location = new Point(601, 245);
            TextMonto.Name = "TextMonto";
            TextMonto.Size = new Size(100, 23);
            TextMonto.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(552, 248);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 39;
            label5.Text = "Monto";
            // 
            // cantPerstext
            // 
            cantPerstext.Location = new Point(314, 106);
            cantPerstext.Name = "cantPerstext";
            cantPerstext.Size = new Size(100, 23);
            cantPerstext.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 71);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 41;
            label2.Text = "Cantidad Personas";
            // 
            // FormReporteHoteles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 471);
            Controls.Add(label2);
            Controls.Add(cantPerstext);
            Controls.Add(label5);
            Controls.Add(TextMonto);
            Controls.Add(labelNombreHotel);
            Controls.Add(labelIdComprar);
            Controls.Add(labelTituloComprar);
            Controls.Add(tituloreporte);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(buttonComprar);
            Controls.Add(boxCiudades);
            Controls.Add(dataGridViewHotel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(botonBuscar);
            Controls.Add(label1);
            Controls.Add(fechaDesde);
            Controls.Add(fechaHasta);
            Name = "FormReporteHoteles";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHotel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker fechaHasta;
        private DateTimePicker fechaDesde;
        private Label label1;
        private Button botonBuscar;
        private Label label3;
        private Label label4;
        private DataGridView dataGridViewHotel;
        private ComboBox boxCiudades;
        private Button buttonComprar;
        private Button Volver_desde_usuario;
        private Label tituloreporte;
        private Label labelTituloComprar;
        private Label labelIdComprar;
        private Label labelNombreHotel;
        private TextBox TextMonto;
        private Label label5;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn ubicacion;
        private DataGridViewTextBoxColumn capacidad;
        private DataGridViewTextBoxColumn costo;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn Fdesde;
        private DataGridViewTextBoxColumn FHasta;
        private TextBox cantPerstext;
        private Label label2;
    }
}