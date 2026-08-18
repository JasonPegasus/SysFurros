using DataAccess.Session.DTOs;
using Shared;

namespace AdminPanel
{
    public partial class MainForm : Form
    {
        Font defaultConsoleFont;

        public MainForm()
        {
            InitializeComponent();
            BT_SQL_Start.Click += (_, _) => SwitchSQLService(true);
            BT_SQL_Stop.Click += (_, _) => SwitchSQLService(false);
            BT_Test.Click += (_, _) => DoTest();

            defaultConsoleFont = CONSOLE.Font;

            DevHelper.OnPrint += (msg, pType) => PrintToConsole(msg, pType);
            PrintToConsole("                         [ Syfur Admin Console ]", Color.FromArgb(152, 0, 0), new Font("monotype corsiva", 20, FontStyle.Regular));
            PrintToConsole("(C) 2026 /// Maximo Raziel F.J. - Valentina A. Mironchik - Candela R.L. Ortiz", Color.FromArgb(152, 0, 0));
            PrintToConsole("---------------------------------------------------------------------------", Color.FromArgb(152, 0, 0));
        }

        void DoTest()
        {
            //DT_Persona? pers = DT_Persona.Create("pepe", "argento", 58798546, "54 9 11 5987-5468", 1, "https://imagen.com o algo asi", 54898756);
            DT_Persona? pers = DT_Persona.Find(1);
            if (pers is null) return;
            //pers["nombres"] = "ENRIQUE";
            //pers.PushData();
            pers.PullData();
            foreach (var v in pers.VALUES)
            {
                if (v.Key is null || v.Value is null) continue;
                DevHelper.Print(v.ToString());
            }
        }

        void PrintToConsole(string msg, DevHelper.PrintType pType, Font? font = null)
        { PrintToConsole(msg, DevHelper.PrintTypeColors[pType]); }

        void PrintToConsole(string msg, Color color, Font? font = null)
        {
            RichTextBox c = CONSOLE;
            c.SelectionStart = c.Text.Length;
            c.SelectionLength = 0;
            c.SelectionColor = color;
            if (font is not null) { c.SelectionFont = font; }
            c.AppendText(msg + "\n");
            if (CH_AutoScroll.Checked) { c.ScrollToCaret(); }
        }

        public void SwitchSQLService(bool start)
        { DevHelper.Print((new CmdExecute($"sc {(start ? "start" : "stop")} MSSQL$SQLEXPRESS")).Run()); }
    }
}
