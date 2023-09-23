namespace tpAgencia_Gpo_2
{
    partial class BuscadorVuelos
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
            comboBoxCorigen = new ComboBox();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Origen = new DataGridViewTextBoxColumn();
            Destino = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Aerolinea = new DataGridViewTextBoxColumn();
            Avion = new DataGridViewTextBoxColumn();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            label5 = new Label();
            comboBoxCdestino = new ComboBox();
            numericUpDownPax = new NumericUpDown();
            Volver_desde_usuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPax).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(576, 9);
            label1.Name = "label1";
            label1.Size = new Size(570, 69);
            label1.TabIndex = 0;
            label1.Text = "Buscador de vuelos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 100);
            label2.Name = "label2";
            label2.Size = new Size(152, 25);
            label2.TabIndex = 1;
            label2.Text = "Ciudad de Origen";
            // 
            // comboBoxCorigen
            // 
            comboBoxCorigen.FormattingEnabled = true;
            comboBoxCorigen.Location = new Point(263, 92);
            comboBoxCorigen.Name = "comboBoxCorigen";
            comboBoxCorigen.Size = new Size(176, 33);
            comboBoxCorigen.TabIndex = 2;
            comboBoxCorigen.SelectedIndexChanged += comboBoxCorigen_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Origen, Destino, Cantidad, Costo, Fecha, Aerolinea, Avion });
            dataGridView1.Location = new Point(528, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1216, 246);
            dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 150;
            // 
            // Origen
            // 
            Origen.HeaderText = "Origen";
            Origen.MinimumWidth = 8;
            Origen.Name = "Origen";
            Origen.ReadOnly = true;
            Origen.Width = 150;
            // 
            // Destino
            // 
            Destino.HeaderText = "Destino";
            Destino.MinimumWidth = 8;
            Destino.Name = "Destino";
            Destino.ReadOnly = true;
            Destino.Width = 150;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Asientos disponibles";
            Cantidad.MinimumWidth = 8;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 250;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.MinimumWidth = 8;
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            Costo.Width = 150;
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 8;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 150;
            // 
            // Aerolinea
            // 
            Aerolinea.HeaderText = "Aerolinea";
            Aerolinea.MinimumWidth = 8;
            Aerolinea.Name = "Aerolinea";
            Aerolinea.ReadOnly = true;
            Aerolinea.Width = 150;
            // 
            // Avion
            // 
            Avion.HeaderText = "Avion";
            Avion.MinimumWidth = 8;
            Avion.Name = "Avion";
            Avion.ReadOnly = true;
            Avion.Width = 150;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 207);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 4;
            label3.Text = "Fecha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 260);
            label4.Name = "label4";
            label4.Size = new Size(188, 25);
            label4.TabIndex = 5;
            label4.Text = "Cantidad de pasajeros";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(263, 207);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(176, 31);
            dateTimePicker1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(263, 359);
            button1.Name = "button1";
            button1.Size = new Size(145, 40);
            button1.TabIndex = 8;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 155);
            label5.Name = "label5";
            label5.Size = new Size(159, 25);
            label5.TabIndex = 9;
            label5.Text = "Ciudad de Destino";
            // 
            // comboBoxCdestino
            // 
            comboBoxCdestino.FormattingEnabled = true;
            comboBoxCdestino.Location = new Point(263, 147);
            comboBoxCdestino.Name = "comboBoxCdestino";
            comboBoxCdestino.Size = new Size(175, 33);
            comboBoxCdestino.TabIndex = 10;
            // 
            // numericUpDownPax
            // 
            numericUpDownPax.Location = new Point(263, 260);
            numericUpDownPax.Name = "numericUpDownPax";
            numericUpDownPax.Size = new Size(175, 31);
            numericUpDownPax.TabIndex = 11;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(22, 361);
            Volver_desde_usuario.Margin = new Padding(4, 5, 4, 5);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(107, 38);
            Volver_desde_usuario.TabIndex = 26;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // BuscadorVuelos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1787, 450);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(numericUpDownPax);
            Controls.Add(comboBoxCdestino);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(comboBoxCorigen);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BuscadorVuelos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscadorVuelos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBoxCorigen;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Label label5;
        private ComboBox comboBoxCdestino;
        private NumericUpDown numericUpDownPax;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Origen;
        private DataGridViewTextBoxColumn Destino;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Aerolinea;
        private DataGridViewTextBoxColumn Avion;
        private Button Volver_desde_usuario;
    }
}