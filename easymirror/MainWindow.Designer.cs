namespace easymirror
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Start_button = new System.Windows.Forms.Button();
            this.FolderButton = new System.Windows.Forms.Button();
            this.CustomSettingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Start_button.Location = new System.Drawing.Point(27, 162);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(358, 79);
            this.Start_button.TabIndex = 0;
            this.Start_button.Text = "かんたんスタート";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // FolderButton
            // 
            this.FolderButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FolderButton.Location = new System.Drawing.Point(208, 41);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(177, 67);
            this.FolderButton.TabIndex = 2;
            this.FolderButton.Text = "フォルダーを開く";
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButtonClick);
            // 
            // CustomSettingButton
            // 
            this.CustomSettingButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomSettingButton.Location = new System.Drawing.Point(27, 41);
            this.CustomSettingButton.Name = "CustomSettingButton";
            this.CustomSettingButton.Size = new System.Drawing.Size(179, 67);
            this.CustomSettingButton.TabIndex = 4;
            this.CustomSettingButton.Text = "カスタマイズ";
            this.CustomSettingButton.UseVisualStyleBackColor = true;
            this.CustomSettingButton.Click += new System.EventHandler(this.CustomSettingButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 323);
            this.Controls.Add(this.CustomSettingButton);
            this.Controls.Add(this.FolderButton);
            this.Controls.Add(this.Start_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 370);
            this.MinimumSize = new System.Drawing.Size(450, 370);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowFormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.Button CustomSettingButton;
    }
}