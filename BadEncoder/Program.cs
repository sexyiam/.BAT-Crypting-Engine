using System;
using System.Windows.Forms;

namespace BadEncoder
{
  internal static class Program
  {
    [STAThread]
    private static void bMain() => Console.ReadLine();

    [STAThread]
    private static void Main()
    {
      System.Diagnostics.Process.Start("https://t.me/+bL06ZatKrDdkMjBh");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
