using View.Design.StyleForms;

namespace View
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new F_Login());
        }
    }
}