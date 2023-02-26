using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using System.IO;

namespace Client
{
    public class DownloadFile
    {
        string m_Url, m_SavePath, m_FileName;
        WebClient m_Client;

        public DownloadFile(string url, string savePath, string fileName)
        {
            m_Url = url;
            m_SavePath = savePath;
            m_FileName = fileName;
            m_Completed = false;
            m_Client = new WebClient();
            StartDownloading();
        }
        public void StartDownloading()
        {
            if (Directory.Exists(m_SavePath) == false)
            {
                Directory.CreateDirectory(m_SavePath);
            }
            m_Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
            m_Client.DownloadProgressChanged += DownloadUpdate;
            m_Client.DownloadFileAsync(new Uri(m_Url), m_SavePath+m_FileName);
        }
        private void DownloadUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            m_TotalMegaBytes = (float)(e.TotalBytesToReceive / 1000000f);
            m_ReceivedMegaBytes = (float)(e.BytesReceived / 1000000f);
            m_TotalProgress = e.ProgressPercentage;
        }
        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            m_Completed = true;
        }

        bool m_Completed;
        float m_TotalMegaBytes, m_ReceivedMegaBytes;
        int m_TotalProgress;
        public float TotalMegaBytes
        {
            get { return m_TotalMegaBytes; }
        }
        public float ReceivedMegaBytes
        {
            get { return m_ReceivedMegaBytes; }
        }
        public int TotalProgress
        {
            get { return m_TotalProgress; }
        }
        public bool Completed
        {
            get { return m_Completed; }
            set { m_Completed = value; }
        }
        public string FullPath
        {
            get { return m_SavePath + m_FileName; }
        }
        public string FolderPath
        {
            get { return m_SavePath; }
        }
        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
