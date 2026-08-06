using System.Diagnostics;
using System.Windows.Forms;
using View.Design;

namespace View
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
            StyleManager.ApplyStyle(this, StyleManager.DARK_DEFAULT);
            this.Load += (_, _) => Init();
            FormResizeController formResizer = new(this);

            this.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyData == Keys.NumPad1) { StyleManager.ApplyStyle(this, StyleManager.WINDOWS_DEFAULT); }
                if (e.KeyData == Keys.NumPad2) { StyleManager.ApplyStyle(this, StyleManager.DARK_DEFAULT); }
                if (e.KeyData == Keys.NumPad3) { StyleManager.ApplyStyle(this, StyleManager.DARK_BLACK); }
            };

            BT_PasswordView.Click += SwitchPasswordView;
        }


        void Init()
        {
            SetPasswordView(false);
        }

        bool passwordView = false;

        void SwitchPasswordView(object sender, EventArgs e)
        {
            BT_PasswordView.Update();
            passwordView = !passwordView;
            SetPasswordView(passwordView);
            this.Font = new Font(this.Font.FontFamily,50, Font.Style);
        }

        void SetPasswordView(bool view)
        {
            BT_PasswordView.BackColor = view ? Color.FromArgb(255, 100, 100, 100) : Color.FromArgb(255, 40, 40, 40);
            BT_PasswordView.Text = view ? "👁" : "✗";
        }
    }
}