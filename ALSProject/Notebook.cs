using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class Notebook : Form
    {
        private List<string> phrases;

        ALSButton[] topRowButtons; //[Alarm, Add, Edit, PageLeft, PageRight, Back]

        protected ALSButton[,] callouts;
        protected const int EDIT_BUTTON_WIDTH = 100;
        protected const int NUM_CALLOUTS = 6;
        protected bool isEditMode;
        protected int pageNum = 0;
        SpeechSynthesizer speaker;
        private int indexBeingEdited;       //-1 means it's not being used

        Notepage notepage;

        private Form parentForm;
        
        public Notebook(Form parent, SpeechSynthesizer voice)
        {
            InitializeComponent();

            parentForm = parent;
            //setup speech
            speaker = voice;

            notepage = new Notepage(this, speaker);

            indexBeingEdited = -1;

            //setup  callout list
            phrases = new List<String>();
            populateList();

            //this.Parent = parent;
            topRowButtons = new ALSButton[6];

            topRowButtons[0] = new ALSAlarm();

            for (int i = 1; i < topRowButtons.Length; i++)
                topRowButtons[i] = new ALSButton();

            topRowButtons[1].Text = "Delete";
            topRowButtons[2].Text = "Page Left";
            topRowButtons[3].Text = "Page Right";
            topRowButtons[4].Text = "New Note";
            topRowButtons[5].Text = "Main Menu";

            topRowButtons[1].Click += new System.EventHandler(this.edit_Click);
            topRowButtons[2].Click += new System.EventHandler(this.pageLeft);
            topRowButtons[3].Click += new System.EventHandler(this.pageRight);
            topRowButtons[4].Click += new System.EventHandler(this.NewNote_Click);
            topRowButtons[5].Click += new System.EventHandler(this.MainMenu_Click);
            notepage.getSaveButton().Click += new EventHandler(this.addToList);

            foreach (ALSButton btn in topRowButtons)
            {
                Controls.Add(btn);
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            callouts = new ALSButton[2, NUM_CALLOUTS];
            for (int i = 0; i < callouts.GetLength(0); i++)
                for (int j = 0; j < callouts.GetLength(1); j++)
                {
                    callouts[i, j] = new ALSButton();
                    Controls.Add(callouts[i, j]);
                }

            for (int i = 0; i < callouts.GetLength(1); i++)
            {
                callouts[0, i].Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                callouts[0, i].Click += new EventHandler(this.EditNote);
                callouts[0, i].Name = "btnNotepage" + i;
            }

            for (int i = 1; i < callouts.GetLength(0); i++)
                for (int j = 0; j < callouts.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 1:
                            callouts[i, j].BackgroundImage = Properties.Resources.trashcan;
                            callouts[i, j].Name = "btnDel" + j;
                            callouts[i, j].Click += new System.EventHandler(this.deleteItem);
                            break;
                    }
                    callouts[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    callouts[i, j].Visible = false;
                }

            flipToPage(0);
        }

        private void EditNote(object sender, EventArgs e)
        {
            ALSButton btn = (ALSButton)sender;
            notepage.Visible = true;
            this.Visible = false;
            //Load Text
            if(!String.IsNullOrEmpty(btn.Name))
            {
                int index = getNum(btn.Name) + pageNum * NUM_CALLOUTS;
                if (index >= 0 && index < phrases.Count)
                {
                    notepage.setText(phrases[index]);
                    indexBeingEdited = index;
                    phrases.RemoveAt(index);
                    if (phrases.Count < NUM_CALLOUTS)
                        phrases.Add("Add new note");
                }
            }
            //Set Cursor at end
            notepage.setCursorAtEnd();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            parentForm.Visible = true;
            this.Visible = false;
        }

        private int getNum(String str)
        {
            char test = str[str.Length - 1];
            int num = Convert.ToInt16(test - '0');
            return num;
        }

        private void addToList(object sender, EventArgs e)
        {
            string str = notepage.getText();
            phrases.Add(str);
            this.Show();
            notepage.Hide();
            this.refreshNotes();
            notepage.setText("");
        }
        
        private void refreshNotes()
        {
            flipToPage(pageNum);
        }
        
        private void deleteItem(object sender, EventArgs e)
        {
            ALSButton btn = (ALSButton)sender;

            int num = getNum(btn.Name);
            try
            {
                phrases.RemoveAt(num + NUM_CALLOUTS * pageNum);
                if (phrases.Count < NUM_CALLOUTS)
                    phrases.Add("Add new note");
            }
            catch (ArgumentOutOfRangeException) { }
            refreshNotes();
        }

        private void pageRight(object sender, EventArgs e)
        {
            pageNum++;
            flipToPage(pageNum);
        }

        private void pageLeft(object sender, EventArgs e)
        {
            pageNum--;
            flipToPage(pageNum);
        }
        
        private void flipToPage(int num)
        {
            if (num < 0)
                num = 0;
            else if (phrases.Count / NUM_CALLOUTS < num)
            {
                num = phrases.Count / NUM_CALLOUTS;
            }

            pageNum = num;

            for (int i = 0; i < NUM_CALLOUTS; i++)
            {
                try { callouts[0, i].Text = phrases[i + num * NUM_CALLOUTS]; }
                catch (ArgumentOutOfRangeException) { callouts[0, i].Text = ""; }
            }

        }

        private void NewNote_Click(object sender, EventArgs e)
        {
            indexBeingEdited = 0;
            notepage.Show();
            this.Hide();
        }

        private void populateList()
        {

            if (!File.Exists("Notes.txt"))
            {
                generateDefaultFile();
            }

            StreamReader file = new StreamReader(File.Open("Notes.txt", FileMode.Open));

            while (!file.EndOfStream)
            {
                phrases.Add(file.ReadLine());
            }

            foreach (string str in phrases)
            {
                Console.WriteLine(str);
            }

            file.Close();
        }

        public void resetList()
        {
            phrases.Clear();
            this.refreshNotes();
        }


        private void generateDefaultFile()
        {
            StreamWriter filestream = new StreamWriter(File.Create("Notes.txt"));
            filestream.Close();
        }

        public ALSButton[] getMenuBtns()
        {
            return topRowButtons;
        }
        
        private void edit_Click(object sender, EventArgs e)
        {
            isEditMode = !isEditMode;
            for (int i = 0; i < callouts.GetLength(1); i++)
            {
                callouts[1, i].Visible = isEditMode;
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
            }
            else
            {
                for (int i = 0; i < callouts.GetLength(1); i++)
                {
                    callouts[0, i].Location = new Point(UI.GAP, (2 + i) * UI.GAP + buttonWidth + i * calloutsButtonHeight);
                    callouts[0, i].Size = new Size(Width - UI.GAP * 2, calloutsButtonHeight);
                }
                for (int i = 1; i < callouts.GetLength(0); i++)
                    for (int j = 0; j < callouts.GetLength(1); j++)
                        callouts[i, j].Visible = false;
            }
        }
        
        private void Notebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(indexBeingEdited != -1)
            {
                phrases.Insert(0, notepage.getText());
            }


            StreamWriter filestream = new StreamWriter(File.Open("Notes.txt", FileMode.Create));
            for (int i = 0; i < phrases.Count; i++)
            {
                filestream.WriteLine(phrases[i]);
            }

            filestream.Close();
        }

        private void Notebook_Load(object sender, EventArgs e)
        {
            ResizeButtons();
        }

        private void Notebook_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (indexBeingEdited != -1)
                {
                    phrases.Insert(0, notepage.getText());
                    indexBeingEdited = -1;
                }
                refreshNotes();
            }
        }
    }
}
