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
            Dir = Dir + @"\ELNA\temp\";
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
                    outputText = Regex.Replace(outputText, @"\(\s+\)", "");
                outputText = Regex.Replace(outputText, @"\(\s+\)", "");
                outputText = Regex.Replace(outputText, @"\(\)", "");
                Console.WriteLine("outputText2" + outputText);
                F_Line = outputText.Substring(0, outputText.IndexOf(". ")) + ".";
            }
            catch (Exception)
            {
                try
                {
                    Console.WriteLine(line + "test");
                    line = line.Substring(0, line.IndexOf("may also refer to", StringComparison.CurrentCultureIgnoreCase));
                    F_Line = line + " (Please View full content using integrated WebBrowser)";
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
            try
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
            catch (Exception)
            {
                return "";
                
            }
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
        /*
        public static string Auto_Capitalization(string text)
        {

        }*/
       
        public static string Auto_Capitalization(string text)
        {
            string[] Word = text.Split(' ');
            string CapitalizedWord = "";
            for (int i = 0; i < Word.Length; i++)
            {
                string Temp = Word[i];
                if (!Temp.Equals("of") && !Temp.Equals("Of"))
                {
                    string Capitalized = Temp.Substring(0, 1).ToUpper();
                    string Reset = Temp.Substring(1, Temp.Length - 1);
                    Word[i] = Capitalized + Reset;
                }
                else
                {
                    Word[i] = "of";
                }
            }

            foreach (string i in Word)
            {
                CapitalizedWord = CapitalizedWord + i + " ";
            }
            return CapitalizedWord;
        }
       
        
        public static string UrbanDictionary(string User_Term,String url)
        {
            WebClient client = new WebClient();
            if (url != "http://:")
            {
                WebProxy wp = new WebProxy(url);
                client.Proxy = wp;
            }
            try
            {
                string UrbanAPI = @"http://api.urbandictionary.com/v0/define?term=";
                List<double> ThumbUp = new List<double>();
                List<double> ThumbDown = new List<double>();
                List<double> LiketoDislikeRatio = new List<double>();
                using (Stream stream = client.OpenRead(UrbanAPI + User_Term))
                using (StreamReader reader = new StreamReader(stream))
                {
                    JsonSerializer ser = new JsonSerializer();
                    UrbanResult urban = ser.Deserialize<UrbanResult>(new JsonTextReader(reader));
                    foreach (DataRow i in urban.list.Rows)
                    {
                        ThumbUp.Add(double.Parse(i["thumbs_up"].ToString()));
                        ThumbDown.Add(double.Parse(i["thumbs_down"].ToString()));
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        LiketoDislikeRatio.Add(ThumbUp[i] / ThumbDown[i]);
                    }
                    double Greatest_Ratio = LiketoDislikeRatio[0];
                    int Index = 0;
                    /*
                    for (int i = 0; i < LiketoDislikeRatio.Count; i++)
                    {
                        if (LiketoDislikeRatio[i] > Greatest_Ratio)
                        {
                            Greatest_Ratio = LiketoDislikeRatio[i];
                            Index = i;
                        }
                    }*/
                    if (Math.Abs(LiketoDislikeRatio[1] - Greatest_Ratio) < 0.1)
                    {
                        if (LiketoDislikeRatio[1] > Greatest_Ratio)
                        {
                            Index = 1;
                        }

                    }
                    else
                    {
                        if (ThumbUp[0] > ThumbUp[1])
                        {

                        }
                        else
                        {
                            Index = 1;
                        }
                    }

                    return "Definition :" + "\r\n" + urban.list.Rows[Index]["definition"] + Environment.NewLine + " " + Environment.NewLine + "Example: " + "\r\n" + urban.list.Rows[Index]["example"];
                }
            }catch(Exception)
            {
                SpellingCorrector spelling = new SpellingCorrector();
                if (url != "http://:")
                {
                    return "Unexpected Error! Check your proxy server and input.\r\n\r\nDo you mean: " + spelling.Correct(User_Term);
                }
                else if (url == "http://:")
                {
                    return "No proxy being assigned please check your address";
                }
                else
                {
                    return "Unexpected Error!\r\n\r\nDo you mean: " + spelling.Correct(User_Term);
                }
            }
        }
        public static string DefinitionFromOwlDictionary(string Term)
        {
            try
            {
                WebClient OwlDictionary = new WebClient();
                string SearchLink = "https://owlbot.info/api/v2/dictionary/" + Term + "?format=json";
                using (Stream str = OwlDictionary.OpenRead(SearchLink))
                using (StreamReader sr = new StreamReader(str))
                {
                    JsonSerializer js = new JsonSerializer();
                    DataTable Cod = js.Deserialize<DataTable>(new JsonTextReader(sr));
                    return Cod.Rows[0]["definition"].ToString();
                }
            }
            catch
            {
                SpellingCorrector spelling = new SpellingCorrector();
                return "Term does not exist. \r\n\r\nDo you mean: " + spelling.Correct(Term);
            }

        }
        public static WebBrowser w;
        public static Timer timer;
        public static string Bing_Translate(string Term, string to,WebBrowser wb)
        {
            w= wb;
            String pc = ""; int seen=0;
            try
            {
                //wb.Navigate("https://www.bing.com/translator");
                timer = new Timer();
                var links = wb.Document.GetElementsByTagName("option");
                foreach (HtmlElement link in links)
                {
                    if (link.GetAttribute("value").Equals(to))
                    {
                        if (seen != 0)
                        {
                            link.SetAttribute("selected", "selected");
                        }
                        else
                        {
                            seen++;
                        }
                    }
                }
                wb.Document.GetElementById("t_sv").Focus();
                wb.Document.GetElementById("t_sv").SetAttribute("value", Term);
                SendKeys.Send("{ENTER}");
                pc = wb.Document.GetElementById("t_tv").GetAttribute("value");
                try
                {
                    if (wb.Document.GetElementById("t_long").GetAttribute("dir").Equals("ltr"))
                    {
                        pc = "That’s too much text to translate at once. Try entering less";
                    }
                }
                catch (Exception)
                {
                    pc = "Unexpected Error";
                }
                return pc;

            }
            catch
            {
                SpellingCorrector spelling = new SpellingCorrector();
                return "Term does not exist. \r\n\r\nDo you mean: " + spelling.Correct(Term);
            }

        }


        public class UrbanResult
        {
            public IList<string> tags { get; set; }
            public string result_type { get; set; }
            public DataTable list { get; set; }

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
