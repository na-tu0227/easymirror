namespace easymirror
{
    public partial class Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FullscreenButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.ScreenshotButton = new System.Windows.Forms.Button();
            this.FolderButton = new System.Windows.Forms.Button();
            this.CustomSettingButton = new System.Windows.Forms.Button();
            this.recPicture = new System.Windows.Forms.PictureBox();
            this.avMuteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolTip
            // 
            this.ToolTip.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // FullscreenButton
            // 
            this.FullscreenButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FullscreenButton.BackgroundImage = global::easymirror.Properties.Resources.全画面アイコン;
            this.FullscreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FullscreenButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FullscreenButton.Location = new System.Drawing.Point(185, 35);
            this.FullscreenButton.Name = "FullscreenButton";
            this.FullscreenButton.Size = new System.Drawing.Size(54, 53);
            this.FullscreenButton.TabIndex = 0;
            this.ToolTip.SetToolTip(this.FullscreenButton, "全画面表示");
            this.FullscreenButton.UseVisualStyleBackColor = false;
            this.FullscreenButton.Click += new System.EventHandler(this.FullscreenButtonClick);
            this.FullscreenButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControllerKeyDown);
            // 
            // RecordButton
            // 
            this.RecordButton.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RecordButton.Location = new System.Drawing.Point(19, 126);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(220, 50);
            this.RecordButton.TabIndex = 1;
            this.RecordButton.Text = "録画開始";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButtonClick);
            // 
            // ScreenshotButton
            // 
            this.ScreenshotButton.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ScreenshotButton.Location = new System.Drawing.Point(19, 204);
            this.ScreenshotButton.Name = "ScreenshotButton";
            this.ScreenshotButton.Size = new System.Drawing.Size(220, 50);
            this.ScreenshotButton.TabIndex = 2;
            this.ScreenshotButton.Text = "スクリーンショット";
            this.ScreenshotButton.UseVisualStyleBackColor = true;
            this.ScreenshotButton.Click += new System.EventHandler(this.ScreenshotButtonClick);
            // 
            // FolderButton
            // 
            this.FolderButton.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FolderButton.Location = new System.Drawing.Point(19, 430);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(220, 50);
            this.FolderButton.TabIndex = 3;
            this.FolderButton.Text = "フォルダー";
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButtonClick);
            // 
            // CustomSettingButton
            // 
            this.CustomSettingButton.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomSettingButton.Location = new System.Drawing.Point(19, 355);
            this.CustomSettingButton.Name = "CustomSettingButton";
            this.CustomSettingButton.Size = new System.Drawing.Size(220, 50);
            this.CustomSettingButton.TabIndex = 5;
            this.CustomSettingButton.Text = "カスタマイズ";
            this.CustomSettingButton.UseVisualStyleBackColor = true;
            this.CustomSettingButton.Click += new System.EventHandler(this.CustomSetting_Click);
            // 
            // recPicture
            // 
            this.recPicture.Enabled = false;
            this.recPicture.Image = global::easymirror.Properties.Resources.録画開始__カスタム_;
            this.recPicture.Location = new System.Drawing.Point(12, 35);
            this.recPicture.Name = "recPicture";
            this.recPicture.Size = new System.Drawing.Size(138, 53);
            this.recPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.recPicture.TabIndex = 6;
            this.recPicture.TabStop = false;
            this.recPicture.Visible = false;
            // 
            // avMuteButton
            // 
            this.avMuteButton.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.avMuteButton.Location = new System.Drawing.Point(19, 280);
            this.avMuteButton.Name = "avMuteButton";
            this.avMuteButton.Size = new System.Drawing.Size(220, 50);
            this.avMuteButton.TabIndex = 7;
            this.avMuteButton.Text = "AVミュート";
            this.avMuteButton.UseVisualStyleBackColor = true;
            this.avMuteButton.Click += new System.EventHandler(this.av_muteButton_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(262, 553);
            this.Controls.Add(this.avMuteButton);
            this.Controls.Add(this.recPicture);
            this.Controls.Add(this.CustomSettingButton);
            this.Controls.Add(this.FolderButton);
            this.Controls.Add(this.ScreenshotButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.FullscreenButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 600);
            this.MinimumSize = new System.Drawing.Size(280, 600);
            this.Name = "Controller";
            this.Text = "Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControllerFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.recPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FullscreenButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button ScreenshotButton;
        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.Button CustomSettingButton;
        private System.Windows.Forms.PictureBox recPicture;
        private System.Windows.Forms.Button avMuteButton;
    }
}