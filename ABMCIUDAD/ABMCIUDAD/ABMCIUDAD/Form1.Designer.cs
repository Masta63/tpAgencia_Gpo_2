namespace ABMCIUDAD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
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
            dgvCiudad.Location = new Point(22, 50);
            dgvCiudad.Name = "dgvCiudad";
            dgvCiudad.RowHeadersWidth = 62;
            dgvCiudad.RowTemplate.Height = 33;
            dgvCiudad.Size = new Size(626, 322);
            dgvCiudad.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(730, 71);
            label1.Name = "label1";
            label1.Size = new Size(33, 29);
            label1.TabIndex = 1;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(958, 59);
            label3.Name = "label3";
            label3.Size = new Size(101, 29);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // numericID
            // 
            numericID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericID.Location = new Point(723, 123);
            numericID.Name = "numericID";
            numericID.Size = new Size(180, 35);
            numericID.TabIndex = 3;
            numericID.ValueChanged += numericID_ValueChanged;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(956, 122);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 35);
            txtNombre.TabIndex = 4;
            // 
            // btnAlta
            // 
            btnAlta.BackColor = SystemColors.ActiveCaption;
            btnAlta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAlta.Location = new Point(668, 241);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(153, 60);
            btnAlta.TabIndex = 5;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = false;
            btnAlta.Click += btnAlta_Click;
            // 
            // btnBaja
            // 
            btnBaja.BackColor = SystemColors.ActiveCaption;
            btnBaja.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBaja.Location = new Point(847, 241);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(153, 60);
            btnBaja.TabIndex = 6;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.ActiveCaption;
            btnModificar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.Location = new Point(1024, 241);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(175, 60);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificacion";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 557);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnAlta);
            Controls.Add(txtNombre);
            Controls.Add(numericID);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dgvCiudad);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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