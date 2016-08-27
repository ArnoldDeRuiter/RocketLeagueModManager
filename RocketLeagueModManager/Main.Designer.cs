namespace RocketLeagueModManager
{
    partial class Main
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lstInstalled = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMods = new System.Windows.Forms.ComboBox();
            this.lblStockStatus = new System.Windows.Forms.Label();
            this.btnBootRL = new System.Windows.Forms.Button();
            this.cbLastDefault = new System.Windows.Forms.CheckBox();
            this.lblRunning = new System.Windows.Forms.Label();
            this.lblCheckInstalled = new System.Windows.Forms.Label();
            this.btnInstallMod = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1469, 28);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importModsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importModsToolStripMenuItem
            // 
            this.importModsToolStripMenuItem.Name = "importModsToolStripMenuItem";
            this.importModsToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.importModsToolStripMenuItem.Text = "Import mods...";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.exportToolStripMenuItem.Text = "Export...";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // usageToolStripMenuItem
            // 
            this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            this.usageToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.usageToolStripMenuItem.Text = "Usage";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // lstInstalled
            // 
            this.lstInstalled.FormattingEnabled = true;
            this.lstInstalled.ItemHeight = 16;
            this.lstInstalled.Location = new System.Drawing.Point(759, 55);
            this.lstInstalled.Margin = new System.Windows.Forms.Padding(4);
            this.lstInstalled.Name = "lstInstalled";
            this.lstInstalled.Size = new System.Drawing.Size(693, 100);
            this.lstInstalled.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Installed";
            // 
            // cmbMods
            // 
            this.cmbMods.FormattingEnabled = true;
            this.cmbMods.Location = new System.Drawing.Point(17, 54);
            this.cmbMods.Name = "cmbMods";
            this.cmbMods.Size = new System.Drawing.Size(717, 24);
            this.cmbMods.TabIndex = 5;
            this.cmbMods.SelectedIndexChanged += new System.EventHandler(this.cmbMods_SelectedIndexChanged);
            // 
            // lblStockStatus
            // 
            this.lblStockStatus.AutoSize = true;
            this.lblStockStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStockStatus.Location = new System.Drawing.Point(14, 81);
            this.lblStockStatus.Name = "lblStockStatus";
            this.lblStockStatus.Size = new System.Drawing.Size(244, 17);
            this.lblStockStatus.TabIndex = 6;
            this.lblStockStatus.Text = "Stock status: Validating hash online...";
            // 
            // btnBootRL
            // 
            this.btnBootRL.Location = new System.Drawing.Point(237, 162);
            this.btnBootRL.Name = "btnBootRL";
            this.btnBootRL.Size = new System.Drawing.Size(190, 38);
            this.btnBootRL.TabIndex = 7;
            this.btnBootRL.Text = "Launch Rocket League";
            this.btnBootRL.UseVisualStyleBackColor = true;
            this.btnBootRL.Click += new System.EventHandler(this.btnBootRL_Click);
            // 
            // cbLastDefault
            // 
            this.cbLastDefault.AutoSize = true;
            this.cbLastDefault.Location = new System.Drawing.Point(17, 101);
            this.cbLastDefault.Name = "cbLastDefault";
            this.cbLastDefault.Size = new System.Drawing.Size(410, 21);
            this.cbLastDefault.TabIndex = 8;
            this.cbLastDefault.Text = "Default the mods box to last selected mod. (Instead of stock)";
            this.cbLastDefault.UseVisualStyleBackColor = true;
            this.cbLastDefault.CheckedChanged += new System.EventHandler(this.cbLastDefault_CheckedChanged);
            // 
            // lblRunning
            // 
            this.lblRunning.AutoSize = true;
            this.lblRunning.Location = new System.Drawing.Point(433, 183);
            this.lblRunning.Name = "lblRunning";
            this.lblRunning.Size = new System.Drawing.Size(73, 17);
            this.lblRunning.TabIndex = 9;
            this.lblRunning.Text = "Running...";
            this.lblRunning.Visible = false;
            // 
            // lblCheckInstalled
            // 
            this.lblCheckInstalled.AutoSize = true;
            this.lblCheckInstalled.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCheckInstalled.Location = new System.Drawing.Point(755, 159);
            this.lblCheckInstalled.Name = "lblCheckInstalled";
            this.lblCheckInstalled.Size = new System.Drawing.Size(167, 17);
            this.lblCheckInstalled.TabIndex = 10;
            this.lblCheckInstalled.Text = "Installed files: Checking...";
            // 
            // btnInstallMod
            // 
            this.btnInstallMod.Location = new System.Drawing.Point(586, 84);
            this.btnInstallMod.Name = "btnInstallMod";
            this.btnInstallMod.Size = new System.Drawing.Size(148, 38);
            this.btnInstallMod.TabIndex = 11;
            this.btnInstallMod.Text = "Install";
            this.btnInstallMod.UseVisualStyleBackColor = true;
            this.btnInstallMod.Click += new System.EventHandler(this.btnInstallMod_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(1262, 162);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(190, 38);
            this.btnRestore.TabIndex = 12;
            this.btnRestore.Text = "Restore last installation";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 211);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnInstallMod);
            this.Controls.Add(this.lblCheckInstalled);
            this.Controls.Add(this.lblRunning);
            this.Controls.Add(this.cbLastDefault);
            this.Controls.Add(this.btnBootRL);
            this.Controls.Add(this.lblStockStatus);
            this.Controls.Add(this.cmbMods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstInstalled);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Rocket League Mod Manager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox lstInstalled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMods;
        private System.Windows.Forms.Label lblStockStatus;
        private System.Windows.Forms.Button btnBootRL;
        private System.Windows.Forms.CheckBox cbLastDefault;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.Label lblCheckInstalled;
        private System.Windows.Forms.Button btnInstallMod;
        private System.Windows.Forms.ToolStripMenuItem importModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Button btnRestore;
    }
}

