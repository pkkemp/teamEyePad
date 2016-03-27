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
    public partial class QwertyKeyboard : Keyboard
    {
        private enum KeyboardType
        {
            Lowercase, Uppercase, Characters,
            aTOi, jTOr, sTOz,
            ATOI, JTOR, STOZ,
            _1TO9, Punctuation, Symbols, Symbols2
        };

        private KeyboardType keyboardType;
        private const string uLetters1 = "ABCDE\nFGHI";
        private const string uLetters2 = "JKLMN\nOPQR";
        private const string uLetters3 = "STUV\nXYZ";
        private const string lLetters1 = "abcde\nfghi";
        private const string lLetters2 = "jklmn\nopqr";
        private const string lLetters3 = "stuv\nwxyz";
        private const string symbols1 = ".!?,:;'\"";
        private const string symbols2 = "@$%^&*+-=;";
        private const string symbols3 = "()[]{}|\\/";

        #region Constructors

        public QwertyKeyboard() : base()
        {
            initialConfiguration();
        }

        public QwertyKeyboard(bool mode) : base(mode)
        {
            browserMode = mode;
            initialConfiguration();
        }

        private void initialConfiguration()
        {
            InitializeComponent();

            keyboardType = KeyboardType.Lowercase;

            string[,] letters = { { lLetters1, lLetters2, lLetters3, "?", ".", "ABC", "Space", "Backspace", "Delete Word", "Clear"},
                                  { uLetters1, uLetters2, uLetters3, "?", ".", "123", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "0", "1-9", symbols1, symbols2, symbols3, "abc", "Space", "Backspace", "Delete Word", "Clear"},
                                  { "a", "b", "c", "d", "e", "f", "g", "h", "i", "Back"},
                                  { "j", "k", "l", "m", "n", "o", "p", "q", "r", "Back"},
                                  { "s", "t", "u", "v", "w", "x", "y", "z", "", "Back"},
                                  { "A", "B", "C", "D", "E", "F", "G", "H", "I", "Back"},
                                  { "J", "K", "L", "M", "N", "O", "P", "Q", "R", "Back"},
                                  { "S", "T", "U", "V", "W", "X", "Y", "Z", "", "Back"},
                                  { "1", "2", "3", "4", "5", "6", "7", "8", "9", "Back"},
                                  { ".", "!", "?", ",", ":", ";", "'", "\"", "", "Back"},
                                  { "@", "$", "%", "^", "&&", "*", "+", "-", "=", "Back"},
                                  { "(", ")", "[", "]", "{", "}", "|", "\\", "/", "Back"} };

            keyboard = new ALSKey[letters.GetLength(0), letters.GetLength(1)];

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
                            if (j < 3 || j == 5)
                                keyboard[i, j].Click += NavigateKeyboard;
                            else if (j == 3 || j == 4 || j == 6)
                                keyboard[i, j].Click += TypeCharacter;
                            else if (j == 7)
                                keyboard[i, j].Click += Backspace;
                            else if (j == 8)
                            {
                                if (!browserMode)
                                    keyboard[i, j].Click += DeleteWord;
                                else
                                {
                                    keyboard[i, j].Enabled = false;
                                    keyboard[i, j].Visible = false;

                                }
                            }
                            else if (j == 9)
                            {
                                if (!browserMode)
                                    keyboard[i, j].Click += Clear;
                                else
                                {
                                    //keyboard[i, j].Location = keyboard[1, 8].Location; //move clear to delete words position
                                }
                            }
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
                            {
                                if (!browserMode)
                                    keyboard[i, j].Click += DeleteWord;
                                else
                                {
                                    keyboard[i, j].Enabled = false;
                                    keyboard[i, j].Visible = false;

                                }
                            }
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

            SetIsBrowser(browserMode);
        }
        #endregion

        #region Public Methods
        public override object Clone()
        {
            return new QwertyKeyboard();
        }
        #endregion

        #region Events
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
                case lLetters1:
                    keyboardType = KeyboardType.aTOi;
                    break;
                case lLetters2:
                    keyboardType = KeyboardType.jTOr;
                    break;
                case lLetters3:
                    keyboardType = KeyboardType.sTOz;
                    break;
                case uLetters1:
                    keyboardType = KeyboardType.ATOI;
                    break;
                case uLetters2:
                    keyboardType = KeyboardType.JTOR;
                    break;
                case uLetters3:
                    keyboardType = KeyboardType.STOZ;
                    break;
                case "1-9":
                    keyboardType = KeyboardType._1TO9;
                    break;
                case symbols1:
                    keyboardType = KeyboardType.Punctuation;
                    break;
                case symbols2:
                    keyboardType = KeyboardType.Symbols;
                    break;
                case symbols3:
                    keyboardType = KeyboardType.Symbols2;
                    break;
                case "Back":
                    switch (keyboardType)
                    {
                        case KeyboardType.aTOi:
                        case KeyboardType.jTOr:
                        case KeyboardType.sTOz:
                            keyboardType = KeyboardType.Lowercase;
                            break;
                        case KeyboardType.ATOI:
                        case KeyboardType.JTOR:
                        case KeyboardType.STOZ:
                            keyboardType = KeyboardType.Uppercase;
                            break;
                        case KeyboardType._1TO9:
                        case KeyboardType.Punctuation:
                        case KeyboardType.Symbols:
                        case KeyboardType.Symbols2:
                            keyboardType = KeyboardType.Characters;
                            break;
                    }
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
            int buttonHeight;
            if (browserMode)
                buttonHeight = (Height - MainMenu.GAP - _textBox.Height) / 2;
            else
                buttonHeight = (Height - 2 * MainMenu.GAP - _textBox.Height) / 3;

            int buttonWidth = (Width - (keyboard.GetLength(1) / 2 - 1) * MainMenu.GAP) / (keyboard.GetLength(1) / 2);

            //Set heights and widths
            foreach (ALSButton button in keyboard)
                button.Size = new Size(buttonWidth, buttonHeight);

            foreach (ALSButton button in predictionKeys)
            {
                if (browserMode)
                    button.Size = new Size(0, 0);
                else
                    button.Size = new Size(buttonWidth, buttonHeight);

            }

            //Set button locations
            predictionKeys[0].Location = new Point(0, _textBox.Bottom + MainMenu.GAP);

            for (int i = 1; i < predictionKeys.Length; i++)
            {
                predictionKeys[i].Location = new Point(predictionKeys[i - 1].Right + MainMenu.GAP, _textBox.Bottom + MainMenu.GAP);
            }

            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                keyboard[i, 0].Location = new Point(0, predictionKeys[0].Bottom + MainMenu.GAP);
                keyboard[i, keyboard.GetLength(1) / 2].Location = new Point(0, keyboard[i, 0].Bottom + MainMenu.GAP);
            }

            for (int i = 0; i < keyboard.GetLength(0); i++)
                for (int j = 1; j < keyboard.GetLength(1) / 2; j++)
                {
                    keyboard[i, j].Location = new Point(keyboard[i, j - 1].Right + MainMenu.GAP, keyboard[i, 0].Location.Y);

                    int row2 = keyboard.GetLength(1) / 2;
                    keyboard[i, row2 + j].Location = new Point(keyboard[i, row2 + j - 1].Right + MainMenu.GAP, keyboard[i, row2].Location.Y);
                }

            SetIsBrowser(browserMode);
        }
        #endregion

        #region Private Methods
        protected override void SetIsBrowser(bool isBrowser)
        {
            if (isBrowser)
            {

                foreach (var key in predictionKeys)
                {
                    key.Visible = false;
                }
                foreach (ALSButton button in keyboard)
                {
                    if (button.Text.Equals("Delete Word"))
                    {
                        button.Enabled = false;
                    }
                }

            }
            else
            {
                foreach (var key in predictionKeys)
                {
                    key.Visible = true;
                }
                foreach (ALSButton button in keyboard)
                {
                    if (button.Text.Equals("Delete Word"))
                    {
                        button.Enabled = true;
                    }
                }

            }
        }
        #endregion
    }
}
