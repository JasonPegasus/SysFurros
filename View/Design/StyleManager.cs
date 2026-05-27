using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using View.Design.StyleForms;
using System.Drawing.Printing;
using static View.StyleManager;

namespace View
{
    internal class StyleManager
    {
        public static Style<SF_WindowsDefault> WINDOWS_DEFAULT = new();
        public static Style<SF_DarkDefault> DARK_DEFAULT = new();
        public static Style<SF_DarkBlack> DARK_BLACK = new();



        const string IGNORE_TAG = "ignore";
        const string ONLY_DEFAULTS_TAG = "onlydefaults";

        public static void ApplyStyle<T>(Form form, Style<T> style) where T : Form, new()
        {
            foreach (var prop in style.formBase) { typeof(Form).GetProperty(prop.Key).SetValue(form, prop.Value); }
            foreach (Control ctr in form.Controls.OfType<Control>().Where(x => !Ignore(x))) { ApplyStyle(ctr, style); } 
        }

        public static void ApplyStyle<T>(Control ctr, Style<T> style) where T : Form, new()
        {
            Type cType = ctr.GetType();
            if (!style.controlBases.ContainsKey(cType)) { return; }

            foreach (var prop in style.controlBases[cType])
            {
                PropertyInfo propInf = cType.GetProperty(prop.Key);
                object propValue = propInf.GetValue(ctr);

                if (propValue != null && (!OnlyDefaults(ctr) || propValue.Equals(WINDOWS_DEFAULT.controlBases[cType][propInf.Name])))
                { propInf.SetValue(ctr, prop.Value); }
            }
        }

        static List<Control> GetAllControls(Form form)
        {
            List<Control> list = new List<Control>();
            foreach (Control ctr in form.Controls) 
            {
                list.Add(ctr);
                list.AddRange(GetAllControls(ctr));
            }
            return list;
        }

        static List<Control> GetAllControls(Control parent)
        {
            List<Control> list = new List<Control>();
            foreach (Control ctr in parent.Controls)
            {
                list.Add(ctr);
                list.AddRange(GetAllControls(ctr));
            }
            return list;
        }


        static bool OnlyDefaults(Control ctr)
        { return (ctr.Tag != null) && (ctr.Tag.ToString().ToLower().Replace(" ", "") == ONLY_DEFAULTS_TAG); }

        static bool Ignore(Control ctr)
        { return (ctr.Tag != null) && (ctr.Tag.ToString().ToLower().Replace(" ", "") == IGNORE_TAG); }

        internal class Style<T> where T : Form, new()
        {
            static readonly Type[] VISUAL_TYPES =
            {
                typeof(Color),
                typeof(Font),
                typeof(Image),
                typeof(Padding),
                typeof(FlatStyle),
                typeof(BorderStyle),
                typeof(DataGridViewCellStyle),
                typeof(DataGridViewCellBorderStyle),
                typeof(DataGridViewHeaderBorderStyle),
                typeof(DockStyle),
            };

            internal Dictionary<Type, Dictionary<string, object>> controlBases = new();
            internal Dictionary<string, object> formBase = new();

            public Style()
            {
                Form form = new T();

                formBase = typeof(Form).GetProperties().Where(x => VISUAL_TYPES.Contains(x.PropertyType)).ToDictionary(x => x.Name, x => x.GetValue(form));
                foreach (Control c in GetAllControls(form))
                {
                    Type cType = c.GetType();
                    controlBases[cType] = cType.GetProperties().Where(x => VISUAL_TYPES.Contains(x.PropertyType)).ToDictionary(x => x.Name, x => x.GetValue(c));
                }

                form.Dispose();
            }
        }
    }
}