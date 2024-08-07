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
    public partial class justfortest : Form
    {
        public justfortest()
        {
            InitializeComponent();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void justfortest_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
