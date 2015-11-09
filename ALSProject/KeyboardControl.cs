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
        private new Form ParentForm;
        private ALSKey[][] keyboard;    // [rows] [columns]
        private Char[,][] keyboards;    // [keyboard#, row#] [column#]
        private ALSButton[][] predictionKeyboard;
        private ALSButton btnShift;
        private ALSButton keySpace;
        public const int GAP = 10;
        private int keyWidth;
        private int keyboardNumber;
        private TextBox txtEntry;
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

            this.Controls.Add(keySpace);
            keySpace.Text = "Space";

        }


        public KeyboardControl(Form parentForm) : this()
        {
            this.ParentForm = parentForm;
        }

        public void setupPreditionBox()
        {
            boxPredict.Location = new Point(keySpace.Location.X - GAP - boxPredict.Width, keySpace.Location.Y);
            this.Controls.Add(boxPredict);
        }

        private void setupLayout()
        {
            int keyHeight = keyWidth;
            int leftOffset = GAP;
            int midOffset = leftOffset + keyWidth / 2;
            int bottomOffset = midOffset + keyWidth + GAP;

            //place the alphanumeric keys

            for (int i = 0; i < keyboard.Length; i++)
                for (int j = 0; j < keyboard[i].Length; j++)
                {
                    switch (i)
                    {
                        case 0:
                            keyboard[i][j].Location = new Point(leftOffset + j * (keyWidth + GAP), GAP);
                            break;
                        case 1:
                            keyboard[i][j].Location = new Point(midOffset + j * (keyWidth + GAP), GAP * 2 + keyHeight);
                            break;
                        case 2:
                            keyboard[i][j].Location = new Point(bottomOffset + j * (keyWidth + GAP), GAP * 3 + 2 * keyHeight);
                            break;
                    }
                    keyboard[i][j].Height = keyHeight;
                    keyboard[i][j].Width = keyWidth;
                }
            //place space bar
            keySpace.Location = new Point(keyboard[2][2].Location.X, GAP * 4 + 3 * keyHeight);
            keySpace.Size = new Size((keyWidth) * 3 + GAP * 2, keySpace.Size.Height);
            keySpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            spacebarLocation = keySpace.Location;

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
        }

        private void setupKeypad()
        {
            for(int j = 0; j <predictionKeyboard.Length; j++) { 
                for(int i = 0; i < predictionKeyboard[0].Length; i++) {  
                    predictionKeyboard[j][i] = new ALSButton();
                    predictionKeyboard[j][i].Location = new Point(400 + (keyWidth+ GAP) * i+GAP, GAP * (5+ j) + (4+ j) * keyWidth);
                    this.Controls.Add(predictionKeyboard[j][i]);
                }
            }

            keyboard[0][10].Text = "Backspace";
            keyboard[1][9].Text = "Delete\nWord";

        }


        private void setupShift()
        {
            btnShift = new ALSButton();
            btnShift.Text = ">";
            btnShift.Location = new Point(GAP, Height - GAP - keyWidth);
            btnShift.Click += new System.EventHandler(this.btnRight_Click);
            this.Controls.Add(btnShift);
        }

        private void setupTextBox()
        {
            txtEntry = new TextBox();
            txtEntry.Location = new Point(400, 400);
            this.Controls.Add(txtEntry);
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

        public void setRemainingVariables()
        {
            keyWidth = (this.Width - 10 * GAP) / 11;

            setupLayout();
            setupLetters();
            //setupShift();
            //setupKeypad();
            setupPreditionBox();
        }

        private void KeyboardControl_Resize(object sender, EventArgs e)
        {
            setRemainingVariables(); //this creates extra shift buttons
        }
    }
}
