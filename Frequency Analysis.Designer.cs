namespace CSharpDemo
{
    partial class Frequency_Analysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frequency_Analysis));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Bins");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Hertz");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Magnitude Spectrum", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Radians-Bins");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Radians-Hertz");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Degree-Bins");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Degree-Hertz");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Phase Spectrum", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Absolute Magnitude");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Periodogram");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Power Spectrum", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Energy Spectrum");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Double-sided", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode8,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("bins");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("hertz");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("magnitude spectrum", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("radians-bins");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("radians-hertz");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("degree-bins");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("degree-hertz");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("phase spectrum", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("absolute magnitude");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("periodogram");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("power spectrum", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("energy spectrum");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Single-sided", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode21,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("FREQUENCY ANALYSIS", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode26});
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.button16 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.button10 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Location = new System.Drawing.Point(0, 677);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(851, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.MintCream;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripDropDownButton1.Enabled = false;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(95, 22);
            this.toolStripDropDownButton1.Text = "Spectral peaks";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoToolTip = true;
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem1.Image = global::CSharpDemo.Properties.Resources.star_lime1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.ToolTipText = "Star";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AutoToolTip = true;
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Indigo;
            this.toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem2.Image = global::CSharpDemo.Properties.Resources.diamond_lime1;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            this.toolStripMenuItem2.ToolTipText = "Diamond";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.AutoToolTip = true;
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem3.Image = global::CSharpDemo.Properties.Resources.circle;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem3.ToolTipText = "Circle";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.AutoToolTip = true;
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.Indigo;
            this.toolStripMenuItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem4.Image = global::CSharpDemo.Properties.Resources.plus_lime1;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            this.toolStripMenuItem4.ToolTipText = "Plus";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.AutoToolTip = true;
            this.toolStripMenuItem5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem5.Image = global::CSharpDemo.Properties.Resources.square;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem5.ToolTipText = "Square";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.AutoToolTip = true;
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.Indigo;
            this.toolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem6.Image = global::CSharpDemo.Properties.Resources.tri_lime1;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            this.toolStripMenuItem6.ToolTipText = "Triangle";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.AutoToolTip = true;
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripMenuItem7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem7.Image = global::CSharpDemo.Properties.Resources.tri_down;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem7.ToolTipText = "Triangle down";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.AutoToolTip = true;
            this.toolStripMenuItem8.BackColor = System.Drawing.Color.Indigo;
            this.toolStripMenuItem8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem8.Image = global::CSharpDemo.Properties.Resources.hdash;
            this.toolStripMenuItem8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem8.ToolTipText = "Horizontal dash";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.AutoToolTip = true;
            this.toolStripMenuItem9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripMenuItem9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem9.Image = global::CSharpDemo.Properties.Resources.vdash;
            this.toolStripMenuItem9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(184, 26);
            this.toolStripMenuItem9.Text = "toolStripMenuItem9";
            this.toolStripMenuItem9.ToolTipText = "Verticle dash";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(123, 22);
            this.toolStripSplitButton1.Text = "Modal Frequencies";
            this.toolStripSplitButton1.ToolTipText = "Show Modal Frequencies";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoToolTip = true;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.toolStripComboBox1.MaxDropDownItems = 3;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Text = "3";
            this.toolStripComboBox1.ToolTipText = "Select number of modal frequencies";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(851, 652);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(10, 15);
            this.treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.SystemColors.Info;
            treeNode1.Name = "Node5";
            treeNode1.Text = "Bins";
            treeNode1.ToolTipText = "Bins";
            treeNode2.BackColor = System.Drawing.Color.Bisque;
            treeNode2.Name = "Node6";
            treeNode2.Text = "Hertz";
            treeNode2.ToolTipText = "Hertz";
            treeNode3.BackColor = System.Drawing.Color.Thistle;
            treeNode3.Name = "Node0";
            treeNode3.Text = "Magnitude Spectrum";
            treeNode4.BackColor = System.Drawing.SystemColors.Info;
            treeNode4.Name = "Node7";
            treeNode4.Text = "Radians-Bins";
            treeNode4.ToolTipText = "Radians-Bins";
            treeNode5.BackColor = System.Drawing.Color.Bisque;
            treeNode5.Name = "Node8";
            treeNode5.Text = "Radians-Hertz";
            treeNode5.ToolTipText = "Radians-Hertz";
            treeNode6.BackColor = System.Drawing.SystemColors.Info;
            treeNode6.Name = "Node9";
            treeNode6.Text = "Degree-Bins";
            treeNode6.ToolTipText = "Degree-Bins";
            treeNode7.BackColor = System.Drawing.Color.Bisque;
            treeNode7.Name = "Node10";
            treeNode7.Text = "Degree-Hertz";
            treeNode7.ToolTipText = "Degree-Hertz";
            treeNode8.BackColor = System.Drawing.Color.Thistle;
            treeNode8.Name = "Node1";
            treeNode8.Text = "Phase Spectrum";
            treeNode8.ToolTipText = "Phase Spectrum";
            treeNode9.BackColor = System.Drawing.SystemColors.Info;
            treeNode9.Name = "Node0";
            treeNode9.Text = "Absolute Magnitude";
            treeNode9.ToolTipText = "Absolute Magnitude";
            treeNode10.BackColor = System.Drawing.Color.Bisque;
            treeNode10.Name = "Node0";
            treeNode10.Text = "Periodogram";
            treeNode10.ToolTipText = "Periodogram";
            treeNode11.BackColor = System.Drawing.Color.Thistle;
            treeNode11.Name = "Node2";
            treeNode11.Text = "Power Spectrum";
            treeNode11.ToolTipText = "Power Spectrum";
            treeNode12.BackColor = System.Drawing.Color.Thistle;
            treeNode12.Name = "Node3";
            treeNode12.Text = "Energy Spectrum";
            treeNode12.ToolTipText = "Energy Spectrum";
            treeNode13.BackColor = System.Drawing.Color.LightBlue;
            treeNode13.Name = "Node0";
            treeNode13.Text = "Double-sided";
            treeNode13.ToolTipText = "Double-sided";
            treeNode14.BackColor = System.Drawing.SystemColors.Info;
            treeNode14.Name = "Node11";
            treeNode14.Text = "bins";
            treeNode14.ToolTipText = "bins";
            treeNode15.BackColor = System.Drawing.Color.Bisque;
            treeNode15.Name = "Node12";
            treeNode15.Text = "hertz";
            treeNode15.ToolTipText = "hertz";
            treeNode16.BackColor = System.Drawing.Color.Thistle;
            treeNode16.Name = "Node1";
            treeNode16.Text = "magnitude spectrum";
            treeNode16.ToolTipText = "magnitude spectrum";
            treeNode17.BackColor = System.Drawing.SystemColors.Info;
            treeNode17.Name = "Node13";
            treeNode17.Text = "radians-bins";
            treeNode17.ToolTipText = "radians-bins";
            treeNode18.BackColor = System.Drawing.Color.Bisque;
            treeNode18.Name = "Node14";
            treeNode18.Text = "radians-hertz";
            treeNode18.ToolTipText = "radians-hertz";
            treeNode19.BackColor = System.Drawing.SystemColors.Info;
            treeNode19.Name = "Node15";
            treeNode19.Text = "degree-bins";
            treeNode19.ToolTipText = "degree-bins";
            treeNode20.BackColor = System.Drawing.Color.Bisque;
            treeNode20.Name = "Node16";
            treeNode20.Text = "degree-hertz";
            treeNode20.ToolTipText = "degree-hertz";
            treeNode21.BackColor = System.Drawing.Color.Thistle;
            treeNode21.Name = "Node2";
            treeNode21.Text = "phase spectrum";
            treeNode21.ToolTipText = "phase spectrum";
            treeNode22.BackColor = System.Drawing.SystemColors.Info;
            treeNode22.Name = "Node2";
            treeNode22.Text = "absolute magnitude";
            treeNode22.ToolTipText = "absolute magnitude";
            treeNode23.BackColor = System.Drawing.Color.Bisque;
            treeNode23.Name = "Node1";
            treeNode23.Text = "periodogram";
            treeNode23.ToolTipText = "periodogram";
            treeNode24.BackColor = System.Drawing.Color.Thistle;
            treeNode24.Name = "Node3";
            treeNode24.Text = "power spectrum";
            treeNode24.ToolTipText = "power spectrum";
            treeNode25.BackColor = System.Drawing.Color.Thistle;
            treeNode25.Name = "Node4";
            treeNode25.Text = "energy spectrum";
            treeNode26.BackColor = System.Drawing.Color.LightBlue;
            treeNode26.Name = "Node0";
            treeNode26.Text = "Single-sided";
            treeNode26.ToolTipText = "Single-sided";
            treeNode27.BackColor = System.Drawing.Color.Silver;
            treeNode27.Name = "Node17";
            treeNode27.Text = "FREQUENCY ANALYSIS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode27});
            this.treeView1.Size = new System.Drawing.Size(87, 589);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(731, 652);
            this.splitContainer2.SplitterDistance = 430;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer3.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel1_Paint);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer3.Panel2.Controls.Add(this.button11);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Panel2.Controls.Add(this.button5);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer3.Panel2.Controls.Add(this.button16);
            this.splitContainer3.Panel2.Controls.Add(this.button13);
            this.splitContainer3.Panel2.Controls.Add(this.button12);
            this.splitContainer3.Panel2.Controls.Add(this.button9);
            this.splitContainer3.Panel2.Controls.Add(this.button8);
            this.splitContainer3.Panel2.Controls.Add(this.button7);
            this.splitContainer3.Panel2.Controls.Add(this.button6);
            this.splitContainer3.Panel2.Controls.Add(this.button4);
            this.splitContainer3.Panel2.Controls.Add(this.button3);
            this.splitContainer3.Panel2.Controls.Add(this.button2);
            this.splitContainer3.Size = new System.Drawing.Size(731, 430);
            this.splitContainer3.SplitterDistance = 617;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.zedGraphControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graphical Analysis";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.AutoScroll = true;
            this.zedGraphControl1.BackColor = System.Drawing.Color.Magenta;
            this.zedGraphControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl1.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Z)));
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphControl1.ForeColor = System.Drawing.Color.White;
            this.zedGraphControl1.IsEnableSelection = true;
            this.zedGraphControl1.IsShowContextMenu = false;
            this.zedGraphControl1.IsShowHScrollBar = true;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.IsShowVScrollBar = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(2, -2);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = double.NaN;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = double.NaN;
            this.zedGraphControl1.Size = new System.Drawing.Size(579, 385);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.Red;
            this.button11.Location = new System.Drawing.Point(2, 556);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(86, 50);
            this.button11.TabIndex = 13;
            this.button11.Text = "normalised amplitude spectrum";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(5, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(78, 59);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phase";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.ForeColor = System.Drawing.Color.Fuchsia;
            this.radioButton5.Location = new System.Drawing.Point(6, 35);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(60, 17);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Text = "Single";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.ForeColor = System.Drawing.Color.Fuchsia;
            this.radioButton6.Location = new System.Drawing.Point(6, 16);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(65, 17);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Text = "Double";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(1, 209);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 35);
            this.button5.TabIndex = 15;
            this.button5.Text = "Stack all vertically";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(5, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(78, 59);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequency";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.Fuchsia;
            this.radioButton2.Location = new System.Drawing.Point(6, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Hertz";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.Fuchsia;
            this.radioButton1.Location = new System.Drawing.Point(6, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Bins";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Location = new System.Drawing.Point(5, 144);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(78, 59);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phase";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.Color.Fuchsia;
            this.radioButton3.Location = new System.Drawing.Point(6, 35);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(66, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Text = "Degree";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.ForeColor = System.Drawing.Color.Fuchsia;
            this.radioButton4.Location = new System.Drawing.Point(6, 16);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(65, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.Text = "Radian";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // button16
            // 
            this.button16.Enabled = false;
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.Red;
            this.button16.Location = new System.Drawing.Point(1, 555);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(86, 50);
            this.button16.TabIndex = 12;
            this.button16.Text = "Normalised Amplitude Spectrum";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Visible = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.Red;
            this.button13.Location = new System.Drawing.Point(3, 520);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(84, 35);
            this.button13.TabIndex = 11;
            this.button13.Text = "normalised to nyquist";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.Red;
            this.button12.Location = new System.Drawing.Point(3, 483);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(84, 35);
            this.button12.TabIndex = 10;
            this.button12.Text = "show border of textobj";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Red;
            this.button9.Location = new System.Drawing.Point(3, 447);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(84, 35);
            this.button9.TabIndex = 7;
            this.button9.Text = "Show spectral peaks";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.Red;
            this.button8.Location = new System.Drawing.Point(3, 412);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(84, 35);
            this.button8.TabIndex = 6;
            this.button8.Text = "Show/Hide yvalue";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Red;
            this.button7.Location = new System.Drawing.Point(3, 376);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(84, 35);
            this.button7.TabIndex = 5;
            this.button7.Text = "FFT PLOT";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(3, 340);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 35);
            this.button6.TabIndex = 4;
            this.button6.Text = "Plain vertically";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(3, 301);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 37);
            this.button4.TabIndex = 2;
            this.button4.Text = "zoom in";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(2, 277);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 21);
            this.button3.TabIndex = 1;
            this.button3.Text = "zoom out";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(1, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 21);
            this.button2.TabIndex = 0;
            this.button2.Text = "Clear graph(s)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer4.Panel1.Controls.Add(this.button10);
            this.splitContainer4.Panel1.Controls.Add(this.button20);
            this.splitContainer4.Panel1.Controls.Add(this.button19);
            this.splitContainer4.Panel1.Controls.Add(this.button18);
            this.splitContainer4.Panel1.Controls.Add(this.label1);
            this.splitContainer4.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer4.Panel2.Controls.Add(this.listView1);
            this.splitContainer4.Size = new System.Drawing.Size(727, 213);
            this.splitContainer4.SplitterDistance = 290;
            this.splitContainer4.SplitterWidth = 8;
            this.splitContainer4.TabIndex = 0;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button10.Location = new System.Drawing.Point(3, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(114, 47);
            this.button10.TabIndex = 6;
            this.button10.Text = "list modal frequencies";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button20.Location = new System.Drawing.Point(3, 150);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(114, 41);
            this.button20.TabIndex = 5;
            this.button20.Text = "Resolution";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button19.Location = new System.Drawing.Point(3, 103);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(114, 41);
            this.button19.TabIndex = 4;
            this.button19.Text = "Bandwidth";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button18.Location = new System.Drawing.Point(3, 56);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(114, 41);
            this.button18.TabIndex = 3;
            this.button18.Text = "LRF";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HotTracking = true;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(22, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(371, 183);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Frequency_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(851, 699);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Frequency_Analysis";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frequency_Analysis";
            this.Load += new System.EventHandler(this.Frequency_Analysis_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Button button11;
    }
}