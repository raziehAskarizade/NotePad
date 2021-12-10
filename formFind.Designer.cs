
namespace NotePadProject
{
    partial class formFind
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.chbMatchCase = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoDown = new System.Windows.Forms.RadioButton();
            this.rdoUp = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find What :";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(86, 19);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(151, 20);
            this.txtFind.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(263, 17);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find Next";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Location = new System.Drawing.Point(263, 55);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // chbMatchCase
            // 
            this.chbMatchCase.AutoSize = true;
            this.chbMatchCase.Location = new System.Drawing.Point(12, 114);
            this.chbMatchCase.Name = "chbMatchCase";
            this.chbMatchCase.Size = new System.Drawing.Size(82, 17);
            this.chbMatchCase.TabIndex = 4;
            this.chbMatchCase.Text = "Match case";
            this.chbMatchCase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoDown);
            this.groupBox1.Controls.Add(this.rdoUp);
            this.groupBox1.Location = new System.Drawing.Point(100, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 60);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // rdoDown
            // 
            this.rdoDown.AutoSize = true;
            this.rdoDown.Checked = true;
            this.rdoDown.Location = new System.Drawing.Point(73, 37);
            this.rdoDown.Name = "rdoDown";
            this.rdoDown.Size = new System.Drawing.Size(53, 17);
            this.rdoDown.TabIndex = 1;
            this.rdoDown.TabStop = true;
            this.rdoDown.Text = "Down";
            this.rdoDown.UseVisualStyleBackColor = true;
            // 
            // rdoUp
            // 
            this.rdoUp.AutoSize = true;
            this.rdoUp.Location = new System.Drawing.Point(7, 37);
            this.rdoUp.Name = "rdoUp";
            this.rdoUp.Size = new System.Drawing.Size(39, 17);
            this.rdoUp.TabIndex = 0;
            this.rdoUp.Text = "Up";
            this.rdoUp.UseVisualStyleBackColor = true;
            // 
            // formFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 152);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chbMatchCase);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formFind";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtFind;
        protected System.Windows.Forms.Button btnFind;
        protected System.Windows.Forms.Button btnCancle;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected internal System.Windows.Forms.CheckBox chbMatchCase;
        protected internal System.Windows.Forms.RadioButton rdoDown;
        protected internal System.Windows.Forms.RadioButton rdoUp;
    }
}