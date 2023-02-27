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
using System.IO.Compression;
using System.Diagnostics;

namespace Client
{
    public partial class Client : Form
    {
        Scaler scaler;
        DownloadFile gameDownload;

        public Client()
        {
            InitializeComponent();

            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);

            gameDownload = null;
            scaler = new Scaler(Width, Height, Controls);
            Directory.CreateDirectory("C:/temp");
            Directory.CreateDirectory("C:/temp/Downloads");
        }

        #region MouseMovement
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Client_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void BtnMinecraftModded_Click(object sender, EventArgs e)
        {
            LblTitle.Text = "Minecraft modded";
        }
        private void BtnFragileFrogs_Click(object sender, EventArgs e)
        {
            LblTitle.Text = "Fragile frogs";
        }
        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:/temp/Downloads"))
            {
                try
                {
                    Directory.Delete("C:/temp/Downloads", true);
                }
                catch (System.IO.IOException args)
                {
                    MessageBox.Show($"Trying to clear cache data: {args.Message}");
                    return;
                }
            }

            DialogResult dialogResult;
            switch (LblTitle.Text.ToLower())
            {
                case "minecraft modded":
                    dialogResult = MessageBox.Show("Do you have minecraft 1.18.1 installed? YOUR MOD FOLDER WILL BE DELETED!", "Minecraft modded install", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        btnInstall.Enabled = false;
                        gameDownload = new DownloadFile("https://www.dropbox.com/s/n89zmy9be0737m3/Minecraft%20modded.zip?dl=1", "C:/temp/Downloads/", "minecraft.zip");
                        gameDownload.Name = LblTitle.Text;
                    }
                    break;
                case "fragile frogs":
                    if (Directory.Exists(Constants.fragileFrogsLocation))
                    {
                        dialogResult = MessageBox.Show("You already have fragile frogs. This will overwrite the current version.", "Fragile frogs install", MessageBoxButtons.YesNo);
                        if (dialogResult != DialogResult.Yes)
                        {
                            return;
                        }
                        Directory.Delete(Environment.ExpandEnvironmentVariables(Constants.fragileFrogsLocation), true);
                    }
                    btnInstall.Enabled = false;
                    gameDownload = new DownloadFile("https://www.dropbox.com/s/3jqijdibu842cbk/MotherFroggers.zip?dl=1", "C:/temp/Downloads/", "fragilefrogs.zip");
                    gameDownload.StoreLocation = Constants.fragileFrogsLocation;
                    gameDownload.Name = LblTitle.Text;
                    Directory.CreateDirectory(gameDownload.StoreLocation);
                    break;
            }
        }

        private void tick_Tick(object sender, EventArgs e)
        {
            if (gameDownload != null)
            {

                if (gameDownload.Completed)
                {
                    switch (gameDownload.Name.ToLower())
                    {
                        case "minecraft modded":
                            if (File.Exists(gameDownload.FullPath))
                            {
                                ZipFile.ExtractToDirectory(gameDownload.FullPath, gameDownload.FolderPath);
                                ReEnableDownload();
                            }
                            if (File.Exists(gameDownload.FolderPath + "Run/Forge.jar"))
                            {
                                Process.Start(gameDownload.FolderPath + "Run/Forge.jar");
                                Process.Start($@"{gameDownload.FolderPath}Run/");
                            }
                            if (Directory.Exists($"{gameDownload.FolderPath}Mods/"))
                            {
                                if (Directory.Exists(Environment.ExpandEnvironmentVariables("%AppData%\\.minecraft/mods")))
                                {
                                    Directory.Delete(Environment.ExpandEnvironmentVariables("%AppData%\\.minecraft/mods"), true);
                                }
                                DownloadFile.CopyFolder($"{gameDownload.FolderPath}Mods/", Environment.ExpandEnvironmentVariables("%AppData%\\.minecraft/mods"));
                            }
                            break;
                        case "fragile frogs":
                            if (File.Exists(gameDownload.FullPath))
                            {
                                ZipFile.ExtractToDirectory(gameDownload.FullPath, gameDownload.StoreLocation);
                                ReEnableDownload();
                                Process.Start($@"{gameDownload.StoreLocation}/");
                            }
                            break;
                    }
                }
                else
                {
                    progbarInstall.Maximum = (int)(gameDownload.TotalMegaBytes * 1000);
                    progbarInstall.Value = (int)(gameDownload.ReceivedMegaBytes * 1000);
                    LblSpeed.Text = $"{Math.Round(gameDownload.ReceivedMegaBytes, 2)}MB/{Math.Round(gameDownload.TotalMegaBytes, 2)}MB";
                }
            }
        }
        private void ReEnableDownload()
        {
            gameDownload.Completed = false;
            btnInstall.Enabled = true;
            LblSpeed.Text = string.Empty;    
        }
    }
}
