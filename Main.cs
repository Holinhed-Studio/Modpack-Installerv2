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
        // Wait 200 milliseconds.
        Thread.Sleep(200);
        // Report progress.
        Downloading.progressBar1.Value = i;
      }
      a.WaitForExit();
      string bArgs = ("/MIR /Z /W:1 modpack ..\\.modpack");
      Process b = Process.Start("robocopy", bArgs);
      for (int i = 51; i <= 100; i++)
      {
        // Wait 200 milliseconds.
        Thread.Sleep(200);
        // Report progress.
        Downloading.progressBar1.Value = i;
      }
      b.WaitForExit();
      Downloading.Hide();
      this.Show();
      Directory.Delete ("modpack", true);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Hide();
      var forgeInstall = new ForgeInstall();
      forgeInstall.Show();
      Process p = Process.Start("java.exe");
    }
    private void button4_Click(object sender, EventArgs e)
    {

    }
 
    private void button5_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    [DllImport("user32.dll")]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
  }
}
