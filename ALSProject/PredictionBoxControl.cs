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
    public partial class PredictionBoxControl : UserControl
    {

        Label[][] table;
        private int cellHeight;
        Presage presage;
        public String lastWord { get; private set; } //sooo thissss is how you do this

        public PredictionBoxControl(UserControl parent)
        {
            InitializeComponent();
            this.Parent = parent;
            cellHeight = this.Height / 11+5;
            lastWord = " ";

            setupTable();

                presage = new Presage
                (
                    callback_get_past_stream,
                    callback_get_future_stream,
                    "presage.xml"
                );

        }

        public void setupTable()
        {
            table = new Label[2][];
            table[0] = new Label[11];
            table[1] = new Label[11];

            for(int j = 0; j < table.Length; j++) { 
                for (int i = 0; i < table[0].Length; i++)
                {
                    table[j][i] = new Label();
                    table[j][i].AutoSize = true;
                    table[j][i].Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.Controls.Add(table[j][i]);
                }
            }

            for (int i = 0; i < table[0].Length; i++)
            {
                table[0][i].Text = i.ToString();
                table[0][i].Location = new Point(this.Width / 50, cellHeight * (i));

            }

            for (int i = 0; i < table[1].Length; i++)
            {
                table[1][i].Location = new Point(this.Width / 50 + 40, cellHeight * (i));

            }

            table[0][0].Text = "";
            table[1][0].Text = "";

        }

        public Label[][] getTable()
        {
            return table;
        }

        public void drawTable()
        {

        }

        public void predictType(string key)
        {
            table[0][0].Text += key;
            
            //Console.WriteLine(callback_get_past_stream());
            String[] predictions = presage.predict();

            for(int i = 0; i < predictions.Length; i++)
            {
                table[1][i+1].Text = predictions[i];
            }




        }

        public void resetWord()
        {
            lastWord = table[0][0].Text;
            table[0][0].Text = "";


            String[] predictions = presage.predict();

            for (int i = 0; i < predictions.Length; i++)
            {
                table[1][i + 1].Text = predictions[i];
            }


        }

        public void updateSize()
        {
            this.Size = new Size(KeyboardControl.spacebarLocation.X - UI.GAP * 2, this.Parent.Height - KeyboardControl.spacebarLocation.Y);

        }


        private string callback_get_past_stream()
        {
                return table[0][0].Text;

        }

        private string callback_get_future_stream()
        {
            return "";
        }



    }
}
