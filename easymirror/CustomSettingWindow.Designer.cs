namespace easymirror
{
    partial class CustomSettingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSettingWindow));
            this.maxFps = new System.Windows.Forms.TextBox();
            this.maxBitrate = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WirelessButton = new System.Windows.Forms.CheckBox();
            this.CustomRecordButton = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.movieCodec = new System.Windows.Forms.ComboBox();
            this.audioCodec = new System.Windows.Forms.ComboBox();
            this.RecordGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeParam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.videoBuffer = new System.Windows.Forms.TextBox();
            this.scrcpyConfig = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.maxWindowButton = new System.Windows.Forms.RadioButton();
            this.noMirrorButton = new System.Windows.Forms.RadioButton();
            this.fullScreenButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.defaultSizeButton = new System.Windows.Forms.RadioButton();
            this.sizeGroup = new System.Windows.Forms.GroupBox();
            this.WirelessKillButton = new System.Windows.Forms.Button();
            this.RecordGroup.SuspendLayout();
            this.scrcpyConfig.SuspendLayout();
            this.sizeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // maxFps
            // 
            this.maxFps.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.maxFps.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.maxFps.Location = new System.Drawing.Point(111, 68);
            this.maxFps.Name = "maxFps";
            this.maxFps.ShortcutsEnabled = false;
            this.maxFps.Size = new System.Drawing.Size(56, 24);
            this.maxFps.TabIndex = 2;
            this.maxFps.Text = "0";
            this.maxFps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_KeyDown);
            this.maxFps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxNumOnly_KeyPress);
            this.maxFps.Leave += new System.EventHandler(this.maxFps_Leave);
            // 
            // maxBitrate
            // 
            this.maxBitrate.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.maxBitrate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.maxBitrate.Location = new System.Drawing.Point(111, 97);
            this.maxBitrate.Name = "maxBitrate";
            this.maxBitrate.ShortcutsEnabled = false;
            this.maxBitrate.Size = new System.Drawing.Size(56, 24);
            this.maxBitrate.TabIndex = 5;
            this.maxBitrate.Text = "0";
            this.maxBitrate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_KeyDown);
            this.maxBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxNumOnly_KeyPress);
            this.maxBitrate.Leave += new System.EventHandler(this.maxBitrate_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "h264",
            "h265"});
            this.comboBox1.Location = new System.Drawing.Point(6, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "オーディオなし",
            "Opus",
            "AAC"});
            this.comboBox2.Location = new System.Drawing.Point(162, 45);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 3;
            // 
            // WirelessButton
            // 
            this.WirelessButton.AutoSize = true;
            this.WirelessButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WirelessButton.Location = new System.Drawing.Point(12, 21);
            this.WirelessButton.Name = "WirelessButton";
            this.WirelessButton.Size = new System.Drawing.Size(139, 21);
            this.WirelessButton.TabIndex = 14;
            this.WirelessButton.Text = "無線で起動する";
            this.WirelessButton.UseVisualStyleBackColor = true;
            // 
            // CustomRecordButton
            // 
            this.CustomRecordButton.AutoSize = true;
            this.CustomRecordButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomRecordButton.Location = new System.Drawing.Point(378, 42);
            this.CustomRecordButton.Name = "CustomRecordButton";
            this.CustomRecordButton.Size = new System.Drawing.Size(138, 21);
            this.CustomRecordButton.TabIndex = 17;
            this.CustomRecordButton.Text = "録画を開始する";
            this.CustomRecordButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "映像コーデック";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "音声コーデック";
            // 
            // movieCodec
            // 
            this.movieCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.movieCodec.FormattingEnabled = true;
            this.movieCodec.Items.AddRange(new object[] {
            "h264(デフォルト）",
            "h265"});
            this.movieCodec.Location = new System.Drawing.Point(6, 40);
            this.movieCodec.Name = "movieCodec";
            this.movieCodec.Size = new System.Drawing.Size(121, 25);
            this.movieCodec.TabIndex = 2;
            // 
            // audioCodec
            // 
            this.audioCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioCodec.FormattingEnabled = true;
            this.audioCodec.Items.AddRange(new object[] {
            "AAC(デフォルト）",
            "Opus",
            "音声無し"});
            this.audioCodec.Location = new System.Drawing.Point(141, 42);
            this.audioCodec.Name = "audioCodec";
            this.audioCodec.Size = new System.Drawing.Size(114, 25);
            this.audioCodec.TabIndex = 3;
            // 
            // RecordGroup
            // 
            this.RecordGroup.Controls.Add(this.audioCodec);
            this.RecordGroup.Controls.Add(this.movieCodec);
            this.RecordGroup.Controls.Add(this.label5);
            this.RecordGroup.Controls.Add(this.label4);
            this.RecordGroup.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RecordGroup.Location = new System.Drawing.Point(378, 75);
            this.RecordGroup.Name = "RecordGroup";
            this.RecordGroup.Size = new System.Drawing.Size(274, 87);
            this.RecordGroup.TabIndex = 16;
            this.RecordGroup.TabStop = false;
            this.RecordGroup.Text = "コーデック";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(9, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "最大FPS：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(8, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "ビットレート：";
            // 
            // sizeParam
            // 
            this.sizeParam.Enabled = false;
            this.sizeParam.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sizeParam.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.sizeParam.Location = new System.Drawing.Point(186, 92);
            this.sizeParam.Name = "sizeParam";
            this.sizeParam.ShortcutsEnabled = false;
            this.sizeParam.Size = new System.Drawing.Size(56, 24);
            this.sizeParam.TabIndex = 20;
            this.sizeParam.Text = "0";
            this.sizeParam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_KeyDown);
            this.sizeParam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxNumOnly_KeyPress);
            this.sizeParam.Leave += new System.EventHandler(this.sizeParam_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(-1, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "ビデオバッファ：";
            // 
            // videoBuffer
            // 
            this.videoBuffer.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.videoBuffer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.videoBuffer.Location = new System.Drawing.Point(111, 132);
            this.videoBuffer.Name = "videoBuffer";
            this.videoBuffer.ShortcutsEnabled = false;
            this.videoBuffer.Size = new System.Drawing.Size(56, 24);
            this.videoBuffer.TabIndex = 23;
            this.videoBuffer.Text = "0";
            this.videoBuffer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_KeyDown);
            this.videoBuffer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxNumOnly_KeyPress);
            this.videoBuffer.Leave += new System.EventHandler(this.videoBuffer_Leave);
            // 
            // scrcpyConfig
            // 
            this.scrcpyConfig.Controls.Add(this.label12);
            this.scrcpyConfig.Controls.Add(this.label11);
            this.scrcpyConfig.Controls.Add(this.label10);
            this.scrcpyConfig.Controls.Add(this.label9);
            this.scrcpyConfig.Controls.Add(this.label7);
            this.scrcpyConfig.Controls.Add(this.videoBuffer);
            this.scrcpyConfig.Controls.Add(this.label6);
            this.scrcpyConfig.Controls.Add(this.label3);
            this.scrcpyConfig.Controls.Add(this.maxBitrate);
            this.scrcpyConfig.Controls.Add(this.maxFps);
            this.scrcpyConfig.Controls.Add(this.WirelessButton);
            this.scrcpyConfig.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.scrcpyConfig.Location = new System.Drawing.Point(28, 29);
            this.scrcpyConfig.Name = "scrcpyConfig";
            this.scrcpyConfig.Size = new System.Drawing.Size(308, 284);
            this.scrcpyConfig.TabIndex = 25;
            this.scrcpyConfig.TabStop = false;
            this.scrcpyConfig.Text = "Scrcpy設定";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(2, 176);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(264, 90);
            this.label12.TabIndex = 29;
            this.label12.Text = "※最大fpsやビットレートを上げすぎると\r\n　負荷が大きくなるためご注意ください。\r\n※一部併用できない設定があるため\r\n　ご注意ください。\r\n※何も記入していな" +
    "い場合は既定の数値を\r\n　返すようにしています。";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(174, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "ms　(0～10000)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(174, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Mdps　(0～40)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(173, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "(0～120)";
            // 
            // maxWindowButton
            // 
            this.maxWindowButton.AutoSize = true;
            this.maxWindowButton.Location = new System.Drawing.Point(21, 95);
            this.maxWindowButton.Name = "maxWindowButton";
            this.maxWindowButton.Size = new System.Drawing.Size(143, 19);
            this.maxWindowButton.TabIndex = 32;
            this.maxWindowButton.Text = "任意の最大サイズ：";
            this.maxWindowButton.UseVisualStyleBackColor = true;
            this.maxWindowButton.CheckedChanged += new System.EventHandler(this.MaxWindowButton_CheckedChanged);
            // 
            // noMirrorButton
            // 
            this.noMirrorButton.AutoSize = true;
            this.noMirrorButton.Location = new System.Drawing.Point(21, 42);
            this.noMirrorButton.Name = "noMirrorButton";
            this.noMirrorButton.Size = new System.Drawing.Size(135, 19);
            this.noMirrorButton.TabIndex = 31;
            this.noMirrorButton.Text = "端末を表示しない";
            this.noMirrorButton.UseVisualStyleBackColor = true;
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.AutoSize = true;
            this.fullScreenButton.Location = new System.Drawing.Point(21, 67);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(139, 19);
            this.fullScreenButton.TabIndex = 30;
            this.fullScreenButton.Text = "全画面で表示する";
            this.fullScreenButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(549, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "(0～10000)";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.startButton.Location = new System.Drawing.Point(344, 344);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(172, 60);
            this.startButton.TabIndex = 26;
            this.startButton.Text = "MirorrAppStart";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.backButton.Location = new System.Drawing.Point(531, 343);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(148, 60);
            this.backButton.TabIndex = 27;
            this.backButton.Text = "戻る";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // defaultSizeButton
            // 
            this.defaultSizeButton.AutoSize = true;
            this.defaultSizeButton.Checked = true;
            this.defaultSizeButton.Location = new System.Drawing.Point(22, 18);
            this.defaultSizeButton.Name = "defaultSizeButton";
            this.defaultSizeButton.Size = new System.Drawing.Size(118, 19);
            this.defaultSizeButton.TabIndex = 33;
            this.defaultSizeButton.TabStop = true;
            this.defaultSizeButton.Text = "デフォルトサイズ";
            this.defaultSizeButton.UseVisualStyleBackColor = true;
            // 
            // sizeGroup
            // 
            this.sizeGroup.Controls.Add(this.defaultSizeButton);
            this.sizeGroup.Controls.Add(this.maxWindowButton);
            this.sizeGroup.Controls.Add(this.noMirrorButton);
            this.sizeGroup.Controls.Add(this.fullScreenButton);
            this.sizeGroup.Controls.Add(this.sizeParam);
            this.sizeGroup.Location = new System.Drawing.Point(378, 186);
            this.sizeGroup.Name = "sizeGroup";
            this.sizeGroup.Size = new System.Drawing.Size(293, 127);
            this.sizeGroup.TabIndex = 34;
            this.sizeGroup.TabStop = false;
            this.sizeGroup.Text = "画面サイズ";
            // 
            // WirelessKillButton
            // 
            this.WirelessKillButton.Enabled = false;
            this.WirelessKillButton.Location = new System.Drawing.Point(28, 345);
            this.WirelessKillButton.Name = "WirelessKillButton";
            this.WirelessKillButton.Size = new System.Drawing.Size(140, 58);
            this.WirelessKillButton.TabIndex = 35;
            this.WirelessKillButton.Text = "無線接続の切断";
            this.WirelessKillButton.UseVisualStyleBackColor = true;
            this.WirelessKillButton.Click += new System.EventHandler(this.WirelessKill_Click);
            // 
            // CustomSettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 426);
            this.Controls.Add(this.WirelessKillButton);
            this.Controls.Add(this.sizeGroup);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.scrcpyConfig);
            this.Controls.Add(this.CustomRecordButton);
            this.Controls.Add(this.RecordGroup);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomSettingWindow";
            this.Text = "CustomSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomSettingWindow_FormClosing);
            this.Load += new System.EventHandler(this.CustomSettingWindow_Load);
            this.RecordGroup.ResumeLayout(false);
            this.RecordGroup.PerformLayout();
            this.scrcpyConfig.ResumeLayout(false);
            this.scrcpyConfig.PerformLayout();
            this.sizeGroup.ResumeLayout(false);
            this.sizeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox maxBitrate;
        private System.Windows.Forms.TextBox maxFps;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox WirelessButton;
        private System.Windows.Forms.CheckBox CustomRecordButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox movieCodec;
        private System.Windows.Forms.ComboBox audioCodec;
        private System.Windows.Forms.GroupBox RecordGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sizeParam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox videoBuffer;
        private System.Windows.Forms.GroupBox scrcpyConfig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton maxWindowButton;
        private System.Windows.Forms.RadioButton noMirrorButton;
        private System.Windows.Forms.RadioButton fullScreenButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.RadioButton defaultSizeButton;
        private System.Windows.Forms.GroupBox sizeGroup;
        private System.Windows.Forms.Button WirelessKillButton;
    }
}