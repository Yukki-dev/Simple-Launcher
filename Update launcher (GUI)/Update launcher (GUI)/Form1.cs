using System;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Update_launcher__GUI_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string CurrentPath = Environment.CurrentDirectory + @"\",
                appName = "launcher.exe";

            Thread.Sleep(750);
            if (File.Exists(CurrentPath + appName))
            {
                File.Delete(CurrentPath + appName);
                if (File.Exists(CurrentPath + "temp_update"))
                {
                    File.Move(CurrentPath + "temp_update", CurrentPath + @"\launcher.exe");
                    if (File.Exists(CurrentPath + "launcher" + @"\temp_update"))
                    {
                        File.Delete(CurrentPath + "launcher" + @"\temp_update");
                        //MessageBox.Show("Файл удален");
                    }
                }
                else
                {
                    if (File.Exists(CurrentPath + "launcher" + @"\temp_update"))
                    {
                        File.Move(CurrentPath + "launcher" + @"\temp_update", CurrentPath + @"\Launcher.exe");
                        //MessageBox.Show("Файл перемещен");
                    }
                    else
                    {
                        MessageBox.Show("Куда делся temp_update? О_О");
                        Close();
                    }
                }
                Thread.Sleep(300);
                Process.Start(CurrentPath + "launcher.exe");
                Thread.Sleep(300);
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
