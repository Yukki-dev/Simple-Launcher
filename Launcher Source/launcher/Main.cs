using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Launcher;
using SevenZip;

namespace launcher
{
    public partial class Main : Form
    {
        // 7z библиотеки https://archive.codeplex.com/?p=sevenzipsharp

        public class IniRW //Класс для чтения/записи INI-файлов
        {
            //Конструктор, принимающий путь к INI-файлу
            public IniRW(string aPath)
            {
                _path = aPath;
            }
            //Конструктор без аргументов (путь к INI-файлу нужно будет задать отдельно)

            //Возвращает значение из INI-файла (по указанным секции и ключу) 
            public string GetPrivateProfileString(string aSection, string aKey)
            {
                //Для получения значения
                StringBuilder buffer = new StringBuilder(SIZE);

                //Получить значение в buffer
                GetPrivateString(aSection, aKey, null, buffer, SIZE, _path);

                //Вернуть полученное значение
                return buffer.ToString();
            }

            //Пишет значение в INI-файл (по указанным секции и ключу) 
            public void WritePrivateString(string aSection, string aKey, string aValue)
            {
                //Записать значение в INI-файл
                WritePrivateString(aSection, aKey, aValue, _path);
            }

            //Возвращает или устанавливает путь к INI файлу
            private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
            private string _path; //Для хранения пути к INI-файлу

            //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
            private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);
            //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
            [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
            private static extern int WritePrivateString(string section, string key, string str, string path);
        }

        private static readonly Stopwatch DLTime = new Stopwatch();

        MainValues varPath = new MainValues();          // пути
        MainValues MergeValues = new MainValues();      // Переменный для сравнения версий
        MainValues DLvalue = new MainValues();          // Для отображения размеров файлов

