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
    public partial class CameraSettings : Form
    {
        public CameraSettings()
        {
            InitializeComponent();
        }

        private void CameraSettings_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // textBox1.Text = treeView1.SelectedNode.Text;//how to check if the selected node has a parent
        
        }

        private void button1_Click(object sender, EventArgs e)
        {


            pictureBox1.Show();
        }

       

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pictureBox1.Hide();
            ListViewItem itm = new ListViewItem();
           textBox1.Text = e.Node.FullPath;
           listView1.Clear();
           listView1.Groups.Clear();
           bool groupexist = false;
            
           listView1.Size = new System.Drawing.Size(424,60);
          
            switch (e.Node.Text)
            {
                case "Camera1":
                    groupexist = true;
            listView1.Size = new System.Drawing.Size(424, 400);
            listView1.Columns.Add("", 200);
            listView1.Columns.Add("unit", 100);
            listView1.Columns.Add("PCO.1200s", 200);
            ListViewGroup gen = new ListViewGroup("General");
            ListViewGroup imge = new ListViewGroup("Image");
            ListViewGroup tim = new ListViewGroup("Timing");
            listView1.Groups.Add(gen);
            listView1.Groups.Add(imge);
            listView1.Groups.Add(tim);

            listView1.Items.Add(new ListViewItem(new string[]{"Camera Name","  ---","Camera 1"},gen));
            listView1.Items.Add(new ListViewItem(new string[] { "Camera Type", "  ---", "pco.1200s" }, gen));
            listView1.Items.Add(new ListViewItem(new string[] { "Trigger mode", "  ---", "auto" }, gen));
            listView1.Items.Add(new ListViewItem(new string[] { "Serial Number", "  ---", "1668" }, gen));
            listView1.Items.Add(new ListViewItem(new string[] { "Image size", "pixels", "1280 x 1024" }, imge));
            listView1.Items.Add(new ListViewItem(new string[] { "Exposure", "us", "20.000000" }, tim));
            listView1.Items.Add(new ListViewItem(new string[] { "Delay", "us", "0.000000" }, tim));
            listView1.Items.Add(new ListViewItem(new string[] { "Pixel rate", "pixels/s", "67692308" }, tim));
    
    


                    break;
                case "Shutter":
                    groupexist = true;
                    listView1.Size = new System.Drawing.Size(444, 400);
                    listView1.Columns.Add("", 130);
                    listView1.Columns.Add("unit", 60);
                    listView1.Columns.Add("PCO.1200s", 330);
                    ListViewGroup gen6 = new ListViewGroup("Type");
                    ListViewGroup imge6 = new ListViewGroup("Efficiency");
                    ListViewGroup tim6 = new ListViewGroup("Exposure time");
                    listView1.Groups.Add(gen6);
                    listView1.Groups.Add(imge6);
                    listView1.Groups.Add(tim6);

                    listView1.Items.Add(new ListViewItem(new string[] { "Shutter", "  ---", "CTrueSNAP \n freeze-frame \n electronic shutter" }, gen6));
                    listView1.Items.Add(new ListViewItem(new string[] { "Shutter Efficiency", " ---", ">99.95" }, imge6));
                    listView1.Items.Add(new ListViewItem(new string[] { "Shutter exposure time", " us", "2-33" }, tim6));
                    break;

               
                case "Imaging Area":
                    groupexist = true;
                    listView1.Size = new System.Drawing.Size(400, 200);
                    listView1.Columns.Add("unit", 200);
                    listView1.Columns.Add("PCO.1200s", 2100);
                    ListViewGroup gen7 = new ListViewGroup("horizontal x vertical");
                    ListViewGroup imge7 = new ListViewGroup("diagonal");
                    listView1.Groups.Add(gen7);
                    listView1.Groups.Add(imge7);

                    listView1.Items.Add(new ListViewItem(new string[] { "mm square", "15.36 x 12.29" }, gen7));
                    listView1.Items.Add(new ListViewItem(new string[] { "mm", "19.67" }, imge7));
                    break;
                case "Pixel array specification":
                    groupexist = true;
                    listView1.Size = new System.Drawing.Size(400, 400);
                    listView1.Columns.Add("unit", 100);
                    listView1.Columns.Add("PCO.1200s", 300);
                    ListViewGroup gen9 = new ListViewGroup("Resolution");
                    ListViewGroup imge9 = new ListViewGroup("Pixel size");
                    ListViewGroup tim9 = new ListViewGroup("Pixel pitch");
                    ListViewGroup gim9 = new ListViewGroup("Pixel fill factor");
                    listView1.Groups.Add(gen9);
                    listView1.Groups.Add(imge9);
                    listView1.Groups.Add(tim9);
                    listView1.Groups.Add(gim9);

                    listView1.Items.Add(new ListViewItem(new string[] { "pixels", "  1280 x 1024" }, gen9));
                    listView1.Items.Add(new ListViewItem(new string[] { "um", " 12 x 12" }, imge9));
                    listView1.Items.Add(new ListViewItem(new string[] { "um", "12" }, tim9));
                    listView1.Items.Add(new ListViewItem(new string[] { "%", " 40" }, tim9));

                    break;
               
                case "Programmable Controls":
                    groupexist = true;
                    listView1.Size = new System.Drawing.Size(400, 400);
                    listView1.Columns.Add("", 400);
                    ListViewGroup gen11 = new ListViewGroup("On-chip");
                    ListViewGroup imge11 = new ListViewGroup("Off-chip");
                    listView1.Groups.Add(gen11);
                    listView1.Groups.Add(imge11);
                    listView1.Items.Add(new ListViewItem(new string[] { "ADC controls" }, gen11));
                    listView1.Items.Add(new ListViewItem(new string[] { "Output multiplexing" }, gen11));
                    listView1.Items.Add(new ListViewItem(new string[] { "ADC calibration" }, gen11));
                    listView1.Items.Add(new ListViewItem(new string[] { "Window size and locations" }, imge11));
                    listView1.Items.Add(new ListViewItem(new string[] { "Frame rate and data rate" }, imge11));
                    listView1.Items.Add(new ListViewItem(new string[] { "Shutter exposure time (integration time)" }, imge11));
                    listView1.Items.Add(new ListViewItem(new string[] { "ADC reference" }, imge11));

                    break;
                   
                case "General": 
            listView1.Size = new System.Drawing.Size(424, 200);
            listView1.Columns.Add("", 200);
            listView1.Columns.Add("PCO.1200s", 200);
            ListViewGroup gen1 = new ListViewGroup("General");
             listView1.Groups.Add(gen1);
            listView1.Items.Add(new ListViewItem(new string[]{"Camera Name","Camera 1"},gen1));
            listView1.Items.Add(new ListViewItem(new string[] { "Camera Type",  "pco.1200s" }, gen1));
            listView1.Items.Add(new ListViewItem(new string[] { "Trigger mode",  "auto" }, gen1));
            listView1.Items.Add(new ListViewItem(new string[] { "Serial Number",  "1668" }, gen1));
               break;
                case "Image size": 
            listView1.Size = new System.Drawing.Size(424, 125);
            listView1.Columns.Add("", 200);
            listView1.Columns.Add("unit", 100);
            listView1.Columns.Add("PCO.1200s", 200);
            ListViewGroup imge1 = new ListViewGroup("Image");
            listView1.Groups.Add(imge1);
            listView1.Items.Add(new ListViewItem(new string[] { "Image size", "pixels", "1280 x 1024" }, imge1));
                  break;
                case "timing":
                  groupexist = true;
                    listView1.Size = new System.Drawing.Size(424, 200);
                  listView1.Columns.Add("", 200);
                  listView1.Columns.Add("unit", 100);
                  listView1.Columns.Add("PCO.1200s", 200);
                 ListViewGroup tim1 = new ListViewGroup("Timing");
                  listView1.Groups.Add(tim1);
                  listView1.Items.Add(new ListViewItem(new string[] { "Exposure", "us", "20.000000" }, tim1));
                  listView1.Items.Add(new ListViewItem(new string[] { "Delay", "us", "0.000000" }, tim1));
                  listView1.Items.Add(new ListViewItem(new string[] { "Pixel rate", "pixels/s", "67692308" }, tim1));
                  pictureBox1.Location = new System.Drawing.Point(22, 286);
                  pictureBox1.Size = new System.Drawing.Size(424, 183);
                  pictureBox1.Image = CSharpDemo.Properties.Resources.timing;
                  pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                  pictureBox1.Show();
                  break;
                case "Exposure":
                     listView1.Size = new System.Drawing.Size(424, 125);
                  listView1.Columns.Add("", 200);
                  listView1.Columns.Add("unit", 100);
                  listView1.Columns.Add("PCO.1200s", 200);
                 ListViewGroup tim11 = new ListViewGroup("Timing");
                  listView1.Groups.Add(tim11);
                  listView1.Items.Add(new ListViewItem(new string[] { "Exposure", "us", "20.000000" }, tim11));
                  break;
                case "Delay":
                  listView1.Size = new System.Drawing.Size(424, 125);
                  listView1.Columns.Add("", 200);
                  listView1.Columns.Add("unit", 100);
                  listView1.Columns.Add("PCO.1200s", 200);
                 ListViewGroup tim12 = new ListViewGroup("Timing");
                  listView1.Groups.Add(tim12);
                  listView1.Items.Add(new ListViewItem(new string[] { "Delay", "us", "0.000000" }, tim12));
                    break;
                case "pixel rate":
                     listView1.Size = new System.Drawing.Size(424,125);
                  listView1.Columns.Add("", 200);
                  listView1.Columns.Add("unit", 100);
                  listView1.Columns.Add("PCO.1200s", 200);
                 ListViewGroup tim13 = new ListViewGroup("Timing");
                  listView1.Groups.Add(tim13);
                 listView1.Items.Add(new ListViewItem(new string[] { "Pixel rate", "pixels/s", "67692308" }, tim13));
                  break;
                  
                    case "Name":    listView1.Columns.Add("Sensor Name", 100);
                                    listView1.Columns.Add("MT9M413", 100);
                                  pictureBox1.Location = new System.Drawing.Point(22, 146);
                                  pictureBox1.Size = new System.Drawing.Size(424, 379);
                                  pictureBox1.Image = CSharpDemo.Properties.Resources.SensorP;
                                  pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                  pictureBox1.Show();
                                     
                                    break;
                    case "horizontal x vertical(mm square)" :
                    listView1.Columns.Add("unit",200);
                    listView1.Columns.Add("PCO.1200s",220);
                    itm.Text = "mm square";
                    itm.SubItems.Add("15.36 x 12.29");
                    listView1.Items.Add(itm);
                                              break;
                    case "diagonal(mm)": 
                     listView1.Columns.Add("unit", 200);
                    listView1.Columns.Add("PCO.1200s", 220);
                    itm.Text = "mm ";
                    itm.SubItems.Add("19.67");
                    listView1.Items.Add(itm);
                        break;
                    case "Resolution" :
                         listView1.Columns.Add("unit",200);
                    listView1.Columns.Add("PCO.1200s",220);
                    itm.Text = "pixels";
                    itm.SubItems.Add("1280 x 1024");
                    listView1.Items.Add(itm);
                    break;
                    case "Pixel size" :
                         listView1.Columns.Add("unit",200);
                    listView1.Columns.Add("PCO.1200s",220);
                    itm.Text = "um";
                    itm.SubItems.Add("12 x 12");
                    listView1.Items.Add(itm);break;
                    case "Pixel pitch" :
                         listView1.Columns.Add("unit",200);
                    listView1.Columns.Add("PCO.1200s",220);
                    itm.Text = "um";
                    itm.SubItems.Add("12");
                    listView1.Items.Add(itm);break;
                    case "Pixel fill factor" :
                         listView1.Columns.Add("unit",200);
                    listView1.Columns.Add("PCO.1200s",220);
                    itm.Text = "%";
                    itm.SubItems.Add("40");
                    listView1.Items.Add(itm);break;
                    case "supply voltage":
                         listView1.Columns.Add("unit",200);
                    listView1.Columns.Add("PCO.1200s",220);
                    itm.Text = "Volt";
                    itm.SubItems.Add("3.3");
                    listView1.Items.Add(itm);break;
                    case "Conversion gain":
                        listView1.Columns.Add("",250);
                        listView1.Columns.Add("unit",100);
                        listView1.Columns.Add("PCO.1200s",120);
                        itm.Text = "conversion gain per electron";
                        itm.SubItems.Add("uV");
                        itm.SubItems.Add("13");
                        listView1.Items.Add(itm); break;
                    case "Type" :
                    //    listView1.Items.Add({"","dsf);
                    
                    listView1.Columns.Add("",100);
                    listView1.Columns.Add("PCO.1200s",320);
                    itm.Text = "Shutter :";
                    itm.SubItems.Add("TrueSNAP freeze-frame electronic shutter");
                    listView1.Items.Add(itm);
                        break;
                    case "Efficiency": listView1.Columns.Add("", 250);
                        listView1.Columns.Add("PCO.1200s", 170);
                        itm.Text = "Shutter Efficiency :";
                        itm.SubItems.Add(">99.95");
                        listView1.Items.Add(itm); 
                        break;
                    case "Exposure time" :
                        listView1.Columns.Add("", 150);
                    listView1.Columns.Add("units", 100);
                    listView1.Columns.Add("PCO.1200s", 170);
                   
                        itm.Text = "Shutter Exposure time :";
                        itm.SubItems.Add("us");
                        itm.SubItems.Add("2-33");
                        listView1.Items.Add(itm); 
                        break;
                    case "Package":
                          listView1.Columns.Add("", 250);
                   listView1.Columns.Add("PCO.1200s", 170);
                    itm.Text = "Shutter Package :";
                    itm.SubItems.Add("280-pin ceramic PGA");
                        listView1.Items.Add(itm); 
                        break;
                    case "On-chip" :
                        listView1.Columns.Add("programmable controls : On-chip", 400);
                        listView1.Items.Add ("ADC controls");
                        listView1.Items.Add("Output multiplexing");
                        listView1.Items.Add ("ADC calibration");
                     
                        break;
                    case "Off-chip":
                     listView1.Columns.Add("programmable controls : Off-chip", 420);
                     listView1.Items.Add("Window size and location");
                     listView1.Items.Add("Frame rate and data rate");
                     listView1.Items.Add("Shutter exposure time (integration time)");
                     listView1.Items.Add("ADC reference");
                     
                     break;
                    case "Memory": 
                     pictureBox1.Location = new System.Drawing.Point(22, 86);
                     pictureBox1.Size = new System.Drawing.Size(424, 250);
                     pictureBox1.Image = CSharpDemo.Properties.Resources.camram;
                     pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                     pictureBox1.Show();

                     break;
                    case "Recorder mode":
                     listView1.Columns.Add("",250);
                    listView1.Columns.Add("PCO.1200s",150);
                       itm.Text = "Recorder mode";
                        itm.SubItems.Add("Ring Buffer");
                       listView1.Items.Add(itm); 
                     pictureBox1.Location = new System.Drawing.Point(22, 146);
                     pictureBox1.Size = new System.Drawing.Size(424, 184);
                     pictureBox1.Image = CSharpDemo.Properties.Resources.recording;
                     pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                     pictureBox1.Show();
                     break;

                    case "Acquire mode":
                     listView1.Columns.Add("",250);
                    listView1.Columns.Add("PCO.1200s",150);
                       itm.Text = "Acquire mode";
                        itm.SubItems.Add("Auto");
                       listView1.Items.Add(itm); 
                     pictureBox1.Location = new System.Drawing.Point(22, 146);
                     pictureBox1.Size = new System.Drawing.Size(424, 184);
                     pictureBox1.Image = CSharpDemo.Properties.Resources.recording;
                     pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                     pictureBox1.Show();
                    break;

                    case "Timestamp":
                     listView1.Columns.Add("",250);
                    listView1.Columns.Add("PCO.1200s",150);
                       itm.Text = "Recorder mode";
                        itm.SubItems.Add("Ring Buffer");
                       listView1.Items.Add(itm); 
                     pictureBox1.Location = new System.Drawing.Point(22, 146);
                     pictureBox1.Size = new System.Drawing.Size(424, 184);
                     pictureBox1.Image = CSharpDemo.Properties.Resources.recording;
                     pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                     pictureBox1.Show();
                     break;
                    
                    
            }
            if ((e.Node.Nodes.Count == 0)||(groupexist))
                listView1.Visible = true;
            else
                listView1.Visible = false;
            /*listViewItem item = new ListViewItem();
item.text = "Column A";
item.SubItems.Add("");
item.SubItems.Add("Column C");

m_listView.Items.Add(item);

m_listView.Items[0].SubItems[2].Text  = "change text of column C";
m_listView.Items[0].SubItems[1].Text  = "change text of column B";
m_listView.Items[0].SubItems[0].Text  = "change text of column A";*/





            /*listView1.ListItems[i].SubItems[0].ToString() + "\t" + listView1.ListItems[i].SubItems[1].ToString());*/
            /* string[] arr = new string[4];
        ListViewItem itm;
        //add items to ListView
        arr[0] = "product_1";
        arr[1] = "100";
        arr[2] = "10";
        itm = new ListViewItem(arr);
        listView1.Items.Add(itm);*/

            /* //Add column header
            listView1.Columns.Add("ProductName", 100);
            listView1.Columns.Add("Price", 70);
            listView1.Columns.Add("Quantity", 70);

            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm ;

            //Add first item
            arr[0] = "product_1";
            arr[1] = "100";
            arr[2] = "10";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            //Add second item
            arr[0] = "product_2";
            arr[1] = "200";
            arr[2] = "20";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);*/

        
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            label2.Text = e.Item.Text;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
      /*  void iteratetopdown(TreeNode pnode,TreeNodeMouseClickEventArgs etree)
        {
            if ((pnode.Nodes.Count == 0)&&(etree.Node==pnode))
            {
                MessageBox.Show("" + pnode);//give a break point
            }
            else
            {
                foreach (TreeNode subnode in pnode.Nodes)
                {

                  
                    iteratetopdown(subnode, etree);

                }
            }
        }*/
    }
}
