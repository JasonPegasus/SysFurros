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
                if (e.KeyData == Keys.G ) { StyleManager.ApplyStyle(this, StyleManager.DARK_DEFAULT); }
                if (e.KeyData == Keys.H) { StyleManager.ApplyStyle(this, StyleManager.WINDOWS_DEFAULT); }
            };
        }
    }
}
