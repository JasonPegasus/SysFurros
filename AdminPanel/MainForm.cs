using DataAccess.Session.DTOs;
using Shared;

namespace AdminPanel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            BT_SQL_Start.Click += (_, _) => SwitchSQLService(true);
            BT_SQL_Stop.Click += (_, _) => SwitchSQLService(false);
            DevHelper.OnPrint += PrintToConsole;
            DT_Persona pers = new("pepe", "argento", 45789123, "4847-1235", 5, "EEEE.PNG", 48954);
            DevHelper.Print($"Nombre: {pers.Nombres}");
        }

        void PrintToConsole(string msg, DevHelper.PrintType pType)
        {
            RichTextBox b = CONSOLE;
            b.SelectionStart = b.Text.Length;
            b.SelectionLength = 0;
            b.SelectionColor = DevHelper.PrintTypeColors[pType];
            b.AppendText(msg + "\n");
        }

        public void SwitchSQLService(bool start)
        { DevHelper.Print((new CmdExecute($"sc {(start ? "start" : "stop")} MSSQL$SQLEXPRESS")).Run()); }
    }
}
