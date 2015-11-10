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

            for (int i = 0; i < topRowButtons.Length; i++)
                topRowButtons[i] = new ALSButton();

            topRowButtons[0].Text = "Speak";
            topRowButtons[1].Text = "Add";
            topRowButtons[2].Text = "Edit";
            topRowButtons[3].Text = "Page Left";
            topRowButtons[4].Text = "Page Right";
            topRowButtons[5].Text = "Back";


            topRowButtons[2].Click += new System.EventHandler(this.edit_Click);

            foreach (ALSButton btn in topRowButtons)
                Controls.Add(btn);

            callouts = new ALSButton[3, NUM_CALLOUTS];
            for (int i = 0; i < callouts.GetLength(0); i++)
                for (int j = 0; j < callouts.GetLength(1); j++)
                {
                    callouts[i, j] = new ALSButton();
                    Controls.Add(callouts[i, j]);
                }
            for (int i = 0; i < callouts.GetLength(1); i++)
            {
                callouts[1, i].BackgroundImage = Properties.Resources.notepad;
                callouts[1, i].BackgroundImageLayout = ImageLayout.Zoom;
                callouts[1, i].Visible = false;

                callouts[2, i].BackgroundImage = Properties.Resources.checkmark;
                callouts[2, i].BackgroundImageLayout = ImageLayout.Zoom;
                callouts[2, i].Visible = false;
            }
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
                for (int i = 0; i < callouts.GetLength(1); i++)
                {
                    callouts[2, i].Location = new Point(Width - EDIT_BUTTON_WIDTH - UI.GAP, callouts[0, i].Location.Y);
                    callouts[2, i].Size = new Size(EDIT_BUTTON_WIDTH, callouts[0, 0].Size.Height);
                    callouts[2, i].Visible = true;

                    callouts[1, i].Location = new Point(Width - 2 * EDIT_BUTTON_WIDTH - 2 * UI.GAP, callouts[0, i].Location.Y);
                    callouts[1, i].Size = new Size(EDIT_BUTTON_WIDTH, callouts[0, 0].Size.Height);
                    callouts[1, i].Visible = true;

                    callouts[0, i].Size = new Size(Width - UI.GAP * 4 - 2 * EDIT_BUTTON_WIDTH, callouts[0, 0].Size.Height);
                }
            }
            else
            {
                for (int i = 0; i < callouts.GetLength(1); i++)
                {
                    callouts[0, i].Location = new Point(UI.GAP, (2 + i) * UI.GAP + buttonWidth + i * calloutsButtonHeight);
                    callouts[0, i].Size = new Size(Width - UI.GAP * 2, calloutsButtonHeight);
                    callouts[0, i].Text = i + "";
                }
            }
        }

    }
}
