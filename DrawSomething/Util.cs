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
            string url = @"http://hackecho.com/drawsomething/index.php/Util/getscorebyuid?uid=" + uid;
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
            string url = @"http://hackecho.com/drawsomething/index.php/User/getmydrawnum?uid=" + uid;
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
            string url = @"http://hackecho.com/drawsomething/index.php/User/getmydrawthing?uid=" + uid;
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

        public static string getsenderusername(string uid)
        {
            string url = @"http://hackecho.com/drawsomething/index.php/User/getsenderusername?uid=" + uid;
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
            string url = @"http://hackecho.com/drawsomething/index.php/User/getmydrawxml?uid=" + uid;
            System.Net.WebRequest wReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse wResp = wReq.GetResponse();
            System.IO.Stream respStream = wResp.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        //猜对后设置为已猜(默认设置的是表里第一条数据，因此不用where检索qid)
        public static bool setQuenuDone(string uid)
        {
            string url = @"http://hackecho.com/drawsomething/index.php/Drawinfo/setquenudone?uid=" + uid;
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

        //更新自己的分数
        public static bool updatemyscore(string uid, string score)
        {
            string url = @"http://hackecho.com/drawsomething/index.php/user/updatemyscore?uid=" + uid + @"&score=" + score;
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

        //得到排行榜
        public static string getTopList()
        {
            string url = @"http://hackecho.com/drawsomething/index.php/Util/gettoplist";
            System.Net.WebRequest wReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse wResp = wReq.GetResponse();
            System.IO.Stream respStream = wResp.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
