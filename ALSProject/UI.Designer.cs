namespace ALSProject
{
    partial class UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.btnBrowser = new ALSProject.ALSButton();
            this.alsButton5 = new ALSProject.ALSButton();
            this.btnQuit = new ALSProject.ALSButton();
            this.setBut = new ALSProject.ALSButton();
            this.alsButton4 = new ALSProject.ALSButton();
            this.btnMin = new ALSProject.ALSButton();
            this.btnNotebook = new ALSProject.ALSButton();
            this.btnTTS = new ALSProject.ALSButton();
            this.btnAlarm = new ALSProject.ALSAlarm();
            this.SuspendLayout();
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBrowser.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnBrowser.dwellTimeInterval = 15;
            this.btnBrowser.FlatAppearance.BorderSize = 0;
            this.btnBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnBrowser.Location = new System.Drawing.Point(12, 518);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(312, 248);
            this.btnBrowser.TabIndex = 8;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowser.UseVisualStyleBackColor = false;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // alsButton5
            // 
            this.alsButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.alsButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.alsButton5.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsButton5.dwellTimeInterval = 15;
            this.alsButton5.FlatAppearance.BorderSize = 0;
            this.alsButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsButton5.Location = new System.Drawing.Point(356, 264);
            this.alsButton5.Name = "alsButton5";
            this.alsButton5.Size = new System.Drawing.Size(312, 248);
            this.alsButton5.TabIndex = 6;
            this.alsButton5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.alsButton5.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuit.BackgroundImage = global::ALSProject.Properties.Resources.power;
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuit.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnQuit.dwellTimeInterval = 15;
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnQuit.ForeColor = System.Drawing.Color.Blue;
            this.btnQuit.Location = new System.Drawing.Point(700, 518);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(312, 248);
            this.btnQuit.TabIndex = 10;
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.quitBut_Click);
            // 
            // setBut
            // 
            this.setBut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.setBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.setBut.BackgroundImage = global::ALSProject.Properties.Resources.gear_b;
            this.setBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setBut.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.setBut.dwellTimeInterval = 15;
            this.setBut.FlatAppearance.BorderSize = 0;
            this.setBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.setBut.ForeColor = System.Drawing.Color.Blue;
            this.setBut.Location = new System.Drawing.Point(356, 518);
            this.setBut.Name = "setBut";
            this.setBut.Size = new System.Drawing.Size(312, 248);
            this.setBut.TabIndex = 9;
            this.setBut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.setBut.UseVisualStyleBackColor = false;
            this.setBut.Click += new System.EventHandler(this.setBut_Click);
            // 
            // alsButton4
            // 
            this.alsButton4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alsButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton4.BackgroundImage = global::ALSProject.Properties.Resources.Speech;
            this.alsButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.alsButton4.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsButton4.dwellTimeInterval = 15;
            this.alsButton4.FlatAppearance.BorderSize = 0;
            this.alsButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsButton4.ForeColor = System.Drawing.Color.Blue;
            this.alsButton4.Location = new System.Drawing.Point(700, 264);
            this.alsButton4.Name = "alsButton4";
            this.alsButton4.Size = new System.Drawing.Size(312, 248);
            this.alsButton4.TabIndex = 7;
            this.alsButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.alsButton4.UseVisualStyleBackColor = false;
            this.alsButton4.Click += new System.EventHandler(this.alsButton4_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMin.BackgroundImage = global::ALSProject.Properties.Resources.Notes;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMin.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnMin.dwellTimeInterval = 15;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnMin.Location = new System.Drawing.Point(12, 264);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(312, 248);
            this.btnMin.TabIndex = 5;
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnNotebook
            // 
            this.btnNotebook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotebook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNotebook.BackgroundImage = global::ALSProject.Properties.Resources.Lock;
            this.btnNotebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNotebook.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnNotebook.dwellTimeInterval = 15;
            this.btnNotebook.FlatAppearance.BorderSize = 0;
            this.btnNotebook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnNotebook.Location = new System.Drawing.Point(700, 10);
            this.btnNotebook.Name = "btnNotebook";
            this.btnNotebook.Size = new System.Drawing.Size(312, 248);
            this.btnNotebook.TabIndex = 4;
            this.btnNotebook.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotebook.UseVisualStyleBackColor = false;
            this.btnNotebook.Click += new System.EventHandler(this.btnNotebook_Click);
            // 
            // btnTTS
            // 
            this.btnTTS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTTS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTTS.BackgroundImage = global::ALSProject.Properties.Resources.chatbubbles;
            this.btnTTS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTTS.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnTTS.dwellTimeInterval = 15;
            this.btnTTS.FlatAppearance.BorderSize = 0;
            this.btnTTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnTTS.ForeColor = System.Drawing.Color.Blue;
            this.btnTTS.Location = new System.Drawing.Point(356, 10);
            this.btnTTS.Name = "btnTTS";
            this.btnTTS.Size = new System.Drawing.Size(312, 248);
            this.btnTTS.TabIndex = 3;
            this.btnTTS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTTS.UseVisualStyleBackColor = false;
            this.btnTTS.Click += new System.EventHandler(this.ttsBut_Click);
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAlarm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAlarm.BackgroundImage")));
            this.btnAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAlarm.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnAlarm.dwellTimeInterval = 15;
            this.btnAlarm.FlatAppearance.BorderSize = 0;
            this.btnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnAlarm.ForeColor = System.Drawing.Color.Blue;
            this.btnAlarm.Location = new System.Drawing.Point(12, 10);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(312, 248);
            this.btnAlarm.TabIndex = 2;
            this.btnAlarm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.alarmBut_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.setBut);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.alsButton4);
            this.Controls.Add(this.alsButton5);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnNotebook);
            this.Controls.Add(this.btnTTS);
            this.Controls.Add(this.btnAlarm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UI_FormClosed);
            this.Load += new System.EventHandler(this.User_Interface_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ALSAlarm btnAlarm;
        private ALSButton btnTTS;
        private ALSButton btnNotebook;
        private ALSButton alsButton4;
        private ALSButton alsButton5;
        private ALSButton btnMin;
        private ALSButton setBut;
        private ALSButton btnBrowser;
        private ALSButton btnQuit;
    }
}