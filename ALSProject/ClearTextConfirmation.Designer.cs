namespace ALSProject
{
    partial class ClearTextConfirmation
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
            this.confirmation1 = new ALSProject.Confirmation();
            this.SuspendLayout();
            // 
            // confirmation1
            // 
            this.confirmation1.Location = new System.Drawing.Point(13, 13);
            this.confirmation1.Name = "confirmation1";
            this.confirmation1.Size = new System.Drawing.Size(639, 328);
            this.confirmation1.TabIndex = 0;
            // 
            // ClearTextConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(658, 343);
            this.Controls.Add(this.confirmation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClearTextConfirmation";
            this.Text = "ClearTextConfirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private Confirmation confirmation1;
    }
}