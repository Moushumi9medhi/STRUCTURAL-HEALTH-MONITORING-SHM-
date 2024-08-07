/////////////////////////////////////////////////////////////////////////////////////////////////////
// This sample does not show how to get images and how to play with the camRAM, etc.
// It is only intended to show how to access the pco.camera SDK while using C#.
/////////////////////////////////////////////////////////////////////////////////////////////////////

// extern "C" { #include c:\programme\digital camera toolbox\pco.camera.sdk\include\SC2_CamExport.h }
// Including is not possible with C#, so we have to rebuild all structures defined in SC2_CamExport.h.
// Additionally you can not create arrays inside a structure. We can work around this, by creating
// each member as an own entity.

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
//using AForge.Imaging.RGB;
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
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using WMPLib;
//using DShowNET;
 
//using QuartzTypeLib;
//using Microsoft.DirectX;
//using Microsoft.DirectX.AudioVideoPlayback;

using DexterLib;
using System.Runtime.CompilerServices;


namespace CSharpDemo
{
  /// <summary>
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
      ANN frm;
    private System.Windows.Forms.Button buttonOpen;
    private System.Windows.Forms.Button buttonGetDescription;
    private System.Windows.Forms.Button buttonClose;
    private Button buttonGrab;
    private Button buttonStart;
    private Button buttonStop;
    private PictureBox pictureBox1;
    private Button button1;
    private Button button2;
    private GroupBox groupBox2;
    private NumericUpDown numericUpDown3;
    private Label label3;
    private NumericUpDown numericUpDown2;
    private Label label2;
    private NumericUpDown numericUpDown1;
    private Button button3;
    private LinkLabel linkLabel1;
    private Label label4;
    private IContainer components;
    Color color = Color.Red;
   // public double sec = 0;
    double ratiox = 1.5;
    double ratioy = 1.5;
    double ry; double rx;
    int y;
    public bool setflagForcasting = false;
    public bool startIntakeVibrations = false;
    public bool startCalculation = false;
    public bool flag_strip = false;
    public bool videoframeinputstarted = false;
    public bool verticaldir = true;
    public bool extractframefirst = false;
    public bool startreadingdisplacementvalue = false;
    public bool stopreadingdisplacementvalue = false;
    public bool selectdimatcurrpt=false;
    public bool tdm=true;
    public bool removenoisypikes = false;
    complex[] resy;
    double av_time;
    int framecount1, framecount2;
    FileVideoSource videoSource;
    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    public int counter = 0;
    public int counter2 = 0;
    public int timer5counter = 0;
    BlobCounter blobCounter = new BlobCounter();
    private ColorDialog colorDialog1;
    int range = 115;
    GrayscaleBT709 grayscaleFilter = new GrayscaleBT709();
    EuclideanColorFiltering filter = new EuclideanColorFiltering();
    Rectangle mRect;
    Boolean object_found = false;
    Rectangle selected_object, previous_pos;
    Boolean tempo = false;
    double freq_x = 0;
    //double xvalue = 12.97, yvalue = 15.37;
    double freq_y = 0;
    private System.Windows.Forms.Timer timer1;
    double dist;
    //complex[] resy;
    int temp_y; public int n1; int frrcv;
   // double xvalue;
    double av_y;
    double max_x = 0, max_y = 0, min_x = 10000, min_y = 10000, delta_x, delta_y;
    public double actd;//= 3.72060546875; //mm
    double  ds=31;
    int init_x, init_y;
    Boolean found = true;
    Boolean flag_index_y = true;
    LinkedList<double> yvals = new LinkedList<double>();//initially int changed on 29th feb
    LinkedList<double> freqs = new LinkedList<double>();
  public  LinkedList<double> accelerationpdf = new LinkedList<double>();
  LinkedList<double> yd = new LinkedList<double>();
  public LinkedList<double> dispactual = new LinkedList<double>();    
  //  LinkedList<double> time_p = new LinkedList<double>
    double time_curr, time_prev = 0,Velocity_prev=0, temp;
    private ComboBox camerasCombo;
    private PrintPreviewDialog printPreviewDialog1;
    private PictureBox pictureBox2;
    //private System.Windows.Forms.Timer timer2;
    private RadioButton radioButton1;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private GroupBox groupBox5;
    private RadioButton radioButton2;
    private PictureBox pictureBox3;
    private Label label1;
    private GroupBox groupBox8;
    private Button button10;
    private RichTextBox richTextBox3;
    private Button button11;
    private Button button7;
    private Label label6;
    private OpenFileDialog openFileDialog1;
    private GroupBox groupBox6;
    private RadioButton radioButton5;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart7;
    private PictureBox pictureBox4;
    private FilterInfoCollection videoDevices;
    private Label label8;
    private Label label9;
    private Label label7;
    private GroupBox groupbox13;
    double[] DRms;
    double[] DRmsN;
    
    private Button button14;
    private Button button15;
    private Label label10;
    private ProgressBar progressBar1;
    private System.Windows.Forms.Timer timer3;
    private Button button16;
    double yval_rms;
    public double[] yval_array = new double[1024];
     
