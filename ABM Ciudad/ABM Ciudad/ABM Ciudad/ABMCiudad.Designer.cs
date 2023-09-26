
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
			this.dgvCiudad = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAlta = new System.Windows.Forms.Button();
			this.btnBaja = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.numericID = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.dgvCiudad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericID)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvCiudad
			// 
			this.dgvCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCiudad.Location = new System.Drawing.Point(18, 49);
			this.dgvCiudad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dgvCiudad.Name = "dgvCiudad";
			this.dgvCiudad.RowHeadersWidth = 62;
			this.dgvCiudad.Size = new System.Drawing.Size(699, 309);
			this.dgvCiudad.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(801, 95);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 27);
			this.label1.TabIndex = 1;
			this.label1.Text = "Id";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(1070, 95);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 27);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nombre";
			// 
			// btnAlta
			// 
			this.btnAlta.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnAlta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAlta.Location = new System.Drawing.Point(762, 305);
			this.btnAlta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAlta.Name = "btnAlta";
			this.btnAlta.Size = new System.Drawing.Size(166, 54);
			this.btnAlta.TabIndex = 3;
			this.btnAlta.Text = "Alta";
			this.btnAlta.UseVisualStyleBackColor = false;
			this.btnAlta.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnBaja
			// 
			this.btnBaja.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnBaja.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBaja.Location = new System.Drawing.Point(980, 305);
			this.btnBaja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBaja.Name = "btnBaja";
			this.btnBaja.Size = new System.Drawing.Size(141, 54);
			this.btnBaja.TabIndex = 4;
			this.btnBaja.Text = "Baja";
			this.btnBaja.UseVisualStyleBackColor = false;
			this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
			// 
			// btnModificar
			// 
			this.btnModificar.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnModificar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnModificar.Location = new System.Drawing.Point(1168, 305);
			this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(168, 54);
			this.btnModificar.TabIndex = 5;
			this.btnModificar.Text = "Modificacion";
			this.btnModificar.UseVisualStyleBackColor = false;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// txtNombre
			// 
			this.txtNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNombre.Location = new System.Drawing.Point(1074, 143);
			this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(148, 35);
			this.txtNombre.TabIndex = 7;
			// 
			// numericID
			// 
			this.numericID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericID.Location = new System.Drawing.Point(806, 143);
			this.numericID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.numericID.Name = "numericID";
			this.numericID.Size = new System.Drawing.Size(180, 35);
			this.numericID.TabIndex = 8;
			// 
			// ABMCiudad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1360, 674);
			this.Controls.Add(this.numericID);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnBaja);
			this.Controls.Add(this.btnAlta);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvCiudad);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "ABMCiudad";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ABMCiudad_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvCiudad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCiudad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown numericID;
    }
}

