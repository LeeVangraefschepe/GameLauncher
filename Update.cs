using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Update : Form
    {
        Scaler scaler;
        List<DownloadFile> downloadFiles = new List<DownloadFile>();
        List<Control> downloadControls = new List<Control>();
        DateTime timeCompleted;
        int isValidInstall = -1;
        bool done;
        string destinationFolder = "C:/temp/LEEVGS/";
        public Update()
        {
            InitializeComponent();

            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);

            scaler = new Scaler(this.Width, this.Height, Controls);
            timeCompleted = DateTime.MinValue;
            downloadControls.Add(LblDetails);
            downloadControls.Add(progressDownload);

            //downloadFiles.Add(new DownloadFile("https://www.dropbox.com/s/fwbl0kum9obd4gi/Future%20war%20V5.zip?dl=1", destinationFolder, "Test.zip"));
            downloadFiles.Add(new DownloadFile("https://docs.google.com/document/d/1s1HSYsv8MXjW9rrfB1QJkAxeDjpx0EwEm9oQF7XeKBc/export?format=txt", destinationFolder, "version.ini"));
        }
        private void Update_Resize(object sender, EventArgs e)
        {
            scaler.ScaleAllControls(Controls, this.Width, this.Height);
        }
        private void ticks_Tick(object sender, EventArgs e)
        {
            float totalMegaBytes = 0, receivedMegaBytes = 0;
            bool allCompleted = true;
            foreach(DownloadFile downloadFile in downloadFiles)
            {
                totalMegaBytes += downloadFile.TotalMegaBytes;
                receivedMegaBytes += downloadFile.ReceivedMegaBytes;
                if (allCompleted == true)
                {
                    allCompleted = downloadFile.Completed;
                }
            }
            progressDownload.Maximum = (int)totalMegaBytes;
            progressDownload.Value = (int)receivedMegaBytes;
            LblDetails.Text = $"{Math.Round(receivedMegaBytes,2)}MB/{Math.Round(totalMegaBytes,2)}MB";
            if (allCompleted)
            {
                if (isValidInstall == -1)
                {
                    CheckIsValidInstall();
                }
                //Wait before launch
                if (timeCompleted == DateTime.MinValue)
                {
                    timeCompleted = DateTime.Now;
                }
                if (timeCompleted.AddSeconds(1) <= DateTime.Now && done == false)
                {
                    done = true;
                    if (isValidInstall == 1)
                    {
                        this.Hide();
                        Client client = new Client(); //this is the change, code for redirect  
                        client.ShowDialog();
                    }
                    else if (isValidInstall == 0)
                    {
                        Scaler.HideEveryObject(Controls);
                        Scaler.ShowEveryObject(Controls, downloadControls);
                        LblTitle.Text = "Client needs to be updated!";
                        LblTitle.ForeColor = Color.Red;
                        BtnUpdate.Visible = true;
                    }
                    
                }   
            }
        }
        public void CheckIsValidInstall()
        {
            isValidInstall = -2;
            bool isValidInstallTemp = true;
            if (Constants.version != File.ReadAllText(destinationFolder + "version.ini"))
            {
                isValidInstallTemp = false;
            }
            if (isValidInstallTemp)
            {
                isValidInstall = 1;
            }
            else
            {
                isValidInstall = 0;
            }
            File.Delete(destinationFolder + "version.ini");
        }

        #region MouseMovement
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Update_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://google.com");
            Application.Exit();
        }
    }
}
