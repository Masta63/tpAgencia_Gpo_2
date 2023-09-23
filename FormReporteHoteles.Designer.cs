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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridViewHotel = new DataGridView();
            boxCiudades = new ComboBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHotel).BeginInit();
            SuspendLayout();
            // 
            // fechaHasta
            // 
            fechaHasta.Location = new Point(442, 136);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(200, 23);
            fechaHasta.TabIndex = 0;
            // 
            // fechaDesde
            // 
            fechaDesde.Location = new Point(44, 136);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(200, 23);
            fechaDesde.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 21);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 3;
            label1.Text = "Indique la ciudad";
            label1.Click += label1_Click;
            // 
            // botonBuscar
            // 
            botonBuscar.Location = new Point(314, 194);
            botonBuscar.Name = "botonBuscar";
            botonBuscar.Size = new Size(75, 23);
            botonBuscar.TabIndex = 5;
            botonBuscar.Text = "Buscar";
            botonBuscar.UseVisualStyleBackColor = true;
            botonBuscar.Click += botonBuscar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(471, 21);
            label2.Name = "label2";
            label2.Size = new Size(183, 15);
            label2.TabIndex = 6;
            label2.Text = "Indique la cantidad de huespedes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 107);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 7;
            label3.Text = "Fecha desde:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(503, 107);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha hasta:";
            // 
            // dataGridViewHotel
            // 
            dataGridViewHotel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHotel.Location = new Point(0, 232);
            dataGridViewHotel.Name = "dataGridViewHotel";
            dataGridViewHotel.RowTemplate.Height = 25;
            dataGridViewHotel.Size = new Size(701, 150);
            dataGridViewHotel.TabIndex = 9;
            dataGridViewHotel.CellContentClick += dataGridView1_CellContentClick;
            // 
            // boxCiudades
            // 
            boxCiudades.FormattingEnabled = true;
            boxCiudades.Location = new Point(44, 40);
            boxCiudades.Name = "boxCiudades";
            boxCiudades.Size = new Size(121, 23);
            boxCiudades.TabIndex = 10;
            boxCiudades.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(503, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 11;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 383);
            Controls.Add(textBox1);
            Controls.Add(boxCiudades);
            Controls.Add(dataGridViewHotel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(botonBuscar);
            Controls.Add(label1);
            Controls.Add(fechaDesde);
            Controls.Add(fechaHasta);
            Name = "Form2";
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
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridViewHotel;
        private ComboBox boxCiudades;
        private TextBox textBox1;
    }
}