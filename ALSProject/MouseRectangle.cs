using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ALSProject
{
    class MouseRectangle
    {
        private Rectangle bounds;
        Timer timer;
        private Form parentForm;
        private Control parentControl;
        Graphics gr;

        public MouseRectangle(Form parent)
        {
            timer = new Timer();
            timer.Tick += new System.EventHandler(timerEvent);
            timer.Interval = 100;
            timer.Enabled = true;
            bounds.Size = new Size(50, 50);
            parentForm = parent;
        }

        public MouseRectangle(Control parent)
        {
            timer = new Timer();
            timer.Tick += new System.EventHandler(timerEvent);
            timer.Interval = 100;
            timer.Enabled = false;
            bounds.Size = new Size(50, 50);
            parentControl = parent;
        }

        private void timerEvent(object sender, EventArgs e)
        {
            bool doEvent = false;
            if (parentForm != null && parentForm.Visible)
            {
                gr = parentForm.CreateGraphics();
                doEvent = true;
            }
            else if (parentControl != null && parentControl.Visible)
            {
                gr = parentControl.CreateGraphics();
                doEvent = true;
            }


            if (doEvent) {
                gr.Clear(Color.FromArgb(32,32,32));
                bounds.Location = new Point(Cursor.Position.X - bounds.Size.Width/2, Cursor.Position.Y - bounds.Size.Height / 2);
                gr.FillRectangle(Brushes.SkyBlue, bounds);
            }
        }

        public void UpdateRect()
        {
            bool doEvent = false;
            if (parentForm != null && parentForm.Visible)
            {
                gr = parentForm.CreateGraphics();
                doEvent = true;
            }
            else if (parentControl != null && parentControl.Visible)
            {
                gr = parentControl.CreateGraphics();
                doEvent = true;
            }


            if (doEvent)
            {
                gr.Clear(Color.FromArgb(32, 32, 32));
                bounds.Location = new Point(Cursor.Position.X - bounds.Size.Width / 2, Cursor.Position.Y - bounds.Size.Height / 2);
                gr.FillRectangle(Brushes.SkyBlue, bounds);
            }
        }

    }
}
