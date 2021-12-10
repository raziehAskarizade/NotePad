using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NotePadProject
{
    public partial class formGoTo : Form
    {
        Form1 form1;
        public formGoTo(Form1 form)
        {
            form1 = form;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formGoTo_Load(object sender, EventArgs e)
        {
            txtLineNumber.Text = form1.getLine().ToString();
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtLineNumber.Text) > form1.getLine() - 1)
            {
                MessageBox.Show("The line number is beyond the total number of lines!");
                txtLineNumber.SelectAll();
                txtLineNumber.Focus();
            }
            else
            {
                form1.showLine(int.Parse(txtLineNumber.Text) - 1);
                this.Close();
            }

        }
        private void txtLineNumber_TextChanged(object sender, EventArgs e)
        {
            //NumericUpDown.CheckForIllegalCrossThreadCalls{
                
            //}
            //if(txtLineNumber.Text==NumericUpDown)

        }

        private void txtLineNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                pictureBox1.Visible = true;
            }
            else
                pictureBox1.Visible = false;
        }
    }
}
