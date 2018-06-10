namespace FourJobFiesta
{
    partial class FormFourJobFiesta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFourJobFiesta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butRandomize = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAltF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTextColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picWind = new System.Windows.Forms.PictureBox();
            this.picWater = new System.Windows.Forms.PictureBox();
            this.picEarth = new System.Windows.Forms.PictureBox();
            this.picFire = new System.Windows.Forms.PictureBox();
            this.comboCrystal = new System.Windows.Forms.ListBox();
            this.comboRules = new System.Windows.Forms.ListBox();
            this.comboMod = new System.Windows.Forms.ListBox();
            this.labRoll = new System.Windows.Forms.TextBox();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.clrTimerText = new System.Windows.Forms.ColorDialog();
            this.btnTmrStart = new System.Windows.Forms.Button();
            this.btnTmrStop = new System.Windows.Forms.Button();
            this.btnTmrReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEarth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFire)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Roll:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Crystal:";
            // 
            // butRandomize
            // 
            this.butRandomize.Location = new System.Drawing.Point(75, 245);
            this.butRandomize.Name = "butRandomize";
            this.butRandomize.Size = new System.Drawing.Size(75, 23);
            this.butRandomize.TabIndex = 6;
            this.butRandomize.Text = "Roll!";
            this.butRandomize.UseVisualStyleBackColor = true;
            this.butRandomize.Click += new System.EventHandler(this.butRandomize_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Run Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Modifier:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.timerToolStripMenuItem,
            this.rulesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeAltF4ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // closeAltF4ToolStripMenuItem
            // 
            this.closeAltF4ToolStripMenuItem.Name = "closeAltF4ToolStripMenuItem";
            this.closeAltF4ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.closeAltF4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeAltF4ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.closeAltF4ToolStripMenuItem.Text = "Close";
            this.closeAltF4ToolStripMenuItem.Click += new System.EventHandler(this.closeAltF4ToolStripMenuItem_Click);
            // 
            // timerToolStripMenuItem
            // 
            this.timerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTextColorToolStripMenuItem,
            this.editBackgroundColorToolStripMenuItem});
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.timerToolStripMenuItem.Text = "Timer";
            // 
            // editTextColorToolStripMenuItem
            // 
            this.editTextColorToolStripMenuItem.Name = "editTextColorToolStripMenuItem";
            this.editTextColorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editTextColorToolStripMenuItem.Text = "Edit Text Color";
            this.editTextColorToolStripMenuItem.Click += new System.EventHandler(this.editTextColorToolStripMenuItem_Click);
            // 
            // editBackgroundColorToolStripMenuItem
            // 
            this.editBackgroundColorToolStripMenuItem.Name = "editBackgroundColorToolStripMenuItem";
            this.editBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editBackgroundColorToolStripMenuItem.Text = "Edit Background Color";
            this.editBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.editBackgroundColorToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // picWind
            // 
            this.picWind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWind.BackgroundImage")));
            this.picWind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWind.Location = new System.Drawing.Point(210, 27);
            this.picWind.Name = "picWind";
            this.picWind.Size = new System.Drawing.Size(255, 255);
            this.picWind.TabIndex = 25;
            this.picWind.TabStop = false;
            // 
            // picWater
            // 
            this.picWater.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWater.BackgroundImage")));
            this.picWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWater.Location = new System.Drawing.Point(464, 27);
            this.picWater.Name = "picWater";
            this.picWater.Size = new System.Drawing.Size(255, 255);
            this.picWater.TabIndex = 26;
            this.picWater.TabStop = false;
            // 
            // picEarth
            // 
            this.picEarth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picEarth.BackgroundImage")));
            this.picEarth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEarth.Location = new System.Drawing.Point(464, 281);
            this.picEarth.Name = "picEarth";
            this.picEarth.Size = new System.Drawing.Size(255, 255);
            this.picEarth.TabIndex = 28;
            this.picEarth.TabStop = false;
            // 
            // picFire
            // 
            this.picFire.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFire.BackgroundImage")));
            this.picFire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFire.Location = new System.Drawing.Point(210, 281);
            this.picFire.Name = "picFire";
            this.picFire.Size = new System.Drawing.Size(255, 255);
            this.picFire.TabIndex = 27;
            this.picFire.TabStop = false;
            // 
            // comboCrystal
            // 
            this.comboCrystal.FormattingEnabled = true;
            this.comboCrystal.Items.AddRange(new object[] {
            "Wind",
            "Water",
            "Fire",
            "Earth"});
            this.comboCrystal.Location = new System.Drawing.Point(75, 57);
            this.comboCrystal.Name = "comboCrystal";
            this.comboCrystal.Size = new System.Drawing.Size(120, 56);
            this.comboCrystal.TabIndex = 29;
            // 
            // comboRules
            // 
            this.comboRules.FormattingEnabled = true;
            this.comboRules.Items.AddRange(new object[] {
            "Normal",
            "Team 750",
            "Team No 750",
            "Classic"});
            this.comboRules.Location = new System.Drawing.Point(75, 120);
            this.comboRules.Name = "comboRules";
            this.comboRules.Size = new System.Drawing.Size(120, 56);
            this.comboRules.TabIndex = 30;
            // 
            // comboMod
            // 
            this.comboMod.FormattingEnabled = true;
            this.comboMod.Items.AddRange(new object[] {
            "None",
            "Random",
            "Chaos",
            "Pure Chaos"});
            this.comboMod.Location = new System.Drawing.Point(75, 183);
            this.comboMod.Name = "comboMod";
            this.comboMod.Size = new System.Drawing.Size(120, 56);
            this.comboMod.TabIndex = 31;
            // 
            // labRoll
            // 
            this.labRoll.Enabled = false;
            this.labRoll.Location = new System.Drawing.Point(75, 31);
            this.labRoll.Name = "labRoll";
            this.labRoll.Size = new System.Drawing.Size(120, 20);
            this.labRoll.TabIndex = 32;
            // 
            // txtTimer
            // 
            this.txtTimer.BackColor = System.Drawing.Color.Black;
            this.txtTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimer.ForeColor = System.Drawing.Color.White;
            this.txtTimer.Location = new System.Drawing.Point(210, 542);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.ReadOnly = true;
            this.txtTimer.Size = new System.Drawing.Size(509, 83);
            this.txtTimer.TabIndex = 34;
            this.txtTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clrTimerText
            // 
            this.clrTimerText.FullOpen = true;
            // 
            // btnTmrStart
            // 
            this.btnTmrStart.Location = new System.Drawing.Point(120, 542);
            this.btnTmrStart.Name = "btnTmrStart";
            this.btnTmrStart.Size = new System.Drawing.Size(75, 23);
            this.btnTmrStart.TabIndex = 35;
            this.btnTmrStart.Text = "Start";
            this.btnTmrStart.UseVisualStyleBackColor = true;
            this.btnTmrStart.Click += new System.EventHandler(this.btnTmrStart_Click);
            // 
            // btnTmrStop
            // 
            this.btnTmrStop.Location = new System.Drawing.Point(10, 542);
            this.btnTmrStop.Name = "btnTmrStop";
            this.btnTmrStop.Size = new System.Drawing.Size(75, 23);
            this.btnTmrStop.TabIndex = 36;
            this.btnTmrStop.Text = "Stop";
            this.btnTmrStop.UseVisualStyleBackColor = true;
            this.btnTmrStop.Click += new System.EventHandler(this.btnTmrStop_Click);
            // 
            // btnTmrReset
            // 
            this.btnTmrReset.Location = new System.Drawing.Point(10, 602);
            this.btnTmrReset.Name = "btnTmrReset";
            this.btnTmrReset.Size = new System.Drawing.Size(75, 23);
            this.btnTmrReset.TabIndex = 37;
            this.btnTmrReset.Text = "Reset";
            this.btnTmrReset.UseVisualStyleBackColor = true;
            this.btnTmrReset.Click += new System.EventHandler(this.btnTmrReset_Click);
            // 
            // FormFourJobFiesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 631);
            this.Controls.Add(this.btnTmrReset);
            this.Controls.Add(this.btnTmrStop);
            this.Controls.Add(this.btnTmrStart);
            this.Controls.Add(this.txtTimer);
            this.Controls.Add(this.labRoll);
            this.Controls.Add(this.comboMod);
            this.Controls.Add(this.comboRules);
            this.Controls.Add(this.comboCrystal);
            this.Controls.Add(this.picEarth);
            this.Controls.Add(this.picFire);
            this.Controls.Add(this.picWater);
            this.Controls.Add(this.picWind);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butRandomize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormFourJobFiesta";
            this.Text = "Four Job Fiesta";
            this.Load += new System.EventHandler(this.FormFourJobFiesta_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEarth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRandomize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAltF4ToolStripMenuItem;
        private System.Windows.Forms.PictureBox picWind;
        private System.Windows.Forms.PictureBox picWater;
        private System.Windows.Forms.PictureBox picEarth;
        private System.Windows.Forms.PictureBox picFire;
        private System.Windows.Forms.ListBox comboCrystal;
        private System.Windows.Forms.ListBox comboRules;
        private System.Windows.Forms.ListBox comboMod;
        private System.Windows.Forms.TextBox labRoll;
        private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTextColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.ColorDialog clrTimerText;
        private System.Windows.Forms.Button btnTmrStart;
        private System.Windows.Forms.Button btnTmrStop;
        private System.Windows.Forms.Button btnTmrReset;
    }
}

