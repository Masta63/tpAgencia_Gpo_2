namespace tpAgencia_Gpo_2
{
    partial class FormUsuario
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
            mostrar_usuario = new Button();
            Volver_desde_usuario = new Button();
            label_usuarios = new Label();
            label_id = new Label();
            label_nombre = new Label();
            label_apellido = new Label();
            label_dni = new Label();
            label_email = new Label();
            label_reserva_hotel = new Label();
            label_reserva_vuelo = new Label();
            textBox_id = new TextBox();
            textBox_nombre = new TextBox();
            textBox_apellido = new TextBox();
            textBox_dni = new TextBox();
            textBox_email = new TextBox();
            textBox_resHotel = new TextBox();
            textBox_resVuelo = new TextBox();
            button_Agregar = new Button();
            button_Modificar = new Button();
            button_Eliminar = new Button();
            dataGridView_usuarios = new DataGridView();
            bienvenida = new Label();
            Bienvenida_usuario = new Label();
            id = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            apellido = new DataGridViewTextBoxColumn();
            dni = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            resHotel = new DataGridViewTextBoxColumn();
            resVuelo = new DataGridViewTextBoxColumn();
            bienvenida = new Label();
            Bienvenida_usuario = new Label();
            textBox_credito = new TextBox();
            label_Credito = new Label();
            btn_agregarCredito = new Button();
            btn_modificarCredito = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_usuarios).BeginInit();
            SuspendLayout();
            // 
            // mostrar_usuario
            // 
            mostrar_usuario.Location = new Point(35, 169);
            mostrar_usuario.Margin = new Padding(2);
            mostrar_usuario.Name = "mostrar_usuario";
            mostrar_usuario.Size = new Size(181, 32);
            mostrar_usuario.TabIndex = 6;
            mostrar_usuario.Text = "Mostrar / Actualizar Usuarios";
            mostrar_usuario.UseVisualStyleBackColor = true;
            mostrar_usuario.Click += mostrar_usuario_Click;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.BackColor = Color.FromArgb(192, 255, 255);
            Volver_desde_usuario.Location = new Point(35, 405);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 8;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = false;
            Volver_desde_usuario.Click += Volver_desde_usuario_Click;
            // 
            // label_usuarios
            // 
            label_usuarios.AutoSize = true;
            label_usuarios.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            label_usuarios.Location = new Point(680, 33);
            label_usuarios.Name = "label_usuarios";
            label_usuarios.Size = new Size(119, 36);
            label_usuarios.TabIndex = 9;
            label_usuarios.Text = "Usuarios";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(960, 83);
            label_id.Name = "label_id";
            label_id.Size = new Size(17, 15);
            label_id.TabIndex = 11;
            label_id.Text = "id";
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Location = new Point(926, 120);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(51, 15);
            label_nombre.TabIndex = 12;
            label_nombre.Text = "Nombre";
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Location = new Point(926, 155);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(51, 15);
            label_apellido.TabIndex = 13;
            label_apellido.Text = "Apellido";
            // 
            // label_dni
            // 
            label_dni.AutoSize = true;
            label_dni.Location = new Point(952, 186);
            label_dni.Name = "label_dni";
            label_dni.Size = new Size(25, 15);
            label_dni.TabIndex = 14;
            label_dni.Text = "Dni";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Location = new Point(941, 228);
            label_email.Name = "label_email";
            label_email.Size = new Size(36, 15);
            label_email.TabIndex = 15;
            label_email.Text = "Email";
            // 
            // label_reserva_hotel
            // 
            label_reserva_hotel.AutoSize = true;
            label_reserva_hotel.Location = new Point(898, 267);
            label_reserva_hotel.Name = "label_reserva_hotel";
            label_reserva_hotel.Size = new Size(79, 15);
            label_reserva_hotel.TabIndex = 17;
            label_reserva_hotel.Text = "Reserva Hotel";
            // 
            // label_reserva_vuelo
            // 
            label_reserva_vuelo.AutoSize = true;
            label_reserva_vuelo.Location = new Point(897, 308);
            label_reserva_vuelo.Name = "label_reserva_vuelo";
            label_reserva_vuelo.Size = new Size(80, 15);
            label_reserva_vuelo.TabIndex = 18;
            label_reserva_vuelo.Text = "Reserva Vuelo";
            // 
            // textBox_id
            // 
            textBox_id.Enabled = false;
            textBox_id.Location = new Point(993, 75);
            textBox_id.Name = "textBox_id";
            textBox_id.ReadOnly = true;
            textBox_id.Size = new Size(269, 23);
            textBox_id.TabIndex = 20;
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(993, 112);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(269, 23);
            textBox_nombre.TabIndex = 21;
            // 
            // textBox_apellido
            // 
            textBox_apellido.Location = new Point(993, 147);
            textBox_apellido.Name = "textBox_apellido";
            textBox_apellido.Size = new Size(269, 23);
            textBox_apellido.TabIndex = 22;
            // 
            // textBox_dni
            // 
            textBox_dni.Location = new Point(993, 183);
            textBox_dni.Name = "textBox_dni";
            textBox_dni.Size = new Size(269, 23);
            textBox_dni.TabIndex = 23;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(993, 220);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(269, 23);
            textBox_email.TabIndex = 24;
            // 
            // textBox_resHotel
            // 
            textBox_resHotel.Location = new Point(993, 259);
            textBox_resHotel.Name = "textBox_resHotel";
            textBox_resHotel.Size = new Size(267, 23);
            textBox_resHotel.TabIndex = 31;
            // 
            // textBox_resVuelo
            // 
            textBox_resVuelo.Location = new Point(993, 300);
            textBox_resVuelo.Name = "textBox_resVuelo";
            textBox_resVuelo.Size = new Size(269, 23);
            textBox_resVuelo.TabIndex = 27;
            // 
            // button_Agregar
            // 
            button_Agregar.BackColor = Color.LightGreen;
            button_Agregar.Location = new Point(959, 374);
            button_Agregar.Name = "button_Agregar";
            button_Agregar.Size = new Size(75, 23);
            button_Agregar.TabIndex = 28;
            button_Agregar.Text = "Agregar";
            button_Agregar.UseVisualStyleBackColor = false;
            button_Agregar.Click += button_Agregar_Click;
            // 
            // button_Modificar
            // 
            button_Modificar.BackColor = Color.FromArgb(255, 255, 192);
            button_Modificar.Location = new Point(1086, 374);
            button_Modificar.Name = "button_Modificar";
            button_Modificar.Size = new Size(75, 23);
            button_Modificar.TabIndex = 29;
            button_Modificar.Text = "Modificar";
            button_Modificar.UseVisualStyleBackColor = false;
            button_Modificar.Click += button_Modificar_Click;
            // 
            // button_Eliminar
            // 
            button_Eliminar.BackColor = Color.LightCoral;
            button_Eliminar.Location = new Point(1205, 374);
            button_Eliminar.Name = "button_Eliminar";
            button_Eliminar.Size = new Size(75, 23);
            button_Eliminar.TabIndex = 30;
            button_Eliminar.Text = "Eliminar";
            button_Eliminar.UseVisualStyleBackColor = false;
            button_Eliminar.Click += button_Eliminar_Click;
            // 
            // dataGridView_usuarios
            // 
            dataGridView_usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_usuarios.Columns.AddRange(new DataGridViewColumn[] { id, nombre, apellido, dni, email, resHotel, resVuelo });
            dataGridView_usuarios.Location = new Point(35, 220);
            dataGridView_usuarios.Name = "dataGridView_usuarios";
            dataGridView_usuarios.RowTemplate.Height = 25;
            dataGridView_usuarios.Size = new Size(792, 178);
            dataGridView_usuarios.TabIndex = 32;
            dataGridView_usuarios.CellContentClick += dataGridView_usuarios_CellContentClick;
            dataGridView_usuarios.CellDoubleClick += dataGridView_usuarios_CellContentClick;
            // 
            // bienvenida
            // 
            bienvenida.AutoSize = true;
            bienvenida.Location = new Point(31, 42);
            bienvenida.Name = "bienvenida";
            bienvenida.Size = new Size(72, 15);
            bienvenida.TabIndex = 33;
            bienvenida.Text = "Bienvenido: ";
            // 
            // Bienvenida_usuario
            // 
            Bienvenida_usuario.AutoSize = true;
            Bienvenida_usuario.Location = new Point(126, 42);
            Bienvenida_usuario.Name = "Bienvenida_usuario";
            Bienvenida_usuario.Size = new Size(0, 15);
            Bienvenida_usuario.TabIndex = 34;
            // 
            // id
            // 
            id.HeaderText = "ID de usuario";
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 110;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            nombre.ReadOnly = true;
            // 
            // apellido
            // 
            apellido.HeaderText = "Apellido";
            apellido.Name = "apellido";
            apellido.ReadOnly = true;
            // 
            // dni
            // 
            dni.HeaderText = "Dni";
            dni.Name = "dni";
            dni.ReadOnly = true;
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // resHotel
            // 
            resHotel.HeaderText = "Reserva de Hotel";
            resHotel.Name = "resHotel";
            resHotel.ReadOnly = true;
            resHotel.Width = 120;
            // 
            // resVuelo
            // 
            resVuelo.HeaderText = "Reserva de Vuelo";
            resVuelo.Name = "resVuelo";
            resVuelo.ReadOnly = true;
            resVuelo.Width = 120;
            // 
            // bienvenida
            // 
            bienvenida.AutoSize = true;
            bienvenida.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point);
            bienvenida.Location = new Point(24, 33);
            bienvenida.Name = "bienvenida";
            bienvenida.Size = new Size(166, 36);
            bienvenida.TabIndex = 33;
            bienvenida.Text = "Bienvenido: ";
            // 
            // Bienvenida_usuario
            // 
            Bienvenida_usuario.AutoSize = true;
            Bienvenida_usuario.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Bienvenida_usuario.Location = new Point(206, 41);
            Bienvenida_usuario.Name = "Bienvenida_usuario";
            Bienvenida_usuario.Size = new Size(0, 25);
            Bienvenida_usuario.TabIndex = 34;
            // 
            // textBox_credito
            // 
            textBox_credito.Location = new Point(560, 170);
            textBox_credito.Name = "textBox_credito";
            textBox_credito.Size = new Size(100, 23);
            textBox_credito.TabIndex = 35;
            textBox_credito.TextChanged += textBox_credito_TextChanged;
            // 
            // label_Credito
            // 
            label_Credito.AutoSize = true;
            label_Credito.Location = new Point(560, 140);
            label_Credito.Name = "label_Credito";
            label_Credito.Size = new Size(46, 15);
            label_Credito.TabIndex = 36;
            label_Credito.Text = "Credito";
            // 
            // btn_agregarCredito
            // 
            btn_agregarCredito.Location = new Point(680, 132);
            btn_agregarCredito.Name = "btn_agregarCredito";
            btn_agregarCredito.Size = new Size(75, 23);
            btn_agregarCredito.TabIndex = 37;
            btn_agregarCredito.Text = "Agregar";
            btn_agregarCredito.UseVisualStyleBackColor = true;
            // 
            // btn_modificarCredito
            // 
            btn_modificarCredito.Location = new Point(680, 170);
            btn_modificarCredito.Name = "btn_modificarCredito";
            btn_modificarCredito.Size = new Size(75, 23);
            btn_modificarCredito.TabIndex = 38;
            btn_modificarCredito.Text = "Modificar";
            btn_modificarCredito.UseVisualStyleBackColor = true;
            btn_modificarCredito.Click += btn_modificarCredito_Click;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1385, 511);
            ControlBox = false;
            Controls.Add(btn_modificarCredito);
            Controls.Add(btn_agregarCredito);
            Controls.Add(label_Credito);
            Controls.Add(textBox_credito);
            Controls.Add(Bienvenida_usuario);
            Controls.Add(bienvenida);
            Controls.Add(dataGridView_usuarios);
            Controls.Add(textBox_resHotel);
            Controls.Add(button_Eliminar);
            Controls.Add(button_Modificar);
            Controls.Add(button_Agregar);
            Controls.Add(textBox_resVuelo);
            Controls.Add(textBox_email);
            Controls.Add(textBox_dni);
            Controls.Add(textBox_apellido);
            Controls.Add(textBox_nombre);
            Controls.Add(textBox_id);
            Controls.Add(label_reserva_vuelo);
            Controls.Add(label_reserva_hotel);
            Controls.Add(label_email);
            Controls.Add(label_dni);
            Controls.Add(label_apellido);
            Controls.Add(label_nombre);
            Controls.Add(label_id);
            Controls.Add(label_usuarios);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(mostrar_usuario);
            Name = "FormUsuario";
            Text = "FormUsuario";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_usuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button mostrar_usuario;
        private DataGridView dataGridView_usuarios;
        private DataGridView dataGridView1;
        private Button Volver_desde_usuario;
        private Label label_usuarios;
        private Label Bienvenida_usuario;
        private Label label_id;
        private Label label_nombre;
        private Label label_apellido;
        private Label label_dni;
        private Label label_email;
        private Label label_reserva_hotel;
        private Label label_reserva_vuelo;
        private TextBox textBox1;
        private TextBox textBox_id;
        private TextBox textBox_nombre;
        private TextBox textBox_apellido;
        private TextBox textBox_dni;
        private TextBox textBox_email;
        private TextBox textBox8;
        private TextBox textBox_resVuelo;
        private Button button_Agregar;
        private Button button_Modificar;
        private Button button_Eliminar;
        private TextBox textBox_resHotel;
        private DataGridView dataGridView2;
        private Label bienvenida;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn apellido;
        private DataGridViewTextBoxColumn dni;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn resHotel;
        private DataGridViewTextBoxColumn resVuelo;
        private TextBox textBox_credito;
        private Label label_Credito;
        private Button btn_agregarCredito;
        private Button btn_modificarCredito;
    }
}