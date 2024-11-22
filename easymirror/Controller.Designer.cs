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
            this.SaveRewindRecording = new System.Windows.Forms.Button();
            this.CustomSettingButton = new System.Windows.Forms.Button();
            this.recPicture = new System.Windows.Forms.PictureBox();
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
            this.FullscreenButton.Location = new System.Drawing.Point(215, 44);
            this.FullscreenButton.Name = "FullscreenButton";
            this.FullscreenButton.Size = new System.Drawing.Size(35, 35);
            this.FullscreenButton.TabIndex = 0;
            this.ToolTip.SetToolTip(this.FullscreenButton, "全画面表示");
            this.FullscreenButton.UseVisualStyleBackColor = false;
            this.FullscreenButton.Click += new System.EventHandler(this.FullscreenButtonClick);
            this.FullscreenButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControllerKeyDown);
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(136, 94);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(114, 43);
            this.RecordButton.TabIndex = 1;
            this.RecordButton.Text = "録画開始";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButtonClick);
            // 
            // ScreenshotButton
            // 
            this.ScreenshotButton.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ScreenshotButton.Location = new System.Drawing.Point(136, 157);
            this.ScreenshotButton.Name = "ScreenshotButton";
            this.ScreenshotButton.Size = new System.Drawing.Size(114, 40);
            this.ScreenshotButton.TabIndex = 2;
            this.ScreenshotButton.Text = "スクリーンショット";
            this.ScreenshotButton.UseVisualStyleBackColor = true;
            this.ScreenshotButton.Click += new System.EventHandler(this.ScreenshotButtonClick);
            // 
            // FolderButton
            // 
            this.FolderButton.Location = new System.Drawing.Point(136, 230);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(114, 40);
            this.FolderButton.TabIndex = 3;
            this.FolderButton.Text = "フォルダー";
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButtonClick);
            // 
            // SaveRewindRecording
            // 
            this.SaveRewindRecording.Location = new System.Drawing.Point(136, 301);
            this.SaveRewindRecording.Name = "SaveRewindRecording";
            this.SaveRewindRecording.Size = new System.Drawing.Size(118, 38);
            this.SaveRewindRecording.TabIndex = 4;
            this.SaveRewindRecording.Text = "巻き戻し録画";
            this.SaveRewindRecording.UseVisualStyleBackColor = true;
            this.SaveRewindRecording.Visible = false;
            this.SaveRewindRecording.Click += new System.EventHandler(this.SaveRewindRecording_Click);
            // 
            // CustomSettingButton
            // 
            this.CustomSettingButton.Location = new System.Drawing.Point(136, 372);
            this.CustomSettingButton.Name = "CustomSettingButton";
            this.CustomSettingButton.Size = new System.Drawing.Size(118, 38);
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
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(262, 554);
            this.Controls.Add(this.recPicture);
            this.Controls.Add(this.CustomSettingButton);
            this.Controls.Add(this.SaveRewindRecording);
            this.Controls.Add(this.FolderButton);
            this.Controls.Add(this.ScreenshotButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.FullscreenButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button SaveRewindRecording;
        private System.Windows.Forms.Button CustomSettingButton;
        private System.Windows.Forms.PictureBox recPicture;
    }
}