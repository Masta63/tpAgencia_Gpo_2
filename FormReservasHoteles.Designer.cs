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
            CostoHotel = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            fechaDesde = new DataGridViewTextBoxColumn();
            fechaHasta = new DataGridViewTextBoxColumn();
            idHotel = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Volver_desde_usuario = new Button();
            textBox_id = new TextBox();
            label_id = new Label();
            label4 = new Label();
            textCosto = new TextBox();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            dateTimePickerFechaDesde = new DateTimePicker();
            dateTimePickerFechaHasta = new DateTimePicker();
            button2 = new Button();
            textBoxidHotel = new TextBox();
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idReservaHotel, Ubicacion, CostoHotel, Nombre, Capacidad, fechaDesde, fechaHasta, idHotel, Costo });
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
            // CostoHotel
            // 
            CostoHotel.HeaderText = "MontoPagado";
            CostoHotel.Name = "CostoHotel";
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
            // idHotel
            // 
            idHotel.HeaderText = "idHotel";
            idHotel.Name = "idHotel";
            idHotel.Visible = false;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.MinimumWidth = 8;
            Costo.Name = "Costo";
            Costo.Width = 150;
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
            textBox_id.Location = new Point(944, 166);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(161, 23);
            textBox_id.TabIndex = 28;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(920, 174);
            label_id.Name = "label_id";
            label_id.Size = new Size(18, 15);
            label_id.TabIndex = 29;
            label_id.Text = "ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(900, 223);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 32;
            label4.Text = "Costo";
            // 
            // textCosto
            // 
            textCosto.Enabled = false;
            textCosto.Location = new Point(944, 215);
            textCosto.Name = "textCosto";
            textCosto.Size = new Size(161, 23);
            textCosto.TabIndex = 33;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(833, 275);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 40;
            label7.Text = "Fecha desde";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(836, 324);
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
            dateTimePickerFechaDesde.Enabled = false;
            dateTimePickerFechaDesde.Location = new Point(920, 267);
            dateTimePickerFechaDesde.Name = "dateTimePickerFechaDesde";
            dateTimePickerFechaDesde.Size = new Size(200, 23);
            dateTimePickerFechaDesde.TabIndex = 43;
            dateTimePickerFechaDesde.ValueChanged += dateTimePickerFechaDesde_ValueChanged;
            // 
            // dateTimePickerFechaHasta
            // 
            dateTimePickerFechaHasta.Enabled = false;
            dateTimePickerFechaHasta.Location = new Point(920, 316);
            dateTimePickerFechaHasta.Name = "dateTimePickerFechaHasta";
            dateTimePickerFechaHasta.Size = new Size(200, 23);
            dateTimePickerFechaHasta.TabIndex = 44;
            dateTimePickerFechaHasta.ValueChanged += dateTimePickerFechaHasta_ValueChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 255, 255);
            button2.Enabled = false;
            button2.Location = new Point(628, 148);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 45;
            button2.Text = "editar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBoxidHotel
            // 
            textBoxidHotel.Enabled = false;
            textBoxidHotel.Location = new Point(944, 123);
            textBoxidHotel.Name = "textBoxidHotel";
            textBoxidHotel.Size = new Size(161, 23);
            textBoxidHotel.TabIndex = 46;
            textBoxidHotel.Visible = false;
            // 
            // FormReservasHoteles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 490);
            Controls.Add(textBoxidHotel);
            Controls.Add(button2);
            Controls.Add(dateTimePickerFechaHasta);
            Controls.Add(dateTimePickerFechaDesde);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textCosto);
            Controls.Add(label4);
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
        private TextBox textBox_id;
        private Label label_id;
        private Label label4;
        private TextBox textCosto;
        private Label label7;
        private Label label8;
        private Button button1;
        private DateTimePicker dateTimePickerFechaDesde;
        private DateTimePicker dateTimePickerFechaHasta;
        private Button button2;
        private TextBox textBoxidHotel;
        private DataGridViewTextBoxColumn idReservaHotel;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn CostoHotel;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridViewTextBoxColumn fechaDesde;
        private DataGridViewTextBoxColumn fechaHasta;
        private DataGridViewTextBoxColumn idHotel;
        private DataGridViewTextBoxColumn Costo;
    }
}