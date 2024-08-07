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
    public partial class Signal_magnitude_Analysis : Form
    {
        public double standarddeviation, mean, skewness, kurtosis, rms, variance;
        public Form1 reftoform1fromSMA;
        public CSharpDemo.Frequency_Analysis reftoFAfromSMA;
        public double[] yval_arraySMA = new double[1024];
        public int countpdf = 0;
        public double peak;
        public double variancesum = 0,rms_sum=0;
        LinkedList<double> accelerationpdfSMA;//=new LinkedList<double>(); 
        public Signal_magnitude_Analysis(Form1 reftoform1frmSMA,CSharpDemo.Frequency_Analysis reftoFAfrmSMA)
        {
            this.reftoform1fromSMA = reftoform1frmSMA;
            this.reftoFAfromSMA = reftoFAfrmSMA;
           InitializeComponent();
        }

        private void Signal_magnitude_Analysis_Load(object sender, EventArgs e)
        {
            Array.Copy(reftoFAfromSMA.yval_arrayFA, yval_arraySMA, 1024);
            //Array.Copy(reftoform1fromSMA.yval_array, yval_arraySMA, 1024);
            mean = yval_arraySMA.Sum() / yval_arraySMA.Length;
            for(int ivar=0;ivar<1024;ivar++)
            {
                rms_sum+=Math.Pow(yval_arraySMA[ivar],2);
            variancesum +=Math.Pow((yval_arraySMA[ivar]-mean),2);
            }
            rms=Math.Sqrt(rms_sum/1024);
            variance=variancesum/1023;
            standarddeviation = Math.Sqrt(variance);
            //foreach(var item in reftoform1fromSMA.Accelerationpdf )
                accelerationpdfSMA = new LinkedList<double>(reftoform1fromSMA.accelerationpdf); 
            //standard deviation formula
         
            double skewsum = 0;
            double kurtosum = 0;
            for (int i = 0; i < 1024; i++)
            {
                skewsum += Math.Pow((yval_arraySMA[i] - mean), 3);
                kurtosum += Math.Pow((yval_arraySMA[i] - mean), 4);

            }
            skewness = skewsum / (1024 * (Math.Pow(standarddeviation, 3)));
            kurtosis = kurtosum / (1024 * (Math.Pow(standarddeviation, 4)));

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox8.Text = kurtosis.ToString();
                textBox8.Enabled = true;
            }
            else
            {
                textBox8.Text = "";
                textBox8.Enabled = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                textBox7.Text = skewness.ToString();
                textBox7.Enabled = true;
            }
            else
            {
                textBox7.Text = "";
                textBox7.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                textBox6.Text = variance.ToString();
                textBox6.Enabled = true;
            }
            else
            {
                textBox6.Text = "";
                textBox6.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox4.Text = rms.ToString();
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Text = "";
                textBox4.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox5.Text = standarddeviation.ToString();
                textBox5.Enabled = true;
            }
            else
            {
                textBox5.Text = "";
                textBox5.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.Text = mean.ToString();
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Text = "";
                textBox3.Enabled = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            //chart2.ChartAreas["Histogram"].AxisX.ScaleView.ViewMaximum=Math.Floor(AccelerationpdfSMA.Min()+10;
         //   diagram.AxisY.Range.Auto = false;
          //  diagram.AxisY.Range.SetInternalMinMaxValues(1, 12);
           // chart2.ChartAreas["ChartArea1"].AxisX.ScaleView.MinSize = 10;
           // chart2.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 10;
           // chart2.ChartAreas["ChartArea1"].AxisX.Maximum=10;

            for(int x=(int)Math.Floor(accelerationpdfSMA.Min());x<Math.Ceiling(accelerationpdfSMA.Max());x++)
            {
                foreach (var item4 in accelerationpdfSMA)
                {
                    if ((item4 >= x) && (item4 <= x + 1))
                    {
                        countpdf++;
                    }
                }
                chart2.Series["Histogram"].Points.AddXY((x+0.5).ToString("N3")/*sec.ToString("N3")*/, countpdf.ToString());
                countpdf = 0;   
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                chart2.Series["Histogram"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                peak = yval_arraySMA.Max();
                textBox1.Text = peak.ToString();
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
