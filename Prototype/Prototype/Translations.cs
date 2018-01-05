using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Prototype
{
    class Translations
    {

        public static string Wikipedia_Source(string text)
        {

            WebClient client = new WebClient();
            string pg = "";
            string F_Line = "";
            //string target = "";
            //text = text.Replace(" ", "_");
            //取得系统Document文件夹的路径
            string Dir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Dir = Dir + @"\ELNA\temp";
            Directory.CreateDirectory(Dir);

            using (Stream stream = client.OpenRead("http://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=" + text))
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer ser = new JsonSerializer();
                Result result = ser.Deserialize<Result>(new JsonTextReader(reader));

                foreach (Page page in result.query.pages.Values)
                    pg = page.extract;
            }
            using (StreamWriter sw = File.CreateText(Dir + "Temp.txt"))
            {
                sw.Write(pg);
            }
            string line = File.ReadAllText(Dir + "Temp.txt");
            try
            {
                line = line.Substring(0, line.IndexOf("="));
                Console.WriteLine("line"+line);
                string outputText = Regex.Replace(line, @"[^\s()]+(?=[^()]*\))", "");
                Console.WriteLine("outputText"+outputText);
                while (outputText.IndexOf("(") > -1 || outputText.IndexOf(")") > -1)
                {
                    outputText = Regex.Replace(outputText, @"\(\s+\)", "");
                }
                Console.WriteLine("outputText2" + outputText);
                F_Line = outputText.Substring(0, outputText.IndexOf(". ")) + ".";
            }
            catch (Exception)
            {
                try
                {
                    Console.WriteLine(line + "test");
                    line = line.Substring(0, line.IndexOf("may also refer to", StringComparison.CurrentCultureIgnoreCase));
                    F_Line = line + " Please View full content using integrated WebBrowser";
                }
                catch (Exception)
                {
                    if (line.IndexOf(":\n") > -1)
                    {
                        F_Line = line + " (Please View full content using integrated WebBrowser)";
                    }
                    else
                    {
                        F_Line = line;
                    }
                }
            }
            File.Delete(Dir + "Temp.txt");
            return F_Line;


        }
        public static string Google_Translate(string text, string from, string to)
        {
            string page = null;
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                wc.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
                wc.Encoding = Encoding.UTF8;

                string url = string.Format(@"http://translate.google.com.tr/m?hl=en&sl={0}&tl={1}&ie=UTF-8&prev=_m&q={2}",
                                            from, to, Uri.EscapeUriString(text));
                Console.WriteLine(url);
                page = wc.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            page = page.Remove(0, page.IndexOf("<div dir=\"ltr\" class=\"t0\">")).Replace("<div dir=\"ltr\" class=\"t0\">", "");
            int last = page.IndexOf("</div>");
            page = page.Remove(last, page.Length - last);

            return page;
        }
        public static string Youdao_Dictionary(string text)
        {
            string page = null;
            text = Regex.Replace(text, @"\s+", "%20");
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                wc.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
                wc.Encoding = Encoding.UTF8;

                string url = string.Format(@"http://fanyi.youdao.com/openapi.do?keyfrom=sasfasdfasf&key=1177596287&type=data&doctype=json&version=1.1&q={0}",
                                            text, Uri.EscapeUriString(text));
                Console.WriteLine(url);
                page = wc.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            var jo = JObject.Parse(page);
            try
            {
                //var id = jo["basic"]["explains"].ToString();
                String sb = "";
                foreach (JToken result in jo["basic"]["explains"])
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    sb += result + "\r\n";
                }
                return sb;
            }
            catch (Exception)
            {
                //var id = jo["translation"].ToString();
                //return id;
                String sb = "";
                foreach (JToken result in jo["translation"])
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    sb += result + "\r\n";
                }
                return sb;
            }
            //var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(page);
            //return JSONObj["basic"];
        }
        public class Result
        {
            public Query query { get; set; }
        }

        public class Query
        {
            public Dictionary<string, Page> pages { get; set; }
        }

        public class Page
        {
            public string extract { get; set; }
        }
    }

}
