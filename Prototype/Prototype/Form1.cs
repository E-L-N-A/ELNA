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
    public partial class Form1 : MaterialForm
    {
        string path;
        string WikiDefaultLink = "https://en.wikipedia.org/wiki/";
        string User_Query="";
        public static string Search_Link = "";
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex=0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
            linkLabel1.Text = "";
           
            //richTextBox1.Text = lines;

        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        public static string Wikipedia_Source(string text)
        {

            WebClient client = new WebClient();
            string pg = "";
            string F_Line = "";
            string target = "";
            //text = text.Replace(" ", "_");
            //取得系统Document文件夹的路径
            string Dir =System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
            using (StreamWriter sw = File.CreateText(Dir+"Temp.txt"))
            {
                sw.Write(pg);
            }
            string line = File.ReadAllText(Dir+"Temp.txt");
            try
            {
                line = line.Substring(0, line.IndexOf("="));
                string outputText = Regex.Replace(line, @"[^\s()]+(?=[^()]*\))", "");
                outputText = Regex.Replace(outputText, @"\((.*)\)", "");
                F_Line = outputText.Substring(0, outputText.IndexOf(". "))+".";
            }
            catch (Exception)
            {
                try
                {
                    Console.WriteLine(line+"test");
                    line = line.Substring(0, line.IndexOf("may also refer to", StringComparison.CurrentCultureIgnoreCase));
                    F_Line = line + " Please View full content using integrated WebBrowser";
                }
                catch (Exception)
                {
                    if (line.IndexOf(":\n")>-1)
                    {
                        F_Line = line + " (Please View full content using integrated WebBrowser)";
                    }
                    else
                    {
                        F_Line = line;
                    }
                }
            }
           File.Delete(Dir+"Temp.txt");
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
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------




        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {
                if (metroComboBox3.SelectedIndex == 0)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "en");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 1)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "zh");
                    string definition = Youdao_Dictionary(User_Text.Text);
                    Output.Text = translation+"\r\n"+definition;
                }
                if (metroComboBox3.SelectedIndex == 2)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "es");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 3)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "fr");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 4)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "ru");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 5)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "ko");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 6)
                {
                    string translation = Google_Translate(User_Text.Text, "auto", "ja");
                    Output.Text = translation;
                }
            }
            if (metroComboBox1.SelectedIndex == 0)
            {

            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroComboBox3.Visible = metroComboBox1.SelectedIndex == 0 ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbs = new FolderBrowserDialog();
            fbs.ShowDialog();
            path = fbs.SelectedPath;
            textBox1.Text = path;
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                metroCheckBox1.Enabled = true;
                metroCheckBox2.Enabled = true;
                metroCheckBox3.Enabled = true;
                metroCheckBox4.Enabled = true;
                metroCheckBox5.Enabled = true;
                metroCheckBox6.Enabled = true;
                metroCheckBox7.Enabled = true;
                metroCheckBox8.Enabled = true;
                label5.Text = "Current Assistant Mode: Advanced";
                label5.ForeColor = System.Drawing.Color.Red;
                materialRaisedButton3.Visible = true;
                materialRaisedButton4.Visible = true;
                materialRaisedButton5.Visible = true;

            }
            else
            {
                metroCheckBox1.Enabled = false;
                metroCheckBox2.Enabled = false;
                metroCheckBox3.Enabled = false;
                metroCheckBox4.Enabled = false;
                metroCheckBox5.Enabled = false;
                metroCheckBox6.Enabled = false;
                metroCheckBox7.Enabled = false;
                metroCheckBox8.Enabled = false;
                label5.Text = "Current Assistant Mode: Normal";
                label5.ForeColor = System.Drawing.Color.DodgerBlue;
                materialRaisedButton3.Visible = false;
                materialRaisedButton4.Visible = false;
                materialRaisedButton5.Visible = false;
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp;
            try
            {
                if (!(string.IsNullOrEmpty(User_Text.Text)))
                {
                    Search_Link = WikiDefaultLink + User_Text.Text;
                    webBrowser1.Navigate(Search_Link);
                    temp = GetPageTitle(Search_Link);
                    temp = temp.Substring(0, temp.IndexOf("-"));
                    //temp = temp.Replace(" ", "_");
                    Output.Text = Wikipedia_Source(temp);
                    //User_Query = User_Text.Text.Replace(" ", "_");
                    linkLabel1.Text = "View Full Content";
                    Output.ForeColor = System.Drawing.Color.Black;
                    
                }
                else
                {
                    MessageBox.Show("No Input Detected");
                }
            }
            catch (Exception)
            {
                Output.ForeColor = System.Drawing.Color.Red;
                Output.Text = "Error : Wikipedia does not have the information you requested";
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            
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
            catch (Exception ex)
            {
                //MessageBox.Show("Could not connect. Error:" + ex.Message);
                return "";
            }
        }
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
