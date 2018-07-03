using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Nutanix.PowerShell.SDK
{
  public static class Log
  {
    [Conditional("DEBUG")]
    public static void Write(
                          string text,
                          [CallerFilePath] string file = "",
                          [CallerMemberName] string member = "",
                          [CallerLineNumber] int line = 0)
    {
      string LogFolder = Path.GetTempPath();
      string LogFileName = String.Format("NTNXCmdlets-{0:yyyy-MM-dd}.log", DateTime.Now);
      string LogFile = Path.Combine(LogFolder, LogFileName);

      using (StreamWriter w = File.AppendText(LogFile))
      {
        w.WriteLine("{4} {0}:{2} ({1}): {3}", Path.GetFileName(file), member, line, text, DateTime.Now.ToString("MMdd HH:mm:ss.ff"));
      }
    }
  }
}
