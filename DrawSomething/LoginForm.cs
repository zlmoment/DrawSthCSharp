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
    public partial class LoginForm : Form
    {
        private string uid = "0";
        private string score = "0";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            if (checkLogin(username,password))
            {
                UserModel userModel = new UserModel();
                userModel.username = username;
                userModel.uid = uid;
                userModel.score = score;
                if (int.Parse(Util.getmydrawnum(uid)) > 0)
                {
                    if (MessageBox.Show("有朋友给您发送了未猜的图画，是否要开始猜图？(一次只能猜测一幅画)", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string drawthing = Util.getdrawthing(uid);
                        MainForm mainForm = new MainForm(userModel, userModel, drawthing, "guess");
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        FindPartnerForm findPartnerForm = new FindPartnerForm(userModel);
                        findPartnerForm.Show();
                        this.Hide();
                    }
                } 
                else
                {
                    FindPartnerForm findPartnerForm = new FindPartnerForm(userModel);
                    findPartnerForm.Show();
                    this.Hide();
                }
                
            } 
            else
            {
                MessageBox.Show("登陆失败，请再填写用户名和密码并重新登陆。");
            }
        }

        private bool checkLogin(string username, string password)
        {
            if (username == "")
            {
                return false;
            }
            else
            {
                string url = @"http://172.28.11.123/~zhaoyulee/drawsomething/index.php/User/login?username="+username+@"&password="+password;
                HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
                Stream stream = webreponse.GetResponseStream();
                byte[] rsByte = new Byte[webreponse.ContentLength];
                try
                {
                    stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                    string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                    if (result != "0")
                    {
                        uid = result;
                        score = Util.getScoreByUid(uid);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception exp)
                {
                    return false;
                }
            }
        }

        //创建新用户
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();
        }
    }
}
