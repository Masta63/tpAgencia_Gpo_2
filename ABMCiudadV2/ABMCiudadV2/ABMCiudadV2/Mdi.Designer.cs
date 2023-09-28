namespace ABMCiudadV2
{
	partial class Mdi
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			agenciaToolStripMenuItem = new ToolStripMenuItem();
			ciudadABMToolStripMenuItem = new ToolStripMenuItem();
			reportesABMToolStripMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(24, 24);
			menuStrip1.Items.AddRange(new ToolStripItem[] { agenciaToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1057, 33);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// agenciaToolStripMenuItem
			// 
			agenciaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ciudadABMToolStripMenuItem, reportesABMToolStripMenuItem });
			agenciaToolStripMenuItem.Name = "agenciaToolStripMenuItem";
			agenciaToolStripMenuItem.Size = new Size(91, 29);
			agenciaToolStripMenuItem.Text = "Agencia";
			// 
			// ciudadABMToolStripMenuItem
			// 
			ciudadABMToolStripMenuItem.Name = "ciudadABMToolStripMenuItem";
			ciudadABMToolStripMenuItem.Size = new Size(270, 34);
			ciudadABMToolStripMenuItem.Text = "Ciudad ABM";
			ciudadABMToolStripMenuItem.Click += ciudadABMToolStripMenuItem_Click;
			// 
			// reportesABMToolStripMenuItem
			// 
			reportesABMToolStripMenuItem.Name = "reportesABMToolStripMenuItem";
			reportesABMToolStripMenuItem.Size = new Size(270, 34);
			reportesABMToolStripMenuItem.Text = "Reportes ABM";
			reportesABMToolStripMenuItem.Click += reportesABMToolStripMenuItem_Click;
			// 
			// Mdi
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1057, 492);
			Controls.Add(menuStrip1);
			IsMdiContainer = true;
			MainMenuStrip = menuStrip1;
			Name = "Mdi";
			Text = "Form1";
			Load += Mdi_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem agenciaToolStripMenuItem;
		private ToolStripMenuItem ciudadABMToolStripMenuItem;
		private ToolStripMenuItem reportesABMToolStripMenuItem;
	}
}