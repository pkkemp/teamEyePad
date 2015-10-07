using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemsPOC
{
    public partial class KeyboardV1 : Form
    {
        public KeyboardV1()
        {
            InitializeComponent();
        }

        public void append(String letter) 
        {
            textBox1.AppendText(letter);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            append("Q");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            append("W");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            append("E");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            append("R");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            append("T");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            append("Y");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            append("U");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            append("I");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            append("O");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            append("P");
        }



        private void button17_Click(object sender, EventArgs e)
        {
            append("L");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            append("H");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            append("J");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            append("K");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            append("G");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            append("S");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            append("D");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            append("F");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            append("A");
        }

        //GBADFEHC
        private void button25_Click(object sender, EventArgs e)
        {
            append("C");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            append("X");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            append(".");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            append("V");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            append("N");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            append("B");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            append("Z");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            append("M");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            append(" ");
        }
    }
}
