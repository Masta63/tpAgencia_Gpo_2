namespace tpAgencia_Gpo_2
{
    partial class FormHotelAbm
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
            textBoxCosto = new TextBox();
            comboBoxHospedaje = new ComboBox();
            label2 = new Label();
            textBoxNombre = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxId = new TextBox();
            label5 = new Label();
            dataGridViewHoteles = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Ubicacion = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            buttonActualizarInformacion = new Button();
            buttonAgregar = new Button();
            buttonModificar = new Button();
            buttonCancelar = new Button();
            label6 = new Label();
            buttonVolver = new Button();
            textBoxCapacidad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(592, 176);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 1;
            label1.Text = "Ciudad del hotel";
            label1.Click += label1_Click;
            // 
            // textBoxCosto
            // 
            textBoxCosto.Location = new Point(556, 337);
            textBoxCosto.Name = "textBoxCosto";
            textBoxCosto.Size = new Size(179, 23);
            textBoxCosto.TabIndex = 3;
            textBoxCosto.TextChanged += textBoxCosto_TextChanged;
            // 
            // comboBoxHospedaje
            // 
            comboBoxHospedaje.FormattingEnabled = true;
            comboBoxHospedaje.Location = new Point(556, 194);
            comboBoxHospedaje.Name = "comboBoxHospedaje";
            comboBoxHospedaje.Size = new Size(179, 23);
            comboBoxHospedaje.TabIndex = 5;
            comboBoxHospedaje.SelectedIndexChanged += comboBoxHospedaje_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(592, 100);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre del hotel";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(556, 118);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(179, 23);
            textBoxNombre.TabIndex = 7;
            textBoxNombre.TextChanged += textBoxNombre_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(572, 254);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 8;
            label3.Text = "Capacidad de huespedes";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(609, 28);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 9;
            label4.Text = "ID a asignar";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(561, 46);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(179, 23);
            textBoxId.TabIndex = 10;
            textBoxId.TextChanged += textBoxId_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(591, 319);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 11;
            label5.Text = "Costo por noche";
            // 
            // dataGridViewHoteles
            // 
            dataGridViewHoteles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoteles.Columns.AddRange(new DataGridViewColumn[] { ID, Ubicacion, Capacidad, Costo, Nombre });
            dataGridViewHoteles.Location = new Point(12, 99);
            dataGridViewHoteles.Name = "dataGridViewHoteles";
            dataGridViewHoteles.RowTemplate.Height = 25;
            dataGridViewHoteles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHoteles.Size = new Size(517, 260);
            dataGridViewHoteles.TabIndex = 12;
            dataGridViewHoteles.CellContentClick += dataGridViewHoteles_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Ubicacion
            // 
            Ubicacion.HeaderText = "Ubicacion";
            Ubicacion.Name = "Ubicacion";
            // 
            // Capacidad
            // 
            Capacidad.HeaderText = "Capacidad";
            Capacidad.Name = "Capacidad";
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // buttonActualizarInformacion
            // 
            buttonActualizarInformacion.Location = new Point(12, 70);
            buttonActualizarInformacion.Name = "buttonActualizarInformacion";
            buttonActualizarInformacion.Size = new Size(193, 23);
            buttonActualizarInformacion.TabIndex = 13;
            buttonActualizarInformacion.Text = "Actualizar informacion";
            buttonActualizarInformacion.UseVisualStyleBackColor = true;
            buttonActualizarInformacion.Click += buttonActualizarInformacion_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(508, 401);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 23);
            buttonAgregar.TabIndex = 14;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(602, 401);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(75, 23);
            buttonModificar.TabIndex = 15;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(695, 401);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 23);
            buttonCancelar.TabIndex = 16;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(168, 19);
            label6.Name = "label6";
            label6.Size = new Size(136, 31);
            label6.TabIndex = 17;
            label6.Text = "ABM HOTEL";
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(21, 401);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
            buttonVolver.TabIndex = 18;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(556, 282);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(184, 23);
            textBoxCapacidad.TabIndex = 19;
            textBoxCapacidad.TextChanged += textBoxCapacidad_TextChanged;
            // 
            // FormHotelAbm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxCapacidad);
            Controls.Add(buttonVolver);
            Controls.Add(label6);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonActualizarInformacion);
            Controls.Add(dataGridViewHoteles);
            Controls.Add(label5);
            Controls.Add(textBoxId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxNombre);
            Controls.Add(label2);
            Controls.Add(comboBoxHospedaje);
            Controls.Add(textBoxCosto);
            Controls.Add(label1);
            Name = "FormHotelAbm";
            Text = "Form2";
            Load += FormHotelAbm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBoxCosto;
        private ComboBox comboBoxHospedaje;
        private Label label2;
        private TextBox textBoxNombre;
        private Label label3;
        private Label label4;
        private TextBox textBoxId;
        private Label label5;
        private DataGridView dataGridViewHoteles;
        private Button buttonActualizarInformacion;
        private Button buttonAgregar;
        private Button buttonModificar;
        private Button buttonCancelar;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn Capacidad;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Nombre;
        private Label label6;
        private Button buttonVolver;
        private TextBox textBoxCapacidad;
    }
}