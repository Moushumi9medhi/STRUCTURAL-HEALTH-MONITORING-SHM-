namespace CSharpDemo
{
    partial class CameraSettings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Image size");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Exposure");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Delay");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("pixel rate");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("timing", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Camera1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("horizontal x vertical(mm square)");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("diagonal(mm)");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Imaging Area", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Resolution");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Pixel size");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Pixel pitch");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Pixel fill factor");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Pixel array specification", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("supply voltage");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Conversion gain");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Type");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Efficiency");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Exposure time");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Shutter", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Package");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("On-chip");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Off-chip");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Programmable Controls", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Sensor", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode11,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode22,
            treeNode23,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Memory");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Recorder mode");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Acquire mode");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Timestamp");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Recording", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraSettings));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(866, 572);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.SplitterWidth = 15;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(25, 36);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node26";
            treeNode1.Text = "General";
            treeNode2.Name = "Node27";
            treeNode2.Text = "Image size";
            treeNode3.Name = "Node29";
            treeNode3.Text = "Exposure";
            treeNode4.Name = "Node30";
            treeNode4.Text = "Delay";
            treeNode5.Name = "Node31";
            treeNode5.Text = "pixel rate";
            treeNode6.Name = "Node28";
            treeNode6.Text = "timing";
            treeNode7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            treeNode7.Name = "Node23";
            treeNode7.Text = "Camera1";
            treeNode8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode8.Name = "Node1";
            treeNode8.Tag = "";
            treeNode8.Text = "Name";
            treeNode9.Name = "Node3";
            treeNode9.Text = "horizontal x vertical(mm square)";
            treeNode10.Name = "Node4";
            treeNode10.Text = "diagonal(mm)";
            treeNode11.BackColor = System.Drawing.Color.MistyRose;
            treeNode11.ForeColor = System.Drawing.Color.MidnightBlue;
            treeNode11.Name = "Node2";
            treeNode11.Text = "Imaging Area";
            treeNode12.Name = "Node16";
            treeNode12.Text = "Resolution";
            treeNode13.Name = "Node19";
            treeNode13.Text = "Pixel size";
            treeNode14.Name = "Node21";
            treeNode14.Text = "Pixel pitch";
            treeNode15.Name = "Node22";
            treeNode15.Text = "Pixel fill factor";
            treeNode16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode16.Name = "Node15";
            treeNode16.Text = "Pixel array specification";
            treeNode17.BackColor = System.Drawing.Color.MistyRose;
            treeNode17.Name = "Node0";
            treeNode17.Text = "supply voltage";
            treeNode18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode18.Name = "Node1";
            treeNode18.Text = "Conversion gain";
            treeNode19.Name = "Node4";
            treeNode19.Text = "Type";
            treeNode20.Name = "Node5";
            treeNode20.Text = "Efficiency";
            treeNode21.Name = "Node6";
            treeNode21.Text = "Exposure time";
            treeNode22.BackColor = System.Drawing.Color.MistyRose;
            treeNode22.Name = "Node3";
            treeNode22.Text = "Shutter";
            treeNode23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode23.Name = "Node7";
            treeNode23.Text = "Package";
            treeNode24.Name = "Node9";
            treeNode24.Text = "On-chip";
            treeNode25.Name = "Node10";
            treeNode25.Text = "Off-chip";
            treeNode26.BackColor = System.Drawing.Color.MistyRose;
            treeNode26.Name = "Node8";
            treeNode26.Text = "Programmable Controls";
            treeNode27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            treeNode27.Name = "Node0";
            treeNode27.Text = "Sensor";
            treeNode28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            treeNode28.Name = "Node0";
            treeNode28.Text = "Memory";
            treeNode29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode29.Name = "Node7";
            treeNode29.Text = "Recorder mode";
            treeNode30.BackColor = System.Drawing.Color.MistyRose;
            treeNode30.Name = "Node8";
            treeNode30.Text = "Acquire mode";
            treeNode31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode31.Name = "Node9";
            treeNode31.Text = "Timestamp";
            treeNode32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            treeNode32.Name = "Node1";
            treeNode32.Text = "Recording";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode27,
            treeNode28,
            treeNode32});
            this.treeView1.Size = new System.Drawing.Size(203, 386);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 10);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
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
            this.listView1.Location = new System.Drawing.Point(22, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(448, 82);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView1_ItemMouseHover);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(86, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(288, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected :";
            // 
            // CameraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 572);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CameraSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera Settings";
            this.Load += new System.EventHandler(this.CameraSettings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}