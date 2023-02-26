
namespace Client
{
    partial class Update
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
            this.ticks = new System.Windows.Forms.Timer(this.components);
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblDetails = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ticks
            // 
            this.ticks.Enabled = true;
            this.ticks.Tick += new System.EventHandler(this.ticks_Tick);
            // 
            // progressDownload
            // 
            this.progressDownload.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressDownload.ForeColor = System.Drawing.Color.Navy;
            this.progressDownload.Location = new System.Drawing.Point(15, 406);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(1250, 100);
            this.progressDownload.TabIndex = 0;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Arial Black", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(-1, 202);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1280, 100);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "Downloading information";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDetails
            // 
            this.LblDetails.BackColor = System.Drawing.Color.Transparent;
            this.LblDetails.Font = new System.Drawing.Font("Arial Black", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetails.ForeColor = System.Drawing.Color.White;
            this.LblDetails.Location = new System.Drawing.Point(0, 296);
            this.LblDetails.Name = "LblDetails";
            this.LblDetails.Size = new System.Drawing.Size(1280, 104);
            this.LblDetails.TabIndex = 2;
            this.LblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.Location = new System.Drawing.Point(358, 305);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(600, 100);
            this.BtnUpdate.TabIndex = 3;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Visible = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.UpdateScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.LblDetails);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.progressDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Update";
            this.Text = "Update";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Update_MouseDown);
            this.Resize += new System.EventHandler(this.Update_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ticks;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblDetails;
        private System.Windows.Forms.Button BtnUpdate;
    }
}