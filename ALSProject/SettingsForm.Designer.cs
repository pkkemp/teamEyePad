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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sldrDwellTime = new ALSProject.Slider("Dwell Time");
            this.btnResetCallouts = new ALSProject.ALSButton();
            this.btnAlarm = new ALSProject.ALSAlarm();
            this.btnBack = new ALSProject.ALSButton();
            this.sldrKeyboard = new ALSProject.Slider("Keyboard Dwell Time");
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(311, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dwell Time Speed";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(230, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(576, 63);
            this.label4.TabIndex = 11;
            this.label4.Text = "Keyboard Dwell Speed";
            // 
            // sldrDwellTime
            // 
            this.sldrDwellTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sldrDwellTime.Location = new System.Drawing.Point(177, 300);
            this.sldrDwellTime.Name = "sldrDwellTime";
            this.sldrDwellTime.Size = new System.Drawing.Size(158, 58);
            this.sldrDwellTime.TabIndex = 12;
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
            // sldrKeyboard
            // 
            this.sldrKeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sldrKeyboard.Location = new System.Drawing.Point(297, 485);
            this.sldrKeyboard.Name = "sldrKeyboard";
            this.sldrKeyboard.Size = new System.Drawing.Size(258, 58);
            this.sldrKeyboard.TabIndex = 13;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.sldrKeyboard);
            this.Controls.Add(this.sldrDwellTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnResetCallouts);
            this.Controls.Add(this.btnAlarm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ALSButton btnBack;
        private ALSAlarm btnAlarm;
        public ALSButton btnResetCallouts;
        private System.Windows.Forms.Label label4;
        private Slider sldrDwellTime;
        private Slider sldrKeyboard;
    }
}