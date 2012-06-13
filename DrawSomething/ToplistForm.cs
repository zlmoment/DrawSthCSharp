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
    public partial class ToplistForm : Form
    {
        public ToplistForm()
        {
            InitializeComponent();
        }

        //加载排行榜
        private void ToplistForm_Load(object sender, EventArgs e)
        {
            string alldata = Util.getTopList();
            string[] alldataArray=alldata.Split(',');
            string[] finalDataArray = new string[10];
            for (int i = 0; i < 10; i++ )
            {
                finalDataArray[i] = "无";
            }
            for (int i = 0; i < alldataArray.Length; i++)
            {
                finalDataArray[i] = alldataArray[i].ToString();
            }

            this.label_top1.Text = finalDataArray[0].ToString();
            this.label_top1s.Text = finalDataArray[1].ToString();
            this.label_top2.Text = finalDataArray[2].ToString();
            this.label_top2s.Text = finalDataArray[3].ToString();
            this.label_top3.Text = finalDataArray[4].ToString();
            this.label_top3s.Text = finalDataArray[5].ToString();
            this.label_top4.Text = finalDataArray[6].ToString();
            this.label_top4s.Text = finalDataArray[7].ToString();
            this.label_top5.Text = finalDataArray[8].ToString();
            this.label_top5s.Text = finalDataArray[9].ToString();
        }
    }
}
