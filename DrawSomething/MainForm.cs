using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

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

        private string drawthing;
        private UserModel userModel;
        private UserModel f_userModel;

        public MainForm(UserModel userModel, UserModel f_userModel, string drawthing, string gameMode)
        {
            InitializeComponent();
            lines = new List<Line>();
            this.userModel = userModel;
            this.f_userModel = f_userModel;
            this.drawthing = drawthing;
            if (gameMode == "guess")
            {
                this.label_friendinfo.Text = "您正在猜，字符长度为 "+drawthing.Length.ToString() + " ，猜对可得10分。";
                this.label_score.Text = userModel.score;
                this.panel1.Visible = false;
                this.panel2.Visible = true;
            } 
            else
            {
                this.label_friendinfo.Text = "您正在画 " + drawthing + " 给 " + f_userModel.username;
                this.label_score.Text = userModel.score;
                this.panel1.Visible = true;
                this.panel2.Visible = false;
            }
        }


        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
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

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //如果首次点击鼠标，打开计时器
            if (this.timer1.Enabled == false)
            {
                this.traceTime = 0;
                this.timer1.Enabled = true;
                Point beginPoint = new Point(e.X, e.Y);
                traceToXML = new TraceToXML(beginPoint, penColor.ToArgb().ToString(), penWidth.ToString());
            }

            if (isTracingNow == false)
            {
                isTracingNow = true;
                this.label_status.Text = "正在记录";
                traceToXML.addNewSection(penColor.ToArgb().ToString(), penWidth.ToString());
            }

            if (e.Button == MouseButtons.Left)
            {
                pointNow = new Point(e.X, e.Y);
                drawingLine = new Line(pointNow);
                drawingLine.penColor = this.penColor;
                drawingLine.penWidth = this.penWidth;
                lines.Add(drawingLine);
            }
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isTracingNow == true)
            {
                isTracingNow = false;
                this.label_status.Text = "结束记录";
            }
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
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

        //设置主form的双缓冲，防止picturebox闪烁
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

            //开始发送到服务器
            bool result = this.sendToServerPost();
            if (result == true)
            {
                MessageBox.Show("恭喜，发送成功！");
            }
            else
            {
                MessageBox.Show("失败，请检查网络连接。");
            }
        }

        //启动用于记录轨迹的定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.mainPictureBox.Refresh();
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
            this.mainPictureBox.Refresh();
        }

        //排行榜
        private void button1_Click(object sender, EventArgs e)
        {
            ToplistForm toplistForm = new ToplistForm();
            toplistForm.ShowDialog();
        }

        //退出程序
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private bool sendToServerPost()
        {
            try
            {
                string xmlbody = File.ReadAllText(System.Environment.CurrentDirectory.ToString() + "\\Trace.xml");

                Encoding encode = Encoding.GetEncoding("utf-8");
                string postData = "sender_uid=" + userModel.uid + "&receiver_uid=" + f_userModel.uid + "&drawthing=" + drawthing + "&xmlbody=" + xmlbody;
                string strURL = @"http://172.28.11.123/~zhaoyulee/drawsomething/index.php/drawinfo/addnewdraw";

                byte[] data = encode.GetBytes(postData);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(strURL);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded"; 
                myRequest.ContentLength = data.Length;
                using (Stream reqStream = myRequest.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                using (WebResponse wr = myRequest.GetResponse())
                {
                    Stream stream = wr.GetResponseStream();
                    byte[] rsByte = new Byte[wr.ContentLength];
                    stream.Read(rsByte, 0, (int)wr.ContentLength);
                    string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                    if (result == "true")
                    {
                        return true;
                    } 
                    else
                    {
                        return false;
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：失败。"+ex.Message);
                return false;
            }

        }

        //开始绘制
        private void button9_Click(object sender, EventArgs e)
        {
            traceToDraw = new TraceToDraw(this.timer2, this.mainPictureBox, userModel.uid);
            traceToDraw.start();
        }

        //猜测答案按钮
        private void button8_Click(object sender, EventArgs e)
        {
            string myAnswer = this.textBox1.Text;
            if (myAnswer == drawthing)
            {
                MessageBox.Show("猜对了！");
            } 
            else
            {
                MessageBox.Show("猜错了，请重试。");
                this.textBox1.Focus();
            }
        }

    }
}
