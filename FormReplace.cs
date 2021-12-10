using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NotePadProject
{
    public partial class FormReplace : NotePadProject.formFind
    {
        Form1 Form;
        public FormReplace()
        {
            InitializeComponent();
        }
        public FormReplace(Form1 form) : base(form)
        {
            Form = form;
            InitializeComponent();
        }
        private void FormReplace_Load(object sender, EventArgs e)
        {

        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Form.ReplaceFunction(txtReplace.Text);
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (chbMatchCase.Checked == true)
                Form.ReplaceAllFunction(txtFind.Text, txtReplace.Text, StringComparison.Ordinal, rdoDown.Checked);
            else
                Form.ReplaceAllFunction(txtFind.Text, txtReplace.Text, StringComparison.OrdinalIgnoreCase, rdoDown.Checked);
        }
    }
}
