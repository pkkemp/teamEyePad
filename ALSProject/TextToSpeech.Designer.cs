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
            this.alsButton3 = new ALSProject.ALSButton();
            this.alsButton2 = new ALSProject.ALSButton();
            this.alsAlarm1 = new ALSProject.ALSAlarm();
            this.alsKeyboard = new ALSProject.KeyboardControl();
            this.alsButton1 = new ALSProject.ALSButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(491, 194);
            this.textBox1.TabIndex = 3;
            // 
            // alsButton3
            // 
            this.alsButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton3.FlatAppearance.BorderSize = 0;
            this.alsButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton3.Location = new System.Drawing.Point(642, 112);
            this.alsButton3.Name = "alsButton3";
            this.alsButton3.Size = new System.Drawing.Size(126, 94);
            this.alsButton3.TabIndex = 7;
            this.alsButton3.Text = "Clear";
            this.alsButton3.timeDivision = 15;
            this.alsButton3.UseVisualStyleBackColor = false;
            this.alsButton3.Click += new System.EventHandler(this.alsButton3_Click);
            // 
            // alsButton2
            // 
            this.alsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton2.FlatAppearance.BorderSize = 0;
            this.alsButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton2.Location = new System.Drawing.Point(642, 12);
            this.alsButton2.Name = "alsButton2";
            this.alsButton2.Size = new System.Drawing.Size(126, 94);
            this.alsButton2.TabIndex = 6;
            this.alsButton2.Text = "Speak";
            this.alsButton2.timeDivision = 15;
            this.alsButton2.UseVisualStyleBackColor = false;
            this.alsButton2.Click += new System.EventHandler(this.alsButton2_Click);
            // 
            // alsAlarm1
            // 
            this.alsAlarm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsAlarm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alsAlarm1.BackgroundImage")));
            this.alsAlarm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.alsAlarm1.FlatAppearance.BorderSize = 0;
            this.alsAlarm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsAlarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 69F);
            this.alsAlarm1.Location = new System.Drawing.Point(13, 12);
            this.alsAlarm1.Name = "alsAlarm1";
            this.alsAlarm1.Size = new System.Drawing.Size(126, 104);
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
            // alsButton1
            // 
            this.alsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alsButton1.FlatAppearance.BorderSize = 0;
            this.alsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alsButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alsButton1.Location = new System.Drawing.Point(886, 12);
            this.alsButton1.Name = "alsButton1";
            this.alsButton1.Size = new System.Drawing.Size(126, 94);
            this.alsButton1.TabIndex = 1;
            this.alsButton1.Text = "Main Menu";
            this.alsButton1.timeDivision = 15;
            this.alsButton1.UseVisualStyleBackColor = false;
            this.alsButton1.Click += new System.EventHandler(this.alsButton1_Click);
            // 
            // TextToSpeech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.alsButton3);
            this.Controls.Add(this.alsButton2);
            this.Controls.Add(this.alsAlarm1);
            this.Controls.Add(this.alsKeyboard);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.alsButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TextToSpeech";
            this.Text = "Notebook";
            this.Load += new System.EventHandler(this.TextToSpeech_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ALSButton alsButton1;
        private System.Windows.Forms.TextBox textBox1;
        private KeyboardControl alsKeyboard;
        private ALSAlarm alsAlarm1;
        private ALSButton alsButton2;
        private ALSButton alsButton3;
    }
}