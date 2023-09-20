namespace tpAgencia_Gpo_2
{
    partial class FormLoginNuevoUsuario
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
            buttonCargarUsuario = new Button();
            buttonCancelarCargaUsuario = new Button();
            checkBoxSiEresAdmin = new CheckBox();
            CargaNombreNew = new TextBox();
            CargaApellidoNew = new TextBox();
            CargaEmailNew = new TextBox();
            CargaDniNew = new TextBox();
            labelNewNombre = new Label();
            labelNewApellido = new Label();
            labelNewDNI = new Label();
            labelNewEmail = new Label();
            textBox1 = new TextBox();
            textBoxConfirmaPass = new TextBox();
            textBoxConfirmaEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonCargarUsuario
            // 
            buttonCargarUsuario.Location = new Point(547, 379);
            buttonCargarUsuario.Name = "buttonCargarUsuario";
            buttonCargarUsuario.Size = new Size(75, 23);
            buttonCargarUsuario.TabIndex = 0;
            buttonCargarUsuario.Text = "Cargar";
            buttonCargarUsuario.UseVisualStyleBackColor = true;
            buttonCargarUsuario.Click += buttonCargarUsuario_Click;
            // 
            // buttonCancelarCargaUsuario
            // 
            buttonCancelarCargaUsuario.Location = new Point(637, 379);
            buttonCancelarCargaUsuario.Name = "buttonCancelarCargaUsuario";
            buttonCancelarCargaUsuario.Size = new Size(75, 23);
            buttonCancelarCargaUsuario.TabIndex = 1;
            buttonCancelarCargaUsuario.Text = "Cancelar";
            buttonCancelarCargaUsuario.UseVisualStyleBackColor = true;
            buttonCancelarCargaUsuario.Click += buttonCancelarCargaUsuario_Click;
            // 
            // checkBoxSiEresAdmin
            // 
            checkBoxSiEresAdmin.AutoSize = true;
            checkBoxSiEresAdmin.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxSiEresAdmin.Location = new Point(345, 379);
            checkBoxSiEresAdmin.Name = "checkBoxSiEresAdmin";
            checkBoxSiEresAdmin.Size = new Size(167, 19);
            checkBoxSiEresAdmin.TabIndex = 2;
            checkBoxSiEresAdmin.Text = "Tildar si eres administrador";
            checkBoxSiEresAdmin.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSiEresAdmin.UseVisualStyleBackColor = true;
            checkBoxSiEresAdmin.CheckedChanged += checkBoxSiEresAdmin_CheckedChanged;
            // 
            // CargaNombreNew
            // 
            CargaNombreNew.Location = new Point(151, 115);
            CargaNombreNew.Name = "CargaNombreNew";
            CargaNombreNew.Size = new Size(226, 23);
            CargaNombreNew.TabIndex = 3;
            CargaNombreNew.TextChanged += CargaNombreNew_TextChanged;
            // 
            // CargaApellidoNew
            // 
            CargaApellidoNew.Location = new Point(151, 155);
            CargaApellidoNew.Name = "CargaApellidoNew";
            CargaApellidoNew.Size = new Size(226, 23);
            CargaApellidoNew.TabIndex = 4;
            CargaApellidoNew.TextChanged += CargaApellidoNew_TextChanged;
            // 
            // CargaEmailNew
            // 
            CargaEmailNew.Location = new Point(151, 233);
            CargaEmailNew.Name = "CargaEmailNew";
            CargaEmailNew.Size = new Size(226, 23);
            CargaEmailNew.TabIndex = 5;
            CargaEmailNew.TextChanged += CargaEmailNew_TextChanged;
            // 
            // CargaDniNew
            // 
            CargaDniNew.Location = new Point(151, 195);
            CargaDniNew.Name = "CargaDniNew";
            CargaDniNew.Size = new Size(226, 23);
            CargaDniNew.TabIndex = 6;
            CargaDniNew.TextChanged += textBox6_TextChanged;
            // 
            // labelNewNombre
            // 
            labelNewNombre.AutoSize = true;
            labelNewNombre.Location = new Point(86, 118);
            labelNewNombre.Name = "labelNewNombre";
            labelNewNombre.Size = new Size(54, 15);
            labelNewNombre.TabIndex = 7;
            labelNewNombre.Text = "Nombre:";
            labelNewNombre.TextAlign = ContentAlignment.MiddleRight;
            labelNewNombre.Click += label1_Click;
            // 
            // labelNewApellido
            // 
            labelNewApellido.AutoSize = true;
            labelNewApellido.Location = new Point(86, 155);
            labelNewApellido.Name = "labelNewApellido";
            labelNewApellido.Size = new Size(54, 15);
            labelNewApellido.TabIndex = 8;
            labelNewApellido.Text = "Apellido:";
            labelNewApellido.TextAlign = ContentAlignment.MiddleRight;
            labelNewApellido.Click += label1_Click_1;
            // 
            // labelNewDNI
            // 
            labelNewDNI.AutoSize = true;
            labelNewDNI.Location = new Point(110, 198);
            labelNewDNI.Name = "labelNewDNI";
            labelNewDNI.Size = new Size(30, 15);
            labelNewDNI.TabIndex = 9;
            labelNewDNI.Text = "DNI:";
            labelNewDNI.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelNewEmail
            // 
            labelNewEmail.AutoSize = true;
            labelNewEmail.Location = new Point(101, 236);
            labelNewEmail.Name = "labelNewEmail";
            labelNewEmail.Size = new Size(39, 15);
            labelNewEmail.TabIndex = 10;
            labelNewEmail.Text = "EMail:";
            labelNewEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 277);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(226, 23);
            textBox1.TabIndex = 11;
            // 
            // textBoxConfirmaPass
            // 
            textBoxConfirmaPass.Location = new Point(475, 277);
            textBoxConfirmaPass.Name = "textBoxConfirmaPass";
            textBoxConfirmaPass.PasswordChar = '*';
            textBoxConfirmaPass.Size = new Size(226, 23);
            textBoxConfirmaPass.TabIndex = 13;
            // 
            // textBoxConfirmaEmail
            // 
            textBoxConfirmaEmail.Location = new Point(475, 233);
            textBoxConfirmaEmail.Name = "textBoxConfirmaEmail";
            textBoxConfirmaEmail.Size = new Size(226, 23);
            textBoxConfirmaEmail.TabIndex = 12;
            textBoxConfirmaEmail.TextChanged += textBoxConfirmaEmail_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 280);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 14;
            label1.Text = "Password:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.Click += label1_Click_2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 226);
            label2.Name = "label2";
            label2.Size = new Size(61, 30);
            label2.TabIndex = 15;
            label2.Text = "Confirmar\r\nEMail:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(409, 270);
            label3.Name = "label3";
            label3.Size = new Size(61, 30);
            label3.TabIndex = 16;
            label3.Text = "Confirmar\r\nPassword:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormLoginNuevoUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxConfirmaPass);
            Controls.Add(textBoxConfirmaEmail);
            Controls.Add(textBox1);
            Controls.Add(labelNewEmail);
            Controls.Add(labelNewDNI);
            Controls.Add(labelNewApellido);
            Controls.Add(labelNewNombre);
            Controls.Add(CargaDniNew);
            Controls.Add(CargaEmailNew);
            Controls.Add(CargaApellidoNew);
            Controls.Add(CargaNombreNew);
            Controls.Add(checkBoxSiEresAdmin);
            Controls.Add(buttonCancelarCargaUsuario);
            Controls.Add(buttonCargarUsuario);
            Name = "FormLoginNuevoUsuario";
            Text = "FormLoginNuevoUsuario";
            Load += FormLoginNuevoUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCargarUsuario;
        private Button buttonCancelarCargaUsuario;
        private CheckBox checkBoxSiEresAdmin;
        private TextBox CargaNombreNew;
        private TextBox CargaApellidoNew;
        private TextBox CargaEmailNew;
        private TextBox CargaDniNew;
        private Label labelNewNombre;
        private Label labelNewApellido;
        private Label labelNewDNI;
        private Label labelNewEmail;
        private TextBox textBox1;
        private TextBox textBoxConfirmaPass;
        private TextBox textBoxConfirmaEmail;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}