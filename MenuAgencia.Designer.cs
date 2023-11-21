namespace tpAgencia_Gpo_2
{
    partial class MenuAgencia
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
            Agencia.cerrarContexto();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { altasToolStripMenuItem, opcionesUsuarioComunToolStripMenuItem, cerrarSesionToolStripMenuItem });
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
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
    }
}