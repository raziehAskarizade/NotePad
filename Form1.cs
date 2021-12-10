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
    public partial class Form1 : Form
    {
        
        string path;
        Boolean saveFlag;
        MyUndo Undo = new MyUndo();
        //EditOperation editOperation = new EditOperation();
        //Timer timer;
        public Form1()
        {
            InitializeComponent();
            //timer = new Timer();
            //timer.Tick += MyTimer_Ticked;
            //timer.Interval = 500;
        }
        //private void MyTimer_Ticked(object sender, EventArgs e)
        //{
        //    timer.Stop();
        //    editOperation.AddItem(txtNotepad.Text);
        //}
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetBackColor(object sender, EventArgs e)
        {
            txtNotepad.BackColor = Color.FromName(((ToolStripMenuItem)sender).Text);
            foreach (ToolStripMenuItem x in backColorToolStripMenuItem.DropDownItems)
                if (x.Text == ((ToolStripMenuItem)sender).Text)
                    x.Checked = true;
                else
                    x.Checked = false;
        }
        private void SetForeColor(object sender, EventArgs e)
        {
            txtNotepad.ForeColor = Color.FromName(((ToolStripMenuItem)sender).Text);
            foreach (ToolStripMenuItem x in foreColorToolStripMenuItem.DropDownItems)
                if (x.Text == ((ToolStripMenuItem)sender).Text)
                    x.Checked = true;
                else
                    x.Checked = false;
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = txtNotepad.Font;
            fontDialog1.ShowDialog();
            txtNotepad.Font = fontDialog1.Font;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] writefile = new string[6];
            writefile[0] = txtNotepad.BackColor.Name;
            writefile[1] = txtNotepad.Font.Name;
            writefile[2] = txtNotepad.Font.Size.ToString();
            writefile[3] = this.Height.ToString();
            writefile[4] = this.Width.ToString();
            writefile[5] = txtNotepad.ForeColor.Name;
            System.IO.File.WriteAllLines(@"c", writefile);
            //System.IO.File.WriteAllText(@"c", txtNotepad.BackColor.Name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] readfile = new string[6];
                if (System.IO.File.Exists(@"c") == true)
                {
                    readfile = System.IO.File.ReadAllLines(@"c");
                    //string x = System.IO.File.ReadAllText(@"D:\test.txt");
                    ToolStripMenuItem temp = new ToolStripMenuItem();
                    ToolStripMenuItem tempForeColor = new ToolStripMenuItem();
                    temp.Text = readfile[0];
                    //temp.Text = x;
                    SetBackColor(temp, null);
                    txtNotepad.Font = new Font(readfile[1], int.Parse(readfile[2]));
                    //   // txtNotepad.Font = new Font(System.IO.File.ReadAllText(@"c"), int.Parse(System.IO.File.ReadAllText(@"c")));
                    this.Height = int.Parse(readfile[3]);
                    this.Width = int.Parse(readfile[4]);
                    tempForeColor.Text = readfile[5];
                    SetForeColor(tempForeColor, null);
                }
                saveFlag = true;
            }
            catch
            {
                return;
            }
        }
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.WordWrap = wordWrapToolStripMenuItem.Checked;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                DialogResult x;
                saveFileDialog1.Filter = "Text file|*.txt|Document file|*.doc|All files|*.*";
                x = saveFileDialog1.ShowDialog();
                if (x == DialogResult.Cancel)
                    return;
                path = saveFileDialog1.FileName;
            }
            System.IO.File.WriteAllText(path, txtNotepad.Text );
            saveFlag = true;
            this.Text = path + "-Notepad";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFlag == false)
            {
                DialogResult result = MessageBox.Show("Do you want to save?", "Save Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
            }
            txtNotepad.Text = "";
            this.Text = "Untitled - Notepad";
            saveFlag = true;
            path = null;
        }
        private void txtNotepad_TextChanged(object sender, EventArgs e)
        {

            saveFlag = false;
            setRowColl();
            setEnables();
            //if (editOperation.TxtAreaTextChangeRequare)
            //    timer.Start();
            //else
            //    editOperation.TxtAreaTextChangeRequare = false;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(null, null);
            openFileDialog1.Filter = "Text file|*.txt|Document file|*.doc|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = openFileDialog1.FileName;
            txtNotepad.Text = System.IO.File.ReadAllText(path);
            saveFlag = true;
            this.Text = path;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = null;
            saveToolStripMenuItem_Click(null, null);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            newToolStripMenuItem_Click(null, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtNotepad.SelectedText);
            }
            catch
            {
                return;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.SelectedText = Clipboard.GetText();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(null, null);
            deleteToolStripMenuItem_Click(null, null);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtNotepad.Text = txtNotepad.Text.Replace(txtNotepad.SelectedText, null);
            }
            catch
            {
                return;
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.SelectAll();
        }
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFind find = new formFind(this);
            find.Show(this);
        }
        public Boolean Find(string f)
        {
            FormReplace replace = new FormReplace();
            int _index = 0;
            try
            {
                _index = txtNotepad.Text.IndexOf(f, 0, StringComparison.OrdinalIgnoreCase);
                if (_index == -1)
                    _index = txtNotepad.Text.LastIndexOf(f, txtNotepad.Text.Length, StringComparison.OrdinalIgnoreCase);
                //    if (replace.rdoDown.Checked == true)
                //    {
                //        if (replace.chbMatchCase.Checked == true)
                //            _index = txtNotepad.Text.IndexOf(f, txtNotepad.SelectionStart , StringComparison.Ordinal);
                //        else
                //            _index = txtNotepad.Text.IndexOf(f, txtNotepad.SelectionStart , StringComparison.OrdinalIgnoreCase);
                //    }
                //    if (replace.rdoUp.Checked == true)
                //    {
                //        if (replace.chbMatchCase.Checked == true)
                //            _index = txtNotepad.Text.LastIndexOf(f, txtNotepad.SelectionStart - 1, StringComparison.Ordinal);
                //        else
                //            _index = txtNotepad.Text.LastIndexOf(f, txtNotepad.SelectionStart - 1, StringComparison.OrdinalIgnoreCase);
                //    }
                if (_index == -1)
                {
                    MessageBox.Show($"Cannot find {f}!");
                    return false;
                }
                else
                {
                    //txtNotepad.SelectionStart = _index;
                    //txtNotepad.SelectionLength = f.Length;
                    ////txtNotepad.Select(txtNotepad.Text.IndexOf(f),f.Length);
                    //txtNotepad.Focus();
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Text is ended!");
                return false;
            }
        }
        public void setEnables()
        {
            copyToolStripMenuItem.Enabled = txtNotepad.SelectedText.Length > 0;
            cutToolStripMenuItem.Enabled = txtNotepad.SelectionLength > 0;
            deleteToolStripMenuItem.Enabled = txtNotepad.SelectionLength > 0;
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            undoToolStripMenuItem.Enabled = txtNotepad.TextLength > 0;
            redoToolStripMenuItem.Enabled = undoToolStripMenuItem.Enabled;
            gotoToolStripMenuItem1.Enabled = txtNotepad.TextLength > 0;
            findToolStripMenuItem.Enabled = txtNotepad.TextLength > 0;
            replaceToolStripMenuItem.Enabled = txtNotepad.TextLength > 0;
            selectAllToolStripMenuItem.Enabled = txtNotepad.TextLength > 0;
            findNextToolStripMenuItem.Enabled = txtNotepad.SelectionLength > 0;
            saveToolStripMenuItem.Enabled = !saveFlag;

        }
        /// <summary>
        /// this explanations come if you call them!
        /// </summary>
        /// <param name="f">it's just takes an string</param>
        /// <param name="comparison">this is the text you want start searching from this space</param>
        /// <param name="check">right to left or vise versa?</param>
        /// <returns></returns>
        public Boolean FindNext(string f, StringComparison comparison, Boolean check)
        {
            try
            {
                int _index = 0;
                if (check == true)
                    _index = txtNotepad.Text.IndexOf(f, txtNotepad.SelectionStart + 1, comparison);
                else
                    _index = txtNotepad.Text.LastIndexOf(f, txtNotepad.SelectionStart - 1, comparison);

                if (_index == -1)
                {
                    MessageBox.Show($"Cannot find {f}!");
                    return false;
                }
                else
                {
                    txtNotepad.SelectionStart = _index;
                    txtNotepad.SelectionLength = f.Length;
                    //txtNotepad.Select(txtNotepad.Text.IndexOf(f),f.Length);
                    txtNotepad.Focus();
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Text is ended!");
                return false;
            }
        }
        public Boolean FindNextReplaceFunc(string f, StringComparison comparison, Boolean check)
        {
            try
            {
                int _index = 0;
                if (check == true)
                    _index = txtNotepad.Text.IndexOf(f, txtNotepad.SelectionStart, comparison);
                else
                    _index = txtNotepad.Text.LastIndexOf(f, txtNotepad.SelectionStart, comparison);

                if (_index == -1)
                {
                    return false;
                }
                else
                {
                    txtNotepad.SelectionStart = _index;
                    txtNotepad.SelectionLength = f.Length;
                    //txtNotepad.Select(txtNotepad.Text.IndexOf(f),f.Length);
                    txtNotepad.Focus();
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Text is ended!");
                return false;
            }
        }
        public void setRowColl()
        {
            int row = txtNotepad.GetLineFromCharIndex(txtNotepad.SelectionStart) + 1;
            int col = txtNotepad.SelectionStart - txtNotepad.GetFirstCharIndexOfCurrentLine() + 1;
            lblRowCol.Text = $"Ln {row}, Col {col} ";
        }
        private void findnextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindNext(txtNotepad.SelectedText, StringComparison.OrdinalIgnoreCase, true);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.Text = Undo.Undo();
            //txtNotepad.Text = editOperation.UndoClicked();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNotepad.Text = Undo.Redo();
            //txtNotepad.Text = editOperation.RedoClicked();

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Undo.setText(txtNotepad.Text);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReplace replace = new FormReplace(this);
            replace.Show(this);
        }
        public void ReplaceFunction(string text)
        {
            if (txtNotepad.SelectionLength > 0)
                txtNotepad.SelectedText = text;
        }
        public void ReplaceAllFunction(string OldText, string NewText, StringComparison caseOrnot, Boolean leftOrright)
        {
            if (Find(OldText))
                while (FindNextReplaceFunc(OldText, caseOrnot, leftOrright))
                    ReplaceFunction(NewText);
        }

        private void gotoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formGoTo goTo = new formGoTo(this);
            goTo.ShowDialog();
        }
        public int getLine()
        {
            return txtNotepad.Lines.Count();
        }
        public void showLine(int lineNum)
        {
            txtNotepad.SelectionStart = txtNotepad.GetFirstCharIndexFromLine(lineNum);
        }

        private void txtNotepad_KeyUp(object sender, KeyEventArgs e)
        {
            setRowColl();
        }

        private void txtNotepad_Click(object sender, EventArgs e)
        {
            setRowColl();
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            setEnables();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            DialogResult temp = printDialog1.ShowDialog();
            if (temp == DialogResult.OK)
                printDocument1.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SolidBrush shadowBrush = new SolidBrush(txtNotepad.ForeColor);
            e.Graphics.DrawString(txtNotepad.Text, txtNotepad.Font, shadowBrush, 0, 0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {

        }
    }
    public class MyUndo
    {
        string[] temp = new string[100];
        int currentPosition;
        int index;
        public MyUndo()
        {
            index = 0;
            currentPosition = 0;
        }
        public void setText(string str)
        {
            //temp = new string[100];
            temp[index] = str;
            currentPosition = index;
            ++index;
        }
        public string Undo()
        {
            if (currentPosition > 0)
                return temp[--currentPosition];
            return null;
        }
        public string Redo()
        {
            if (currentPosition < index)
                return temp[++currentPosition];
            return null;
        }
    }
}
