namespace ABM_Ciudad
{
    partial class MDI
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
            menuStrip1 = new MenuStrip();
            agenciaToolStripMenuItem = new ToolStripMenuItem();
            agenciaFormToolStripMenuItem = new ToolStripMenuItem();
            ciudadToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { agenciaToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1298, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // agenciaToolStripMenuItem
            // 
            agenciaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agenciaFormToolStripMenuItem, ciudadToolStripMenuItem });
            agenciaToolStripMenuItem.Name = "agenciaToolStripMenuItem";
            agenciaToolStripMenuItem.Size = new Size(91, 29);
            agenciaToolStripMenuItem.Text = "Agencia";
            agenciaToolStripMenuItem.Click += agenciaToolStripMenuItem_Click;
            // 
            // agenciaFormToolStripMenuItem
            // 
            agenciaFormToolStripMenuItem.Name = "agenciaFormToolStripMenuItem";
            agenciaFormToolStripMenuItem.Size = new Size(270, 34);
            agenciaFormToolStripMenuItem.Text = "AgenciaForm";
            agenciaFormToolStripMenuItem.Click += agenciaFormToolStripMenuItem_Click;
            // 
            // ciudadToolStripMenuItem
            // 
            ciudadToolStripMenuItem.Name = "ciudadToolStripMenuItem";
            ciudadToolStripMenuItem.Size = new Size(270, 34);
            ciudadToolStripMenuItem.Text = "Ciudad";
            ciudadToolStripMenuItem.Click += ciudadToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(187, 29);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // MDI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1298, 655);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MDI";
            Text = "Form2";
            Load += Form2_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem agenciaToolStripMenuItem;
        private ToolStripMenuItem agenciaFormToolStripMenuItem;
        private ToolStripMenuItem ciudadToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}