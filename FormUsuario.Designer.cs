﻿namespace tpAgencia_Gpo_2
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
            this.dataGridView_usuarios = new DataGridView();
            Volver_desde_usuario = new Button();
            label_usuarios = new Label();
            label_id = new Label();
            label_nombre = new Label();
            label_apellido = new Label();
            label_dni = new Label();
            label_email = new Label();
            label_contraseña = new Label();
            label_reserva_hotel = new Label();
            label_reserva_vuelo = new Label();
            textBox_id = new TextBox();
            textBox_nombre = new TextBox();
            textBox_apellido = new TextBox();
            textBox_dni = new TextBox();
            textBox_email = new TextBox();
            textBox_contraseña = new TextBox();
            this.textBox_resHotel = new TextBox();
            textBox_resVuelo = new TextBox();
            button_Agregar = new Button();
            button_Modificar = new Button();
            button_Eliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView_usuarios).BeginInit();
            SuspendLayout();
            // 
            // mostrar_usuario
            // 
            mostrar_usuario.Location = new Point(25, 136);
            mostrar_usuario.Margin = new Padding(2);
            mostrar_usuario.Name = "mostrar_usuario";
            mostrar_usuario.Size = new Size(181, 32);
            mostrar_usuario.TabIndex = 6;
            mostrar_usuario.Text = "Mostrar / Actualizar Usuarios";
            mostrar_usuario.UseVisualStyleBackColor = true;
            // 
            // dataGridView_usuarios
            // 
            this.dataGridView_usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_usuarios.Location = new Point(25, 184);
            this.dataGridView_usuarios.Name = "dataGridView_usuarios";
            this.dataGridView_usuarios.RowTemplate.Height = 25;
            this.dataGridView_usuarios.Size = new Size(846, 135);
            this.dataGridView_usuarios.TabIndex = 7;
            // 
            // Volver_desde_usuario
            // 
            Volver_desde_usuario.Location = new Point(29, 335);
            Volver_desde_usuario.Name = "Volver_desde_usuario";
            Volver_desde_usuario.Size = new Size(75, 23);
            Volver_desde_usuario.TabIndex = 8;
            Volver_desde_usuario.Text = "Volver";
            Volver_desde_usuario.UseVisualStyleBackColor = true;
            // 
            // label_usuarios
            // 
            label_usuarios.AutoSize = true;
            label_usuarios.Location = new Point(671, 33);
            label_usuarios.Name = "label_usuarios";
            label_usuarios.Size = new Size(52, 15);
            label_usuarios.TabIndex = 9;
            label_usuarios.Text = "Usuarios";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(1044, 62);
            label_id.Name = "label_id";
            label_id.Size = new Size(17, 15);
            label_id.TabIndex = 11;
            label_id.Text = "id";
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Location = new Point(1010, 99);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(51, 15);
            label_nombre.TabIndex = 12;
            label_nombre.Text = "Nombre";
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Location = new Point(1010, 134);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(51, 15);
            label_apellido.TabIndex = 13;
            label_apellido.Text = "Apellido";
            // 
            // label_dni
            // 
            label_dni.AutoSize = true;
            label_dni.Location = new Point(1036, 165);
            label_dni.Name = "label_dni";
            label_dni.Size = new Size(25, 15);
            label_dni.TabIndex = 14;
            label_dni.Text = "Dni";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Location = new Point(1025, 207);
            label_email.Name = "label_email";
            label_email.Size = new Size(36, 15);
            label_email.TabIndex = 15;
            label_email.Text = "Email";
            // 
            // label_contraseña
            // 
            label_contraseña.AutoSize = true;
            label_contraseña.Location = new Point(994, 247);
            label_contraseña.Name = "label_contraseña";
            label_contraseña.Size = new Size(67, 15);
            label_contraseña.TabIndex = 16;
            label_contraseña.Text = "Contraseña";
            // 
            // label_reserva_hotel
            // 
            label_reserva_hotel.AutoSize = true;
            label_reserva_hotel.Location = new Point(982, 289);
            label_reserva_hotel.Name = "label_reserva_hotel";
            label_reserva_hotel.Size = new Size(79, 15);
            label_reserva_hotel.TabIndex = 17;
            label_reserva_hotel.Text = "Reserva Hotel";
            // 
            // label_reserva_vuelo
            // 
            label_reserva_vuelo.AutoSize = true;
            label_reserva_vuelo.Location = new Point(981, 330);
            label_reserva_vuelo.Name = "label_reserva_vuelo";
            label_reserva_vuelo.Size = new Size(80, 15);
            label_reserva_vuelo.TabIndex = 18;
            label_reserva_vuelo.Text = "Reserva Vuelo";
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(1077, 54);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(269, 23);
            textBox_id.TabIndex = 20;
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(1077, 91);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(269, 23);
            textBox_nombre.TabIndex = 21;
            // 
            // textBox_apellido
            // 
            textBox_apellido.Location = new Point(1077, 126);
            textBox_apellido.Name = "textBox_apellido";
            textBox_apellido.Size = new Size(269, 23);
            textBox_apellido.TabIndex = 22;
            // 
            // textBox_dni
            // 
            textBox_dni.Location = new Point(1077, 162);
            textBox_dni.Name = "textBox_dni";
            textBox_dni.Size = new Size(269, 23);
            textBox_dni.TabIndex = 23;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(1077, 199);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(269, 23);
            textBox_email.TabIndex = 24;
            // 
            // textBox_contraseña
            // 
            textBox_contraseña.Location = new Point(1077, 239);
            textBox_contraseña.Name = "textBox_contraseña";
            textBox_contraseña.Size = new Size(269, 23);
            textBox_contraseña.TabIndex = 25;
            // 
            // textBox_resHotel
            // 
            this.textBox_resHotel.Location = new Point(1077, 281);
            this.textBox_resHotel.Name = "textBox_resHotel";
            this.textBox_resHotel.Size = new Size(269, 23);
            this.textBox_resHotel.TabIndex = 26;
            // 
            // textBox_resVuelo
            // 
            textBox_resVuelo.Location = new Point(1077, 322);
            textBox_resVuelo.Name = "textBox_resVuelo";
            textBox_resVuelo.Size = new Size(269, 23);
            textBox_resVuelo.TabIndex = 27;
            // 
            // button_Agregar
            // 
            button_Agregar.Location = new Point(1025, 375);
            button_Agregar.Name = "button_Agregar";
            button_Agregar.Size = new Size(75, 23);
            button_Agregar.TabIndex = 28;
            button_Agregar.Text = "Agregar";
            button_Agregar.UseVisualStyleBackColor = true;
            // 
            // button_Modificar
            // 
            button_Modificar.Location = new Point(1152, 375);
            button_Modificar.Name = "button_Modificar";
            button_Modificar.Size = new Size(75, 23);
            button_Modificar.TabIndex = 29;
            button_Modificar.Text = "Modificar";
            button_Modificar.UseVisualStyleBackColor = true;
            // 
            // button_Eliminar
            // 
            button_Eliminar.Location = new Point(1271, 375);
            button_Eliminar.Name = "button_Eliminar";
            button_Eliminar.Size = new Size(75, 23);
            button_Eliminar.TabIndex = 30;
            button_Eliminar.Text = "Eliminar";
            button_Eliminar.UseVisualStyleBackColor = true;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1385, 451);
            Controls.Add(button_Eliminar);
            Controls.Add(button_Modificar);
            Controls.Add(button_Agregar);
            Controls.Add(textBox_resVuelo);
            Controls.Add(this.textBox_resHotel);
            Controls.Add(textBox_contraseña);
            Controls.Add(textBox_email);
            Controls.Add(textBox_dni);
            Controls.Add(textBox_apellido);
            Controls.Add(textBox_nombre);
            Controls.Add(textBox_id);
            Controls.Add(label_reserva_vuelo);
            Controls.Add(label_reserva_hotel);
            Controls.Add(label_contraseña);
            Controls.Add(label_email);
            Controls.Add(label_dni);
            Controls.Add(label_apellido);
            Controls.Add(label_nombre);
            Controls.Add(label_id);
            Controls.Add(label_usuarios);
            Controls.Add(Volver_desde_usuario);
            Controls.Add(this.dataGridView_usuarios);
            Controls.Add(mostrar_usuario);
            Name = "FormUsuario";
            Text = "FormUsuario";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView_usuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button mostrar_usuario;
        private DataGridView dataGridView1;
        private Button Volver_desde_usuario;
        private Label label_usuarios;
        private Label label1;
        private Label label_id;
        private Label label_nombre;
        private Label label_apellido;
        private Label label_dni;
        private Label label_email;
        private Label label_contraseña;
        private Label label_reserva_hotel;
        private Label label_reserva_vuelo;
        private TextBox textBox1;
        private TextBox textBox_id;
        private TextBox textBox_nombre;
        private TextBox textBox_apellido;
        private TextBox textBox_dni;
        private TextBox textBox_email;
        private TextBox textBox_contraseña;
        private TextBox textBox8;
        private TextBox textBox_resVuelo;
        private Button button_Agregar;
        private Button button_Modificar;
        private Button button_Eliminar;
    }
}