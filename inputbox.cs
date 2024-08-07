using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpDemo
{
    public partial class inputbox : Form
    {
        public ANN refTOANNfrmIPBX;
        string[] bitsinp;
        public bool incompleteInput;
        public string inputboxline;
        public inputbox(ANN refTOANNfrmIPBX)
        {
            this.refTOANNfrmIPBX = refTOANNfrmIPBX;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Split(' ').Length == ((11 * refTOANNfrmIPBX.selectedvalue) + (2 * refTOANNfrmIPBX.selectedvalue) + 1 + 1))
            {
                MessageBox.Show("Initial Weights and biases are saved. ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Incomplete input !. ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Split(' ').Length < ((11 * refTOANNfrmIPBX.selectedvalue) + (2 * refTOANNfrmIPBX.selectedvalue) + 1 + 1))
            {
                button1.Enabled = false;
                button1.BackColor = System.Drawing.Color.Transparent;
            }
            char ch = e.KeyChar;
            string t;
            bool contains;

            //8 for backspace.46 for dot

            if (ch == ' ' && (textBox1.Text.EndsWith(" ") || textBox1.Text.EndsWith("."))) { e.Handled = true; }
            if (ch == 46)
            {
                int i = textBox1.Text.TrimEnd().LastIndexOf(' ');//i=5for1 238 7;i=2 for12 3 ie last spacebar not detected..only wen it ids between two numbers
                t = textBox1.Text.Substring(i + 1).TrimEnd();
                contains = t.Contains(".");

                if (contains) { e.Handled = true; }

            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != ' ')
            { e.Handled = true; }
            bitsinp = textBox1.Text.Split(' ');

            if (bitsinp.Length == ((11 * refTOANNfrmIPBX.selectedvalue) + (2 * refTOANNfrmIPBX.selectedvalue) + 1 + 1) && (ch != 8) && (ch != ' '))
            {
                e.Handled = true;
                button1.Enabled = true;
                button1.BackColor = System.Drawing.Color.SteelBlue;
                // string m = "po";  
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Split(' ').Length == ((11 * refTOANNfrmIPBX.selectedvalue) + (2 * refTOANNfrmIPBX.selectedvalue) + 2))
            {
                this.Close();
            }
            else
            {
                DialogResult dR = MessageBox.Show("Incomplete input !.\nDo you want to complete input process? ", "Warning ! ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dR == DialogResult.No)
                {
                    this.Close();
                    incompleteInput = true;
                }


            }
        }

        private void inputbox_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
