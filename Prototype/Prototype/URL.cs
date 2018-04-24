using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace Prototype
{
    class URL
    {
        public static string GetRedirectedURL(string url)
        {
            
                HttpWebRequest WebR = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse WebP = (HttpWebResponse)WebR.GetResponse();
                WebP.Close();
                if (WebR.RequestUri != WebR.Address)
                {
                    return WebR.Address.ToString();
                }
                else
                {
                    return WebR.RequestUri.ToString();
                }
            
            
            
        }
        public static string GetPageTitle(string link)
        {
            try
            {
                WebRequest request = WebRequest.Create(link);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader sr = new StreamReader(data);
                string html = sr.ReadToEnd();
                string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
                System.Text.RegularExpressions.Regex ex = new System.Text.RegularExpressions.Regex(regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                string Title = ex.Match(html).Value.Trim();
                return Title;
            }
            catch (Exception)
            {
                //MessageBox.Show("Could not connect. Error:" + ex.Message);
                return "";
            }
        }
        public static string getRandomProxy()
        {
            try
            {
                string page = null;
                try
                {
                    WebClient wc = new WebClient();
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                    wc.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
                    wc.Encoding = Encoding.UTF8;

                    string url = string.Format(@"https://webcache.googleusercontent.com/search?q=cache:{0}",
                                                "https://www.us-proxy.org");
                    Console.WriteLine(url);
                    page = wc.DownloadString(url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }

                page = page.Remove(0, page.IndexOf("Last Checked</th></tr></thead><tbody><tr><td>")).Replace("Last Checked</th></tr></thead><tbody><tr><td>", "");
                int last = page.IndexOf("</td></tr></tbody><tfoot>");
                page = page.Remove(last, page.Length - last);
                page = page.Replace("</td><td>", ":");
                MatchCollection matches = Regex.Matches(page, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}(?=[^\d])\s*:?\s*(\d{2,5})");
                //return matches.Count.ToString();
                Random rnd = new Random();
                int randomInt = rnd.Next(0, 19);
                Console.Write(randomInt);
                for (int i = 0; i < matches.Count; i++)
                {   //loop matches
                    Match match = matches[i];
                    //Console.Write(" "+match.Index+" ");
                    if (i == randomInt)
                    {
                        return match.Value;
                    }
                }
                return "Unexpected Error Occured";
            }
            catch (Exception)
            {
                return "Unexpected Error Occured";
            }
        }
    }
}
