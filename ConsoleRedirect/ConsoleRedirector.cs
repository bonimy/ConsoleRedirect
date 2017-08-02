using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleRedirect
{
    public class ConsoleRedirector
    {
        private Thread ProcessMonitor;
        private volatile bool IsClosing;

        public IConsoleRedirect ConsoleRedirect
        {
            get;
            private set;
        }

        public string ExecutablePath
        {
            get;
            set;
        }

        public string Arguments
        {
            get;
            set;
        }

        public ConsoleRedirector(IConsoleRedirect consoleRedirect)
            : this(consoleRedirect, null, null)
        { }
        public ConsoleRedirector(IConsoleRedirect consoleRedirect, string executable)
            : this(consoleRedirect, executable, null)
        { }
        public ConsoleRedirector(IConsoleRedirect consoleRedirect, string executable, string arguments)
        {
            if (consoleRedirect == null)
                throw new ArgumentNullException(nameof(consoleRedirect));

            ExecutablePath = executable;
            Arguments = arguments;
            ConsoleRedirect = consoleRedirect;

            Application.ApplicationExit += Application_ApplicationExit;

            ProcessMonitor = new Thread(Run);
            ProcessMonitor.Start();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            IsClosing = true;
        }

        public void Start()
        {
            if (Invoked)
                return;

            ConsoleRedirect.Clear();
            InvocationInitialized = true;
        }

        public void InputText(string text)
        {
            if (IsRunning)
                Process.StandardInput.WriteLineAsync(text);
        }

        private volatile bool InvocationInitialized;
        private volatile bool Invoked;
        private volatile bool _isRunning;
        private volatile Process Process;

        public bool IsRunning
        {
            get { return _isRunning; }
        }

        private void Run()
        {
            while (!IsClosing)
            {
                if (!InvocationInitialized && !Invoked)
                    continue;
                Invoked = true;
                InvocationInitialized = false;

                if (!File.Exists(ExecutablePath))
                {
                    Invoked = false;
                    continue;
                }

                using (Process process = new Process())
                {
                    process.StartInfo.FileName = ExecutablePath;
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(ExecutablePath);
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.OutputDataReceived += Process_OutputDataReceived;
                    process.StartInfo.Arguments = Arguments;
                    Process = process;
                    process.Start();
                    _isRunning = true;
                    process.BeginOutputReadLine();
                    process.WaitForExit();
                    process.Close();
                }
                _isRunning = false;
                Process = null;
                Invoked = false;
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e != null && e.Data != null)
                AppendOutput(e.Data);
        }

        private delegate void AppendMethod(string line);

        private void AppendOutput(string line)
        {
            if (ConsoleRedirect.InvokeRequired)
            {
                AppendMethod append = new AppendMethod(AppendOutput);
                ConsoleRedirect.Invoke(append, line);
            }
            else
                ConsoleRedirect.AppendText(line + Environment.NewLine);
        }

        public void Kill()
        {
            if (_isRunning && Process != null)
            {
                Process.Kill();
                Process.Dispose();
            }
        }


        internal static Color ColorFromConsoleColor(ConsoleColor color)
        {
            string name = color.ToString();
            if (name == "DarkYellow")
                return Color.FromArgb(0x99, 0x99, 0x00);

            return Color.FromName(name);
        }
    }
}
