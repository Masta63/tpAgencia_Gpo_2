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
            id = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            idLabel = new Label();
            textCiudadId = new TextBox();
            Volver_desde_usuario = new Button();
            bienvenida = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).BeginInit();
            SuspendLayout();
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.Location = new Point(1019, 313);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(174, 60);
            btnModificar.TabIndex = 15;
            btnModificar.Text = "Modificacion";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBaja
            // 
            btnBaja.BackColor = SystemColors.ActiveCaption;
            btnBaja.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBaja.Location = new Point(841, 313);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(153, 60);
            btnBaja.TabIndex = 14;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnAlta
            // 
            btnAlta.BackColor = SystemColors.ActiveCaption;
            btnAlta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAlta.Location = new Point(663, 313);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(153, 60);
            btnAlta.TabIndex = 13;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = false;
            btnAlta.Click += btnAlta_Click;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(950, 193);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 35);
            txtNombre.TabIndex = 12;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(953, 130);
            label3.Name = "label3";
            label3.Size = new Size(101, 29);
            label3.TabIndex = 10;
            label3.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(724, 143);
            label1.Name = "label1";
            label1.Size = new Size(33, 29);
            label1.TabIndex = 9;
            label1.Text = "Id";
            // 
            // dgvCiudad
            // 
            dgvCiudad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCiudad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCiudad.Columns.AddRange(new DataGridViewColumn[] { id, nombre });
            dgvCiudad.Location = new Point(16, 122);
            dgvCiudad.Name = "dgvCiudad";
            dgvCiudad.RowHeadersWidth = 62;
            dgvCiudad.RowTemplate.Height = 33;
            dgvCiudad.Size = new Size(626, 322);
            dgvCiudad.TabIndex = 8;
            dgvCiudad.CellContentClick += dgvCiudad_CellContentClick;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 8;
            id.Name = "id";
            // 
            // nombre
            // 
            nombre.HeaderText = "nombre";
            nombre.MinimumWidth = 8;
            nombre.Name = "nombre";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            idLabel.Location = new Point(724, 203);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(0, 29);
            idLabel.TabIndex = 16;
            // 
            // textCiudadId
            // 
            textCiudadId.Enabled = false;
            textCiudadId.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textCiudadId.Location = new Point(690, 198);
            textCiudadId.Name = "textCiudadId";
            textCiudadId.Size = new Size(150, 35);
            textCiudadId.TabIndex = 17;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(17, 528);
            Volver_desde_usuario.Margin = new Padding(4, 5, 4, 5);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(107, 38);
            Volver_desde_usuario.TabIndex = 18;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // bienvenida
            // 
            bienvenida.AutoSize = true;
            bienvenida.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            bienvenida.Location = new Point(34, 30);
            bienvenida.Margin = new Padding(4, 0, 4, 0);
            bienvenida.Name = "bienvenida";
            bienvenida.Size = new Size(206, 51);
            bienvenida.TabIndex = 34;
            bienvenida.Text = "Ciudades: ";
            // 
            // FormCiudad
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 750);
            Controls.Add(bienvenida);
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
            Margin = new Padding(4, 5, 4, 5);
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
        private Label bienvenida;
    }
}