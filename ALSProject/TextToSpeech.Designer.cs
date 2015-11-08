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
            this.btnClear = new ALSProject.ALSButton();
            this.btnSpeak = new ALSProject.ALSButton();
            this.alsAlarm1 = new ALSProject.ALSAlarm();
            this.alsKeyboard = new ALSProject.KeyboardControl();
            this.btnMenu = new ALSProject.ALSButton();
            this.btnCallouts = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(236, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(464, 194);
            this.textBox1.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(706, 112);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(157, 94);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.timeDivision = 15;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSpeak
            // 
            this.btnSpeak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSpeak.FlatAppearance.BorderSize = 0;
            this.btnSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeak.Location = new System.Drawing.Point(706, 12);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(157, 94);
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
            this.alsAlarm1.Size = new System.Drawing.Size(217, 194);
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
            this.alsKeyboard.Location = new System.Drawing.Point(12, 234);
            this.alsKeyboard.Name = "alsKeyboard";
            this.alsKeyboard.Size = new System.Drawing.Size(1000, 515);
            this.alsKeyboard.TabIndex = 4;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(869, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(143, 94);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Main Menu";
            this.btnMenu.timeDivision = 15;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnCallouts
            // 
            this.btnCallouts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCallouts.FlatAppearance.BorderSize = 0;
            this.btnCallouts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallouts.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallouts.Location = new System.Drawing.Point(869, 112);
            this.btnCallouts.Name = "btnCallouts";
            this.btnCallouts.Size = new System.Drawing.Size(143, 94);
            this.btnCallouts.TabIndex = 8;
            this.btnCallouts.Text = "Callouts";
            this.btnCallouts.timeDivision = 15;
            this.btnCallouts.UseVisualStyleBackColor = false;
            // 
            // TextToSpeech
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnCallouts);
            this.Controls.Add(this.btnClear);
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
        private ALSButton btnClear;
        private ALSButton btnCallouts;
    }
}