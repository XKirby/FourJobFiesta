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
        public Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public Timer timer = new Timer();

        Stopwatch sw = new Stopwatch();

        public int min { get; set; }
        public int roll { get; set; }

        public static TimeSpan SavedTime { get; set; }
        public static TimeSpan TimerTick { get; set; }
        
        public Random r = new Random();

        public List<string> allJobs = new List<string>();
        public List<string> classicJobs = new List<string>();
        public List<string> sevenFiftyJobs = new List<string>();
        public List<string> no750Jobs = new List<string>();

        public const string IMG_FORMAT_STR = "Images/{0}.png";
        public const string TIMER_FORMAT = @"mm\:hh\:ss\.ff";

        public FormFourJobFiesta()
        {
            InitializeComponent();
            
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
            allJobs.Add("Beast Master");
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
            no750Jobs.Add("Beast Master");
            no750Jobs.Add("Ninja");
            no750Jobs.Add("Ranger");
            no750Jobs.Add("Dragoon");
            no750Jobs.Add("Samurai");
            no750Jobs.Add("Mime");

            AddContextMenus();
        }
        
        private void AddContextMenus()
        {
            // Wind
            ContextMenu cmWind = new ContextMenu();

            foreach (string str in allJobs)
            {
                cmWind.MenuItems.Add(str, mcWindItem_Click);
            }

            picWind.ContextMenu = cmWind;

            // Water
            ContextMenu cmWater = new ContextMenu();

            foreach (string str in allJobs)
            {
                cmWater.MenuItems.Add(str, mcWaterItem_Click);
            }

            picWater.ContextMenu = cmWater;

            // Fire
            ContextMenu cmFire = new ContextMenu();

            foreach (string str in allJobs)
            {
                cmFire.MenuItems.Add(str, mcFireItem_Click);
            }

            picFire.ContextMenu = cmFire;

            // Earth
            ContextMenu cmEarth = new ContextMenu();

            foreach (string str in allJobs)
            {
                cmEarth.MenuItems.Add(str, mcEarthItem_Click);
            }

            picEarth.ContextMenu = cmEarth;
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            txtTimer.Text = (SavedTime + sw.Elapsed).ToString(TIMER_FORMAT);
        }

        private void mcWindItem_Click(object sender, EventArgs e)
        {
            picWind.ImageLocation = string.Format(IMG_FORMAT_STR, ((MenuItem)sender).Text);
        }

        private void mcWaterItem_Click(object sender, EventArgs e)
        {
            picWater.ImageLocation = string.Format(IMG_FORMAT_STR, ((MenuItem)sender).Text);
        }

        private void mcFireItem_Click(object sender, EventArgs e)
        {
            picFire.ImageLocation = string.Format(IMG_FORMAT_STR, ((MenuItem)sender).Text);
        }

        private void mcEarthItem_Click(object sender, EventArgs e)
        {
            picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, ((MenuItem)sender).Text);
        }

        private void butRandomize_Click(object sender, EventArgs e)
        {
            if (comboMod.SelectedIndex == 2 && comboRules.Text != "Classic") // chaos
            {
                switch (comboRules.Text)
                {
                    case "Team 750":
                        labRoll.Text = sevenFiftyJobs[r.Next(sevenFiftyJobs.Count - 1)];
                        break;

                    case "Team No 750":
                        labRoll.Text = no750Jobs[r.Next(no750Jobs.Count - 1)];
                        break;

                    default:
                        labRoll.Text = allJobs[r.Next(allJobs.Count - 2)];
                        break;
                }
            }
            else if(comboMod.SelectedIndex == 3 && comboRules.Text != "Classic") // pure chaos
            {
                switch (comboRules.Text)
                {
                    case "Team 750":
                        labRoll.Text = sevenFiftyJobs[r.Next(sevenFiftyJobs.Count)];
                        break;

                    case "Team No 750":
                        labRoll.Text = no750Jobs[r.Next(no750Jobs.Count)];
                        break;

                    default:
                        labRoll.Text = allJobs[r.Next(allJobs.Count)];
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
                    picWind.ImageLocation = string.Format(IMG_FORMAT_STR, labRoll.Text);
                    break;

                case 1:
                    picWater.ImageLocation = string.Format(IMG_FORMAT_STR, labRoll.Text);
                    break;

                case 2:
                    picFire.ImageLocation = string.Format(IMG_FORMAT_STR, labRoll.Text);
                    break;

                case 3:
                    picEarth.ImageLocation = string.Format(IMG_FORMAT_STR, labRoll.Text);
                    break;

                default:
                    break;
            }
        }
        
        public void rollJob(List<string> jobs, int min, int max)
        {
            labRoll.Text = jobs[r.Next(min, max)];
        }

        private void FormFourJobFiesta_Load(object sender, EventArgs e)
        {
            if (config.AppSettings.Settings.AllKeys.Contains("DefaultSave") && File.Exists(config.AppSettings.Settings["DefaultSave"].Value))
            {
                LoadSave(config.AppSettings.Settings["DefaultSave"].Value);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder save = new StringBuilder();
            string[] line = {
                "crystal," + comboCrystal.SelectedIndex.ToString(),
                "type," + comboRules.SelectedIndex.ToString(),
                "mod," + comboMod.SelectedIndex.ToString(),
                "wind," + picWind.ImageLocation,
                "water," + picWater.ImageLocation,
                "fire," + picFire.ImageLocation,
                "earth," + picEarth.ImageLocation,
                "time," + txtTimer.Text
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

                if (config.AppSettings.Settings.AllKeys.Contains("DefaultSave"))
                {
                    config.AppSettings.Settings["DefaultSave"].Value = sfd.FileName;
                }
                else
                {
                    config.AppSettings.Settings.Add("DefaultSave", sfd.FileName);
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("userSettings");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Saved Run";
            ofd.Filter = "CSV|*.csv";
            ofd.ShowDialog();


            LoadSave(ofd.FileName);

            if (config.AppSettings.Settings.AllKeys.Contains("DefaultSave"))
            {
                config.AppSettings.Settings["DefaultSave"].Value = ofd.FileName;
            }
            else
            {
                config.AppSettings.Settings.Add("DefaultSave", ofd.FileName);
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");
        }

        private void LoadSave(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
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
                                break;

                            case "water":
                                picWater.ImageLocation = split[1];
                                break;

                            case "fire":
                                picFire.ImageLocation = split[1];
                                break;

                            case "earth":
                                picEarth.ImageLocation = split[1];
                                break;

                            case "time":
                                SavedTime = TimeSpan.Parse(split[1]);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboCrystal.SelectedIndex = -1;
            comboRules.SelectedIndex = -1;
            comboMod.SelectedIndex = -1;
            picWind.ImageLocation = string.Empty;
            picWater.ImageLocation = string.Empty;
            picFire.ImageLocation = string.Empty;
            picEarth.ImageLocation = string.Empty;
            labRoll.Text = string.Empty;
            
            sw.Reset();
            SavedTime = new TimeSpan();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://fourjobfiesta.com/help.php?s=c#");
        }

        private void closeAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clrTimerText.AnyColor = true;
            clrTimerText.Color = txtTimer.ForeColor;
            clrTimerText.ShowDialog();

            txtTimer.ForeColor = clrTimerText.Color;
        }

        private void editBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clrTimerText.AnyColor = true;
            clrTimerText.Color = txtTimer.BackColor;
            clrTimerText.ShowDialog();

            txtTimer.BackColor = clrTimerText.Color;
        }

        private void btnTmrStart_Click(object sender, EventArgs e)
        {
            sw.Start();
        }

        private void btnTmrStop_Click(object sender, EventArgs e)
        {
            SavedTime = SavedTime + sw.Elapsed;
            sw.Reset();
        }

        private void btnTmrReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the timer?", "Reset Timer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sw.Reset();
                SavedTime = new TimeSpan();
                txtTimer.Text = SavedTime.ToString(TIMER_FORMAT);
            }
        }
    }
}
