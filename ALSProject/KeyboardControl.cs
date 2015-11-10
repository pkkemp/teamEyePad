using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using presage;

namespace ALSProject
{
    public partial class KeyboardControl : UserControl
    {
       
        private ALSKey[][] keyboard;    // [rows] [columns]
        private Char[,][] keyboards;    // [keyboard#, row#] [column#]
        private ALSButton[][] predictionKeyboard;
        private ALSButton btnShift;
        private ALSButton keySpace;
        private ALSButton btnClear;
        private int keyWidth;
        private int keyboardNumber;
        public static Point spacebarLocation;
        private PredictionBoxControl boxPredict;

        public KeyboardControl()
        {
            InitializeComponent();

            keyboardNumber = 0;


            boxPredict = new PredictionBoxControl(this);

            keyboard = new ALSKey[3][];
            keyboard[0] = new ALSKey[11];
            keyboard[1] = new ALSKey[10];
            keyboard[2] = new ALSKey[7];
            keySpace = new ALSButton();
            btnClear = new ALSButton();

            predictionKeyboard = new ALSButton[2][];
            predictionKeyboard[0] = new ALSButton[5];
            predictionKeyboard[1] = new ALSButton[5];

            for (int i = 0; i < keyboard.Length; i++)
            {
                for (int j = 0; j < keyboard[i].Length; j++)
                {
                    keyboard[i][j] = new ALSKey();
                    this.Controls.Add(keyboard[i][j]);
                }
            }

            for ( int i =0; i < predictionKeyboard.Length; i++)
            {
                for(int j=0; j < predictionKeyboard[i].Length; j++)
                {
                    predictionKeyboard[i][j] = new ALSButton();
                    this.Controls.Add(predictionKeyboard[i][j]);
                }
            }

            this.Controls.Add(boxPredict);
            this.Controls.Add(keySpace);
            keySpace.Text = "Space";

        }


        public KeyboardControl(Form parentForm) : this()
        {
            this.Parent = parentForm;
        }

        public void setupPreditionBox()
        {
            //boxPredict.Location = new Point(500 , 300);
            boxPredict.updateSize();
            boxPredict.Location = new Point(keySpace.Location.X - UI.GAP - boxPredict.Width, keySpace.Location.Y);

        }

        private void setupLayout()
        {
            int keyHeight = keyWidth;
            int leftOffset = UI.GAP;
            int midOffset = leftOffset + keyWidth / 2;
            int bottomOffset = midOffset + keyWidth + UI.GAP;

            //place the alphanumeric keys

            for (int i = 0; i < keyboard.Length; i++)
                for (int j = 0; j < keyboard[i].Length; j++)
                {
                    switch (i)
                    {
                        case 0:
                            keyboard[i][j].Location = new Point(leftOffset + j * (keyWidth + UI.GAP), UI.GAP);
                            break;
                        case 1:
                            keyboard[i][j].Location = new Point(midOffset + j * (keyWidth + UI.GAP), UI.GAP * 2 + keyHeight);
                            break;
                        case 2:
                            keyboard[i][j].Location = new Point(bottomOffset + j * (keyWidth + UI.GAP), UI.GAP * 3 + 2 * keyHeight);
                            break;
                    }
                    keyboard[i][j].Height = keyHeight;
                    keyboard[i][j].Width = keyWidth;
                }
            //place space bar
            keySpace.Location = new Point(keyboard[2][2].Location.X, UI.GAP * 4 + 3 * keyHeight);
            keySpace.Size = new Size((keyWidth) * 3 + UI.GAP * 2, keySpace.Size.Height);
            keySpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            spacebarLocation = keySpace.Location;

            //clear button
            btnClear.Location = new Point(keyboard[2][6].Location.X + keyWidth + UI.GAP, keyboard[2][6].Location.Y);
            btnClear.Text = "Clear";
            btnClear.Width = 2 * (keyWidth) + UI.GAP;
            btnClear.Height = keyHeight;
            this.Controls.Add(btnClear);

        }

