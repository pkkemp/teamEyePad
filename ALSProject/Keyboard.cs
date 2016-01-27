using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{

    //this shouldn't be abstract. When drawing a KeyboardControl2, it does not instantiate the child class. It instantiates this class
    //and draws on it according to the child class specifications. It is causing the error for keyboardControl2 design view. 
    //I'm leaving it because it isn't causing a problem and fixing it is a low priority, but for general polish and correct design
    //methodology, this should be fixed in the future
    public abstract class Keyboard : UserControl
    {
        protected TextBox _textBox;
        protected bool _confirmClear = false;
        protected ALSButton[] predictionKeys;
        protected PresagePredictor presage = new PresagePredictor();
        protected ALSKey[,] keyboard;
        protected List<string> predictionWords;

        public Keyboard()
        {
            _textBox = new TextBox();
            _textBox.Font = new Font(_textBox.Font.FontFamily, 24);
            _textBox.Multiline = true;

            Controls.Add(_textBox);

            predictionKeys = new ALSButton[5];
            predictionWords = new List<string>();

            for (int i = 0; i < predictionKeys.Length; i++)
            {
                predictionKeys[i] = new ALSButton();
                this.Controls.Add(predictionKeys[i]);
                predictionKeys[i].btnType = ALSButton.ButtonType.key;
                predictionKeys[i].Click += new System.EventHandler(this.Predictionkey_Click);
            }
            this.Resize += new System.EventHandler(this.Keyboard_Resize);
        }

        public void Predictionkey_Click(object sender, EventArgs e)
        {
            ALSButton key = ((ALSButton)sender);
            if (key.Text.Length == 0)
                return;

            string text = _textBox.Text.Substring(0, _textBox.SelectionStart);
            var match = Regex.Match(text, @"\S+\s*$");

            string newWord;
            int charactersAfterCaret = _textBox.TextLength - _textBox.SelectionStart;

            if (match.Value.Contains(" "))
            {
                if (needsCapitalization())
                    newWord = key.Text.Substring(0, 1).ToUpper() + key.Text.Substring(1);
                else
                    newWord = key.Text;
                _textBox.Text = _textBox.Text.Substring(0, _textBox.SelectionStart) + newWord + " " + _textBox.Text.Substring(_textBox.SelectionStart);
            }
            else
            {
                //Remove typed characters
                int numCharactersToRemove = 0;
                for (int i = 0; i < text.Length; i++)
                    if (text.ToLower()[i].Equals(key.Text.ToLower()[i]))
                        numCharactersToRemove++;
                    else
                        break;
                _textBox.Text = _textBox.Text.Substring(0, _textBox.SelectionStart - numCharactersToRemove) + _textBox.Text.Substring(_textBox.SelectionStart);

                if (needsCapitalization())
                    newWord = key.Text.Substring(0, 1).ToUpper() + key.Text.Substring(1);
                else
                    newWord = key.Text;

                _textBox.Text = text.Substring(0, match.Index) + newWord + " " + _textBox.Text.Substring(_textBox.SelectionStart);
            }
            _textBox.SelectionStart = _textBox.TextLength - charactersAfterCaret + 1;

            ResetPrediction();
            Populate_Predictkeys();
        }

        public void Clear(object sender, EventArgs e)
        {

            if (_confirmClear)
            {
                Parent.Enabled = false;
                ClearTextConfirmation confirm = new ClearTextConfirmation((Form)Parent);
                confirm.Visible = true;
            }
            else
                _textBox.Text = "";
        }

        public void SetText(string text)
        {
            _textBox.Text = text;
        }

        public void SetTextBoxLocation(Point location)
        {
            _textBox.Location = location;
        }

        public void SetTextBoxSize(Size size)
        {
            _textBox.Size = size;
        }

        public void SetSelection(int start, int length)
        {
            _textBox.SelectionStart = start;
            _textBox.SelectionLength = length;
        }

        public void SetTextBoxFocus()
        {
            _textBox.Focus();
        }

        public int GetSelectionStart()
        {
            return _textBox.SelectionStart;
        }

        public string GetText()
        {
            return _textBox.Text;
        }

        public TextBox GetTextBox()
        {
            return _textBox;
        }

        public void HideTextBox()
        {
            _textBox.Hide();
            _textBox.Size = new Size(0, 0);
            Keyboard_Resize(this, null);
        }

        public void setClearConfirmation(bool confirmClear)
        {
            _confirmClear = confirmClear;
        }

        public void FillPredictKeys(object sender, EventArgs e)
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

        public void ResetPrediction()
        {
            predictionWords.Clear();
            presage.reset();

            foreach (ALSButton btn in predictionKeys)
            {
                btn.Text = "";
            }
        }

        public ALSButton[] GetPredictKeys()
        {
            return predictionKeys;
        }

        public void PredictType(string key)
        {
            //boxPredict.tType(key);
        }

        protected void Populate_Predictkeys()
        {
            string lastWord = "";
            string text = _textBox.Text.Substring(0, _textBox.SelectionStart);
            var match = Regex.Match(text, @"[.!?][^.!?]*$");

            if (match.Success)
                lastWord = match.Length > 1 ? text.Substring(match.Index + 1) : "";
            else
                lastWord = text;

            //remove inaplicable words
            match = Regex.Match(text, @"\S*$");
            string lastWord2 = "";
            if (match.Success)
                lastWord2 = text.Substring(match.Index);
            else
                predictionWords.Clear();    //new word
            for (int i = predictionWords.Count - 1; i >= 0; i--)
            {
                string temp = predictionWords.ElementAt(i);
                if (!temp.ToLower().Contains(lastWord2.ToLower()))
                    predictionWords.Remove(temp);
            }

            //Add new applicable words 
            string[] predictions = presage.getPredictions(lastWord);
            foreach (string word in predictions)
                predictionWords.Add(word);

            //Write words to buttons
            for (int i = 0; i < predictionKeys.Length; i++)
            {
                try
                {
                    string word = predictionWords.ElementAt(i);
                    predictionKeys[i].Text = word;
                    predictionKeys[i].setFontSize();
                }
                catch (ArgumentOutOfRangeException)
                {
                    predictionKeys[i].Text = "";
                }
            }
        }

        // This is wrong. If the caret is in the middle of the word, it only deletes the text before the caret, 
        // whereas it should also delete the text after the caret
        protected void DeleteWord(object sender, EventArgs e)
        {
            string text = _textBox.Text.Substring(0, _textBox.SelectionStart);
            var match = Regex.Match(text, @"\s+\S+\s*$");

            if (match.Success)
            {
                _textBox.Text = text.Substring(1, match.Index) + _textBox.Text.Substring(_textBox.SelectionStart);
                _textBox.SelectionStart = text.Length;
            }
            else
            {
                _textBox.Text = _textBox.Text.Substring(_textBox.SelectionStart);
                _textBox.SelectionStart = _textBox.TextLength;
            }
        }

        protected void Backspace(object sender, EventArgs e)
        {
            if (_textBox.Text.Length > 0)
            {
                int selectionStart = _textBox.SelectionStart;
                if (selectionStart == _textBox.Text.Length)
                    _textBox.Text = _textBox.Text.Substring(0, selectionStart - 1);
                else
                    _textBox.Text = _textBox.Text.Substring(0, selectionStart - 1) + _textBox.Text.Substring(selectionStart);

                _textBox.SelectionStart = selectionStart - 1;
            }
        }

        protected void TypeCharacter(object sender, EventArgs e)
        {
            ALSButton button = (ALSButton)sender;
            int selectionStart = _textBox.SelectionStart;


            switch (button.Text)
            {
                case "Space":
                    _textBox.Text = _textBox.Text.Substring(0, selectionStart) + " " + _textBox.Text.Substring(selectionStart);
                    break;
                case "&&":
                    _textBox.Text = _textBox.Text.Substring(0, selectionStart) + "&" + _textBox.Text.Substring(selectionStart);
                    break;
                case ".":
                case "!":
                case "?":
                case ",":
                    string text = _textBox.Text.Substring(0, selectionStart);
                    var match = Regex.Match(text, @"\s*$");
                    _textBox.Text = _textBox.Text.Substring(0, selectionStart) + _textBox.Text.Substring(selectionStart);
                    selectionStart -= match.Length;
                    _textBox.Text = _textBox.Text.Substring(0, selectionStart) + button.Text + _textBox.Text.Substring(selectionStart);
                    ResetPrediction();
                    break;
                default:
                    if (needsCapitalization())
                        _textBox.Text = _textBox.Text.Substring(0, selectionStart) + button.Text.ToUpper() + _textBox.Text.Substring(selectionStart);
                    else
                        _textBox.Text = _textBox.Text.Substring(0, selectionStart) + button.Text + _textBox.Text.Substring(selectionStart);
                    break;
            }
            
            _textBox.SelectionStart = selectionStart + 1;

            this.Populate_Predictkeys();
        }

        public ALSKey[,] GetKeyboard()
        {
            return keyboard;
        }

        private bool needsCapitalization()
        {
            string text = _textBox.Text.Substring(0, _textBox.SelectionStart);
            var match = Regex.Match(text, @"[.!?]\s*$");
            if (match.Success)
                return true;
            match = Regex.Match(text, @"^\s*$");
            if (match.Success)
                return true;
            return false;
        }

        protected abstract void Keyboard_Resize(object sender, EventArgs e);

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Keyboard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Name = "Keyboard";
            this.ResumeLayout(false);

        }
    }
}
