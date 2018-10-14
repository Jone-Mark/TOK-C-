/*
 * 由SharpDevelop创建。
 * 用户： Steven Kong
 * 日期: 2013/2/3
 * 时间: 15:44
 *
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;


namespace TOK_IOT
{
	/// <summary>
	/// Description of http.
	/// </summary>
	public class http
	{
		        
				        public  static string Gethtml(string URL, string cookie)
		        {
 
            HttpWebRequest httpWebRequest;
            WebResponse wrp;
            

            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            CookieContainer co = new CookieContainer();
            Uri uri = new Uri(URL);
            co.SetCookies(uri, cookie);

            httpWebRequest.CookieContainer = co;

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Accept =
                "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            httpWebRequest.UserAgent =
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            httpWebRequest.Method = "get";

            

            wrp = (HttpWebResponse)httpWebRequest.GetResponse();

            string html = new StreamReader(wrp.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            cookie = wrp.Headers.Get("Set-Cookie");
            
            return cookie+"\r\n\r\n\r\n=========================\r\n\r\n\r\n"+html;
            
		        }
		        
		       public static string Logingethtml( string URL, byte[] byteRequest, string cookie,string refer,out string header)
        {
            long contentLength;
            HttpWebRequest httpWebRequest;
            HttpWebResponse webResponse;
            Stream getStream;

            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            CookieContainer co = new CookieContainer();
            Uri uri = new Uri(URL);
            co.SetCookies(uri, cookie);

            httpWebRequest.CookieContainer = co;

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Accept ="text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8;";
            httpWebRequest.Referer = refer;
            httpWebRequest.UserAgent =
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            httpWebRequest.Method = "Post";
            httpWebRequest.ContentLength = byteRequest.Length;
            Stream stream;
            stream = httpWebRequest.GetRequestStream();
            stream.Write(byteRequest, 0, byteRequest.Length);
            stream.Close();
            webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            header = webResponse.Headers.ToString();
            getStream = webResponse.GetResponseStream();
            contentLength = webResponse.ContentLength;
           
           string html = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            getStream.Close();
            return html;
        }
		       public static string post(string URL,string poststring,string cookie,string refer,string head)
		       {
		       	string post =poststring;
		       	byte[] byteRequest = Encoding.Default.GetBytes(post);
		       	string html= Logingethtml(URL,byteRequest,cookie,refer,out head);
		       	return html;
		       }
	}
}
