namespace tpAgencia_Gpo_2
{
    partial class MenuAgenciaAdm
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            altasToolStripMenuItem = new ToolStripMenuItem();
            hotelesToolStripMenuItem = new ToolStripMenuItem();
            personasToolStripMenuItem = new ToolStripMenuItem();
            ciudadesToolStripMenuItem = new ToolStripMenuItem();
            opcionesUsuarioComunToolStripMenuItem = new ToolStripMenuItem();
            miCreditoToolStripMenuItem = new ToolStripMenuItem();
            cargarCreditoToolStripMenuItem = new ToolStripMenuItem();
            misreservashotelesToolStripMenuItem = new ToolStripMenuItem();
            misreservasvuelosToolStripMenuItem = new ToolStripMenuItem();
            misvuelosencualviajeToolStripMenuItem = new ToolStripMenuItem();
            misHotelesquevisiteToolStripMenuItem = new ToolStripMenuItem();
            aBMToolStripMenuItem = new ToolStripMenuItem();
            vuelosToolStripMenuItem = new ToolStripMenuItem();
            hotelesToolStripMenuItem1 = new ToolStripMenuItem();
            ciudadesToolStripMenuItem1 = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { altasToolStripMenuItem, opcionesUsuarioComunToolStripMenuItem, aBMToolStripMenuItem, cerrarSesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(959, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // altasToolStripMenuItem
            // 
            altasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hotelesToolStripMenuItem, personasToolStripMenuItem, ciudadesToolStripMenuItem });
            altasToolStripMenuItem.Name = "altasToolStripMenuItem";
            altasToolStripMenuItem.Size = new Size(132, 20);
            altasToolStripMenuItem.Text = "Consultas - Opciones";
            altasToolStripMenuItem.Click += altasToolStripMenuItem_Click;
            // 
            // hotelesToolStripMenuItem
            // 
            hotelesToolStripMenuItem.Name = "hotelesToolStripMenuItem";
            hotelesToolStripMenuItem.Size = new Size(123, 22);
            hotelesToolStripMenuItem.Text = "Hoteles";
            hotelesToolStripMenuItem.Click += hotelesToolStripMenuItem_Click;
            // 
            // personasToolStripMenuItem
            // 
            personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            personasToolStripMenuItem.Size = new Size(123, 22);
            personasToolStripMenuItem.Text = "Vuelos";
            personasToolStripMenuItem.Click += personasToolStripMenuItem_Click;
            // 
            // ciudadesToolStripMenuItem
            // 
            ciudadesToolStripMenuItem.Name = "ciudadesToolStripMenuItem";
            ciudadesToolStripMenuItem.Size = new Size(123, 22);
            ciudadesToolStripMenuItem.Text = "Ciudades";
            ciudadesToolStripMenuItem.Click += ciudadesToolStripMenuItem_Click;
            // 
            // opcionesUsuarioComunToolStripMenuItem
            // 
            opcionesUsuarioComunToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCreditoToolStripMenuItem, misreservashotelesToolStripMenuItem, misreservasvuelosToolStripMenuItem, misvuelosencualviajeToolStripMenuItem, misHotelesquevisiteToolStripMenuItem });
            opcionesUsuarioComunToolStripMenuItem.Name = "opcionesUsuarioComunToolStripMenuItem";
            opcionesUsuarioComunToolStripMenuItem.Size = new Size(171, 20);
            opcionesUsuarioComunToolStripMenuItem.Text = "Opciones - Usuario - Comun";
            opcionesUsuarioComunToolStripMenuItem.Click += opcionesUsuarioComunToolStripMenuItem_Click;
            // 
            // miCreditoToolStripMenuItem
            // 
            miCreditoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarCreditoToolStripMenuItem });
            miCreditoToolStripMenuItem.Name = "miCreditoToolStripMenuItem";
            miCreditoToolStripMenuItem.Size = new Size(203, 22);
            miCreditoToolStripMenuItem.Text = "Mi credito";
            // 
            // cargarCreditoToolStripMenuItem
            // 
            cargarCreditoToolStripMenuItem.Name = "cargarCreditoToolStripMenuItem";
            cargarCreditoToolStripMenuItem.Size = new Size(149, 22);
            cargarCreditoToolStripMenuItem.Text = "Cargar credito";
            cargarCreditoToolStripMenuItem.Click += cargarCreditoToolStripMenuItem_Click;
            // 
            // misreservashotelesToolStripMenuItem
            // 
            misreservashotelesToolStripMenuItem.Name = "misreservashotelesToolStripMenuItem";
            misreservashotelesToolStripMenuItem.Size = new Size(203, 22);
            misreservashotelesToolStripMenuItem.Text = "Mis reservas hoteles";
            misreservashotelesToolStripMenuItem.Click += misreservashotelesToolStripMenuItem_Click;
            // 
            // misreservasvuelosToolStripMenuItem
            // 
            misreservasvuelosToolStripMenuItem.Name = "misreservasvuelosToolStripMenuItem";
            misreservasvuelosToolStripMenuItem.Size = new Size(203, 22);
            misreservasvuelosToolStripMenuItem.Text = "Mis reservas vuelos";
            misreservasvuelosToolStripMenuItem.Click += misreservasvuelosToolStripMenuItem_Click;
            // 
            // misvuelosencualviajeToolStripMenuItem
            // 
            misvuelosencualviajeToolStripMenuItem.Name = "misvuelosencualviajeToolStripMenuItem";
            misvuelosencualviajeToolStripMenuItem.Size = new Size(203, 22);
            misvuelosencualviajeToolStripMenuItem.Text = "Mis vuelos(en cual viaje)";
            misvuelosencualviajeToolStripMenuItem.Click += misvuelosencualviajeToolStripMenuItem_Click;
            // 
            // misHotelesquevisiteToolStripMenuItem
            // 
            misHotelesquevisiteToolStripMenuItem.Name = "misHotelesquevisiteToolStripMenuItem";
            misHotelesquevisiteToolStripMenuItem.Size = new Size(203, 22);
            misHotelesquevisiteToolStripMenuItem.Text = "Mis Hoteles(que visite)";
            misHotelesquevisiteToolStripMenuItem.Click += misHotelesquevisiteToolStripMenuItem_Click;
            // 
            // aBMToolStripMenuItem
            // 
            aBMToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vuelosToolStripMenuItem, hotelesToolStripMenuItem1, ciudadesToolStripMenuItem1, usuariosToolStripMenuItem });
            aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            aBMToolStripMenuItem.Size = new Size(45, 20);
            aBMToolStripMenuItem.Text = "ABM";
            // 
            // vuelosToolStripMenuItem
            // 
            vuelosToolStripMenuItem.Name = "vuelosToolStripMenuItem";
            vuelosToolStripMenuItem.Size = new Size(180, 22);
            vuelosToolStripMenuItem.Text = "Vuelos";
            vuelosToolStripMenuItem.Click += vuelosToolStripMenuItem_Click;
            // 
            // hotelesToolStripMenuItem1
            // 
            hotelesToolStripMenuItem1.Name = "hotelesToolStripMenuItem1";
            hotelesToolStripMenuItem1.Size = new Size(180, 22);
            hotelesToolStripMenuItem1.Text = "Hoteles";
            hotelesToolStripMenuItem1.Click += hotelesToolStripMenuItem1_Click_1;
            // 
            // ciudadesToolStripMenuItem1
            // 
            ciudadesToolStripMenuItem1.Name = "ciudadesToolStripMenuItem1";
            ciudadesToolStripMenuItem1.Size = new Size(180, 22);
            ciudadesToolStripMenuItem1.Text = "Ciudades";
            ciudadesToolStripMenuItem1.Click += ciudadesToolStripMenuItem1_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(180, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // reservasToolStripMenuItem
            //
            /* revisar este error
            reservasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reservarVueloToolStripMenuItem, reservarHotelToolStripMenuItem });
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(64, 20);
            reservasToolStripMenuItem.Text = "Reservas";
            // 
            // reservarVueloToolStripMenuItem
            // 
            reservarVueloToolStripMenuItem.Name = "reservarVueloToolStripMenuItem";
            reservarVueloToolStripMenuItem.Size = new Size(150, 22);
            reservarVueloToolStripMenuItem.Text = "Reservar vuelo";
            // 
            // reservarHotelToolStripMenuItem
            // 
            reservarHotelToolStripMenuItem.Name = "reservarHotelToolStripMenuItem";
            reservarHotelToolStripMenuItem.Size = new Size(150, 22);
            reservarHotelToolStripMenuItem.Text = "Reservar Hotel";
            reservarHotelToolStripMenuItem.Click += reservarHotelToolStripMenuItem_Click;
            // 
            */
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(87, 20);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // MenuAgencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 449);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuAgencia";
            Text = "MenuAgencia";
            Load += MenuAgencia_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem altasToolStripMenuItem;
        private ToolStripMenuItem hotelesToolStripMenuItem;
        private ToolStripMenuItem personasToolStripMenuItem;
        private ToolStripMenuItem ciudadesToolStripMenuItem;
        private ToolStripMenuItem opcionesUsuarioComunToolStripMenuItem;
        private ToolStripMenuItem miCreditoToolStripMenuItem;
        private ToolStripMenuItem cargarCreditoToolStripMenuItem;
        private ToolStripMenuItem misreservashotelesToolStripMenuItem;
        private ToolStripMenuItem misreservasvuelosToolStripMenuItem;
        private ToolStripMenuItem misvuelosencualviajeToolStripMenuItem;
        private ToolStripMenuItem misHotelesquevisiteToolStripMenuItem;
        private ToolStripMenuItem aBMToolStripMenuItem;
        private ToolStripMenuItem vuelosToolStripMenuItem;
        private ToolStripMenuItem hotelesToolStripMenuItem1;
        private ToolStripMenuItem ciudadesToolStripMenuItem1;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
    }
}