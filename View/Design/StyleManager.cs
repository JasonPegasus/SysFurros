using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class StyleManager
    {
        public static Style DARK_DEFAULT = new Style(Color.DarkGray, Color.White, Color.Gray, new Font("Agency FB", 12));

        public static void ApplyStyle(Form form, Style style)
        {
            form.ForeColor = style.foregroundColor;
            form.BackColor = style.backgroundColor;
            form.Font = style.font;

            foreach (var ctr in form.Controls)
            {
                try { ApplyStyle((Button)  ctr, style); } catch { }
                try { ApplyStyle((Label)   ctr, style); } catch { }
                try { ApplyStyle((TextBox) ctr, style); } catch { }
            }
        }

        public static void ApplyStyle(Button btn, Style style)
        {
            btn.BackColor = style.backgroundColor;
            btn.ForeColor = style.foregroundColor;
        }

        public static void ApplyStyle(Label lb, Style style)
        {
            lb.ForeColor = style.foregroundColor;
        }

        public static void ApplyStyle(TextBox tb, Style style)
        {
            tb.ForeColor = style.backgroundColor;
            tb.BackColor = style.foregroundColor;
        }

        internal class Style
        {
            public Color backgroundColor;
            public Color foregroundColor;
            public Color frameColor;
            public Font font;

            public Style(Color background, Color foreground, Color frame, Font font)
            {
                backgroundColor = background;
                foregroundColor = foreground;
                frameColor = foreground;
                this.font = font;
            }
        }
    }
}

