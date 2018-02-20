using Launcher;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace launcher
{
    public partial class DllLoad : Form
    {
        readonly MainValues StartLauncher = new MainValues();
        private string dllName = null;
        private string appUPD = "upd.exe";
        private string LauncherName = "launcher.exe";
        private string temp_update = "temp_update"; // временное название скачанной новой версии лаунчера. Это название прописано в upd.exe, при замене - менять и там

        // В program.cs пути провисаны явно. Учитывать при изменении имен библиотек
        public string dllLib1 = "7z.dll";
        private string dllLib2 = "SevenZipSharp.dll";

        public DllLoad()
        {
            InitializeComponent();
            if (MainValues.Launcherupdate)
            {
                Status.Text = "Обновление лаунчера...";
                Downloadupdapp(); // обновляемся
            }
            //MessageBox.Show("Load DLL -- " + Modes.NeedSevenZipDll + " --");
            if (MainValues.NeedSevenZipDll)
            {
                Status.Text = "Подготовка к запуску...";
                cLBox_Dll.Visible = true;
                cLBox_Dll.Items.Add(dllLib1);
                cLBox_Dll.Items.Add(dllLib2);
                Download7Z(); // скачиваем библиотеки
            }
        }

        #region UPDATE
        void Downloadupdapp()
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(MainValues.Siteadress + "/" + appUPD);//для примера ссылка на фаил))))))))
            client.DownloadFileAsync(uri, Environment.CurrentDirectory + @"\" + appUPD);//сохраняем фаил под именем
            client.DownloadProgressChanged += webClient_DownloadFileProgressUPDAPP;
            client.DownloadFileCompleted += webClient_DownloadFileCompletedUPDAPP;
        }

        void webClient_DownloadFileProgressUPDAPP(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Invoke(new Action(() => progressBar1.Value = e.ProgressPercentage));// заполняем 
        } // состояние загрузки

        void webClient_DownloadFileCompletedUPDAPP(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = 0));// заполняем 
                progressBar1.Invoke(new Action(() => progressBar1.Maximum = 100));// сбрасываем 
                Updatelauncher();
            }
            catch{/*можно вывести описание ошибки, иначе ничего не будет*/}
        }

        void Updatelauncher()
        {

            WebClient client = new WebClient();
            Uri uri = new Uri(MainValues.Siteadress + "/" + LauncherName);//для примера ссылка на фаил))))))))
            client.DownloadFileAsync(uri, Environment.CurrentDirectory + @"\" + temp_update);//сохраняем файл под именем
            client.DownloadProgressChanged += webClient_DownloadFileProgressDll;
            client.DownloadFileCompleted += webClient_DownloadFileCompletedUPD;
        }

        void webClient_DownloadFileCompletedUPD(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = 0));// заполняем 
                progressBar1.Invoke(new Action(() => progressBar1.Maximum = 100));// сбрасываем 
                Process.Start(Environment.CurrentDirectory + @"\" + appUPD);
                Environment.Exit(0);
            }
            catch {/*можно вывести описание ошибки, иначе ничего не будет*/}
        }
        #endregion

        #region 7Z dll

        private void Download7Z()
        {
            WebClient dll7Z = new WebClient();
            Uri uri = new Uri(MainValues.Siteadress + "/" + dllLib1);
            dll7Z.DownloadFileAsync(uri, StartLauncher.Launcherfolder + dllLib1); //сохраняем файл
            dll7Z.DownloadProgressChanged += webClient_DownloadFileProgressDll;
            dll7Z.DownloadFileCompleted += webClient_DownloadFileCompleted7z;
        } // загрузка 7z

        void webClient_DownloadFileCompleted7z(object sender, AsyncCompletedEventArgs e)
        {
            cLBox_Dll.SetItemCheckState(0, CheckState.Checked);
            if (File.Exists(StartLauncher.Launcherfolder + dllLib2))
            {
                // библиотека есть
                cLBox_Dll.SetItemCheckState(1, CheckState.Checked);
                Close(); // ок
            }
            else
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = 0));// заполняем 
                progressBar1.Invoke(new Action(() => progressBar1.Maximum = 100));// сбрасываем 
                DownloadSevenZip();
            }
        } // 7z загружена

        private void DownloadSevenZip()
        {
            WebClient dll7zip = new WebClient();
            Uri uri = new Uri(MainValues.Siteadress + "/" + dllLib2);
            dll7zip.DownloadFileAsync(uri, StartLauncher.Launcherfolder + dllLib2); //сохраняем файл
            dll7zip.DownloadProgressChanged += webClient_DownloadFileProgressDll;
            dll7zip.DownloadFileCompleted += webClient_DownloadFileCompletedSevenZipSharp;
        } // загрузка SevenZipSharp

        void webClient_DownloadFileCompletedSevenZipSharp(object sender, AsyncCompletedEventArgs e)
        {
            cLBox_Dll.SetItemCheckState(1, CheckState.Checked);
            if (File.Exists(StartLauncher.Launcherfolder + dllLib1) &&
                File.Exists(StartLauncher.Launcherfolder + dllLib2))
            {
                Close(); // Ok
            }
            else
            {
                MessageBox.Show("При загрузке библиотек возникла ошибка, приложение будет закрыто");
                Environment.Exit(1); // полностью закрывает программу
            }
        } // SevenZipSharp загружена

        void webClient_DownloadFileProgressDll(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Invoke(new Action(() => progressBar1.Value = e.ProgressPercentage));// заполняем 
        } // состояние загрузки библиотек

        #endregion
    }
}
