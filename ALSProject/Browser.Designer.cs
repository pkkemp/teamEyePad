namespace ALSProject
{
    partial class Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.btnScrollDown = new ALSProject.ALSButton();
            this.btnScrollUp = new ALSProject.ALSButton();
            this.alsButton1 = new ALSProject.ALSButton();
            this.keyboard = new ALSProject.KeyboardControl2();
            this.btnMenu = new ALSProject.ALSButton();
            this.btnBack = new ALSProject.ALSButton();
            this.alsAlarm1 = new ALSProject.ALSAlarm();
            this.txtUrl = new ALSTextbox();
            this.SuspendLayout();
            // 
            // btnScrollDown
            // 
            this.btnScrollDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnScrollDown.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnScrollDown.dwellTimeInterval = 100;
            this.btnScrollDown.FlatAppearance.BorderSize = 0;
            this.btnScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnScrollDown.Location = new System.Drawing.Point(12, 496);
            this.btnScrollDown.Name = "btnScrollDown";
            this.btnScrollDown.Size = new System.Drawing.Size(112, 94);
            this.btnScrollDown.TabIndex = 8;
            this.btnScrollDown.Text = "\\/";
            this.btnScrollDown.UseVisualStyleBackColor = false;
            this.btnScrollDown.Click += new System.EventHandler(this.btnScrollDown_Click);
            // 
            // btnScrollUp
            // 
            this.btnScrollUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnScrollUp.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnScrollUp.dwellTimeInterval = 100;
            this.btnScrollUp.FlatAppearance.BorderSize = 0;
            this.btnScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnScrollUp.Location = new System.Drawing.Point(12, 396);
            this.btnScrollUp.Name = "btnScrollUp";
            this.btnScrollUp.Size = new System.Drawing.Size(112, 94);
            this.btnScrollUp.TabIndex = 7;
            this.btnScrollUp.Text = "/\\";
            this.btnScrollUp.UseVisualStyleBackColor = false;
            this.btnScrollUp.Click += new System.EventHandler(this.btnScrollUp_Click);
            // 
            // alsButton1
            // 
            this.alsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton1.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsButton1.dwellTimeInterval = 100;
            this.alsButton1.FlatAppearance.BorderSize = 0;
            this.alsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsButton1.Location = new System.Drawing.Point(12, 301);
            this.alsButton1.Name = "alsButton1";
            this.alsButton1.Size = new System.Drawing.Size(112, 89);
            this.alsButton1.TabIndex = 6;
            this.alsButton1.Text = "Go";
            this.alsButton1.UseVisualStyleBackColor = false;
            this.alsButton1.Click += new System.EventHandler(this.alsButton1_Click);
            // 
            // keyboard
            // 
            this.keyboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboard.BackColor = System.Drawing.Color.Black;
            this.keyboard.Location = new System.Drawing.Point(129, 348);
            this.keyboard.Name = "keyboard";
            this.keyboard.Size = new System.Drawing.Size(867, 370);
            this.keyboard.TabIndex = 4;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnMenu.dwellTimeInterval = 100;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnMenu.Location = new System.Drawing.Point(12, 128);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(111, 108);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Main Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBack.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnBack.dwellTimeInterval = 100;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnBack.Location = new System.Drawing.Point(12, 596);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 94);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // alsAlarm1
            // 
            this.alsAlarm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsAlarm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alsAlarm1.BackgroundImage")));
            this.alsAlarm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.alsAlarm1.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.alsAlarm1.dwellTimeInterval = 100;
            this.alsAlarm1.FlatAppearance.BorderSize = 0;
            this.alsAlarm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsAlarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.alsAlarm1.Location = new System.Drawing.Point(12, 12);
            this.alsAlarm1.Name = "alsAlarm1";
            this.alsAlarm1.Size = new System.Drawing.Size(112, 110);
            this.alsAlarm1.TabIndex = 0;
            this.alsAlarm1.UseVisualStyleBackColor = false;
            this.alsAlarm1.Click += new System.EventHandler(this.alsAlarm1_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(12, 242);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(112, 53);
            this.txtUrl.TabIndex = 3;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnScrollDown);
            this.Controls.Add(this.btnScrollUp);
            this.Controls.Add(this.alsButton1);
            this.Controls.Add(this.keyboard);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.alsAlarm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ALSAlarm alsAlarm1;
        private ALSButton btnMenu;
        private KeyboardControl2 keyboard;
        private ALSButton alsButton1;
        private ALSButton btnScrollUp;
        private ALSButton btnScrollDown;
        private ALSButton btnBack;
        private ALSTextbox txtUrl;
    }
}