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
        }

        public void PrintToConsole(string msg, DevHelper.PrintType pType)
        {
            RichTextBox b = CONSOLE;
            b.SelectionStart = b.Text.Length;
            b.SelectionLength = 0;
            b.SelectionColor = DevHelper.PrintTypeColors[pType];
            b.AppendText(msg + "\n");
        }

        public void SwitchSQLService(bool start)
        {
            CmdExecute cmd = new($"sc {(start ? "start" : "stop")} MSSQL$SQLEXPRESS");
            DevHelper.Print(cmd.Run(), (DevHelper.PrintType) Random.Shared.Next(0, 4));
        }
    }
}
