namespace ALSProject
{
    partial class QuitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuitForm));
            this.yesBut = new ALSProject.ALSButton();
            this.noBut = new ALSProject.ALSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesBut
            // 
            this.yesBut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yesBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yesBut.BackgroundImage = global::ALSProject.Properties.Resources.checkmark;
            this.yesBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yesBut.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.yesBut.dwellTimeInterval = 50;
            this.yesBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.yesBut.Location = new System.Drawing.Point(12, 143);
            this.yesBut.Name = "yesBut";
            this.yesBut.Size = new System.Drawing.Size(312, 248);
            this.yesBut.TabIndex = 4;
            this.yesBut.UseVisualStyleBackColor = false;
            this.yesBut.Click += new System.EventHandler(this.yesBut_Click);
            // 
            // noBut
            // 
            this.noBut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.noBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.noBut.BackgroundImage = global::ALSProject.Properties.Resources.minus;
            this.noBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noBut.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.noBut.dwellTimeInterval = 15;
            this.noBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.noBut.Location = new System.Drawing.Point(330, 143);
            this.noBut.Name = "noBut";
            this.noBut.Size = new System.Drawing.Size(312, 248);
            this.noBut.TabIndex = 5;
            this.noBut.UseVisualStyleBackColor = false;
            this.noBut.Click += new System.EventHandler(this.noBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "Are you sure you want to quit?";
            // 
            // QuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(650, 403);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noBut);
            this.Controls.Add(this.yesBut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuitForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QuitForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuitForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ALSButton yesBut;
        private ALSButton noBut;
        private System.Windows.Forms.Label label1;
    }
}