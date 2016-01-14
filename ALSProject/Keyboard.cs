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
    public abstract class Keyboard : UserControl
    {
        protected TextBox _textBox;
        protected bool _confirmClear = false;
        protected ALSButton[] predictionKeys;
        protected PresagePredictor presage = new PresagePredictor();
        protected ALSKey[,] keyboard;

        public Keyboard()
        {
            _textBox = new TextBox();
            _textBox.Font = new Font(_textBox.Font.FontFamily, 24);
            _textBox.Multiline = true;

            Controls.Add(_textBox);

            predictionKeys = new ALSButton[5];

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
            //this doesn't really work
            this.DeleteWord(sender, e);
            if (_textBox.TextLength > 1)
                _textBox.Text = _textBox.Text.Substring(0, _textBox.TextLength - 1);
            else
                _textBox.Text = "";
          
            //daniel fix this already, turns out git wasn't even broken

            ALSButton key = ((ALSButton)sender);
            _textBox.Text += (" " + key.Text + " ");
            this.Populate_Predictkeys();

            //come on daniel 16 hours really?

            //WHY ISN'T THIS FIXED BY NOW? DANIEL!?!?

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
        
        protected void DeleteWord(object sender, EventArgs e)
        {
            var match = Regex.Match(_textBox.Text, @"\s+\S+\s*$");

            if (match.Success)
                _textBox.Text = _textBox.Text.Substring(0, match.Index);
            else
                _textBox.Text = "";
        }

        protected void Populate_Predictkeys()
        {
            String lastWord = "";

            var match = Regex.Match(_textBox.Text, @"\p{P}*$");

            if (match.Success)
                lastWord = _textBox.Text.Substring(0, match.Index);
            else
                lastWord = "";

            String[] predictions = presage.getPredictions(lastWord);

            try {
                for (int i = 0; i < predictionKeys.Length; i++)
                {
                    predictionKeys[i].Text = predictions[i];
                }
            }
            catch(IndexOutOfRangeException) { }
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
            if (button.Text.Equals("Space"))
                _textBox.Text = _textBox.Text.Substring(0, selectionStart) + " " + _textBox.Text.Substring(selectionStart);
            else if (button.Text.Equals("&&"))
                _textBox.Text = _textBox.Text.Substring(0, selectionStart) + "&" + _textBox.Text.Substring(selectionStart);
            else
                _textBox.Text = _textBox.Text.Substring(0, selectionStart) + button.Text + _textBox.Text.Substring(selectionStart);

            _textBox.SelectionStart = selectionStart + 1;

            this.Populate_Predictkeys();
        }

        public ALSKey[,] GetKeyboard()
        {
            return keyboard;
        }

        protected abstract void Keyboard_Resize(object sender, EventArgs e);

    }
}
