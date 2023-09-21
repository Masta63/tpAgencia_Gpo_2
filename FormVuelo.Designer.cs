namespace tpAgencia_Gpo_2
{
    partial class FormVuelo
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            Origen = new DataGridViewTextBoxColumn();
            Destino = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Aerolinea = new DataGridViewTextBoxColumn();
            Avion = new DataGridViewTextBoxColumn();
            button4 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox8 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            Volver_desde_usuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(600, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 46);
            label1.TabIndex = 0;
            label1.Text = "Vuelos";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 192);
            button1.Location = new Point(1003, 392);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(94, 28);
            button1.TabIndex = 1;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.Location = new Point(1233, 392);
            button2.Margin = new Padding(2, 2, 2, 2);
            button2.Name = "button2";
            button2.Size = new Size(94, 28);
            button2.TabIndex = 2;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 255, 192);
            button3.Location = new Point(1121, 392);
            button3.Margin = new Padding(2, 2, 2, 2);
            button3.Name = "button3";
            button3.Size = new Size(94, 28);
            button3.TabIndex = 3;
            button3.Text = "Modificar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, Origen, Destino, Capacidad, Costo, Fecha, Aerolinea, Avion });
            dataGridView1.Location = new Point(18, 138);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(846, 135);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellContentClick;
            // 
            // id
            // 
            id.Frozen = true;
            id.HeaderText = "id";
            id.MinimumWidth = 8;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 150;
            // 
            // Origen
            // 
            Origen.Frozen = true;
            Origen.HeaderText = "Origen";
            Origen.MinimumWidth = 8;
            Origen.Name = "Origen";
            Origen.ReadOnly = true;
            Origen.Width = 150;
            // 
            // Destino
            // 
            Destino.Frozen = true;
            Destino.HeaderText = "Destino";
            Destino.MinimumWidth = 8;
            Destino.Name = "Destino";
            Destino.ReadOnly = true;
            Destino.Width = 150;
            // 
            // Capacidad
            // 
            Capacidad.Frozen = true;
            Capacidad.HeaderText = "Capacidad";
            Capacidad.MinimumWidth = 8;
            Capacidad.Name = "Capacidad";
            Capacidad.ReadOnly = true;
            Capacidad.Width = 150;
            // 
            // Costo
            // 
            Costo.Frozen = true;
            Costo.HeaderText = "Costo";
            Costo.MinimumWidth = 8;
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            Costo.Width = 150;
            // 
            // Fecha
            // 
            Fecha.Frozen = true;
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 8;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 250;
            // 
            // Aerolinea
            // 
            Aerolinea.Frozen = true;
            Aerolinea.HeaderText = "Aerolinea";
            Aerolinea.MinimumWidth = 8;
            Aerolinea.Name = "Aerolinea";
            Aerolinea.ReadOnly = true;
            Aerolinea.Width = 150;
            // 
            // Avion
            // 
            Avion.Frozen = true;
            Avion.HeaderText = "Avion";
            Avion.MinimumWidth = 8;
            Avion.Name = "Avion";
            Avion.ReadOnly = true;
            Avion.Width = 150;
            // 
            // button4
            // 
            button4.Location = new Point(18, 73);
            button4.Margin = new Padding(2, 2, 2, 2);
            button4.Name = "button4";
            button4.Size = new Size(197, 45);
            button4.TabIndex = 5;
            button4.Text = "Mostrar / Actualizar Vuelos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1082, 185);
            textBox3.Margin = new Padding(2, 2, 2, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(227, 23);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1082, 226);
            textBox4.Margin = new Padding(2, 2, 2, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(227, 23);
            textBox4.TabIndex = 9;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1082, 302);
            textBox6.Margin = new Padding(2, 2, 2, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(227, 23);
            textBox6.TabIndex = 11;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(1082, 334);
            textBox7.Margin = new Padding(2, 2, 2, 2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(227, 23);
            textBox7.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1017, 110);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 13;
            label2.Text = "Origen";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1012, 146);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 14;
            label3.Text = "Destino";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(997, 188);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 15;
            label4.Text = "Capacidad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1022, 229);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 16;
            label5.Text = "Costo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1023, 268);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 17;
            label6.Text = "Fecha";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1003, 302);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 18;
            label7.Text = "Aerolinea";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1023, 336);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 19;
            label8.Text = "Avion";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1044, 77);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 21;
            label9.Text = "Id";
            // 
            // textBox8
            // 
            textBox8.Cursor = Cursors.No;
            textBox8.Location = new Point(1082, 73);
            textBox8.Margin = new Padding(2, 2, 2, 2);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new Size(227, 23);
            textBox8.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(1082, 265);
            dateTimePicker1.Margin = new Padding(2, 2, 2, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(227, 23);
            dateTimePicker1.TabIndex = 22;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1082, 108);
            comboBox1.Margin = new Padding(2, 2, 2, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(227, 23);
            comboBox1.TabIndex = 23;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1082, 145);
            comboBox2.Margin = new Padding(2, 2, 2, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(227, 23);
            comboBox2.TabIndex = 24;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(18, 301);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 25;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // FormVuelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 449);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label9);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormVuelo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormVuelo";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private Button button4;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox8;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Origen;
        private DataGridViewTextBoxColumn Destino;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Aerolinea;
        private DataGridViewTextBoxColumn Avion;
        private Button Volver_desde_usuario;
    }
}