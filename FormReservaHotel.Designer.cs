namespace tpAgencia_Gpo_2
{
    partial class FormReservaHotel
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
            tituloreporte = new Label();
            buttonComprar = new Button();
            boxHoteles = new ComboBox();
            dataGridViewHotel = new DataGridView();
            nombre = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            capacidad = new DataGridViewTextBoxColumn();
            Fdesde = new DataGridViewTextBoxColumn();
            FHasta = new DataGridViewTextBoxColumn();
            Cantidad_personas = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            fechaDesde = new DateTimePicker();
            fechaHasta = new DateTimePicker();
            textBoxMonto = new TextBox();
            label5 = new Label();
            Volver_desde_usuario = new Button();
            label2 = new Label();
            cantPerstext = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHotel).BeginInit();
            SuspendLayout();
            // 
            // tituloreporte
            // 
            tituloreporte.AutoSize = true;
            tituloreporte.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            tituloreporte.Location = new Point(37, 43);
            tituloreporte.Margin = new Padding(4, 0, 4, 0);
            tituloreporte.Name = "tituloreporte";
            tituloreporte.Size = new Size(280, 51);
            tituloreporte.TabIndex = 37;
            tituloreporte.Text = "Reservar hotel";
            // 
            // buttonComprar
            // 
            buttonComprar.Location = new Point(54, 417);
            buttonComprar.Margin = new Padding(4, 5, 4, 5);
            buttonComprar.Name = "buttonComprar";
            buttonComprar.Size = new Size(173, 38);
            buttonComprar.TabIndex = 47;
            buttonComprar.Text = "Confirmar comprar";
            buttonComprar.UseVisualStyleBackColor = true;
            buttonComprar.Click += buttonComprar_Click;
            // 
            // boxHoteles
            // 
            boxHoteles.Enabled = false;
            boxHoteles.FormattingEnabled = true;
            boxHoteles.Location = new Point(100, 187);
            boxHoteles.Margin = new Padding(4, 5, 4, 5);
            boxHoteles.Name = "boxHoteles";
            boxHoteles.Size = new Size(171, 33);
            boxHoteles.TabIndex = 45;
            boxHoteles.SelectedIndexChanged += boxHoteles_SelectedIndexChanged;
            // 
            // dataGridViewHotel
            // 
            dataGridViewHotel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHotel.Columns.AddRange(new DataGridViewColumn[] { nombre, Monto, capacidad, Fdesde, FHasta, Cantidad_personas });
            dataGridViewHotel.Location = new Point(37, 465);
            dataGridViewHotel.Margin = new Padding(4, 5, 4, 5);
            dataGridViewHotel.Name = "dataGridViewHotel";
            dataGridViewHotel.RowHeadersWidth = 62;
            dataGridViewHotel.RowTemplate.Height = 25;
            dataGridViewHotel.Size = new Size(1001, 250);
            dataGridViewHotel.TabIndex = 44;
            dataGridViewHotel.CellContentClick += dataGridViewHotel_CellContentClick;
            // 
            // nombre
            // 
            nombre.HeaderText = "nombre";
            nombre.MinimumWidth = 8;
            nombre.Name = "nombre";
            nombre.Width = 150;
            // 
            // Monto
            // 
            Monto.HeaderText = "Monto";
            Monto.MinimumWidth = 8;
            Monto.Name = "Monto";
            Monto.Width = 150;
            // 
            // capacidad
            // 
            capacidad.HeaderText = "capacidad";
            capacidad.MinimumWidth = 8;
            capacidad.Name = "capacidad";
            capacidad.Width = 150;
            // 
            // Fdesde
            // 
            Fdesde.HeaderText = "FechaDesde";
            Fdesde.MinimumWidth = 8;
            Fdesde.Name = "Fdesde";
            Fdesde.Width = 150;
            // 
            // FHasta
            // 
            FHasta.HeaderText = "FechaHasta";
            FHasta.MinimumWidth = 8;
            FHasta.Name = "FHasta";
            FHasta.Width = 150;
            // 
            // Cantidad_personas
            // 
            Cantidad_personas.HeaderText = "cantidadPersonas";
            Cantidad_personas.MinimumWidth = 8;
            Cantidad_personas.Name = "Cantidad_personas";
            Cantidad_personas.Width = 150;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(486, 257);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 43;
            label4.Text = "Fecha hasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 257);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 42;
            label3.Text = "Fecha desde:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 128);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 40;
            label1.Text = "Indique Hotel";
            // 
            // fechaDesde
            // 
            fechaDesde.Enabled = false;
            fechaDesde.Location = new Point(100, 305);
            fechaDesde.Margin = new Padding(4, 5, 4, 5);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(284, 31);
            fechaDesde.TabIndex = 39;
            // 
            // fechaHasta
            // 
            fechaHasta.Enabled = false;
            fechaHasta.Location = new Point(486, 305);
            fechaHasta.Margin = new Padding(4, 5, 4, 5);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(284, 31);
            fechaHasta.TabIndex = 38;
            // 
            // textBoxMonto
            // 
            textBoxMonto.Location = new Point(410, 187);
            textBoxMonto.Margin = new Padding(4, 5, 4, 5);
            textBoxMonto.Name = "textBoxMonto";
            textBoxMonto.Size = new Size(141, 31);
            textBoxMonto.TabIndex = 48;
            textBoxMonto.TextChanged += textBoxMonto_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 128);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 49;
            label5.Text = "Monto";
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(37, 725);
            Volver_desde_usuario.Margin = new Padding(4, 5, 4, 5);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(107, 38);
            Volver_desde_usuario.TabIndex = 50;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(629, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(158, 25);
            label2.TabIndex = 52;
            label2.Text = "Cantidad Personas";
            // 
            // cantPerstext
            // 
            cantPerstext.Enabled = false;
            cantPerstext.Location = new Point(629, 187);
            cantPerstext.Margin = new Padding(4, 5, 4, 5);
            cantPerstext.Name = "cantPerstext";
            cantPerstext.Size = new Size(141, 31);
            cantPerstext.TabIndex = 51;
            // 
            // FormReservaHotel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 782);
            Controls.Add(label2);
            Controls.Add(cantPerstext);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(label5);
            Controls.Add(textBoxMonto);
            Controls.Add(buttonComprar);
            Controls.Add(boxHoteles);
            Controls.Add(dataGridViewHotel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(fechaDesde);
            Controls.Add(fechaHasta);
            Controls.Add(tituloreporte);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormReservaHotel";
            Text = "FormReservaHotelcs";
            Load += FormReservaHotel_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHotel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloreporte;
        private Label labelIdCompra;
        private Button buttonComprar;
        private ComboBox boxHoteles;
        private DataGridView dataGridViewHotel;
        private Label label4;
        private Label label3;
        private Label label1;
        private DateTimePicker fechaDesde;
        private DateTimePicker fechaHasta;
        private TextBox textBoxMonto;
        private Label label5;
        private Button Volver_desde_usuario;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn capacidad;
        private DataGridViewTextBoxColumn Fdesde;
        private DataGridViewTextBoxColumn FHasta;
        private DataGridViewTextBoxColumn Cantidad_personas;
        private Label label2;
        private TextBox cantPerstext;
    }
}