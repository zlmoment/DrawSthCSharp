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

        private bool isTracingNow = false;
        private Point pointNow;
        private int traceTime = 0;
        private TraceToXML traceToXML;

        private TraceToDraw traceToDraw;
        
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
                pointNow = new Point(e.X, e.Y);
                drawingLine.Add(pointNow);
                Invalidate();
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //如果首次点击鼠标，打开计时器
            if (this.timer1.Enabled == false)
            {
                this.timer1.Enabled = true;
                Point beginPoint = new Point(e.X, e.Y);
                traceToXML = new TraceToXML(beginPoint, penColor.ToArgb().ToString(), penWidth.ToString());
            }

            if (isTracingNow == false)
            {
                isTracingNow = true;
                this.label_status.Text = "正在记录";
                traceToXML.addNewSection(penColor.ToArgb().ToString(),penWidth.ToString());
            }

            if (e.Button == MouseButtons.Left)
            {
                Point pointNow = new Point(e.X, e.Y);
                drawingLine = new Line(pointNow);
                drawingLine.penColor = this.penColor;
                drawingLine.penWidth = this.penWidth;
                lines.Add(drawingLine);
            }
        }

        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isTracingNow == true)
            {
                isTracingNow = false;
                this.label_status.Text = "结束记录";
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

        //绘图完成按钮
        private void button3_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            traceToXML.finish();
            this.traceTime = 0;
            this.drawingLine = null;
            this.lines = null;
            MessageBox.Show("finish");
            //MessageBox.Show(System.Environment.CurrentDirectory.ToString());
        }

        //启动用于记录轨迹的定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.mainPanel.Refresh();
            traceTime += timer1.Interval;
            if (isTracingNow == true)
            {
                traceToXML.add(pointNow, traceTime.ToString());
            }
        }

        //用于还原绘图过程的定时器
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            traceToDraw.drawit(traceTime.ToString());
            traceTime += timer2.Interval;
            this.drawingLine = traceToDraw.drawingLine;
            this.lines = traceToDraw.lines;
            this.mainPanel.Refresh();
        }

        //排行榜
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //退出程序
        private void button2_Click(object sender, EventArgs e)
        {
            traceToDraw = new TraceToDraw(this.timer2, this.mainPanel);
            traceToDraw.start();
        }

    }
}
