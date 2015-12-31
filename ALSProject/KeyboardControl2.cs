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
    public partial class KeyboardControl2 : Keyboard
    {
        private enum KeyboardType
        {
            Lowercase, Uppercase, Characters,
            aTOf, gTOn, nTOs, tTOz,
            ATOF, GTON, NTOS, TTOZ,
            _1TO9, Punctuation, Symbols, Symbols2
        };

        private KeyboardType keyboardType;

        public KeyboardControl2() : base()
        {
            InitializeComponent();

            keyboardType = KeyboardType.Lowercase;

            keyboard = new ALSKey[15, 10];
            
            string[,] letters = { { "abc\ndef", "ghi\njkl", "mnop\nqrs", "tuvw\nxyz", ".", "ABC", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "ABC\nDEF", "GHI\nJKL", "MNOP\nQRS", "TUVW\nXYZ", ".", "123", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "0", "1-9", ",!?,:;'\"", "@$%^&*+-=", "()[]{}|\\/", "abc", "Space", "Backspace", "Delete Word", "Clear"},
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

        public KeyboardControl2(Form parentForm) : this()
        {
            this.Parent = parentForm;
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

        protected override void Keyboard_Resize(object sender, EventArgs e)
        {
            if (keyboard == null)
                return;

            //Calculate Button Height and Width
            int buttonHeight = (Height - 2 * UI.GAP - _textBox.Height) / 3;
            int buttonWidth = (Width - (keyboard.GetLength(1) / 2 - 1) * UI.GAP) / (keyboard.GetLength(1) / 2);

            //Set heights and widths
            foreach (ALSButton button in keyboard)
                button.Size = new Size(buttonWidth, buttonHeight);

            foreach (ALSButton button in predictionKeys)
                // button.Size = new Size(buttonHeight, buttonWidth);
                button.Size = new Size(buttonWidth, buttonHeight);

            //Set button locations
            predictionKeys[0].Location = new Point(0, _textBox.Bottom + UI.GAP);

            for (int i = 1; i < predictionKeys.Length; i++)
            {
                predictionKeys[i].Location = new Point(predictionKeys[i - 1].Right + UI.GAP, _textBox.Bottom + UI.GAP);
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
