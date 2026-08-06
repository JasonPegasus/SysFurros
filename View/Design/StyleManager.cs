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
using View.Design;

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
            string[] propBlacklist = GetPropertyBlacklist(ctr);

            foreach (var prop in style.controlBases[cType])
            {
                PropertyInfo propInf = cType.GetProperty(prop.Key);
                object propValue = propInf.GetValue(ctr);

                if (propValue != null && 
                    !propBlacklist.Contains(propInf.Name.ToLower()) &&
                    (!OnlyDefaults(ctr) || propValue.Equals(WINDOWS_DEFAULT.controlBases[cType][propInf.Name])))
                { propInf.SetValue(ctr, prop.Value); }
            }
        }

        static string[] GetPropertyBlacklist(Control ctr)
        {
            if (!(ctr.Tag is string))
            { return Array.Empty<string>(); }

            return ctr.Tag.ToString().Replace(" ", "").ToLower().Split(',');
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
                foreach (Control c in FormManagementHelper.GetAllControls(form))
                {
                    Type cType = c.GetType();
                    controlBases[cType] = cType.GetProperties().Where(x => VISUAL_TYPES.Contains(x.PropertyType)).ToDictionary(x => x.Name, x => x.GetValue(c));
                }

                form.Dispose();
            }
        }
    }
}