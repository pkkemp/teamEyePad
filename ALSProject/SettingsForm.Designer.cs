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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnResetCallouts = new ALSProject.ALSButton();
            this.btnAlarm = new ALSProject.ALSAlarm();
            this.btnBack = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // btnResetCallouts
            // 
            this.btnResetCallouts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnResetCallouts.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnResetCallouts.dwellTimeInterval = 15;
            this.btnResetCallouts.FlatAppearance.BorderSize = 0;
            this.btnResetCallouts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCallouts.Font = new System.Drawing.Font("Microsoft Sans Serif", 34.12514F);
            this.btnResetCallouts.Location = new System.Drawing.Point(12, 619);
            this.btnResetCallouts.Name = "btnResetCallouts";
            this.btnResetCallouts.Size = new System.Drawing.Size(203, 150);
            this.btnResetCallouts.TabIndex = 7;
            this.btnResetCallouts.Text = "Reset\r\nCallouts";
            this.btnResetCallouts.UseVisualStyleBackColor = false;
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAlarm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAlarm.BackgroundImage")));
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
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 43.64351F);
            this.btnBack.Location = new System.Drawing.Point(811, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(201, 157);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Main\r\nMenu";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private ALSButton btnBack;
        private ALSAlarm btnAlarm;
        public ALSButton btnResetCallouts;
    }
}