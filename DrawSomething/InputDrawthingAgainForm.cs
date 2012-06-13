using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawSomething
{
    public partial class InputDrawthingAgainForm : Form
    {
        private MainForm mainForm;
        public InputDrawthingAgainForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string drawthing = this.textBox1.Text;
            if (drawthing == "")
            {
                MessageBox.Show("不能为空...");
            } 
            else
            {
                mainForm.drawthing = drawthing;
                this.Dispose();
            }
        }
    }
}
