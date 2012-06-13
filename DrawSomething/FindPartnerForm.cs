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
    public partial class FindPartnerForm : Form
    {
        private UserModel userModel;
        private UserModel f_userModel;

        public FindPartnerForm(UserModel userModel)
        {
            InitializeComponent();
            this.panel1.Visible = false;
            this.userModel = userModel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string friend_username = this.textBox1.Text;
            if (friend_username == "")
            {
                MessageBox.Show("不能为空");
                this.panel1.Visible = false;
            } 
            else
            {
                string url = @"http://59.65.171.223/~zhaoyulee/drawsomething/index.php/User/findpartner?username=" + friend_username;
                HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
                Stream stream = webreponse.GetResponseStream();
                byte[] rsByte = new Byte[webreponse.ContentLength];
                try
                {
                    stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                    string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                    if (result == "0")
                    {
                        this.label_findstatus.Text = "没有此用户，请重新查找。";
                        this.panel1.Visible = false;
                        this.textBox1.Text = "";
                        this.textBox1.Focus();
                    }
                    else
                    {
                        this.label_findstatus.Text = "：）找到啦~~开始游戏吧";
                        f_userModel = new UserModel();
                        f_userModel.username = friend_username;
                        f_userModel.uid = result;
                        f_userModel.score = Util.getScoreByUid(result);
                        this.panel1.Visible = true;
                    }
                }
                catch (Exception exp)
                {
                    
                }
            }
        }

        //开始游戏 
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox_drawthing.Text == "")
            {
                MessageBox.Show("请输入要画的东西。");
                this.textBox_drawthing.Focus();
            } 
            else
            {
                MainForm mainForm = new MainForm(userModel, f_userModel, this.textBox_drawthing.Text,"draw");
                mainForm.Show();
                this.Hide();
            }
            
        }
    }
}
