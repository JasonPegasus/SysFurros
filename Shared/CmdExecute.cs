using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CmdExecute
    {
        static ProcessStartInfo startInfo = new ProcessStartInfo()
        {
            FileName = "cmd.exe",
            RedirectStandardOutput = true,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        public CmdExecute(string command, bool doRun = false) 
        {
            startInfo.Arguments = $"/c {command} 2>&1";
            if (doRun) { Run(); }
        }

        public string Run()
        {
            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd();
            }
        }
    }
}
