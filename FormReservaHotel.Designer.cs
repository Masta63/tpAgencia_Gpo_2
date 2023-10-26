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
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            fechaDesde = new DateTimePicker();
            fechaHasta = new DateTimePicker();
            textBoxMonto = new TextBox();
            label5 = new Label();
            Volver_desde_usuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHotel).BeginInit();
            SuspendLayout();
            // 
            // tituloreporte
            // 
            tituloreporte.AutoSize = true;
            tituloreporte.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            tituloreporte.Location = new Point(26, 26);
            tituloreporte.Name = "tituloreporte";
            tituloreporte.Size = new Size(189, 36);
            tituloreporte.TabIndex = 37;
            tituloreporte.Text = "Reservar hotel";
            // 
            // buttonComprar
            // 
            buttonComprar.Location = new Point(38, 250);
            buttonComprar.Name = "buttonComprar";
            buttonComprar.Size = new Size(121, 23);
            buttonComprar.TabIndex = 47;
            buttonComprar.Text = "Confirmar comprar";
            buttonComprar.UseVisualStyleBackColor = true;
            buttonComprar.Click += buttonComprar_Click;
            // 
            // boxHoteles
            // 
            boxHoteles.Enabled = false;
            boxHoteles.FormattingEnabled = true;
            boxHoteles.Location = new Point(70, 112);
            boxHoteles.Name = "boxHoteles";
            boxHoteles.Size = new Size(121, 23);
            boxHoteles.TabIndex = 45;
            // 
            // dataGridViewHotel
            // 
            dataGridViewHotel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHotel.Columns.AddRange(new DataGridViewColumn[] { nombre, Monto, capacidad, Fdesde, FHasta });
            dataGridViewHotel.Location = new Point(26, 279);
            dataGridViewHotel.Name = "dataGridViewHotel";
            dataGridViewHotel.RowTemplate.Height = 25;
            dataGridViewHotel.Size = new Size(701, 150);
            dataGridViewHotel.TabIndex = 44;
            dataGridViewHotel.CellContentClick += dataGridViewHotel_CellContentClick;
            // 
            // nombre
            // 
            nombre.HeaderText = "nombre";
            nombre.Name = "nombre";
            // 
            // Monto
            // 
            Monto.HeaderText = "Monto";
            Monto.Name = "Monto";
            // 
            // capacidad
            // 
            capacidad.HeaderText = "capacidad";
            capacidad.Name = "capacidad";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(340, 154);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 43;
            label4.Text = "Fecha hasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 154);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 42;
            label3.Text = "Fecha desde:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 77);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 40;
            label1.Text = "Indique Hotel";
            // 
            // fechaDesde
            // 
            fechaDesde.Enabled = false;
            fechaDesde.Location = new Point(70, 183);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(200, 23);
            fechaDesde.TabIndex = 39;
            // 
            // fechaHasta
            // 
            fechaHasta.Enabled = false;
            fechaHasta.Location = new Point(340, 183);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(200, 23);
            fechaHasta.TabIndex = 38;
            // 
            // textBoxMonto
            // 
            textBoxMonto.Location = new Point(287, 112);
            textBoxMonto.Name = "textBoxMonto";
            textBoxMonto.Size = new Size(100, 23);
            textBoxMonto.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(287, 77);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 49;
            label5.Text = "Monto";
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(26, 435);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 50;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // FormReservaHotel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 469);
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
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn capacidad;
        private DataGridViewTextBoxColumn Fdesde;
        private DataGridViewTextBoxColumn FHasta;
        private Button Volver_desde_usuario;
    }
}