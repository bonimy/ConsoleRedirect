using System;

namespace ConsoleRedirect
{
    public interface IConsoleRedirect
    {
        bool InvokeRequired
        { get; }
        object Invoke(Delegate method, params object[] args);

        void Clear();
        void AppendText(string text);
    }
}
