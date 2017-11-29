using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_Core.Extensions
{
    public static class RichTextBoxExtension
    {
        public static RichTextBox AppendTextFormatted(this RichTextBox box, string message, FontStyle style, Color color)
        {
            box.SelectionColor = color;
            box.SelectionFont = new Font(box.Font, style);
            box.AppendText(message);

            return box;
        }
        public static void EndLine(this RichTextBox box)
        {
            box.AppendText("\n");
            box.SelectionStart = box.Text.Length;
            box.ScrollToCaret();
        }
    }
}
