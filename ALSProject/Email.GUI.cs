using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ALSProject
{
    partial class Email
    {
        
        void CreateLayout(ComponentResourceManager resources)
        {
            /*
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnScrollDown = new ALSProject.ALSButton();
            this.btnScrollUp = new ALSProject.ALSButton();
            this.btnMenu = new ALSProject.ALSButton();
            this.btnAlarm = new ALSProject.ALSAlarm();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            */
            this.btnTest = new ALSProject.ALSButton();
          

            //
            // testButton
            //
            //this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTest.btnType = ALSProject.ALSButton.ButtonType.normal;
            this.btnTest.dwellTimeInterval = 100;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnTest.Location = new System.Drawing.Point(this.Width-100, this.Height-100);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(147, 143);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            
            this.Controls.Add(this.btnTest);
            btnTest.setFontSize();
            btnMenu.setFontSize();
        }

        private ALSButton btnTest;
    }

}
