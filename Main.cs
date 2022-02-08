using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Hide();
      var Downloading = new DownloadRunning();
      Downloading.Show();
      string aArgs = (" -m -nH -d -A *.jar -T 3 -t 1 --cut-dirs=1 --no-parent cdn.firehostredux.com/fartsncomc/modpack/");
      Process a = Process.Start("workers\\wget.exe", aArgs);
      Downloading.progressBar1.Maximum = 100;
      Downloading.progressBar1.Step = 10;
      for (int i = 1; i <= 50; i++)
      {
        Thread.Sleep(200);
        Downloading.progressBar1.Value = i;
      }
      a.WaitForExit();
      string bArgs = ("/MIR /Z /W:1 modpack\\config ..\\.minecraft\\config");
      string xArgs = ("/MIR /Z /W:1 modpack\\mods ..\\.minecraft\\mods");
      string hArgs = ("/MIR /Z /W:1 modpack\\resourcepacks ..\\.minecraft\\resourcepacks");
      string zArgs = ("/MIR /Z /W:1 modpack\\shaderpacks ..\\.minecraft\\shaderpacks"); ;
      Process b = Process.Start("robocopy", bArgs);
      for (int i = 51; i <= 75; i++)
      {
        Thread.Sleep(200);
        Downloading.progressBar1.Value = i;
      }
      b.WaitForExit();
      Process x = Process.Start("robocopy", xArgs);
      for (int i = 76; i <= 100; i++)
      {
        Thread.Sleep(200);
        Downloading.progressBar1.Value = i;
      }
      x.WaitForExit();
      Process h = Process.Start("robocopy", hArgs);
      h.WaitForExit();
      Process z = Process.Start("robocopy", zArgs);
      z.WaitForExit();
      Downloading.Hide();
      this.Show();
      Directory.Delete("modpack/config", true);
      Directory.Delete("modpack/mods", true);
      Directory.Delete("modpack/resourcepacks", true);
      Directory.Delete("modpack/shaderpacks", true);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.Hide();
      if (Directory.Exists("backup\\config") || Directory.Exists("backup\\mods") || Directory.Exists("backup\\resourcepacks") || Directory.Exists("backup\\shaderpacks"))
      {
        MessageBox.Show("ERROR: You may only have one backup at a time!");
        this.Show();
      }
      else
      {
        string dArgs = ("/MIR /Z /W:1 ..\\.minecraft\\config .\\backup\\config");
        Process d = Process.Start("robocopy", dArgs);
        d.WaitForExit();
        string fArgs = ("/MIR /Z /W:1 ..\\.minecraft\\mods .\\backup\\mods");
        Process f = Process.Start("robocopy", fArgs);
        f.WaitForExit();
        string hArgs = ("/MIR /Z /W:1 ..\\.minecraft\\resourcepacks .\\backup\\resourcepacks");
        Process h = Process.Start("robocopy", hArgs);
        h.WaitForExit();
        string jArgs = ("/MIR /Z /W:1 ..\\.minecraft\\shaderpacks .\\backup\\shaderpacks");
        Process j = Process.Start("robocopy", jArgs);
        j.WaitForExit();
        this.Show();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Hide();
      string fArgs = ("-jar modpack/forge.jar");
      try
      {
        Process p = Process.Start("java", fArgs);
        p.WaitForExit();
        this.Show();
      }
      catch (Exception)
      {
        MessageBox.Show("JAVA.EXE COULD NOT BE FOUND. PLEASE VERIFY YOUR JAVA PATH OR INSTALL JAVA, THEN CLICK *INSTALL FORGE* AGAIN.");
        this.Show();
      }
    }
    private void button4_Click(object sender, EventArgs e)
    {
      this.Hide();
      if (!Directory.Exists("backup\\config") || !Directory.Exists("backup\\mods") || !Directory.Exists("backup\\resourcepacks") || !Directory.Exists("backup\\shaderpacks"))
      {
        MessageBox.Show("ERROR: No backups exist!");
        this.Show();
      }
      else
      {
        string wArgs = ("/MIR /Z /W:1 .\\backup\\config ..\\.minecraft\\config");
        Process w = Process.Start("robocopy", wArgs);
        w.WaitForExit();
        string yArgs = ("/MIR /Z /W:1 .\\backup\\mods ..\\.minecraft\\mods");
        Process y = Process.Start("robocopy", yArgs);
        y.WaitForExit();
        string aArgs = ("/MIR /Z /W:1 .\\backup\\resourcepacks ..\\.minecraft\\resourcepacks");
        Process a = Process.Start("robocopy", aArgs);
        a.WaitForExit();
        string cArgs = ("/MIR /Z /W:1 .\\backup\\shaderpacks ..\\.minecraft\\shaderpacks");
        Process c = Process.Start("robocopy", cArgs);
        c.WaitForExit();
        Directory.Delete("backup/config", true);
        Directory.Delete("backup/mods", true);
        Directory.Delete("backup/resourcepacks", true);
        Directory.Delete("backup/shaderpacks", true);
        this.Show();
      }
    }
 
    private void button5_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
