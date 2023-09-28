namespace ABMCiudadV2
{
    partial class ABMCIUDAD
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
            dgvCiudad = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            numericID = new NumericUpDown();
            txtNombre = new TextBox();
            btnAlta = new Button();
            btnBaja = new Button();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericID).BeginInit();
            SuspendLayout();
            // 
            // dgvCiudad
            // 
            dgvCiudad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCiudad.Location = new Point(29, 109);
            dgvCiudad.Name = "dgvCiudad";
            dgvCiudad.RowHeadersWidth = 62;
            dgvCiudad.RowTemplate.Height = 33;
            dgvCiudad.Size = new Size(591, 277);
            dgvCiudad.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(29, 36);
            label1.Name = "label1";
            label1.Size = new Size(112, 32);
            label1.TabIndex = 1;
            label1.Text = "Ciudades";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(647, 109);
            label2.Name = "label2";
            label2.Size = new Size(34, 32);
            label2.TabIndex = 2;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(970, 109);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // numericID
            // 
            numericID.Location = new Point(654, 152);
            numericID.Name = "numericID";
            numericID.Size = new Size(180, 31);
            numericID.TabIndex = 4;
            numericID.ValueChanged += numericID_ValueChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(970, 151);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 5;
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(668, 292);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(125, 51);
            btnAlta.TabIndex = 6;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click;
            // 
            // btnBaja
            // 
            btnBaja.Location = new Point(828, 292);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(129, 51);
            btnBaja.TabIndex = 7;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(985, 292);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(135, 51);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // ABMCIUDAD
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 531);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnAlta);
            Controls.Add(txtNombre);
            Controls.Add(numericID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvCiudad);
            Name = "ABMCIUDAD";
            Text = "ABMCIUDAD";
            Load += ABMCIUDAD_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCiudad;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericID;
        private TextBox txtNombre;
        private Button btnAlta;
        private Button btnBaja;
        private Button btnModificar;
    }
}