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
using System.Reflection;
using FourJobFiesta.Models;

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

        public Job[] allJobs = new Job[0];
        public Job[] advance = new Job[0];

        public const string TIMER_FORMAT = @"hh\:mm\:ss\.ff";
        public const string VOID = "Void";
        public const string WIND = "Wind";
        public const string WATER = "Water";
        public const string FIRE = "Fire";
        public const string EARTH = "Earth";
        public const string TEAM750 = "Team 750";
        public const string TEAMNO750 = "Team No 750";
        public const string CLASSIC = "Classic";

        public FormFourJobFiesta()
        {
            InitializeComponent();
            BuildTimer();
            BuildJobs();
            AddContextMenus();
            SetKeybinds(Program.ConfigFile.AppSettings.Settings["StartStopTimerButton"].Value,
                Program.ConfigFile.AppSettings.Settings["ResetTimerButton"].Value);
            SetOrientation();

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            tsmiVersion.Text = "v" + version;

            Program.FinishInit(this);
        }

        private Job[] GetClassicJobs()
        {
            return allJobs.Where(a => a.Tags.Contains(CLASSIC)).ToArray();
        }

        private Job[] Get750Jobs()
        {
            return allJobs.Where(a => a.Tags.Contains(TEAM750)).ToArray();
        }

        private Job[] GetNo750Jobs()
        {
            return allJobs.Where(a => a.Tags.Contains(TEAMNO750)).ToArray();
        }

        private void SetOrientation()
        {
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
        }

        private void BuildTimer()
        {
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
        }

        private void BuildJobs()
        {
            allJobs = new[] { 
                new Job("Knight", new[] { WIND, TEAMNO750, CLASSIC }),
                new Job("Monk", new[] { WIND, TEAMNO750, CLASSIC }),
                new Job("Thief", new[] { WIND, TEAMNO750, CLASSIC }),
                new Job("Black Mage", new[] { WIND, TEAM750, CLASSIC }),
                new Job("White Mage", new[] { WIND, TEAM750, CLASSIC }),
                new Job("Blue Mage", new[] { WIND, TEAM750 }),

                new Job("Red Mage", new[] { WATER, TEAM750, CLASSIC }),
                new Job("Time Mage", new[] { WATER, TEAM750 }),
                new Job("Summoner", new[] { WATER, TEAM750 }),
                new Job("Berserker", new[] { WATER, TEAMNO750 }),
                new Job("Mystic Knight", new[] { WATER, TEAMNO750 }),

                new Job("Beastmaster", new[] { FIRE, TEAMNO750 }),
                new Job("Geomancer", new[] { FIRE, TEAM750 }),
                new Job("Ninja", new[] { FIRE, TEAMNO750 }),
                new Job("Ranger", new[] { FIRE, TEAMNO750 }),
                new Job("Bard", new[] { FIRE, TEAM750 }),

                new Job("Dragoon", new[] { EARTH, TEAMNO750 }),
                new Job("Dancer", new[] { EARTH, TEAM750 }),
                new Job("Samurai", new[] { EARTH, TEAMNO750 }),
                new Job("Chemist", new[] { EARTH, TEAM750 }),

                new Job("Freelancer"),
                new Job("Mime")
            };

            advance = new[] {
                new Job("Cannoneer"),
                new Job("Oracle"),
                new Job("Gladiator")
            };
        }

        public void AddContextMenus()
        {
            ContextMenu cmWind = new ContextMenu();
            ContextMenu cmWater = new ContextMenu();
            ContextMenu cmFire = new ContextMenu();
            ContextMenu cmEarth = new ContextMenu();

            cmWind.MenuItems.Add("Clear", mcWindItem_Click);
            cmWater.MenuItems.Add("Clear", mcWaterItem_Click);
            cmFire.MenuItems.Add("Clear", mcFireItem_Click);
            cmEarth.MenuItems.Add("Clear", mcEarthItem_Click);

            foreach (Job job in allJobs)
            {
                cmWind.MenuItems.Add(job.Name, mcWindItem_Click);
                cmWater.MenuItems.Add(job.Name, mcWaterItem_Click);
                cmFire.MenuItems.Add(job.Name, mcFireItem_Click);
                cmEarth.MenuItems.Add(job.Name, mcEarthItem_Click);
            }

            foreach (Job job in advance)
            {
                cmWind.MenuItems.Add(job.Name, mcWindItem_Click);
                cmWater.MenuItems.Add(job.Name, mcWaterItem_Click);
                cmFire.MenuItems.Add(job.Name, mcFireItem_Click);
                cmEarth.MenuItems.Add(job.Name, mcEarthItem_Click);
            }

            cmWind.MenuItems.Add(VOID, mcWindItem_Click);
            cmWater.MenuItems.Add(VOID, mcWaterItem_Click);
            cmFire.MenuItems.Add(VOID, mcFireItem_Click);
            cmEarth.MenuItems.Add(VOID, mcEarthItem_Click);

            picWind.ContextMenu = cmWind;
            picWater.ContextMenu = cmWater;
            picFire.ContextMenu = cmFire;
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
            string crystal = comboCrystal.Text;
            string rules = comboRules.Text;
            int mod = comboMod.SelectedIndex;

            if (mod == 3) // pure chaos
            {
                text = allJobs[r.Next(allJobs.Length)].Name;
            }
            else if (rules == "Advance" && comboCrystal.Text == EARTH) // advance earth crystal
            {
                text = advance[r.Next(advance.Length)].Name;
            }
            else if (mod == 2 && rules != CLASSIC) // chaos
            {
                Job[] jobs = FilterRules(allJobs, rules);
                text = jobs[r.Next(jobs.Length)].Name;
            }
            else if (mod == 1) // random
            {
                Job[] jobs = FilterRules(allJobs, rules);
                List<string> crystals = new List<string>();
                crystals.Add(WIND);

                switch (crystal)
                {
                    case WATER:
                        crystals.Add(WATER);
                        break;
                    case FIRE:
                        crystals.Add(WATER);
                        crystals.Add(FIRE);
                        break;
                    case EARTH:
                        crystals.Add(WATER);
                        crystals.Add(FIRE);
                        crystals.Add(EARTH);
                        break;
                }

                jobs = FilterCrystals(jobs, crystals);

                text = jobs[r.Next(jobs.Length)].Name;
            }
            else // normal
            {
                Job[] jobs = FilterRules(allJobs, rules);
                jobs = FilterCrystals(jobs, new List<string>() { crystal });
                text = jobs[r.Next(jobs.Length)].Name;
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

        private Job[] FilterRules(Job[] jobs, string rules)
        {
            Job[] ret = jobs;
            ret = jobs.Where(a => a.Tags.Length > 0).ToArray();
            return rules == "Normal" || rules == "Advance" ? jobs : jobs.Where(a => a.Tags.Contains(rules)).ToArray();
        }

        private Job[] FilterCrystals(Job[] jobs, List<string> crystals)
        {
            List<Job> ret = new List<Job>();
            jobs = jobs.Where(a => a.Tags.Length > 0).ToArray();

            foreach (string crystal in crystals)
            {
                var filtered = jobs.Where(a => a.Tags.Contains(crystal)).ToList();
                ret.AddRange(filtered);
            }

            return ret.ToArray();
        }

        public string rollJob(List<Job> jobs, int min, int max)
        {
            return jobs[r.Next(min, max)].ToString();
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

            if (!string.IsNullOrEmpty(tag) && lblEarthText.Text != VOID)
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

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/CBurlison/FourJobFiesta/releases");
        }
    }
}
