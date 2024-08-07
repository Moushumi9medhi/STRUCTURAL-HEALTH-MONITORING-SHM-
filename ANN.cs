
using System;
using System.Linq;
using System.Drawing;
//using System.Drawing.Color;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime;
using System.Runtime.InteropServices;
using PCOConvertStructures;
using PCOConvertDll;
using System.Collections.Generic;
using System.Text;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;
using AForge.Video.DirectShow;
using System.IO;
using AForge.Video;
using System.Threading;
using System.Net;
using NeuralNetworks.Functions;
using NeuralNetworks.Layers;
using NeuralNetworks.Learning;
using NeuralNetworks.Networks;
using NeuralNetworks.Neurons;
using csmatio.io;
using csmatio.types;




namespace CSharpDemo
{
    public partial class ANN : Form
    {
        public Boolean flg;
        public Form1 refToForm1;
        private Button button3;
        consoleuseless1.OnlineTraining ot;
        public int selectedvalue;
        public bool selectcombox = false;
        
        public ANN(Form1 f1)
        {
            this.refToForm1 = f1;
            InitializeComponent();
            ot = new consoleuseless1.OnlineTraining(this);

        }


        private void ANN_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
          toolStripStatusLabel4.Text=refToForm1.dateTimePicker1.Value.ToShortDateString();
          toolStripStatusLabel6.Text = refToForm1.dateTimePicker1.Value.ToShortTimeString();
        }

        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {


        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
      

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        
       

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_2(object sender, EventArgs e)
        {

        }
        
       

        private void button5_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    textBox1.Text = openFileDialog1.FileName;
                    if ((System.IO.Path.GetFileName(openFileDialog1.FileName)) != "moushumi_withtarget.txt")
                    {
                        textBox1.Clear();
                        DialogResult dialog = MessageBox.Show("You have not selected the appropriate training data file!!! ", "Incorrect File Selection ", MessageBoxButtons.RetryCancel);
                        if (dialog == DialogResult.Retry)
                        {

                            button5.PerformClick();

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(textBox1.Text);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Choose a valid  file first.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("The textbox is already  empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem == null) && (comboBox2.SelectedItem == null))
            { this.label6.Show(); this.label8.Show(); }
            else if ((comboBox1.SelectedItem == null) && (comboBox2.SelectedItem != null))
            { this.label6.Show(); this.label8.Hide(); }
            else if ((comboBox2.SelectedItem == null) && (comboBox1.SelectedItem != null))
            { this.label8.Show(); this.label6.Hide(); }
            else
            { this.label6.Hide(); this.label8.Hide(); pictureBox1.Show(); label9.Show(); label10.Show(); label11.Show(); }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show(" Load  a valid  training data file first in the data preparation tab.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                toolStripStatusLabel1.Visible = true;
                toolStripStatusLabel1.Text = "busy";
                button9.Enabled = false;
                toolStripButton1.Enabled = false;
                switch (comboBox2.Text)
                {
                    case "2": selectedvalue = 2;
                        break;
                    case "3": selectedvalue = 3;
                        break;
                    case "4": selectedvalue = 4;
                        break;
                    case "5": selectedvalue = 5;
                        break;
                    case "6": selectedvalue = 6;
                        break;
                    case "7": selectedvalue = 7;
                        break;
                    case "8": selectedvalue = 8;
                        break;
                    case "9": selectedvalue = 9;
                        break;
                    case "10": selectedvalue = 10;
                        break;
                    default: selectedvalue = 4;
                        break;
                }
              
                richTextBox2.Text += "Creating a 11-input," + selectedvalue + "-hidden, 1-output neural network";
                richTextBox2.Text += "\nUsing logistic sigmoid function for input-to-hidden activation";
                richTextBox2.Text += "\nUsing tanh function for hidden-to-output activation";
                richTextBox2.Text += "\nSetting learning rate (eta) = 0.90";
                richTextBox2.Text += "\nSetting momentum (alpha) = 0.04";
                richTextBox2.Text += "\nEntering back-propagation compute-update cycle";
                richTextBox2.Text += "\nStopping when sum absolute error <= 0.01 or maximum number of epoch completed";
                richTextBox2.Show();
                toolStripStatusLabel1.Text = "Network initialized.Training...";
                MessageBox.Show("Training the neural network.This might take a few seconds!");
               
                double[] bstwts = ot.ANNsetup();
                if (bstwts != null)//this is not usually a best way..sometimes program may crash due to this kind of condition..try to make bestweights 0..try to solve this out later
                {
                    richTextBox2.Hide();
                    toolStripStatusLabel1.Text = "Process completed.";
                    MessageBox.Show("Training completed successfully!");
                    
                    richTextBox2.Text += "\n\n\n Best weights and biases found:";
                    richTextBox2.Text += "\nThe " + (11 * selectedvalue) + " input to hidden connection weights are  :\n";
                    for (int wt = 0; wt <= (11 * selectedvalue) - 1; wt++)
                    {
                        richTextBox2.Text += bstwts[wt].ToString("F" + 2) + "   ";
                    }
                    richTextBox2.Text += "\nThe " + selectedvalue + " input biases are  :\n";
                    for (int wt = (11 * selectedvalue); wt <= (11 * selectedvalue) + selectedvalue - 1; wt++)
                    {
                        richTextBox2.Text += bstwts[wt].ToString("F" + 2) + "   ";
                    }
                    richTextBox2.Text += "\nThe " + selectedvalue + " hidden to output connection weights are  :\n";
                    for (int wt = (11 * selectedvalue) + selectedvalue; wt <= (11 * selectedvalue) + (2 * selectedvalue) - 1; wt++)
                    {
                        richTextBox2.Text += bstwts[wt].ToString("F" + 2) + "   ";
                    }
                    richTextBox2.Text += "\nThe single output bias is \n:" + bstwts[(11 * selectedvalue) + (2 * selectedvalue)].ToString("F" + 2);
                    richTextBox2.Show();
                    richTextBox2.Enabled = true;
                    //button4.Enabled = true;
                    button1.Show();
                    label16.Show();
                   

                }
                else
                {
                    richTextBox2.Clear();
                }
                saveToolStripButton.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(richTextBox2.Text)))
            {
                MessageBox.Show("The network has not been trained yet.Press the 'Train' button in Neural Network Preparation tabpage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DialogResult dialog = MessageBox.Show("Do you really want to read new vibrations through PCO?\n If yes then you would be automatically directed to the other page and cannot revert back to this page without giving new vibrations as input.", "CONFIRMATION", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    refToForm1.setflagForcasting = true;

                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click_3(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox2.SelectedIndex == 1)&&(selectcombox == false))
            {
                button8.Hide();
                pictureBox1.Hide();
                label9.Hide(); label10.Hide(); label11.Hide();
                comboBox2.DroppedDown = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Insert(0, "2");
                comboBox2.Items.Insert(1, "3");
                comboBox2.Items.Insert(2, "4");
                comboBox2.Items.Insert(3, "5");
                comboBox2.Items.Insert(4, "6");
                comboBox2.Items.Insert(5, "7");
                comboBox2.Items.Insert(6, "8");
                comboBox2.Items.Insert(7, "9");
                comboBox2.Items.Insert(8, "10");
                selectcombox = true;
            }
            if (comboBox2.Text == "4")
                button8.Show(); pictureBox1.Hide(); label9.Show();
             if(comboBox2.Text == "4(default)")
                button8.Show(); label9.Show();
             if ((comboBox2.Text != "4") && (selectcombox = true))
             {
                 button8.Hide(); pictureBox1.Hide(); label9.Hide();
             }
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you  want to read new vibrations through PCO?\n If yes then you would be automatically directed to the other page and cannot revert back to this page without giving new vibrations as input.", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                refToForm1.setflagForcasting = true;
                string v = comboBox2.Text.ToString();
                string num = System.Text.RegularExpressions.Regex.Match(v, @"\d+").Value;
                refToForm1.comboxANNvalue = Convert.ToInt32(num);
                this.Hide();
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             if (textBox1.Text == "")
            {
                MessageBox.Show(" Load  a valid  training data file first in the data preparation tab.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                toolStripButton1.Enabled = false;
                button9.Enabled = false;
                switch (comboBox2.Text)
                {
                    case "2": selectedvalue = 2;
                        break;
                    case "3": selectedvalue = 3;
                        break;
                    case "4": selectedvalue = 4;
                        break;
                    case "5": selectedvalue = 5;
                        break;
                    case "6": selectedvalue = 6;
                        break;
                    case "7": selectedvalue = 7;
                        break;
                    case "8": selectedvalue = 8;
                        break;
                    case "9": selectedvalue = 9;
                        break;
                    case "10": selectedvalue = 10;
                        break;
                    default: selectedvalue = 4;
                        break;
                }
                richTextBox2.Text += "Creating a 11-input," + selectedvalue + "-hidden, 1-output neural network";
                richTextBox2.Text += "\nUsing logistic sigmoid function for input-to-hidden activation";
                richTextBox2.Text += "\nUsing tanh function for hidden-to-output activation";
                richTextBox2.Text += "\nSetting learning rate (eta) = 0.90";
                richTextBox2.Text += "\nSetting momentum (alpha) = 0.04";
                richTextBox2.Text += "\nEntering back-propagation compute-update cycle";
                richTextBox2.Text += "\nStopping when sum absolute error <= 0.01 or maximum number of epoch completed";
                richTextBox2.Show();
                MessageBox.Show("Training the neural network.This might take a few seconds!");
                double[] bstwts = ot.ANNsetup();
                if (bstwts != null)//this is not usually a best way..sometimes program may crash due to this kind of condition..try to make bestweights 0..try to solve this out later
                {
                    richTextBox2.Hide();
                    MessageBox.Show("Training completed successfully!");
                    richTextBox2.Text += "\n\n\n Best weights and biases found:";
                    richTextBox2.Text += "\nThe " + (11 * selectedvalue) + " input to hidden connection weights are  :\n";
                    for (int wt = 0; wt <= (11 * selectedvalue) - 1; wt++)
                    {
                        richTextBox2.Text += bstwts[wt].ToString("F" + 2) + "   ";
                    }
                    richTextBox2.Text += "\nThe " + selectedvalue + " input biases are  :\n";
                    for (int wt = (11 * selectedvalue); wt <= (11 * selectedvalue) + selectedvalue - 1; wt++)
                    {
                        richTextBox2.Text += bstwts[wt].ToString("F" + 2) + "   ";
                    }
                    richTextBox2.Text += "\nThe " + selectedvalue + " hidden to output connection weights are  :\n";
                    for (int wt = (11 * selectedvalue) + selectedvalue; wt <= (11 * selectedvalue) + (2 * selectedvalue) - 1; wt++)
                    {
                        richTextBox2.Text += bstwts[wt].ToString("F" + 2) + "   ";
                    }
                    richTextBox2.Text += "\nThe single output bias is \n:" + bstwts[(11 * selectedvalue) + (2 * selectedvalue)].ToString("F" + 2);
                    richTextBox2.Show();
                    richTextBox2.Enabled = true;
                    //button4.Enabled = true;
                    button1.Show();
                    label16.Show();
                    saveToolStripButton.Enabled = true;
                   

                }
                else
                {
                    richTextBox2.Clear();
                }
                saveToolStripButton.Enabled = true;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripButton.CheckState = CheckState.Checked;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox2.Text);
            }
            saveToolStripButton.CheckState = CheckState.Unchecked;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDialog1.Document = printDocument1;
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 10;
            int y = 0;
            int charpos=0;
            while (charpos < richTextBox2.Text.Length)
            {
                if (richTextBox2.Text[charpos] == '\n')
                {
                    charpos++;
                    y += 20;
                    x = 10;
                }
                else if (richTextBox2.Text[charpos] == '\r')
                {
                    charpos++;

                }
                else
                {
                    richTextBox2.Select(charpos, 1);
                    e.Graphics.DrawString(richTextBox2.SelectedText, richTextBox2.SelectionFont, new SolidBrush(richTextBox2.SelectionColor), new PointF(x, y));
                    x = x + 8;
                    charpos++;
                }
            }
        }

       
       
        

     
}
}

