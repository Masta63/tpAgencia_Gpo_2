
namespace ABM_Ciudad
{
    partial class ABMCiudad
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCiudad = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnAlta = new Button();
            btnBaja = new Button();
            btnModificar = new Button();
            txtNombre = new TextBox();
            numericID = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericID).BeginInit();
            SuspendLayout();
            // 
            // dgvCiudad
            // 
            dgvCiudad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCiudad.Location = new Point(20, 61);
            dgvCiudad.Margin = new Padding(4, 6, 4, 6);
            dgvCiudad.Name = "dgvCiudad";
            dgvCiudad.RowHeadersWidth = 62;
            dgvCiudad.Size = new Size(777, 386);
            dgvCiudad.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(890, 119);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 27);
            label1.TabIndex = 1;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1189, 119);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 27);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // btnAlta
            // 
            btnAlta.BackColor = SystemColors.ActiveCaption;
            btnAlta.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAlta.Location = new Point(847, 381);
            btnAlta.Margin = new Padding(4, 6, 4, 6);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(184, 68);
            btnAlta.TabIndex = 3;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = false;
            btnAlta.Click += button1_Click;
            // 
            // btnBaja
            // 
            btnBaja.BackColor = SystemColors.ActiveCaption;
            btnBaja.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBaja.Location = new Point(1089, 381);
            btnBaja.Margin = new Padding(4, 6, 4, 6);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(157, 68);
            btnBaja.TabIndex = 4;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.Location = new Point(1298, 381);
            btnModificar.Margin = new Padding(4, 6, 4, 6);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(187, 68);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificacion";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(1189, 179);
            txtNombre.Margin = new Padding(4, 6, 4, 6);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(164, 35);
            txtNombre.TabIndex = 7;
            txtNombre.Text = "bue";
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // numericID
            // 
            numericID.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericID.Location = new Point(896, 179);
            numericID.Margin = new Padding(4, 6, 4, 6);
            numericID.Name = "numericID";
            numericID.Size = new Size(200, 35);
            numericID.TabIndex = 8;
            numericID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericID.ValueChanged += numericID_ValueChanged;
            // 
            // ABMCiudad
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1511, 842);
            Controls.Add(numericID);
            Controls.Add(txtNombre);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnAlta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvCiudad);
            Margin = new Padding(4, 6, 4, 6);
            Name = "ABMCiudad";
            Text = "Form1";
            Load += ABMCiudad_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCiudad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCiudad;
        private Label label1;
        private Label label2;
        private Button btnAlta;
        private Button btnBaja;
        private Button btnModificar;
        private TextBox txtNombre;
        private NumericUpDown numericID;
    }
}

