using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class Callout : Form
    {

        ALSButton[] topRowButtons; //[Alarm, Add, Edit, PageLeft, PageRight, Back]
         
        ALSButton[,] callouts;
        private const int EDIT_BUTTON_WIDTH = 100;
        private const int NUM_CALLOUTS = 6;
        private bool isEditMode;

        public Callout(Form parent)
        {
            InitializeComponent();

            //this.Parent = parent;
            topRowButtons = new ALSButton[6];

            topRowButtons[0] = new ALSAlarm();

            for (int i = 1; i < topRowButtons.Length; i++)
                topRowButtons[i] = new ALSButton();

            topRowButtons[1].Text = "Edit"; //add functionality should appear in edit mode
            topRowButtons[2].Text = "Page Left";
            topRowButtons[3].Text = "Page Right";
            topRowButtons[4].Text = "Text to Speech";
            topRowButtons[5].Text = "Main Menu";

            topRowButtons[1].Click += new System.EventHandler(this.edit_Click);

            foreach (ALSButton btn in topRowButtons)
                Controls.Add(btn);

            callouts = new ALSButton[5, NUM_CALLOUTS];
            for (int i = 0; i < callouts.GetLength(0); i++)
                for (int j = 0; j < callouts.GetLength(1); j++)
                {
                    callouts[i, j] = new ALSButton();
                    Controls.Add(callouts[i, j]);
                }

            for (int i = 1; i < callouts.GetLength(0); i++)
                for (int j = 0; j < callouts.GetLength(1); j++)
                {
                    switch(i)
                    {
                        case 1:
                            callouts[i, j].BackgroundImage = Properties.Resources.notepad;
                            break;
                        case 2:
                            callouts[i, j].BackgroundImage = Properties.Resources.checkmark;
                            break;
                        case 3:
                            callouts[i, j].Text = "Up";
                            break;
                        case 4:
                            callouts[i, j].Text = "Down";
                            break;
                    }
                    callouts[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    callouts[i, j].Visible = false;
                }
        }

        public ALSButton[] getMenuBtns()
        {
            return topRowButtons;
        }


        private void Callout_Load(object sender, EventArgs e)
        {
            ResizeButtons();
        }
        private void edit_Click(object sender, EventArgs e)
        {
            isEditMode = !isEditMode;
            for (int i = 0; i < callouts.GetLength(1); i++)
            {
                callouts[1, i].Visible = isEditMode;
                callouts[2, i].Visible = isEditMode;
            }
            ResizeButtons();
        }

        private void ResizeButtons()
        {
            int buttonWidth = (this.Width - (topRowButtons.Length + 1) * UI.GAP) / topRowButtons.Length;

            for (int i = 0; i < topRowButtons.Length; i++)
            {
                topRowButtons[i].Location = new Point(UI.GAP * (1 + i) + buttonWidth * i, UI.GAP);
                topRowButtons[i].Size = new Size(buttonWidth, buttonWidth);
            }


            int calloutsButtonHeight = (Height - buttonWidth - UI.GAP * (2 + callouts.GetLength(1))) / callouts.GetLength(1);

            if (isEditMode)
            {

                for (int i = 0; i < callouts.GetLength(0); i++)
                    for (int j = 0; j < callouts.GetLength(1); j++)
                    {
                        if (i != 0)
                        {
                            callouts[i, j].Location = new Point(Width - (callouts.GetLength(0) - i) * (EDIT_BUTTON_WIDTH + UI.GAP), callouts[0, j].Location.Y);
                            callouts[i, j].Size = new Size(EDIT_BUTTON_WIDTH, callouts[0, 0].Size.Height);
                            callouts[i, j].Visible = true;
                        }
                        else
                            callouts[i, j].Size = new Size(Width - UI.GAP * (callouts.GetLength(0) + 1) - (callouts.GetLength(0) - 1) * EDIT_BUTTON_WIDTH, callouts[0, 0].Size.Height);
                    }
                topRowButtons[4].Text = "Add";
            }
            else
            {
                for (int i = 0; i < callouts.GetLength(1); i++)
                {
                    callouts[0, i].Location = new Point(UI.GAP, (2 + i) * UI.GAP + buttonWidth + i * calloutsButtonHeight);
                    callouts[0, i].Size = new Size(Width - UI.GAP * 2, calloutsButtonHeight);
                    callouts[0, i].Text = i + "";
                }
                for (int i = 1; i < callouts.GetLength(0); i++)
                    for (int j = 0; j < callouts.GetLength(1); j++)
                        callouts[i, j].Visible = false;

                topRowButtons[4].Text = "Callouts";
            }
        }

    

    }
}
