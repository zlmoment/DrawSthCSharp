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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        //创建按钮
        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("请填写完整。");
            } 
            else
            {
                string url = @"http://59.65.171.223/~zhaoyulee/drawsomething/index.php/User/addnew?username=" + username + @"&password=" + password;
                HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
                Stream stream = webreponse.GetResponseStream();
                byte[] rsByte = new Byte[webreponse.ContentLength];
                try
                {
                    stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                    string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                    if (result == "true")
                    {
                        MessageBox.Show("注册成功。");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("注册失败。"); 
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("注册失败。"); 
                }
            }
        }

    }
}
