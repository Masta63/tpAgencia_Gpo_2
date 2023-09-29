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
            Ubicacion = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Capacidad = new DataGridViewTextBoxColumn();
            Volver_desde_usuario = new Button();
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
            label2.Location = new Point(51, 84);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 13);
            label2.TabIndex = 1;
            label2.Text = "Mis reservas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Ubicacion, Costo, Nombre, Capacidad });
            dataGridView1.Location = new Point(52, 119);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(786, 175);
            dataGridView1.TabIndex = 2;
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
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(52, 322);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 27;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // FormReservasHoteles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1033, 417);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
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
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Capacidad;
    }
}