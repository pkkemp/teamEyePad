using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ALSProject
{
    public partial class KeyboardControl2 : UserControl
    {
        private enum KeyboardType
        {
            Lowercase, Uppercase, Characters,
            aTOf, gTOn, nTOs, tTOz,
            ATOF, GTON, NTOS, TTOZ,
            _1TO9, Punctuation, Symbols, Symbols2
        };

        private KeyboardType keyboardType;
        private ALSKey[,] keyboard;
        private ALSButton[] predictionKeys;
        private TextBox textBox;
        private ALSButton keySpace;
        private ALSButton btnClear;
        public static Point spacebarLocation;
        private PresagePredictor presage;
        String buffer;

        public KeyboardControl2()
        {
            InitializeComponent();

            keyboardType = KeyboardType.Lowercase;

            presage = new PresagePredictor();
            keyboard = new ALSKey[15, 10];
            textBox = new TextBox();

            keySpace = new ALSButton();
            btnClear = new ALSButton();
            predictionKeys = new ALSButton[5];
            textBox.Font = new Font(textBox.Font.FontFamily, 24);
            textBox.Multiline = true;

            Controls.Add(textBox);

            for (int i = 0; i < predictionKeys.Length; i++)
            {
                predictionKeys[i] = new ALSButton();
                this.Controls.Add(predictionKeys[i]);
                predictionKeys[i].btnType = ALSButton.ButtonType.key;
            }

            string[,] letters = { { "abc\ndef", "ghi\njkl", "mnop\nqrs", "tuvw\nxyz", ".", "ABC", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "ABC\nDEF", "GHI\nJKL", "MNOP\nQRS", "TUVW\nXYZ", ".", "123", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "0", "1-9", ",!?", "@#$", "[({", "abc", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "a", "b", "c", "d", "e", "f", "", "", "", "Back"},
                                  { "g", "h", "i", "j", "k", "l", "", "", "", "Back"},
                                  { "m", "n", "o", "p", "q", "r", "s", "", "", "Back"},
                                  { "t", "u", "v", "w", "x", "y", "z", "", "", "Back"},
                                  { "A", "B", "C", "D", "E", "F", "", "", "", "Back"},
                                  { "G", "H", "I", "J", "K", "L", "", "", "", "Back"},
                                  { "M", "N", "O", "P", "Q", "R", "S", "", "", "Back"},
                                  { "T", "U", "V", "W", "X", "Y", "Z", "", "", "Back"},
                                  { "1", "2", "3", "4", "5", "6", "7", "8", "9", "Back"},
                                  { ".", "!", "?", ",", ":", ";", "'", "\"", "", "Back"},
                                  { "@", "$", "%", "^", "&&", "*", "+", "-", "=", "Back"},
                                  { "(", ")", "[", "]", "{", "}", "|", "\\", "/", "Back"} };

            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                for (int j = 0; j < keyboard.GetLength(1); j++)
                {
                    keyboard[i, j] = new ALSKey();
                    Controls.Add(keyboard[i, j]);
                    keyboard[i, j].Text = letters[i, j];
                    keyboard[i, j].btnType = ALSButton.ButtonType.key;

                    switch (i)
                    {
                        case 0:
                        case 1:
                            if (j < 4 || j == 5)
                                keyboard[i, j].Click += NavigateKeyboard;
                            else if (j == 4 || j == 6)
                                keyboard[i, j].Click += TypeCharacter;
                            else if (j == 7)
                                keyboard[i, j].Click += Backspace;
                            else if (j == 8)
                                keyboard[i, j].Click += DeleteWord;
                            else if (j == 9)
                                keyboard[i, j].Click += Clear;
                            break;
                        case 2:
                            if (j == 0)
                                keyboard[i, j].Click += TypeCharacter;
                            else if (j >= 1 && j <= 5)
                                keyboard[i, j].Click += NavigateKeyboard;
                            else if (j == 6)
                                keyboard[i, j].Click += TypeCharacter;
                            else if (j == 7)
                                keyboard[i, j].Click += Backspace;
                            else if (j == 8)
                                keyboard[i, j].Click += DeleteWord;
                            else if (j == 9)
                                keyboard[i, j].Click += Clear;
                            break;
                        default:
                            if (j < 9)
                            {
                                keyboard[i, j].Click += TypeCharacter;
                                keyboard[i, j].Click += NavigateKeyboard;
                            }
                            else
                                keyboard[i, j].Click += NavigateKeyboard;
                            break;
                    }
                }
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            textBox.Text = "";
        }

        public void hideTextBox()
        {
            textBox.Hide();
            textBox.Size = new Size(0, 0);
        }

        private void DeleteWord(object sender, EventArgs e)
        {
            var match = Regex.Match(textBox.Text, @"\s+\S+\s*$");

            if (match.Success)
                textBox.Text = textBox.Text.Substring(0, match.Index);
            else
                textBox.Text = "";
        }

        private void Backspace(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                int selectionStart = textBox.SelectionStart;
                if (selectionStart == textBox.Text.Length)
                    textBox.Text = textBox.Text.Substring(0, selectionStart - 1);
                else
                    textBox.Text = textBox.Text.Substring(0, selectionStart- 1) + textBox.Text.Substring(selectionStart);

                textBox.SelectionStart = selectionStart - 1;
            }  
        }

        private void TypeCharacter(object sender, EventArgs e)
        {
            ALSButton button = (ALSButton)sender;
            int selectionStart = textBox.SelectionStart;
            if (button.Text.Equals("Space"))
                textBox.Text = textBox.Text.Substring(0, selectionStart) + " " + textBox.Text.Substring(selectionStart);
            else if (button.Text.Equals("&&"))
                textBox.Text = textBox.Text.Substring(0, selectionStart) + "&" + textBox.Text.Substring(selectionStart);
            else
                textBox.Text = textBox.Text.Substring(0, selectionStart) + button.Text + textBox.Text.Substring(selectionStart);
            
            textBox.SelectionStart = selectionStart + 1;
        }

        private void NavigateKeyboard(object sender, EventArgs e)
        {
            ALSButton button = (ALSButton)sender;
            switch (button.Text)
            {
                case "abc":
                    keyboardType = KeyboardType.Lowercase;
                    break;
                case "ABC":
                    keyboardType = KeyboardType.Uppercase;
                    break;
                case "123":
                    keyboardType = KeyboardType.Characters;
                    break;
                case "abc\ndef":
                    keyboardType = KeyboardType.aTOf;
                    break;
                case "ghi\njkl":
                    keyboardType = KeyboardType.gTOn;
                    break;
                case "mnop\nqrs":
                    keyboardType = KeyboardType.nTOs;
                    break;
                case "tuvw\nxyz":
                    keyboardType = KeyboardType.tTOz;
                    break;
                case "ABC\nDEF":
                    keyboardType = KeyboardType.ATOF;
                    break;
                case "GHI\nJKL":
                    keyboardType = KeyboardType.GTON;
                    break;
                case "MNOP\nQRS":
                    keyboardType = KeyboardType.NTOS;
                    break;
                case "TUVW\nXYZ":
                    keyboardType = KeyboardType.TTOZ;
                    break;
                case "1-9":
                    keyboardType = KeyboardType._1TO9;
                    break;
                case ",!?":
                    keyboardType = KeyboardType.Punctuation;
                    break;
                case "@#$":
                    keyboardType = KeyboardType.Symbols;
                    break;
                case "[({":
                    keyboardType = KeyboardType.Symbols2;
                    break;
                case "Back":
                    int tempKT = (int)keyboardType;
                    if (tempKT >= 3 && tempKT <= 6)
                        keyboardType = KeyboardType.Lowercase;
                    else if (tempKT >= 7 && tempKT <= 10)
                        keyboardType = KeyboardType.Uppercase;
                    else
                        keyboardType = KeyboardType.Characters;
                    break;
                default:
                    if (button.Text.Length > 0)
                    {
                        if (button.Text[0] >= 'a' && button.Text[0] <= 'z')
                            keyboardType = KeyboardType.Lowercase;
                        else if (button.Text[0] >= 'A' && button.Text[0] <= 'Z')
                        {
                            keyboardType = KeyboardType.Uppercase;
                        }
                        else
                        {
                            keyboardType = KeyboardType.Characters;
                        }
                    }
                    break;

            }


            int temp = (int)keyboardType;
            for (int i = 0; i < keyboard.GetLength(1); i++)
                keyboard[(int)keyboardType, i].BringToFront();
        }

        public KeyboardControl2(Form parentForm) : this()
        {
            this.Parent = parentForm;
        }

        //public void setBuffer(string buffer)
        //{
        //    this.buffer = buffer;
        //}

        private void setupKeypad()
        {

        }

        public void fillPredictKeys(object sender, EventArgs e)
        {
            ALSButton btn = ((ALSButton)sender);
            String[] predictions = presage.getPredictions(btn.Text);

            for (int i = 0; i < predictionKeys.GetLength(0); i++)
            {
                try
                {
                    predictionKeys[i].Text = predictions[i];
                }
                catch (IndexOutOfRangeException)
                {
                    predictionKeys[i].Text = "";
                }
            }
        }

        public void resetPrediction()
        {
            presage.reset();

            foreach (ALSButton btn in predictionKeys)
            {
                btn.Text = "";
            }
        }

        public ALSButton[] getPredictKeys()
        {
            return predictionKeys;
        }

        public void predictType(string key)
        {
            //boxPredict.tType(key);
        }

        public ALSKey[,] getKeyboard()
        {
            return keyboard;
        }

        public string GetText()
        {
            return textBox.Text;
        }

        public TextBox getTextBox()
        {
            return textBox;
        }

        public void SetText(string text)
        {
            textBox.Text = text;
        }

        public void SetTextBoxLocation(Point location)
        {
            textBox.Location = location;    //Test this
        }

        public void SetTextBoxSize(Size size)
        {
            textBox.Size = size;
        }

        public void SetSelection(int start, int length)
        {
            textBox.SelectionStart = start;
            textBox.SelectionLength = length;
        }

        public int GetSelectionStart()
        {
            return textBox.SelectionStart;
        }

        public void SetTextBoxFocus()
        {
            textBox.Focus();
        }

        private void KeyboardControl_Resize(object sender, EventArgs e)
        {
            //Set width of text box
            textBox.Size = new Size(this.Width, textBox.Height);

            //Calculate Button Height and Width
            int buttonHeight = (Height - 2 * UI.GAP - textBox.Height) / 3;
            int buttonWidth = (Width - (keyboard.GetLength(1) / 2 - 1) * UI.GAP) / (keyboard.GetLength(1) / 2);

            //Set heights and widths
            foreach (ALSButton button in keyboard)
                button.Size = new Size(buttonWidth, buttonHeight);

            foreach (ALSButton button in predictionKeys)
                // button.Size = new Size(buttonHeight, buttonWidth);
                button.Size = new Size(buttonWidth, buttonHeight);

            //Set button locations
            predictionKeys[0].Location = new Point(0, textBox.Bottom + UI.GAP);

            for (int i = 1; i < predictionKeys.Length; i++)
            {
                predictionKeys[i].Location = new Point(predictionKeys[i - 1].Right + UI.GAP, textBox.Bottom + UI.GAP);
            }

            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                keyboard[i, 0].Location = new Point(0, predictionKeys[0].Bottom + UI.GAP);
                keyboard[i, keyboard.GetLength(1) / 2].Location = new Point(0, keyboard[i, 0].Bottom + UI.GAP);
            }

            for (int i = 0; i < keyboard.GetLength(0); i++)
                for (int j = 1; j < keyboard.GetLength(1) / 2; j++)
                {
                    keyboard[i, j].Location = new Point(keyboard[i, j - 1].Right + UI.GAP, keyboard[i, 0].Location.Y);

                    int row2 = keyboard.GetLength(1) / 2;
                    keyboard[i, row2 + j].Location = new Point(keyboard[i, row2 + j - 1].Right + UI.GAP, keyboard[i, row2].Location.Y);
                }
        }
    }
}
