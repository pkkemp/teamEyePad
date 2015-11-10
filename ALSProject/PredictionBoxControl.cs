﻿using System;
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
    public partial class PredictionBoxControl : UserControl
    {

        Label[][] table;
        private int cellHeight;

        public PredictionBoxControl(UserControl parent)
        {
            InitializeComponent();
            this.Parent = parent;
            cellHeight = this.Height / 11+5;

            setupTable();
            drawTable();
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
                table[1][i].Text = "Sample";
                table[1][i].Location = new Point(this.Width / 50 + 40, cellHeight * (i));

            }

        }

        public Label[][] getTable()
        {
            return table;
        }

        public void drawTable()
        {

        }

        public void updateSize()
        {
            this.Size = new Size(KeyboardControl.spacebarLocation.X - UI.GAP * 2, this.Parent.Height - KeyboardControl.spacebarLocation.Y);

        }






    }
}
