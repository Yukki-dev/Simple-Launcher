using launcher;
using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Launcher
{
    public class MainValues
    {
        public readonly string
            LauncherVersion = "1.0"; // Жестко прописано в коде, но можно вынести и в файл

        public static readonly string
            Siteadress = "http://launcher.site",            // адрес по умолчанию
            WebPathInstall = Siteadress + "/install.7z",    // путь до архива с установщиком
            WebPathFix = Siteadress + "/fix.7z";            // путь до архива с фиксами

        // проверка соединения с интернетом
        public readonly string
            ServerAdress = "127.0.0.1",                     // IP адрес сервера
            ServerPort = "80",                              // Порт сервера

            Launcherfolder = Environment.CurrentDirectory + @"\launcher\"; // путь к папке лаунчера 

        public static bool         // режимы лаунчера
            Connected,      // соединение с сервером
            Launcherupdate, // обновление лаунчера
            NeedSevenZipDll,// наличие библиотек
            Installed,      // установка выполнена
            Updated;        // обновлено

        // переменные для сервера
        public string
            InstallVersionserver,   // версия установщика на сервере
            UpdateVersionserver,    // версия обновления на сервере
            Appupdateserver;        // версия лаунчера на сервере

        // локальные значения
        public string
            InstallVersion,// версия установщика на ПК
            UpdateVersion; // версия обновлений на ПК

        public void StartChecking()
        {
            CheckConnection(); // Проверка соединения с интернетом + считывание значений сервера
            if (!Directory.Exists(Launcherfolder))
            {
                try
                {
                    Directory.CreateDirectory(Launcherfolder);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
            if (Connected)
            {
                Updateapp(); // обновление лаунчера
                DownloadDll(); // проверка наличия библиотек
            }
            GetvaluesfromLocal();
            Checker(); // блок сравнения значений сервер/локал
            if (!Connected)
            {
                MessageBox.Show("Невозможно установить соединение с сервером.\nПриложение будет закрыто.", "Внимание!",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0); // Если наличие интернета крайне важно - закрываем прогу, иначе можно удалить эту строку
            }
        }

        private void CheckConnection() // ПРОВЕРКА ПОДКЛЮЧЕНИЯ К СЕТИ / считывание значений c сервера
        {
            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(ServerAdress, Convert.ToInt32(ServerPort)); // проверка соединения с интернетом, можно указать IP сервера своего сайта
                Connected = true;
                GetvaluesfromServer(); // получаем значения с сервера, чтоб больше не бегать
            }
            catch
            {
                if (File.Exists(Environment.CurrentDirectory + Launcherfolder + "SevenZipSharp.dll") &&
                    File.Exists(Environment.CurrentDirectory + Launcherfolder + "7z.dll"))
                {
                    Connected = false;
                }
            }
        } // ПРОВЕРКА ПОДКЛЮЧЕНИЯ К СЕТИ / считывание значений сервера

        private void Updateapp()
        {
            if (LauncherVersion != Appupdateserver)
            {
                Launcherupdate = true;
                if (MessageBox.Show(
                        $"Обнаружена новая версия лаунчера ({Appupdateserver}). Обновить? \nПриложение будет автоматически обновлено и перезапущено. \nНажмите 'Нет' для выхода",
                        Application.ProductName + " v" + LauncherVersion, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Enabled = false;
                    new DllLoad().ShowDialog(); // окно обновления лаунчера
                    //downloadupdapp();
                }
                else
                {
                    Environment.Exit(1);
                }
            }
            else
            {
                File.Delete(Environment.CurrentDirectory + "\\upd.exe");
            }
        } // обновление лаунчера


        private void DownloadDll()
        {
            if (!File.Exists(Launcherfolder + "SevenZipSharp.dll") ||
                !File.Exists(Launcherfolder + "7z.dll"))
            {
                NeedSevenZipDll = true; // это значит библиотек нету
                new DllLoad().ShowDialog();
            } // загрузка 7z
        }

        public void GetvaluesfromServer()
        {
            if (Connected) // если офлайн не проверять
            {
                try
                {
                    XElement servervalue = XElement.Load(Siteadress + "/launcher.xml");
                    InstallVersionserver = servervalue.Element("Install")?.Element("InstallVersion")?.Value;
                    UpdateVersionserver = servervalue.Element("Update")?.Element("Updateversion")?.Value;
                    Appupdateserver = servervalue.Element("Update")?.Element("launcherversion")?.Value;
                }
                catch
                {
                    Connected = false;
                    //Environment.Exit(0);
                }
            }
        } // получение значений с сервера

        private void GetvaluesfromLocal()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\launcher\launcher.ini"))
            {
                Main.IniRW testvariables = new Main.IniRW(Environment.CurrentDirectory + @"\launcher\launcher.ini");
                InstallVersion = testvariables.GetPrivateProfileString("Build", "version");
                UpdateVersion = testvariables.GetPrivateProfileString("Build", "update");
            }
        } // получение локальных значений

        public void Checker()
        {
            if (Connected) // только если есть соединение с сервом
            {
                if (Appupdateserver == LauncherVersion) // версии лаунчера равны
                {
                    Launcherupdate = true;
                }

                if (InstallVersionserver == InstallVersion) // версии установщика равны
                {
                    Installed = true;

                    if (UpdateVersionserver == UpdateVersion) // версии обновлений равны
                    {
                        Updated = true;
                    }
                }
            }
        }

        public string DLspeed(double speed)
        {
            string rezult = null;
            var speedс = Convert.ToInt32(speed);
            /*
             * 1 КБ = 1024 Б
             * 1 МБ = 1024 Кб ==> 1048576 Б
             * 1 ГБ = 1024 Мб ==> 1073741824 Б
             */
            if (speedс <= 1024) // если меньше килобайта
            {
                rezult = speedс + " Б/с"; // чтоб не терялась
            }
            if (speedс >= 1024) // если меньше мегабайта
            {
                rezult = (speedс/1024) + " КБ/с";
            }
            if (speedс >= 1048576) // больше мега
            {
                rezult = (speedс/1048576) + " МБ/с";
            }
            if (speedс > 1073741824) // больше гига
            {
                rezult = (speedс/1073741824) + " ГБ/с О_О";
            }
            return rezult;
        }

        public string DLsize(long size)
        {
            string rezult = null;

            if (size <= 1024) // если меньше килобайта
            {
                rezult = size + " Б"; // чтоб не терялась
            }
            if (size >= 1024) // если меньше мегабайта
            {
                rezult = (size/1024) + " КБ";
            }
            if (size >= 1048576) // больше мега
            {
                rezult = (size/1048576) + " МБ";
            }
            if (size > 1073741824) // больше гига
            {
                rezult = (size/1073741824) + " ГБ";
            }
            return rezult;
        }
    }
}