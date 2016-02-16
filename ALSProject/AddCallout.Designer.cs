namespace ALSProject
{
    partial class AddCallout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCallout));
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            // 
            // alsAlarm1
            // 
            this.alsAlarm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alsAlarm1.BackgroundImage")));
            this.alsAlarm1.FlatAppearance.BorderSize = 0;
            // 
            // btnSpeak
            // 
            this.btnSpeak.FlatAppearance.BorderSize = 0;
            // 
            // btnCallouts
            // 
            this.btnCallouts.FlatAppearance.BorderSize = 0;
            // 
            // alsKeyboard
            // 
            this.alsKeyboard.Size = new System.Drawing.Size(264, 241);
            // 
            // AddCallout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AddCallout";
            this.Text = "Add Callout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCallout_FormClosing);
            this.Resize += new System.EventHandler(this.AddCallout_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}