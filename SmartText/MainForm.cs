using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartText
{
    public partial class ParentForm : Form
    {
        int count;
        public ParentForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            count++;
            ChildForm object89 = new ChildForm();
            object89.MdiParent = this;
            object89.Show();
            object89.Text = "New Document" + count;
        }



        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            Form ChildForm;
            RichTextBox editorTextBox;
            openFileDialog2.FileName = " ";
            answer = openFileDialog2.ShowDialog();
            if (answer == DialogResult.OK)
            {
                newToolStripMenuItem.PerformClick();
                ChildForm = this.ActiveMdiChild;
                ChildForm.Text = openFileDialog2.FileName;
                editorTextBox = (RichTextBox)ChildForm.ActiveControl;
                editorTextBox.LoadFile(openFileDialog2.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            Form ChildForm = this.ActiveMdiChild;
            RichTextBox editorTextBox;
            if (ChildForm != null)
            {
                saveFileDialog1.FileName = ChildForm.Text;
                answer = saveFileDialog1.ShowDialog();
                if (answer == DialogResult.OK)
                {
                    ChildForm.Text = saveFileDialog1.FileName;
                    editorTextBox = (RichTextBox)ChildForm.ActiveControl;
                    editorTextBox.SaveFile(saveFileDialog1.FileName);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild;
            activechild = this.ActiveMdiChild;
            if (activechild != null)
            {
                activechild.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("Do you want to exit ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            Form activechild = this.ActiveMdiChild;
            if (activechild != null)
            {
                fontDialog1.Font = activechild.ActiveControl.Font;
                answer = fontDialog1.ShowDialog();
                if (answer == DialogResult.OK)
                {
                    activechild.ActiveControl.Font = fontDialog1.Font;
                }
            }

        }

       

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            Form activechild = this.ActiveMdiChild;
            if (activechild != null)
            {
                colorDialog1.Color = activechild.ActiveControl.ForeColor;
                answer = colorDialog1.ShowDialog();
                if (answer == DialogResult.OK)
                {
                    activechild.ActiveControl.ForeColor = colorDialog1.Color;
                }
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild;
            activechild = this.ActiveMdiChild;

            if (activechild != null)
            {
                activechild.ActiveControl.ForeColor = Color.Black;
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild;
            activechild = this.ActiveMdiChild;

            if (activechild != null)
            {
                activechild.ActiveControl.ForeColor = Color.Green;
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activechild;
            activechild = this.ActiveMdiChild;

            if (activechild != null)
            {
                activechild.ActiveControl.ForeColor = Color.Blue;
            }
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
