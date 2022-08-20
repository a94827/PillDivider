using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FreeLibSet.Forms;

namespace PillDivider
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      try
      {
        EFPApp.InitApp();

        Application.Run(new MainForm());
      }
      catch (Exception e)
      {
        EFPApp.ShowException(e, "������ ������� ���������");
      }
    }
  }
}