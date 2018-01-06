using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

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
                WebClient wc = new WebClient();
                string html = wc.DownloadString(link);

                Regex x = new Regex("<title>(.*)</title>");
                MatchCollection m = x.Matches(html);

                if (m.Count > 0)
                {
                    return m[0].Value.Replace("<title>", "").Replace("</title>", "");
                }
                else
                    return "";
            }
            catch (Exception)
            {
                //MessageBox.Show("Could not connect. Error:" + ex.Message);
                return "";
            }
        }
    }
}
