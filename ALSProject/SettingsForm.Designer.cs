namespace ALSProject
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAlarm = new ALSProject.ALSButton();
            this.btnBack = new ALSProject.ALSButton();
            this.slider1 = new ALSProject.Slider();
            this.alsButton2 = new ALSProject.ALSButton();
            this.alsButton1 = new ALSProject.ALSButton();
            this.btnResetCallouts = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(311, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dwell Time Speed";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(396, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 63);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seconds: 1";
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAlarm.BackgroundImage = global::ALSProject.Properties.Resources.speaker_icon;
            this.btnAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlarm.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnAlarm.dwellTimeInterval = 15;
            this.btnAlarm.FlatAppearance.BorderSize = 0;
            this.btnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnAlarm.Location = new System.Drawing.Point(12, 12);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(201, 181);
            this.btnAlarm.TabIndex = 6;
            this.btnAlarm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlarm.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBack.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnBack.dwellTimeInterval = 15;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnBack.Location = new System.Drawing.Point(811, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(201, 157);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Main\r\nMenu";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // slider1
            // 
            this.slider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slider1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.slider1.BackColor = System.Drawing.Color.Gainsboro;
            this.slider1.Location = new System.Drawing.Point(221, 230);
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(598, 34);
            this.slider1.TabIndex = 2;
            // 
            // alsButton2
            // 
            this.alsButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton2.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsButton2.dwellTimeInterval = 4;
            this.alsButton2.FlatAppearance.BorderSize = 0;
            this.alsButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsButton2.Location = new System.Drawing.Point(825, 199);
            this.alsButton2.Name = "alsButton2";
            this.alsButton2.Size = new System.Drawing.Size(189, 130);
            this.alsButton2.TabIndex = 1;
            this.alsButton2.Text = ">";
            this.alsButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.alsButton2.UseVisualStyleBackColor = false;
            this.alsButton2.Click += new System.EventHandler(this.alsButton2_Click);
            // 
            // alsButton1
            // 
            this.alsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton1.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsButton1.dwellTimeInterval = 4;
            this.alsButton1.FlatAppearance.BorderSize = 0;
            this.alsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsButton1.Location = new System.Drawing.Point(12, 199);
            this.alsButton1.Name = "alsButton1";
            this.alsButton1.Size = new System.Drawing.Size(203, 130);
            this.alsButton1.TabIndex = 0;
            this.alsButton1.Text = "<";
            this.alsButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.alsButton1.UseVisualStyleBackColor = false;
            this.alsButton1.Click += new System.EventHandler(this.alsButton1_Click);
            // 
            // btnResetCallouts
            // 
            this.btnResetCallouts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnResetCallouts.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnResetCallouts.dwellTimeInterval = 15;
            this.btnResetCallouts.FlatAppearance.BorderSize = 0;
            this.btnResetCallouts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCallouts.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnResetCallouts.Location = new System.Drawing.Point(12, 376);
            this.btnResetCallouts.Name = "btnResetCallouts";
            this.btnResetCallouts.Size = new System.Drawing.Size(203, 150);
            this.btnResetCallouts.TabIndex = 7;
            this.btnResetCallouts.Text = "Reset\\nCallouts";
            this.btnResetCallouts.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnResetCallouts);
            this.Controls.Add(this.btnAlarm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slider1);
            this.Controls.Add(this.alsButton2);
            this.Controls.Add(this.alsButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ALSButton alsButton1;
        private ALSButton alsButton2;
        private Slider slider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ALSButton btnBack;
        private ALSButton btnAlarm;
        public ALSButton btnResetCallouts;
    }
}