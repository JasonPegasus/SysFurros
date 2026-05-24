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

namespace View
{
    internal class StyleManager
    {
        public static Style<SF_DarkDefault> DARK_DEFAULT = new();
        const string DONT_OVERRIDE_TAG = "dontoverride";

        public static void ApplyStyle<T>(Form form, Style<T> style) where T : Form, new()
        { 
            form.BackColor = style.bForm.bc;
            form.ForeColor = style.bForm.fc;
            form.Font = style.bForm.font;
            foreach (Control ctr in form.Controls) { ApplyStyle(ctr, style); } 
        }

        public static void ApplyStyle<T>(Control ctr, Style<T> style) where T : Form, new()
        {
            if (!CanOverride(ctr)) { return; }
            switch (ctr)
            {
                case TextBox tb:       tb.BackColor =  style.bTextBox.bc;      tb.ForeColor = style.bTextBox.fc;      tb.Font = style.bTextBox.font;     tb.BorderStyle = style.bTextBox.border;                  break;
                case ListBox lb:       lb.BackColor =  style.bListBox.bc;      lb.ForeColor = style.bListBox.fc;      lb.Font = style.bListBox.font;     lb.BorderStyle = style.bListBox.border;                  break;
                case Button btn:       btn.BackColor = style.bButton.bc;       btn.ForeColor = style.bButton.fc;      btn.Font = style.bButton.font;     btn.FlatStyle = style.bButton.flat;                      break;
                case ComboBox cb:      cb.BackColor =  style.bComboBox.bc;     cb.ForeColor = style.bComboBox.fc;     cb.Font = style.bComboBox.font;    cb.FlatStyle = style.bComboBox.flat;                     break;
                case ProgressBar pb:   pb.BackColor =  style.bProgressBar.bc;  pb.ForeColor = style.bProgressBar.fc;  pb.Step = style.bProgressBar.step; pb.MarqueeAnimationSpeed = style.bProgressBar.animSpeed; break;
                case Label lbl:        lbl.BackColor = style.bLabel.bc;        lbl.ForeColor = style.bLabel.fc;       lbl.Font = style.bLabel.font;      break;
                case GroupBox gb:      gb.BackColor =  style.bGroupBox.bc;     gb.ForeColor = style.bGroupBox.fc;     gb.Font = style.bGroupBox.font;    break;
                case CheckBox chk:     chk.BackColor = style.bCheckBox.bc;     chk.ForeColor = style.bCheckBox.fc;    chk.Font = style.bCheckBox.font;   break;
                case RadioButton rb:   rb.BackColor =  style.bRadioButton.bc;  rb.ForeColor = style.bRadioButton.fc;  rb.Font = style.bRadioButton.font; break;
                case Form f:           f.BackColor =   style.bForm.bc;         f.ForeColor = style.bForm.fc;          f.Font = style.bForm.font;         break;
                case DataGridView dgv: 
                    dgv.BackColor = style.bDGV.bc;        
                    dgv.ForeColor = style.bDGV.fc;        
                    dgv.Font = style.bDGV.font;        
                    dgv.DefaultCellStyle = style.bDGV.cellstyle; 
                    dgv.ColumnHeadersDefaultCellStyle = style.bDGV.headerstyle; 
                    dgv.GridColor = style.bDGV.gridcolor; 
                    dgv.EnableHeadersVisualStyles = style.bDGV.enableheaderstyle;
                    dgv.BorderStyle = style.bDGV.bstyles.BorderStyle;
                    dgv.CellBorderStyle = style.bDGV.bstyles.CellBorderStyle;
                    dgv.RowHeadersBorderStyle = style.bDGV.bstyles.RowHeaderBorderStyle;
                    dgv.ColumnHeadersBorderStyle = style.bDGV.bstyles.ColumnHeaderBorderStyle;
                    break;
            }
        }

        static bool CanOverride(Control ctr)
        { return (ctr.Tag == null) || !(ctr.Tag.ToString().ToLower().Replace(" ", "") == DONT_OVERRIDE_TAG); }

        internal class Style<T> where T : Form, new()
        {
            internal struct borderStyles 
            {
                public BorderStyle BorderStyle;
                public DataGridViewCellBorderStyle CellBorderStyle;
                public DataGridViewHeaderBorderStyle RowHeaderBorderStyle;
                public DataGridViewHeaderBorderStyle ColumnHeaderBorderStyle; 
            }

