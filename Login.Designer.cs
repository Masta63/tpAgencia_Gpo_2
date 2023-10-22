namespace tpAgencia_Gpo_2
{
    partial class Login
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
            textMail = new TextBox();
            textContrasenia = new TextBox();
            Aceptar = new Button();
            btn_registrarse = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 34);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Mail";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 34);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // textMail
            // 
            textMail.Location = new Point(12, 66);
            textMail.Name = "textMail";
            textMail.Size = new Size(106, 23);
            textMail.TabIndex = 2;
            // 
            // textContrasenia
            // 
            textContrasenia.Location = new Point(150, 66);
            textContrasenia.Name = "textContrasenia";
            textContrasenia.PasswordChar = '*';
            textContrasenia.Size = new Size(125, 23);
            textContrasenia.TabIndex = 3;
            textContrasenia.TextChanged += textContrasenia_TextChanged;
            // 
            // Aceptar
            // 
            Aceptar.Location = new Point(43, 129);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(75, 23);
            Aceptar.TabIndex = 4;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // btn_registrarse
            // 
            btn_registrarse.Location = new Point(199, 129);
            btn_registrarse.Name = "btn_registrarse";
            btn_registrarse.Size = new Size(75, 23);
            btn_registrarse.TabIndex = 5;
            btn_registrarse.Text = "Registrarse";
            btn_registrarse.UseVisualStyleBackColor = true;
            btn_registrarse.Click += btn_registrarse_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 178);
            Controls.Add(btn_registrarse);
            Controls.Add(Aceptar);
            Controls.Add(textContrasenia);
            Controls.Add(textMail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textMail;
        private TextBox textContrasenia;
        private Button Aceptar;
        private Button btn_registrarse;
    }
}