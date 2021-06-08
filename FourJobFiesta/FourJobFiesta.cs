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
using FourJobFiesta.Properties;

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
        public List<string> advance = new List<string>();

        public const string IMG_FORMAT_STR = "Images/{0}.png";
        public const string TIMER_FORMAT = @"hh\:mm\:ss\.ff";
        public const string VOID = "Void";

        public FormFourJobFiesta()
        {
            InitializeComponent();
            
            txtTimer.BackColor = Color.Black;
            txtTimer.ForeColor = Color.White;

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("TimerBackgroundColor"))
            {
                string color = Program.ConfigFile.AppSettings.Settings["TimerBackgroundColor"].Value;

                try
                {
                    if (!string.IsNullOrEmpty(color) && color.Length > 2 && color.StartsWith("ff"))
                        txtTimer.BackColor = ColorTranslator.FromHtml("#" + color.Remove(0, 2));
                }
                catch (Exception) { }

                if (txtTimer.BackColor.Name != color)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(color))
                            txtTimer.BackColor = Color.FromName(color);
                    }
                    catch (Exception) { }
                }
            }

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("TimerTextColor"))
            {
                string color = Program.ConfigFile.AppSettings.Settings["TimerTextColor"].Value;

                try
                {
                    if (!string.IsNullOrEmpty(color) && color.Length > 2 && color.StartsWith("ff"))
                        txtTimer.ForeColor = ColorTranslator.FromHtml("#" + color.Remove(0, 2));
                }
                catch (Exception) { }

                if (txtTimer.ForeColor.Name != color)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(color))
                            txtTimer.ForeColor = Color.FromName(color);
                    }
                    catch (Exception) { }
                }
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

            advance.Add("Cannoneer");
            advance.Add("Oracle");
            advance.Add("Gladiator");
            
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
                else if (o == "horizontal")
                {
                    MakeHorizontal();
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

            cmWind.MenuItems.Add("Cannoneer", mcWindItem_Click);
            cmWind.MenuItems.Add("Oracle", mcWindItem_Click);
            cmWind.MenuItems.Add("Gladiator", mcWindItem_Click);
            cmWind.MenuItems.Add(VOID, mcWindItem_Click);

            picWind.ContextMenu = cmWind;
            
            // Water
            ContextMenu cmWater = new ContextMenu();

            cmWater.MenuItems.Add("Clear", mcWaterItem_Click);

            foreach (string str in allJobs)
            {
                cmWater.MenuItems.Add(str, mcWaterItem_Click);
            }

            cmWater.MenuItems.Add("Cannoneer", mcWaterItem_Click);
            cmWater.MenuItems.Add("Oracle", mcWaterItem_Click);
            cmWater.MenuItems.Add("Gladiator", mcWaterItem_Click);
            cmWater.MenuItems.Add(VOID, mcWaterItem_Click);

            picWater.ContextMenu = cmWater;

            // Fire
            ContextMenu cmFire = new ContextMenu();

            cmFire.MenuItems.Add("Clear", mcFireItem_Click);

            foreach (string str in allJobs)
            {
                cmFire.MenuItems.Add(str, mcFireItem_Click);
            }

            cmFire.MenuItems.Add("Cannoneer", mcFireItem_Click);
            cmFire.MenuItems.Add("Oracle", mcFireItem_Click);
            cmFire.MenuItems.Add("Gladiator", mcFireItem_Click);
            cmFire.MenuItems.Add(VOID, mcFireItem_Click);

            picFire.ContextMenu = cmFire;

            // Earth
            ContextMenu cmEarth = new ContextMenu();

            cmEarth.MenuItems.Add("Clear", mcEarthItem_Click);

            foreach (string str in allJobs)
            {
                cmEarth.MenuItems.Add(str, mcEarthItem_Click);
            }

            cmEarth.MenuItems.Add("Cannoneer", mcEarthItem_Click);
            cmEarth.MenuItems.Add("Oracle", mcEarthItem_Click);
            cmEarth.MenuItems.Add("Gladiator", mcEarthItem_Click);
            cmEarth.MenuItems.Add(VOID, mcEarthItem_Click);

            picEarth.ContextMenu = cmEarth;
        }
        
        public void timer_Tick(object sender, EventArgs e)
        {
            txtTimer.Text = (SavedTime + sw.Elapsed).ToString(TIMER_FORMAT);
        }

        public void mcWindItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear") && !text.Equals(VOID))
            {
                picWind.Image = (Image)Resources.ResourceManager.GetObject("Bartz_" + text);
                picWind.Tag = "Bartz_" + text;
                lblWindText.Text = text;
                lblWindText.Show();
            }
            else if (text.Equals(VOID))
            {
                picWind.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                picWind.Tag = text;
                lblWindText.Text = text;
                lblWindText.Show();
            }
            else
            {
                picWind.Image = null;
                picWind.Tag = string.Empty;
                lblWindText.Text = string.Empty;
                lblWindText.Hide();
            }
        }

        public void mcWaterItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear") && !text.Equals(VOID))
            {
                picWater.Image = (Image)Resources.ResourceManager.GetObject("Lenna_" + text);
                picWater.Tag = "Lenna_" + text;
                lblWaterText.Text = text;
                lblWaterText.Show();
            }
            else if (text.Equals(VOID))
            {
                picWater.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                picWater.Tag = text;
                lblWaterText.Text = text;
                lblWaterText.Show();
            }
            else
            {
                picWater.Image = null;
                picWater.Tag = string.Empty;
                lblWaterText.Text = string.Empty;
                lblWaterText.Hide();
            }
        }

        public void mcFireItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear") && !text.Equals(VOID))
            {
                picFire.Image = (Image)Resources.ResourceManager.GetObject("Faris_" + text);
                picFire.Tag = "Faris_" + text;
                lblFireText.Text = text;
                lblFireText.Show();
            }
            else if (text.Equals(VOID))
            {
                picFire.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                picFire.Tag = text;
                lblFireText.Text = text;
                lblFireText.Show();
            }
            else
            {
                picFire.Image = null;
                picFire.Tag = string.Empty;
                lblFireText.Text = string.Empty;
                lblFireText.Hide();
            }
        }

        public void mcEarthItem_Click(object sender, EventArgs e)
        {
            string text = ((MenuItem)sender).Text;

            if (!text.Equals("Clear") && !text.Equals(VOID))
            {
                if (checkBox1.Checked)
                {
                    picEarth.Image = (Image)Resources.ResourceManager.GetObject("Krile_" + text);
                    picEarth.Tag = "Krile_" + text;
                }
                else
                {
                    if (text == "Mime" || text == "Cannoneer" || text == "Oracle" || text == "Gladiator")
                    {
                        picEarth.Image = (Image)Resources.ResourceManager.GetObject("Krile_" + text);
                        picEarth.Tag = "Krile_" + text;
                    }
                    else
                    {
                        picEarth.Image = (Image)Resources.ResourceManager.GetObject("Galuf_" + text);
                        picEarth.Tag = "Galuf_" + text;
                    }
                }

                lblEarthText.Text = text;
                lblEarthText.Show();
            }
            else if (text.Equals(VOID))
            {
                picEarth.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                lblEarthText.Text = text;
                lblEarthText.Show();
            }
            else
            {
                picEarth.Image = null;
                lblEarthText.Text = string.Empty;
                lblEarthText.Hide();
            }

        }

        public void butRandomize_Click(object sender, EventArgs e)
        {
            string text = string.Empty;

            if (comboRules.Text == "Advance" && comboCrystal.Text == "Earth")
            {
                text = advance[r.Next(advance.Count)];
            }
            else if (comboMod.SelectedIndex == 2 && comboRules.Text != "Classic") // chaos
            {
                switch (comboRules.Text)
                {
                    case "Team 750":
                        text = sevenFiftyJobs[r.Next(sevenFiftyJobs.Count - 1)];
                        break;

                    case "Team No 750":
                        text = no750Jobs[r.Next(no750Jobs.Count - 1)];
                        break;

                    default:
                        text = allJobs[r.Next(allJobs.Count - 2)];
                        break;
                }
            }
            else if(comboMod.SelectedIndex == 3 && comboRules.Text != "Classic") // pure chaos
            {
                switch (comboRules.Text)
                {
                    case "Team 750":
                        text = sevenFiftyJobs[r.Next(sevenFiftyJobs.Count)];
                        break;

                    case "Team No 750":
                        text = no750Jobs[r.Next(no750Jobs.Count)];
                        break;

                    default:
                        text = allJobs[r.Next(allJobs.Count)];
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
                            case "Advance":
                                text = rollJob(allJobs, 0, 6);
                                break;
                            case "Team 750":
                                text = rollJob(sevenFiftyJobs, 0, 3);
                                break;
                            case "Team No 750":
                                text = rollJob(no750Jobs, 0, 3);
                                break;
                            case "Classic":
                                text = rollJob(classicJobs, 0, 5);
                                break;
                        }
                        break;

                    case 1:
                        switch (comboRules.Text)
                        {
                            case "Normal":
                            case "Advance":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 6;

                                text = rollJob(allJobs, min, 11);
                                break;
                            case "Team 750":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 3;

                                text = rollJob(sevenFiftyJobs, min, 6);
                                break;
                            case "Team No 750":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 3;

                                text = rollJob(no750Jobs, min, 6);
                                break;
                            case "Classic":
                                text = rollJob(classicJobs, 0, 6);
                                break;
                        }
                        break;

                    case 2:
                        switch (comboRules.Text)
                        {
                            case "Normal":
                            case "Advance":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 11;

                                text = rollJob(allJobs, min, 16);
                                break;
                            case "Team 750":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 6;

                                text = rollJob(sevenFiftyJobs, min, 8);
                                break;
                            case "Team No 750":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 6;

                                text = rollJob(no750Jobs, min, 8);
                                break;
                            case "Classic":
                                text = rollJob(classicJobs, 0, 6);
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

                                text = rollJob(allJobs, min, 20);
                                break;
                            case "Team 750":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 8;

                                text = rollJob(sevenFiftyJobs, min, 10);
                                break;
                            case "Team No 750":
                                if (comboMod.SelectedIndex == 1)
                                    min = 0;
                                else
                                    min = 8;

                                text = rollJob(no750Jobs, min, 10);
                                break;
                            case "Classic":
                                text = rollJob(classicJobs, 0, 6);
                                break;
                        }
                        break;
                }
            }

            switch (comboCrystal.SelectedIndex)
            {
                case 0:
                    picWind.Image = (Image)Resources.ResourceManager.GetObject("Bartz_" + text);
                    picWind.Tag = "Bartz_" + text;
                    lblWindText.Text = text;
                    lblWindText.Show();
                    break;

                case 1:
                    picWater.Image = (Image)Resources.ResourceManager.GetObject("Lenna_" + text);
                    picWater.Tag = "Lenna_" + text;
                    lblWaterText.Text = text;
                    lblWaterText.Show();
                    break;

                case 2:
                    picFire.Image = (Image)Resources.ResourceManager.GetObject("Faris_" + text);
                    picFire.Tag = "Faris_" + text;
                    lblFireText.Text = text;
                    lblFireText.Show();
                    break;

                case 3:
                    if (checkBox1.Checked)
                    {
                        picEarth.Image = (Image)Resources.ResourceManager.GetObject("Krile_" + text);
                        picEarth.Tag = "Krile_" + text;
                    }
                    else
                    {
                        if (text == "Mime" || text == "Cannoneer" || text == "Oracle" || text == "Gladiator")
                        {
                            picEarth.Image = (Image)Resources.ResourceManager.GetObject("Krile_" + text);
                            picEarth.Tag = "Krile_" + text;
                        }
                        else
                        {
                            picEarth.Image = (Image)Resources.ResourceManager.GetObject("Galuf_" + text);
                            picEarth.Tag = "Galuf_" + text;
                        }
                    }

                    lblEarthText.Text = text;
                    lblEarthText.Show();
                    break;

                default:
                    break;
            }
        }
        
        public string rollJob(List<string> jobs, int min, int max)
        {
            return jobs[r.Next(min, max)];
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
                "wind," + picWind.Tag,
                "water," + picWater.Tag,
                "fire," + picFire.Tag,
                "earth," + picEarth.Tag,
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

                    if (split.Count() == 2 && !string.IsNullOrEmpty(split[1]))
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
                                picWind.Image = (Image)Resources.ResourceManager.GetObject(split[1]);
                                picWind.Tag = split[1];
                                lblWindText.Text = split[1].Split('_')[1];
                                lblWindText.Show();
                                break;

                            case "water":
                                picWater.Image = (Image)Resources.ResourceManager.GetObject(split[1]);
                                picWater.Tag = split[1];
                                lblWaterText.Text = split[1].Split('_')[1];
                                lblWaterText.Show();
                                break;

                            case "fire":
                                picFire.Image = (Image)Resources.ResourceManager.GetObject(split[1]);
                                picFire.Tag = split[1];
                                lblFireText.Text = split[1].Split('_')[1];
                                lblFireText.Show();
                                break;

                            case "earth":
                                picEarth.Image = (Image)Resources.ResourceManager.GetObject(split[1]);
                                picEarth.Tag = split[1];
                                lblEarthText.Text = split[1].Split('_')[1];
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
            picWind.Image = null;
            picWind.Tag = string.Empty;
            picWater.Image = null;
            picWater.Tag = string.Empty;
            picFire.Image = null;
            picFire.Tag = string.Empty;
            picEarth.Image = null;
            picEarth.Tag = string.Empty;
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
            if (hideToolStripMenuItem.Text == "Hide")
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
        }

        public void btnTmrStart_Click(object sender, EventArgs e)
        {
            StartStopClick();
        }
        
        public void ResetClick()
        {
            if (hideToolStripMenuItem.Text == "Hide")
            {
                if (MessageBox.Show("Are you sure you want to reset the timer?", "Reset Timer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    sw.Reset();
                    SavedTime = new TimeSpan();
                    txtTimer.Text = SavedTime.ToString(TIMER_FORMAT);
                    btnTmrStart.Text = "Start";
                }
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
                "wind," + picWind.Tag,
                "water," + picWater.Tag,
                "fire," + picFire.Tag,
                "earth," + picEarth.Tag,
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
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            checkBox1.ForeColor = Color.Black;
            menuStrip1.BackColor = Color.WhiteSmoke;
            menuStrip1.ForeColor = Color.Black;
            groupTimer.ForeColor = Color.Black;

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
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            checkBox1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.Black;
            menuStrip1.ForeColor = Color.White;
            groupTimer.ForeColor = Color.White;
            btnTmrReset.ForeColor = Color.Black;
            btnTmrStart.ForeColor = Color.Black;

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
            string tag = (string)picEarth.Tag;

            if (!string.IsNullOrEmpty(tag))
            {
                if (checkBox1.Checked)
                {
                    picEarth.Tag = tag.Replace("Galuf_", "Krile_");
                    picEarth.Image = (Image)Resources.ResourceManager.GetObject((string)picEarth.Tag);
                }
                else
                {
                    if (!tag.Contains("Krile_Mime") && !tag.Contains("Krile_Cannoneer")
                        && !tag.Contains("Krile_Oracle") && !tag.Contains("Krile_Gladiator"))
                    {
                        picEarth.Tag = tag.Replace("Krile_", "Galuf_");
                        picEarth.Image = (Image)Resources.ResourceManager.GetObject((string)picEarth.Tag);
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
        
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("orientation"))
            {
                Program.ConfigFile.AppSettings.Settings["orientation"].Value = "horizontal";
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("orientation", "horizontal");
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            MakeHorizontal();
        }

        public void MakeSquare()
        {
            Size = new Size(630, 545);
            
            picWater.Location = new Point(410, 25);
            lblWaterText.Location = new Point(418, 180);
            picFire.Location = new Point(210, 225);
            lblFireText.Location = new Point(218, 380);
            picEarth.Location = new Point(410, 225);
            lblEarthText.Location = new Point(418, 380);

            txtTimer.Location = new Point(210, 430);
            txtTimer.Size = new Size(400, 70);
            txtTimer.Font = new Font(txtTimer.Font.FontFamily, 40, txtTimer.Font.Style, txtTimer.Font.Unit, txtTimer.Font.GdiCharSet, txtTimer.Font.GdiVerticalFont);
        }

        public void MakeVertical()
        {
            Size = new Size(430, 920);
            
            picWater.Location = new Point(210, 225);
            lblWaterText.Location = new Point(218, 380);
            picFire.Location = new Point(210, 425);
            lblFireText.Location = new Point(218, 580);
            picEarth.Location = new Point(210, 625);
            lblEarthText.Location = new Point(218, 780);

            txtTimer.Location = new Point(210, 830);
            txtTimer.Size = new Size(200, 50);
            txtTimer.Font = new Font(txtTimer.Font.FontFamily, 25, txtTimer.Font.Style, txtTimer.Font.Unit, txtTimer.Font.GdiCharSet, txtTimer.Font.GdiVerticalFont);
        }

        public void MakeHorizontal()
        {
            Size = new Size(1030, 350);

            picWater.Location = new Point(410, 25);
            lblWaterText.Location = new Point(418, 180);
            picFire.Location = new Point(610, 25);
            lblFireText.Location = new Point(618, 180);
            picEarth.Location = new Point(810, 25);
            lblEarthText.Location = new Point(818, 180);

            txtTimer.Location = new Point(210, 235);
            txtTimer.Size = new Size(400, 70);
            txtTimer.Font = new Font(txtTimer.Font.FontFamily, 40, txtTimer.Font.Style, txtTimer.Font.Unit, txtTimer.Font.GdiCharSet, txtTimer.Font.GdiVerticalFont);
        }
        
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideToolStripMenuItem.Text == "Hide")
            {
                if (btnTmrStart.Text == "Stop")
                {
                    SavedTime = SavedTime + sw.Elapsed;
                    sw.Reset();
                    btnTmrStart.Text = "Start";
                }

                txtTimer.Hide();
                btnTmrStart.Hide();
                btnTmrReset.Hide();
                groupTimer.Hide();

                hideToolStripMenuItem.Text = "Show";
            }
            else
            {
                txtTimer.Show();
                btnTmrStart.Show();
                btnTmrReset.Show();
                groupTimer.Show();
                hideToolStripMenuItem.Text = "Hide";
            }
        }

        private void buttonVoid_Click(object sender, EventArgs e)
        {
            if (lblWindText.Text != VOID && lblWindText.Visible == true
                && lblWaterText.Text != VOID && lblWaterText.Visible == true
                && lblFireText.Text != VOID && lblFireText.Visible == true
                && lblEarthText.Text != VOID && lblEarthText.Visible == true)
            {
                int voided = r.Next(4);

                switch (voided)
                {
                    case 0:
                        lblWindText.Text = VOID;
                        picWind.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                        picWind.Tag = VOID;
                        break;

                    case 1:
                        lblWaterText.Text = VOID;
                        picWater.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                        picWater.Tag = VOID;
                        break;

                    case 2:
                        lblFireText.Text = VOID;
                        picFire.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                        picFire.Tag = VOID;
                        break;

                    case 3:
                        lblEarthText.Text = VOID;
                        picEarth.Image = (Image)Resources.ResourceManager.GetObject(VOID);
                        picEarth.Tag = VOID;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