        private void setupLetters()
        {
            keyboards = new Char[3, 3][];
            for (int i = 0; i < 3; i++)
            {
                keyboards[i, 0] = new Char[keyboard[0].Length];
                keyboards[i, 1] = new Char[keyboard[1].Length];
                keyboards[i, 2] = new Char[keyboard[2].Length];
            }

            String[] lowercaseKeyboard = { "qwertyuiop ", "asdfghjkl ", "zxcvbnm" };
            String[] uppercaseKeyboard = { "QWERTYUIOP ", "ASDFGHJKL ", "ZXCVBNM" };
            String[] symbolsKeyboard = { "1234567890 ", "!$()_+;:     ", "\",.?    " };

            for (int i = 0; i < keyboard[0].Length; i++)
            {
                keyboards[0, 0][i] = lowercaseKeyboard[0][i];
                keyboards[1, 0][i] = uppercaseKeyboard[0][i];
                keyboards[2, 0][i] = symbolsKeyboard[0][i];
            }
            for (int i = 0; i < keyboard[1].Length; i++)
            {
                keyboards[0, 1][i] = lowercaseKeyboard[1][i];
                keyboards[1, 1][i] = uppercaseKeyboard[1][i];
                keyboards[2, 1][i] = symbolsKeyboard[1][i];
            }
            for (int i = 0; i < keyboard[2].Length; i++)
            {
                keyboards[0, 2][i] = lowercaseKeyboard[2][i];
                keyboards[1, 2][i] = uppercaseKeyboard[2][i];
                keyboards[2, 2][i] = symbolsKeyboard[2][i];
            }

            fillKeyboard();
        }

        private void fillKeyboard()
        {
            for (int i = 0; i < keyboard.Length; i++)
            {
                for (int j = 0; j < keyboard[i].Length; j++)
                    keyboard[i][j].Text = Convert.ToString(keyboards[keyboardNumber, i][j]);
            }

            keyboard[0][10].Text = "Backspace";
            keyboard[1][9].Text = "Delete\nWord";
        }

        private void setupKeypad()
        {
            try { 
                for (int j = 0; j < predictionKeyboard.Length; j++)
                {
                    for (int i = 0; i < predictionKeyboard[j].Length; i++)
                    {
                        predictionKeyboard[j][i].Size = new Size(keyWidth, keyWidth);

                        predictionKeyboard[j][i].Location = new Point(spacebarLocation.X + ((keyWidth + UI.GAP) * i) + UI.GAP, spacebarLocation.Y + 10 +  (keyWidth +UI.GAP) * (1+j));
                        predictionKeyboard[j][i].Text = ((i+1) + (j * 5)).ToString();
                    }
                }
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Parent unknown\n======\n" + e + "======");
            }
        }

        public string wordPrediction(int num)
        {
            return boxPredict.getTable()[1][num].Text;
        }


        private void setupShift()
        {
            btnShift = new ALSButton();
            btnShift.Text = ">";
            btnShift.Location = new Point(UI.GAP, Height - UI.GAP - keyWidth);
            btnShift.Click += new System.EventHandler(this.btnRight_Click);
            this.Controls.Add(btnShift);
        }
        
        public void predictType(string key)
        {
            boxPredict.predictType(key);
        }

        public void resetPredict()
        {
            boxPredict.resetWord();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            keyboardNumber = (keyboardNumber + 1) % 3;
            fillKeyboard();
        }

        private void KeyboardControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < keyboard.Length; i++)
                foreach (ALSKey button in keyboard[i])
                    button.Show();
        }

        public ALSKey[][] getKeyboard()
        {
            return keyboard;
        }

        public ALSButton getSpace()
        {
            return keySpace;
        }

        public ALSButton getClear()
        {
            return btnClear;
        }

        public ALSButton[][] getKeypad()
        {
            return predictionKeyboard;
        }

        public void setRemainingVariables()
        {
            keyWidth = (this.Width - 10 * UI.GAP) / 11;

            setupLayout();
            setupLetters();
            //setupShift();
            setupKeypad();
            setupPreditionBox();
        }

        private void KeyboardControl_Resize(object sender, EventArgs e)
        {
            setRemainingVariables();
        }
    }
}
