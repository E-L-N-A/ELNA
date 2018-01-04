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
<<<<<<< HEAD
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;
=======
>>>>>>> parent of 47e9c8d... Functionality Begins!

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
<<<<<<< HEAD
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
            text = text.Replace(" ", "_");
            string Dir =System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Dir = Dir + @"\Elna\temp";
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
            string[] line = File.ReadAllLines(Dir+"Temp.txt");
            try
            {
                F_Line = line[0].Substring(0, line[0].IndexOf(".") + 1);
            }
            catch (Exception)
            {
                F_Line = "No Match Result Can be Displayed Use View full content to resolve";
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


=======
>>>>>>> parent of 47e9c8d... Functionality Begins!


        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            
            
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
<<<<<<< HEAD

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(User_Text.Text))) {
                Output.Text = Wikipedia_Source(User_Text.Text);
                User_Query = User_Text.Text.Replace(" ", "_");
                Search_Link = WikiDefaultLink + User_Query;
                linkLabel1.Text = "View Full Content";
            }
            else
            {
                MessageBox.Show("No Input Detected");
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            
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
=======
>>>>>>> parent of 47e9c8d... Functionality Begins!
    }
}
