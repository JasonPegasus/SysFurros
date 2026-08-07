using View.Design.StyleForms;

namespace View
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            F_Login loginForm = new F_Login();
            loginForm.ShowDialog();
        }
    }
}