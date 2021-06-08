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
            this.label2 = new System.Windows.Forms.Label();
            this.butRandomize = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAltF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTextColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picWind = new System.Windows.Forms.PictureBox();
            this.picWater = new System.Windows.Forms.PictureBox();
            this.picEarth = new System.Windows.Forms.PictureBox();
            this.picFire = new System.Windows.Forms.PictureBox();
            this.comboCrystal = new System.Windows.Forms.ListBox();
            this.comboRules = new System.Windows.Forms.ListBox();
            this.comboMod = new System.Windows.Forms.ListBox();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.clrTimerText = new System.Windows.Forms.ColorDialog();
            this.btnTmrStart = new System.Windows.Forms.Button();
            this.btnTmrReset = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblWindText = new System.Windows.Forms.Label();
            this.lblWaterText = new System.Windows.Forms.Label();
            this.lblFireText = new System.Windows.Forms.Label();
            this.lblEarthText = new System.Windows.Forms.Label();
            this.groupTimer = new System.Windows.Forms.GroupBox();
            this.buttonVoid = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEarth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFire)).BeginInit();
            this.groupTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Crystal:";
            // 
            // butRandomize
            // 
            this.butRandomize.Location = new System.Drawing.Point(132, 228);
            this.butRandomize.Name = "butRandomize";
            this.butRandomize.Size = new System.Drawing.Size(63, 23);
            this.butRandomize.TabIndex = 6;
            this.butRandomize.Text = "Roll!";
            this.butRandomize.UseVisualStyleBackColor = true;
            this.butRandomize.Click += new System.EventHandler(this.butRandomize_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Run Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Modifier:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem,
            this.rulesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeAltF4ToolStripMenuItem
            // 
            this.closeAltF4ToolStripMenuItem.Name = "closeAltF4ToolStripMenuItem";
            this.closeAltF4ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.closeAltF4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeAltF4ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeAltF4ToolStripMenuItem.Text = "Close";
            this.closeAltF4ToolStripMenuItem.Click += new System.EventHandler(this.closeAltF4ToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.layoutToolStripMenuItem,
            this.timerToolStripMenuItem1});
            this.configToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.darkToolStripMenuItem});
            this.themeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem2.Text = "Light";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // layoutToolStripMenuItem
            // 
            this.layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.squareToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.layoutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            this.layoutToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.layoutToolStripMenuItem.Text = "Layout";
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // timerToolStripMenuItem1
            // 
            this.timerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStopToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.editBackgroundColorToolStripMenuItem,
            this.editTextColorToolStripMenuItem,
            this.editShortcutsToolStripMenuItem});
            this.timerToolStripMenuItem1.Name = "timerToolStripMenuItem1";
            this.timerToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.timerToolStripMenuItem1.Text = "Timer";
            // 
            // startStopToolStripMenuItem
            // 
            this.startStopToolStripMenuItem.Name = "startStopToolStripMenuItem";
            this.startStopToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.startStopToolStripMenuItem.Text = "Start/Stop";
            this.startStopToolStripMenuItem.Click += new System.EventHandler(this.startStopToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // editBackgroundColorToolStripMenuItem
            // 
            this.editBackgroundColorToolStripMenuItem.Name = "editBackgroundColorToolStripMenuItem";
            this.editBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editBackgroundColorToolStripMenuItem.Text = "Edit Background Color";
            this.editBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.editBackgroundColorToolStripMenuItem_Click);
            // 
            // editTextColorToolStripMenuItem
            // 
            this.editTextColorToolStripMenuItem.Name = "editTextColorToolStripMenuItem";
            this.editTextColorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editTextColorToolStripMenuItem.Text = "Edit Text Color";
            this.editTextColorToolStripMenuItem.Click += new System.EventHandler(this.editTextColorToolStripMenuItem_Click);
            // 
            // editShortcutsToolStripMenuItem
            // 
            this.editShortcutsToolStripMenuItem.Name = "editShortcutsToolStripMenuItem";
            this.editShortcutsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editShortcutsToolStripMenuItem.Text = "Edit Shortcuts";
            this.editShortcutsToolStripMenuItem.Click += new System.EventHandler(this.editShortcutsToolStripMenuItem_Click);
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
            this.picWind.Location = new System.Drawing.Point(210, 25);
            this.picWind.Name = "picWind";
            this.picWind.Size = new System.Drawing.Size(200, 200);
            this.picWind.TabIndex = 25;
            this.picWind.TabStop = false;
            // 
            // picWater
            // 
            this.picWater.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWater.BackgroundImage")));
            this.picWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWater.Location = new System.Drawing.Point(410, 25);
            this.picWater.Name = "picWater";
            this.picWater.Size = new System.Drawing.Size(200, 200);
            this.picWater.TabIndex = 26;
            this.picWater.TabStop = false;
            // 
            // picEarth
            // 
            this.picEarth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picEarth.BackgroundImage")));
            this.picEarth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEarth.Location = new System.Drawing.Point(410, 225);
            this.picEarth.Name = "picEarth";
            this.picEarth.Size = new System.Drawing.Size(200, 200);
            this.picEarth.TabIndex = 28;
            this.picEarth.TabStop = false;
            // 
            // picFire
            // 
            this.picFire.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFire.BackgroundImage")));
            this.picFire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFire.Location = new System.Drawing.Point(210, 225);
            this.picFire.Name = "picFire";
            this.picFire.Size = new System.Drawing.Size(200, 200);
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
            this.comboCrystal.Location = new System.Drawing.Point(75, 27);
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
            "Classic",
            "Advance"});
            this.comboRules.Location = new System.Drawing.Point(75, 90);
            this.comboRules.Name = "comboRules";
            this.comboRules.Size = new System.Drawing.Size(120, 69);
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
            this.comboMod.Location = new System.Drawing.Point(75, 165);
            this.comboMod.Name = "comboMod";
            this.comboMod.Size = new System.Drawing.Size(120, 56);
            this.comboMod.TabIndex = 31;
            // 
            // txtTimer
            // 
            this.txtTimer.BackColor = System.Drawing.Color.Black;
            this.txtTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimer.ForeColor = System.Drawing.Color.White;
            this.txtTimer.Location = new System.Drawing.Point(210, 430);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.ReadOnly = true;
            this.txtTimer.Size = new System.Drawing.Size(400, 68);
            this.txtTimer.TabIndex = 34;
            this.txtTimer.Text = "00:00:00.00";
            this.txtTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clrTimerText
            // 
            this.clrTimerText.FullOpen = true;
            // 
            // btnTmrStart
            // 
            this.btnTmrStart.Location = new System.Drawing.Point(104, 19);
            this.btnTmrStart.Name = "btnTmrStart";
            this.btnTmrStart.Size = new System.Drawing.Size(75, 23);
            this.btnTmrStart.TabIndex = 35;
            this.btnTmrStart.Text = "Start";
            this.btnTmrStart.UseVisualStyleBackColor = true;
            this.btnTmrStart.Click += new System.EventHandler(this.btnTmrStart_Click);
            // 
            // btnTmrReset
            // 
            this.btnTmrReset.Location = new System.Drawing.Point(6, 19);
            this.btnTmrReset.Name = "btnTmrReset";
            this.btnTmrReset.Size = new System.Drawing.Size(75, 23);
            this.btnTmrReset.TabIndex = 37;
            this.btnTmrReset.Text = "Reset";
            this.btnTmrReset.UseVisualStyleBackColor = true;
            this.btnTmrReset.Click += new System.EventHandler(this.btnTmrReset_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 232);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 17);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "Krile";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblWindText
            // 
            this.lblWindText.BackColor = System.Drawing.Color.ForestGreen;
            this.lblWindText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindText.ForeColor = System.Drawing.Color.White;
            this.lblWindText.Location = new System.Drawing.Point(218, 180);
            this.lblWindText.Name = "lblWindText";
            this.lblWindText.Size = new System.Drawing.Size(184, 35);
            this.lblWindText.TabIndex = 39;
            this.lblWindText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWindText.Visible = false;
            // 
            // lblWaterText
            // 
            this.lblWaterText.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblWaterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterText.ForeColor = System.Drawing.Color.White;
            this.lblWaterText.Location = new System.Drawing.Point(418, 180);
            this.lblWaterText.Name = "lblWaterText";
            this.lblWaterText.Size = new System.Drawing.Size(184, 35);
            this.lblWaterText.TabIndex = 40;
            this.lblWaterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaterText.Visible = false;
            // 
            // lblFireText
            // 
            this.lblFireText.BackColor = System.Drawing.Color.Maroon;
            this.lblFireText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFireText.ForeColor = System.Drawing.Color.White;
            this.lblFireText.Location = new System.Drawing.Point(218, 380);
            this.lblFireText.Name = "lblFireText";
            this.lblFireText.Size = new System.Drawing.Size(184, 35);
            this.lblFireText.TabIndex = 41;
            this.lblFireText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFireText.Visible = false;
            // 
            // lblEarthText
            // 
            this.lblEarthText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblEarthText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEarthText.ForeColor = System.Drawing.Color.White;
            this.lblEarthText.Location = new System.Drawing.Point(418, 380);
            this.lblEarthText.Name = "lblEarthText";
            this.lblEarthText.Size = new System.Drawing.Size(184, 35);
            this.lblEarthText.TabIndex = 42;
            this.lblEarthText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEarthText.Visible = false;
            // 
            // groupTimer
            // 
            this.groupTimer.Controls.Add(this.btnTmrStart);
            this.groupTimer.Controls.Add(this.btnTmrReset);
            this.groupTimer.Location = new System.Drawing.Point(10, 250);
            this.groupTimer.Name = "groupTimer";
            this.groupTimer.Size = new System.Drawing.Size(185, 53);
            this.groupTimer.TabIndex = 43;
            this.groupTimer.TabStop = false;
            this.groupTimer.Text = "Timer";
            // 
            // buttonVoid
            // 
            this.buttonVoid.Location = new System.Drawing.Point(62, 228);
            this.buttonVoid.Name = "buttonVoid";
            this.buttonVoid.Size = new System.Drawing.Size(63, 23);
            this.buttonVoid.TabIndex = 44;
            this.buttonVoid.Text = "Void";
            this.buttonVoid.UseVisualStyleBackColor = true;
            this.buttonVoid.Click += new System.EventHandler(this.buttonVoid_Click);
            // 
            // FormFourJobFiesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(614, 503);
            this.Controls.Add(this.buttonVoid);
            this.Controls.Add(this.groupTimer);
            this.Controls.Add(this.lblEarthText);
            this.Controls.Add(this.lblFireText);
            this.Controls.Add(this.lblWaterText);
            this.Controls.Add(this.lblWindText);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtTimer);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.groupTimer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.ColorDialog clrTimerText;
        private System.Windows.Forms.Button btnTmrStart;
        private System.Windows.Forms.Button btnTmrReset;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblWindText;
        private System.Windows.Forms.Label lblWaterText;
        private System.Windows.Forms.Label lblFireText;
        private System.Windows.Forms.Label lblEarthText;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTextColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupTimer;
        private System.Windows.Forms.Button buttonVoid;
    }
}

