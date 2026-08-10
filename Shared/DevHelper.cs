using System.Drawing;

namespace Shared
{
    public static class DevHelper
    {
        public static Exception FormatError(string text, Exception exception)
        { return new Exception($"{text}:\n{exception.Message}\n\n"); }

        public static string CurrentDate()
        { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); }


        public enum PrintType { Log, Warn, Error, FatalError }

        public static readonly Dictionary<PrintType, Color> PrintTypeColors = new()
        {
            { PrintType.Log, Color.White },
            { PrintType.Warn, Color.Gold },
            { PrintType.Error, Color.Red },
            { PrintType.FatalError, Color.DarkRed },
        };

        public static event Action<string, PrintType>? OnPrint;

        public static void Print(string text, PrintType pType = 0)
        {
            string fullLog = $"[{CurrentDate()}] {text}";
            OnPrint?.Invoke(fullLog, pType);
        }
    }
}
