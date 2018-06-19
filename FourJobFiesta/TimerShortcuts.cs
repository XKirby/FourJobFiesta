using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourJobFiesta
{
    public partial class TimerShortcuts : Form
    {
        public TimerShortcuts()
        {
            InitializeComponent();
            var values = Enum.GetValues(typeof(Keys));

            foreach (var item in values)
            {
                comboStartStop.Items.Add(item);
                comboReset.Items.Add(item);
            }

            comboStartStop.SelectedItem = Program.StartStopKey;
            comboReset.SelectedItem = Program.ResetKey;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.StartStopKey = (Keys)Enum.Parse(typeof(Keys), comboStartStop.SelectedItem.ToString());
            Program.ResetKey = (Keys)Enum.Parse(typeof(Keys), comboReset.SelectedItem.ToString());
            
            Program.MainForm.SetKeybinds(comboStartStop.SelectedItem.ToString(), comboReset.SelectedItem.ToString());
            
            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("StartStopTimerButton"))
            {
                Program.ConfigFile.AppSettings.Settings["StartStopTimerButton"].Value = comboStartStop.SelectedItem.ToString();
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("StartStopTimerButton", comboStartStop.SelectedItem.ToString());
            }

            if (Program.ConfigFile.AppSettings.Settings.AllKeys.Contains("ResetTimerButton"))
            {
                Program.ConfigFile.AppSettings.Settings["ResetTimerButton"].Value = comboReset.SelectedItem.ToString();
            }
            else
            {
                Program.ConfigFile.AppSettings.Settings.Add("ResetTimerButton", comboReset.SelectedItem.ToString());
            }

            Program.ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
