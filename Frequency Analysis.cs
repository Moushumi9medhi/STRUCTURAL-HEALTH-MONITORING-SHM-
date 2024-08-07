using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using ZedGraph.Web;

namespace CSharpDemo
{
    public partial class Frequency_Analysis : Form
    {
        public Form1 refToForm1fromFA;
        complex[] complexyval_arrayFA = new complex[1024];
        complex[] fftcoeff = new complex[1024];
        double[] fftcoeff_mag = new double[1024];
        double[] fftcoeff_phase = new double[1024];
        double[] fftcoeff_magmodal = new double[511];
        public double[] yval_arrayFA = new double[1024];
        double[] top10modalfreqmag = new double[5];
        double[] top10modalfreq = new double[5];
        public bool hertznnotbins = false;
       public bool dblsdnnotsnglsd = true;
       public bool radnnotdeg = true;
       public bool ampnnotphase;
        GraphPane pane; 
       // SymbolType st=SymbolType.None;
        public bool FCclick = false;
        LineItem li;
        PointPairList ppl = new PointPairList();
        PointPairList pplsnglsd = new PointPairList();
       
        ListViewItem itm1 = new ListViewItem();
        public Frequency_Analysis(Form1 f2)
        {

            this.refToForm1fromFA = f2;
            InitializeComponent();
            
        }



        private void Frequency_Analysis_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
           /* for (int i = 0; i < 1024; i++)
            {
                yval_arrayFA[i] = refToForm1fromFA.yval_array[i]*refToForm1fromFA.actd;//actual value
            }
            */
            if (refToForm1fromFA.acceleratebuttonpressed == false)
            {
                int tfa1 = 0;
                if (refToForm1fromFA.videosrcplayr == true)
                {

                    if (refToForm1fromFA.extractframefirst == false)
                    {
                        foreach (var item1 in refToForm1fromFA.dispactual)
                        {
                            if (tfa1 < 200)
                            {
                                yval_arrayFA[tfa1] = item1;
                                tfa1++;
                            }
                            if (tfa1 == 200)
                            { break; }

                        }
                        double referenceLevel = (yval_arrayFA.Max() + yval_arrayFA.Min()) / 2.0;
                        for (int i = 0; i < 200; i++)
                        {
                            yval_arrayFA[i] = yval_arrayFA[i] - referenceLevel;
                        }

                        for (int tfa2 = 1; tfa2 <= 4; tfa2++)
                        {
                            for (int tfa3 = 0; tfa3 < 200; tfa3++)
                            {
                                yval_arrayFA[(tfa2 * 200) + tfa3] = yval_arrayFA[tfa3];
                            }
                        }

                        for (int tfa4 = 0; tfa4 < 24; tfa4++)
                        {
                            yval_arrayFA[1000 + tfa4] = yval_arrayFA[tfa4];
                        }

                    }

                    if (refToForm1fromFA.extractframefirst == true)
                    {
                        foreach (var item1 in refToForm1fromFA.dispactual)
                        {
                            if (tfa1 < 1024)
                            {
                                yval_arrayFA[tfa1] = item1;
                                tfa1++;
                            }
                            if (tfa1 == 1024)
                                break;
                        }



                        double referenceLevel = (yval_arrayFA.Max() + yval_arrayFA.Min()) / 2.0;
                        for (int iFA = 0; iFA < 1024; iFA++)
                        {
                            yval_arrayFA[iFA] = yval_arrayFA[iFA] - referenceLevel;
                        }

                    }

                }
                if (refToForm1fromFA.pco == true)
                {
                    int tFA1 = 0;
                    foreach (var item1 in refToForm1fromFA.dispactual)
                    {
                        if (tFA1 < 50)
                        {
                            yval_arrayFA[tFA1] = item1;
                            tFA1++;
                        }
                        if (tFA1 == 50)
                        { break; }

                    }
                    double referenceLevel = (yval_arrayFA.Max() + yval_arrayFA.Min()) / 2.0;
                    for (int iFA = 0; iFA < 50; iFA++)
                    {
                        yval_arrayFA[iFA] = yval_arrayFA[iFA] - referenceLevel;
                    }

                    for (int tFA2 = 1; tFA2 <= 19; tFA2++)
                    {
                        for (int tFA3 = 0; tFA3 < 50; tFA3++)
                        {
                            yval_arrayFA[(tFA2 * 50) + tFA3] = yval_arrayFA[tFA3];
                        }
                    }

                    for (int tFA4 = 0; tFA4 < 24; tFA4++)
                    {
                        yval_arrayFA[1000 + tFA4] = yval_arrayFA[tFA4];
                    }

                }
            }
            else
            {
                if (refToForm1fromFA.videosrcplayr == true)
                {


                    if (refToForm1fromFA.dispactual.Count < 500)/* && ((yvals.Count / (duration / 1000)) < 2)*/
                    {

                        int tFA5 = 0;
                        foreach (var item1 in refToForm1fromFA.dispactual)
                        {
                            yval_arrayFA[tFA5] = item1;
                            tFA5++;

                        }
                        double referenceLevel = (yval_arrayFA.Max() + yval_arrayFA.Min()) / 2.0;
                        for (int i = 0; i < tFA5; i++)
                        {
                            yval_arrayFA[i] = yval_arrayFA[i] - referenceLevel;
                        }



                        for (int tFA6 = 1; tFA6 < (1024 / refToForm1fromFA.dispactual.Count); tFA6++)
                        {
                            for (int tFA7 = 0; tFA7 < refToForm1fromFA.dispactual.Count; tFA7++)
                            {
                                yval_arrayFA[(tFA6 * refToForm1fromFA.dispactual.Count) + tFA7] = yval_arrayFA[tFA7];
                            }
                        }
                        // int t9 = t6 * t7;
                        for (int t8 = 0; t8 < (1024 % refToForm1fromFA.dispactual.Count); t8++)
                        {
                            yval_arrayFA[(refToForm1fromFA.dispactual.Count * (1024 / refToForm1fromFA.dispactual.Count)) + t8] = yval_arrayFA[t8];
                        }

                    }     
                }
                else
                {

                    if (refToForm1fromFA.dispactual.Count < 50)/* && ((yvals.Count / (duration / 1000)) < 2)*/
                    {
                        int tFA5 = 0;
                        foreach (var item1 in refToForm1fromFA.dispactual)
                        {
                            yval_arrayFA[tFA5] = item1;
                            tFA5++;

                        }
                        double referenceLevel = (yval_arrayFA.Max() + yval_arrayFA.Min()) / 2.0;
                        for (int i = 0; i < tFA5; i++)
                        {
                            yval_arrayFA[i] = yval_arrayFA[i] - referenceLevel;
                        }



                        for (int tFA6 = 1; tFA6 < (1024 / refToForm1fromFA.dispactual.Count); tFA6++)
                        {
                            for (int tFA7 = 0; tFA7 < refToForm1fromFA.dispactual.Count; tFA7++)
                            {
                                yval_arrayFA[(tFA6 * refToForm1fromFA.dispactual.Count) + tFA7] = yval_arrayFA[tFA7];
                            }
                        }
                        // int t9 = t6 * t7;
                        for (int tFA8 = 0; tFA8 < (1024 % refToForm1fromFA.dispactual.Count); tFA8++)
                        {
                            yval_arrayFA[(refToForm1fromFA.dispactual.Count * (1024 / refToForm1fromFA.dispactual.Count)) + tFA8] = yval_arrayFA[tFA8];
                        }

                     

                    }
                }//end of else
            }


            pane = zedGraphControl1.GraphPane;
          
          pane.YAxis.MajorGrid.IsVisible = true;
          pane.XAxis.MajorGrid.IsVisible = true;
          pane.XAxis.MinorGrid.IsVisible = true;
          pane.YAxis.MinorGrid.IsVisible = true;
         
