using System.Diagnostics;

namespace View
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
            StyleManager.ApplyStyle(this, StyleManager.DARK_DEFAULT);

            this.KeyDown += (object sender, KeyEventArgs e) => 
            {
                if (e.KeyData == Keys.NumPad1) { StyleManager.ApplyStyle(this, StyleManager.WINDOWS_DEFAULT); }
                if (e.KeyData == Keys.NumPad2) { StyleManager.ApplyStyle(this, StyleManager.DARK_DEFAULT); }
                if (e.KeyData == Keys.NumPad3) { StyleManager.ApplyStyle(this, StyleManager.DARK_BLACK); }
            };
        }
    }
}
