namespace ALSProject
{
    partial class Email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Email));
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnScrollDown = new ALSProject.ALSButton();
            this.btnScrollUp = new ALSProject.ALSButton();
            this.btnMenu = new ALSProject.ALSButton();
            this.btnAlarm = new ALSProject.ALSAlarm();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(189, 12);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.Size = new System.Drawing.Size(670, 368);
            this.txtBody.TabIndex = 6;
            // 
            // btnScrollDown
            // 
            this.btnScrollDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnScrollDown.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnScrollDown.dwellTimeInterval = 100;
            this.btnScrollDown.FlatAppearance.BorderSize = 0;
            this.btnScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnScrollDown.Location = new System.Drawing.Point(12, 270);
            this.btnScrollDown.Name = "btnScrollDown";
            this.btnScrollDown.Size = new System.Drawing.Size(171, 110);
            this.btnScrollDown.TabIndex = 5;
            this.btnScrollDown.Text = "Down";
            this.btnScrollDown.UseVisualStyleBackColor = false;
            // 
            // btnScrollUp
            // 
            this.btnScrollUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnScrollUp.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnScrollUp.dwellTimeInterval = 100;
            this.btnScrollUp.FlatAppearance.BorderSize = 0;
            this.btnScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnScrollUp.Location = new System.Drawing.Point(12, 154);
            this.btnScrollUp.Name = "btnScrollUp";
            this.btnScrollUp.Size = new System.Drawing.Size(171, 110);
            this.btnScrollUp.TabIndex = 4;
            this.btnScrollUp.Text = "Up";
            this.btnScrollUp.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnMenu.dwellTimeInterval = 100;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnMenu.Location = new System.Drawing.Point(865, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(147, 143);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Main Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAlarm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAlarm.BackgroundImage")));
            this.btnAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAlarm.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnAlarm.dwellTimeInterval = 100;
            this.btnAlarm.FlatAppearance.BorderSize = 0;
            this.btnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAlarm.Location = new System.Drawing.Point(12, 12);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(171, 136);
            this.btnAlarm.TabIndex = 0;
            this.btnAlarm.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 386);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(171, 121);
            this.listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(189, 386);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(171, 121);
            this.listBox2.TabIndex = 8;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnScrollDown);
            this.Controls.Add(this.btnScrollUp);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnAlarm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Email";
            this.Text = "Email";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ALSAlarm btnAlarm;
        private ALSButton btnMenu;
        private ALSButton btnScrollUp;
        private ALSButton btnScrollDown;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}