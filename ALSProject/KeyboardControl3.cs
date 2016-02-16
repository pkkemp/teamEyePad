using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    //This is the same as User Control 1, but it is written more clearly
    public partial class KeyboardControl3 : Keyboard
    {
        private enum KeyboardType
        {
            Lowercase, Uppercase, Characters
        };
        
        private KeyboardType keyboardType;
        private const string backspace = "Backspace", space = "Space", deleteWord = "Delete\nWord", clear = "Clear";
        
        public KeyboardControl3() : base()
        {
            InitializeComponent();

            keyboardType = KeyboardType.Lowercase;
            
            string[,] characters = { { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "ABC", "z", "x", "c", "v", "b", "n", "m", backspace, space, deleteWord, clear},
                                 { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "123", "Z", "X", "C", "V", "B", "N", "M", backspace, space, deleteWord, clear},
                                 { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$", "%", "^", "&", "*", "_", "abc", "\"", ",", ".", "?", ":", ";", "'", backspace, space, deleteWord, clear} };

            keyboard = new ALSKey[characters.GetLength(0), characters.GetLength(1)];

            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                for (int j = 0; j < keyboard.GetLength(1); j++)
                {
                    keyboard[i, j] = new ALSKey();
                    Controls.Add(keyboard[i, j]);
                    keyboard[i, j].Text = characters[i, j];
                    keyboard[i, j].btnType = ALSButton.ButtonType.key;

                    switch (keyboard[i,j].Text)
                    {
                        case backspace:
                            keyboard[i, j].Click += Backspace;
                            break;
                        case deleteWord:
                            keyboard[i, j].Click += DeleteWord;
                            break;
                        case clear:
                            keyboard[i, j].Click += Clear;
                            break;
                        case "abc":
                        case "ABC":
                        case "123":
                            keyboard[i, j].Click += NavigateKeyboard;
                            break;
                        default:
                            keyboard[i, j].Click += TypeCharacter;
                            break;
                    }
                }
            }
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

            }
            int temp = (int)keyboardType;
            for (int i = 0; i < keyboard.GetLength(1); i++)
                keyboard[(int)keyboardType, i].BringToFront();
        }

        protected override void Keyboard_Resize(object sender, EventArgs e)
        {
            int predictionWidth = (Width - (predictionKeys.Length - 1) * MainMenu.GAP) / predictionKeys.Length;

            int keyHeight = (int)((Height - _textBox.Height - MainMenu.GAP * 5) / 5);


            for (int i = 0; i < predictionKeys.Length; i++)
            {
                predictionKeys[i].Size = new Size(predictionWidth, keyHeight);
                predictionKeys[i].Location = new Point(i * (predictionWidth + MainMenu.GAP), _textBox.Bottom + MainMenu.GAP);

            }
            int keyWidth = (Width - 11 * MainMenu.GAP) / 10;

            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                //Top row
                for (int j = 0; j < 10; j++)   //10 letters on top row
                {
                    keyboard[i, j].Size = new Size(keyWidth, keyHeight);
                    keyboard[i, j].Location = new Point(j * (keyWidth + MainMenu.GAP), predictionKeys[0].Location.Y + predictionKeys[0].Height + MainMenu.GAP);
                }
                //Middle row
                int middleRowOffest = keyWidth / 2;
                for (int j = 10; j < 19; j++)   //9 letters on middle row
                {
                    keyboard[i, j].Size = new Size(keyWidth, keyHeight);
                    keyboard[i, j].Location = new Point((j- 10) * (keyWidth + MainMenu.GAP) + middleRowOffest, keyboard[0, 0].Location.Y + keyboard[0, 0].Height + MainMenu.GAP);
                }
                //Shift
                keyboard[i, 19].Size = new Size((int)(keyWidth * 1.5), keyHeight);
                keyboard[i, 19].Location = new Point(0, keyboard[0, 10].Location.Y + keyboard[0, 10].Height + MainMenu.GAP);
                //Bottom row
                int bottomRowOffest = keyboard[i, 19].Width + MainMenu.GAP;
                for (int j = 20; j < 27; j++)   //7 letters on bottom row
                {
                    keyboard[i, j].Size = new Size(keyWidth, keyHeight);
                    keyboard[i, j].Location = new Point((j - 20) * (keyWidth + MainMenu.GAP) + bottomRowOffest, keyboard[i,19].Location.Y);
                }
                //Backspace
                keyboard[i, 27].Size = new Size(Width - (keyboard[i,26].Right + MainMenu.GAP), keyHeight);
                keyboard[i, 27].Location = new Point(keyboard[i, 26].Right + MainMenu.GAP, keyboard[i, 19].Location.Y);
                //Delete Word
                keyboard[i, 29].Size = new Size(keyboard[i,27].Width, keyHeight);
                keyboard[i, 29].Location = new Point(0, keyboard[i, 26].Bottom + MainMenu.GAP);
                //Clear
                keyboard[i, 30].Size = new Size(keyboard[i, 27].Width, keyHeight);
                keyboard[i, 30].Location = new Point(Width - keyboard[i,30].Width, keyboard[i, 29].Top);
                //Space
                keyboard[i, 28].Size = new Size(keyboard[i,30].Left - keyboard[i,29].Right - MainMenu.GAP * 2, keyHeight);
                keyboard[i, 28].Location = new Point(keyboard[i, 29].Right + MainMenu.GAP, keyboard[i, 29].Top);
            }
        }
    }
}
