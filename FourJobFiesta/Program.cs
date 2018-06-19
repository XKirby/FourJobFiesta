using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourJobFiesta
{
    static class Program
    {
        public static FormFourJobFiesta MainForm { get; set; }
        public static Keys StartStopKey { get; set; }
        public static Keys ResetKey { get; set; }
        public static Configuration ConfigFile { get; set; }
        
        // key friendly name, value enum value
        public static ConcurrentDictionary<string, string> KeyBindMap { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetKeyBindMap();

            _hookID = SetHook(_proc);

            ConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigFile.AppSettings.Settings.AllKeys.Contains("StartStopTimerButton"))
            {
                StartStopKey = (Keys)Enum.Parse(typeof(Keys), ConfigFile.AppSettings.Settings["StartStopTimerButton"].Value);
            }
            else
            {
                StartStopKey = Keys.NumPad0;
                ConfigFile.AppSettings.Settings.Add("StartStopTimerButton", "NumPad0");
            }

            if (ConfigFile.AppSettings.Settings.AllKeys.Contains("ResetTimerButton"))
            {
                ResetKey = (Keys)Enum.Parse(typeof(Keys), ConfigFile.AppSettings.Settings["ResetTimerButton"].Value);
            }
            else
            {
                ResetKey = Keys.Oemtilde;
                ConfigFile.AppSettings.Settings.Add("ResetTimerButton", "Oemtilde");
            }

            ConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("userSettings");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormFourJobFiesta());
        }

        public static void FinishInit(FormFourJobFiesta form)
        {
            MainForm = form;

            MainForm.SetKeybinds(ConfigFile.AppSettings.Settings["StartStopTimerButton"].Value,
                ConfigFile.AppSettings.Settings["ResetTimerButton"].Value);
        }
        
        private static void SetKeyBindMap()
        {
            KeyBindMap = new ConcurrentDictionary<string, string>();
        }

        #region >>> Latch Keys

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);

                if (key == StartStopKey)
                {
                    MainForm.StartStopClick();
                }

                if (key == ResetKey)
                {
                    MainForm.ResetClick();
                }
            }
            
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        #endregion >>> Latch Keys
    }
}
