using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace DrawSomething
{
    public class Util
    {
        public Util()
        {

        }

        public static string getScoreByUid(string uid)
        {
            string url = @"http://172.28.11.123/~zhaoyulee/drawsomething/index.php/Util/getscorebyuid?uid=" + uid;
            HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
            Stream stream = webreponse.GetResponseStream();
            byte[] rsByte = new Byte[webreponse.ContentLength];
            try
            {
                stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                return result;
            }
            catch (Exception exp)
            {
                return "0";
            }
        }

        public static string getmydrawnum(string uid)
        {
            string url = @"http://172.28.11.123/~zhaoyulee/drawsomething/index.php/User/getmydrawnum?uid=" + uid;
            HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
            Stream stream = webreponse.GetResponseStream();
            byte[] rsByte = new Byte[webreponse.ContentLength];
            try
            {
                stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                return result;
            }
            catch (Exception exp)
            {
                return "0";
            }
        }

        public static string getdrawthing(string uid)
        {
            string url = @"http://172.28.11.123/~zhaoyulee/drawsomething/index.php/User/getmydrawthing?uid=" + uid;
            HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
            Stream stream = webreponse.GetResponseStream();
            byte[] rsByte = new Byte[webreponse.ContentLength];
            try
            {
                stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                return result;
            }
            catch (Exception exp)
            {
                return "0";
            }
        }

        public static string getdrawxml(string uid)
        {
            string url = @"http://172.28.11.123/~zhaoyulee/drawsomething/index.php/User/getmydrawxml?uid=" + uid;
            HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
            Stream stream = webreponse.GetResponseStream();
            byte[] rsByte = new Byte[webreponse.ContentLength];
            try
            {
                stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                string result = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
                return result;
            }
            catch (Exception exp)
            {
                return "0";
            }
        }

        //猜对后设置为已猜
        public static void setQuenuDone()
        {

        }

        //更新自己的分数
        public static void updatemyscore(string uid, string score)
        {

        }
    }
}