          pane.Title.FontSpec.FontColor = System.Drawing.Color.White;
          pane.XAxis.Title.FontSpec.FontColor = System.Drawing.Color.White;
          pane.YAxis.Title.FontSpec.FontColor = System.Drawing.Color.White;
          pane.XAxis.Scale.FontSpec.FontColor = System.Drawing.Color.White;
          pane.YAxis.Scale.FontSpec.FontColor = System.Drawing.Color.White;
          pane.XAxis.MajorGrid.DashOff = 0;
          pane.YAxis.MajorGrid.DashOff = 0;
          pane.XAxis.MajorTic.IsBetweenLabels = true;
          //  pane.XAxis.MinorTic.Size = 0;
          pane.XAxis.MajorTic.IsInside = false;
          pane.XAxis.MajorTic.IsOutside = true;
          pane.Legend.IsVisible = true;
          // Draw the X tics at the labels  
          pane.XAxis.MajorTic.IsBetweenLabels = false;
          pane.Legend.Position = LegendPos.TopFlushLeft;

            //  pane.XAxis.MinorTic.IsCrossOutside= true;
            //pane.XAxis.MinorTic.IsCrossOutside = false;
            // Y AXIS SETTINGS
            /*  myPane.YAxis.Title.Text = "Hours Worked";
              myPane.YAxis.Type = AxisType.Linear;
              myPane.YAxis.Scale.Format = @"00:\0\0";
              myPane.YAxis.Scale.Min = 0;
              myPane.YAxis.Scale.Max = 24;
              myPane.YAxis.Scale.MajorStep = 1;
              myPane.YAxis.MinorTic.Size = 0;*/
          //pane.XAxis.Scale.MajorStep = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            pane.Title.Text = "FFT ";
            pane.XAxis.Title.Text = "Frequency Bins";
            pane.YAxis.Title.Text = "fft mag";

            // Fill the axis background with a gradient
            pane.Fill = new Fill(Color.MidnightBlue, Color.DarkSlateGray,Color.LightGray, 45.0f);
            //  pane.Fill.Color = System.Drawing.Color.MidnightBlue;if dnt want gradient
            pane.Chart.Fill = new Fill(Color.Black, Color.DimGray, 45.0f);//for inner color..change it to some differnt combination
            pane.XAxis.Color = Color.Red; ;
            pane.YAxis.Color = Color.Red;
            //  pane.Chart.Border.IsVisible = false;//or nxt line
            pane.Title.FontSpec.IsBold = true;
            pane.Chart.Border.Color = Color.Red;
            //change the color of tics.labels,titels
            // Enable the Y2 axis display
            //pane.Y2Axis.IsVisible = true;
            //Display the Y axis grid lines
            pane.YAxis.MajorTic.Color = System.Drawing.Color.White;
            pane.XAxis.MajorTic.Color = System.Drawing.Color.White;
            pane.YAxis.MinorTic.Color = System.Drawing.Color.DeepSkyBlue;
            pane.XAxis.MinorTic.Color = System.Drawing.Color.DeepSkyBlue;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.Color = System.Drawing.Color.DeepSkyBlue;
            pane.YAxis.MinorGrid.Color = System.Drawing.Color.DeepSkyBlue;

            pane.YAxis.MajorGrid.Color = System.Drawing.Color.White;
            pane.XAxis.MajorGrid.Color = System.Drawing.Color.White;
            pane.Title.FontSpec.FontColor = System.Drawing.Color.White;
            pane.XAxis.Title.FontSpec.FontColor = System.Drawing.Color.White;
            pane.YAxis.Title.FontSpec.FontColor = System.Drawing.Color.White;
            pane.XAxis.Scale.FontSpec.FontColor = System.Drawing.Color.White;
            pane.YAxis.Scale.FontSpec.FontColor = System.Drawing.Color.White;
            pane.XAxis.MajorGrid.DashOff = 0;
            pane.YAxis.MajorGrid.DashOff = 0;
            //ON ZOOMING AXES VALUES SCALE SHOULD BE SHOWN
            // Add a text box with instructions
            TextObj text = new TextObj("Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse", 0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
            text.FontSpec.StringAlignment = StringAlignment.Near;
            pane.GraphObjList.Add(text);
            // Make sure the Graph gets redrawn
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
              zedGraphControl1.Refresh();//see wats its use

            pane.BarSettings.Type = BarType.Cluster;//i meant column..this is wrong i think so
            pane.BarSettings.ClusterScaleWidth = 0;//not sure abt this


            pane.BarSettings.MinBarGap = 0;
            pane.BarSettings.Base = BarBase.X;
            // Generate a red bar with "Curve 1" in the legend
            //  BarItem myBar = pane.AddBar("Curve 1", nullptr, y, Color.Red);//correct this line 

            //myBar.Bar.Fill = new Fill(Color.Lime, Color.White, Color.Red);
            pane.BarSettings.ClusterScaleWidth = 1;
            pane.BarSettings.MinClusterGap = 0;//verify this line
            //myPane->XAxis->Scale->MinAuto = false;
            //myPane->XAxis->Scale->MaxAuto = false;

            //myPane->XAxis->Scale->Min = 30;
            // pane.BarSettings.ClusterScaleWidth = 1D;

            // X AXIS SETTINGS

            //pane.XAxis.Type = AxisType.;
            //  myPane.XAxis.Scale.Format = "dd-MMM-yy";
            // myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.MajorStep = 1;
            // myPane.XAxis.Scale.Min = new XDate(DateTime.Now.AddDays(-NumberOfBars));
            //myPane.XAxis.Scale.Max = new XDate(DateTime.Now);
            pane.XAxis.MajorTic.IsBetweenLabels = true;
            //  pane.XAxis.MinorTic.Size = 0;
            pane.XAxis.MajorTic.IsInside = false;
            pane.XAxis.MajorTic.IsOutside = true;
            pane.Legend.IsVisible = true;
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toolStripDropDownButton1.Enabled = true;
            //  GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            MasterPane master = zedGraphControl1.MasterPane;
            //  master.Chart.Fill = new Fill(Color.Black, Color.DimGray, 45.0f);
            master.Fill = new Fill(Color.MidnightBlue, Color.DarkSlateGray, 45.0f);
            // Clear out the initial GraphPane
            master.PaneList.Clear();

            // Show the masterpane title
            master.Title.IsVisible = true;
            master.Title.Text = "Double sided frequency analysis(Absolute magnitude,Phase,power)";
           
            // Leave a margin around the masterpane, but only a small gap between panes
            master.Margin.All = 10;
            master.InnerPaneGap = 5;

            // The titles for the individual GraphPanes
            string[] yLabels = { "Absolute magnitude", "Phase", "power" };
            master.Title.FontSpec.FontColor = System.Drawing.Color.White;
            
            ColorSymbolRotator rotator = new ColorSymbolRotator();

            for (int j = 0; j < 3; j++)
            {
                // Create a new graph -- dimensions to be set later by MasterPane Layout
                GraphPane myPaneT = new GraphPane(new Rectangle(10, 10, 10, 10),
                   "",
                   "Number of samples ",
                   yLabels[j]);

                //myPaneT.Fill = new Fill( Color.FromArgb( 230, 230, 255 ) );
                myPaneT.Fill.IsVisible = false;
                myPaneT.Title.FontSpec.FontColor = System.Drawing.Color.White;
                myPaneT.XAxis.Color = System.Drawing.Color.White;
                myPaneT.YAxis.Color = System.Drawing.Color.White;
                // Fill the Chart background
                myPaneT.Chart.Fill = new Fill(Color.Black, Color.DimGray, 45.0f);
                // Set the BaseDimension, so fonts are scale a little bigger
                myPaneT.BaseDimension = 3.0F;

                // Hide the XAxis scale and title
                myPaneT.XAxis.Title.IsVisible = false;
                myPaneT.XAxis.Scale.IsVisible = false;
                // Hide the legend, border, and GraphPane title
                myPaneT.Legend.IsVisible = true;
                myPaneT.Border.IsVisible = true;
                myPaneT.Title.IsVisible = true;
                // Get rid of the tics that are outside the chart rect
                myPaneT.XAxis.MajorTic.IsOutside = false;
                myPaneT.XAxis.MinorTic.IsOutside = false;
                // Show the X grids
                myPaneT.XAxis.MajorGrid.IsVisible = true;
                myPaneT.XAxis.MinorGrid.IsVisible = true;
                // Remove all margins
                myPaneT.Margin.All = 0;
                // Except, leave some top margin on the first GraphPane
                if (j == 0)
                    myPaneT.Margin.Top = 20;
                // And some bottom margin on the last GraphPane
                // Also, show the X title and scale on the last GraphPane only
                if (j == 2)
                {
                    myPaneT.XAxis.Title.IsVisible = true;
                    myPaneT.XAxis.Scale.IsVisible = true;
                    myPaneT.Margin.Bottom = 10;
                }

                if (j > 0)
                    myPaneT.YAxis.Scale.IsSkipLastLabel = true;

                // This sets the minimum amount of space for the left and right side, respectively
                // The reason for this is so that the ChartRect's all end up being the same size.
                myPaneT.YAxis.MinSpace = 80;
                myPaneT.Y2Axis.MinSpace = 20;

                // Make up some data arrays based on the Sine function
                PointPairList list = new PointPairList();
                for (int i = 0; i < 36; i++)
                {
                    double x = (double)i + 5 + j * 3;
                    double y = (j + 1) * (j + 1) * 10 *
                          (1.5 + Math.Sin((double)i * 0.2 + (double)j));
                    list.Add(x, y);
                }

                // Create a curve
                LineItem myCurve = myPaneT.AddCurve("Type " + j.ToString(),
                   list, rotator.NextColor, rotator.NextSymbol);
                // Fill the curve symbols with white
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Add the GraphPane to the MasterPane.PaneList
                master.Add(myPaneT);
            }

            using (Graphics g = this.CreateGraphics())
            {
                // Align the GraphPanes vertically
                master.SetLayout(g, PaneLayout.SingleColumn);
                master.AxisChange(g);
            }
           

        }

