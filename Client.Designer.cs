
namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnMinecraftModded = new System.Windows.Forms.Button();
            this.LblTitle = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.progbarInstall = new System.Windows.Forms.ProgressBar();
            this.LblProgress = new System.Windows.Forms.Label();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.BtnFragileFrogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnMinecraftModded
            // 
            this.BtnMinecraftModded.BackColor = System.Drawing.Color.Transparent;
            this.BtnMinecraftModded.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMinecraftModded.Location = new System.Drawing.Point(15, 60);
            this.BtnMinecraftModded.Name = "BtnMinecraftModded";
            this.BtnMinecraftModded.Size = new System.Drawing.Size(240, 50);
            this.BtnMinecraftModded.TabIndex = 0;
            this.BtnMinecraftModded.Text = "Minecraft modded";
            this.BtnMinecraftModded.UseVisualStyleBackColor = false;
            this.BtnMinecraftModded.Click += new System.EventHandler(this.BtnMinecraftModded_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(267, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1012, 69);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "Select an installment";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.Transparent;
            this.btnInstall.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.Location = new System.Drawing.Point(1044, 592);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(137, 50);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // progbarInstall
            // 
            this.progbarInstall.Location = new System.Drawing.Point(358, 592);
            this.progbarInstall.Name = "progbarInstall";
            this.progbarInstall.Size = new System.Drawing.Size(674, 50);
            this.progbarInstall.TabIndex = 3;
            // 
            // LblProgress
            // 
            this.LblProgress.BackColor = System.Drawing.Color.Transparent;
            this.LblProgress.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProgress.ForeColor = System.Drawing.Color.White;
            this.LblProgress.Location = new System.Drawing.Point(359, 520);
            this.LblProgress.Name = "LblProgress";
            this.LblProgress.Size = new System.Drawing.Size(673, 69);
            this.LblProgress.TabIndex = 4;
            this.LblProgress.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tick
            // 
            this.tick.Enabled = true;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // BtnFragileFrogs
            // 
            this.BtnFragileFrogs.BackColor = System.Drawing.Color.Transparent;
            this.BtnFragileFrogs.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFragileFrogs.Location = new System.Drawing.Point(15, 120);
            this.BtnFragileFrogs.Name = "BtnFragileFrogs";
            this.BtnFragileFrogs.Size = new System.Drawing.Size(240, 50);
            this.BtnFragileFrogs.TabIndex = 5;
            this.BtnFragileFrogs.Text = "Fragile frogs";
            this.BtnFragileFrogs.UseVisualStyleBackColor = false;
            this.BtnFragileFrogs.Click += new System.EventHandler(this.BtnFragileFrogs_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.ClientClient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.BtnFragileFrogs);
            this.Controls.Add(this.LblProgress);
            this.Controls.Add(this.progbarInstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.BtnMinecraftModded);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Client";
            this.Text = "Client";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Client_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnMinecraftModded;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.ProgressBar progbarInstall;
        private System.Windows.Forms.Label LblProgress;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.Button BtnFragileFrogs;
    }
}