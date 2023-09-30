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
            checkBoxEsAdmin = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 57);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 25);
            label1.TabIndex = 0;
            label1.Text = "Mail";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 57);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // textMail
            // 
            textMail.Location = new Point(17, 110);
            textMail.Margin = new Padding(4, 5, 4, 5);
            textMail.Name = "textMail";
            textMail.Size = new Size(150, 31);
            textMail.TabIndex = 2;
            // 
            // textContrasenia
            // 
            textContrasenia.Location = new Point(214, 110);
            textContrasenia.Margin = new Padding(4, 5, 4, 5);
            textContrasenia.Name = "textContrasenia";
            textContrasenia.PasswordChar = '*';
            textContrasenia.Size = new Size(177, 31);
            textContrasenia.TabIndex = 3;
            textContrasenia.TextChanged += textContrasenia_TextChanged;
            // 
            // Aceptar
            // 
            Aceptar.Location = new Point(286, 238);
            Aceptar.Margin = new Padding(4, 5, 4, 5);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(107, 38);
            Aceptar.TabIndex = 4;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // checkBoxEsAdmin
            // 
            checkBoxEsAdmin.AutoSize = true;
            checkBoxEsAdmin.Location = new Point(17, 198);
            checkBoxEsAdmin.Margin = new Padding(4, 5, 4, 5);
            checkBoxEsAdmin.Name = "checkBoxEsAdmin";
            checkBoxEsAdmin.Size = new Size(108, 29);
            checkBoxEsAdmin.TabIndex = 5;
            checkBoxEsAdmin.Text = "esAdmin";
            checkBoxEsAdmin.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 297);
            Controls.Add(checkBoxEsAdmin);
            Controls.Add(Aceptar);
            Controls.Add(textContrasenia);
            Controls.Add(textMail);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
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
        private CheckBox checkBoxEsAdmin;
    }
}