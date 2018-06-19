using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace FourJobFiesta
{
    public partial class FormFourJobFiesta : Form
    {
        public Timer timer = new Timer();

        Stopwatch sw = new Stopwatch();

        public int min { get; set; }
        public int roll { get; set; }

        public string SaveFile { get; set; }

        public static TimeSpan SavedTime { get; set; }
        public static TimeSpan TimerTick { get; set; }
        
        public Random r = new Random();

        public List<string> allJobs = new List<string>();
        public List<string> classicJobs = new List<string>();
        public List<string> sevenFiftyJobs = new List<string>();
        public List<string> no750Jobs = new List<string>();

        public const string IMG_FORMAT_STR = "Images/{0}.png";
        public const string TIMER_FORMAT = @"hh\:mm\:ss\.ff";

        public FormFourJobFiesta()
        {
            InitializeComponent();

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("TimerBackgroundColor"))
            {
                string color = Program.ConfigFile.AppSettings.Settings["TimerBackgroundColor"].Value;

                if (!string.IsNullOrEmpty(color))
                    txtTimer.BackColor = Color.FromName(color);
            }

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("TimerTextColor"))
            {
                string color = Program.ConfigFile.AppSettings.Settings["TimerTextColor"].Value;

                if (!string.IsNullOrEmpty(color))
                    txtTimer.ForeColor = Color.FromName(color);
            }

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("Theme"))
            {
                string theme = Program.ConfigFile.AppSettings.Settings["Theme"].Value.ToLower();

                if (theme == "dark")
                {
                    darkToolStripMenuItem_Click(null, null);
                }
                else if (theme == "light")
                {
                    toolStripMenuItem2_Click(null, null);
                }
            }

            TimerTick = TimeSpan.FromMilliseconds(10);
            SavedTime = new TimeSpan();

            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();

            txtTimer.Text = SavedTime.ToString(TIMER_FORMAT);
            
            allJobs.Add("Knight");
            allJobs.Add("Monk");
            allJobs.Add("Thief");
            allJobs.Add("Black Mage");
            allJobs.Add("White Mage");
            allJobs.Add("Blue Mage");
            allJobs.Add("Red Mage");
            allJobs.Add("Time Mage");
            allJobs.Add("Summoner");
            allJobs.Add("Berserker");
            allJobs.Add("Mystic Knight");
            allJobs.Add("Beastmaster");
            allJobs.Add("Geomancer");
            allJobs.Add("Ninja");
            allJobs.Add("Ranger");
            allJobs.Add("Bard");
            allJobs.Add("Dragoon");
            allJobs.Add("Dancer");
            allJobs.Add("Samurai");
            allJobs.Add("Chemist");
            allJobs.Add("Freelancer");
            allJobs.Add("Mime");

            classicJobs.Add("Knight");
            classicJobs.Add("Monk");
            classicJobs.Add("Thief");
            classicJobs.Add("Black Mage");
            classicJobs.Add("White Mage");
            classicJobs.Add("Red Mage");

            sevenFiftyJobs.Add("Black Mage");
            sevenFiftyJobs.Add("White Mage");
            sevenFiftyJobs.Add("Blue Mage");
            sevenFiftyJobs.Add("Red Mage");
            sevenFiftyJobs.Add("Time Mage");
            sevenFiftyJobs.Add("Summoner");
            sevenFiftyJobs.Add("Geomancer");
            sevenFiftyJobs.Add("Bard");
            sevenFiftyJobs.Add("Chemist");
            sevenFiftyJobs.Add("Dancer");
            sevenFiftyJobs.Add("Freelancer");

            no750Jobs.Add("Knight");
            no750Jobs.Add("Monk");
            no750Jobs.Add("Thief");
            no750Jobs.Add("Berserker");
            no750Jobs.Add("Mystic Knight");
            no750Jobs.Add("Beastmaster");
            no750Jobs.Add("Ninja");
            no750Jobs.Add("Ranger");
            no750Jobs.Add("Dragoon");
            no750Jobs.Add("Samurai");
            no750Jobs.Add("Mime");

            AddContextMenus();
            SetKeybinds(Program.ConfigFile.AppSettings.Settings["StartStopTimerButton"].Value,
                Program.ConfigFile.AppSettings.Settings["ResetTimerButton"].Value);

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("orientation"))
            {
                string o = Program.ConfigFile.AppSettings.Settings["orientation"].Value.ToLower();

                if (o == "vertical")
                {
                    MakeVertical();
                }
                else
                {
                    MakeSquare();
                }
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("orientation", "square");
                MakeSquare();
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            Program.FinishInit(this);
        }
        
        public void AddContextMenus()
        {
            // Wind
            ContextMenu cmWind = new ContextMenu();

            cmWind.MenuItems.Add("Clear", mcWindItem_Click);

            foreach (string str in allJobs)
            {
                cmWind.MenuItems.Add(str, mcWindItem_Click);
            }

            picWind.ContextMenu = cmWind;
            
            // Water
            ContextMenu cmWater = new ContextMenu();

            cmWater.MenuItems.Add("Clear", mcWaterItem_Click);

            foreach (string str in allJobs)
            {
                cmWater.MenuItems.Add(str, mcWaterItem_Click);
            }

            picWater.ContextMenu = cmWater;

            // Fire
            ContextMenu cmFire = new ContextMenu();

            cmFire.MenuItems.Add("Clear", mcFireItem_Click);

            foreach (string str in allJobs)
            {
                cmFire.MenuItems.Add(str, mcFireItem_Click);
            }

            picFire.ContextMenu = cmFire;

            // Earth
            ContextMenu cmEarth = new ContextMenu();

            cmEarth.MenuItems.Add("Clear", mcEarthItem_Click);

            foreach (string str in allJobs)
            {
                cmEarth.MenuItems.Add(str, mcEarthItem_Click);
            }

            picEarth.ContextMenu = cmEarth;
        }
        
        public void timer_Tick(object sender, EventArgs e)
        {
            txtTimer.Text = (SavedTime + sw.Elapsed).ToString(TIMER_FORMAT);
        }

        public void mcWindItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear"))
            {
                picWind.ImageLocation = string.Format(IMG_FORMAT_STR, "Bartz-" + ((MenuItem)sender).Text);
                lblWindText.Text = text;
                lblWindText.Show();
            }
            else
            {
                picWind.ImageLocation = string.Empty;
                lblWindText.Text = string.Empty;
                lblWindText.Hide();
            }
        }

        public void mcWaterItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear"))
            {
                picWater.ImageLocation = string.Format(IMG_FORMAT_STR, "Lenna-" + ((MenuItem)sender).Text);
                lblWaterText.Text = text;
                lblWaterText.Show();
            }
            else
            {
                picWater.ImageLocation = string.Empty;
                lblWaterText.Text = string.Empty;
                lblWaterText.Hide();
            }
        }

        public void mcFireItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear"))
            {
                picFire.ImageLocation = string.Format(IMG_FORMAT_STR, "Faris-" + ((MenuItem)sender).Text);
                lblFireText.Text = text;
                lblFireText.Show();
            }
            else
            {
                picFire.ImageLocation = string.Empty;
                lblFireText.Text = string.Empty;
                lblFireText.Hide();
            }
        }

        public void mcEarthItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear"))
            {
                if (checkBox1.Checked)
                {
                    picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, "Krile-" + ((MenuItem)sender).Text);
                }
                else
                {
                    if (((MenuItem)sender).Text == "Mime")
                    {
                        picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, "Krile-" + ((MenuItem)sender).Text);
                    }
                    else
                    {
                        picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, "Galuf-" + ((MenuItem)sender).Text);
                    }
                }

                lblEarthText.Text = text;
                lblEarthText.Show();
            }
            else
            {
                picEarth.ImageLocation = string.Empty;
                lblEarthText.Text = string.Empty;
                lblEarthText.Hide();
            }

        }

        public void butRandomize_Click(object sender, EventArgs e)
        {
            if (comboMod.SelectedIndex == 2 && comboRules.Text != "Classic") // chaos
            {
                switch (comboRules.Text)
                {
                    case "Team 750":
                        lblRoll.Text = sevenFiftyJobs[r.Next(sevenFiftyJobs.Count - 1)];
                        break;

                    case "Team No 750":
                        lblRoll.Text = no750Jobs[r.Next(no750Jobs.Count - 1)];
                        break;

                    default:
                        lblRoll.Text = allJobs[r.Next(allJobs.Count - 2)];
                        break;
                }
            }
            else if(comboMod.SelectedIndex == 3 && comboRules.Text != "Classic") // pure chaos
            {
                switch (comboRules.Text)
                {
                    case "Team 750":
                        lblRoll.Text = sevenFiftyJobs[r.Next(sevenFiftyJobs.Count)];
                        break;

                    case "Team No 750":
                        lblRoll.Text = no750Jobs[r.Next(no750Jobs.Count)];
                        break;

                    default:
                        lblRoll.Text = allJobs[r.Next(allJobs.Count)];
                        break;
                }
            }
            else // normal and random
            {
                switch (comboCrystal.SelectedIndex)
                {
                    case 0:
                        switch (comboRules.Text)
                        {
                            case "Normal":
                                rollJob(allJobs, 0, 6);
                                break;
                            case "Team 750":
                                rollJob(sevenFiftyJobs, 0, 3);
                                break;
                            case "Team No 750":
                                rollJob(no750Jobs, 0, 3);
                                break;
                            case "Classic":
                                rollJob(classicJobs, 0, 5);
                                break;
                        }
                        break;

                    case 1:
                        switch (comboRules.Text)
                        {
                            case "Normal":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 6;

                                rollJob(allJobs, min, 11);
                                break;
                            case "Team 750":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 3;

                                rollJob(sevenFiftyJobs, min, 6);
                                break;
                            case "Team No 750":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 3;

                                rollJob(no750Jobs, min, 6);
                                break;
                            case "Classic":
                                rollJob(classicJobs, 0, 6);
                                break;
                        }
                        break;

                    case 2:
                        switch (comboRules.Text)
                        {
                            case "Normal":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 11;

                                rollJob(allJobs, min, 16);
                                break;
                            case "Team 750":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 6;

                                rollJob(sevenFiftyJobs, min, 8);
                                break;
                            case "Team No 750":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 6;

                                rollJob(no750Jobs, min, 8);
                                break;
                            case "Classic":
                                rollJob(classicJobs, 0, 6);
                                break;
                        }
                        break;

                    case 3:
                        switch (comboRules.Text)
                        {
                            case "Normal":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 16;

                                rollJob(allJobs, min, 20);
                                break;
                            case "Team 750":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 8;

                                rollJob(sevenFiftyJobs, min, 10);
                                break;
                            case "Team No 750":

                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 8;

                                rollJob(no750Jobs, min, 10);
                                break;
                            case "Classic":
                                rollJob(classicJobs, 0, 6);
                                break;
                        }
                        break;
                }
            }

            switch (comboCrystal.SelectedIndex)
            {
                case 0:
                    picWind.ImageLocation = string.Format(IMG_FORMAT_STR, "Bartz-" + lblRoll.Text);
                    lblWindText.Text = lblRoll.Text;
                    lblWindText.Show();
                    break;

                case 1:
                    picWater.ImageLocation = string.Format(IMG_FORMAT_STR, "Lenna-" + lblRoll.Text);
                    lblWaterText.Text = lblRoll.Text;
                    lblWaterText.Show();
                    break;

                case 2:
                    picFire.ImageLocation = string.Format(IMG_FORMAT_STR, "Faris-" + lblRoll.Text);
                    lblFireText.Text = lblRoll.Text;
                    lblFireText.Show();
                    break;

                case 3:
                    if (checkBox1.Checked)
                    {
                        picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, "Krile-" + lblRoll.Text);
                    }
                    else
                    {
                        if (lblRoll.Text == "Mime")
                        {
                            picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, "Krile-" + lblRoll.Text);
                        }
                        else
                        {
                            picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, "Galuf-" + lblRoll.Text);
                        }
                    }

                    lblEarthText.Text = lblRoll.Text;
                    lblEarthText.Show();
                    break;

                default:
                    break;
            }
        }
        
        public void rollJob(List<string> jobs, int min, int max)
        {
            lblRoll.Text = jobs[r.Next(min, max)];
        }

        public void FormFourJobFiesta_Load(object sender, EventArgs e)
        {
            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("DefaultSave") && File.Exists(Program.ConfigFile.AppSettings.Settings["DefaultSave"].Value))
            {
                LoadSave(Program.ConfigFile.AppSettings.Settings["DefaultSave"].Value);
            }
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] line = {
                "crystal," + comboCrystal.SelectedIndex.ToString(),
                "type," + comboRules.SelectedIndex.ToString(),
                "mod," + comboMod.SelectedIndex.ToString(),
                "wind," + picWind.ImageLocation,
                "water," + picWater.ImageLocation,
                "fire," + picFire.ImageLocation,
                "earth," + picEarth.ImageLocation,
                "time," + txtTimer.Text,
                "krile," + checkBox1.Checked.ToString()
            };

            if (string.IsNullOrEmpty(SaveFile))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save Current Run";
                sfd.Filter = "CSV|*.csv";
                sfd.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (sfd.FileName != "")
                {
                    using (StreamWriter sw = new StreamWriter(sfd.OpenFile()))
                    {
                        foreach (string str in line)
                        {
                            sw.WriteLine(str);
                        }
                    }

                    if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("DefaultSave"))
                    {
                        Program.ConfigFile.AppSettings.Settings["DefaultSave"].Value = sfd.FileName;
                    }
                    else
                    {
                        Program.ConfigFile.AppSettings.Settings.Add("DefaultSave", sfd.FileName);
                    }

                    Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("userSettings");

                    SaveFile = sfd.FileName;
                }
            }
            else
            {
                File.WriteAllText(SaveFile, string.Join(Environment.NewLine, line));
            }
        }

        public void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Saved Run";
            ofd.Filter = "CSV|*.csv";
            ofd.ShowDialog();
            
            LoadSave(ofd.FileName);

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("DefaultSave"))
            {
                Program.ConfigFile.AppSettings.Settings["DefaultSave"].Value = ofd.FileName;
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("DefaultSave", ofd.FileName);
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");
        }

        public void LoadSave(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                SaveFile = path;
                sw.Reset();
                SavedTime = new TimeSpan();

                string[] save = File.ReadAllLines(path);

                foreach (string line in save)
                {
                    string[] split = line.Split(',');

                    if (split.Count() == 2)
                    {
                        switch (split[0])
                        {
                            case "crystal":
                                comboCrystal.SelectedIndex = int.Parse(split[1]);
                                break;

                            case "type":
                                comboRules.SelectedIndex = int.Parse(split[1]);
                                break;

                            case "mod":
                                comboMod.SelectedIndex = int.Parse(split[1]);
                                break;

                            case "wind":
                                picWind.ImageLocation = split[1];
                                lblWindText.Text = split[1].Split('-')[1].Replace(".png", string.Empty);
                                lblWindText.Show();
                                break;

                            case "water":
                                picWater.ImageLocation = split[1];
                                lblWaterText.Text = split[1].Split('-')[1].Replace(".png", string.Empty);
                                lblWaterText.Show();
                                break;

                            case "fire":
                                picFire.ImageLocation = split[1];
                                lblFireText.Text = split[1].Split('-')[1].Replace(".png", string.Empty);
                                lblFireText.Show();
                                break;

                            case "earth":
                                picEarth.ImageLocation = split[1];
                                lblEarthText.Text = split[1].Split('-')[1].Replace(".png", string.Empty);
                                lblEarthText.Show();
                                break;

                            case "time":
                                SavedTime = TimeSpan.Parse(split[1]);
                                break;

                            case "krile":
                                checkBox1.Checked = split[1] == "True";
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboCrystal.SelectedIndex = -1;
            comboRules.SelectedIndex = -1;
            comboMod.SelectedIndex = -1;
            picWind.ImageLocation = string.Empty;
            picWater.ImageLocation = string.Empty;
            picFire.ImageLocation = string.Empty;
            picEarth.ImageLocation = string.Empty;
            lblRoll.Text = string.Empty;
            lblWindText.Text = string.Empty;
            lblWindText.Hide();
            lblWaterText.Text = string.Empty;
            lblWaterText.Hide();
            lblFireText.Text = string.Empty;
            lblFireText.Hide();
            lblEarthText.Text = string.Empty;
            lblEarthText.Hide();

            sw.Reset();
            SavedTime = new TimeSpan();
            SaveFile = string.Empty;
        }

        public void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://fourjobfiesta.com/help.php");
        }

        public void closeAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void editTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clrTimerText.AnyColor = true;
            clrTimerText.Color = txtTimer.ForeColor;
            clrTimerText.ShowDialog();

            txtTimer.ForeColor = clrTimerText.Color;

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("TimerTextColor"))
            {
                Program.ConfigFile.AppSettings.Settings["TimerTextColor"].Value = clrTimerText.Color.Name;
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("TimerTextColor", clrTimerText.Color.Name);
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");
        }

        public void editBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clrTimerText.AnyColor = true;
            clrTimerText.Color = txtTimer.BackColor;
            clrTimerText.ShowDialog();

            txtTimer.BackColor = clrTimerText.Color;

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("TimerBackgroundColor"))
            {
                Program.ConfigFile.AppSettings.Settings["TimerBackgroundColor"].Value = clrTimerText.Color.Name;
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("TimerBackgroundColor", clrTimerText.Color.Name);
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");
        }
        
        public void StartStopClick()
        {
            if (btnTmrStart.Text == "Start")
            {
                sw.Start();
                btnTmrStart.Text = "Stop";
            }
            else
            {
                SavedTime = SavedTime + sw.Elapsed;
                sw.Reset();
                btnTmrStart.Text = "Start";
            }
        }

        public void btnTmrStart_Click(object sender, EventArgs e)
        {
            StartStopClick();
        }
        
        
        public void ResetClick()
        {
            if (MessageBox.Show("Are you sure you want to reset the timer?", "Reset Timer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sw.Reset();
                SavedTime = new TimeSpan();
                txtTimer.Text = SavedTime.ToString(TIMER_FORMAT);
                btnTmrStart.Text = "Start";
            }
        }

        public void btnTmrReset_Click(object sender, EventArgs e)
        {
            ResetClick();
        }

        public void startStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTmrStart_Click(sender, e);
        }

        public void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTmrReset_Click(sender, e);
        }

        public void editShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerShortcuts ts = new TimerShortcuts();
            ts.Show();
        }

        public void SetKeybinds(string startStop, string reset)
        {
            startStopToolStripMenuItem.ShortcutKeyDisplayString = startStop;
            resetToolStripMenuItem.ShortcutKeyDisplayString = reset;
        }

        public void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] line = {
                "crystal," + comboCrystal.SelectedIndex.ToString(),
                "type," + comboRules.SelectedIndex.ToString(),
                "mod," + comboMod.SelectedIndex.ToString(),
                "wind," + picWind.ImageLocation,
                "water," + picWater.ImageLocation,
                "fire," + picFire.ImageLocation,
                "earth," + picEarth.ImageLocation,
                "time," + txtTimer.Text,
                "krile," + checkBox1.Checked.ToString()
            };
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Current Run";
            sfd.Filter = "CSV|*.csv";
            sfd.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (sfd.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(sfd.OpenFile()))
                {
                    foreach (string str in line)
                    {
                        sw.WriteLine(str);
                    }
                }

                if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("DefaultSave"))
                {
                    Program.ConfigFile.AppSettings.Settings["DefaultSave"].Value = sfd.FileName;
                }
                else
                {
                    Program.ConfigFile.AppSettings.Settings.Add("DefaultSave", sfd.FileName);
                }

                Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("userSettings");

                SaveFile = sfd.FileName;
            }
            else
            {
                File.WriteAllText(sfd.FileName, string.Join(Environment.NewLine, line));
            }
        }

        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BackColor = Color.WhiteSmoke;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            checkBox1.ForeColor = Color.Black;
            
            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("Theme"))
            {
                Program.ConfigFile.AppSettings.Settings["Theme"].Value = "light";
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("Theme", "light");
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");
        }

        public void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            checkBox1.ForeColor = Color.White;

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("Theme"))
            {
                Program.ConfigFile.AppSettings.Settings["Theme"].Value = "dark";
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("Theme", "dark");
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(picEarth.ImageLocation))
            {
                if (checkBox1.Checked)
                {
                    picEarth.ImageLocation = picEarth.ImageLocation.Replace("Galuf-", "Krile-");
                }
                else
                {
                    if (!picEarth.ImageLocation.Contains("Krile-Mime"))
                    {
                        picEarth.ImageLocation = picEarth.ImageLocation.Replace("Krile-", "Galuf-");
                    }
                }
            }
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("orientation"))
            {
                Program.ConfigFile.AppSettings.Settings["orientation"].Value = "square";
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("orientation", "square");
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            MakeSquare();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("orientation"))
            {
                Program.ConfigFile.AppSettings.Settings["orientation"].Value = "vertical";
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("orientation", "vertical");
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            MakeVertical();
        }

        public void MakeSquare()
        {
            Size = new Size(630, 542);
            
            picWater.Location = new Point(410, 27);
            lblWaterText.Location = new Point(419, 184);
            picFire.Location = new Point(210, 226);
            lblFireText.Location = new Point(219, 383);
            picEarth.Location = new Point(410, 226);
            lblEarthText.Location = new Point(419, 383);

            txtTimer.Location = new Point(210, 432);
            txtTimer.Size = new Size(400, 68);
            txtTimer.Font = new Font(txtTimer.Font.FontFamily, 40, txtTimer.Font.Style, txtTimer.Font.Unit, txtTimer.Font.GdiCharSet, txtTimer.Font.GdiVerticalFont);
            
            btnTmrStart.Location = new Point(120, 432);
            btnTmrReset.Location = new Point(120, 477);
        }

        public void MakeVertical()
        {
            Size = new Size(431, 918);
            
            picWater.Location = new Point(210, 226);
            lblWaterText.Location = new Point(219, 383);
            picFire.Location = new Point(210, 425);
            lblFireText.Location = new Point(219, 582);
            picEarth.Location = new Point(210, 624);
            lblEarthText.Location = new Point(219, 781);

            txtTimer.Location = new Point(210, 830);
            txtTimer.Size = new Size(200, 45);
            txtTimer.Font = new Font(txtTimer.Font.FontFamily, 25, txtTimer.Font.Style, txtTimer.Font.Unit, txtTimer.Font.GdiCharSet, txtTimer.Font.GdiVerticalFont);

            btnTmrStart.Location = new Point(129, 852);
            btnTmrReset.Location = new Point(10, 852);
        }
    }
}
