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
    }
}
