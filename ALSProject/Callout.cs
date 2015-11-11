﻿using System;
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
    public partial class Callout : Form
    {

        private List<string> phrases;
        
        ALSButton[] topRowButtons; //[Alarm, Add, Edit, PageLeft, PageRight, Back]
         
        ALSButton[,] callouts;
        private const int EDIT_BUTTON_WIDTH = 100;
        private const int NUM_CALLOUTS = 6;
        private bool isEditMode;
        private int pageNum = 0;
        SpeechSynthesizer speaker;
        AddCallout ac;


        public Callout(Form parent, SpeechSynthesizer voice)
        {
            InitializeComponent();

            //setup speech
            speaker = voice;

            ac = new AddCallout(this, speaker);

            //setup  callout list
            phrases = new List<String>();
            populateList();

            //this.Parent = parent;
            topRowButtons = new ALSButton[6];

            topRowButtons[0] = new ALSAlarm();

            for (int i = 1; i < topRowButtons.Length; i++)
                topRowButtons[i] = new ALSButton();

            topRowButtons[1].Text = "Edit"; 
            topRowButtons[2].Text = "Page Left";
            topRowButtons[3].Text = "Page Right";
            topRowButtons[4].Text = "Text to Speech";
            topRowButtons[5].Text = "Main Menu";

            topRowButtons[1].Click += new System.EventHandler(this.edit_Click);
            topRowButtons[2].Click += new System.EventHandler(this.pageLeft);
            topRowButtons[3].Click += new System.EventHandler(this.pageRight);
            topRowButtons[4].Click += new System.EventHandler(this.TextToSpeech_Click);
            ac.getSaveButton().Click += new EventHandler(this.addToList);

            foreach (ALSButton btn in topRowButtons) { 
                Controls.Add(btn);
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
            }

            callouts = new ALSButton[5, NUM_CALLOUTS];
            for (int i = 0; i < callouts.GetLength(0); i++)
                for (int j = 0; j < callouts.GetLength(1); j++)
                {
                    callouts[i, j] = new ALSButton();
                    Controls.Add(callouts[i, j]);
                }

            for(int i = 0; i < callouts.GetLength(1); i++)
            {
                callouts[0, i].Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                callouts[0, i].Click += new EventHandler(this.speakCallout);
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
                            callouts[i, j].BackgroundImage = Properties.Resources.trashcan;
                            callouts[i, j].Name = "btnDel" + j;
                            callouts[i, j].Click += new System.EventHandler(this.deleteItem);
                            break;
                        case 3:
                            callouts[i, j].Text = "Up";
                            callouts[i, j].Name = "btnUp" + j;
                            callouts[i, j].Click += new System.EventHandler(this.moveItemUp);
                            break;
                        case 4:
                            callouts[i, j].Text = "Down";
                            callouts[i, j].Name = "btnDown" + j;
                            callouts[i, j].Click += new EventHandler(this.moveItemDown);
                            break;
                    }
                    callouts[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    callouts[i, j].Visible = false;
                }

            flipToPage(0);
            
        }

        private void addToList(object sender, EventArgs e)
        {
            string str = ac.getTextBox().Text;
            phrases.Add(str);
            this.Show();
            ac.Hide();
        }

        private void speakCallout(object sender, EventArgs e)
        {
            ALSButton btn = (ALSButton)sender;
            speaker.SpeakAsyncCancelAll();
            speaker.SpeakAsync(btn.Text);
        }

        private void refreshCalloutList()
        {
            flipToPage(pageNum);
        }

        private void moveItemDown(object sender, EventArgs e)
        {
            try { 
                ALSButton btn = (ALSButton)sender;
                int num = 0;
                switch (btn.Name) //I am fully aware this is a foolish way of doing this. By all means fix it but idk how
                {
                    case "btnDown0":
                        num = 0;
                        break;
                    case "btnDown1":
                        num = 1;
                        break;
                    case "btnDown2":
                        num = 2;
                        break;
                    case "btnDown3":
                        num = 3;
                        break;
                    case "btnDown4":
                        num = 4;
                        break;
                    case "btnDown5":
                        num = 5;
                        break;
                }

                //num = pageNum * 5 + num; // there is a bug here

                string temp = phrases[num+1];
                phrases[num + 1] = phrases[num];
                phrases[num] = temp;
                refreshCalloutList();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void moveItemUp(object sender, EventArgs e)
        {
            try { 
                ALSButton btn = (ALSButton)sender;
                int num = 0;
                switch (btn.Name)
                {
                    case "btnUp0":
                        num = 0;
                        break;
                    case "btnUp1":
                        num = 1;
                        break;
                    case "btnUp2":
                        num = 2;
                        break;
                    case "btnUp3":
                        num = 3;
                        break;
                    case "btnUp4":
                        num = 4;
                        break;
                    case "btnUp5":
                        num = 5;
                        break;
                }

                //num = pageNum * 5 + num; //there is a bug here

                string temp = phrases[num - 1];
                phrases[num - 1] = phrases[num];
                phrases[num] = temp;
                refreshCalloutList();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void deleteItem(object sender, EventArgs e)
        {
            ALSButton btn = (ALSButton)sender;
            int num = 0;
            switch (btn.Name)
            {
                case "btnDel0":
                    num = 0;
                    break;
                case "btnDel1":
                    num = 1;
                    break;
                case "btnDel2":
                    num = 2;
                    break;
                case "btnDel3":
                    num = 3;
                    break;
                case "btnDel4":
                    num = 4;
                    break;
                case "btnDel5":
                    num = 5;
                    break;
            }
            try { 
                phrases.RemoveAt(num);
            }
            catch (ArgumentOutOfRangeException) { }
            refreshCalloutList();
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

        private void Callout_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void flipToPage(int num)
        {
            if (num < 0)
                num = 0;
            else if(phrases.Count / NUM_CALLOUTS< num)
            {
                num = phrases.Count / NUM_CALLOUTS;
            }
            
            pageNum = num;

            for(int i = 0; i < NUM_CALLOUTS; i++)
            {
                try { callouts[0, i].Text = phrases[i + num * NUM_CALLOUTS]; }
                catch (ArgumentOutOfRangeException) { callouts[0, i].Text = ""; }
            }

        }

       

        private void TextToSpeech_Click(object sender, EventArgs e)
        {
            if(isEditMode)
            {
                ac.Show();
                this.Hide();
            }
        }

        private void populateList()
        {

            if (!File.Exists("CalloutPhrases.txt")) {
                generateDefaultFile();
            }

            StreamReader file = new StreamReader(File.Open("CalloutsPhrases.txt", FileMode.Open));

            while (!file.EndOfStream) { 
                phrases.Add(file.ReadLine());
            }

            foreach(string str in phrases)
            {
                Console.WriteLine(str);
            }


        }

        private void generateDefaultFile()
        {
            StreamWriter filestream = new StreamWriter(File.Create("CalloutsPhrases.txt"));
            for(int i =0; i < defaultPhrases.Length; i++) {
                filestream.WriteLine(defaultPhrases[i]);
            }

            filestream.Close();
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
                }
                for (int i = 1; i < callouts.GetLength(0); i++)
                    for (int j = 0; j < callouts.GetLength(1); j++)
                        callouts[i, j].Visible = false;

                topRowButtons[4].Text = "Text to Speech";
            }
        }

        private string[] defaultPhrases =
        {
            "Suction","Wipe my Eyes", "Adjust my head to the left","Adjust my head to the right",
            "Adjust my head up","Adjust my head down","Sit my chair up","Recline my chair"
        };


    }
}