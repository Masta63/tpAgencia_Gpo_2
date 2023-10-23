namespace tpAgencia_Gpo_2
{
    partial class FormReservasHoteles
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
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            idReservaHotel = new DataGridViewTextBoxColumn();
            Ubicacion = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            fechaDesde = new DataGridViewTextBoxColumn();
            fechaHasta = new DataGridViewTextBoxColumn();
            Volver_desde_usuario = new Button();
            textBox_id = new TextBox();
            label_id = new Label();
            label3 = new Label();
            textUbicacion = new TextBox();
            label4 = new Label();
            textCosto = new TextBox();
            label5 = new Label();
            textBoxName = new TextBox();
            label6 = new Label();
            textBoxCapacidad = new TextBox();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            dateTimePickerFechaDesde = new DateTimePicker();
            dateTimePickerFechaHasta = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(346, 19);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(503, 46);
            label1.TabIndex = 0;
            label1.Text = "Mis reservas de hoteles";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 150);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 13);
            label2.TabIndex = 1;
            label2.Text = "Mis reservas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idReservaHotel, Ubicacion, Costo, Nombre, Capacidad, fechaDesde, fechaHasta });
            dataGridView1.Location = new Point(11, 176);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(786, 175);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idReservaHotel
            // 
            idReservaHotel.HeaderText = "id";
            idReservaHotel.Name = "idReservaHotel";
            // 
            // Ubicacion
            // 
            Ubicacion.HeaderText = "Ubicacion";
            Ubicacion.MinimumWidth = 8;
            Ubicacion.Name = "Ubicacion";
            Ubicacion.Width = 150;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.MinimumWidth = 8;
            Costo.Name = "Costo";
            Costo.Width = 150;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 8;
            Nombre.Name = "Nombre";
            Nombre.Width = 150;
            // 
            // Capacidad
            // 
            Capacidad.HeaderText = "Capacidad";
            Capacidad.MinimumWidth = 8;
            Capacidad.Name = "Capacidad";
            Capacidad.Width = 150;
            // 
            // fechaDesde
            // 
            fechaDesde.HeaderText = "fechaDesde";
            fechaDesde.Name = "fechaDesde";
            // 
            // fechaHasta
            // 
            fechaHasta.HeaderText = "fechaHasta";
            fechaHasta.Name = "fechaHasta";
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(12, 357);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 27;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // textBox_id
            // 
            textBox_id.Enabled = false;
            textBox_id.Location = new Point(892, 121);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(161, 23);
            textBox_id.TabIndex = 28;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(868, 129);
            label_id.Name = "label_id";
            label_id.Size = new Size(18, 15);
            label_id.TabIndex = 29;
            label_id.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(826, 176);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 30;
            label3.Text = "Ubicacion";
            // 
            // textUbicacion
            // 
            textUbicacion.Location = new Point(892, 168);
            textUbicacion.Name = "textUbicacion";
            textUbicacion.Size = new Size(161, 23);
            textUbicacion.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(848, 223);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 32;
            label4.Text = "Costo";
            // 
            // textCosto
            // 
            textCosto.Location = new Point(892, 215);
            textCosto.Name = "textCosto";
            textCosto.Size = new Size(161, 23);
            textCosto.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(835, 270);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 34;
            label5.Text = "Nombre";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(892, 262);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(161, 23);
            textBoxName.TabIndex = 35;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(823, 318);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 36;
            label6.Text = "Capacidad";
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(892, 310);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(161, 23);
            textBoxCapacidad.TabIndex = 37;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(793, 366);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 40;
            label7.Text = "Fecha desde";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(793, 419);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 41;
            label8.Text = "Fecha hasta";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 255);
            button1.Enabled = false;
            button1.Location = new Point(722, 148);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 42;
            button1.Text = "eliminar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dateTimePickerFechaDesde
            // 
            dateTimePickerFechaDesde.Location = new Point(871, 360);
            dateTimePickerFechaDesde.Name = "dateTimePickerFechaDesde";
            dateTimePickerFechaDesde.Size = new Size(200, 23);
            dateTimePickerFechaDesde.TabIndex = 43;
            // 
            // dateTimePickerFechaHasta
            // 
            dateTimePickerFechaHasta.Location = new Point(871, 411);
            dateTimePickerFechaHasta.Name = "dateTimePickerFechaHasta";
            dateTimePickerFechaHasta.Size = new Size(200, 23);
            dateTimePickerFechaHasta.TabIndex = 44;
            // 
            // FormReservasHoteles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 490);
            Controls.Add(dateTimePickerFechaHasta);
            Controls.Add(dateTimePickerFechaDesde);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxCapacidad);
            Controls.Add(label6);
            Controls.Add(textBoxName);
            Controls.Add(label5);
            Controls.Add(textCosto);
            Controls.Add(label4);
            Controls.Add(textUbicacion);
            Controls.Add(label3);
            Controls.Add(label_id);
            Controls.Add(textBox_id);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "FormReservasHoteles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormReservasHoteles";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button Volver_desde_usuario;
        private DataGridViewTextBoxColumn idReservaHotel;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridViewTextBoxColumn fechaDesde;
        private DataGridViewTextBoxColumn fechaHasta;
        private TextBox textBox_id;
        private Label label_id;
        private Label label3;
        private TextBox textUbicacion;
        private Label label4;
        private TextBox textCosto;
        private Label label5;
        private TextBox textBoxName;
        private Label label6;
        private TextBox textBoxCapacidad;
        private Label label7;
        private Label label8;
        private Button button1;
        private DateTimePicker dateTimePickerFechaDesde;
        private DateTimePicker dateTimePickerFechaHasta;
    }
}