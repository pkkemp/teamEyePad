namespace ALSProject
{
    partial class TextToSpeech
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextToSpeech));
            this.btnCallouts = new ALSProject.ALSButton();
            this.btnSpeak = new ALSProject.ALSButton();
            this.alsAlarm1 = new ALSProject.ALSAlarm();
            this.btnMenu = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // btnCallouts
            // 
            this.btnCallouts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCallouts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCallouts.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnCallouts.dwellTimeInterval = 15;
            this.btnCallouts.FlatAppearance.BorderSize = 0;
            this.btnCallouts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallouts.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.05569F);
            this.btnCallouts.Location = new System.Drawing.Point(722, 12);
            this.btnCallouts.Name = "btnCallouts";
            this.btnCallouts.Size = new System.Drawing.Size(143, 140);
            this.btnCallouts.TabIndex = 8;
            this.btnCallouts.Text = "Callouts";
            this.btnCallouts.UseVisualStyleBackColor = false;
            this.btnCallouts.Click += new System.EventHandler(this.btnCallouts_Click);
            // 
            // btnSpeak
            // 
            this.btnSpeak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSpeak.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnSpeak.dwellTimeInterval = 15;
            this.btnSpeak.FlatAppearance.BorderSize = 0;
            this.btnSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.27743F);
            this.btnSpeak.Location = new System.Drawing.Point(143, 12);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(132, 140);
            this.btnSpeak.TabIndex = 6;
            this.btnSpeak.Text = "Speak";
            this.btnSpeak.UseVisualStyleBackColor = false;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // alsAlarm1
            // 
            this.alsAlarm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsAlarm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alsAlarm1.BackgroundImage")));
            this.alsAlarm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.alsAlarm1.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsAlarm1.dwellTimeInterval = 15;
            this.alsAlarm1.FlatAppearance.BorderSize = 0;
            this.alsAlarm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsAlarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsAlarm1.Location = new System.Drawing.Point(13, 12);
            this.alsAlarm1.Name = "alsAlarm1";
            this.alsAlarm1.Size = new System.Drawing.Size(124, 140);
            this.alsAlarm1.TabIndex = 5;
            this.alsAlarm1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.alsAlarm1.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnMenu.dwellTimeInterval = 15;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.70997F);
            this.btnMenu.Location = new System.Drawing.Point(871, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(141, 140);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Main\r\nMenu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // TextToSpeech
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnCallouts);
            this.Controls.Add(this.btnSpeak);
            this.Controls.Add(this.alsAlarm1);
            this.Controls.Add(this.btnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextToSpeech";
            this.Text = "Text to Speech";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.TextToSpeech_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        protected ALSButton btnMenu;
        protected ALSAlarm alsAlarm1;
        protected ALSButton btnSpeak;
        protected ALSButton btnCallouts;
    }
}