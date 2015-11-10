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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCallouts = new ALSProject.ALSButton();
            this.btnSpeak = new ALSProject.ALSButton();
            this.alsAlarm1 = new ALSProject.ALSAlarm();
            this.alsKeyboard = new ALSProject.KeyboardControl();
            this.btnMenu = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(281, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(435, 140);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnCallouts
            // 
            this.btnCallouts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCallouts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCallouts.FlatAppearance.BorderSize = 0;
            this.btnCallouts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallouts.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallouts.Location = new System.Drawing.Point(869, 12);
            this.btnCallouts.Name = "btnCallouts";
            this.btnCallouts.Size = new System.Drawing.Size(143, 140);
            this.btnCallouts.TabIndex = 8;
            this.btnCallouts.Text = "Callouts";
            this.btnCallouts.timeDivision = 15;
            this.btnCallouts.UseVisualStyleBackColor = false;
            // 
            // btnSpeak
            // 
            this.btnSpeak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSpeak.FlatAppearance.BorderSize = 0;
            this.btnSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeak.Location = new System.Drawing.Point(143, 12);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(132, 140);
            this.btnSpeak.TabIndex = 6;
            this.btnSpeak.Text = "Speak";
            this.btnSpeak.timeDivision = 15;
            this.btnSpeak.UseVisualStyleBackColor = false;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // alsAlarm1
            // 
            this.alsAlarm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsAlarm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alsAlarm1.BackgroundImage")));
            this.alsAlarm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.alsAlarm1.FlatAppearance.BorderSize = 0;
            this.alsAlarm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsAlarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 119F);
            this.alsAlarm1.Location = new System.Drawing.Point(13, 12);
            this.alsAlarm1.Name = "alsAlarm1";
            this.alsAlarm1.Size = new System.Drawing.Size(124, 140);
            this.alsAlarm1.TabIndex = 5;
            this.alsAlarm1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.alsAlarm1.timeDivision = 15;
            this.alsAlarm1.UseVisualStyleBackColor = false;
            // 
            // alsKeyboard
            // 
            this.alsKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alsKeyboard.BackColor = System.Drawing.Color.Black;
            this.alsKeyboard.Location = new System.Drawing.Point(12, 158);
            this.alsKeyboard.Name = "alsKeyboard";
            this.alsKeyboard.Size = new System.Drawing.Size(1000, 591);
            this.alsKeyboard.TabIndex = 4;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(722, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(141, 140);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Main Menu";
            this.btnMenu.timeDivision = 15;
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
            this.Controls.Add(this.alsKeyboard);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TextToSpeech";
            this.Text = "Text to Speech";
            this.Load += new System.EventHandler(this.TextToSpeech_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ALSButton btnMenu;
        private System.Windows.Forms.TextBox textBox1;
        private KeyboardControl alsKeyboard;
        private ALSAlarm alsAlarm1;
        private ALSButton btnSpeak;
        private ALSButton btnCallouts;
    }
}