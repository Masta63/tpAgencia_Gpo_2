namespace tpAgencia_Gpo_2
{
    partial class FormRegistroUsuario
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
            textBox_nombre = new TextBox();
            textBox_apellido = new TextBox();
            textBox_dni = new TextBox();
            textBox_email = new TextBox();
            textBox_pass = new TextBox();
            lbl_Nombre = new Label();
            lbl_apellido = new Label();
            lbl_dni = new Label();
            lbl_email = new Label();
            lbl_pass = new Label();
            btn_Registrar = new Button();
            buttonRegistro_volver = new Button();
            SuspendLayout();
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(308, 71);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(100, 23);
            textBox_nombre.TabIndex = 0;
            // 
            // textBox_apellido
            // 
            textBox_apellido.Location = new Point(308, 100);
            textBox_apellido.Name = "textBox_apellido";
            textBox_apellido.Size = new Size(100, 23);
            textBox_apellido.TabIndex = 1;
            // 
            // textBox_dni
            // 
            textBox_dni.Location = new Point(308, 133);
            textBox_dni.Name = "textBox_dni";
            textBox_dni.Size = new Size(100, 23);
            textBox_dni.TabIndex = 2;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(308, 164);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(100, 23);
            textBox_email.TabIndex = 3;
            // 
            // textBox_pass
            // 
            textBox_pass.Location = new Point(308, 193);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(100, 23);
            textBox_pass.TabIndex = 4;
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Location = new Point(212, 79);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(51, 15);
            lbl_Nombre.TabIndex = 5;
            lbl_Nombre.Text = "Nombre";
            // 
            // lbl_apellido
            // 
            lbl_apellido.AutoSize = true;
            lbl_apellido.Location = new Point(212, 108);
            lbl_apellido.Name = "lbl_apellido";
            lbl_apellido.Size = new Size(51, 15);
            lbl_apellido.TabIndex = 6;
            lbl_apellido.Text = "Apellido";
            // 
            // lbl_dni
            // 
            lbl_dni.AutoSize = true;
            lbl_dni.Location = new Point(212, 141);
            lbl_dni.Name = "lbl_dni";
            lbl_dni.Size = new Size(25, 15);
            lbl_dni.TabIndex = 7;
            lbl_dni.Text = "Dni";
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Location = new Point(212, 172);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(36, 15);
            lbl_email.TabIndex = 8;
            lbl_email.Text = "Email";
            // 
            // lbl_pass
            // 
            lbl_pass.AutoSize = true;
            lbl_pass.Location = new Point(212, 201);
            lbl_pass.Name = "lbl_pass";
            lbl_pass.Size = new Size(57, 15);
            lbl_pass.TabIndex = 9;
            lbl_pass.Text = "Password";
            // 
            // btn_Registrar
            // 
            btn_Registrar.Location = new Point(411, 270);
            btn_Registrar.Name = "btn_Registrar";
            btn_Registrar.Size = new Size(125, 66);
            btn_Registrar.TabIndex = 10;
            btn_Registrar.Text = "Registrar";
            btn_Registrar.UseVisualStyleBackColor = true;
            btn_Registrar.Click += btn_Registrar_Click;
            // 
            // buttonRegistro_volver
            // 
            buttonRegistro_volver.Location = new Point(144, 270);
            buttonRegistro_volver.Name = "buttonRegistro_volver";
            buttonRegistro_volver.Size = new Size(125, 66);
            buttonRegistro_volver.TabIndex = 11;
            buttonRegistro_volver.Text = "Volver";
            buttonRegistro_volver.UseVisualStyleBackColor = true;
            // 
            // FormRegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 450);
            Controls.Add(buttonRegistro_volver);
            Controls.Add(btn_Registrar);
            Controls.Add(lbl_pass);
            Controls.Add(lbl_email);
            Controls.Add(lbl_dni);
            Controls.Add(lbl_apellido);
            Controls.Add(lbl_Nombre);
            Controls.Add(textBox_pass);
            Controls.Add(textBox_email);
            Controls.Add(textBox_dni);
            Controls.Add(textBox_apellido);
            Controls.Add(textBox_nombre);
            Name = "FormRegistroUsuario";
            Text = "FormRegistroUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_nombre;
        private TextBox textBox_apellido;
        private TextBox textBox_dni;
        private TextBox textBox_email;
        private TextBox textBox_pass;
        private Label lbl_Nombre;
        private Label lbl_apellido;
        private Label lbl_dni;
        private Label lbl_email;
        private Label lbl_pass;
        private Button btn_Registrar;
        private Button buttonRegistro_volver;
    }
}