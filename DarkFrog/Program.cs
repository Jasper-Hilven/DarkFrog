using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkFrog.Core;
using Environment = DarkFrog.Core.Environment;

namespace DarkFrog
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      var e = new Environment();
      e.SaveEnvironment(@"C:\Users\Jasper\Desktop\fs.txt");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