    private Button button9;
    private RichTextBox richTextBox1;
    private Button button12;
    private System.Windows.Forms.Timer timer2;
    private Button button4;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private Label label11;
    Stopwatch stopwatch = new Stopwatch();
    Stopwatch stopwatch1 = new Stopwatch();
    double Displacement;
    double Velocity;
    double Acceleration;
    double displacement;
    double velocity;
    double acceleration;
    private Label label12;
    private GroupBox groupBox1;
    private Label label14;
    private Label label16;
    private Label label15;
    private RadioButton radioButton6;
    private RadioButton radioButton3;
    double Displacement_prev = 0;
    public bool USEalreadytrained = false;
    public bool acceleratebuttonpressed = false;
    public bool oKToolStripMenuItemClick = false;
    public bool shac = false;
    public int comboxANNvalue;
    public int c = 0;//just for test
    public int cframe = 0;
    public bool pco = false;
    private Button button5;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileOpenToolStripMenuItem;
    private ToolStripMenuItem OpenToolStripMenuItem;
    private ToolStripMenuItem yttyfToolStripMenuItem;
    private ToolStripMenuItem StopToolStripMenuItem;
    private ToolStripMenuItem frameCountToolStripMenuItem;
    private ToolStripMenuItem currentToolStripMenuItem;
    private ToolStripMenuItem totalToolStripMenuItem;
    private System.Windows.Forms.Timer timer4;
    public DateTimePicker dateTimePicker1;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem dataPointsToolStripMenuItem;
    private ToolStripMenuItem amplitudeToolStripMenuItem;
    private ToolStripMenuItem parametersToolStripMenuItem;
    private ToolStripMenuItem verticleToolStripMenuItem;
    private ToolStripMenuItem horizontalToolStripMenuItem;
    private ToolStripMenuItem displacementToolStripMenuItem;
    private ToolStripMenuItem verticleToolStripMenuItem1;
    private ToolStripMenuItem horizontalToolStripMenuItem1;
    private ToolStripMenuItem velocityToolStripMenuItem;
    private ToolStripMenuItem verticleToolStripMenuItem2;
    private ToolStripMenuItem horizontalToolStripMenuItem2;
    private ToolStripMenuItem accelerationToolStripMenuItem;
    private ToolStripMenuItem verticleToolStripMenuItem3;
    private ToolStripMenuItem horizontalToolStripMenuItem3; 
      public bool videosrcplayr = false;
      private ToolStripMenuItem videoDurationToolStripMenuItem;
      private ToolStripMenuItem imageSizeToolStripMenuItem;
      private ToolStripMenuItem widthToolStripMenuItem;
      private ToolStripMenuItem heightToolStripMenuItem;
      private ToolStripMenuItem hmsToolStripMenuItem;
      private ToolStripMenuItem hmsroundedToolStripMenuItem;
      private ToolStripMenuItem secsToolStripMenuItem;
      private ToolStripMenuItem minsToolStripMenuItem;
      private ToolStripMenuItem hoursToolStripMenuItem;
      private ToolStripMenuItem millisecsToolStripMenuItem;
      public int framecount = 0;
      public TimeSpan t;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripTextBox toolStripTextBox1;
      private ToolStripTextBox toolStripTextBox2;
      private ToolStripTextBox toolStripTextBox3;
      private ToolStripTextBox toolStripTextBox4;
      private ToolStripTextBox toolStripTextBox5;
      private ToolStripTextBox toolStripTextBox6;
      private ToolStripTextBox toolStripTextBox7;
      private ToolStripTextBox toolStripTextBox8;
      private ToolStripTextBox toolStripTextBox9;
      private ToolStripTextBox toolStripTextBox10;
      private ToolStripMenuItem userInputToolStripMenuItem;
      private ToolStripMenuItem framesSkippedToolStripMenuItem;
      private ToolStripMenuItem videoToolStripMenuItem;
      private ToolStripTextBox toolStripTextBox11;
      private ToolStripMenuItem pCOToolStripMenuItem;
      private ToolStripMenuItem oKToolStripMenuItem;
      private ToolStripTextBox toolStripTextBox12;
      private ToolStripMenuItem oKToolStripMenuItem1;
      private NotifyIcon notifyIcon1;
      private ToolStrip toolStrip1;
      private ToolStripSeparator toolStripSeparator;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripDropDownButton toolStripDropDownButton1;
      private ToolStripButton toolStripButton2;
      private ToolStripMenuItem relativePixelsToolStripMenuItem;
      private ToolStripMenuItem actualToolStripMenuItem;
      private ToolStripSeparator toolStripSeparator3;
      private ToolStripTextBox toolStripTextBox13;
      private ToolStripMenuItem oKToolStripMenuItem2;
      private GroupBox groupBox7;
      private RadioButton radioButton4;
      private RadioButton radioButton7;
      private GroupBox groupBox9;
      private NumericUpDown numericUpDown4;
      private Label label5;
      private NumericUpDown numericUpDown5;
      private Label label17;
      private ToolStripMenuItem toolStripMenuItem1;
      private ToolStripSeparator toolStripSeparator4;
      private ToolStripSeparator toolStripSeparator5;
      private ToolStripSeparator toolStripSeparator6;
      private ToolStripSeparator toolStripSeparator7;
      private ToolStripSeparator toolStripSeparator8;
      private PictureBox pictureBox5;
      private Label label18;
      private Button button8;
      private Button button13;
      private Button button18;
      private Button button19;
      public int frameskip=0;
      private ToolStripMenuItem toolStripMenuItem2;
      private ToolStripTextBox toolStripTextBox14;
      MediaDetClass mediaDet = new MediaDetClass();
     System.Drawing.Image []imgframe1 = new System.Drawing.Image[1024];
     private System.Windows.Forms.Timer timer5;
     private RadioButton radioButton8;
     private Button button6;
      Bitmap imgframe2 = new Bitmap(320,240);
      Daubechies obj_daub = new Daubechies();
      private CheckBox checkBox5;
      private ToolStripSeparator toolStripSeparator9;
      private ToolStripButton toolStripButton3;
      private ToolStripSeparator toolStripSeparator10;
      private ToolStripMenuItem toolStripMenuItem4;
      private ToolStripMenuItem toolStripMenuItem3;
      private ToolStripMenuItem toolStripMenuItem5;
      long duration;
      long durationatstorage;
      private SplitContainer splitContainer1;
      private Button button20;
      private GroupBox groupBox10;
      private GroupBox groupBox11;
      private RichTextBox richTextBox2;
      private Label label27;
      private Label label29;
      private Label label28;
      private GroupBox groupBox12;
      private RichTextBox richTextBox8;
      private RichTextBox richTextBox4;
      private RichTextBox richTextBox9;
      private Button button23;
      private Button button22;
      private Button button17;
      private GroupBox groupBox14;
      private GroupBox groupBox15;
      private RadioButton radioButton10;
      private RadioButton radioButton9;
      private Button button21;
      private Button button24;
      private Button button25;
      int counter_removenoisyspikes = 0;
      double yvalue_prev_rns;
      private GroupBox groupBox16;
      private GroupBox groupBox17;
      private RichTextBox richTextBox5;
      private Button button26;
      private Button button27;
      private Button button28;
      public bool denoise = false;
      double tm;
      private ToolStripButton toolStripButton1;
      private Button button29;
      Frequency_Analysis fq;
public Form1()//executed only on running or pressing start but not after form loaded
    {
        frm = new ANN(this);
      InitializeComponent();
      //groupBox1.Hide();
      groupBox3.Hide();
      groupBox4.Hide();
      //groupBox7.Hide();
      groupBox8.Hide();
      // timer.Tick += new EventHandler(timer2_Tick);
      timer.Interval = 1;//initially it was 10..made 1 for graphs
      timer.Enabled = true;

      buttonGrab.Enabled = false;
      buttonStart.Enabled = false;
      buttonStop.Enabled = false;
      buttonGetDescription.Enabled = false;
      button1.Enabled = true;
      button2.Enabled = false;
      buttonClose.Enabled = false;
      blobCounter.MinWidth = 2;
      blobCounter.MinHeight = 2;
      blobCounter.FilterBlobs = true;
      blobCounter.ObjectsOrder = ObjectsOrder.Size;
      try
      {
          // enumerate video devices
          videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice);//search for video input devices

          if (videoDevices.Count == 0)// if no input device is found throw exception 
              throw new ApplicationException();

          // add all devices to combo
          foreach (FilterInfo device in videoDevices)
          {
              camerasCombo.Items.Add(device.Name);
          }

          camerasCombo.SelectedIndex = 0;
      }
      catch (ApplicationException)
      {
          camerasCombo.Items.Add("No local capture devices");
          videoDevices = null;
      }
      Bitmap b = new Bitmap(320, 240);
      // Rectangle a = (Rectangle)r;
      Pen pen1 = new Pen(Color.FromArgb(160, 255, 160), 3);
      Graphics g2 = Graphics.FromImage(b);
      pen1 = new Pen(Color.FromArgb(255, 0, 0), 3); //red colour
      g2.Clear(Color.White);
      /*g2.DrawLine(pen1, b.Width / 2, 0, b.Width / 2, b.Height);
      g2.DrawLine(pen1, b.Width, b.Height / 2, 0, b.Height / 2);*/
      pictureBox4.Image = (System.Drawing.Image)b;
    }//constructor form1()
      
    public Bitmap vid1(Bitmap image)
    {
        Bitmap objectsImage = null;
        Bitmap mImage = null;
        mImage = (Bitmap)image.Clone();
     
       
        
       
        //filter.CenterColor = Color.FromArgb(color.ToArgb();
        filter.CenterColor = new AForge.Imaging.RGB(colorDialog1.Color);
        
        filter.Radius = (short)range;
        //filter.CenterColor = new AForge.Imaging.RGB(Color.Blue);
       
        objectsImage = image;
        filter.ApplyInPlace(objectsImage);

        BitmapData objectsData = objectsImage.LockBits(new Rectangle(0, 0, image.Width, image.Height),
        ImageLockMode.ReadOnly, image.PixelFormat);
        UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
        objectsImage.UnlockBits(objectsData);


        blobCounter.ProcessImage(grayImage);
        Rectangle[] rects = blobCounter.GetObjectsRectangles();

        if (rects.Length > 0)
        {

            foreach (Rectangle objectRect in rects)
            {
                Graphics g = Graphics.FromImage(mImage);//HERE LIES THE DIFF WITH VID3. MIMAGE IS ORIGINAL IMAGE N NOT EUCLIDEAN COLORED IMAGE
                if (extractframefirst == true)
                {
                    using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 10))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }
                }

                g.Dispose();
            }
        }
        ImageStatisticsHSL hslStatistics = new ImageStatisticsHSL(image);
        int[] luminanceValues = hslStatistics.Luminance.Values;
        // RGB
        ImageStatistics rgbStatistics = new ImageStatistics(image);
        int[] redValues = rgbStatistics.Red.Values;
        int[] greenValues = rgbStatistics.Green.Values;
        int[] blueValues = rgbStatistics.Blue.Values;


        using (FileStream fs_histr = new FileStream("histogram_red.txt", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter sw_histr = new StreamWriter(fs_histr))
        {
            foreach (var value in redValues)
            {
                sw_histr.Write(value.ToString() + " ");
            }

        }

        using (FileStream fs_histg = new FileStream("histogram_green.txt", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter sw_histg = new StreamWriter(fs_histg))
        {
            foreach (var value in greenValues)
            {
                sw_histg.Write(value.ToString() + " ");
            }
            ;
        }

        using (FileStream fs_histb = new FileStream("histogram_blue.txt", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter sw_histb = new StreamWriter(fs_histb))
        {
            foreach (var value in blueValues)
            {
                sw_histb.Write(value.ToString() + " ");
            }
            sw_histb.WriteLine();
        } 
        image = mImage;

        return (System.Drawing.Bitmap)image.Clone();
    }
    public Bitmap vid3(Bitmap image)
    {
        Bitmap objectsImage = null;
        
        // set center color and radius
        filter.CenterColor = new AForge.Imaging.RGB(colorDialog1.Color);
       // filter.CenterColor = new AForge.Imaging.RGB(Color.Blue);
        filter.Radius = (short)range;
        // apply the filter
        objectsImage = image;
        blobCounter.MinHeight = Convert.ToInt32(numericUpDown2.Value);
        blobCounter.MinWidth = Convert.ToInt32(numericUpDown3.Value);
        

        filter.ApplyInPlace(image);
        
        blobCounter.ProcessImage(image);

        // lock image for further processing
        BitmapData objectsData = objectsImage.LockBits(new Rectangle(0, 0, image.Width, image.Height),
            ImageLockMode.ReadOnly, image.PixelFormat);

        // grayscaling
        UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));

        // unlock image
        objectsImage.UnlockBits(objectsData);
        blobCounter.ProcessImage(grayImage);
        
        /*
         objectsImage = image;
        filter.ApplyInPlace(objectsImage);

        BitmapData objectsData = objectsImage.LockBits(new Rectangle(0, 0, image.Width, image.Height),
        ImageLockMode.ReadOnly, image.PixelFormat);
        UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
        objectsImage.UnlockBits(objectsData);


        blobCounter.ProcessImage(image); 
     
         */
       
       /* Graphics g1 = Graphics.FromImage(image);
        Pen pen1 = new Pen(Color.FromArgb(160, 255, 160), 3);
        g1.DrawLine(pen1, image.Width / 2, 0, image.Width / 2, image.Height);
        g1.DrawLine(pen1, image.Width, image.Height / 2, 0, image.Height / 2);
        g1.Dispose();*/
        // Luminance
        ImageStatisticsHSL hslStatisticsvid3 = new ImageStatisticsHSL(image);
        int[] luminanceValuesvid3 = hslStatisticsvid3.Luminance.Values;
        // RGB
        ImageStatistics rgbStatisticsvid3 = new ImageStatistics(image);
        int[] redValuesvid3 = rgbStatisticsvid3.Red.Values;
        int[] greenValuesvid3 = rgbStatisticsvid3.Green.Values;
        int[] blueValuesvid3 = rgbStatisticsvid3.Blue.Values;


        using (FileStream fs_histrvid3 = new FileStream("histogram_redvid3.txt", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter sw_histrvid3 = new StreamWriter(fs_histrvid3))
        {
            foreach (var value in redValuesvid3)
            {
                sw_histrvid3.Write(value.ToString() + " ");
            }

        }

        using (FileStream fs_histgvid3 = new FileStream("histogram_greenvid3.txt", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter sw_histgvid3 = new StreamWriter(fs_histgvid3))
        {
            foreach (var value in greenValuesvid3)
            {
                sw_histgvid3.Write(value.ToString() + " ");
            }
            ;
        }

        using (FileStream fs_histbvid3 = new FileStream("histogram_bluevid3.txt", FileMode.OpenOrCreate, FileAccess.Write))
        using (StreamWriter sw_histbvid3 = new StreamWriter(fs_histbvid3))
        {
            foreach (var value in blueValuesvid3)
            {
                sw_histbvid3.Write(value.ToString() + " ");
            }
            sw_histbvid3.WriteLine();
        } 
        

        return (System.Drawing.Bitmap)image.Clone();
    }
   

    
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Vom Windows Form-Designer generierter Code
    /// <summary>
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonGetDescription = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonGrab = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.camerasCombo = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button24 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart7 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.button16 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yttyfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox7 = new System.Windows.Forms.ToolStripTextBox();
            this.totalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox8 = new System.Windows.Forms.ToolStripTextBox();
            this.videoDurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.hmsroundedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.millisecsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.secsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.minsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox5 = new System.Windows.Forms.ToolStripTextBox();
            this.hoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox6 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox9 = new System.Windows.Forms.ToolStripTextBox();
            this.heightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox10 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox14 = new System.Windows.Forms.ToolStripTextBox();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amplitudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.velocityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.accelerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticleToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.userInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.framesSkippedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox11 = new System.Windows.Forms.ToolStripTextBox();
            this.oKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox12 = new System.Windows.Forms.ToolStripTextBox();
            this.oKToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.relativePixelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.actualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox13 = new System.Windows.Forms.ToolStripTextBox();
            this.oKToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button15 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button29 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.richTextBox9 = new System.Windows.Forms.RichTextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.richTextBox8 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.ForeColor = System.Drawing.Color.Maroon;
            this.buttonOpen.Location = new System.Drawing.Point(0, 46);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(85, 3);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "OpenCamera";
            this.buttonOpen.Click += new System.EventHandler(this.OnOpenCamera);
            // 
            // buttonGetDescription
            // 
            this.buttonGetDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetDescription.ForeColor = System.Drawing.Color.Maroon;
            this.buttonGetDescription.Location = new System.Drawing.Point(171, 43);
            this.buttonGetDescription.Name = "buttonGetDescription";
            this.buttonGetDescription.Size = new System.Drawing.Size(52, 10);
            this.buttonGetDescription.TabIndex = 1;
            this.buttonGetDescription.Text = "Description";
            this.buttonGetDescription.Click += new System.EventHandler(this.OnGetDescription);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.ForeColor = System.Drawing.Color.Maroon;
            this.buttonClose.Location = new System.Drawing.Point(82, 46);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 7);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "CloseCamera";
            this.buttonClose.Click += new System.EventHandler(this.OnCloseCamera);
            // 
            // buttonGrab
            // 
            this.buttonGrab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGrab.ForeColor = System.Drawing.Color.Maroon;
            this.buttonGrab.Location = new System.Drawing.Point(5, 19);
            this.buttonGrab.Name = "buttonGrab";
            this.buttonGrab.Size = new System.Drawing.Size(85, 8);
            this.buttonGrab.TabIndex = 5;
            this.buttonGrab.Text = "Grab Image";
            this.buttonGrab.Click += new System.EventHandler(this.OnGrabImage);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.ForeColor = System.Drawing.Color.Maroon;
            this.buttonStart.Location = new System.Drawing.Point(85, 19);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(83, 8);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start Camera";
            this.buttonStart.Click += new System.EventHandler(this.OnStartRecord);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.ForeColor = System.Drawing.Color.Maroon;
            this.buttonStop.Location = new System.Drawing.Point(171, 19);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(52, 11);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "Stop Camera";
            this.buttonStop.Click += new System.EventHandler(this.OnStopRecord);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(-3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 20);
            this.button1.TabIndex = 8;
            this.button1.Text = "Live view";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Enabled = false;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(-3, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 22);
            this.button2.TabIndex = 9;
            this.button2.Text = "close Live view";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.numericUpDown4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDown5);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.numericUpDown3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(303, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 120);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OBJECT TRACKING";
            this.groupBox2.Visible = false;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown4.Enabled = false;
            this.numericUpDown4.Location = new System.Drawing.Point(143, 93);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown4.TabIndex = 11;
            this.numericUpDown4.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(104, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max W";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown5.Enabled = false;
            this.numericUpDown5.Location = new System.Drawing.Point(143, 74);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown5.TabIndex = 9;
            this.numericUpDown5.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label17.Location = new System.Drawing.Point(104, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Max H";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown3.Enabled = false;
            this.numericUpDown3.Location = new System.Drawing.Point(48, 93);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown3.TabIndex = 7;
            this.numericUpDown3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(4, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Min W";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(50, 74);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(4, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min H";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(75, 50);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(17, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Select Color";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(16, 36);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(16, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Range";
            // 
            // camerasCombo
            // 
            this.camerasCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camerasCombo.FormattingEnabled = true;
            this.camerasCombo.Location = new System.Drawing.Point(151, -8);
            this.camerasCombo.Name = "camerasCombo";
            this.camerasCombo.Size = new System.Drawing.Size(130, 21);
            this.camerasCombo.TabIndex = 17;
            this.camerasCombo.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radioButton1.Location = new System.Drawing.Point(2, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(90, 17);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Grab Image";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.buttonOpen);
            this.groupBox3.Controls.Add(this.buttonGetDescription);
            this.groupBox3.Controls.Add(this.buttonStart);
            this.groupBox3.Controls.Add(this.buttonGrab);
            this.groupBox3.Controls.Add(this.camerasCombo);
            this.groupBox3.Controls.Add(this.buttonStop);
            this.groupBox3.Controls.Add(this.buttonClose);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 63);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grab From PCO";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(95, -9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(65, 55);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LIVE FROM PCO";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(1, -2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(97, 57);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PCO IMG/VDO CAP.";
            this.groupBox5.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radioButton2.Location = new System.Drawing.Point(7, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(79, 17);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Live view";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(222, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 24);
            this.label1.TabIndex = 51;
            this.label1.Text = "Vibration Analysis of Civil Structure using Non-Destructive Method(NDM)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox8.Controls.Add(this.button10);
            this.groupBox8.Controls.Add(this.richTextBox3);
            this.groupBox8.Controls.Add(this.button11);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox8.Font = new System.Drawing.Font("High Tower Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.Firebrick;
            this.groupBox8.Location = new System.Drawing.Point(51, -10);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(65, 117);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Browse File";
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.Enabled = false;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button10.Location = new System.Drawing.Point(7, 76);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(49, 35);
            this.button10.TabIndex = 19;
            this.button10.Text = "Stop Video";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox3.Location = new System.Drawing.Point(13, 43);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(41, 26);
            this.richTextBox3.TabIndex = 18;
            this.richTextBox3.Text = "";
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button11.Location = new System.Drawing.Point(13, 9);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(35, 31);
            this.button11.TabIndex = 17;
            this.button11.Text = "...";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(0, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 47);
            this.label6.TabIndex = 60;
            this.label6.Text = "MOUSHUMI MEDHI(M.TECH  final year)Machine Vision Lab,Digital System Group,CSIR-CE" +
    "ERI,Pilani(Raj.)\r\n";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.button24);
            this.groupBox6.Controls.Add(this.button20);
            this.groupBox6.Controls.Add(this.radioButton8);
            this.groupBox6.Controls.Add(this.groupBox10);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.radioButton5);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Red;
            this.groupBox6.Location = new System.Drawing.Point(3, 56);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(122, 154);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "PLAY VIDEO FILE";
            this.groupBox6.Visible = false;
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // button24
            // 
            this.button24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button24.Location = new System.Drawing.Point(3, 113);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(51, 23);
            this.button24.TabIndex = 112;
            this.button24.Text = "Pixel measurement";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button20
            // 
            this.button20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button20.Location = new System.Drawing.Point(58, 113);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(53, 23);
            this.button20.TabIndex = 98;
            this.button20.Text = "Actual measurement";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // radioButton8
            // 
            this.radioButton8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton8.AutoSize = true;
            this.radioButton8.BackColor = System.Drawing.Color.Transparent;
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radioButton8.Location = new System.Drawing.Point(5, 44);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(40, 17);
            this.radioButton8.TabIndex = 109;
            this.radioButton8.Text = "eff";
            this.radioButton8.UseVisualStyleBackColor = false;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button19);
            this.groupBox10.Location = new System.Drawing.Point(7, 54);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(54, 65);
            this.groupBox10.TabIndex = 110;
            this.groupBox10.TabStop = false;
            // 
            // button19
            // 
            this.button19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button19.Location = new System.Drawing.Point(-4, 25);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(49, 27);
            this.button19.TabIndex = 108;
            this.button19.Text = " Play video";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Visible = false;
            this.button19.Click += new System.EventHandler(this.button19_Click_1);
            // 
            // radioButton5
            // 
            this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = System.Drawing.Color.Transparent;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radioButton5.Location = new System.Drawing.Point(1, 13);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(41, 17);
            this.radioButton5.TabIndex = 25;
            this.radioButton5.Text = "PP";
            this.radioButton5.UseVisualStyleBackColor = false;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chart1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineWidth = 3;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.Linen;
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisX.ScaleView.SmallScrollMinSize = 0.001D;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.SystemColors.ScrollBar;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.SystemColors.ControlDarkDark;
            chartArea1.AxisX.Title = "Time(in sec)";
            chartArea1.AxisX.ToolTip = "time axis(in second)";
            chartArea1.AxisY.InterlacedColor = System.Drawing.Color.LightYellow;
            chartArea1.AxisY.IsInterlaced = true;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.ScaleView.SmallScrollMinSize = 0.001D;
            chartArea1.AxisY.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisY.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisY.Title = "Amplitude";
            chartArea1.AxisY.ToolTip = "Vibration Amplitude";
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.SteelBlue;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.PeachPuff;
            legend1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(166, -11);
            this.chart1.Name = "chart1";
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DarkBlue;
            series1.LabelToolTip = "Vibration Signal";
            series1.Legend = "Legend1";
            series1.Name = "Vib. Signal";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DarkBlue;
            series2.IsValueShownAsLabel = true;
            series2.IsVisibleInLegend = false;
            series2.LabelToolTip = "real position";
            series2.Legend = "Legend1";
            series2.MarkerStep = 5;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series2.Name = "Vib Signal";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(248, 137);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Vibration Amplitude vs time graph";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chart7
            // 
            this.chart7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chart7.BackColor = System.Drawing.Color.SlateBlue;
            this.chart7.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.AxisX.InterlacedColor = System.Drawing.Color.Linen;
            chartArea2.AxisX.IsInterlaced = true;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea2.AxisX.ScrollBar.BackColor = System.Drawing.SystemColors.ScrollBar;
            chartArea2.AxisX.ScrollBar.ButtonColor = System.Drawing.SystemColors.ControlDarkDark;
            chartArea2.AxisX.Title = "Time(in sec)";
            chartArea2.AxisX.ToolTip = "time(in seconds)";
            chartArea2.AxisY.InterlacedColor = System.Drawing.Color.LightYellow;
            chartArea2.AxisY.IsInterlaced = true;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.SelectionColor = System.Drawing.Color.LightSteelBlue;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.CursorY.SelectionColor = System.Drawing.Color.LightSteelBlue;
            chartArea2.Name = "ChartArea1";
            this.chart7.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            this.chart7.Legends.Add(legend2);
            this.chart7.Location = new System.Drawing.Point(555, 0);
            this.chart7.Name = "chart7";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Navy;
            series3.Legend = "Legend1";
            series3.Name = "Displacement";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Fuchsia;
            series4.Legend = "Legend1";
            series4.Name = "Velocity";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.LimeGreen;
            series5.Legend = "Legend1";
            series5.Name = "Acceleration";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Navy;
            series6.Legend = "Legend1";
            series6.Name = "displacement";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Fuchsia;
            series7.Legend = "Legend1";
            series7.Name = "velocity";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Lime;
            series8.Legend = "Legend1";
            series8.Name = "acceleration";
            this.chart7.Series.Add(series3);
            this.chart7.Series.Add(series4);
            this.chart7.Series.Add(series5);
            this.chart7.Series.Add(series6);
            this.chart7.Series.Add(series7);
            this.chart7.Series.Add(series8);
            this.chart7.Size = new System.Drawing.Size(266, 135);
            this.chart7.TabIndex = 78;
            this.chart7.Text = "chart7";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Vibration parameters vs time graphs";
            this.chart7.Titles.Add(title2);
            this.chart7.Click += new System.EventHandler(this.chart7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("High Tower Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(392, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 15);
            this.label8.TabIndex = 72;
            this.label8.Text = "Vibrating Object Detection";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("High Tower Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(669, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(294, 15);
            this.label9.TabIndex = 73;
            this.label9.Text = "Motion Tracking of Structure under Vibration";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("High Tower Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(39, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 15);
            this.label7.TabIndex = 74;
            this.label7.Text = "Original View Of Vibrating  Object";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button16
            // 
            this.button16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button16.Location = new System.Drawing.Point(184, 135);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(50, 28);
            this.button16.TabIndex = 77;
            this.button16.Text = "Accelerate Process";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Visible = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button9.Location = new System.Drawing.Point(421, 155);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 20);
            this.button9.TabIndex = 79;
            this.button9.Text = "INFERENCE";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button4.Location = new System.Drawing.Point(125, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 26);
            this.button4.TabIndex = 80;
            this.button4.Text = "Store Vibrations";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(807, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 81;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Location = new System.Drawing.Point(807, 25);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 82;
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Location = new System.Drawing.Point(807, 38);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 83;
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.Visible = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(807, 52);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 84;
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.Visible = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.SlateBlue;
            this.label11.Font = new System.Drawing.Font("High Tower Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(737, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 85;
            this.label11.Text = "Show all";
            this.label11.Visible = false;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(0, 531);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(944, 0);
            this.label12.TabIndex = 86;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(258, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 103);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Maroon;
            this.button7.Location = new System.Drawing.Point(40, 7);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(41, 41);
            this.button7.TabIndex = 58;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Location = new System.Drawing.Point(3, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 39);
            this.button5.TabIndex = 91;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(852, 550);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 0);
            this.label14.TabIndex = 89;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Salmon;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenToolStripMenuItem,
            this.yttyfToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.userInputToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1317, 20);
            this.menuStrip1.TabIndex = 92;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileOpenToolStripMenuItem
            // 
            this.fileOpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.StopToolStripMenuItem});
            this.fileOpenToolStripMenuItem.Name = "fileOpenToolStripMenuItem";
            this.fileOpenToolStripMenuItem.Size = new System.Drawing.Size(52, 16);
            this.fileOpenToolStripMenuItem.Text = "Media";
            this.fileOpenToolStripMenuItem.Click += new System.EventHandler(this.fileOpenToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.StopToolStripMenuItem.Enabled = false;
            this.StopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripMenuItem.Image")));
            this.StopToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.StopToolStripMenuItem.Text = "Stop";
            this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // yttyfToolStripMenuItem
            // 
            this.yttyfToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frameCountToolStripMenuItem,
            this.videoDurationToolStripMenuItem,
            this.toolStripSeparator1,
            this.imageSizeToolStripMenuItem,
            this.toolStripMenuItem2});
            this.yttyfToolStripMenuItem.Name = "yttyfToolStripMenuItem";
            this.yttyfToolStripMenuItem.Size = new System.Drawing.Size(40, 16);
            this.yttyfToolStripMenuItem.Text = "Info";
            this.yttyfToolStripMenuItem.Click += new System.EventHandler(this.yttyfToolStripMenuItem_Click);
            // 
            // frameCountToolStripMenuItem
            // 
            this.frameCountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentToolStripMenuItem,
            this.totalToolStripMenuItem});
            this.frameCountToolStripMenuItem.Name = "frameCountToolStripMenuItem";
            this.frameCountToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.frameCountToolStripMenuItem.Text = "Frame count";
            this.frameCountToolStripMenuItem.Click += new System.EventHandler(this.frameCountToolStripMenuItem_Click);
            // 
            // currentToolStripMenuItem
            // 
            this.currentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox7});
            this.currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            this.currentToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.currentToolStripMenuItem.Text = "Current";
            this.currentToolStripMenuItem.Click += new System.EventHandler(this.currentToolStripMenuItem_Click);
            // 
            // toolStripTextBox7
            // 
            this.toolStripTextBox7.Name = "toolStripTextBox7";
            this.toolStripTextBox7.ReadOnly = true;
            this.toolStripTextBox7.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox7.Click += new System.EventHandler(this.toolStripTextBox7_Click);
            // 
            // totalToolStripMenuItem
            // 
            this.totalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox8});
            this.totalToolStripMenuItem.Enabled = false;
            this.totalToolStripMenuItem.Name = "totalToolStripMenuItem";
            this.totalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.totalToolStripMenuItem.Text = "Total";
            this.totalToolStripMenuItem.Click += new System.EventHandler(this.totalToolStripMenuItem_Click);
            // 
            // toolStripTextBox8
            // 
            this.toolStripTextBox8.Name = "toolStripTextBox8";
            this.toolStripTextBox8.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox8.Click += new System.EventHandler(this.toolStripTextBox8_Click);
            // 
            // videoDurationToolStripMenuItem
            // 
            this.videoDurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hmsToolStripMenuItem,
            this.hmsroundedToolStripMenuItem,
            this.millisecsToolStripMenuItem,
            this.secsToolStripMenuItem,
            this.minsToolStripMenuItem,
            this.hoursToolStripMenuItem});
            this.videoDurationToolStripMenuItem.Name = "videoDurationToolStripMenuItem";
            this.videoDurationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.videoDurationToolStripMenuItem.Text = "Video Duration";
            this.videoDurationToolStripMenuItem.Click += new System.EventHandler(this.videoDurationToolStripMenuItem_Click);
            // 
            // hmsToolStripMenuItem
            // 
            this.hmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.hmsToolStripMenuItem.Name = "hmsToolStripMenuItem";
            this.hmsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.hmsToolStripMenuItem.Text = "h:m:s";
            this.hmsToolStripMenuItem.Click += new System.EventHandler(this.hmsToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.ToolTipText = "Video Duration in h:m:s";
            // 
            // hmsroundedToolStripMenuItem
            // 
            this.hmsroundedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.hmsroundedToolStripMenuItem.Name = "hmsroundedToolStripMenuItem";
            this.hmsroundedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.hmsroundedToolStripMenuItem.Text = "h:m:s (rounded)";
            this.hmsroundedToolStripMenuItem.Click += new System.EventHandler(this.hmsroundedToolStripMenuItem_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.ToolTipText = "Video Duration in h:m:s after rounding off";
            // 
            // millisecsToolStripMenuItem
            // 
            this.millisecsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox3});
            this.millisecsToolStripMenuItem.Name = "millisecsToolStripMenuItem";
            this.millisecsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.millisecsToolStripMenuItem.Text = "millisecs";
            this.millisecsToolStripMenuItem.Click += new System.EventHandler(this.millisecsToolStripMenuItem_Click);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            // 
            // secsToolStripMenuItem
            // 
            this.secsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox4});
            this.secsToolStripMenuItem.Name = "secsToolStripMenuItem";
            this.secsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.secsToolStripMenuItem.Text = "secs";
            this.secsToolStripMenuItem.Click += new System.EventHandler(this.secsToolStripMenuItem_Click);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 23);
            // 
            // minsToolStripMenuItem
            // 
            this.minsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox5});
            this.minsToolStripMenuItem.Name = "minsToolStripMenuItem";
            this.minsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.minsToolStripMenuItem.Text = "mins";
            this.minsToolStripMenuItem.Click += new System.EventHandler(this.minsToolStripMenuItem_Click);
            // 
            // toolStripTextBox5
            // 
            this.toolStripTextBox5.Name = "toolStripTextBox5";
            this.toolStripTextBox5.Size = new System.Drawing.Size(100, 23);
            // 
            // hoursToolStripMenuItem
            // 
            this.hoursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox6});
            this.hoursToolStripMenuItem.Name = "hoursToolStripMenuItem";
            this.hoursToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.hoursToolStripMenuItem.Text = "hours";
            this.hoursToolStripMenuItem.Click += new System.EventHandler(this.hoursToolStripMenuItem_Click);
            // 
            // toolStripTextBox6
            // 
            this.toolStripTextBox6.Name = "toolStripTextBox6";
            this.toolStripTextBox6.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // imageSizeToolStripMenuItem
            // 
            this.imageSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widthToolStripMenuItem,
            this.heightToolStripMenuItem});
            this.imageSizeToolStripMenuItem.Name = "imageSizeToolStripMenuItem";
            this.imageSizeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.imageSizeToolStripMenuItem.Text = "Image Size";
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox9});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // toolStripTextBox9
            // 
            this.toolStripTextBox9.Name = "toolStripTextBox9";
            this.toolStripTextBox9.ReadOnly = true;
            this.toolStripTextBox9.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox9.Text = "640";
            // 
            // heightToolStripMenuItem
            // 
            this.heightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox10});
            this.heightToolStripMenuItem.Name = "heightToolStripMenuItem";
            this.heightToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.heightToolStripMenuItem.Text = "Height";
            // 
            // toolStripTextBox10
            // 
            this.toolStripTextBox10.Name = "toolStripTextBox10";
            this.toolStripTextBox10.ReadOnly = true;
            this.toolStripTextBox10.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox10.Text = "480";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox14});
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem2.Text = "Frame rate";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripTextBox14
            // 
            this.toolStripTextBox14.Name = "toolStripTextBox14";
            this.toolStripTextBox14.Size = new System.Drawing.Size(100, 23);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataPointsToolStripMenuItem,
            this.toolStripMenuItem4});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 16);
            this.viewToolStripMenuItem.Text = "view";
            // 
            // dataPointsToolStripMenuItem
            // 
            this.dataPointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amplitudeToolStripMenuItem,
            this.parametersToolStripMenuItem});
            this.dataPointsToolStripMenuItem.Name = "dataPointsToolStripMenuItem";
            this.dataPointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataPointsToolStripMenuItem.Text = "data points";
            // 
            // amplitudeToolStripMenuItem
            // 
            this.amplitudeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticleToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.amplitudeToolStripMenuItem.Name = "amplitudeToolStripMenuItem";
            this.amplitudeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.amplitudeToolStripMenuItem.Text = "Amplitude";
            this.amplitudeToolStripMenuItem.Click += new System.EventHandler(this.amplitudeToolStripMenuItem_Click);
            // 
            // verticleToolStripMenuItem
            // 
            this.verticleToolStripMenuItem.Name = "verticleToolStripMenuItem";
            this.verticleToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.verticleToolStripMenuItem.Text = "verticle";
            this.verticleToolStripMenuItem.Click += new System.EventHandler(this.verticleToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.horizontalToolStripMenuItem.Text = "horizontal";
            // 
            // parametersToolStripMenuItem
            // 
            this.parametersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displacementToolStripMenuItem,
            this.velocityToolStripMenuItem,
            this.accelerationToolStripMenuItem});
            this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
            this.parametersToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.parametersToolStripMenuItem.Text = "Parameters";
            this.parametersToolStripMenuItem.Click += new System.EventHandler(this.parametersToolStripMenuItem_Click);
            // 
            // displacementToolStripMenuItem
            // 
            this.displacementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticleToolStripMenuItem1,
            this.horizontalToolStripMenuItem1});
            this.displacementToolStripMenuItem.Name = "displacementToolStripMenuItem";
            this.displacementToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.displacementToolStripMenuItem.Text = "Displacement";
            // 
            // verticleToolStripMenuItem1
            // 
            this.verticleToolStripMenuItem1.Name = "verticleToolStripMenuItem1";
            this.verticleToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.verticleToolStripMenuItem1.Text = "Verticle";
            // 
            // horizontalToolStripMenuItem1
            // 
            this.horizontalToolStripMenuItem1.Name = "horizontalToolStripMenuItem1";
            this.horizontalToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem1.Text = "Horizontal";
            // 
            // velocityToolStripMenuItem
            // 
            this.velocityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticleToolStripMenuItem2,
            this.horizontalToolStripMenuItem2});
            this.velocityToolStripMenuItem.Name = "velocityToolStripMenuItem";
            this.velocityToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.velocityToolStripMenuItem.Text = "Velocity";
            // 
            // verticleToolStripMenuItem2
            // 
            this.verticleToolStripMenuItem2.Name = "verticleToolStripMenuItem2";
            this.verticleToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.verticleToolStripMenuItem2.Text = "Verticle";
            // 
            // horizontalToolStripMenuItem2
            // 
            this.horizontalToolStripMenuItem2.Name = "horizontalToolStripMenuItem2";
            this.horizontalToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem2.Text = "Horizontal";
            // 
            // accelerationToolStripMenuItem
            // 
            this.accelerationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticleToolStripMenuItem3,
            this.horizontalToolStripMenuItem3});
            this.accelerationToolStripMenuItem.Name = "accelerationToolStripMenuItem";
            this.accelerationToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.accelerationToolStripMenuItem.Text = "Acceleration";
            // 
            // verticleToolStripMenuItem3
            // 
            this.verticleToolStripMenuItem3.Name = "verticleToolStripMenuItem3";
            this.verticleToolStripMenuItem3.Size = new System.Drawing.Size(129, 22);
            this.verticleToolStripMenuItem3.Text = "Verticle";
            // 
            // horizontalToolStripMenuItem3
            // 
            this.horizontalToolStripMenuItem3.Name = "horizontalToolStripMenuItem3";
            this.horizontalToolStripMenuItem3.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem3.Text = "Horizontal";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // userInputToolStripMenuItem
            // 
            this.userInputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.framesSkippedToolStripMenuItem});
            this.userInputToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.userInputToolStripMenuItem.Name = "userInputToolStripMenuItem";
            this.userInputToolStripMenuItem.Size = new System.Drawing.Size(73, 16);
            this.userInputToolStripMenuItem.Text = "User Input";
            this.userInputToolStripMenuItem.ToolTipText = "No. of frames to be skipped ";
            // 
            // framesSkippedToolStripMenuItem
            // 
            this.framesSkippedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.pCOToolStripMenuItem});
            this.framesSkippedToolStripMenuItem.Name = "framesSkippedToolStripMenuItem";
            this.framesSkippedToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.framesSkippedToolStripMenuItem.Text = "Frames skipped";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox11,
            this.oKToolStripMenuItem});
            this.videoToolStripMenuItem.Enabled = false;
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // toolStripTextBox11
            // 
            this.toolStripTextBox11.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripTextBox11.Name = "toolStripTextBox11";
            this.toolStripTextBox11.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox11_KeyPress_1);
            // 
            // oKToolStripMenuItem
            // 
            this.oKToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.oKToolStripMenuItem.Enabled = false;
            this.oKToolStripMenuItem.Name = "oKToolStripMenuItem";
            this.oKToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.oKToolStripMenuItem.Text = "OK";
            this.oKToolStripMenuItem.Click += new System.EventHandler(this.oKToolStripMenuItem_Click_1);
            // 
            // pCOToolStripMenuItem
            // 
            this.pCOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox12,
            this.oKToolStripMenuItem1});
            this.pCOToolStripMenuItem.Enabled = false;
            this.pCOToolStripMenuItem.Name = "pCOToolStripMenuItem";
            this.pCOToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.pCOToolStripMenuItem.Text = "PCO";
            // 
            // toolStripTextBox12
            // 
            this.toolStripTextBox12.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripTextBox12.Name = "toolStripTextBox12";
            this.toolStripTextBox12.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox12_KeyPress);
            // 
            // oKToolStripMenuItem1
            // 
            this.oKToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.oKToolStripMenuItem1.Enabled = false;
            this.oKToolStripMenuItem1.Name = "oKToolStripMenuItem1";
            this.oKToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.oKToolStripMenuItem1.Text = "OK";
            this.oKToolStripMenuItem1.Click += new System.EventHandler(this.oKToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(96, 16);
            this.toolStripMenuItem3.Text = "Denoise Signal";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(131, 16);
            this.toolStripMenuItem5.Text = "View Denoised Signal";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Harlow Solid Italic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ScrollBar;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.dateTimePicker1.Font = new System.Drawing.Font("High Tower Text", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(812, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(83, 20);
            this.dateTimePicker1.TabIndex = 93;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator9,
            this.toolStripButton3,
            this.toolStripSeparator10,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(811, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(32, 301);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 97;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            this.toolStrip1.Visible = false;
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked_1);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(30, 6);
            this.toolStripSeparator.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relativePixelsToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripSeparator5,
            this.toolStripSeparator4,
            this.actualToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolStripMenuItem1,
            this.toolStripSeparator6,
            this.toolStripTextBox13,
            this.oKToolStripMenuItem2,
            this.toolStripSeparator7});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(30, 83);
            this.toolStripDropDownButton1.Text = "Data Display";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripDropDownButton1.ToolTipText = "graph plotting in terms of pixel coordinates or actual  measurement";
            this.toolStripDropDownButton1.Visible = false;
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // relativePixelsToolStripMenuItem
            // 
            this.relativePixelsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.relativePixelsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("relativePixelsToolStripMenuItem.Image")));
            this.relativePixelsToolStripMenuItem.Name = "relativePixelsToolStripMenuItem";
            this.relativePixelsToolStripMenuItem.Size = new System.Drawing.Size(355, 26);
            this.relativePixelsToolStripMenuItem.Text = "Relative pixels(default)";
            this.relativePixelsToolStripMenuItem.Click += new System.EventHandler(this.relativePixelsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.LawnGreen;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(352, 12);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(352, 12);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.Gray;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(352, 12);
            // 
            // actualToolStripMenuItem
            // 
            this.actualToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.actualToolStripMenuItem.CheckOnClick = true;
            this.actualToolStripMenuItem.Name = "actualToolStripMenuItem";
            this.actualToolStripMenuItem.Size = new System.Drawing.Size(355, 26);
            this.actualToolStripMenuItem.Text = "Actual Measurement";
            this.actualToolStripMenuItem.Click += new System.EventHandler(this.actualToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(352, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(355, 26);
            this.toolStripMenuItem1.Text = "Camera at a distance of 31 m from the target(default)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(352, 6);
            // 
            // toolStripTextBox13
            // 
            this.toolStripTextBox13.AutoSize = false;
            this.toolStripTextBox13.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolStripTextBox13.Enabled = false;
            this.toolStripTextBox13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox13.Name = "toolStripTextBox13";
            this.toolStripTextBox13.Size = new System.Drawing.Size(270, 23);
            this.toolStripTextBox13.Text = "Enter distance of object from camera(in meter) :";
            this.toolStripTextBox13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox13_KeyPress);
            this.toolStripTextBox13.Click += new System.EventHandler(this.toolStripTextBox13_Click_1);
            // 
            // oKToolStripMenuItem2
            // 
            this.oKToolStripMenuItem2.Enabled = false;
            this.oKToolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oKToolStripMenuItem2.Name = "oKToolStripMenuItem2";
            this.oKToolStripMenuItem2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.oKToolStripMenuItem2.Size = new System.Drawing.Size(355, 26);
            this.oKToolStripMenuItem2.Text = "OK";
            this.oKToolStripMenuItem2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.oKToolStripMenuItem2.Click += new System.EventHandler(this.oKToolStripMenuItem2_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(352, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(30, 6);
            this.toolStripSeparator2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(30, 20);
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(30, 6);
            this.toolStripSeparator9.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ForeColor = System.Drawing.Color.Red;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(30, 95);
            this.toolStripButton3.Text = "Denoised Signal";
            this.toolStripButton3.ToolTipText = "Display Denoised Signal";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(30, 6);
            this.toolStripSeparator10.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.Fuchsia;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(86, 19);
            this.toolStripButton1.Text = "Actual display";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButton4);
            this.groupBox7.Controls.Add(this.radioButton7);
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.ForeColor = System.Drawing.Color.Red;
            this.groupBox7.Location = new System.Drawing.Point(66, -6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(79, 61);
            this.groupBox7.TabIndex = 98;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "mode";
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.Transparent;
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.ForeColor = System.Drawing.Color.Yellow;
            this.radioButton4.Location = new System.Drawing.Point(6, 18);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(68, 17);
            this.radioButton4.TabIndex = 100;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Vertical";
            this.radioButton4.UseVisualStyleBackColor = false;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged_1);
            // 
            // radioButton7
            // 
            this.radioButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton7.AutoSize = true;
            this.radioButton7.BackColor = System.Drawing.Color.Transparent;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.ForeColor = System.Drawing.Color.Yellow;
            this.radioButton7.Location = new System.Drawing.Point(6, 42);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(64, 17);
            this.radioButton7.TabIndex = 99;
            this.radioButton7.Text = "Lateral";
            this.radioButton7.UseVisualStyleBackColor = false;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(1133, 875);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(177, 101);
            this.groupBox9.TabIndex = 101;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Analysis Mode";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(415, -6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(134, 212);
            this.pictureBox5.TabIndex = 99;
            this.pictureBox5.TabStop = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.ForeColor = System.Drawing.Color.Snow;
            this.label16.Location = new System.Drawing.Point(442, 325);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 0);
            this.label16.TabIndex = 93;
            this.label16.Text = "Newly train";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(446, 309);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 0);
            this.label15.TabIndex = 92;
            this.label15.Text = "already trained";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = System.Drawing.Color.Black;
            this.radioButton6.Location = new System.Drawing.Point(426, 329);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(14, 13);
            this.radioButton6.TabIndex = 91;
            this.radioButton6.UseVisualStyleBackColor = false;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Black;
            this.radioButton3.Location = new System.Drawing.Point(427, 314);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 90;
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.LightBlue;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(415, 175);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(134, 26);
            this.richTextBox1.TabIndex = 80;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.BackColor = System.Drawing.Color.DarkGray;
            this.button12.Location = new System.Drawing.Point(423, 131);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(90, 26);
            this.button12.TabIndex = 81;
            this.button12.Text = "READ VIBRATION SIGNAL ";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Colonna MT", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(420, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 18);
            this.label10.TabIndex = 77;
            this.label10.Text = "Please wait ...";
            this.label10.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(415, 110);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(80, 20);
            this.progressBar1.TabIndex = 76;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.BackColor = System.Drawing.Color.LightGray;
            this.button15.Font = new System.Drawing.Font("High Tower Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.DarkViolet;
            this.button15.Location = new System.Drawing.Point(415, 64);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(77, 25);
            this.button15.TabIndex = 75;
            this.button15.Text = "SHM";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Visible = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Location = new System.Drawing.Point(1911, 182);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(0, 0);
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Location = new System.Drawing.Point(640, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(320, 256);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox2.Location = new System.Drawing.Point(319, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 256);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(421, 292);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 23);
            this.label18.TabIndex = 100;
            this.label18.Text = "SHM";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(666, 135);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(54, 35);
            this.button8.TabIndex = 101;
            this.button8.Text = "just for test";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.ForeColor = System.Drawing.Color.Red;
            this.button13.Location = new System.Drawing.Point(555, 139);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(42, 27);
            this.button13.TabIndex = 102;
            this.button13.Text = "FA";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Visible = false;
            this.button13.Click += new System.EventHandler(this.button13_Click_1);
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button18.ForeColor = System.Drawing.Color.Red;
            this.button18.Location = new System.Drawing.Point(603, 139);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(60, 27);
            this.button18.TabIndex = 106;
            this.button18.Text = "SMA";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Visible = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // timer5
            // 
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(726, 141);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 24);
            this.button6.TabIndex = 107;
            this.button6.Text = "Denoising";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.Location = new System.Drawing.Point(771, 148);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 108;
            this.checkBox5.UseVisualStyleBackColor = false;
            this.checkBox5.Visible = false;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(4, 280);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.button29);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox17);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox16);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button9);
            this.splitContainer1.Panel1.Controls.Add(this.button18);
            this.splitContainer1.Panel1.Controls.Add(this.button6);
            this.splitContainer1.Panel1.Controls.Add(this.button8);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox3);
            this.splitContainer1.Panel1.Controls.Add(this.button12);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox2);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox5);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.button13);
            this.splitContainer1.Panel1.Controls.Add(this.chart7);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button16);
            this.splitContainer1.Panel1.Controls.Add(this.button15);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox5);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel2.Controls.Add(this.button25);
            this.splitContainer1.Panel2.Controls.Add(this.button21);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox14);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox12);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox11);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox7);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1892, 760);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 109;
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(604, 166);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(42, 29);
            this.button29.TabIndex = 127;
            this.button29.Text = "button29";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.White;
            this.groupBox17.Controls.Add(this.richTextBox5);
            this.groupBox17.Controls.Add(this.button26);
            this.groupBox17.Controls.Add(this.button27);
            this.groupBox17.Controls.Add(this.button28);
            this.groupBox17.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.ForeColor = System.Drawing.Color.Red;
            this.groupBox17.Location = new System.Drawing.Point(828, 119);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(99, 99);
            this.groupBox17.TabIndex = 126;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "FREE FALL";
            this.groupBox17.Visible = false;
            // 
            // richTextBox5
            // 
            this.richTextBox5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox5.Location = new System.Drawing.Point(6, 72);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(87, 24);
            this.richTextBox5.TabIndex = 119;
            this.richTextBox5.Text = "";
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button26.Location = new System.Drawing.Point(6, 47);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(93, 24);
            this.button26.TabIndex = 118;
            this.button26.Text = "displacement";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button27.Location = new System.Drawing.Point(63, 20);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(48, 27);
            this.button27.TabIndex = 117;
            this.button27.Text = "stop";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button28.Location = new System.Drawing.Point(6, 20);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(55, 28);
            this.button28.TabIndex = 116;
            this.button28.Text = "start";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.White;
            this.groupBox16.Controls.Add(this.richTextBox9);
            this.groupBox16.Controls.Add(this.button23);
            this.groupBox16.Controls.Add(this.button22);
            this.groupBox16.Controls.Add(this.button17);
            this.groupBox16.Location = new System.Drawing.Point(827, 3);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(100, 119);
            this.groupBox16.TabIndex = 125;
            this.groupBox16.TabStop = false;
            this.groupBox16.Visible = false;
            // 
            // richTextBox9
            // 
            this.richTextBox9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox9.Location = new System.Drawing.Point(6, 81);
            this.richTextBox9.Name = "richTextBox9";
            this.richTextBox9.Size = new System.Drawing.Size(88, 29);
            this.richTextBox9.TabIndex = 119;
            this.richTextBox9.Text = "";
            // 
            // button23
            // 
            this.button23.Enabled = false;
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button23.Location = new System.Drawing.Point(6, 47);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(76, 28);
            this.button23.TabIndex = 118;
            this.button23.Text = "displacement";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button22
            // 
            this.button22.Enabled = false;
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button22.Location = new System.Drawing.Point(54, 15);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(46, 28);
            this.button22.TabIndex = 117;
            this.button22.Text = "stop";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button17.Location = new System.Drawing.Point(6, 15);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(42, 28);
            this.button17.TabIndex = 116;
            this.button17.Text = "start";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click_2);
            // 
            // button25
            // 
            this.button25.Enabled = false;
            this.button25.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button25.Location = new System.Drawing.Point(812, 1);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(97, 74);
            this.button25.TabIndex = 124;
            this.button25.Text = "Remove\r\nnoisy spikes";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Silver;
            this.button21.Enabled = false;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button21.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button21.Location = new System.Drawing.Point(714, 6);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(92, 122);
            this.button21.TabIndex = 123;
            this.button21.Text = "Select dimension of target object at current point";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.groupBox15);
            this.groupBox14.Controls.Add(this.radioButton10);
            this.groupBox14.Controls.Add(this.radioButton9);
            this.groupBox14.ForeColor = System.Drawing.Color.Red;
            this.groupBox14.Location = new System.Drawing.Point(3, -3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(57, 61);
            this.groupBox14.TabIndex = 122;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Real";
            // 
            // groupBox15
            // 
            this.groupBox15.Location = new System.Drawing.Point(1133, 875);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(177, 101);
            this.groupBox15.TabIndex = 101;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Analysis Mode";
            // 
            // radioButton10
            // 
            this.radioButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton10.AutoSize = true;
            this.radioButton10.BackColor = System.Drawing.Color.Transparent;
            this.radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton10.ForeColor = System.Drawing.Color.Yellow;
            this.radioButton10.Location = new System.Drawing.Point(3, 40);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(42, 17);
            this.radioButton10.TabIndex = 120;
            this.radioButton10.Text = "DS";
            this.radioButton10.UseVisualStyleBackColor = false;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton9.AutoSize = true;
            this.radioButton9.BackColor = System.Drawing.Color.Transparent;
            this.radioButton9.Checked = true;
            this.radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton9.ForeColor = System.Drawing.Color.Yellow;
            this.radioButton9.Location = new System.Drawing.Point(6, 18);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(42, 17);
            this.radioButton9.TabIndex = 121;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "TD";
            this.radioButton9.UseVisualStyleBackColor = false;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.White;
            this.groupBox12.Controls.Add(this.richTextBox8);
            this.groupBox12.Controls.Add(this.richTextBox4);
            this.groupBox12.Controls.Add(this.label29);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.ForeColor = System.Drawing.Color.Red;
            this.groupBox12.Location = new System.Drawing.Point(498, 10);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(216, 120);
            this.groupBox12.TabIndex = 115;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "TARGET DIMENSION";
            // 
            // richTextBox8
            // 
            this.richTextBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox8.Location = new System.Drawing.Point(127, 78);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.Size = new System.Drawing.Size(83, 31);
            this.richTextBox8.TabIndex = 114;
            this.richTextBox8.Text = "";
            this.richTextBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox8_KeyPress);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox4.Location = new System.Drawing.Point(127, 25);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(83, 31);
            this.richTextBox4.TabIndex = 113;
            this.richTextBox4.Text = "";
            this.richTextBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox4_KeyPress);
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label29.Location = new System.Drawing.Point(6, 67);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(128, 38);
            this.label29.TabIndex = 112;
            this.label29.Text = "Breadth of the object(in cm)";
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label28.Location = new System.Drawing.Point(8, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(113, 38);
            this.label28.TabIndex = 111;
            this.label28.Text = "Length of the object(in cm)";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.White;
            this.groupBox11.Controls.Add(this.richTextBox2);
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Enabled = false;
            this.groupBox11.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.Red;
            this.groupBox11.Location = new System.Drawing.Point(151, 4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(98, 82);
            this.groupBox11.TabIndex = 110;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "DS";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(6, 62);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(77, 20);
            this.richTextBox2.TabIndex = 105;
            this.richTextBox2.Text = "";
            this.richTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox2_KeyPress);
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label27.Location = new System.Drawing.Point(7, 21);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(110, 38);
            this.label27.TabIndex = 104;
            this.label27.Text = "Enter distance (m)";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 670);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightCoral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion

    /// <summary>
    /// </summary>
    [STAThread]
    static void Main() 
    {
     Application.Run(new Form1());
      Application.Run(new Form());
    }

    int cameraHandle = 0;//IntPtr.Zero;
    int convertHandle = 0;
    int convertDialog = 0;
    private const int WM_APPp100 = 0x8000 + 100;
    int bufwidth = 0, bufheight = 0;
    byte[] imagedata;
    UInt16[] wbuf;

    PCO_Description pcoDescr;

    private unsafe void OnOpenCamera(object sender, EventArgs e)
    {
        int err = 0;
      ushort boardNum = 0;

      // Verify board number validity
      // Open a handle to the camera
      err = PCO_SDK_LibWrapper.PCO_OpenCamera(ref cameraHandle, boardNum);
      if (err == 0)
      {
        buttonStart.Enabled = true;
        buttonStop.Enabled = true;
        buttonGetDescription.Enabled = true;
        buttonOpen.Enabled = false;
        buttonClose.Enabled = true;


        Setupconvert();
      }
    }

    private unsafe void Setupconvert()
    {
      PCO_ConvertStructures.PCO_SensorInfo strsensorinf = new PCO_ConvertStructures.PCO_SensorInfo();
      PCO_ConvertStructures.PCO_Display strDisplay = new PCO_ConvertStructures.PCO_Display();
      strsensorinf.wSize = (ushort)Marshal.SizeOf(strsensorinf);
      strDisplay.wSize = (ushort)Marshal.SizeOf(strDisplay);
      strsensorinf.wDummy = 0;
      strsensorinf.iConversionFactor = 0;
      strsensorinf.iDataBits = 10; //12 for pixelfly
      strsensorinf.iSensorInfoBits = 1; //????
      strsensorinf.iDarkOffset = 32;//pixel fly 100;
      strsensorinf.dwzzDummy0 = 0; 
       strsensorinf.strColorCoeff.da11 = 2.238938052;
      strsensorinf.strColorCoeff.da12 = -.008849559;
      strsensorinf.strColorCoeff.da13 = -.699115043;
      strsensorinf.strColorCoeff.da21 = -.504424779; 
      strsensorinf.strColorCoeff.da22 = 2.061946901;
      strsensorinf.strColorCoeff.da23 = -1.088495573;
      strsensorinf.strColorCoeff.da31 =  -.557522121;
      strsensorinf.strColorCoeff.da32 =  -.32743363;
      strsensorinf.strColorCoeff.da33 = 1.88495575;
      strsensorinf.iCamNum = 0;
      strsensorinf.hCamera = cameraHandle;

      int errorCode;
      /* We created a pointer to a convert object here */
      errorCode = PCO_Convert_LibWrapper.PCO_ConvertCreate(ref convertHandle, ref strsensorinf, PCO_Convert_LibWrapper.PCO_COLOR_CONVERT);

      PCO_ConvertStructures.PCO_Convert pcoConv = new PCO_ConvertStructures.PCO_Convert();;

      pcoConv.wSize = (ushort)Marshal.SizeOf(pcoConv); 
      errorCode = PCOConvertDll.PCO_Convert_LibWrapper.PCO_ConvertGet(convertHandle, ref pcoConv);
      pcoConv.wSize = (ushort)Marshal.SizeOf(pcoConv);

      IntPtr debugIntPtr = new IntPtr(convertHandle);
      PCO_ConvertStructures.PCO_Convert pcoConvertlocal = (PCO_ConvertStructures.PCO_Convert)Marshal.PtrToStructure(debugIntPtr, typeof(PCO_ConvertStructures.PCO_Convert));
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == WM_APPp100)
      {
        PCO_ConvertStructures.PCO_ConvDlg_Message pcnv = new PCO_ConvertStructures.PCO_ConvDlg_Message();
        Type ty = pcnv.GetType();
        pcnv = (PCO_ConvertStructures.PCO_ConvDlg_Message)m.GetLParam(ty);

        if (pcnv.wCommand == PCO_ConvertStructures.PCO_CNV_DLG_CMD_WHITEBALANCE)
        { // Do white balance
        }
        if (pcnv.wCommand == PCO_ConvertStructures.PCO_CNV_DLG_CMD_UPDATE)
        { // Do update
        }
        if (pcnv.wCommand == PCO_ConvertStructures.PCO_CNV_DLG_CMD_CLOSING)
        { // Do update
          convertDialog = 0;
        }
      }
      base.WndProc(ref m);
    }

    private unsafe void OnGetDescription(object sender, System.EventArgs e)
    {
      pcoDescr.wSize = (ushort) sizeof(PCO_Description);
      int err = 0;

      err = PCO_SDK_LibWrapper.PCO_GetCameraDescription(cameraHandle, ref pcoDescr);
    }

    private void OnCloseCamera(object sender, System.EventArgs e)
    {
      CloseCamera();
    }
    private void CloseCamera()
    {
      int err = 0;
      if (convertDialog != 0)
        PCO_Convert_LibWrapper.PCO_CloseConvertDialog(convertDialog);

      if (convertHandle != 0)
      {
        PCO_Convert_LibWrapper.PCO_ConvertDelete(convertHandle);
      }

      err = PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);

      err = PCO_SDK_LibWrapper.PCO_CloseCamera(cameraHandle);

      cameraHandle = 0;
      buttonGrab.Enabled = false;
      buttonStart.Enabled = false;
      buttonStop.Enabled = false;
      buttonGetDescription.Enabled = false;
      buttonClose.Enabled = false;
      buttonOpen.Enabled = true;
    }

    private unsafe void OnGrabImage(object sender, EventArgs e)
    {
      pcoDescr.wSize = (ushort)sizeof(PCO_Description);
      int err = 0;
      short bufnr;
      int size;
      int evhandle;
      UInt32 dwStatusDll = 0, dwStatusDrv = 0;
      Bitmap imagebmp;
      UInt16* buf;

      err = PCO_SDK_LibWrapper.PCO_GetCameraDescription(cameraHandle, ref pcoDescr);

      int width = pcoDescr.wMaxHorzResStdDESC;
      int height = pcoDescr.wMaxVertResStdDESC;
      int ishift = 16 - pcoDescr.wDynResDESC;
      int ipadd = width / 4;
      ipadd *= 4;
      ipadd = width - ipadd;
      size = pcoDescr.wMaxHorzResStdDESC * pcoDescr.wMaxVertResStdDESC * 2;

      if ((bufwidth != width) || (bufheight != height))
      {
        imagedata = new byte[(width + ipadd) * height * 3];
        wbuf = new UInt16[width * height];
      }
      evhandle = 0;
      bufnr = -1;
      buf = null;
      dwStatusDll = 0;
      dwStatusDrv = 0;
      fixed (UInt16* pw = wbuf)
      {
        buf = pw;
        err = PCO_SDK_LibWrapper.PCO_AllocateBuffer(cameraHandle, ref bufnr, size, ref buf, ref evhandle);
        size /= 2;
        err = PCO_SDK_LibWrapper.PCO_CamLinkSetImageParameters(cameraHandle, pcoDescr.wMaxHorzResStdDESC, pcoDescr.wMaxVertResStdDESC);
        //Mandatory for Cameralink and GigE. Don't care for all other interfaces, so leave it intact here.
        

        err = PCO_SDK_LibWrapper.PCO_ArmCamera(cameraHandle);

        err = PCO_SDK_LibWrapper.PCO_AddBufferEx(cameraHandle, 0, 0, bufnr, (UInt16)width, (UInt16)height, (UInt16)pcoDescr.wDynResDESC);

        do
        {
          err = PCO_SDK_LibWrapper.PCO_GetBufferStatus(cameraHandle, bufnr, ref dwStatusDll, ref dwStatusDrv);
        } while ((dwStatusDll & 0x8000) == 0);

        int max;
        int min;
        max = 0;
        min = 65535;
        for (int i = 0; i < height * width; i++)
        {
          buf[i] >>= ishift;
          if (buf[i] > max)
            max = buf[i];
          if (buf[i] < min)
            min = buf[i];
        }
        if (max <= min)
          max = min + 1;

        fixed (byte* pb = imagedata)
        {
          PCO_Convert_LibWrapper.PCO_Convert16TOCOL(convertHandle, 0, 1, width, height,
            buf, pb);
            //????
        }
        err = PCO_SDK_LibWrapper.PCO_FreeBuffer(cameraHandle, bufnr);
      }
      if ((convertDialog == 0) && (convertHandle != 0))
      {
        PCO_Convert_LibWrapper.PCO_OpenConvertDialog(ref convertDialog, this.Handle, "BW Dialog", WM_APPp100, convertHandle, 100, 100);
      }
      else
      {
        fixed (byte* pb = imagedata)
        {
          fixed (UInt16* pw = wbuf)
          {
            //PCO_Convert_LibWrapper.PCO_SetDataToDialog(convertDialog, width, height, pw, pb);
          }
        }
      }
      
      imagebmp = new Bitmap(pcoDescr.wMaxHorzResStdDESC, pcoDescr.wMaxVertResStdDESC, PixelFormat.Format24bppRgb);
      Rectangle dimension = new Rectangle(0, 0, imagebmp.Width, imagebmp.Height);
      BitmapData picData = imagebmp.LockBits(dimension, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      IntPtr pixelStartAddress = picData.Scan0;

      //Copy the pixel data into the bitmap structure
      System.Runtime.InteropServices.Marshal.Copy(imagedata, 0, pixelStartAddress, imagedata.Length);

      imagebmp.UnlockBits(picData);
      pictureBox1.Image = imagebmp;
      button1.Enabled = true;
    }

    private void OnStartRecord(object sender, EventArgs e)
    {
      int err;
      err = PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 1);
      buttonGrab.Enabled = true;
    }

    private void OnStopRecord(object sender, EventArgs e)
    {
      int err;
      err = PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);
      buttonGrab.Enabled = false;
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      if (cameraHandle != 0)
      {
        int err;
        err = PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);
        CloseCamera();
        cameraHandle = 0;
       
      }
    }

    public int opo1 = 0;//remove this line later ..this is just for test
    public int opo2 = 0;
    public int opo3 = 0;
    public int opo4 = 0;
    public int opo = 0;


    private unsafe void timer1_Tick(object sender, EventArgs e)
    {
      //  stopwatch.Start();
        counter2++;
        counter += 1;
        //sec = (double)counter / 100;
        pcoDescr.wSize = (ushort)sizeof(PCO_Description);
        int err = 0;
        short bufnr;
        int size;
        int evhandle;
        UInt32 dwStatusDll = 0, dwStatusDrv = 0;
        Bitmap imagebmp;
        UInt16* buf;
        err = PCO_SDK_LibWrapper.PCO_GetCameraDescription(cameraHandle, ref pcoDescr);
        int width = pcoDescr.wMaxHorzResStdDESC;
        int height = pcoDescr.wMaxVertResStdDESC;
        int ishift = 16 - pcoDescr.wDynResDESC;
        int ipadd = width / 4;
        ipadd *= 4;
        ipadd = width - ipadd;
        size = pcoDescr.wMaxHorzResStdDESC * pcoDescr.wMaxVertResStdDESC * 2;
        

        if ((bufwidth != width) || (bufheight != height))
        {
            imagedata = new byte[(width + ipadd) * height * 3];
            wbuf = new UInt16[width * height];
        }
        evhandle = 0;
        bufnr = -1;
        buf = null;
        dwStatusDll = 0;
        dwStatusDrv = 0;
        fixed (UInt16* pw = wbuf)
        {
            buf = pw;
            err = PCO_SDK_LibWrapper.PCO_AllocateBuffer(cameraHandle, ref bufnr, size, ref buf, ref evhandle);
            size /= 2;
            err = PCO_SDK_LibWrapper.PCO_CamLinkSetImageParameters(cameraHandle, pcoDescr.wMaxHorzResStdDESC, pcoDescr.wMaxVertResStdDESC);
            //Mandatory for Cameralink and GigE. Don't care for all other interfaces, so leave it intact here.


            err = PCO_SDK_LibWrapper.PCO_ArmCamera(cameraHandle);

            err = PCO_SDK_LibWrapper.PCO_AddBufferEx(cameraHandle, 0, 0, bufnr, (UInt16)width, (UInt16)height, (UInt16)pcoDescr.wDynResDESC);

            do
            {
                err = PCO_SDK_LibWrapper.PCO_GetBufferStatus(cameraHandle, bufnr, ref dwStatusDll, ref dwStatusDrv);
            } while ((dwStatusDll & 0x8000) == 0);

            int max;
            int min;
            max = 0;
            min = 65535;
            for (int i = 0; i < height * width; i++)
            {
                buf[i] >>= ishift;
                if (buf[i] > max)
                    max = buf[i];
                if (buf[i] < min)
                    min = buf[i];
            }
            if (max <= min)
                max = min + 1;

            fixed (byte* pb = imagedata)
            {
                PCO_Convert_LibWrapper.PCO_Convert16TOCOL(convertHandle, 0, 1, width, height,
                  buf, pb);
            }
            err = PCO_SDK_LibWrapper.PCO_FreeBuffer(cameraHandle, bufnr);
        }
               imagebmp = new Bitmap(pcoDescr.wMaxHorzResStdDESC, pcoDescr.wMaxVertResStdDESC, PixelFormat.Format24bppRgb);
        Rectangle dimension = new Rectangle(0, 0, imagebmp.Width, imagebmp.Height);
        BitmapData picData = imagebmp.LockBits(dimension, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        IntPtr pixelStartAddress = picData.Scan0;

        //Copy the pixel data into the bitmap structure
        System.Runtime.InteropServices.Marshal.Copy(imagedata, 0, pixelStartAddress, imagedata.Length);

        imagebmp.UnlockBits(picData);
        pictureBox1.Image = (Bitmap)System.Drawing.Image.FromFile(@"E:\imghist1.bmp");

        Bitmap imagebmp1 = (Bitmap)System.Drawing.Image.FromFile(@"E:\imghist1.bmp");
        Bitmap imagebmp2 = (Bitmap)System.Drawing.Image.FromFile(@"E:\imghist1.bmp");
        imagebmp1 = vid1(imagebmp1);
        pictureBox2.Image = imagebmp1;

        ratioy = (double)pictureBox3.Height / imagebmp2.Height;
        ratiox = (double)pictureBox3.Width / imagebmp2.Width;

        imagebmp2 = vid3(imagebmp2);
        pictureBox3.Image = imagebmp2;



       //  this.Text = "hello entering timer 2 tick box"+(++opo1);
       // counter += 1;
        
        // sec = (double)counter / 100;
        /* if (sec < 30)
          { button12.Hide(); }
          else
          { button12.Show(); } */
        //  if (counter % 3000 == 0)
         if ((yvals.Count >= 50) && (startCalculation == true))
            {
                //this.Text = "entering if yval.count>1024 inside timer 2 tick " + (++opo);
                //calculating daubechies coefficients
                //  double[] yval_array = new double[1024];initially it was here ..after adding button16 shifted to above
                int t1 = 0;
                foreach (var item1 in yvals)
                {
                    if (t1 < 50)
                    {
                        yval_array[t1] = item1;
                        t1++;
                    }
                    if (t1 == 50)
                    { break; }

                }
                double referenceLevel = (yval_array.Max() + yval_array.Min()) / 2.0;
                for (int i = 0; i < 50; i++)
                {
                    yval_array[i] = yval_array[i] - referenceLevel;
                }

                for (int t2 = 1; t2 <= 19; t2++)
                {
                    for (int t3 = 0; t3 < 50; t3++)
                    {
                        yval_array[(t2 * 50) + t3] = yval_array[t3];
                    }
                }

                for (int t4 = 0; t4 < 24; t4++)
                {
                    yval_array[1000 + t4] = yval_array[t4];
                }


                //calculating rms value of the signal
                double sum1 = 0;
                double mean1;
                for (int y = 0; y < 1024; y++)
                {
                    sum1 += Math.Pow(yval_array[y], 2);
                }
                mean1 = sum1 / 1024;
                yval_rms = Math.Sqrt(mean1);


                DRms = new double[10];
                Daubechies obj_daub = new Daubechies();
                DRms = obj_daub.daubTrans(yval_array,denoise);


                if (setflagForcasting == false)
                {
                    // this.Text = "entering if inside if >1324 inside timer 2 tick box" + (++opo2);
                    using (FileStream fs1 = new FileStream("Drms.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw1 = new StreamWriter(fs1))
                    {

                        for (int q = 0; q < 10; q++)
                        {
                            sw1.Write(DRms[q] + " ");
                        }
                        sw1.WriteLine();
                    }


                    using (FileStream fs2 = new FileStream("min_max.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw2 = new StreamWriter(fs2))
                    {

                        sw2.WriteLine(DRms.Min() + " " + DRms.Max());

                    }

                    using (FileStream fs3 = new FileStream("signal_rms.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw3 = new StreamWriter(fs3))
                    {
                        sw3.WriteLine(yval_rms);
                    }

                    using (FileStream fs4 = new FileStream("yvalarray.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw4 = new StreamWriter(fs4))
                    {
                        for (int q = 0; q < 1024; q++)
                        {
                            sw4.Write(yval_array[q] + " ");
                        }
                        sw4.WriteLine();

                    }
                    /*using (FileStream fs5 = new FileStream("yvals.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw5 = new StreamWriter(fs5))
                    {
                        foreach (var item2 in yvals)
                        {
                            sw5.WriteLine(item2);
                        }

                    }*/

                    double[,] x1;
                    using (TextReader reader = File.OpenText("Drms.txt"))
                    {
                        var lineCount1 = File.ReadLines("Drms.txt").Count();
                        x1 = new double[lineCount1, 10];
                        for (int i = 0; i < lineCount1; i++)
                        {
                            string line = reader.ReadLine();
                            string[] bits = line.Split(' ');

                            for (int j = 0; j < 10; j++)
                            {
                                x1[i, j] = double.Parse(bits[j]);
                            }
                        }
                    }

                    double[,] x2;
                    using (TextReader reader = File.OpenText("min_max.txt"))
                    {
                        var lineCount2 = File.ReadLines("min_max.txt").Count();
                        x2 = new double[lineCount2, 2];
                        for (int i = 0; i < lineCount2; i++)
                        {
                            string line = reader.ReadLine();
                            string[] bits = line.Split(' ');

                            for (int j = 0; j < 2; j++)
                            {
                                x2[i, j] = double.Parse(bits[j]);
                            }
                        }
                    }

                    double[] x3 = new double[5];
                    int NoOfCases;
                    using (TextReader reader = File.OpenText("signal_rms.txt"))
                    {
                        var lineCount3 = File.ReadLines("signal_rms.txt").Count();
                        NoOfCases = lineCount3;
                        for (int i = 0; i < lineCount3; i++)
                        {
                            x3[i] = double.Parse(reader.ReadLine());
                        }
                    }



                    using (FileStream fs = new FileStream("moushumi.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {


                        for (int i = 0; i < 10; i++)
                        {
                            sw.Write((x3[i] - (x3.Min())) / ((x3.Max()) - (x3.Min())) + " ");

                            for (int j = 0; j < 10; j++)
                            {

                                sw.Write((x1[i, j] - (x1.Cast<double>().Min())) / ((x1.Cast<double>().Max()) - (x1.Cast<double>().Min())) + " ");

                            }
                            sw.WriteLine();
                        }

                    }

                    // frequencer();
                    if (yvals.Count >= 1024)
                    {

                        freqs.AddLast(freq_y);
                        yvals.Clear(); dispactual.Clear();
                        flag_index_y = true;
                        found = true;
                        // time_p.Clear();

                    }
                }//end of --if (setflagForcasting == false)


                else
                {

                    timer1.Interval = 120000;
                    //   this.Text = "entering else inside >1024 insidetimer 2 tick box" + (++opo3);

                    double[] x3_prediction = new double[10];
                    using (TextReader reader = File.OpenText("signal_rms.txt"))
                    {
                        var lineCount3 = File.ReadLines("signal_rms.txt").Count();
                        for (int i = 0; i < lineCount3; i++)
                        {
                            x3_prediction[i] = double.Parse(reader.ReadLine());
                        }
                    }


                    double[,] x1_prediction;
                    using (TextReader reader = File.OpenText("Drms.txt"))
                    {
                        var lineCount1 = File.ReadLines("Drms.txt").Count();
                        x1_prediction = new double[lineCount1, 10];
                        for (int i = 0; i < lineCount1; i++)
                        {
                            string line = reader.ReadLine();
                            string[] bits = line.Split(' ');

                            for (int j = 0; j < 10; j++)
                            {
                                x1_prediction[i, j] = double.Parse(bits[j]);
                            }
                        }
                    }


                    using (FileStream fs_prediction = new FileStream("moushumiForPrediction.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw_prediction = new StreamWriter(fs_prediction))
                    {

                        sw_prediction.Write((yval_rms - (x3_prediction.Min())) / ((x3_prediction.Max()) - (x3_prediction.Min())) + " ");

                        for (int j = 0; j < 10; j++)
                        {

                            sw_prediction.Write((DRms[j] - (x1_prediction.Cast<double>().Min())) / ((x1_prediction.Cast<double>().Max()) - (x1_prediction.Cast<double>().Min())) + " ");

                        }
                        sw_prediction.WriteLine();
                        sw_prediction.WriteLine("\n\n Above are the 11 Neural Network inputs(signal rms value and 10 Daubechies coefficients ) that  have  been taken in for forcasting. ");



                    }
                    //setflagForcasting = false;

                    MessageBox.Show("Input data has been  saved !");
                    stopwatch1.Stop();
                  //  stopwatch1.Reset();
                    // timer2.Stop();
                    timer1.Stop();
                    button9.Show();
                    richTextBox1.Show();
                    groupBox2.Enabled = false;
                    groupBox6.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox4.Enabled = false;
                    button16.Enabled = false;
                    pictureBox5.Image = global::CSharpDemo.Properties.Resources.BRIDGE4;
                    button13.Show(); button18.Show();

                    // Application.Exit();//if i dont show this then after crossing pink window again the msg box and on closing msg box again pink wndow appears 
                    //frm.button2.Show();

                }//end of else block
                //this.Text = "coming out of else inside >1324 insede  timer 1 tick box" + (++opo4);
                setflagForcasting = false; //;initially it was uncommented..commented on 8th jan after error at line input  string not in correct format as if flagforcasting was false  was accepted



            }//end of  if ((yvals.Count >= 50) && (startCalculation == true))
       
       }
        
    
    void p(object r)
    {
        try
        {

            Bitmap b = new Bitmap(pictureBox4.Image);//initially it was picturebox4..just for test
            Rectangle a = (Rectangle)r;
            Pen pen1 = new Pen(Color.FromArgb(160, 255, 160), 3);
            Graphics g2 = Graphics.FromImage(b);
            pen1 = new Pen(color, 3);
            SolidBrush b5 = new SolidBrush(color);
            Font f = new Font(Font, FontStyle.Bold);
            g2.DrawString("+", f, b5, a.Location);
            g2.Dispose();
            pictureBox4.Image = (System.Drawing.Image)b;
            this.Invoke((MethodInvoker)delegate
            {
              
                double yvalue;
                //richTextBox1.Text = a.Location.ToString() + "\n" + richTextBox1.Text + "\n"; ;
                if (verticaldir == true)
                {
                     yvalue = a.Location.Y;
                    yvalue = 512 - yvalue;
                }
                else
                {
                     yvalue = a.Location.X;
                    yvalue = yvalue - 640;
                }

                if (removenoisypikes == true)
                {
                    counter_removenoisyspikes++;
                    if (counter_removenoisyspikes > 3)
                    {
                        if ((Math.Abs(yvalue - yvalue_prev_rns)) > 5 /*(Math.Abs(30 * ( yvals.ElementAt(1) - yvals.ElementAt(0))))*/)
                        {
                            yvalue = yvalue_prev_rns;
                        }
                    }
                    yvalue_prev_rns = yvalue;
                }
                    yvals.AddLast(yvalue);
                    if ((startreadingdisplacementvalue == true) && (stopreadingdisplacementvalue == false))
                    {
                        yd.AddLast(yvalue);
                    }
                
                   double firstvalue=yvals.ElementAt(0);
                    double actds;
                    if (verticaldir == true)
                    {
                        actds = actd * (yvalue - firstvalue);
                        Displacement = yvalue - firstvalue;
                    }
                    else
                    {
                        actds = actd * (yvalue - firstvalue);
                        Displacement = yvalue - firstvalue;
                    }

                    dispactual.AddLast(actds);
                    //   time_curr = sec;
                    //temp = time_curr - time_prev;
                    //  time_p.AddLast(temp);
                    //time_prev = time_curr;initially it aws not commented..commented for velocity

                   // sec = sec + (20.0 / 31.0);
                    c++;
                  //  this.Text = c.ToString();
                    this.Text = "Structural Health Monitoring(SHM)";
                

                    //    displacement graph...
                    displacement = actds;
                    
                    //velocity graph...
                    duration = (long)stopwatch1.Elapsed.TotalSeconds ;
                   // double delta_time = duration - time_prev;
                   
                if(extractframefirst==false)
                    Velocity = (Displacement - Displacement_prev) / 0.185;//203 frames in 37 secs for video parallel processing
                else
                    Velocity = (Displacement - Displacement_prev) / (n1/500.0);//1024 frames in 568 secs for video  extract frame first..for velocity we need exact timimg of frame..500 fps
                    velocity = Velocity * actd;
                    //acceleration graph....
                    if (extractframefirst == false)
                        Acceleration = (Velocity - Velocity_prev) / 0.185;
                    else
                        Acceleration = ((Velocity - Velocity_prev) / (n1 / 500.0))/980; //acceleration in terms of g
                    acceleration = Acceleration * actd;
                    accelerationpdf.AddLast(acceleration);
                    Displacement_prev = Displacement;
                    //time_prev = duration;
                    Velocity_prev = Velocity;
                    
                    //using stopwatch.elapsed...giving..error..Axis object – Auto interval error due to invalid point values or axis minimum/maximum
                    chart1.Series["Vib. Signal"].Points.AddXY(duration.ToString("N3"), Displacement.ToString());
                    chart1.Series["Vib. Signal"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart1.ChartAreas[0].AxisX.Name = "Time";
                    //actual

                    chart1.Series["Vib Signal"].Points.AddXY(duration.ToString("N3"), actds.ToString());
                    chart1.Series["Vib Signal"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    //using stopwatch.elapsed...giving..error..Axis object – Auto interval error due to invalid point values or axis minimum/maximum



                    chart7.Series["Displacement"].Points.AddXY(duration.ToString("N3"), Displacement.ToString());
                    chart7.Series["Displacement"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart7.Series["displacement"].Points.AddXY(duration.ToString("N3"), displacement.ToString());
                    chart7.Series["displacement"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

                    chart7.Series["Velocity"].Points.AddXY(duration.ToString("N3"), Velocity.ToString());
                    chart7.Series["Velocity"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart7.Series["velocity"].Points.AddXY(duration.ToString("N3"), velocity.ToString());
                    chart7.Series["velocity"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;


                    chart7.Series["Acceleration"].Points.AddXY(duration.ToString("N3"), Acceleration.ToString());
                    chart7.Series["Acceleration"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart7.Series["acceleration"].Points.AddXY(duration.ToString("N3"), acceleration.ToString());
                    chart7.Series["acceleration"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

                    if (startIntakeVibrations == true)
                {
                    yvals.Clear(); dispactual.Clear();
                    startIntakeVibrations = false;
                }
                if (flag_strip == true)
                {
                   
                    chart1.Series[0].Color = System.Drawing.Color.Blue;
                 /*   StripLine stripline1 = new StripLine();
                    stripline1.Interval = -1;
                    stripline1.IntervalOffset = sec;
                    stripline1.StripWidth = 0.01;
                    stripline1.BackColor = Color.Purple;
                    chart1.ChartAreas[0].AxisX.StripLines.Add(stripline1);*///it was was NotConnentdcommented earlier
                    flag_strip = false;
                }

            });
            //}
        }
        catch (Exception faa)
        {
            Thread.CurrentThread.Abort();
        }

      
        Thread.CurrentThread.Abort();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        label7.Show(); label8.Show(); label9.Show();
        pictureBox5.Image = global::CSharpDemo.Properties.Resources.bridgegif1;
        pCOToolStripMenuItem.Enabled = true;
        toolStrip1.Show();
        
        pco = true;
        button1.Enabled = false;
        groupBox2.Enabled = true;
        groupBox7.Visible = true;
        timer1.Enabled = true;
        button2.Enabled = true;
        int err = 0;
        ushort boardNum = 0;
        err = PCO_SDK_LibWrapper.PCO_OpenCamera(ref cameraHandle, boardNum);
        if (err == 0)
        {

            buttonOpen.Enabled = false;

            Setupconvert();
        }
        OnStartRecord(sender, e);
        OnGrabImage(sender, e); 
    }
    private void button2_Click(object sender, EventArgs e)
    {
        timer1.Enabled = false;
        int err;
        err = PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);
        CloseCamera();
        button1.Enabled = true;
        button2.Enabled = false;
        buttonGetDescription.Enabled = false;
        buttonGrab.Enabled = false;
        buttonStart.Enabled = false;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        colorDialog1.ShowDialog();
        color = colorDialog1.Color;
        numericUpDown1.Enabled = true;
        numericUpDown2.Enabled = true;
        numericUpDown3.Enabled = true;
        numericUpDown4.Enabled = true;
        numericUpDown5.Enabled = true;
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        range = Convert.ToInt32(numericUpDown1.Value);
    }

    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    {
        blobCounter.MinHeight = Convert.ToInt32(numericUpDown2.Value);
    }

    private void numericUpDown3_ValueChanged(object sender, EventArgs e)
    {
        blobCounter.MinWidth = Convert.ToInt32(numericUpDown3.Value);
    }



   

   
 
    public void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)//this is called with each new frame of the videosource(used both for pco video n video player)
    {//global variables used/modified: videoSourcePlayer(2,3)
        //get new frame
        framecount++;
        Bitmap bitmap = new Bitmap(320, 240);
        bitmap = eventArgs.Frame;
        //process the frame
       ry = (double) eventArgs.Frame.Height / 512;
        rx = (double) eventArgs.Frame.Width /640;
       
        if (oKToolStripMenuItemClick==true)
        {
            if (frameskip == 0)
            {
                pictureBox1.BackgroundImage = ResizeBitmap(bitmap, pictureBox1.Width, pictureBox1.Height);
                pictureBox2.BackgroundImage = ResizeBitmap(vid1(bitmap), pictureBox2.Width, pictureBox2.Height);
                pictureBox3.BackgroundImage = ResizeBitmap(vid3(bitmap), pictureBox3.Width, pictureBox3.Height);
                
               
            }
            frameskip++;
            int n = Convert.ToInt32(toolStripTextBox11.Text);
            if (frameskip == Convert.ToInt32(toolStripTextBox11.Text))
                frameskip = 0;
        }
        else
        {
            pictureBox1.BackgroundImage = ResizeBitmap(bitmap, pictureBox1.Width, pictureBox1.Height);
            pictureBox2.BackgroundImage = ResizeBitmap(vid1(bitmap), pictureBox2.Width, pictureBox2.Height);
            pictureBox3.BackgroundImage = ResizeBitmap(vid3(bitmap), pictureBox3.Width, pictureBox3.Height);
        }
        if (videoframeinputstarted == true)
        {
            stopwatch.Start();
            videoframeinputstarted = false;
          
        }
       
    }

    private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
    {
        Bitmap result = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(result))
            g.DrawImage(sourceBMP, 0, 0, width, height);
        return result;
    }
    private void button5_Click(object sender, EventArgs e)
    {
        timer.Stop();
        timer.Enabled = false;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton1.Checked == true)
        {
            groupBox6.Enabled = false;
            groupBox3.Show();
            //groupBox1.Hide();
            groupBox4.Hide();
            
           
        }

    }

    public string fileName { get; set; }
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton2.Checked == true)
        {
            groupBox6.Enabled = false;
            groupBox4.Show();
            groupBox2.Show();
            //groupBox1.Hide();
            groupBox3.Hide();
        }
    }

   

    private void button11_Click(object sender, EventArgs e)
    {
        label7.Show(); label8.Show(); label9.Show();
        videosrcplayr = true;
        button11.Enabled = false;
        groupBox2.Enabled = true;
        groupBox7.Show();
       
        if (extractframefirst == false)
        {
            videoToolStripMenuItem.Enabled = true;
            //videosrcplayr = true;
          //  button11.Enabled = false;
           // groupBox2.Enabled = true;
            //groupBox7.Show();
           button10.Enabled = true;

            openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,mkv,mpeg,flv)|*.mp3;*.wav;*.mov;*.wmv;*.mpg;*.avi;*.mpeg;*.mkv;*.mp4;*.flv|all files|*.*";
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;

                videoSource = new FileVideoSource(fileName);
                if (videoSource.IsRunning)
                {
                    button10_Click(null, null);
                }
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
                videoframeinputstarted = true;
                timer4.Start();
                counter = 0;
                richTextBox3.Text = fileName.ToString();
                groupBox2.Show();
            }

            var player = new WindowsMediaPlayer();
            var clip = player.newMedia(fileName);
           // t = TimeSpan.FromSeconds(clip.duration);
        }
        else
        {
            openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,mkv,mpeg,flv)|*.mp3;*.wav;*.mov;*.wmv;*.mpg;*.avi;*.mpeg;*.mkv;*.mp4;*.flv|all files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mediaDet.Filename = openFileDialog1.FileName;
                mediaDet.CurrentStream = 0;
                richTextBox3.Text = mediaDet.Filename.ToString();
                float percent = 0.002f;//how far do u want for a single step
               int streamsNumber = mediaDet.OutputStreams;
                int streamLength = (int)mediaDet.StreamLength;
                MessageBox.Show("Please wait for few seconds while the uploaded video is being stored in the image memory buffer.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               for (float i = 0.0f; i < streamLength; i = i + (float)(percent * streamLength))
                {
                    cframe++;
                    string fbitname = @"C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame" + (cframe + 2524).ToString();
                    mediaDet.WriteBitmapBits(i, 320, 240, fbitname + ".bmp");//a file is saved in above  directory in .bmp 
                    //  System.Drawing.Image imgframe = System.Drawing.Image.FromFile(@"C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame"+ cframe.ToString()+".bmp");
                    //imgframe.Save(@"C:\\Users\\JLR103\\Downloads\\frame\\demo\\extracted\\Framesaved" + cframe.ToString()+".bmp" , ImageFormat.Bmp);
                    // imgframe.Dispose();

                    //  System.IO.File.Delete("@C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame1.bmp");


                }
                MessageBox.Show("Process completed !", " ", MessageBoxButtons.OK);
               
            }
           
            if (cframe > 1024)
                toolStripMenuItem2.Enabled = true;

            button19.Show();
        }
     
    }

    private void button10_Click(object sender, EventArgs e)
    {
        if (extractframefirst == false)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                timer4.Stop();
                //  timer.Stop();
                //  timer.Enabled = false;


            }
        }
        else 
        {
            timer5.Stop();
        }
    }

 /*   private void button8_Click(object sender, EventArgs e)
    {
        //global variables used/modified: richTextBox2, videoSource
        using (WebClient client = new WebClient())
        {
            client.DownloadFile("http://www.c-sharpcorner.com/UploadFile/shivprasadk/visual-studio-and-net-tips-and-tricks-15/Media/Tip15.wmv", "video.wmv");
            //client.DownloadFile("download.bd-natok.com:82/natok/Eid_Natok_2012/Pocket_Shabdhan/Pocket_Sabdhan.wmv?l=24", "video.wmv");
            client.DownloadFile(richTextBox2.Text, "media.wmv");
            MessageBox.Show("Done", "Done");
        }
        videoSource = new FileVideoSource("media.wmv");
        videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
        videoSource.Start();
        groupBox2.Show();
    }*/

    private void button6_Click(object sender, EventArgs e)
    {
        button10_Click(null, null);
    }

    

    /*void frequencer()
    {
         //global variables used/modified: arrx, arry, found, av_time, freq_x, freq_y
            int ny = yvals.Count;
            //chart3.Series["Series1"].Points.Clear();

            y = (int)Math.Pow(2, Math.Floor(Math.Log(ny) / Math.Log(2)));
            complex[] arry = new complex[y];


            //var temx = xvals.First;
            var temy = yvals.First;
            

            //storing all the yvalues in an array
            for (int i = 0; i < y; i++)
            {
                arry[i] = new complex(temy.Value, 0);
                temy = temy.Next;
            }
            //resx and resy will contain the fft values of arrx and arry
            resy = new complex[y];
            resy = Fourier.FFT(arry);
            float max_magnitude_y = resy[1].magnitude;
            int index_y = 0;

            //to find the frequency corresponding to maximum magnitude for y values

            for (int i = 1; i < y; i++)
            {
                if (resy[i].magnitude > max_magnitude_y)
                {
                    max_magnitude_y = resy[i].magnitude;
                    index_y = (int)i;
                }
            }
               if (found == true)
            {
                av_time = time_p.Average();
                found = false;  

            }
             if (flag_index_y == true && ny > 1024)
            {
                temp_y = index_y;
                flag_index_y = false;
            }


            if (ny >1024)
            {
                index_y = temp_y;   
            }

            freq_y = (double)index_y * av_time / 2 * Math.PI / 2;
           // freq_x = (double)index_y * av_time / 2 * Math.PI / 2;
            double[] fre = new double[y];
            double maxf = 0;
            
            double avfre;
            for (int i = 1; i < y; i++)
            {
                fre[i] =resy[i].magnitude;
                if (fre[i] > maxf) 
                {
                    maxf = fre[i];
                }
            }
             double minf = maxf;
               for(int i=1;i<y;i++)
            {
                if (fre[i] < minf) 
                {
                    minf = fre[i];
                }
               
            }
            avfre = (maxf + minf) / 2;
            for (int i = 1; i < y; i++)
            {
               
                if (fre[i] < avfre)
                {
                  
                }

                else 
                {
                    
                }
            }
    }*/

   

    private void radioButton5_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton5.Checked == true)
        {
            radioButton8.Checked = false;
            extractframefirst = false;
            radioButton8.Enabled = false;
            radioButton5.Enabled = false;
           pictureBox5.Image = global::CSharpDemo.Properties.Resources.bridgegif1;
            pictureBox1.BackColor = System.Drawing.Color.Black;
            pictureBox1.BackgroundImage = global::CSharpDemo.Properties.Resources.images__1_;//see wat we have to do if we need to rchange background image through coding..same or backgndimgchnged
           pictureBox1.BackgroundImageLayout= System.Windows.Forms.ImageLayout.Center;
           pictureBox2.BackColor = System.Drawing.Color.Black;
            pictureBox2.BackgroundImage = global::CSharpDemo.Properties.Resources.images__1_;//see wat we have to do if we need to rchange background image through coding..same or backgndimgchnged
           pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
           pictureBox3.BackColor = System.Drawing.Color.Black;
            pictureBox3.BackgroundImage = global::CSharpDemo.Properties.Resources.images__1_;//see wat we have to do if we need to rchange background image through coding..same or backgndimgchnged
           pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
           menuStrip1.Visible = true;
            //change border style too n change to diff border stle after complting op n during pco
            groupBox5.Enabled = false;
            //radioButton4.Enabled = false;
            groupBox8.Show();
          //  groupBox7.Hide();
   
        }
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
       /* if (radioButton4.Checked == true)
        {

            groupBox7.Show();
            groupBox8.Hide();

        }*/
    }

    

    private void groupBox6_Enter(object sender, EventArgs e)
    {

    }

    private void button9_Click(object sender, EventArgs e)
    {
        yvals.Clear(); dispactual.Clear();
        freqs.Clear();
       // time_p.Clear();
        //verify what is y axiss and delta y here
        //chart2.Series["x-axis"].Points.Clear();
        chart1.Series["y-axis"].Points.Clear();
        chart7.Series["delta y"].Points.Clear();
        delta_y = 0;
        counter = 0;
    }

    private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
    {
        /*richTextBox1.Text = e.Location.ToString();
            Color col = Color.Black;
            col = Image_color.GetPixel(e.X, e.Y);
            color = col;
            richTextBox1.Text = col.Name.ToString();
            richTextBox1.BackColor = col;
            filter.CenterColor = Color.FromArgb(color.ToArgb());
            filter.Radius = (short)range;
            */
    }

    private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
    {
        if (tdm == true)
        {
            if (((verticaldir == true) && (richTextBox4.Text == "")) || ((verticaldir == false) && (richTextBox8.Text == "")))
                MessageBox.Show("Enter dimension of the target object first.");
        }
        //when( mouse clicks on it
        //global variables used/modified: mRect, init_x, init_y
        if (timer.Enabled == false)
        { counter = 0; timer.Enabled = true; }
        mRect = new Rectangle(e.X, e.Y, 0, 0);
        init_x = e.X;
        init_y = e.Y;
        this.Invalidate();
        groupBox7.Enabled = false;
        stopwatch1.Start();
    }

    private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
    {
        //global variables used/modified: mRect(modified), init_x(used), init_y(used)
        if (e.Button == MouseButtons.Left)//when mouse moves over it
        {
            //when mouse drags it down
            if ((e.X > init_x) && (e.Y < init_y))
                mRect = new Rectangle(init_x, e.Y, e.X - init_x, init_y - e.Y);
            if ((e.X > mRect.Left) && (e.Y > mRect.Top))
                mRect = new Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left, e.Y - init_y);
            if ((e.X < init_x) && (e.Y < init_y))
                mRect = new Rectangle(e.X, e.Y, init_x - e.X, init_y - e.Y);
            if ((e.X < init_x) && (e.Y > init_y))
                mRect = new Rectangle(e.X, init_y, init_x - e.X, e.Y - init_y);
            if (pco == true)
            {
                checkBox1.Show(); checkBox2.Show(); checkBox3.Show(); checkBox4.Show(); label11.Show();
            }
            button25.Enabled = true; groupBox16.Show(); groupBox17.Show();
        }
    }

    private void pictureBox2_Paint(object sender, PaintEventArgs e)
    {
        //global variables used/modified: mRect(used)


        using (Pen pen = new Pen(Color.Red, 2))
        {
            e.Graphics.DrawRectangle(pen, mRect);
          

        }
    }
   

      
    ///////////////////////ANN PART/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    static double[][] traindata;
    static double[][] testdata;

    private void button13_Click(object sender, EventArgs e)
  {
        // reading the training data from the traindata1.mat file into a matrix called traindata
        // create a reader for the file 
        MatFileReader mfr = new MatFileReader("traindata1.mat");
       
       // get a reference to out matlab 'squares' double matrix 
        MLDouble mlSquares = (mfr.Content["traindata1"] as MLDouble);
        if (mlSquares != null)
        {
            // now get the double values 
            double[][] tmp = mlSquares.GetArray();
            traindata = tmp;     
        }
       
    
      // reading the testing data from the testdata1.mat file into a matrix called traindata

             MatFileReader mfr1 = new MatFileReader("testdata1.mat");
            // MatFileReader mfr1 = new MatFileReader("traindata.mat");

            // get a reference to out matlab 'squares' double matrix 
            MLDouble mlSquares1 = (mfr1.Content["testdata1"] as MLDouble);
            if (mlSquares != null)
          
            {
                // now get the double values 
            
                double[][] tmp1 = mlSquares1.GetArray();
                testdata = tmp1;
            }

    // Console.WriteLine("Training the neural network,it may take around 10 mins, please wait ...");
            MessageBox.Show("Training the neural network,it may take around 02 mins, please wait ...");
           
            // code to print and test that the squares array is populated
            /* for (int i = 0; i < 10; i++)
              {    for (int j = 0; j < 10; j++)
                  { Console.Write(squares[i][j] + " "); }
               Console.WriteLine(); }

              Console.ReadLine();*/
            
           int errorcount = 0;
    

         //Lout[i] = new double[] {1};
         //double[][] tmp1 = m1square1.GetArraydata(1);
        
            double[][] testclass = new double[60][];
          /*  Lin[0] = new double[] { 1, 1 };
            Lin[1] = new double[] { 1, 0 };
            Lin[2] = new double[] { 0, 1 };
            Lin[3] = new double[] { 0, 0 };*/
            
            
            double[][] Lout = new double[140][];
            /*Lout[0] = new double[] { 0 };
            Lout[1] = new double[] { 1 };
            Lout[2] = new double[] { 1 };
            Lout[3] = new double[] { 0 };
            */

            for (int i = 0; i < 70; i++)
            {
                Lout[i] = new double[] { 1 };

            }
            
            for (int i = 70; i < 140; i++)
            {
                Lout[i] = new double[] { 0 };
                
            }
    //===========================================================================================================================//
           
            backPropagationNetwork net = new backPropagationNetwork(new int[] { 251, 4, 1 }, new hyperbolicTangensActivationFunction(0.4));
          //  net.randomize(0.01, 0.005);
            net.randomize(0.01, 0.5);
            quickPropagation bpl = new quickPropagation(net);
            //double error = bpl.learn(Lin, Lout, 10000, 0.001);

            double error = bpl.learn(traindata, Lout, 10000, 0.001);
          //  Console.WriteLine("training completed");
            MessageBox.Show("Training complete");
           // Console.ReadLine();

            
        //   double error = bpl.learn(traindata, Lout, 900, .01);
            for (int i = 0 ; i < 30 ; i++)
            {
              testclass[i] = new double[]{1};
            }

            for (int i = 30; i < 60; i++)
            {
                testclass[i] =  new double[]{0} ;
            }

            for (int i = 0; i < 60; i++)
            {
                double[] a = net.output(testdata[i]);
                if (String.Compare(a.ToString(),testclass[i].ToString()) != 20)
                    errorcount++;
        
            }
             MessageBox.Show("error count is");
            MessageBox.Show(errorcount.ToString());
            DialogResult dr = MessageBox.Show("want to display the graphs", "graphs", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                
            }
            else { }
         //   Console.WriteLine("error count is");
          //  Console.WriteLine(errorcount);
          //  Console.WriteLine("Press enter to exit");
          //  Console.ReadLine();


        //}
    //}
//}

/* =================================================================================*/
    
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("errorcount is");
            MessageBox.Show("errorcount.ToString()");
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
;            if ((System.IO.File.Exists("moushumiForPrediction.txt")))
            {
                System.IO.File.Delete("moushumiForPrediction.txt");
            }

            if ((System.IO.File.Exists("WeightsNBiases.txt")))
            {
                System.IO.File.Delete("WeightsNBiases.txt");
            }
            if (MessageBox.Show("Are you sure you want to exit?", "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            { Application.Exit(); }
                
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)//this is executed before loading design form and after pressing start
        {
            Application.EnableVisualStyles();
           // this.Location = new System.Drawing.Point(0, 0);
          //  this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //chart4.Hide();
           // chart3.Hide();
            chart1.Hide();
            chart7.Hide();
            button16.Hide();
            chart1.Series["Vib Signal"].Enabled = false;
            chart7.Series["displacement"].Enabled = false;
            chart7.Series["velocity"].Enabled = false;
            chart7.Series["acceleration"].Enabled = false;
           
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            radioButton6.Enabled = false;
            radioButton3.Enabled = false;
            progressBar1.Show();
            label10.Show();
            this.timer3.Start();
           
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (button15.BackColor == Color.LightGray)
            { button15.BackColor = Color.Lime; }
            else
            { button15.BackColor = Color.LightGray; }

            this.progressBar1.Increment(+1);
            if (progressBar1.Value == 99)
            {
                timer3.Stop();
                label10.Hide();
                progressBar1.Enabled = false;
                this.Hide();
                frm.ShowDialog();
                this.Show();
                pictureBox5.Image = global::CSharpDemo.Properties.Resources.BRIDGE3;
                progressBar1.Hide();
                button15.BackColor = Color.LightGray;
                MessageBox.Show("You have exited from the ANN form.\nTo re-train the network ,you need to exit from this application and re-run the application! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button12.Show();
                button15.Enabled = false;
              
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            acceleratebuttonpressed = true;
            button16.Enabled = false;
            if (videosrcplayr == true)
            {
                
               
                if ((yvals.Count < 500)/* && ((yvals.Count / (duration / 1000)) < 2)*/&& (startCalculation == true))
                {
                    timer4.Stop();
                    stopwatch1.Stop();
                    int t5 = 0;
                    foreach (var item1 in yvals)
                    {
                        yval_array[t5] = item1;
                        t5++;

                    }
                    double referenceLevel = (yval_array.Max() + yval_array.Min()) / 2.0;
                    for (int i = 0; i < t5; i++)
                    {
                        yval_array[i] = yval_array[i] - referenceLevel;
                    }



                    for (int t6 = 1; t6 < (1024 / yvals.Count); t6++)
                    {
                        for (int t7 = 0; t7 < yvals.Count; t7++)
                        {
                            yval_array[(t6 * yvals.Count) + t7] = yval_array[t7];
                        }
                    }
                    // int t9 = t6 * t7;
                    for (int t8 = 0; t8 < (1024 % yvals.Count); t8++)
                    {
                        yval_array[(yvals.Count * (1024 / yvals.Count)) + t8] = yval_array[t8];
                    }

                    double sum1 = 0;
                    double mean1;
                    for (int y = 0; y < 1024; y++)
                    {
                        sum1 += Math.Pow(yval_array[y], 2);
                    }
                    mean1 = sum1 / 1024;
                    yval_rms = Math.Sqrt(mean1);


                    DRms = new double[10];
                    Daubechies obj_daub = new Daubechies();
                    DRms = obj_daub.daubTrans(yval_array,denoise);
                    

                    double[] x3_prediction = new double[10];
                    using (TextReader reader = File.OpenText("signal_rms.txt"))
                    {
                        var lineCount3 = File.ReadLines("signal_rms.txt").Count();
                        for (int i = 0; i < lineCount3; i++)
                        {
                            x3_prediction[i] = double.Parse(reader.ReadLine());
                        }
                    }


                    double[,] x1_prediction;
                    using (TextReader reader = File.OpenText("Drms.txt"))
                    {
                        var lineCount1 = File.ReadLines("Drms.txt").Count();
                        x1_prediction = new double[lineCount1, 10];
                        for (int i = 0; i < lineCount1; i++)
                        {
                            string line = reader.ReadLine();
                            string[] bits = line.Split(' ');

                            for (int j = 0; j < 10; j++)
                            {
                                x1_prediction[i, j] = double.Parse(bits[j]);
                            }
                        }
                    }


                    using (FileStream fs_prediction = new FileStream("moushumiForPrediction.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw_prediction = new StreamWriter(fs_prediction))
                    {

                        sw_prediction.Write((yval_rms - (x3_prediction.Min())) / ((x3_prediction.Max()) - (x3_prediction.Min())) + " ");

                        for (int j = 0; j < 10; j++)
                        {

                            sw_prediction.Write((DRms[j] - (x1_prediction.Cast<double>().Min())) / ((x1_prediction.Cast<double>().Max()) - (x1_prediction.Cast<double>().Min())) + " ");

                        }
                        sw_prediction.WriteLine();
                        sw_prediction.WriteLine("\n\n Above are the 11 Neural Network inputs(signal rms value and 10 Daubechies coefficients ) that  have  been taken in for forcasting. ");


                    }
                    MessageBox.Show("Input data has been  saved !");
                    button9.Show();
                    richTextBox1.Show();
                    groupBox2.Enabled = false;
                    groupBox6.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox4.Enabled = false;
                    pictureBox5.Image = global::CSharpDemo.Properties.Resources.BRIDGE4;

                    button13.Show(); button18.Show();
                }
            }
            else
            {
                
              //  stopwatch.Stop();
                timer1.Stop();
              //  long duration = stopwatch.ElapsedMilliseconds;
                if ((yvals.Count < 50)/* && ((yvals.Count / (duration / 1000)) < 2)*/&& (startCalculation == true))
                {
                    int t5 = 0;
                    foreach (var item1 in yvals)
                    {
                        yval_array[t5] = item1;
                        t5++;

                    }
                    double referenceLevel = (yval_array.Max() + yval_array.Min()) / 2.0;
                    for (int i = 0; i < t5; i++)
                    {
                        yval_array[i] = yval_array[i] - referenceLevel;
                    }



                    for (int t6 = 1; t6 < (1024 / yvals.Count); t6++)
                    {
                        for (int t7 = 0; t7 < yvals.Count; t7++)
                        {
                            yval_array[(t6 * yvals.Count) + t7] = yval_array[t7];
                        }
                    }
                    // int t9 = t6 * t7;
                    for (int t8 = 0; t8 < (1024 % yvals.Count); t8++)
                    {
                        yval_array[(yvals.Count * (1024 / yvals.Count)) + t8] = yval_array[t8];
                    }

                    double sum1 = 0;
                    double mean1;
                    for (int y = 0; y < 1024; y++)
                    {
                        sum1 += Math.Pow(yval_array[y], 2);
                    }
                    mean1 = sum1 / 1024;
                    yval_rms = Math.Sqrt(mean1);


                    DRms = new double[10];
                    Daubechies obj_daub = new Daubechies();
                    DRms = obj_daub.daubTrans(yval_array,denoise);
                    if (denoise == true)
                        toolStripMenuItem5.Enabled = true;

                    double[] x3_prediction = new double[10];
                    using (TextReader reader = File.OpenText("signal_rms.txt"))
                    {
                        var lineCount3 = File.ReadLines("signal_rms.txt").Count();
                        for (int i = 0; i < lineCount3; i++)
                        {
                            x3_prediction[i] = double.Parse(reader.ReadLine());
                        }
                    }


                    double[,] x1_prediction;
                    using (TextReader reader = File.OpenText("Drms.txt"))
                    {
                        var lineCount1 = File.ReadLines("Drms.txt").Count();
                        x1_prediction = new double[lineCount1, 10];
                        for (int i = 0; i < lineCount1; i++)
                        {
                            string line = reader.ReadLine();
                            string[] bits = line.Split(' ');

                            for (int j = 0; j < 10; j++)
                            {
                                x1_prediction[i, j] = double.Parse(bits[j]);
                            }
                        }
                    }


                    using (FileStream fs_prediction = new FileStream("moushumiForPrediction.txt", FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw_prediction = new StreamWriter(fs_prediction))
                    {

                        sw_prediction.Write((yval_rms - (x3_prediction.Min())) / ((x3_prediction.Max()) - (x3_prediction.Min())) + " ");

                        for (int j = 0; j < 10; j++)
                        {

                            sw_prediction.Write((DRms[j] - (x1_prediction.Cast<double>().Min())) / ((x1_prediction.Cast<double>().Max()) - (x1_prediction.Cast<double>().Min())) + " ");

                        }
                        sw_prediction.WriteLine();
                        sw_prediction.WriteLine("\n\n Above are the 11 Neural Network inputs(signal rms value and 10 Daubechies coefficients ) that  have  been taken in for forcasting. ");


                    }
                    MessageBox.Show("Input data has been  saved !");
                    button9.Show();
                    stopwatch1.Stop();
                    richTextBox1.Show();
                    groupBox2.Enabled = false;
                    groupBox6.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox4.Enabled = false;
                    timer1.Stop();
                    pictureBox5.Image = global::CSharpDemo.Properties.Resources.BRIDGE4;
                    button13.Show(); button18.Show();


                }
            }//end of else
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(frm.richTextBox2.Text))&&(  USEalreadytrained == false))
            {
                MessageBox.Show("The network has not been trained yet.Please press exit and re-run the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                radioButton3.Enabled = false;
                radioButton6.Enabled = false;
                groupBox5.Show();
                groupBox6.Show();
               // label22.Show(); label26.Show();
                chart1.Show();
                chart7.Show();
               // label19.Show(); label25.Show();
                button12.Enabled = false;
            }
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {
           
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            foreach (var item in accelerationpdf) { }
            richTextBox1.Enabled = true;
            button9.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            double[] re;
            
            if (USEalreadytrained == true)
                comboxANNvalue = 4;
           
            ANNVibrationResult ob = new ANNVibrationResult(comboxANNvalue);
            re = ob.feedforwardANN();
            if (re[0] <= 0.2)
                richTextBox1.Text = "Very Low Vibrations!";
            else if ((re[0] > 0.2) && (re[0] <= 0.7))
                richTextBox1.Text = "low Vibrations!";//"Moderate Vibrations!"
            else if ((re[0] > 0.7) && (re[0] <= 0.9))
                richTextBox1.Text = "Moderate Vibrations!"; //"High Vibrations!";
            else
                richTextBox1.Text = "High Vibrations!"; //"Very High Vibrations!";
           
            timer2.Enabled = true;
            if (pco == true)//this part havent been tested yet..added on 3/3/2015
            {
                timer1.Interval = 1;
                timer1.Enabled = true;
                yvals.Clear(); dispactual.Clear();
                startCalculation = false;
                startIntakeVibrations = false;
                timer1.Start();
 
            }
            
       /*     yvals.Clear();
            startCalculation = false;
            startIntakeVibrations = false;
            acceleratebuttonpressed = false;
            setflagForcasting = true;
            //chart7.Series.Clear();
            //chart7.pl Series.Clear();
           // chart7.PlotArea.Series.Clear();
           // chart7.Series.Remove("Displacement");
            //chart1.Series.Clear();
           chart7.Series["Displacement"].Points.Clear();
             chart7.Series["Velocity"].Points.Clear();
                  chart7.Series["Acceleration"].Points.Clear();
              chart1.Series["Vib. Signal"].Points.Clear();
            
            button4.Show();
            button4.Enabled = true;
            timer1.Interval = 1;
            timer1.Enabled = true;
            timer1.Start();*/
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (richTextBox1.BackColor == Color.LightBlue)
            { richTextBox1.BackColor = Color.PowderBlue; }
            else
            { richTextBox1.BackColor = Color.LightBlue; }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            timer2.Stop();
            yvals.Clear();
            dispactual.Clear();
            button4.Enabled = false;
            startIntakeVibrations = true;
            startCalculation = true;
            durationatstorage=duration;
            flag_strip = true;
            button16.Show(); //label24.Show();
            button16.Enabled = true;
            chart1.Series[0].Color = System.Drawing.Color.DarkBlue;
            chart1.BorderlineColor = System.Drawing.Color.DarkGray;
            chart7.BorderlineColor = System.Drawing.Color.DarkGray;
            
            richTextBox1.Clear();
            richTextBox1.Hide();
            button9.Visible = false;
            if ((System.IO.File.Exists("moushumiForPrediction.txt")))
            {
                System.IO.File.Delete("moushumiForPrediction.txt");
            }
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            chart1.BorderlineColor = Color.DarkGray;
            chart7.BorderlineDashStyle = ChartDashStyle.Solid;
            chart7.BorderlineColor = Color.DarkGray;
            //stopwatch.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                if (shac == false)
                {
                    chart7.Series["Displacement"].Enabled = true;
                    chart7.Series["Velocity"].Enabled = false;
                    chart7.Series["Acceleration"].Enabled = false;
                }
                else
                {
                    chart7.Series["displacement"].Enabled = true;
                    chart7.Series["velocity"].Enabled = false;
                    chart7.Series["acceleration"].Enabled = false;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                if (shac == false)
                {
                    chart7.Series["Displacement"].Enabled = true;
                    chart7.Series["Velocity"].Enabled = true;
                    chart7.Series["Acceleration"].Enabled = true;
                }
                else
                {
                    chart7.Series["displacement"].Enabled = true;
                    chart7.Series["velocity"].Enabled = true;
                    chart7.Series["acceleration"].Enabled = true;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                if (shac == false)
                {
                    chart7.Series["Displacement"].Enabled = false;
                    chart7.Series["Velocity"].Enabled = false;
                    chart7.Series["Acceleration"].Enabled = true;
                }
                else
                {
                    chart7.Series["displacement"].Enabled = false;
                    chart7.Series["velocity"].Enabled = false;
                    chart7.Series["acceleration"].Enabled = true;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                if (shac == false)
                {
                    chart7.Series["Displacement"].Enabled = false;
                    chart7.Series["Velocity"].Enabled = true;
                    chart7.Series["Acceleration"].Enabled = false;
                }
                else
                {
                    chart7.Series["displacement"].Enabled = false;
                    chart7.Series["velocity"].Enabled = true;
                    chart7.Series["acceleration"].Enabled = false;
                }
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton6.Checked = false;
                button12.Show();
                button15.Hide();
                USEalreadytrained = true;
                setflagForcasting = true;
                
            }
        }

       

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                button12.Hide();
                radioButton3.Checked = false;
                button15.Show();
               
               
            }
        }

       
        private void chart7_Click(object sender, EventArgs e)
        {

        }
private void button5_Click_1(object sender, EventArgs e)
        {
           if ((System.IO.File.Exists("moushumiForPrediction.txt")))
            {
                System.IO.File.Delete("moushumiForPrediction.txt");
            }

            if ((System.IO.File.Exists("WeightsNBiases.txt")))
            {
                System.IO.File.Delete("WeightsNBiases.txt");
            }
          
            //Application.Exit();
         //   Application.Restart();
          //  Process.Start(Application.ExecutablePath);

           Process.Start(Application.ExecutablePath);
            Process.GetCurrentProcess().Kill();
            //System.Diagnostics.Debugger.Launch();
           
        }

private void groupBox1_Enter(object sender, EventArgs e)
{

}



private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
{
}



private void StopToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (videoSource.IsRunning)
    {
        videoSource.Stop();
        timer4.Stop();
        //  timer.Stop();
        //  timer.Enabled = false;

        OpenToolStripMenuItem.Enabled = true;

    }
    
}

private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
{
    videoToolStripMenuItem.Enabled = true;
    OpenToolStripMenuItem.Enabled = false;
    videosrcplayr = true;
    button11.Enabled = false;
    groupBox2.Enabled = true;
    groupBox7.Visible = true;
    button10.Enabled = true;
    openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,mkv,mpeg,flv)|*.mp3;*.wav;*.mov;*.wmv;*.mpg;*.avi;*.mpeg;*.mkv;*.mp4;*.flv|all files|*.*";
    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        fileName = openFileDialog1.FileName;

        videoSource = new FileVideoSource(fileName);
        if (videoSource.IsRunning)
        {
            button10_Click(null, null);
        }
        videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);
        videoSource.Start();
        timer4.Start();
        counter = 0;
        richTextBox3.Text = fileName.ToString();
        groupBox2.Show();
        StopToolStripMenuItem.Enabled = true;
    }
    var player = new WindowsMediaPlayer();
    var clip = player.newMedia(fileName);
    t = TimeSpan.FromSeconds(clip.duration);
}

private void currentToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (extractframefirst == false)
        toolStripTextBox7.Text = framecount.ToString();
    else
    {
       // toolStripTextBox7.Text = framecount.ToString();
    }
}

private void totalToolStripMenuItem_Click(object sender, EventArgs e)
{
    toolStripTextBox8.Text= framecount.ToString();
  //  if Not possible then see then enable it at last
}

private void timer4_Tick(object sender, EventArgs e)
{
    if (!videoSource.IsRunning)
    {
    if ( (mRect != null) && (startCalculation == true)/*store vib button pressed*/ && (yvals.Count < 200) && (acceleratebuttonpressed == false))
    {
        timer4.Stop();
        stopwatch1.Stop();
        
        int t1 = 0;
        foreach (var item1 in yvals)
        {
           
                yval_array[t1] = item1;
                t1++;
        }
        double referenceLevel = (yval_array.Max() + yval_array.Min()) / 2.0;
        for (int i = 0; i <t1; i++)
        {
            yval_array[i] = yval_array[i] - referenceLevel;
        }

        for (int t2 = 1; t2 < (1024 / yvals.Count); t2++)
        {
            for (int t3 = 0; t3 < yvals.Count; t3++)
            {
                yval_array[(t2 * yvals.Count) + t3] = yval_array[t3];
            }
        }
        for (int t4 = 0; t4 < (1024 % yvals.Count); t4++)
        {
            yval_array[(yvals.Count * (1024 / yvals.Count)) + t4] = yval_array[t4];
        }

      //calculating rms value of the signal
        double sum1 = 0;
        double mean1;
        for (int y = 0; y < 1024; y++)
        {
            sum1 += Math.Pow(yval_array[y], 2);
        }
        mean1 = sum1 / 1024;
        yval_rms = Math.Sqrt(mean1);


        DRms = new double[10];
        Daubechies obj_daub = new Daubechies();
        DRms = obj_daub.daubTrans(yval_array,denoise);


        if (setflagForcasting == false)
        {
            // this.Text = "entering if inside if >1324 inside timer 2 tick box" + (++opo2);
            using (FileStream fs1 = new FileStream("Drms.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw1 = new StreamWriter(fs1))
            {

                for (int q = 0; q < 10; q++)
                {
                    sw1.Write(DRms[q] + " ");
                }
                sw1.WriteLine();
            }


            using (FileStream fs2 = new FileStream("min_max.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw2 = new StreamWriter(fs2))
            {

                sw2.WriteLine(DRms.Min() + " " + DRms.Max());

            }

            using (FileStream fs3 = new FileStream("signal_rms.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw3 = new StreamWriter(fs3))
            {
                sw3.WriteLine(yval_rms);
            }

            using (FileStream fs4 = new FileStream("yvalarray.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw4 = new StreamWriter(fs4))
            {
                for (int q = 0; q < 1024; q++)
                {
                    sw4.Write(yval_array[q] + " ");
                }
                sw4.WriteLine();

            }
           

            double[,] x1;
            using (TextReader reader = File.OpenText("Drms.txt"))
            {
                var lineCount1 = File.ReadLines("Drms.txt").Count();
                x1 = new double[lineCount1, 10];
                for (int i = 0; i < lineCount1; i++)
                {
                    string line = reader.ReadLine();
                    string[] bits = line.Split(' ');

                    for (int j = 0; j < 10; j++)
                    {
                        x1[i, j] = double.Parse(bits[j]);
                    }
                }
            }

            double[,] x2;
            using (TextReader reader = File.OpenText("min_max.txt"))
            {
                var lineCount2 = File.ReadLines("min_max.txt").Count();
                x2 = new double[lineCount2, 2];
                for (int i = 0; i < lineCount2; i++)
                {
                    string line = reader.ReadLine();
                    string[] bits = line.Split(' ');

                    for (int j = 0; j < 2; j++)
                    {
                        x2[i, j] = double.Parse(bits[j]);
                    }
                }
            }

            double[] x3 = new double[5];
            int NoOfCases;
            using (TextReader reader = File.OpenText("signal_rms.txt"))
            {
                var lineCount3 = File.ReadLines("signal_rms.txt").Count();
                NoOfCases = lineCount3;
                for (int i = 0; i < lineCount3; i++)
                {
                    x3[i] = double.Parse(reader.ReadLine());
                }
            }



            using (FileStream fs = new FileStream("moushumi.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {


                for (int i = 0; i < 10; i++)
                {
                    sw.Write((x3[i] - (x3.Min())) / ((x3.Max()) - (x3.Min())) + " ");

                    for (int j = 0; j < 10; j++)
                    {

                        sw.Write((x1[i, j] - (x1.Cast<double>().Min())) / ((x1.Cast<double>().Max()) - (x1.Cast<double>().Min())) + " ");

                    }
                    sw.WriteLine();
                }

            }

            //  frequencer();
            if (yvals.Count >= 1024)
            {

                freqs.AddLast(freq_y);
                yvals.Clear(); dispactual.Clear();
                flag_index_y = true;
                found = true;
               
                //time_p.Clear();

            }
        }//end of --if (setflagForcasting == false)


        else
        {

            timer1.Interval = 120000;
            //   this.Text = "entering else inside >1024 insidetimer 2 tick box" + (++opo3);

            double[] x3_prediction = new double[10];
            using (TextReader reader = File.OpenText("signal_rms.txt"))
            {
                var lineCount3 = File.ReadLines("signal_rms.txt").Count();
                for (int i = 0; i < lineCount3; i++)
                {
                    x3_prediction[i] = double.Parse(reader.ReadLine());
                }
            }


            double[,] x1_prediction;
            using (TextReader reader = File.OpenText("Drms.txt"))
            {
                var lineCount1 = File.ReadLines("Drms.txt").Count();
                x1_prediction = new double[lineCount1, 10];
                for (int i = 0; i < lineCount1; i++)
                {
                    string line = reader.ReadLine();
                    string[] bits = line.Split(' ');

                    for (int j = 0; j < 10; j++)
                    {
                        x1_prediction[i, j] = double.Parse(bits[j]);
                    }
                }
            }


            using (FileStream fs_prediction = new FileStream("moushumiForPrediction.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw_prediction = new StreamWriter(fs_prediction))
            {

                sw_prediction.Write((yval_rms - (x3_prediction.Min())) / ((x3_prediction.Max()) - (x3_prediction.Min())) + " ");

                for (int j = 0; j < 10; j++)
                {

                    sw_prediction.Write((DRms[j] - (x1_prediction.Cast<double>().Min())) / ((x1_prediction.Cast<double>().Max()) - (x1_prediction.Cast<double>().Min())) + " ");

                }
                sw_prediction.WriteLine();
                sw_prediction.WriteLine("\n\n Above are the 11 Neural Network inputs(signal rms value and 10 Daubechies coefficients ) that  have  been taken in for forcasting. ");



            }
            //setflagForcasting = false;

            MessageBox.Show("Input data has been  saved !");
            stopwatch1.Stop();
            pictureBox5.Image = global::CSharpDemo.Properties.Resources.BRIDGE4;

            // timer2.Stop();
            //timer1.Stop();
           /* if (!this.IsHandleCreated)//initially it was not 'not !' ..change done on 23rd dec
                this.CreateControl();
            this.Invoke((MethodInvoker)delegate
            {
                button9.Show();
                richTextBox1.Show();
                groupBox2.Enabled = false;
                groupBox6.Enabled = false;
                groupBox5.Enabled = false;
                groupBox4.Enabled = false;
                button16.Enabled = false;

            });*/
            //videoSource.Stop();

            button9.Show();
            richTextBox1.Show();
            groupBox2.Enabled = false;
            groupBox6.Enabled = false;
            groupBox5.Enabled = false;
            groupBox4.Enabled = false;
            button16.Enabled = false;
            button13.Show(); button18.Show();

            // Application.Exit();//if i dont show this then after crossing pink window again the msg box and on closing msg box again pink wndow appears 
            //frm.button2.Show();

        }//end of else block
        //this.Text = "coming out of else inside >1324 insede  timer 1 tick box" + (++opo4);
        //  setflagForcasting = false;



    }

  
   
    if ((mRect.X == 0 && mRect.Y==0 && mRect.Width==0 && mRect.Height==0)||(mRect.Width!=0 && mRect.Height!=0 && startCalculation==false))//this is the case when we dont select  red rectangle but its not equal to null
    {  videoSource.Start(); }
   /* if (mRect == null)
    {
        MessageBox.Show("successful");
       
    }*/
    }//end of if(!videosource.isrunning)
}

private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
{

}

private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
{

}

private void amplitudeToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void verticleToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
{

}

private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
{

}

private void fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void yttyfToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void frameCountToolStripMenuItem_Click(object sender, EventArgs e)
{

}

private void videoDurationToolStripMenuItem_Click(object sender, EventArgs e)
{
   
   
}

private void hmsToolStripMenuItem_Click(object sender, EventArgs e)
{

  toolStripTextBox1.Text = t.ToString();

    
}

private void hmsroundedToolStripMenuItem_Click(object sender, EventArgs e)
{
   
     string s = String.Format("{0}h:{1}m:{2}s :", t.Hours, t.Minutes, t.Seconds);
    toolStripTextBox2.Text = s;
   
    
}

private void secsToolStripMenuItem_Click(object sender, EventArgs e)
{
    toolStripTextBox4.Text = t.TotalSeconds.ToString();
   
}

private void minsToolStripMenuItem_Click(object sender, EventArgs e)
{
  
toolStripTextBox5.Text = t.TotalMinutes.ToString(); 
}

private void hoursToolStripMenuItem_Click(object sender, EventArgs e)
{
 toolStripTextBox6.Text = t.TotalHours.ToString();
}

private void millisecsToolStripMenuItem_Click(object sender, EventArgs e)
{
   
    
    toolStripTextBox3.Text = t.TotalMilliseconds.ToString();
   
   }

private void toolStripSeparator1_Click(object sender, EventArgs e)
{

}
      
private void toolStripTextBox1_Click(object sender, EventArgs e)
{

}

private void toolStripTextBox7_Click(object sender, EventArgs e)
{

}

private void toolStripTextBox8_Click(object sender, EventArgs e)
{

}




private void toolStripTextBox11_KeyPress_1(object sender, KeyPressEventArgs e)
{
    //VIDEO
    char ch1 = e.KeyChar;

    //8 for backspace.46 for dot

    if (!char.IsDigit(ch1) && ch1 != 8)
    { e.Handled = true; }

    oKToolStripMenuItem.Enabled = true;
   
}

private void oKToolStripMenuItem_Click_1(object sender, EventArgs e)
{
    //VIDEO
    toolStripTextBox11.Enabled = false;
    oKToolStripMenuItem.CheckState = CheckState.Checked;
    oKToolStripMenuItemClick = true;
    oKToolStripMenuItem.Enabled = false;
    oKToolStripMenuItem.CheckState = CheckState.Unchecked;
}

private void toolStripTextBox12_KeyPress(object sender, KeyPressEventArgs e)
{
    //PCO
    char ch2 = e.KeyChar;

    //8 for backspace.46 for dot

    if (!char.IsDigit(ch2) && ch2 != 8)
    { e.Handled = true; }

    oKToolStripMenuItem1.Enabled = true;
}

private void oKToolStripMenuItem1_Click(object sender, EventArgs e)
{
    //PCO
    toolStripTextBox12.Enabled = false;
    oKToolStripMenuItem1.CheckState = CheckState.Checked;
    timer1.Interval = Convert.ToInt32(toolStripTextBox12.Text);
    oKToolStripMenuItem1.Enabled = false;
    oKToolStripMenuItem1.CheckState = CheckState.Unchecked;
}

private void Form1_SizeChanged(object sender, EventArgs e)
{
    if (this.WindowState == FormWindowState.Minimized)
    {
        notifyIcon1.BalloonTipText = "The form has minimized to tray";
        notifyIcon1.Visible = true;

        notifyIcon1.ShowBalloonTip(5000);
    }
   if (this.WindowState == FormWindowState.Normal)
    {
        notifyIcon1.BalloonTipText = "The form has come back to normal";
        notifyIcon1.ShowBalloonTip(5000);
       
    }
}

private void checkBox5_CheckedChanged(object sender, EventArgs e)
{

}

private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
{

}

private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
{

}

private void toolStripButton1_Click(object sender, EventArgs e)
{

}

private void toolStripMenuItem1_Click(object sender, EventArgs e)
{

}

private void toolStripDropDownButton1_Click(object sender, EventArgs e)
{

}

private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
{

}

private void toolStripTextBox13_Click(object sender, EventArgs e)
{

}

private void actualToolStripMenuItem_Click(object sender, EventArgs e)
{
    relativePixelsToolStripMenuItem.BackColor = System.Drawing.Color.White;
// actualToolStripMenuItem.Image = Properties.Resources.right;
    toolStripMenuItem1.Enabled = true;
    toolStripTextBox13.Enabled = true;
    oKToolStripMenuItem2.Enabled = true;
}


private void toolStripTextBox13_KeyPress(object sender, KeyPressEventArgs e)
{
  
    char ch = e.KeyChar;
    //8 for backspace.46 for dot
   
    if (!char.IsDigit(ch) && ch !=46 && ch!=8)
    { e.Handled = true; }
    oKToolStripMenuItem2.Enabled = true;
    oKToolStripMenuItem2.BackColor = System.Drawing.Color.SlateBlue;
}

private void oKToolStripMenuItem2_Click(object sender, EventArgs e)
{
    toolStripMenuItem1.Enabled = false;
    oKToolStripMenuItem2.Enabled = false;
    string num1 = System.Text.RegularExpressions.Regex.Match(toolStripTextBox13.Text, @"\d+(.\d+)?").Value;//num1 in m
    ds = double.Parse(num1);//m
    actd = ((ds * 12.29) / 1024)*10; //mm
    chart1.Series["Vib. Signal"].Enabled = false;
    chart1.Series["Vib Signal"].Enabled = true;
    chart1.Series["Vib Signal"].Points.Clear();
    
}

private void toolStripTextBox13_Click_1(object sender, EventArgs e)
{

}

private void toolStripButton1_Click_1(object sender, EventArgs e)
{

}

private void toolStripButton2_Click(object sender, EventArgs e)
{
    CSharpDemo.CameraSettings cs = new CSharpDemo.CameraSettings();
    cs.ShowDialog();
}

private void toolStripSplitButton1_ButtonClick_1(object sender, EventArgs e)
{

}

private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
{

}

private void chart1_Click(object sender, EventArgs e)
{

}

private void relativePixelsToolStripMenuItem_Click(object sender, EventArgs e)
{
    chart1.Series["Vib. Signal"].Enabled = true;
    chart1.Series["Vib Signal"].Enabled = false;
  /*   chart7.Series["Displacement"].Enabled = false;
    chart7.Series["Velocity"].Enabled = false;
    chart7.Series["Acceleration"].Enabled = true;*/
}

private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
{

    if (checkBox4.Checked == true)
    {
        radioButton7.Checked = false;
        verticaldir = true;
    }
     
}

private void radioButton7_CheckedChanged(object sender, EventArgs e)
{
            if (radioButton7.Checked == true)
            {
                radioButton4.Checked = false;
                verticaldir = false;
                
            }
        
}

private void label2_Click(object sender, EventArgs e)
{

}

private void label3_Click(object sender, EventArgs e)
{

}

private void numericUpDown5_ValueChanged(object sender, EventArgs e)
{
    numericUpDown5.Minimum = blobCounter.MinHeight + 2;
   blobCounter.MaxHeight = Convert.ToInt32(numericUpDown5.Value);
}

private void numericUpDown4_ValueChanged(object sender, EventArgs e)
{
    numericUpDown4.Minimum = blobCounter.MinWidth + 2;
    blobCounter.MaxWidth = Convert.ToInt32(numericUpDown4.Value);
}

private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
{
    toolStripTextBox13.Enabled = false;
    oKToolStripMenuItem.Enabled = false;
    chart1.Series["Vib. Signal"].Enabled = false;
    chart1.Series["Vib Signal"].Enabled = true;
   
}



private void label15_Click(object sender, EventArgs e)
{

}

private void label16_Click(object sender, EventArgs e)
{

}

private void progressBar1_Click(object sender, EventArgs e)
{

}

private void button8_Click(object sender, EventArgs e)
{
    justfortest j = new justfortest();
    j.ShowDialog();
}

private void button13_Click_1(object sender, EventArgs e)
{
    fq = new Frequency_Analysis(this);
    fq.ShowDialog();
}

private void button17_Click(object sender, EventArgs e)
{
   foreach (var item3 in accelerationpdf)
    {
     
         //    chart2.Series["Histogram"].Points.AddXY(duration.ToString("N3")/*sec.ToString("N3")*/, yvalue.ToString());it was not commented earlier ..only commented today
                    chart1.Series["Vib. Signal"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    
    }
}


private void button18_Click(object sender, EventArgs e)
{
    Signal_magnitude_Analysis sm = new Signal_magnitude_Analysis(this,fq);
    sm.ShowDialog();
}

private void button17_Click_1(object sender, EventArgs e)
{
    extractframefirst = true;
   
    
    openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,mkv,mpeg,flv)|*.mp3;*.wav;*.mov;*.wmv;*.mpg;*.avi;*.mpeg;*.mkv;*.mp4;*.flv|all files|*.*";
    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        mediaDet.Filename = openFileDialog1.FileName;
        mediaDet.CurrentStream = 0;
        float percent = 0.002f;//how far do u want for a single step
          //gets # of streams
        
    int streamsNumber = mediaDet.OutputStreams;
       // _AMMediaType mediaType = mediaDet.StreamMediaType;
     int  streamLength = (int)mediaDet.StreamLength;
        MessageBox.Show("Please wait for few seconds while the uploaded video is being stored in the image memory buffer.", "", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
       // Size  target = getVideoSize(mediaType);
       for (float i = 0.0f; i < streamLength; i = i + (float)(percent * streamLength))
       {

           cframe++;
           string fbitname = @"C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame" + (cframe+2524).ToString();
           mediaDet.WriteBitmapBits(i, 320, 240, fbitname + ".bmp");//a file is saved in above  directory in .bmp 
         //  System.Drawing.Image imgframe = System.Drawing.Image.FromFile(@"C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame"+ cframe.ToString()+".bmp");
           //imgframe.Save(@"C:\\Users\\JLR103\\Downloads\\frame\\demo\\extracted\\Framesaved" + cframe.ToString()+".bmp" , ImageFormat.Bmp);
          // imgframe.Dispose();

         //  System.IO.File.Delete("@C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame1.bmp");
      
      
       }
       MessageBox.Show("Process completed !", " ", MessageBoxButtons.OK);
   
    }
    if (cframe > 1024)
        toolStripMenuItem2.Enabled = true;
      
}

private void button19_Click(object sender, EventArgs e)
{
    System.IO.File.Delete("@C:\\demo1\\Frame1.bmp");
}

private void button19_Click_1(object sender, EventArgs e)
{
    videosrcplayr = true;
    videoToolStripMenuItem.Enabled = false;
   button19.Enabled = false;
    groupBox2.Enabled = true;
    groupBox7.Show();
    button10.Enabled = true;
    /*   int n1=(int)Math.Ceiling(1024/(((cframe%1024)/1024.0)+(Math.Floor(cframe/1024.0))));
       double n2 = Math.Round(1024.0 / n1,0);
       imgframe1[0] = System.Drawing.Image.FromFile(@"C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame1.bmp");
       int n3 = 1;
       while (n3 < 1024)
       {
           for (int i2 = 1; i2 < n1; i2++)
           {
               n3++;
               imgframe1[i2] = System.Drawing.Image.FromFile(@"C:\\Users\\JLR103\\Downloads\\frame\\demo\\Frame" + (n2 * i2).ToString() + ".bmp");
            
           }
       }*/
    int cframe = 2860;//just for test..remove it later
     n1 = cframe / 1024;
    
    timer5.Start();
    groupBox2.Show();
   

}

private void toolStripMenuItem2_Click(object sender, EventArgs e)
{
    toolStripTextBox14.Text = mediaDet.FrameRate.ToString();
}

private void timer5_Tick(object sender, EventArgs e)
{
    imgframe2 = (Bitmap)System.Drawing.Image.FromFile(@"E:\imghist2.bmp");
    
    ry = (double)imgframe2.Height / 512;
    rx = (double)imgframe2.Width / 640;
    pictureBox1.BackgroundImage = ResizeBitmap(imgframe2, pictureBox1.Width, pictureBox1.Height);
    pictureBox2.BackgroundImage = ResizeBitmap(vid1(imgframe2), pictureBox2.Width, pictureBox2.Height);
    pictureBox3.BackgroundImage = ResizeBitmap(vid3(imgframe2), pictureBox3.Width, pictureBox3.Height);
    timer5counter++;
  
}

private void radioButton8_CheckedChanged(object sender, EventArgs e)
{
    if (radioButton8.Checked == true)
    {
        radioButton5.Checked = false;
        extractframefirst = true;
        radioButton8.Enabled = false;
        radioButton5.Enabled = false;
        pictureBox5.Image = global::CSharpDemo.Properties.Resources.bridgegif1;
        pictureBox1.BackColor = System.Drawing.Color.Black;
        pictureBox1.BackgroundImage = global::CSharpDemo.Properties.Resources.images__1_;//see wat we have to do if we need to rchange background image through coding..same or backgndimgchnged
        pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        pictureBox2.BackColor = System.Drawing.Color.Black;
        pictureBox2.BackgroundImage = global::CSharpDemo.Properties.Resources.images__1_;//see wat we have to do if we need to rchange background image through coding..same or backgndimgchnged
        pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        pictureBox3.BackColor = System.Drawing.Color.Black;
        pictureBox3.BackgroundImage = global::CSharpDemo.Properties.Resources.images__1_;//see wat we have to do if we need to rchange background image through coding..same or backgndimgchnged
        pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        menuStrip1.Visible = true;
        //change border style too n change to diff border stle after complting op n during pco
        groupBox5.Enabled = false;
        //radioButton4.Enabled = false;
        groupBox8.Show();
        

    }
}

private void button6_Click_1(object sender, EventArgs e)
{
    

}

private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
{
    if (checkBox5.Checked == true)
    {
        denoise = true;
        checkBox5.Enabled = false;
    }
}

private void toolStripButton3_Click(object sender, EventArgs e)
{
   
}


private void toolStripMenuItem3_Click(object sender, EventArgs e)
{

    denoise = true;
    
}

private void toolStripMenuItem5_Click(object sender, EventArgs e)
{
    System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
    System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
    System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
    chartArea13.AxisX.InterlacedColor = System.Drawing.Color.Thistle;
    chartArea13.AxisX.IsInterlaced = true;
    chartArea13.AxisX.MinorGrid.Enabled = true;
    chartArea13.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
    chartArea13.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
    chartArea13.AxisX.MinorTickMark.Enabled = true;
    chartArea13.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
    chartArea13.AxisX.ScrollBar.BackColor = System.Drawing.SystemColors.ScrollBar;
    chartArea13.AxisX.ScrollBar.ButtonColor = System.Drawing.SystemColors.ControlDarkDark;
    chartArea13.AxisX.Title = "Time(in sec)";
    chartArea13.AxisX.ToolTip = "time(in seconds)";
    chartArea13.AxisY.InterlacedColor = System.Drawing.Color.PaleTurquoise;
    chartArea13.AxisY.IsInterlaced = true;
    chartArea13.AxisY.MinorGrid.Enabled = true;
    chartArea13.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
    chartArea13.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
    chartArea13.CursorX.IsUserEnabled = true;
    chartArea13.CursorX.IsUserSelectionEnabled = true;
    chartArea13.CursorX.SelectionColor = System.Drawing.Color.LightSteelBlue;
    chartArea13.CursorY.IsUserEnabled = true;
    chartArea13.CursorY.IsUserSelectionEnabled = true;
    chartArea13.CursorY.SelectionColor = System.Drawing.Color.LightSteelBlue;
    chartArea13.Name = "ChartArea13";

    legend13.BackColor = System.Drawing.Color.Transparent;
    legend13.Name = "Legend13";


    series13.ChartArea = "ChartArea13";
    series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
    series13.Color = System.Drawing.Color.Navy;
    series13.Legend = "Legend13";
    series13.Name = "Denoised Sig.";
    series13.IsVisibleInLegend = true;

    int dimdpxvalue;
    if (videosrcplayr == true)
    {
        if (extractframefirst == true)
            dimdpxvalue = 1024;
        else
            dimdpxvalue = 200;

    }
    else
    { dimdpxvalue = 50; }
   /* foreach (var dpp in chart1.Series["Vib. Signal"].Points)
    { 
    }*/

    /*double[] dpxvalue = new double[dimdpxvalue];
    int dpxvaluecounter = 0;
    foreach (var dp in chart1.Series["Vib. Signal"].Points)
    {
        if (dpxvaluecounter == dimdpxvalue)
            break;
        if (dp.XValue > durationatstorage)
        {
            dpxvalue[dpxvaluecounter] = dp.XValue;
            dpxvaluecounter++;
        }

    }*/

    
   
    this.chart1.ChartAreas.Add(chartArea13);
    this.chart1.Series.Add(series13);
    this.chart1.Legends.Add(legend13);
    legend13.LegendStyle = LegendStyle.Column;
    chart1.ChartAreas["ChartArea13"].AlignWithChartArea = "ChartArea1";
  //  chart1.Legends["Legend1"].LegendStyle = LegendStyle.Column;
    chart1.Legends["Legend13"].LegendStyle = LegendStyle.Column;
    for (int i = 0; i < 1024/*dpxvaluecounter*/; i++)
    {
        chart1.Series["Denoised Sig."].Points.AddXY(i.ToString()/*dpxvalue[i].ToString("N3")*/, obj_daub.sig5[i].ToString());
        chart1.Series["Denoised Sig."].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
    }
    // 
}



private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
{

}

private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
{
    char ch1 = e.KeyChar;

    if (!char.IsDigit(ch1) && ch1 != 8 && ch1 != 46)
    { e.Handled = true; }
}

private void button20_Click(object sender, EventArgs e)
{
    shac = true;//show actual
    if(tdm==false)
    {
    if (richTextBox2.Text == "")
    { actd = ((31 * 12.29) / 1024); }
    else
    {
        ds = Convert.ToDouble(richTextBox2.Text);//m
        actd = ((ds * 12.29) / 1024) ;//cm
        chart1.Series["Vib. Signal"].Enabled = false;
        chart1.Series["Vib Signal"].Enabled = true;
       // chart1.Series["Vib Signal"].Points.Clear();
        chart7.Series["Displacement"].Enabled = false;
        chart7.Series["displacement"].Enabled = true;
        chart7.Series["Velocity"].Enabled = false;
        chart7.Series["velocity"].Enabled = true;
        chart7.Series["Acceleration"].Enabled = false;
        chart7.Series["acceleration"].Enabled = true; 
    }
    }
  
/*else
    {
        

 if (verticaldir == true)
    {
        double dim = Convert.ToDouble(richTextBox4.Text);
        int h = selected_object.Height;
        actd = (dim / h);
    }
    else
    {
        double dim = Convert.ToDouble(richTextBox8.Text);
        int w = selected_object.Width;
        actd = (dim / w);
    }
   
    }
    chart1.Series["Vib. Signal"].Enabled = false;
    chart1.Series["Vib Signal"].Enabled = true;
    // chart1.Series["Vib Signal"].Points.Clear();
    chart7.Series["Displacement"].Enabled = false;
    chart7.Series["displacement"].Enabled = true;
    chart7.Series["Velocity"].Enabled = false;
    chart7.Series["velocity"].Enabled = true;
    chart7.Series["Acceleration"].Enabled = false;
    chart7.Series["acceleration"].Enabled = true;*/
    chart1.Series["Vib. Signal"].Enabled = false;
    chart1.Series["Vib Signal"].Enabled = true;
    // chart1.Series["Vib Signal"].Points.Clear();
    chart7.Series["Displacement"].Enabled = false;
    chart7.Series["displacement"].Enabled = true;
    chart7.Series["Velocity"].Enabled = false;
    chart7.Series["velocity"].Enabled = true;
    chart7.Series["Acceleration"].Enabled = false;
    chart7.Series["acceleration"].Enabled = true;  
                   
}

private void richTextBox4_KeyPress(object sender, KeyPressEventArgs e)
{
    char ch1 = e.KeyChar;

    if (!char.IsDigit(ch1) && ch1 != 8 && ch1 != 46)
    { e.Handled = true; }

}

private void richTextBox8_KeyPress(object sender, KeyPressEventArgs e)
{
    char ch2 = e.KeyChar;

    if (!char.IsDigit(ch2) && ch2 != 8 && ch2 != 46)
    { e.Handled = true; }
}

private void button17_Click_2(object sender, EventArgs e)
{
    button22.Enabled = true;
    startreadingdisplacementvalue = true;
}

private void button22_Click(object sender, EventArgs e)
{
    button23.Enabled = true;
    stopreadingdisplacementvalue = true;
}

private void button23_Click(object sender, EventArgs e)
{
    //make options if distance true then this should not be there..otherwise will modify actd
    if (tdm == true)
    {
        if (selectdimatcurrpt == false)
        {
            if (verticaldir == true)
            {
                double dim = Convert.ToDouble(richTextBox4.Text);
                int h = selected_object.Height;
                actd = (dim / h);
            }
            else
            {
                double dim = Convert.ToDouble(richTextBox8.Text);
                int w = selected_object.Width;
                actd = (dim / w);
            }
        }
    }
   
    double displ = (Math.Abs(yd.Max() - yd.Min())) * actd;
    richTextBox9.Text = displ.ToString()+"cm";
    yd.Clear(); startreadingdisplacementvalue = false; stopreadingdisplacementvalue = false;
}

private void radioButton10_CheckedChanged(object sender, EventArgs e)
{
    if (radioButton10.Checked == true)
    {
        
        radioButton9.Checked = false;
        groupBox11.Enabled = true;
         groupBox12.Enabled = false;
        tdm = false;
    }
}

      private void radioButton9_CheckedChanged(object sender, EventArgs e)
      {
          
    if (radioButton9.Checked == true)
    {
        
        radioButton10.Checked = false;
        groupBox12.Enabled = true;
         groupBox11.Enabled = false;
        tdm = true;
    }
      }

      private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
      {

      }

      private void button21_Click(object sender, EventArgs e)
      {
          selectdimatcurrpt = true;
          if (verticaldir == true)
          {
              double dim = Convert.ToDouble(richTextBox4.Text);
              int h = selected_object.Height;
              actd = (dim / h);
          }
          else
          {
              double dim = Convert.ToDouble(richTextBox8.Text);
              int w = selected_object.Width;
              actd = (dim / w);
          }
      }

      private void button24_Click(object sender, EventArgs e)
      {
          shac = false;
          
        
          chart1.Series["Vib. Signal"].Enabled = true;
          chart1.Series["Vib Signal"].Enabled = false;
          // chart1.Series["Vib Signal"].Points.Clear();
          chart7.Series["Displacement"].Enabled = true;
          chart7.Series["displacement"].Enabled = false;
          chart7.Series["Velocity"].Enabled = true;
          chart7.Series["velocity"].Enabled =false;
          chart7.Series["Acceleration"].Enabled = true;
          chart7.Series["acceleration"].Enabled = false;  
      }

      private void button25_Click(object sender, EventArgs e)
      {
          removenoisypikes = true;
      }

      private void button28_Click(object sender, EventArgs e)
      {
          framecount1 = timer5counter;
      }

      private void button27_Click(object sender, EventArgs e)
      {
          framecount2 = timer5counter;
      }

      private void button26_Click(object sender, EventArgs e)
      {
          tm = (framecount2 - framecount1) / 500;//500fps
          double dpm;
          dpm = 0.5 * 980 * Math.Pow(tm, 2);//cm
          richTextBox5.Text = dpm.ToString()+"cm";
      }

      private void toolStripButton1_Click_2(object sender, EventArgs e)
      {
          shac = true;
          if (tdm == false)
          {
              if (richTextBox2.Text == "")
              { actd = ((31 * 12.29) / 1024) * 10; }
              else
              {
                  ds = Convert.ToDouble(richTextBox2.Text);//m
                  actd = ((ds * 12.29) / 1024) ;//cm
                  chart1.Series["Vib. Signal"].Enabled = false;
                  chart1.Series["Vib Signal"].Enabled = true;
                  // chart1.Series["Vib Signal"].Points.Clear();
                  chart7.Series["Displacement"].Enabled = false;
                  chart7.Series["displacement"].Enabled = true;
                  chart7.Series["Velocity"].Enabled = false;
                  chart7.Series["velocity"].Enabled = true;
                  chart7.Series["Acceleration"].Enabled = false;
                  chart7.Series["acceleration"].Enabled = true;  
              }
          }

          /*else
              {
        

           if (verticaldir == true)
              {
                  double dim = Convert.ToDouble(richTextBox4.Text);
                  int h = selected_object.Height;
                  actd = (dim / h);
              }
              else
              {
                  double dim = Convert.ToDouble(richTextBox8.Text);
                  int w = selected_object.Width;
                  actd = (dim / w);
              }
   
              }
              chart1.Series["Vib. Signal"].Enabled = false;
              chart1.Series["Vib Signal"].Enabled = true;
              // chart1.Series["Vib Signal"].Points.Clear();
              chart7.Series["Displacement"].Enabled = false;
              chart7.Series["displacement"].Enabled = true;
              chart7.Series["Velocity"].Enabled = false;
              chart7.Series["velocity"].Enabled = true;
              chart7.Series["Acceleration"].Enabled = false;
              chart7.Series["acceleration"].Enabled = true;*/
          chart1.Series["Vib. Signal"].Enabled = false;
          chart1.Series["Vib Signal"].Enabled = true;
          // chart1.Series["Vib Signal"].Points.Clear();
          chart7.Series["Displacement"].Enabled = false;
          chart7.Series["displacement"].Enabled = true;
          chart7.Series["Velocity"].Enabled = false;
          chart7.Series["velocity"].Enabled = true;
          chart7.Series["Acceleration"].Enabled = false;
          chart7.Series["acceleration"].Enabled = true;  
      }

      private void button29_Click(object sender, EventArgs e)
      {
         
          groupBox2.Enabled = true;
          groupBox2.Show();
          timer5.Start();
         
      }



    }
}

//////////////////////////////////end of ANN PART/////////////////////////////////////////////////////////////////////////////////////////////////////////



[StructLayout(LayoutKind.Sequential)]
public unsafe struct PCO_Description
{
  public  ushort        wSize;                   // Sizeof this struct
  public  ushort        wSensorTypeDESC;         // Sensor type
  public  ushort        wSensorSubTypeDESC;      // Sensor subtype
  public  ushort        wMaxHorzResStdDESC;      // Maxmimum horz. resolution in std.mode
  public  ushort        wMaxVertResStdDESC;      // Maxmimum vert. resolution in std.mode
  public  ushort        wMaxHorzResExtDESC;      // Maxmimum horz. resolution in ext.mode
  public  ushort        wMaxVertResExtDESC;      // Maxmimum vert. resolution in ext.mode
  public  ushort        wDynResDESC;             // Dynamic resolution of ADC in bit
  public  ushort        wMaxBinHorzDESC;         // Maxmimum horz. binning
  public  ushort        wBinHorzSteppingDESC;    // Horz. bin. stepping (0:bin, 1:lin)
  public  ushort        wMaxBinVertDESC;         // Maxmimum vert. binning
  public  ushort        wBinVertSteppingDESC;    // Vert. bin. stepping (0:bin, 1:lin)
  public  ushort        wRoiHorStepsDESC;        // Minimum granularity of ROI in pixels
  public  ushort        wRoiVertStepsDESC;       // Minimum granularity of ROI in pixels
  public  ushort        wNumADCsDESC;            // Number of ADCs in system
  public  ushort        ZZwAlignDummy1;
  public  fixed uint    dwPixelRateDESC[4];      // Possible pixelrate in Hz
  public  fixed uint    ZZdwDummypr[20];
  public  fixed ushort  wConvFactDESC[4];        // Possible conversion factor in e/cnt
  public  fixed ushort  ZZdwDummycv[20];
  public  ushort        wIRDESC;                 // IR enhancment possibility
  public  ushort        ZZwAlignDummy2;
  public  uint          dwMinDelayDESC;          // Minimum delay time in ns
  public  uint          dwMaxDelayDESC;          // Maximum delay time in ms
  public  uint          dwMinDelayStepDESC;      // Minimum stepping of delay time in ns
  public  uint          dwMinExposureDESC;       // Minimum exposure time in ns
  public  uint          dwMaxExposureDESC;       // Maximum exposure time in ms
  public  uint          dwMinExposureStepDESC;   // Minimum stepping of exposure time in ns
  public  uint          dwMinDelayIRDESC;        // Minimum delay time in ns
  public  uint          dwMaxDelayIRDESC;        // Maximum delay time in ms
  public  uint          dwMinExposureIRDESC;     // Minimum exposure time in ns
  public  uint          dwMaxExposureIRDESC;     // Maximum exposure time in ms
  public  ushort        wTimeTableDESC;          // Timetable for exp/del possibility
  public  ushort        wDoubleImageDESC;        // Double image mode possibility
  public  short         sMinCoolSetDESC;         // Minimum value for cooling
  public  short         sMaxCoolSetDESC;         // Maximum value for cooling
  public  short         sDefaultCoolSetDESC;     // Default value for cooling
  public  ushort        wPowerDownModeDESC;      // Power down mode possibility 
  public  ushort        wOffsetRegulationDESC;   // Offset regulation possibility
  public  ushort        wColorPatternDESC;       // Color pattern of color chip
          // four nibbles (0,1,2,3) in ushort 
          //  ----------------- 
          //  | 3 | 2 | 1 | 0 |
          //  ----------------- 
          //   
          // describe row,column  2,2 2,1 1,2 1,1
          // 
          //   column1 column2
          //  ----------------- 
          //  |       |       |
          //  |   0   |   1   |   row1
          //  |       |       |
          //  -----------------
          //  |       |       |
          //  |   2   |   3   |   row2
          //  |       |       |
          //  -----------------
          // 
  public  ushort        wPatternTypeDESC;        // Pattern type of color chip
          // 0: Bayer pattern RGB
          // 1: Bayer pattern CMY
  public  ushort        wDSNUCorrectionModeDESC; // DSNU correction mode possibility
  public  ushort        ZZwAlignDummy3;          //
  public  fixed uint    dwReservedDESC[8];
  public  fixed uint    ZZdwDummy[40];
} ;

unsafe class PCO_SDK_LibWrapper
{
  [DllImport("sc2_cam.dll", EntryPoint="PCO_OpenCamera",
     ExactSpelling=false)]
  public static extern int PCO_OpenCamera(ref int pHandle, UInt16 wCamNum );

  [DllImport("sc2_cam.dll", EntryPoint="PCO_CloseCamera",
     ExactSpelling=false)]
  public static extern int PCO_CloseCamera(int pHandle);

  [DllImport("sc2_cam.dll", EntryPoint="PCO_GetCameraDescription",
     ExactSpelling=false)]
  public static extern int PCO_GetCameraDescription(int pHandle, ref PCO_Description strDescription);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_AllocateBuffer",
     ExactSpelling = false)]
  public static extern int PCO_AllocateBuffer(int pHandle, ref short sBufNr, int size, ref UInt16* wBuf, ref int hEvent);
  //HANDLE ph,SHORT* sBufNr,DWORD size,WORD** wBuf,HANDLE *hEvent

  [DllImport("sc2_cam.dll", EntryPoint="PCO_FreeBuffer",
     ExactSpelling=false)]
  public static extern int PCO_FreeBuffer(int pHandle, short sBufNr);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_ArmCamera",
     ExactSpelling = false)]
  public static extern int PCO_ArmCamera(int pHandle);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_CamLinkSetImageParameters",
     ExactSpelling = false)]
  public static extern int PCO_CamLinkSetImageParameters(int pHandle, UInt16 wXRes, UInt16 wYRes);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_SetRecordingState",
     ExactSpelling = false)]
  public static extern int PCO_SetRecordingState(int pHandle, UInt16 wRecState);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_AddBuffer",
     ExactSpelling = false)]
  public static extern int PCO_AddBuffer(int pHandle, UInt32 dwFirstImage, UInt32 dwLastImage, short sBufNr);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_AddBufferEx",
     ExactSpelling = false)]
  public static extern int PCO_AddBufferEx(int pHandle, UInt32 dwFirstImage, UInt32 dwLastImage, short sBufNr, UInt16 wXRes, UInt16 wYRes, UInt16 wBitPerPixel);

  [DllImport("sc2_cam.dll", EntryPoint = "PCO_GetBufferStatus",
     ExactSpelling = false)]
  public static extern int PCO_GetBufferStatus(int pHandle, short sBufNr, ref UInt32 dwStatusDll, ref UInt32 dwStatusDrv);
};



