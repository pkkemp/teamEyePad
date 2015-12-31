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

        protected ALSButton[,] notes;
        protected const int EDIT_BUTTON_WIDTH = 100;
        protected const int NUM_NOTES = 6;
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

            //setup  note list
            phrases = new List<String>();
            populateList();

            //this.Parent = parent;
            topRowButtons = new ALSButton[6];

            topRowButtons[0] = new ALSAlarm();

            for (int i = 1; i < topRowButtons.Length; i++)
                topRowButtons[i] = new ALSButton();

            topRowButtons[1].Text = "Delete";
            topRowButtons[2].Text = "Page\nLeft";
            topRowButtons[3].Text = "Page\nRight";
            topRowButtons[4].Text = "New\nNote";
            topRowButtons[5].Text = "Main\nMenu";

            topRowButtons[1].Click += new System.EventHandler(this.edit_Click);
            topRowButtons[2].Click += new System.EventHandler(this.pageLeft);
            topRowButtons[3].Click += new System.EventHandler(this.pageRight);
            topRowButtons[4].Click += new System.EventHandler(this.NewNote_Click);
            topRowButtons[5].Click += new System.EventHandler(this.MainMenu_Click);

            notepage.getBackBtn().Click += new System.EventHandler(this.addToList);
            //notepage.getSaveButton().Click += new EventHandler(this.addToList); // there is no save button...

            topRowButtons[2].Enabled = false;
            if (NUM_NOTES > phrases.Count)
                topRowButtons[3].Enabled = false;

            foreach (ALSButton btn in topRowButtons)
            {
                Controls.Add(btn);
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            notes = new ALSButton[2, NUM_NOTES];
            for (int i = 0; i < notes.GetLength(0); i++)
                for (int j = 0; j < notes.GetLength(1); j++)
                {
                    notes[i, j] = new ALSButton();
                    Controls.Add(notes[i, j]);
                }

            for (int i = 0; i < notes.GetLength(1); i++)
            {
                notes[0, i].Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                notes[0, i].Click += new EventHandler(this.EditNote);
                notes[0, i].Name = "btnNotepage" + i;
            }

            for (int i = 1; i < notes.GetLength(0); i++)
                for (int j = 0; j < notes.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 1:
                            notes[i, j].BackgroundImage = Properties.Resources.trashcan;
                            notes[i, j].Name = "btnDel" + j;
                            notes[i, j].Click += new System.EventHandler(this.deleteItem);
                            break;
                    }
                    notes[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    notes[i, j].Visible = false;
                }

            flipToPage(0);
        }

        private void EditNote(object sender, EventArgs e)
        {
            ALSButton btn = (ALSButton)sender;
            notepage.Visible = true;
            this.Visible = false;
            //Load Text
            if (!String.IsNullOrEmpty(btn.Name))
            {
                int index = getNum(btn.Name) + pageNum * NUM_NOTES;
                if (index >= 0 && index < phrases.Count)
                {
                    notepage.setText(phrases[index]);
                    indexBeingEdited = index;
                    phrases.RemoveAt(index);
                    if ((pageNum + 1) * NUM_NOTES > phrases.Count + 1)
                        topRowButtons[3].Enabled = false;
                }
            }
            //Set Cursor at end
            notepage.setCursorAtEnd();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
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
            Console.WriteLine(str);
            if (str != "" && str != null)
            {
                phrases.Add(str);
                if ((pageNum + 1) * NUM_NOTES <= phrases.Count)
                    topRowButtons[3].Enabled = true;

            }

            this.refreshNotes();
            this.Show();
            notepage.Hide();
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
                phrases.RemoveAt(num + NUM_NOTES * pageNum);
                if ((pageNum + 1) * NUM_NOTES > phrases.Count + 1)
                    topRowButtons[3].Enabled = false;

            }
            catch (ArgumentOutOfRangeException) { }
            refreshNotes();
        }

        private void pageRight(object sender, EventArgs e)
        {
            pageNum++;
            flipToPage(pageNum);
            topRowButtons[2].Enabled = true;
            if ((pageNum + 1) * NUM_NOTES > phrases.Count)
                topRowButtons[3].Enabled = false;
        }

        private void pageLeft(object sender, EventArgs e)
        {
            pageNum--;
            flipToPage(pageNum);
            topRowButtons[3].Enabled = true;
            if (pageNum == 0)
                topRowButtons[2].Enabled = false;
        }

        private void flipToPage(int num)
        {
            if (num < 0)
                num = 0;
            else if (phrases.Count / NUM_NOTES < num)
            {
                num = phrases.Count / NUM_NOTES;
            }

            pageNum = num;

            for (int i = 0; i < NUM_NOTES; i++)
            {
                try
                {
                    int maxCharactersShown = 40;
                    if (phrases[i + num * NUM_NOTES].Length >= maxCharactersShown)
                        notes[0, i].Text = phrases[i + num * NUM_NOTES].Substring(0, maxCharactersShown);
                    else
                        notes[0, i].Text = phrases[i + num * NUM_NOTES];
                }
                catch (ArgumentOutOfRangeException) { notes[0, i].Text = ""; }
            }

        }

        private void NewNote_Click(object sender, EventArgs e)
        {
            indexBeingEdited = 0;
            notepage.ClearText();
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
            for (int i = 0; i < notes.GetLength(1); i++)
            {
                notes[1, i].Visible = isEditMode;
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


            int notesButtonHeight = (Height - buttonWidth - UI.GAP * (2 + notes.GetLength(1))) / notes.GetLength(1);

            if (isEditMode)
            {

                for (int i = 0; i < notes.GetLength(0); i++)
                    for (int j = 0; j < notes.GetLength(1); j++)
                    {
                        if (i != 0)
                        {
                            notes[i, j].Location = new Point(Width - (notes.GetLength(0) - i) * (EDIT_BUTTON_WIDTH + UI.GAP), notes[0, j].Location.Y);
                            notes[i, j].Size = new Size(EDIT_BUTTON_WIDTH, notes[0, 0].Size.Height);
                            notes[i, j].Visible = true;
                        }
                        else
                            notes[i, j].Size = new Size(Width - UI.GAP * (notes.GetLength(0) + 1) - (notes.GetLength(0) - 1) * EDIT_BUTTON_WIDTH, notes[0, 0].Size.Height);
                    }
            }
            else
            {
                for (int i = 0; i < notes.GetLength(1); i++)
                {
                    notes[0, i].Location = new Point(UI.GAP, (2 + i) * UI.GAP + buttonWidth + i * notesButtonHeight);
                    notes[0, i].Size = new Size(Width - UI.GAP * 2, notesButtonHeight);
                }
                for (int i = 1; i < notes.GetLength(0); i++)
                    for (int j = 0; j < notes.GetLength(1); j++)
                        notes[i, j].Visible = false;
            }
        }

        private void Notebook_FormClosing(object sender, FormClosingEventArgs e)
        {

            //I'm pretty sure this is redundant in most cases. If we want to do this we need to make sure it only happens when the program is being closed by an outside operation
            /*if(indexBeingEdited != -1)
            {
                phrases.Insert(0, notepage.getText());
            }*/


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

        }
    }
}
