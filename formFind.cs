using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadProject
{
    public partial class formFind : Form
    {
        Form1 temp;
        public formFind(Form1 example)
        {
            temp = example;
            InitializeComponent();
        }
        public formFind()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            temp.FindNext(txtFind.Text, StringComparison.OrdinalIgnoreCase, rdoDown.Checked);
            //if (rdoDown.Checked == false)
            //{
            //    temp.FindNextDown(txtFind.Text);
            //}
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
