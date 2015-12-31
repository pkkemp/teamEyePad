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
    public partial class KeyboardControl : Keyboard
    {
       
        private ALSKey[][] keyboard;    // [rows] [columns]
        private Char[,][] keyboards;    // [keyboard#, row#] [column#]
        private ALSButton[] predictionKeys;
        private ALSButton btnShift;
        private ALSButton keySpace;
        private ALSButton btnClear;
        private int keyWidth, keyHeight;
        private int keyboardNumber;
        public static Point spacebarLocation;
        private PresagePredictor presage;
        String buffer;

        //private ALSButton[][] predictionKeyboard;
        //private PredictionBoxControl boxPredict;

        public KeyboardControl()
        {
            InitializeComponent();

            _textBox = new TextBox();
            _textBox.Font = new Font(_textBox.Font.FontFamily, 24);
            _textBox.Multiline = true;
            Controls.Add(_textBox);

            keyboardNumber = 0;

            presage = new PresagePredictor();

            keyboard = new ALSKey[3][];
            keyboard[0] = new ALSKey[11];
            keyboard[1] = new ALSKey[10];
            keyboard[2] = new ALSKey[7];
            keySpace = new ALSButton();
            btnClear = new ALSButton();
            predictionKeys = new ALSButton[6];
            
            /*
            Context is changed to current sentence on space press or word predict press. Context is changed to word completion mode
            when a key is pressed until space key is hit
            */

            //boxPredict = new PredictionBoxControl(this);
            //predictionKeyboard = new ALSButton[2][];
            //predictionKeyboard[0] = new ALSButton[5];
            //predictionKeyboard[1] = new ALSButton[5];

            /*
            for (int i = 0; i < predictionKeyboard.Length; i++)
            {
                for (int j = 0; j < predictionKeyboard[i].Length; j++)
                {
                    predictionKeyboard[i][j] = new ALSButton();
                    this.Controls.Add(predictionKeyboard[i][j]);
                }
            }*/
            
            for (int i = 0; i < keyboard.Length; i++)
            {
                for (int j = 0; j < keyboard[i].Length; j++)
                {
                    keyboard[i][j] = new ALSKey();
                    this.Controls.Add(keyboard[i][j]);
                    keyboard[i][j].Click += new EventHandler(this.fillPredictKeys);
                    keyboard[i][j].btnType = ALSButton.ButtonType.key;
                }
            }

            for( int i = 0; i < predictionKeys.Length; i++)
            {
                predictionKeys[i] = new ALSButton();
                this.Controls.Add(predictionKeys[i]);
            }
            
            //this.Controls.Add(boxPredict);
            this.Controls.Add(keySpace);
            keySpace.Text = "Space";

            btnShift = new ALSButton();
            btnShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(btnShift);
            btnShift.Click += new System.EventHandler(this.btnRight_Click);

            resetPrediction();

        }


        public KeyboardControl(Form parentForm) : this()
        {
            this.Parent = parentForm;

        }

        public void setBuffer(string buffer)
        {
            this.buffer = buffer;
        }

        /*
        public void setupPredictionBox()
        {
            //boxPredict.Location = new Point(500 , 300);
            boxPredict.updateSize();
            boxPredict.Location = new Point(keySpace.Location.X - UI.GAP - boxPredict.Width, keySpace.Location.Y);

        }*/
        
        private void setupLayout()
        {
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
                            keyboard[i][j].Location = new Point(leftOffset + j * (keyWidth + UI.GAP), _textBox.Height +  UI.GAP + keyHeight + UI.GAP);
                            break;
                        case 1:
                            keyboard[i][j].Location = new Point(midOffset + j * (keyWidth + UI.GAP), _textBox.Height + UI.GAP * 2 + 2* keyHeight + UI.GAP);
                            break;
                        case 2:
                            keyboard[i][j].Location = new Point(bottomOffset + j * (keyWidth + UI.GAP), _textBox.Height + UI.GAP * 3 + 3 * keyHeight + UI.GAP);
                            break;
                    }
                    keyboard[i][j].Height = keyHeight;
                    keyboard[i][j].Width = keyWidth;
                }
            //place space bar
            keySpace.Location = new Point(keyboard[2][2].Location.X, UI.GAP * 4 + 4 * keyHeight + UI.GAP);
            keySpace.Size = new Size((keyWidth) * 3 + UI.GAP * 2, keySpace.Size.Height);
            keySpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            spacebarLocation = keySpace.Location;


            //clear button
            btnClear.Location = new Point(keyboard[2][6].Location.X + keyWidth + UI.GAP, keyboard[2][6].Location.Y);
            btnClear.Text = "Clear";
            btnClear.Width = 2 * (keyWidth) + UI.GAP;
            btnClear.Height = keyHeight;
            this.Controls.Add(btnClear);

            //place prediction keys
            int predictionKeySize = (this.Width - predictionKeys.Length * UI.GAP) / predictionKeys.Length;

            for (int i = 0; i < predictionKeys.Length; i++)
            {
                predictionKeys[i].Size = new Size(predictionKeySize, keyHeight);
                predictionKeys[i].Location = new Point(leftOffset + i * (predictionKeySize + UI.GAP), UI.GAP);
                predictionKeys[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

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
            String[] symbolsKeyboard = { "1234567890 ", "!@#$%^&*_ ", "\",.?:;'/    " };

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
            /*try { 
                for (int j = 0; j < predictionKeyboard.Length; j++)
                {
                    for (int i = 0; i < predictionKeyboard[j].Length; i++)
                    {
                        predictionKeyboard[j][i].Size = new Size(keyWidth, keyWidth);

                        predictionKeyboard[j][i].Location = new Point(keySpace.Location.X + ((keyWidth + UI.GAP) * i) + UI.GAP, keySpace.Location.Y + keySpace.Height + UI.GAP + (keyWidth +UI.GAP) * (j));
                        predictionKeyboard[j][i].Text = ((i+1) + (j * 5)).ToString();
                    }
                }
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Parent unknown\n======\n" + e + "======");
            }*/


        }

       /* public string wordPrediction(int num)
        {
          
            return boxPredict.getTable()[1][num].Text;
        }*/

        public void fillPredictKeys(object sender, EventArgs e)
        {
            ALSButton btn = ((ALSButton)sender);
            String[] predictions = presage.getPredictions(buffer+btn.Text);

            for (int i = 0; i < predictionKeys.Length; i++)
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
            buffer = "";
            
            foreach(ALSButton btn in predictionKeys)
            {
                btn.Text = "";
            }
        }

        public ALSButton[] getPredictKeys()
        {
            return predictionKeys;
        }

        private void setupShift()
        {
            btnShift.Text = "ABC";
            btnShift.Location = new Point(UI.GAP, 3 * UI.GAP + 3 * keyWidth + UI.GAP);
            btnShift.Size = new Size((int)(1.5 * keyWidth), keyWidth);
        }
        
        public void predictType(string key)
        {
            //boxPredict.tType(key);
        }
        
        private void btnRight_Click(object sender, EventArgs e)
        {
            keyboardNumber = (keyboardNumber + 1) % 3;
            
            switch (keyboardNumber)
            {
                case 0:
                    btnShift.Text = "ABC";
                    break;
                case 1:
                    btnShift.Text = "123";
                    break;
                case 2:
                    btnShift.Text = "abc";
                    break;
            }

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

       /* public ALSButton[][] getKeypad()
        {
            return predictionKeyboard;
        }*/

        public void setRemainingVariables()
        {
            keyWidth = (this.Width - 10 * UI.GAP) / 11;
            keyHeight = (this.Height - 5 * UI.GAP) / 6;
            setupLayout();
            setupLetters();
            setupShift();
            setupKeypad();
            //setupPredictionBox();
        }

        protected override void Keyboard_Resize(object sender, EventArgs e)
        {
            setRemainingVariables();
        }
    }
}