        public Main()
        {
            InitializeComponent();
            try
            {
                //varPath.StartChecking(); // получаем все нужные значения
                Text = $"{Text} v. {MergeValues.LauncherVersion}";
                Merge();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        void Debug()
        {
            tbx_Debug.Text = $"***            Значения переменных         ***\n" + Environment.NewLine + 
                             $"сайт                 - {MainValues.Siteadress}\n" + Environment.NewLine +
                             $"сервер               - {MergeValues.ServerAdress}:{MergeValues.ServerPort}\n" + Environment.NewLine +
                             $"***                Режимы                  ***\n" + Environment.NewLine +
                             $"соединение           - {MainValues.Connected}\n" + Environment.NewLine +
                             $"обновление лаунчера  - {MainValues.Launcherupdate}\n" + Environment.NewLine +
                             $"требуются библиотеки - {MainValues.NeedSevenZipDll}\n" + Environment.NewLine +
                             $"проект установлен    - {MainValues.Installed}\n" + Environment.NewLine +
                             $"проект обновлен      - {MainValues.Updated}\n" + Environment.NewLine +
                             $"***        Значения локал / сервер         ***\n" + Environment.NewLine +
                             $"версия лаунчера      - {MergeValues.LauncherVersion} / {MergeValues.Appupdateserver}" + Environment.NewLine +
                             $"версия установщика   - {MergeValues.InstallVersion} / {MergeValues.InstallVersionserver}\n" + Environment.NewLine +
                             $"версия обновления    - {MergeValues.UpdateVersion} / {MergeValues.UpdateVersionserver}";
            
        }

        #region Merge

        private void Merge()
        {
            MergeValues.StartChecking(); // получаем все нужные значения
            try
            {
                if (MainValues.Installed) // если версия установщика актуальная
                {
                    if (MainValues.Updated) // версии установщика равны
                    {
                        label_status_bar.Text = "Обновление не требуется";
                        if (!MainValues.Updated) // версии исправлений НЕ равны
                        {
                            // кнопка исправить
                            progressBar1.Visible = true;
                            btn_UPDATE.Visible = true;
                            btn_UPDATE.Text = "Исправить";
                            label_status_bar.Text = "Доступны исправления";
                        }
                        else
                        {
                            // версии исправлений РАВНЫ
                            btn_UPDATE.Visible = false;
                            progressBar1.Visible = false;
                            label_status_bar.Text = "Обновление не требуется";
                        }
                    }
                }
                else
                {
                    label_status_bar.Text = "Не установлено";
                }
                Debug();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion Merge

        #region Установка

        void Install()
        {
            try
            {
                progressBar1.Maximum = 100;
                var dlInstall = new WebClient();
                try
                {
                    var uri = new Uri(MainValues.WebPathInstall);//ссылка на фаил
                    dlInstall.DownloadFileAsync(uri, varPath.Launcherfolder + "install.7z");//сохраняем фаил под именем
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                //Следующей строчкой задаем заполнение и привязку к действию
                DLTime.Start();
                dlInstall.DownloadProgressChanged += WebClient_DownloadProgress;
                dlInstall.DownloadFileCompleted += Install_DownloadFileCompleted;
                btn_UPDATE.Enabled = false;
                btn_PLAY.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // Установка

        void Install_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DLTime.Reset();
            progressBar1.Value = 0;//сброс progressBar1  
            SevenZipBase.SetLibraryPath(varPath.Launcherfolder + "7z.dll"); // фурыкает
            InstallProgress();
        } // загрузка завершена

        void InstallProgress()
        {
            try
            {

                progressBar1.Maximum = 100;
                string fileName = varPath.Launcherfolder + "install.7z";
                var extr = new SevenZipExtractor(fileName);
                progressBar1.Invoke(new Action(() => progressBar1.Maximum = (int)extr.FilesCount));
                extr.FileExtractionStarted += Extr_FileExtractionStarted;
                extr.ExtractionFinished += Extr_ExtractionFinishedInstall;
                extr.BeginExtractArchive(Environment.CurrentDirectory);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // начинает распаковку

        private void Extr_ExtractionFinishedInstall(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                if (!File.Exists(varPath.Launcherfolder + "launcher.ini"))
                {
                    File.Create(varPath.Launcherfolder + "launcher.ini");
                }
                IniRW installDone = new IniRW(varPath.Launcherfolder + "launcher.ini");
                installDone.WritePrivateString("Build", "version", MergeValues.InstallVersionserver);
                installDone.WritePrivateString("Install", "installed", "true");

                MergeValues.Checker(); // блок сравнения значений сервер/локал

                btn_PLAY.Enabled = true;
                File.Delete(varPath.Launcherfolder + "install.7z"); // удаляет архив с установщиком
                Merge();
                if (!MainValues.Updated)
                {
                    InstallFix();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // распаковка завершена

        #endregion

        #region Установка исправлений
        void InstallFix()
        {
            try
            {
                progressBar1.Maximum = 100;
                WebClient Fixing = new WebClient();
                try
                {
                    Uri uri = new Uri(MainValues.WebPathFix);//ссылка на файл
                    Fixing.DownloadFileAsync(uri, varPath.Launcherfolder + "fix.7z");//сохраняем файл под именем
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                DLTime.Start();
                Fixing.DownloadProgressChanged += WebClient_DownloadProgress;
                Fixing.DownloadFileCompleted += InstallFix_DownloadFileCompleted;
                btn_UPDATE.Enabled = false;
                btn_PLAY.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // Установка исправлений

        private void InstallFix_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DLTime.Reset();
            progressBar1.Value = 0; //сброс progressBar1  
            InstallFixProgress();
        } // загрузка завершена

        private void InstallFixProgress()
        {
            try
            {
                progressBar1.Invoke(new Action(() => progressBar1.Maximum = 100));
                SevenZipBase.SetLibraryPath(varPath.Launcherfolder + "7z.dll"); // фурыкает

                string fileName = varPath.Launcherfolder + "fix.7z";

                var extr = new SevenZipExtractor(fileName);

                progressBar1.Invoke(new Action(() => progressBar1.Maximum = (int)extr.FilesCount));
                extr.FileExtractionStarted += Extr_FileExtractionStarted;
                extr.ExtractionFinished += Extr_ExtractionFinishedFix;
                extr.BeginExtractArchive(Environment.CurrentDirectory);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // начинает распаковку

        private void Extr_ExtractionFinishedFix(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                if (File.Exists(varPath.Launcherfolder + "launcher.ini"))
                {
                    IniRW fixInstallDone = new IniRW(varPath.Launcherfolder + "launcher.ini");
                    fixInstallDone.WritePrivateString("Build", "version", MergeValues.InstallVersionserver); // повтор, может потереть
                    fixInstallDone.WritePrivateString("Build", "update", MergeValues.UpdateVersionserver); // записывает значения обновления
                    fixInstallDone.WritePrivateString("Install", "installed", "true");
                }
                else
                {
                    MessageBox.Show("При исправлении произошла ошибка");
                }

                //MergeValues.Checker();              // блок сравнения значений сервер/локал
                Merge();

                btn_UPDATE.Visible = false;
                btn_PLAY.Enabled = true;
                File.Delete(varPath.Launcherfolder + "fix.7z");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // распаковка завершена

        #endregion

        #region Общий вывод состояния загрузки/установки

        private void WebClient_DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = e.ProgressPercentage));// заполняем 

                label_status_bar.Invoke(new Action(() => label_status_bar.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)));
                label_status_bar.Invoke(new Action(() => label_status_bar.Text = $"Загружено: {DLvalue.DLsize(e.BytesReceived)} / {DLvalue.DLsize(e.TotalBytesToReceive)}"));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // состояние загрузки файлов

        private void Extr_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            try
            {
                label_status_bar.Invoke(new Action(() => label_status_bar.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204)));
                label_status_bar.Invoke(new Action(() => label_status_bar.Text = $"Установка: {e.FileInfo.FileName}"));
                progressBar1.Increment(1);  // ЗАПОЛНЕНИЕ ПРОГРЕССА
                progressBar1.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        } // процесс распаковки
        #endregion

        private void btn_UPDATE_Click(object sender, EventArgs e)
        {
            Install();
        }

        private void btn_PLAY_Click(object sender, EventArgs e)
        {
            MessageBox.Show("runned");
        }
    }
}