        private void button6_Click(object sender, EventArgs e)
        {

            MasterPane myMaster = zedGraphControl1.MasterPane;
            myMaster.PaneList.Clear();
            myMaster.Title.IsVisible = true;
            // Fill the pane background with a color gradient
            myMaster.Fill = new Fill(Color.White, Color.MediumSlateBlue, 45.0F);
            // Set the margins and the space between panes 
            myMaster.Margin.All = 0;
            myMaster.InnerPaneGap = 0;
            for (int j = 0; j < 2; j++)
            {
                // Create a new GraphPane
                GraphPane myPane = new GraphPane();
                Graphics g = CreateGraphics();
                myPane.XAxis.MajorGrid.IsVisible = true;
                myPane.YAxis.MajorGrid.IsVisible = true;
                // Fill the pane background with a color gradient
                myPane.Fill = new Fill(Color.White, Color.LightYellow, 45.0F);
                if (j == 0)//alingn Y axes of both charts
                {
                    //Change the base dimension to compensate for SetLayout()below
                    myPane.BaseDimension = 6F;
                }
                if (j == 1)//alingn Y axes of both charts
                {
                    //Change the base to twice as above because 
                    //SetLayout()below doubles the  size of the second graph
                    myPane.BaseDimension = 12F;
                }
                // Make up some data arrays based on the Sine function
                PointPairList list = new PointPairList();
                for (int i = 0; i < 50; i++)
                {
                    double x = (double)i + 5;
                    double y = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                    list.Add(x, y);
                }
                // Generate a red curve 
                LineItem myCurve = myPane.AddCurve("label" + j.ToString(), list, Color.Red, SymbolType.None);
                // Add the new GraphPane to the MasterPane
                myMaster.Add(myPane);
            }
            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = CreateGraphics())
            {
                //Setlayout is used here to show the second graph twice as large as  
                //the first one and to stack one chart over the other
                myMaster.SetLayout(g, true, new int[] { 1, 1 }, new float[] { 1f, 2f, });
                zedGraphControl1.AxisChange();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*  PlotClass PlotResult = new PlotClass();
              PlotResult.FFTPlot(zedGraphControl1);*/
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "FREQUENCY ANALYSIS":
                   for (int i = 0; i < 1024; i++)
                    {
                        complexyval_arrayFA[i] = new complex(yval_arrayFA[i], 0);

                    }

                    fftcoeff = Fourier.FFT(complexyval_arrayFA);
                    for (int i = 0; i < 1024; i++)
                    {
                        fftcoeff_mag[i] = fftcoeff[i].magnitude;
                        fftcoeff_phase[i] = fftcoeff[i].phase;
                    }
                    // Fill the axis background with a gradient
                    pane.Fill = new Fill(Color.MidnightBlue, Color.DarkSlateGray, 45.0f);
                    //  pane.Fill.Color = System.Drawing.Color.MidnightBlue;if dnt want gradient
                    pane.Chart.Fill = new Fill(Color.Black, Color.DimGray, 45.0f);//for inner color..change it to some differnt combination
                    pane.XAxis.Color = Color.Red; ;
                    pane.YAxis.Color = Color.Red;
                    //  pane.Chart.Border.IsVisible = false;//or nxt line
                    pane.Title.FontSpec.IsBold = true;
                    pane.Chart.Border.Color = Color.Red;
                    //change the color of tics.labels,titels
                    // Enable the Y2 axis display
                    //pane.Y2Axis.IsVisible = true;
                    //Display the Y axis grid lines
                    pane.YAxis.MajorTic.Color = System.Drawing.Color.White;
                    pane.XAxis.MajorTic.Color = System.Drawing.Color.White;
                    pane.YAxis.MinorTic.Color = System.Drawing.Color.DeepSkyBlue;
                    pane.XAxis.MinorTic.Color = System.Drawing.Color.DeepSkyBlue;
                    pane.XAxis.MinorGrid.Color = System.Drawing.Color.DeepSkyBlue;
                    pane.YAxis.MinorGrid.Color = System.Drawing.Color.DeepSkyBlue;
                    pane.YAxis.MajorGrid.Color = System.Drawing.Color.White;
                    pane.XAxis.MajorGrid.Color = System.Drawing.Color.White;


                    //ON ZOOMING AXES VALUES SCALE SHOULD BE SHOWN

                   

                  //  toolStripDropDownButton1.Enabled = true;

                    break;
                case "Double-sided":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                    radioButton2.Checked = false;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                    button16.Enabled=false;  button11.Enabled=false;
                    break;
                case "Single-sided":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                    radioButton2.Checked = false;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                    break;
                case "Bins":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
              radioButton1.Checked = true;
                    radioButton2.Checked = false;
                   radioButton4.Checked = false;
                    radioButton3.Checked = false;
                     button16.Enabled=true;  button11.Enabled=true;
                    button16.Show();
                    button11.Hide();
                    
                   // ampnnotphase = true;
                    zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            ppl.Clear();
            pane.Title.Text = "Double-sided magnitude Spectrum(mag vs bins) ";
            pane.XAxis.Title.Text = "Frequency(Bins)";
            pane.YAxis.Title.Text = "Magnitude";
                   
         
            
          
                     // X AXIS SETTINGS

            //pane.XAxis.Type = AxisType.;
            //  myPane.XAxis.Scale.Format = "dd-MMM-yy";
            // myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
          
            // myPane.XAxis.Scale.Min = new XDate(DateTime.Now.AddDays(-NumberOfBars));
            //myPane.XAxis.Scale.Max = new XDate(DateTime.Now);
          
                        // Declare a LineItem:- LineItem is used for creating a line       
                        
                         // Set the XAxis labels  
                     //   pane.XAxis.Scale.TextLabels = x0;
            /*
Just manually control the X axis range so it scrolls continuously
// instead of discrete step-sized jumps
myPane.XAxis.Scale.Min = 0;
myPane.XAxis.Scale.Max = 30;
myPane.XAxis.Scale.MinorStep = 1;
myPane.XAxis.Scale.MajorStep = 5;

// Scale the axes
zedGraphControl1.AxisChange();
*/
                         
                          
         
                for (int i=0; i< 1024; i++)
                {
                    ppl.Add(i,fftcoeff_mag[i]);
                }
                toolStripDropDownButton1.Enabled = true;
              li = pane.AddCurve("magnitude", ppl, Color.Cyan,SymbolType.None);
            //  toolStripDropDownButton1.Enabled = false;
             //================================
             /*LineItem trendLine = new LineItem(String.Empty, new[] { pstartDate, pconfirmDate },   new[] { pstartPrice, pconfirmPrice }, System.Drawing.Color.Black, SymbolType.None);
 trendLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;
 trendLine.Line.Width = 1f;
 pricePane.CurveList.Add(trendLine);*/
             //=============================

             // Make sure the Y axis is rescaled to accommodate actual data
             zedGraphControl1.AxisChange();
             // Force a redraw
             zedGraphControl1.Invalidate();
             zedGraphControl1.Refresh();
             groupBox1.Enabled = true;
            
              // li.Symbol.IsVisible = false;
             /* curve.Line.Width = 2.0F;
curve.Line.IsAntiAlias = true;
curve.Symbol.Fill = new Fill( Color.White );
curve.Symbol.Size = 7;*/
      //   zg1.AxisChange();
        // zg1.Refresh();

                       
              /*   chart6.Series["Amplitudes"].Points.AddXY(i, fre[i]);

                 if (fre[i] < avfre)
                 {
                     chart2.Series["Safe"].Color = Color.Green;
                     chart2.Series["Safe"].Points.AddXY
                      (i, fre[i]);
                 }

                 else
                 {
                     chart2.Series["Unsafe"].Color = Color.Red;
                     chart2.Series["Unsafe"].Points.AddXY
                     (i, fre[i]);
                 }
             }*/
                    break;

                case "Hertz":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                    zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            ppl.Clear();
                    for (int i = 0; i <= 512; i++)
                    {
                        ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_mag[i]);
                    }
                    for (int i = 512; i < 1024; i++)
                    {
                        ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_mag[i]);
                    }
                    pane.Title.Text = "Double-sided Amplitude Spectrum(Amplitude vs Hz) ";
                    pane.YAxis.Title.Text = "Magnitude";
                    pane.XAxis.Title.Text = "Frequency(Hz)";
                    li = pane.AddCurve("magnitude", ppl, Color.Cyan, SymbolType.None);
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                    zedGraphControl1.Refresh();
                    break;


