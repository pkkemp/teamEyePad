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
            this.quitBut = new ALSProject.ALSButton();
            this.setBut = new ALSProject.ALSButton();
            this.btnMax = new ALSProject.ALSButton();
            this.alsButton4 = new ALSProject.ALSButton();
            this.alsButton5 = new ALSProject.ALSButton();
            this.mailBut = new ALSProject.ALSButton();
            this.noteBut = new ALSProject.ALSButton();
            this.ttsBut = new ALSProject.ALSButton();
            this.alarmBut = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // quitBut
            // 
            this.quitBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quitBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.quitBut.BackgroundImage = global::ALSProject.Properties.Resources.power;
            this.quitBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitBut.elapseDivide = 10;
            this.quitBut.Location = new System.Drawing.Point(700, 518);
            this.quitBut.Name = "quitBut";
            this.quitBut.Size = new System.Drawing.Size(312, 248);
            this.quitBut.TabIndex = 10;
            this.quitBut.UseVisualStyleBackColor = false;
            this.quitBut.Click += new System.EventHandler(this.quitBut_Click);
            // 
            // setBut
            // 
            this.setBut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.setBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.setBut.BackgroundImage = global::ALSProject.Properties.Resources.gear_b;
            this.setBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setBut.elapseDivide = 10;
            this.setBut.Location = new System.Drawing.Point(356, 518);
            this.setBut.Name = "setBut";
            this.setBut.Size = new System.Drawing.Size(312, 248);
            this.setBut.TabIndex = 9;
            this.setBut.UseVisualStyleBackColor = false;
            this.setBut.Click += new System.EventHandler(this.setBut_Click);
            this.setBut.MouseEnter += new System.EventHandler(this.setBut_MouseEnter);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMax.elapseDivide = 10;
            this.btnMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.Location = new System.Drawing.Point(12, 518);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(312, 248);
            this.btnMax.TabIndex = 8;
            this.btnMax.Text = "+";
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // alsButton4
            // 
            this.alsButton4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alsButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton4.elapseDivide = 10;
            this.alsButton4.Location = new System.Drawing.Point(700, 264);
            this.alsButton4.Name = "alsButton4";
            this.alsButton4.Size = new System.Drawing.Size(312, 248);
            this.alsButton4.TabIndex = 7;
            this.alsButton4.UseVisualStyleBackColor = false;
            this.alsButton4.Click += new System.EventHandler(this.alsButton4_Click);
            // 
            // alsButton5
            // 
            this.alsButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.alsButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton5.elapseDivide = 10;
            this.alsButton5.Location = new System.Drawing.Point(356, 264);
            this.alsButton5.Name = "alsButton5";
            this.alsButton5.Size = new System.Drawing.Size(312, 248);
            this.alsButton5.TabIndex = 6;
            this.alsButton5.UseVisualStyleBackColor = false;
            // 
            // mailBut
            // 
            this.mailBut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mailBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mailBut.elapseDivide = 10;
            this.mailBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailBut.Location = new System.Drawing.Point(12, 264);
            this.mailBut.Name = "mailBut";
            this.mailBut.Size = new System.Drawing.Size(312, 248);
            this.mailBut.TabIndex = 5;
            this.mailBut.Text = "-";
            this.mailBut.UseVisualStyleBackColor = false;
            this.mailBut.Click += new System.EventHandler(this.mailBut_Click);
            // 
            // noteBut
            // 
            this.noteBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noteBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.noteBut.BackgroundImage = global::ALSProject.Properties.Resources.Notes;
            this.noteBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noteBut.elapseDivide = 10;
            this.noteBut.Location = new System.Drawing.Point(700, 10);
            this.noteBut.Name = "noteBut";
            this.noteBut.Size = new System.Drawing.Size(312, 248);
            this.noteBut.TabIndex = 4;
            this.noteBut.UseVisualStyleBackColor = false;
            // 
            // ttsBut
            // 
            this.ttsBut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ttsBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ttsBut.BackgroundImage = global::ALSProject.Properties.Resources.chatbubbles;
            this.ttsBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ttsBut.elapseDivide = 10;
            this.ttsBut.Location = new System.Drawing.Point(356, 10);
            this.ttsBut.Name = "ttsBut";
            this.ttsBut.Size = new System.Drawing.Size(312, 248);
            this.ttsBut.TabIndex = 3;
            this.ttsBut.UseVisualStyleBackColor = false;
            // 
            // alarmBut
            // 
            this.alarmBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alarmBut.elapseDivide = 10;
            this.alarmBut.Location = new System.Drawing.Point(12, 10);
            this.alarmBut.Name = "alarmBut";
            this.alarmBut.Size = new System.Drawing.Size(312, 248);
            this.alarmBut.TabIndex = 2;
            this.alarmBut.UseVisualStyleBackColor = false;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.quitBut);
            this.Controls.Add(this.setBut);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.alsButton4);
            this.Controls.Add(this.alsButton5);
            this.Controls.Add(this.mailBut);
            this.Controls.Add(this.noteBut);
            this.Controls.Add(this.ttsBut);
            this.Controls.Add(this.alarmBut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALS App";
            this.Load += new System.EventHandler(this.User_Interface_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ALSButton alarmBut;
        private ALSButton ttsBut;
        private ALSButton noteBut;
        private ALSButton alsButton4;
        private ALSButton alsButton5;
        private ALSButton mailBut;
        private ALSButton setBut;
        private ALSButton btnMax;
        private ALSButton quitBut;
    }
}