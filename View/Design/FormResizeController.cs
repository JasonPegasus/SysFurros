using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace View.Design
{
    internal class FormResizeController
    {
        Form pForm;
        bool enabled = true;   

        public FormResizeController(Form form) 
        {
            pForm = form;
            pForm.Load += (_, _) => FormInit();
            pForm.ResizeEnd += (_, _) => UpdateFormSize();
            pForm.Paint += (_, _) => FormPaint();
        }

        Size baseSize;
        Font baseFormFont;
        Dictionary<Control, float> controls;

        void FormInit()
        {
            baseSize = pForm.Size;
            baseFormFont = pForm.Font;
            controls = FormManagementHelper.GetAllControls(pForm).ToDictionary(c=>c, c => c.Font.Size);
        }

        void FormPaint()
        {
            if (pForm.WindowState == FormWindowState.Maximized) { UpdateFormSize(); }
        }

        void UpdateFormSize()
        {
            float sizePerc = (float)pForm.Size.Width / (float)baseSize.Width;
            Size newSize = pForm.Size;

            pForm.Font = new Font(baseFormFont.FontFamily, baseFormFont.Size * sizePerc, baseFormFont.Style);
            pForm.Size = newSize;

            foreach (var ctr in controls)
            {
                Font oldFont = ctr.Key.Font;
                ctr.Key.Font = new Font(oldFont.FontFamily, ctr.Value * sizePerc, oldFont.Style);
            }
        }
    }
}