                case "Radians-Bins":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                    radioButton4.Checked = true;
                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                    radioButton3.Checked = false; 
                    button16.Enabled=false;  button11.Enabled=false;
                    //groupBox4.Enabled = true;
                   // ampnnotphase = false;
                     zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            ppl.Clear();
                        pane.Title.Text = "Double-sided Phase spectrum(rad vs bins) ";
            pane.XAxis.Title.Text = "Frequency(Bins)";
            pane.YAxis.Title.Text = "Phase(radian)";
            for (int i=0; i< 1024; i++)
                {
                    ppl.Add(i,fftcoeff_phase[i]);
                }
                toolStripDropDownButton1.Enabled = true;

                li = pane.AddCurve("Phase(rad)", ppl, Color.Lime, SymbolType.None);
              // Make sure the Y axis is rescaled to accommodate actual data
              zedGraphControl1.AxisChange();
              // Force a redraw
              zedGraphControl1.Invalidate();
              zedGraphControl1.Refresh();
            
                    break;


                case "Radians-Hertz":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                     radioButton4.Checked = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                    zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            ppl.Clear();
                 for (int i = 0; i <= 512; i++)
                    {
                        ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i] );
                    }
                    for (int i = 512; i < 1024; i++)
                    {
                        ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                    }
                     pane.Title.Text = "Double-sided Phase Spectrum(rad vs Hz) ";
                    pane.YAxis.Title.Text = "Phase(radians)";
                    pane.XAxis.Title.Text = "Frequency(Hz)";
                    li = pane.AddCurve("Phase(rad)", ppl, Color.Lime, SymbolType.None);
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                    zedGraphControl1.Refresh();
                    break;


                case "Degree-Bins":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                     radioButton3.Checked = true;
                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                    radioButton4.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                     zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            ppl.Clear();

                    for (int i = 0; i < 1024; i++)
                    {
                        ppl.Add(i, fftcoeff_phase[i] * (180.0 / 3.14));
                    }
                    pane.Title.Text = "Double-sided Phase Spectrum(deg vs Bins) ";
                    pane.YAxis.Title.Text = "Phase(degree)";
                    pane.XAxis.Title.Text = "Frequency(Bins)";
                    li = pane.AddCurve("Phase(deg)", ppl, Color.Lime, SymbolType.None);
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                    zedGraphControl1.Refresh();
                    break;

                case "Degree-Hertz":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                     radioButton3.Checked = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton4.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                     zedGraphControl1.GraphPane.CurveList.Clear();
                    zedGraphControl1.GraphPane.GraphObjList.Clear();
                    ppl.Clear();
                  
                    for (int i = 0; i <= 512; i++)
                    {
                        ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i] * (180.0 / 3.14));
                    }
                    for (int i = 512; i < 1024; i++)
                    {
                        ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i] * (180.0 / 3.14));
                    }
                    li = pane.AddCurve("Phase(deg)", ppl, Color.Lime, SymbolType.None);
                    pane.Title.Text = "Double-sided Phase Spectrum(deg vs Hz) ";
                    pane.YAxis.Title.Text = "Phase(degree)";
                    pane.XAxis.Title.Text = "Frequency(Hz)";
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();
                    zedGraphControl1.Refresh();
                    break;

                case "Absolute Magnitude":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                     radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
            li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();

               for (int i = 0; i <=512; i++)
                {
                    ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * (500 / refToForm1fromFA.n1)));//N point FFT...I ASSUME IT IS 2...CONFIRM IT... 1024 IS LENGTH OF INPUT SIGNAL
                }
                for (int i = 512; i < 1024; i++)
                {
                    ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * (500 / refToForm1fromFA.n1)));
                }

            
                pane.Title.Text = "Double-sided Power Spectral Density(mag vs Hz)";
                pane.YAxis.Title.Text = "Power";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("power", ppl, Color.Yellow, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

                break;

              
                case "Periodogram":
                    radioButton6.Checked = true;
                    radioButton5.Checked = false;
                     radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                    button16.Enabled=false;  button11.Enabled=false;
                      li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();

            for (int i = 0; i <= 512; i++)
            {
                ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, 10 * Math.Log10(Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * (500 / refToForm1fromFA.n1))));
            }
            for (int i = 512; i < 1024; i++)
            {
                ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, 10 * Math.Log10(Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * (500 / refToForm1fromFA.n1))));
            }
            pane.Title.Text = "Double-sided Power Spectral Density ";
            pane.YAxis.Title.Text = "PSD(dB/Hz)";
            pane.XAxis.Title.Text = "Frequency(Hz)";
            li = pane.AddCurve("PSD(dB/Hz)", ppl, Color.Yellow, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
            break;

                case "bins":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                
               radioButton1.Checked = true;
                    radioButton2.Checked = false;
                   radioButton4.Checked = false;
                    radioButton3.Checked = false;
                    button16.Enabled=true;  button11.Enabled=true;
                    button11.Show();
                    button16.Hide();
              
                    li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
                     pane.Title.Text = "Single-sided magnitude Spectrum (mag vs Bins)";
                    for (int i = 0; i <=512; i++)
                    {
                        pplsnglsd.Add(i, fftcoeff_mag[i]);
                    }
                    li = pane.AddCurve("magnitude", pplsnglsd, Color.Cyan, SymbolType.None);
               pane.YAxis.Title.Text = "Amplitude";
                pane.XAxis.Title.Text = "Frequency(bins)";
                toolStripDropDownButton1.Enabled = true;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;

                case "hertz":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                     radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();
                pane.Title.Text = "Single-sided magnitude Spectrum (mag vs Hz)";
                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_mag[i]);
                }
                li = pane.AddCurve("magnitude", pplsnglsd, Color.Cyan, SymbolType.None);
                pane.YAxis.Title.Text = "Amplitude";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                toolStripDropDownButton1.Enabled = true;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;

                case "radians-bins":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                    radioButton4.Checked = true;
                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();
                pane.Title.Text = "Single-sided Phase Spectrum (rad vs bins)";
                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i , fftcoeff_phase[i]);
                }
                li = pane.AddCurve("phase(rad)", pplsnglsd, Color.Lime, SymbolType.None);
                pane.YAxis.Title.Text = "Phase(rad)";
                pane.XAxis.Title.Text = "Frequency(bins)";
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;

               

              case "radians-hertz":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                     radioButton4.Checked = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                    li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();
                     button16.Enabled=false;  button11.Enabled=false;
             for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                }
              pane.Title.Text = "Single-sided Phase Spectrum(rad vs Hz) ";
                pane.YAxis.Title.Text = "Phase(rad)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("Phase(rad)", pplsnglsd, Color.Lime, SymbolType.None);
                     zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;

              case "degree-bins":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                     radioButton3.Checked = true;
                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                    radioButton4.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();
                
                     for (int i = 0; i <=512; i++)
                {
                    pplsnglsd.Add(i, fftcoeff_phase[i] * (180.0 / 3.14));
                }
                pane.Title.Text = "Single-sided Phase Spectrum(deg vs Bins) ";
                pane.YAxis.Title.Text = "Phase(degree)";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("Phase(deg)", pplsnglsd, Color.Lime, SymbolType.None);
               zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;

              case "degree-hertz":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                     radioButton3.Checked = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton4.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();

                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i] * (180.0 / 3.14));
                }
                pane.Title.Text = "Single-sided Phase Spectrum(deg vs Hz) ";
                pane.YAxis.Title.Text = "Phase(degree)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("Phase(deg)", pplsnglsd, Color.Lime, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;


              case "absolute magnitude":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                     radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                    radioButton3.Checked = false;
                     button16.Enabled=false;  button11.Enabled=false;
                li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();

                
                    for (int i = 0; i <=512; i++)
                {
                     pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * 2));//N point FFT...I ASSUME IT IS 2...CONFIRM IT... 1024 IS LENGTH OF INPUT SIGNAL
                }
                

            
                pane.YAxis.Title.Text = "Power";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                pane.Title.Text = "Single-sided power Spectrum(amp vs Hz) ";
                 li = pane.AddCurve("Power(mag)", pplsnglsd, Color.Yellow, SymbolType.None);//aqua
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;


              case "periodogram":
                    radioButton5.Checked = true;
                    radioButton6.Checked = false;
                radioButton2.Checked = true;
                radioButton1.Checked = false;
                radioButton4.Checked = false;
                radioButton3.Checked = false;
                button16.Enabled = false; button11.Enabled = false;
                li.Clear(); ppl.Clear(); pplsnglsd.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.GraphObjList.Clear();

                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, 10 * Math.Log10(Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * (500 / refToForm1fromFA.n1))));//N point FFT...I ASSUME IT IS 2...CONFIRM IT... 1024 IS LENGTH OF INPUT SIGNAL
               
                }
                
                pane.Title.Text = "Single-sided Power Spectral Density ";
                pane.YAxis.Title.Text = "PSD(dB/Hz)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("PSD(dB/Hz)", pplsnglsd, Color.Yellow, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                break;

               
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           /*   foreach (double val in y_vals)
            {
                TextObj text = new TextObj(val.ToString(), zg1.MasterPane[0].XAxis.Scale.Min, val);
                text.Location.AlignH = AlignH.Right;
                text.FontSpec.Border.IsVisible = false;
                text.FontSpec.Fill.IsVisible = false;
                zg1.MasterPane[0].GraphObjList.Add(text); 
            }*/
           // make it Show only only mouse hover..search for some codes
            /* // Loop to add text labels to the points
    for ( int i = 0; i < count; i++ )
    {
        // Get the pointpair
        PointPair pt = curve.Points[i];

        // Create a text label from the Y data value
        TextObj text = new TextObj( pt.Y.ToString( "f2" ), pt.X, pt.Y + offset,
            CoordType.AxisXYScale, AlignH.Left, AlignV.Center );
        text.ZOrder = ZOrder.A_InFront;
        // Hide the border and the fill
        text.FontSpec.Border.IsVisible = false;
        text.FontSpec.Fill.IsVisible = false;
        //text.FontSpec.Fill = new Fill( Color.FromArgb( 100, Color.White ) );
        // Rotate the text to 90 degrees
        text.FontSpec.Angle = 90;

        myPane.GraphObjList.Add( text );
    }

    // Leave some extra space on top for the labels to fit within the chart rect
    myPane.YAxis.Scale.MaxGrace = 0.2;

    // Calculate the Axis Scale Ranges
    zgc.AxisChange();
}*/


              zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();


         /*       TextObj text = new TextObj("Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse", 0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
                text.FontSpec.StringAlignment = StringAlignment.Near;
                pane.GraphObjList.Add(text);

                foreach (double val in y_vals)
            {
                //TextObj text = new TextObj(val.ToString(), zg1.MasterPane[0].XAxis.Scale.Min, val);
                text.Location.AlignH = AlignH.Right;
                text.FontSpec.Border.IsVisible = false;
                text.FontSpec.Fill.IsVisible = false;
                zg1.MasterPane[0].GraphObjList.Add(text); 
            }


                
    pane.Chart.Rect = new RectangleF(10, 10, 500, 200);
    TextObj testObj = new TextObj("X Axis Additional Text", 0.6, -0.3);
    pane.GraphObjList.Add(testObj);
    zedGraphControl1.Refresh();


                ZedGraph.TextObj text = new ZedGraph.TextObj("Hello", xloc, yloc);

text.IsClippedToChartRect = true;*/
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.Star);
           // li.Symbol.Fill.Color = System.Drawing.Color.Red;
            //li.Symbol.Fill.IsVisible = true;
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.Diamond);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.Circle);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.Plus);
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.Square);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.Triangle);
           
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.TriangleDown);
            
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.HDash);
            
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            li = pane.AddCurve("magnitude", ppl, Color.Yellow, SymbolType.VDash); 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("hii");
           

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Array.Copy(fftcoeff_mag,1, fftcoeff_magmodal,0 ,511);
           Array.Sort(fftcoeff_magmodal);
            top10modalfreqmag = fftcoeff_magmodal.Reverse().Take(5).ToArray();
            for (int i = 0; i < 5; i++)
            {
                for (int  j= 1; j < 512; j++)
                {
                    if (top10modalfreqmag[i]==fftcoeff_mag[j])
                    {
                        top10modalfreq[i] = j * (500 / refToForm1fromFA.n1) / 1024.0;
                    }
                }
            }

            if (toolStripComboBox1.Text == "3")
            {

              zedGraphControl1.GraphPane.GraphObjList.Clear();
            // TextObj textEquation = new TextObj("Add your Text", pane.XAxis.Scale.Min+ (3*(pane.XAxis.Scale.MinorStep)), pane.YAxis.Scale.Max-pane.YAxis.Scale.MinorStep);            
              TextObj text = new TextObj("Modal Frequencies\n1. " + top10modalfreq[0] + " Hz\n2. " + top10modalfreq[1] + " Hz\n3. " + top10modalfreq[2]+" Hz", 0.98f, 0.03f, CoordType.ChartFraction, AlignH.Right, AlignV.Top);
                text.FontSpec.StringAlignment = StringAlignment.Near;
                pane.GraphObjList.Add(text);
                text.IsClippedToChartRect = true;
             text.FontSpec.Border.IsVisible = false; // Disable the border
                text.FontSpec.Fill.IsVisible = false;   // ... and the fill. You don't need it.
                text.FontSpec.Fill = new Fill(Color.Yellow, Color.White,Color.Cyan, 45.0f);
             zedGraphControl1.AxisChange();
             zedGraphControl1.Invalidate();
             zedGraphControl1.Refresh();
             text.IsClippedToChartRect = true;
            }

            if (toolStripComboBox1.Text == "4")
            {
                zedGraphControl1.GraphPane.GraphObjList.Clear();
                // TextObj textEquation = new TextObj("Add your Text", pane.XAxis.Scale.Min+ (3*(pane.XAxis.Scale.MinorStep)), pane.YAxis.Scale.Max-pane.YAxis.Scale.MinorStep);            
                TextObj text = new TextObj("Modal Frequencies\n1. " + top10modalfreq[0] + " Hz\n2. " + top10modalfreq[1] + " Hz\n3. " + top10modalfreq[2] + " Hz\n4. " + top10modalfreq[3] + " Hz", 0.98f, 0.03f, CoordType.ChartFraction, AlignH.Right, AlignV.Top);
                text.FontSpec.StringAlignment = StringAlignment.Near;
                pane.GraphObjList.Add(text);
                text.IsClippedToChartRect = true;
                //   text.FontSpec.Border.IsVisible = false; // Disable the border
                //   text.FontSpec.Fill.IsVisible = false;   // ... and the fill. You don't need it.
                text.FontSpec.Fill = new Fill(Color.Yellow, Color.White, Color.DeepSkyBlue, 45.0f);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                text.IsClippedToChartRect = true;
            }

            if (toolStripComboBox1.Text == "5")
            {
                zedGraphControl1.GraphPane.GraphObjList.Clear();
                // TextObj textEquation = new TextObj("Add your Text", pane.XAxis.Scale.Min+ (3*(pane.XAxis.Scale.MinorStep)), pane.YAxis.Scale.Max-pane.YAxis.Scale.MinorStep);            
                TextObj text = new TextObj("Modal Frequencies\n1. " + top10modalfreq[0] + " Hz\n2. " + top10modalfreq[1] + " Hz\n3. " + top10modalfreq[2] + " Hz\n4. " + top10modalfreq[3] + " Hz\n5. " + top10modalfreq[4] + " Hz", 0.98f, 0.03f, CoordType.ChartFraction, AlignH.Right, AlignV.Top);
                text.FontSpec.StringAlignment = StringAlignment.Near;
                pane.GraphObjList.Add(text);
                text.IsClippedToChartRect = true;
                //   text.FontSpec.Border.IsVisible = false; // Disable the border
                //   text.FontSpec.Fill.IsVisible = false;   // ... and the fill. You don't need it.
                text.FontSpec.Fill = new Fill(Color.Yellow, Color.White, Color.DeepSkyBlue, 45.0f);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                zedGraphControl1.Refresh();
                text.IsClippedToChartRect = true;   
            }
          
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
         /*   text.Location.AlignH = AlignH.Right;
            text.FontSpec.Border.IsVisible = false;
            text.FontSpec.Fill.IsVisible = false;*/
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dblsdnnotsnglsd = false;
           button16.Enabled = false;
           li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            if ((ampnnotphase == true) && (hertznnotbins == false))
            {
                for (int i = 0; i <=512; i++)
                {
                    pplsnglsd.Add(i, fftcoeff_mag[i]);
                }
                pane.Title.Text = "Single-sided Amplitude Spectrum(Amplitude vs Bins) ";
                pane.YAxis.Title.Text = "Magnitude";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("magnitude", pplsnglsd, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == true) && (hertznnotbins == true))
            {

                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_mag[i]);
                }
                
                pane.Title.Text = "Single-sided Amplitude Spectrum(Amplitude vs Hz) ";
                pane.YAxis.Title.Text = "Magnitude";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("magnitude", pplsnglsd, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == false) && (hertznnotbins == false) && (radnnotdeg == true))
            {
                for (int i = 0; i <=512; i++)
                {
                    pplsnglsd.Add(i, fftcoeff_phase[i]);
                }
                pane.Title.Text = "Single-sided Phase Spectrum(rad vs Bins) ";
                pane.YAxis.Title.Text = "Phase(radian)";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("Phase(rad)", pplsnglsd, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == false) && (hertznnotbins == true) && (radnnotdeg == true))
            {
                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                }
               pane.Title.Text = "Single-sided Phase Spectrum(rad vs Hz) ";
                pane.YAxis.Title.Text = "Phase(radian)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("Phase(rad)", pplsnglsd, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == false) && (hertznnotbins == false) && (radnnotdeg == false))
            {
                for (int i = 0; i <=512; i++)
                {
                    pplsnglsd.Add(i, fftcoeff_phase[i] * (180.0 / 3.14));
                }
                pane.Title.Text = "Single-sided Phase Spectrum(deg vs Bins) ";
                pane.YAxis.Title.Text = "Phase(degree)";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("Phase(deg)", pplsnglsd, Color.Lime, SymbolType.None);
            }

            if ((ampnnotphase == false) && (hertznnotbins == true) && (radnnotdeg == false))
            {
                for (int i = 0; i <= 512; i++)
                {
                    pplsnglsd.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                }
              pane.Title.Text = "Single-sided Phase Spectrum(degree vs Hz) ";
                pane.YAxis.Title.Text = "Phase(degree)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("Phase(rad)", pplsnglsd, Color.Lime, SymbolType.None);
            }
            toolStripDropDownButton1.Enabled = true;
           zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dblsdnnotsnglsd = true;
           button16.Enabled = true;
            li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            if ((ampnnotphase==true)&&(hertznnotbins == false))
            {
                for (int i = 0; i < 1024; i++)
                {
                    ppl.Add(i, fftcoeff_mag[i]);
                }
                pane.Title.Text = "Double-sided Amplitude Spectrum(Amplitude vs Bins) ";
                pane.YAxis.Title.Text = "Magnitude";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("magnitude", ppl, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == true) && (hertznnotbins == true))
            {
                
                for (int i = 0; i <=512; i++)
                {
                    ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_mag[i]);
                }
                for (int i = 512; i < 1024; i++)
                {
                    ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_mag[i]);
                }
                pane.Title.Text = "Double-sided Amplitude Spectrum(Amplitude vs Hz) ";
                pane.YAxis.Title.Text = "Magnitude";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("magnitude", ppl, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == false) && (hertznnotbins == false)&&(radnnotdeg==true))
            {
                for (int i = 0; i < 1024; i++)
                {
                    ppl.Add(i, fftcoeff_phase[i]);
                }
                pane.Title.Text = "Double-sided Phase Spectrum(rad vs Bins) ";
                pane.YAxis.Title.Text = "Phase(radian)";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("Phase(rad)", ppl, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == false) && (hertznnotbins == true) && (radnnotdeg == true))
            {
                for (int i = 0; i <=512; i++)
                {
                    ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                }
                for (int i = 512; i <1024; i++)
                {
                    ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                }
                pane.Title.Text = "Double-sided Phase Spectrum(rad vs Hz) ";
                pane.YAxis.Title.Text = "Phase(radian)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("Phase(rad)", ppl, Color.Lime, SymbolType.None);
            }
            if ((ampnnotphase == false) && (hertznnotbins == false) && (radnnotdeg == false))
            {
                for (int i = 0; i < 1024; i++)
                {
                    ppl.Add(i, fftcoeff_phase[i]*(180.0/3.14));
                }
                pane.Title.Text = "Double-sided Phase Spectrum(deg vs Bins) ";
                pane.YAxis.Title.Text = "Phase(degree)";
                pane.XAxis.Title.Text = "Frequency(Bins)";
                li = pane.AddCurve("Phase(deg)", ppl, Color.Lime, SymbolType.None);
            }
           
            if ((ampnnotphase == false) && (hertznnotbins == true) && (radnnotdeg == false))
            {
                for (int i = 0; i <=512; i++)
                {
                    ppl.Add(i * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i]);
                }
                for (int i = 512; i <1024; i++)
                {
                    ppl.Add((i - 1024) * (500 / refToForm1fromFA.n1) / 1024.0, fftcoeff_phase[i] * (180.0 / 3.14));
                }
                pane.Title.Text = "Double-sided Phase Spectrum(degree vs Hz) ";
                pane.YAxis.Title.Text = "Phase(degree)";
                pane.XAxis.Title.Text = "Frequency(Hz)";
                li = pane.AddCurve("Phase(rad)", ppl, Color.Lime, SymbolType.None);
            }
                toolStripDropDownButton1.Enabled = true;//check it later on
           
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //make this for only for double sided n bins...enable it
            li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            for (int i = 0; i < 1024; i++)
            {
                ppl.Add(i/1024.0, fftcoeff_mag[i]);
            }
            pane.Title.Text = "Double-sided Amplitude Spectrum(Amplitude vs Bins) ";
            pane.YAxis.Title.Text = "Magnitude";
            pane.XAxis.Title.Text = "Frequency Bins(Normalised)";
            li = pane.AddCurve("magnitude", ppl, Color.Lime, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

        private void button17_Click(object sender, EventArgs e)
        {
           
          


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MasterPane master = zedGraphControl1.MasterPane;
            //  master.Chart.Fill = new Fill(Color.Black, Color.DimGray, 45.0f);
            master.Fill = new Fill(Color.MidnightBlue, Color.DarkSlateGray, 45.0f);
            // Clear out the initial GraphPane
            master.PaneList.Clear();
            master.Title.FontSpec.FontColor = System.Drawing.Color.White;
            // Show the masterpane title
            master.Title.IsVisible = true;
            master.Title.Text = "Double-sided Frequency analysis(Absolute magnitude,Phase,power)";

            // Leave a margin around the masterpane, but only a small gap between panes
            master.Margin.All = 10;
            master.InnerPaneGap = 5;

            // The titles for the individual GraphPanes
            string[] yLabels = { "Absolute magnitude", "Phase", "power" };

            ColorSymbolRotator rotator = new ColorSymbolRotator();

            for (int j = 0; j < 3; j++)
            {
                // Create a new graph -- dimensions to be set later by MasterPane Layout
                GraphPane myPaneT = new GraphPane(new Rectangle(10, 10, 10, 10),
                   "",
                   "Number of samples",
                   yLabels[j]);

                //myPaneT.Fill = new Fill( Color.FromArgb( 230, 230, 255 ) );
                myPaneT.Fill.IsVisible = false;
                myPaneT.XAxis.Color = System.Drawing.Color.Fuchsia;
                myPaneT.YAxis.Color = System.Drawing.Color.Fuchsia;
                myPaneT.XAxis.Title.FontSpec.FontColor = System.Drawing.Color.White;
                myPaneT.YAxis.Title.FontSpec.FontColor = System.Drawing.Color.White;
                myPaneT.XAxis.Scale.FontSpec.FontColor = System.Drawing.Color.White;
                myPaneT.YAxis.Scale.FontSpec.FontColor = System.Drawing.Color.White;
                myPaneT.XAxis.MajorGrid.Color = System.Drawing.Color.Aqua;
              //  myPaneT.XAxis.MinorGrid.Color = System.Drawing.Color.Aqua;
                myPaneT.YAxis.MajorGrid.Color = System.Drawing.Color.Aqua;
              //  myPaneT.XAxis.MinorGrid.Color = System.Drawing.Color.Aqua;
                myPaneT.XAxis.MajorTic.Color = System.Drawing.Color.Yellow;
                myPaneT.YAxis.MajorTic.Color = System.Drawing.Color.Yellow;
                // Fill the Chart background
                myPaneT.Chart.Fill = new Fill(Color.Black, Color.DimGray, 45.0f);
                // Set the BaseDimension, so fonts are scale a little bigger
                myPaneT.BaseDimension = 3.0F;

                // Hide the XAxis scale and title
                myPaneT.XAxis.Title.IsVisible = true;
                myPaneT.XAxis.Scale.IsVisible = true;
                // Hide the legend, border, and GraphPane title
                myPaneT.Legend.IsVisible = true;
                myPaneT.Border.IsVisible = true;
                myPaneT.Title.IsVisible = true;
                // Get rid of the tics that are outside the chart rect
                myPaneT.XAxis.MajorTic.IsOutside = false;
                myPaneT.XAxis.MinorTic.IsOutside = false;
                myPaneT.XAxis.MajorTic.IsCrossOutside = true;
                myPaneT.XAxis.MinorTic.IsCrossOutside = true;
             
               
                // Show the X grids
                myPaneT.XAxis.MajorGrid.IsVisible = true;
                myPaneT.XAxis.MinorGrid.IsVisible = true;
                myPaneT.YAxis.MajorGrid.IsVisible = true;
                myPaneT.YAxis.MinorGrid.IsVisible = true;
                // Remove all margins
                myPaneT.Margin.All = 0;
                // Except, leave some top margin on the first GraphPane
                if (j == 0)
                    myPaneT.Margin.Top = 20;
                // And some bottom margin on the last GraphPane
                // Also, show the X title and scale on the last GraphPane only
                if (j == 2)
                {
                    myPaneT.XAxis.Title.IsVisible = true;
                    myPaneT.XAxis.Scale.IsVisible = true;
                    myPaneT.Margin.Bottom = 10;
                }

                if (j > 0)
                    myPaneT.YAxis.Scale.IsSkipLastLabel = true;

                // This sets the minimum amount of space for the left and right side, respectively
                // The reason for this is so that the ChartRect's all end up being the same size.
                myPaneT.YAxis.MinSpace = 80;
                myPaneT.Y2Axis.MinSpace = 20;

                // Make up some data arrays based on the Sine function
                PointPairList list = new PointPairList();
                
                   
                     
            //pane.Title.Text = "Double-sided magnitude Spectrum ";
           // pane.XAxis.Title.Text = "Frequency(Bins)";
           // pane.YAxis.Title.Text = "Magnitude";
                   
         
            
          
                     // X AXIS SETTINGS

            //pane.XAxis.Type = AxisType.;
            //  myPane.XAxis.Scale.Format = "dd-MMM-yy";
            // myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
          
            // myPane.XAxis.Scale.Min = new XDate(DateTime.Now.AddDays(-NumberOfBars));
            //myPane.XAxis.Scale.Max = new XDate(DateTime.Now);
          
                        // Declare a LineItem:- LineItem is used for creating a line       
                        
                         // Set the XAxis labels  
                     //   pane.XAxis.Scale.TextLabels = x0;
            /*
Just manually control the X axis range so it scrolls continuously
// instead of discrete step-sized jumps
myPane.XAxis.Scale.Min = 0;
myPane.XAxis.Scale.Max = 30;
myPane.XAxis.Scale.MinorStep = 1;
myPane.XAxis.Scale.MajorStep = 5;

// Scale the axes
zedGraphControl1.AxisChange();
*/

                if (j == 0)
                {
                    list.Clear();
                    for (int i = 0; i < 1024; i++)
                    {
                        list.Add(i, fftcoeff_mag[i]);
                    }
                    //  toolStripDropDownButton1.Enabled = true;
                    //li = pane.AddCurve("magnitude", ppl, Color.Lime,SymbolType.None);


                    //  toolStripDropDownButton1.Enabled = false;
                    //================================
                    /*LineItem trendLine = new LineItem(String.Empty, new[] { pstartDate, pconfirmDate },   new[] { pstartPrice, pconfirmPrice }, System.Drawing.Color.Black, SymbolType.None);
        trendLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;
        trendLine.Line.Width = 1f;
        pricePane.CurveList.Add(trendLine);*/
                    //=============================

                    // Make sure the Y axis is rescaled to accommodate actual data

                    // li.Symbol.IsVisible = false;
                    /* curve.Line.Width = 2.0F;
       curve.Line.IsAntiAlias = true;
       curve.Symbol.Fill = new Fill( Color.White );
       curve.Symbol.Size = 7;*/
                    //   zg1.AxisChange();
                    // zg1.Refresh();


                    /*   chart6.Series["Amplitu
                      }

                      // Create a curve
                      LineItem myCurve = myPaneT.AddCurve("Type " + j.ToString(),
                         list, rotator.NextColor, rotator.NextSymbol);
                      // Fill the curve symbols with white
                      myCurve.Symbol.Fill = new Fill(Color.White);

                      // Add the GraphPane to the MasterPane.PaneList
                      master.Add(myPaneT);
                  }

                  using (Graphics g = this.CreateGraphics())
                  {
                      // Align the GraphPanes vertically
                      master.SetLayout(g, PaneLayout.SingleColumn);
                      master.AxisChange(g);
                  }
                  /*var text = new TextObj("Your Comapany Name Ltd.", (0.6) * (myPaneT.XAxis.Scale.Max), 1.1, CoordType.ChartFraction, AlignH.Left, AlignV.Top);
                  text.ZOrder = ZOrder.D_BehindAxis;
                  master.GraphObjList.Add(text);*/
                    //not wrking
                    // Create a curve
                    LineItem myCurve = myPaneT.AddCurve("Amplitude " ,
                       list, rotator.NextColor, rotator.NextSymbol);
                    // Fill the curve symbols with white
                    myCurve.Symbol.Fill = new Fill(Color.White);

                    // Add the GraphPane to the MasterPane.PaneList
                    master.Add(myPaneT);
                }
                if (j == 1)
                {
                    list.Clear();
                  //  pane.Title.Text = "Double-sided Phase Spectrum(deg vs Bins) ";
                    for (int i = 0; i < 1024; i++)
                    {
                        list.Add(i, fftcoeff_phase[i] * (180.0 / 3.14));
                    }
                   
                    LineItem myCurve = myPaneT.AddCurve("degree ",
                       list, rotator.NextColor, rotator.NextSymbol);
                      myCurve.Symbol.Fill = new Fill(Color.White);
                      master.Add(myPaneT);
                }
                if (j == 2)
                {
                    list.Clear();
                    //  pane.Title.Text = "Double-sided Phase Spectrum(deg vs Bins) ";
                    for (int i = 0; i < 1024; i++)
                    {
                        list.Add(i, 10 * Math.Log10(Math.Pow(fftcoeff_mag[i], 2) / (1024.0 * 2.0)));
                    }

                    LineItem myCurve = myPaneT.AddCurve("dB ",
                       list, rotator.NextColor, rotator.NextSymbol);
                    myCurve.Symbol.Fill = new Fill(Color.White);
                    master.Add(myPaneT);

                }

            }

            using (Graphics g = this.CreateGraphics())
            {
                // Align the GraphPanes vertically
                master.SetLayout(g, PaneLayout.SingleColumn);
                master.AxisChange(g);
            }
            /*var text = new TextObj("Your Comapany Name Ltd.", (0.6) * (myPaneT.XAxis.Scale.Max), 1.1, CoordType.ChartFraction, AlignH.Left, AlignV.Top);
            text.ZOrder = ZOrder.D_BehindAxis;
            master.GraphObjList.Add(text);*/
            //not wrking

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            double BW;
            if (refToForm1fromFA.videosrcplayr == true)
                BW = (512 * (500 / refToForm1fromFA.n1) / 1024.0) * 1.0;
            else
                BW = (512 *2 / 1024.0) * 1.0;
            listView1.Clear();
            listView1.Columns.Add("Bandwidth", 200);
            listView1.Columns.Add("Unit", 150);

            itm1.Text = BW.ToString();
            itm1.SubItems.Add("Hz/line");
            listView1.Items.Add(itm1);
            //do the display thing unit:hz/line
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double resolution;
            if (refToForm1fromFA.videosrcplayr == true)
                resolution = 2 * (512 * (500 / refToForm1fromFA.n1) / 1024.0) * 1.0;
            else
                resolution = 2 * (512 * 2 / 1024.0) * 1.0;
            listView1.Clear();
            listView1.Columns.Add("Resolution", 200);
            listView1.Columns.Add("Unit", 150);

            itm1.Text = resolution.ToString();
            itm1.SubItems.Add("Hz/line");
            listView1.Items.Add(itm1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            double LRF ;
            if(refToForm1fromFA.videosrcplayr==true)
             LRF = 512 * (500/refToForm1fromFA.n1) / 1024.0;//500 fps 
            else
                LRF = 512 * 2/ 1024.0;//2 sampling freq
            listView1.Clear();
            listView1.Columns.Add("Lowest resolution Frequency", 200);
            listView1.Columns.Add("Unit", 150);

                itm1.Text = LRF.ToString();
                itm1.SubItems.Add("Hz/line");
                listView1.Items.Add(itm1);
            
            //do the display thing unit:hz/line
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            listView1.Columns.Add("Modal Frequencies", 200);
            listView1.Columns.Add("Unit", 100);
      
             if (toolStripComboBox1.Text == "3")
            {
                listView1.Items.Clear();

                ListViewItem itm2 = new ListViewItem();
                ListViewItem itm3 = new ListViewItem();
                ListViewItem itm4 = new ListViewItem();
                  
                itm2.Text = top10modalfreq[0].ToString();
                itm2.SubItems.Add("Hz");
              itm3.Text = top10modalfreq[1].ToString();
                itm3.SubItems.Add("Hz");
                  itm4.Text = top10modalfreq[2].ToString();
                itm4.SubItems.Add("Hz");
                listView1.Items.AddRange(new ListViewItem[] { itm2, itm3, itm4 });
  
            }

            if (toolStripComboBox1.Text == "4")
            {
                listView1.Items.Clear();
                ListViewItem itm2 = new ListViewItem();
                ListViewItem itm3 = new ListViewItem();
                ListViewItem itm4 = new ListViewItem();
                ListViewItem itm5 = new ListViewItem();
                itm2.Text = top10modalfreq[0].ToString();
                itm2.SubItems.Add("Hz");
                itm3.Text = top10modalfreq[1].ToString();
                itm3.SubItems.Add("Hz");
                itm4.Text = top10modalfreq[2].ToString();
                itm4.SubItems.Add("Hz");
                itm5.Text = top10modalfreq[3].ToString();
                itm5.SubItems.Add("Hz");
                listView1.Items.AddRange(new ListViewItem[] { itm2, itm3, itm4,itm5 });
                
            }

            if (toolStripComboBox1.Text == "5")
            {
                listView1.Items.Clear();
                ListViewItem itm2 = new ListViewItem();
                ListViewItem itm3 = new ListViewItem();
                ListViewItem itm4 = new ListViewItem();
                ListViewItem itm5 = new ListViewItem();
                ListViewItem itm6 = new ListViewItem();
                itm2.Text = top10modalfreq[0].ToString();
                itm2.SubItems.Add("Hz");
                itm3.Text = top10modalfreq[1].ToString();
                itm3.SubItems.Add("Hz");
                itm4.Text = top10modalfreq[2].ToString();
                itm4.SubItems.Add("Hz");
                itm5.Text = top10modalfreq[3].ToString();
                itm5.SubItems.Add("Hz");
                itm6.Text = top10modalfreq[4].ToString();
                itm6.SubItems.Add("Hz");
                listView1.Items.AddRange(new ListViewItem[] { itm2, itm3, itm4, itm5 ,itm6});
            }
          
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            li.Clear(); ppl.Clear(); pplsnglsd.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            for (int i = 0; i < 512; i++)
            {
                pplsnglsd.Add(i / 1024.0, fftcoeff_mag[i]);
            }
            pane.Title.Text = "Single-sided Amplitude Spectrum(Amplitude vs Bins) ";
            pane.YAxis.Title.Text = "Magnitude";
            pane.XAxis.Title.Text = "Frequency Bins(Normalised)";
            li = pane.AddCurve("magnitude", pplsnglsd, Color.Lime, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

    
      

        
    }
}
