using System;
using System.IO;
using System.Windows.Forms;
using ConsoleRedirect;

namespace SampleApp
{
    public partial class Form1 : Form
    {
        public string ExecutablePath
        {
            get { return tbxPath.Text; }
            set { tbxPath.Text = value; }
        }
        public string Arguments
        {
            get { return tbxArgs.Text; }
            set { tbxArgs.Text = value; }
        }

        public ConsoleRedirector ConsoleRedirector
        {
            get { return conApp.ConsoleRedirector; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void tbxPath_TextChanged(object sender, EventArgs e)
        {
            btnRun.Enabled = File.Exists(ExecutablePath);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!ConsoleRedirector.IsRunning)
            {
                ConsoleRedirector.ExecutablePath = ExecutablePath;
                ConsoleRedirector.Arguments = Arguments;
                ConsoleRedirector.Start();
            }
            else
            {
                ConsoleRedirector.InputText(ConsoleRedirector.Arguments);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConsoleRedirector.Kill();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.DefaultExt = ".exe";
                dlg.Filter = "Executables (*.exe;*.bat)|*.exe;*.bat";
                dlg.Multiselect = false;
                dlg.Title = "Select Application";
                if (dlg.ShowDialog() == DialogResult.OK)
                    ExecutablePath = dlg.FileName;
            }
        }
    }
}
