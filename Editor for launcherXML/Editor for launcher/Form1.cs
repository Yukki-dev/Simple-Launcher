using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace Editor_for_launcher
{
    public partial class MainWindow : Form
    {
        private string Install { get; set; }
        private string update { get; set; }
        private string launcherversion { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadFile();
        }

        private void LoadFile()
        {
            if (File.Exists(@"launcher.xml")) // считывание значений из файла
            {
                XElement ruupdate = XElement.Load(@"launcher.xml");

                Install = ruupdate.Element("Install")?.Element("InstallVersion")?.Value;
                update = ruupdate.Element("Update")?.Element("Updateversion")?.Value;
                launcherversion = ruupdate.Element("Update")?.Element("launcherversion")?.Value;
            }
            else // если файл не существует - создаем и заполняем произвольными данными
            {
                string strokav = "";
                StreamWriter SW = new StreamWriter(new FileStream("launcher.xml", FileMode.Create, FileAccess.Write));
                SW.Write(strokav);
                SW.Close();
                XElement ruupdate = new XElement
                ("launcher",
                    new XElement("Install",
                        new XElement("InstallVersion", "install #version#")),
                    new XElement("Update",
                        new XElement("Updateversion", "00.00.00"),
                        new XElement("launcherversion", "0.0"))
                );
                ruupdate.Save(@"launcher.xml");
                LoadFile(); // обновляем значения
            }
            try
            {
                txtBox_InstallVersion.Text = Install;           //версия установщика
                txtBox_UpdVersion.Text = update;                //версия обновлений
                txtBox_LauncherVersion.Text = launcherversion;  //версия лаунчера
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void MakeFile() // записываем новые значения в файл
        {
            Install = txtBox_InstallVersion.Text;
            update = txtBox_UpdVersion.Text;
            launcherversion = txtBox_LauncherVersion.Text; 

            XElement ruupdate =
                    new XElement
                        ("launcher",
                            new XElement("Install",
                                new XElement("InstallVersion", Install)),
                            new XElement("Update",
                                new XElement("Updateversion", update),
                                new XElement("launcherversion", launcherversion))
                        );
            ruupdate.Save(@"launcher.xml");
            MessageBox.Show("Сохранил!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtBox_LauncherVersion.Enabled = checkBox_AppVersion.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            txtBox_InstallVersion.Enabled = checkBox_Install.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            txtBox_UpdVersion.Enabled = checkBox_Update.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MakeFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
