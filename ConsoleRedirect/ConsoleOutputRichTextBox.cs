using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleRedirect
{
    public class ConsoleOutputRichTextBox : RichTextBox, IConsoleRedirect
    {
        private ConsoleColor _backColor;
        private ConsoleColor _foreColor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConsoleRedirector ConsoleRedirector
        {
            get;
            private set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Console background color")]
        [DefaultValue(ConsoleColor.Black)]
        public new ConsoleColor BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                base.BackColor = ConsoleRedirector.ColorFromConsoleColor(value);
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Console foreground color")]
        [DefaultValue(ConsoleColor.Gray)]
        public new ConsoleColor ForeColor
        {
            get { return _foreColor; }
            set
            {
                _foreColor = value;
                base.ForeColor = ConsoleRedirector.ColorFromConsoleColor(value);
            }
        }

        public ConsoleOutputRichTextBox()
        {
            BackColor = Console.BackgroundColor;
            Font = new Font("Consolas", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Console.ForegroundColor;
            Multiline = true;
            ReadOnly = true;
            ScrollBars = RichTextBoxScrollBars.Vertical;
            ConsoleRedirector = new ConsoleRedirector(this);
            Text = "Sample Text";
        }
    }
}
