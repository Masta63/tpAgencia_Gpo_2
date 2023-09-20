namespace tpAgencia_Gpo_2
{
    partial class FormLogin
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
            checkBoxAdmin = new CheckBox();
            textoUsuario = new Label();
            textoClave = new Label();
            ingresoUsuario = new TextBox();
            ingresoClave = new TextBox();
            btnIngresar = new Button();
            btnLimpiar = new Button();
            btnNuevoUsuario = new Button();
            SuspendLayout();
            // 
            // checkBoxAdmin
            // 
            checkBoxAdmin.AutoSize = true;
            checkBoxAdmin.Location = new Point(675, 419);
            checkBoxAdmin.Name = "checkBoxAdmin";
            checkBoxAdmin.RightToLeft = RightToLeft.Yes;
            checkBoxAdmin.Size = new Size(102, 19);
            checkBoxAdmin.TabIndex = 0;
            checkBoxAdmin.Text = "Administrador";
            checkBoxAdmin.UseVisualStyleBackColor = true;
            checkBoxAdmin.CheckedChanged += checkBoxAdmin_CheckedChanged;
            // 
            // textoUsuario
            // 
            textoUsuario.AutoSize = true;
            textoUsuario.Location = new Point(153, 94);
            textoUsuario.Name = "textoUsuario";
            textoUsuario.Size = new Size(50, 15);
            textoUsuario.TabIndex = 1;
            textoUsuario.Text = "Usuario:";
            textoUsuario.Click += label1_Click;
            // 
            // textoClave
            // 
            textoClave.AutoSize = true;
            textoClave.Location = new Point(164, 150);
            textoClave.Name = "textoClave";
            textoClave.Size = new Size(39, 15);
            textoClave.TabIndex = 2;
            textoClave.Text = "Clave:";
            // 
            // ingresoUsuario
            // 
            ingresoUsuario.BackColor = SystemColors.Window;
            ingresoUsuario.Location = new Point(245, 86);
            ingresoUsuario.Name = "ingresoUsuario";
            ingresoUsuario.Size = new Size(320, 23);
            ingresoUsuario.TabIndex = 3;
            // 
            // ingresoClave
            // 
            ingresoClave.Location = new Point(245, 142);
            ingresoClave.Name = "ingresoClave";
            ingresoClave.PasswordChar = '*';
            ingresoClave.Size = new Size(320, 23);
            ingresoClave.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(263, 240);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(111, 23);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(12, 415);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(62, 23);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Borrar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.Location = new Point(407, 240);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Size = new Size(111, 23);
            btnNuevoUsuario.TabIndex = 7;
            btnNuevoUsuario.Text = "Nuevo Usuario";
            btnNuevoUsuario.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNuevoUsuario);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Controls.Add(ingresoClave);
            Controls.Add(ingresoUsuario);
            Controls.Add(textoClave);
            Controls.Add(textoUsuario);
            Controls.Add(checkBoxAdmin);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxAdmin;
        private Label textoUsuario;
        private Label textoClave;
        private TextBox ingresoUsuario;
        private TextBox ingresoClave;
        private Button btnIngresar;
        private Button btnLimpiar;
        private Button btnNuevoUsuario;
    }
}