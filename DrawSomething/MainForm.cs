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
    public partial class MainForm : Form
    {
        private Line drawingLine;
        private List<Line> lines;

        private Color penColor = Color.Black;
        private float penWidth = 1;
        
        public MainForm()
        {
            InitializeComponent();
            lines = new List<Line>();
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            string x_point = e.X.ToString();
            string y_point = e.Y.ToString();

            if (e.Button == MouseButtons.Left)
            {
                Point pointNow = new Point(e.X, e.Y);
                drawingLine.Add(pointNow);
                Invalidate();
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point pointNow = new Point(e.X, e.Y);
                drawingLine = new Line(pointNow);
                drawingLine.penColor = this.penColor;
                drawingLine.penWidth = this.penWidth;
                lines.Add(drawingLine);
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var line in lines)
            {
                line.Draw(e.Graphics);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            this.mainPanel.Refresh();
        }

        //设置颜色
        private void button7_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.penColor = this.colorDialog1.Color;
            this.button7.BackColor = this.penColor;
        }

        //设置粗细
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.penWidth = int.Parse(this.comboBox1.SelectedItem.ToString());
        }

        //设置主form的双缓冲，防止panel闪烁，但效果不明显
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
    }
}