            internal struct baseProgressBar  { public Color bc; public Color fc; public int  step; public int animSpeed; }
            internal struct baseTextBox      { public Color bc; public Color fc; public Font font; public BorderStyle border; }
            internal struct baseListBox      { public Color bc; public Color fc; public Font font; public BorderStyle border; }
            internal struct baseButton       { public Color bc; public Color fc; public Font font; public FlatStyle flat; }
            internal struct baseComboBox     { public Color bc; public Color fc; public Font font; public FlatStyle flat; }
            internal struct baseForm         { public Color bc; public Color fc; public Font font; }
            internal struct baseLabel        { public Color bc; public Color fc; public Font font; }
            internal struct baseGroupBox     { public Color bc; public Color fc; public Font font; }
            internal struct baseCheckBox     { public Color bc; public Color fc; public Font font; }
            internal struct baseRadioButton  { public Color bc; public Color fc; public Font font; }
            internal struct baseDataGridView { 
                public Color bc; 
                public Color fc; 
                public Font font; 
                public DataGridViewCellStyle cellstyle; 
                public DataGridViewCellStyle headerstyle; 
                public Color gridcolor; 
                public bool enableheaderstyle;
                public borderStyles bstyles;
            }


            public baseTextBox bTextBox;
            public baseListBox bListBox;
            public baseButton bButton;
            public baseComboBox bComboBox;
            public baseLabel bLabel;
            public baseGroupBox bGroupBox;
            public baseCheckBox bCheckBox;
            public baseRadioButton bRadioButton;
            public baseProgressBar bProgressBar;
            public baseForm bForm;
            public baseDataGridView bDGV;

            public Style()
            {
                Form form = new T();
                bForm = new baseForm { bc = form.BackColor, fc = form.ForeColor, font = form.Font };
                foreach (Control ctr in form.Controls)
                {
                    switch (ctr)
                    {
                        case TextBox tb:       bTextBox     = new baseTextBox      { bc = tb.BackColor,  fc = tb.ForeColor,  font = tb.Font, border = tb.BorderStyle               }; break;
                        case ListBox lb:       bListBox     = new baseListBox      { bc = lb.BackColor,  fc = lb.ForeColor,  font = lb.Font, border = lb.BorderStyle               }; break;
                        case Button btn:       bButton      = new baseButton       { bc = btn.BackColor, fc = btn.ForeColor, font = btn.Font, flat = btn.FlatStyle                 }; break;
                        case ComboBox cb:      bComboBox    = new baseComboBox     { bc = cb.BackColor,  fc = cb.ForeColor,  font = cb.Font, flat = cb.FlatStyle                   }; break;
                        case ProgressBar pb:   bProgressBar = new baseProgressBar  { bc = pb.BackColor,  fc = pb.ForeColor,  step = pb.Step, animSpeed = pb.MarqueeAnimationSpeed  }; break;
                        case Label lbl:        bLabel       = new baseLabel        { bc = lbl.BackColor, fc = lbl.ForeColor, font = lbl.Font                                       }; break;
                        case GroupBox gb:      bGroupBox    = new baseGroupBox     { bc = gb.BackColor,  fc = gb.ForeColor,  font = gb.Font                                        }; break;
                        case CheckBox chk:     bCheckBox    = new baseCheckBox     { bc = chk.BackColor, fc = chk.ForeColor, font = chk.Font                                       }; break;
                        case RadioButton rb:   bRadioButton = new baseRadioButton  { bc = rb.BackColor,  fc = rb.ForeColor,  font = rb.Font                                        }; break;
                        case DataGridView dgv: bDGV = new baseDataGridView
                        {
                            bc = dgv.BackColor,
                            fc = dgv.ForeColor,
                            font = dgv.Font,
                            cellstyle = dgv.DefaultCellStyle,
                            headerstyle = dgv.ColumnHeadersDefaultCellStyle,
                            gridcolor = dgv.GridColor,
                            enableheaderstyle = dgv.EnableHeadersVisualStyles,
                            bstyles = { BorderStyle = dgv.BorderStyle, 
                                        CellBorderStyle = dgv.CellBorderStyle, 
                                        ColumnHeaderBorderStyle = dgv.ColumnHeadersBorderStyle, 
                                        RowHeaderBorderStyle = dgv.RowHeadersBorderStyle 
                                      },

                        }; break;
                    }
                }
            }
        }
    }
}