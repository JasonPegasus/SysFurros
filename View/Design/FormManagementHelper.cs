using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Design
{
    static class FormManagementHelper
    {
        public static List<Control> GetAllControls(Form form)
        {
            List<Control> list = new List<Control>();
            foreach (Control ctr in form.Controls)
            {
                list.Add(ctr);
                list.AddRange(GetAllControls(ctr));
            }
            return list;
        }

        public static List<Control> GetAllControls(Control parent)
        {
            List<Control> list = new List<Control>();
            foreach (Control ctr in parent.Controls)
            {
                list.Add(ctr);
                list.AddRange(GetAllControls(ctr));
            }
            return list;
        }

    }
}
