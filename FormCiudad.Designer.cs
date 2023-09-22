namespace tpAgencia_Gpo_2
{
    partial class FormCiudad
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
            btnModificar = new Button();
            btnBaja = new Button();
            btnAlta = new Button();
            txtNombre = new TextBox();
            label3 = new Label();
            label1 = new Label();
            dgvCiudad = new DataGridView();
            idLabel = new Label();
            textCiudadId = new TextBox();
            Volver_desde_usuario = new Button();
            id = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).BeginInit();
            SuspendLayout();
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.Location = new Point(713, 188);
            btnModificar.Margin = new Padding(2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(122, 36);
            btnModificar.TabIndex = 15;
            btnModificar.Text = "Modificacion";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBaja
            // 
            btnBaja.BackColor = SystemColors.ActiveCaption;
            btnBaja.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBaja.Location = new Point(589, 188);
            btnBaja.Margin = new Padding(2);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(107, 36);
            btnBaja.TabIndex = 14;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnAlta
            // 
            btnAlta.BackColor = SystemColors.ActiveCaption;
            btnAlta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAlta.Location = new Point(464, 188);
            btnAlta.Margin = new Padding(2);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(107, 36);
            btnAlta.TabIndex = 13;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = false;
            btnAlta.Click += btnAlta_Click;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(665, 116);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(106, 26);
            txtNombre.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(667, 78);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 10;
            label3.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(507, 86);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(23, 20);
            label1.TabIndex = 9;
            label1.Text = "Id";
            // 
            // dgvCiudad
            // 
            dgvCiudad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCiudad.Columns.AddRange(new DataGridViewColumn[] { id, nombre });
            dgvCiudad.Location = new Point(11, 73);
            dgvCiudad.Margin = new Padding(2);
            dgvCiudad.Name = "dgvCiudad";
            dgvCiudad.RowHeadersWidth = 62;
            dgvCiudad.RowTemplate.Height = 33;
            dgvCiudad.Size = new Size(438, 193);
            dgvCiudad.TabIndex = 8;
            dgvCiudad.CellContentClick += dgvCiudad_CellContentClick;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            idLabel.Location = new Point(507, 122);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(0, 20);
            idLabel.TabIndex = 16;
            // 
            // textCiudadId
            // 
            textCiudadId.Enabled = false;
            textCiudadId.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textCiudadId.Location = new Point(483, 119);
            textCiudadId.Margin = new Padding(2);
            textCiudadId.Name = "textCiudadId";
            textCiudadId.Size = new Size(106, 26);
            textCiudadId.TabIndex = 17;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(12, 317);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 18;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.Name = "id";
            // 
            // nombre
            // 
            nombre.HeaderText = "nombre";
            nombre.Name = "nombre";
            nombre.Width = 200;
            // 
            // FormCiudad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 450);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(textCiudadId);
            Controls.Add(idLabel);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnAlta);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dgvCiudad);
            Name = "FormCiudad";
            Text = "FormCiudad";
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificar;
        private Button btnBaja;
        private Button btnAlta;
        private TextBox txtNombre;
        private Label label3;
        private Label label1;
        private DataGridView dgvCiudad;
        private Label idLabel;
        private TextBox textCiudadId;
        private Button Volver_desde_usuario;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nombre;
    }
}