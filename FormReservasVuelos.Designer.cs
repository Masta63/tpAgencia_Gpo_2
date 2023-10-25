namespace tpAgencia_Gpo_2
{
    partial class FormReservasVuelos
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
            idReserva = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            Origen = new DataGridViewTextBoxColumn();
            Destino = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Aerolinea = new DataGridViewTextBoxColumn();
            Avion = new DataGridViewTextBoxColumn();
            Volver_desde_usuario = new Button();
            Modificar = new Button();
            Eliminar = new Button();
            textBoxId = new TextBox();
            textBoxOrigen = new TextBox();
            textBoxDestino = new TextBox();
            textBoxFecha = new TextBox();
            textBoxAerolinea = new TextBox();
            textBoxCantidad = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            textBoxIdReserva = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(494, 32);
            label1.Name = "label1";
            label1.Size = new Size(660, 69);
            label1.TabIndex = 0;
            label1.Text = "Mis reservas de vuelo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(73, 140);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 1;
            label2.Text = "Mis reservas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idReserva, id, Origen, Destino, Costo, Fecha, Aerolinea, Avion });
            dataGridView1.Location = new Point(75, 199);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(979, 291);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // idReserva
            // 
            idReserva.HeaderText = "idReserva";
            idReserva.MinimumWidth = 8;
            idReserva.Name = "idReserva";
            idReserva.Visible = false;
            idReserva.Width = 150;
            // 
            // id
            // 
            id.HeaderText = "Id";
            id.MinimumWidth = 8;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 150;
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
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(75, 537);
            Volver_desde_usuario.Margin = new Padding(4, 5, 4, 5);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(107, 38);
            Volver_desde_usuario.TabIndex = 27;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // Modificar
            // 
            Modificar.Location = new Point(1217, 620);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(116, 46);
            Modificar.TabIndex = 28;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Modificar_Click;
            // 
            // Eliminar
            // 
            Eliminar.Location = new Point(1339, 620);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(111, 46);
            Eliminar.TabIndex = 29;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(1309, 205);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(106, 31);
            textBoxId.TabIndex = 30;
            // 
            // textBoxOrigen
            // 
            textBoxOrigen.Location = new Point(1309, 263);
            textBoxOrigen.Name = "textBoxOrigen";
            textBoxOrigen.ReadOnly = true;
            textBoxOrigen.Size = new Size(155, 31);
            textBoxOrigen.TabIndex = 31;
            // 
            // textBoxDestino
            // 
            textBoxDestino.Location = new Point(1309, 319);
            textBoxDestino.Name = "textBoxDestino";
            textBoxDestino.ReadOnly = true;
            textBoxDestino.Size = new Size(155, 31);
            textBoxDestino.TabIndex = 32;
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(1309, 381);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.ReadOnly = true;
            textBoxFecha.Size = new Size(141, 31);
            textBoxFecha.TabIndex = 33;
            // 
            // textBoxAerolinea
            // 
            textBoxAerolinea.Location = new Point(1309, 440);
            textBoxAerolinea.Name = "textBoxAerolinea";
            textBoxAerolinea.ReadOnly = true;
            textBoxAerolinea.Size = new Size(141, 31);
            textBoxAerolinea.TabIndex = 34;
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(1309, 564);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(106, 31);
            textBoxCantidad.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1221, 266);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 37;
            label3.Text = "Origen";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1221, 325);
            label4.Name = "label4";
            label4.Size = new Size(73, 25);
            label4.TabIndex = 38;
            label4.Text = "Destino";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1221, 387);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 39;
            label5.Text = "Fecha";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1221, 443);
            label6.Name = "label6";
            label6.Size = new Size(86, 25);
            label6.TabIndex = 40;
            label6.Text = "Aerolinea";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1224, 564);
            label7.Name = "label7";
            label7.Size = new Size(83, 25);
            label7.TabIndex = 41;
            label7.Text = "Cantidad";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1309, 504);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(141, 31);
            textBox1.TabIndex = 42;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1224, 510);
            label8.Name = "label8";
            label8.Size = new Size(59, 25);
            label8.TabIndex = 43;
            label8.Text = "Costo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1221, 211);
            label9.Name = "label9";
            label9.Size = new Size(28, 25);
            label9.TabIndex = 44;
            label9.Text = "Id";
            // 
            // textBoxIdReserva
            // 
            textBoxIdReserva.Location = new Point(1309, 152);
            textBoxIdReserva.Name = "textBoxIdReserva";
            textBoxIdReserva.ReadOnly = true;
            textBoxIdReserva.Size = new Size(106, 31);
            textBoxIdReserva.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1217, 158);
            label10.Name = "label10";
            label10.Size = new Size(93, 25);
            label10.TabIndex = 46;
            label10.Text = "Id Reserva";
            // 
            // FormReservasVuelos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1476, 695);
            Controls.Add(label10);
            Controls.Add(textBoxIdReserva);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxCantidad);
            Controls.Add(textBoxAerolinea);
            Controls.Add(textBoxFecha);
            Controls.Add(textBoxDestino);
            Controls.Add(textBoxOrigen);
            Controls.Add(textBoxId);
            Controls.Add(Eliminar);
            Controls.Add(Modificar);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormReservasVuelos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormReservasVuelos";
            Load += FormReservasVuelos_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button Volver_desde_usuario;
        private Button Modificar;
        private Button Eliminar;
        private TextBox textBoxId;
        private TextBox textBoxOrigen;
        private TextBox textBoxDestino;
        private TextBox textBoxFecha;
        private TextBox textBoxAerolinea;
        private TextBox textBoxCantidad;
        // private Label Id;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox1;
        private Label label8;
        private Label label9;
        private TextBox textBoxIdReserva;
        private Label label10;
        private DataGridViewTextBoxColumn idReserva;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Origen;
        private DataGridViewTextBoxColumn Destino;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Aerolinea;
        private DataGridViewTextBoxColumn Avion;
    }
}