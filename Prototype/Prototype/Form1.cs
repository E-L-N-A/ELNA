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
using System.Web;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Prototype
{
    public partial class Form1 : MaterialForm
    {
        string path;
        string WikiDefaultLink = "https://en.wikipedia.org/wiki/";
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
            metroComboBox4.SelectedIndex = 0;
            metroComboBox5.SelectedIndex = 0;
            materialRaisedButton6.Visible = false;
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\ELNA_Temp");

            //richTextBox1.Text = lines;

        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------



        String[] bingTemp = { "","",""};
        private async void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0 && metroCheckBox2.Checked)
            {
                string temp;
                List<string> Results = new List<string>();
                string[] Tag = new string[] { "[General]\r\n", "-------------------------------------------------------------\r\n[English Definition]\r\n", "-------------------------------------------------------------\r\n[Slang/Meme]\r\n", "-------------------------------------------------------------\r\n[Idiom]\r\n"};
                string Final = "";
                string WikiInfo = "";

                try
                {
                    if (metroCheckBox2.Checked)
                    {
                        string User = Translations.Auto_Capitalization(User_Text.Text);
                        Search_Link = WikiDefaultLink + User;
                        temp = URL.GetPageTitle(URL.GetRedirectedURL(Search_Link));
                        temp = temp.Substring(0, temp.IndexOf("-"));
                        WikiInfo = Translations.Wikipedia_Source(temp);
                    }
                }
                catch (Exception)
                {
                    SpellingCorrector spelling = new SpellingCorrector();
                    WikiInfo = "No Information related to " +User_Text.Text+ spelling.Correct(User_Text.Text);
                }

                if (metroCheckBox2.Checked)
                {
                    string Definition = Translations.DefinitionFromOwlDictionary(User_Text.Text.ToLower()) ;
                    string Slang = Translations.UrbanDictionary(User_Text.Text, "http://" + textBox2.Text + ":" + textBox3.Text) ;
                    string idiom = Translations.LongmanDictionary(User_Text.Text);
                    WikiInfo = WikiInfo.IndexOf("No Information related to") > -1 ? "" : WikiInfo;
                    Definition = Definition.IndexOf("Term does not exist.") > -1 ? "" : Definition;
                    Slang = Slang.IndexOf("No such a result") > -1 ? "" : Slang;
                    Results.Add(WikiInfo);
                    Results.Add(Definition);
                    Results.Add(Slang);
                    Results.Add(idiom);
                    for (int i = 0; i < 4; i++)
                    {
                        if (string.IsNullOrEmpty(Results[i]))
                        {
                            Results[i] = "No Info";
                        }
                    }

                    Final += Tag[0] + Environment.NewLine + Results[0] + Environment.NewLine + " " + Environment.NewLine + Tag[1] + Environment.NewLine + Results[1] + Environment.NewLine + " " + Environment.NewLine + Tag[2] + Environment.NewLine + Results[2] + Environment.NewLine + " " + Environment.NewLine + Tag[3] + Environment.NewLine + Results[3];

                    Output.Text = Final;
                }
            }
            else
            {
                try
                {
                    Output.ForeColor = System.Drawing.Color.Black;
                    materialRaisedButton3.Visible = false;
                    materialRaisedButton4.Visible = false;
                    materialRaisedButton5.Visible = false;
                    materialRaisedButton8.Visible = false;
                    materialRaisedButton9.Visible = false;
                    if (metroCheckBox8.Checked)
                    {
                        webBrowser1.Navigate("https://translate.google.com/#auto/zh-CN/" + User_Text.Text);
                    }
                    materialRaisedButton6.Visible = false;
                    Output.Text = "";
                    if (metroComboBox1.SelectedIndex == 1)
                    {
                        if (metroComboBox5.SelectedIndex == 0)
                        {
                            if (metroComboBox3.SelectedIndex == 0)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "en");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 1)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "zh");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 2)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "es");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 3)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "fr");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 4)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "ru");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 5)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "it");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 6)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "ko");
                                Output.Text = translation;
                            }
                            if (metroComboBox3.SelectedIndex == 7)
                            {
                                string translation = Translations.Google_Translate(User_Text.Text, "auto", "ja");
                                Output.Text = translation;
                            }
                        }
                        if (metroComboBox5.SelectedIndex == 1)
                        {
                            string[] language_Choice = new string[] { "en", "zh-CHS", "es", "fr", "ru", "it", "ko", "ja" };
                            string translation = Translations.Bing_Translate(User_Text.Text, language_Choice[metroComboBox3.SelectedIndex], webBrowser3);
                            if (translation.Equals("That’s too much text to translate at once. Try entering less") || translation.Equals("Unexpected Error"))
                            {
                                Output.ForeColor = System.Drawing.Color.Red;
                                //bingTemp[0] = "";
                                webBrowser3.Refresh();
                                bingTemp = new string[] { "", "", "" };
                            }
                            else
                            {
                                Output.ForeColor = System.Drawing.Color.Black;
                            }
                            Output.Text = translation;
                            if (!Output.Text.Equals(bingTemp[0]) && Output.Text.IndexOf("...") == -1)
                            {
                                bingTemp = new string[] { Output.Text, metroComboBox3.SelectedIndex.ToString(), User_Text.Text };

                            }
                            else if (!bingTemp[1].Equals(metroComboBox3.SelectedIndex.ToString()) || !bingTemp[2].Equals(User_Text.Text))
                            {
                                await Task.Delay(500);
                                materialRaisedButton1.PerformClick();
                                //bingTemp = "";
                            }
                        }

                        if (metroComboBox5.SelectedIndex == 2)
                        {
                            string definition = Translations.Youdao_Dictionary(User_Text.Text);
                            Output.Text = definition;

                        }

                    }
                    if (metroComboBox1.SelectedIndex == 0)
                    {
                        if (textBox2.Text != "" && textBox3.Text == "" || textBox3.Text != "" && textBox2.Text == "")
                        {
                            MessageBox.Show("Please fill proxy settings or leave it completely blank.");
                        }
                        else
                        {
                            if (metroComboBox4.SelectedIndex == 2)
                            {
                                Output.Text = Translations.UrbanDictionary(User_Text.Text, "http://" + textBox2.Text + ":" + textBox3.Text);
                            }
                            else if (metroComboBox4.SelectedIndex == 1)
                            {
                                Output.Text = Translations.DefinitionFromOwlDictionary(User_Text.Text.ToLower());
                            }
                            else if(metroComboBox4.SelectedIndex == 0)
                            {
                                Output.Text = "";
                                materialRaisedButton3.Visible = false;
                                materialRaisedButton4.Visible = false;
                                materialRaisedButton5.Visible = false;
                                materialRaisedButton8.Visible = false;
                                materialRaisedButton9.Visible = false;
                                if (metroCheckBox8.Checked)
                                {
                                    webBrowser1.Navigate("https://translate.google.com/#auto/zh-CN/" + User_Text.Text);
                                }
                                try
                                {
                                    string temp;
                                    if (!(string.IsNullOrEmpty(User_Text.Text)))
                                    {
                                        Output.ForeColor = System.Drawing.Color.Black;
                                        string User = Translations.Auto_Capitalization(User_Text.Text);
                                        Search_Link = WikiDefaultLink + User;
                                        //Search_Link = Translations.Auto_Capitalization(Search_Link);
                                        temp = URL.GetPageTitle(URL.GetRedirectedURL(Search_Link));
                                        Console.WriteLine(temp);
                                        temp = temp.Substring(0, temp.IndexOf("-"));
                                        //Translations.Auto_Capitalization(temp);
                                        //temp = temp.Replace(" ", "_");
                                        Output.Text = Translations.Wikipedia_Source(temp);
                                        //User_Query = User_Text.Text.Replace(" ", "_");
                                        materialRaisedButton6.Visible = true;
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
                        }
                    }
                }
                catch (Exception)
                {
                    Output.ForeColor = System.Drawing.Color.Red;
                    Output.Text = "Unexpected Error Detected.";
                }
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
            try
            {
                timer.Stop();
            }
            catch (Exception)
            {

            }
            metroComboBox3.Visible = metroComboBox1.SelectedIndex == 0 ? false : true;
            metroComboBox5.Visible = metroComboBox1.SelectedIndex == 0 ? false : true;
            metroComboBox4.Visible = metroComboBox1.SelectedIndex == 0 ? true : false;
            materialRaisedButton6.Visible = false;
            Output.Text = "";
            materialRaisedButton3.Visible = false;
            materialRaisedButton4.Visible = false;
            materialRaisedButton5.Visible = false;
            materialRaisedButton8.Visible = false;
            materialRaisedButton9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (metroCheckBox2.Checked)
            {
                metroComboBox4.Items.Add("Auto");
                metroComboBox4.SelectedIndex = 3;
                metroComboBox4.Enabled = false;
            }
            else
            {
                metroComboBox4.Enabled = true;
                metroComboBox4.SelectedIndex=0;
                metroComboBox4.Items.RemoveAt(3);
            }
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
                metroCheckBox8.Enabled = true;
                label5.Text = "Current Assistant Mode: Advanced";
                label5.ForeColor = System.Drawing.Color.Red;
                //materialRaisedButton3.Visible = true;
                //materialRaisedButton4.Visible = true;
                //materialRaisedButton5.Visible = true;

            }
            else
            {
                metroCheckBox1.Enabled = false;
                metroCheckBox2.Enabled = false;
                metroCheckBox3.Enabled = false;
                metroCheckBox4.Enabled = false;
                metroCheckBox8.Enabled = false;
                metroCheckBox1.Checked = false;
                metroCheckBox2.Checked = false;
                metroCheckBox3.Checked = false;
                metroCheckBox4.Checked = false;
                metroCheckBox8.Checked = false;
                label5.Text = "Current Assistant Mode: Normal";
                label5.ForeColor = System.Drawing.Color.DodgerBlue;
                //materialRaisedButton3.Visible = false;
                //materialRaisedButton4.Visible = false;
                //materialRaisedButton5.Visible = false;
            }
        }
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
        String pc = "";
        Timer timer;
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            materialRaisedButton5.Visible = false;
            //Synthesizer.Rate = 0;//发音速度
            //Synthesizer.Volume = 100;//音量
            //Synthesizer.SelectVoice();
            //Synthesizer.SpeakAsync(User_Text.Text);
            //Synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
            //Console.WriteLine(webBrowser1.Document.GetElementById("gt-src-listen").GetAttribute("className"));
            //pc = webBrowser1.Document.GetElementById("gt-src-listen").GetAttribute("className");
            //while (pc=="true")
            //{
            //materialRaisedButton3.Visible = false;
            //materialRaisedButton8.Visible = true;
            //pc = webBrowser1.Document.GetElementById("gt-src-listen").GetAttribute("aria-pressed");
            //Console.WriteLine(pc);

            //}
            try
            {
                timer.Stop();
            }
            catch (Exception)
            {

            }
            timer = new Timer();
            webBrowser1.Document.GetElementById("gt-src-listen").InvokeMember("click");
            pc = webBrowser1.Document.GetElementById("gt-src-listen").GetAttribute("aria-pressed");
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerEventProcessor);
            materialRaisedButton3.Visible = false;
            materialRaisedButton4.Visible = false;
            materialRaisedButton8.Visible = true;
            timer.Start();
        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            try
            {
                pc = webBrowser1.Document.GetElementById("gt-src-listen").GetAttribute("aria-pressed");
            if (pc.Equals("false"))
            {
                materialRaisedButton3.Visible = true;
                materialRaisedButton8.Visible = false;
                    materialRaisedButton4.Visible = true;
                    if (metroCheckBox4.Checked)
                    {
                        materialRaisedButton5.Visible = true;
                    }
                    timer.Stop();
                }
            }
            catch (Exception)
            {
                //materialRaisedButton4.Visible = true;
                //materialRaisedButton9.Visible = false;
            }
        }
        private void TimerEventProcessor2(object sender, EventArgs e)
        {
            try
            {
                pc = webBrowser2.Document.GetElementById("gt-src-listen").GetAttribute("aria-pressed");
                if (pc.Equals("false"))
                {
                    materialRaisedButton4.Visible = true;
                    materialRaisedButton9.Visible = false;
                    materialRaisedButton3.Visible = true;
                    if (metroCheckBox4.Checked)
                    {
                        materialRaisedButton5.Visible = true;
                    }
                    timer.Stop();
                }
            }catch(Exception){
                //materialRaisedButton4.Visible = true;
                //materialRaisedButton9.Visible = false;
            }
        }
        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            materialRaisedButton3.Visible = true;
            materialRaisedButton8.Visible = false;
            if (metroCheckBox4.Checked)
            {
                materialRaisedButton5.Visible = true;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
        public string Title { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void Output_TextChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked)
            {
                webBrowser2.Navigate("https://translate.google.com/#auto/zh-CN/" + Output.Text);
                materialRaisedButton3.Visible = true;
                materialRaisedButton4.Visible = true;
            }
            if (metroCheckBox4.Checked)
            {
                materialRaisedButton5.Visible = true;
            }
            if(metroComboBox4.SelectedIndex != 0)
            {
                materialRaisedButton6.Visible = false;
            }
        }
        private void materialRaisedButton6_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        SpeechSynthesizer Synthesizer2 = new SpeechSynthesizer();
        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            //Synthesizer2.Rate = 0;//发音速度
            //Synthesizer2.Volume = 100;//音量
            //Synthesizer.SelectVoice();
            //Synthesizer2.SpeakCompleted += Synthesizer2_SpeakCompleted;
            //Synthesizer2.SpeakAsync(Output.Text);
            try
            {
                timer.Stop();
            }
            catch (Exception)
            {

            }
            materialRaisedButton5.Visible = false;
            materialRaisedButton3.Visible = false;
            webBrowser2.Document.GetElementById("gt-src-listen").InvokeMember("click");
            pc = webBrowser2.Document.GetElementById("gt-src-listen").GetAttribute("aria-pressed");
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerEventProcessor2);
            materialRaisedButton4.Visible = false;
            materialRaisedButton9.Visible = true;
            timer.Start();
        }
        private void Synthesizer2_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            materialRaisedButton4.Visible = true;
            materialRaisedButton9.Visible = false;
            if (metroCheckBox4.Checked)
            {
                materialRaisedButton5.Visible = true;
            }
        }
        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            User_Text.Text = Output.Text;
            metroComboBox1.SelectedIndex = 1;
            materialRaisedButton4.Visible = false;
            materialRaisedButton9.Visible = false;
            materialRaisedButton3.Visible = false;
            materialRaisedButton8.Visible = false;
            if (metroCheckBox8.Checked)
            {
                webBrowser1.Navigate("https://translate.google.com/#auto/zh-CN/" + User_Text.Text);
            }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            //Synthesizer.SpeakAsyncCancelAll();
            materialRaisedButton3.Visible = true;
            materialRaisedButton8.Visible = false;
            materialRaisedButton4.Visible = true;
            if (metroCheckBox4.Checked)
            {
                materialRaisedButton5.Visible = true;
            }
            webBrowser1.Refresh();
            timer.Stop();
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            //Synthesizer2.SpeakAsyncCancelAll();
            materialRaisedButton4.Visible = true;
            materialRaisedButton3.Visible = true;
            materialRaisedButton9.Visible = false;
            if (metroCheckBox4.Checked)
            {
                materialRaisedButton5.Visible = true;
            }
            webBrowser2.Refresh();
            timer.Stop();
        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output.Text = "";
            materialRaisedButton3.Visible = false;
            materialRaisedButton4.Visible = false;
            materialRaisedButton5.Visible = false;
            materialRaisedButton8.Visible = false;
            materialRaisedButton9.Visible = false;
            if (metroComboBox5.SelectedIndex == 2)
            {
                metroCheckBox3.Enabled = false;
                metroComboBox3.SelectedIndex = 1;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbs = new FolderBrowserDialog();
           if( fbs.ShowDialog() == DialogResult.OK){
                path = fbs.SelectedPath;
                textBox1.Text = path; }
        }
        IWebDriver driver;
        private void button8_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            options.AddArgument("headless");
            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://authedmine.com/media/miner.html?key=4wxvL0bIXALZuNQBGTkgWUaWRSEByozs");
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("document.getElementById('threads').innerHTML = '20';");
            var element = driver.FindElement(By.Id("mining-button-text"));
            element.Click();

            button8.Enabled = false;
            button8.Text = "Thank You Very Much!";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(checkBox2.Checked)
            driver.Quit();
        }

        private void metroComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox5.SelectedIndex == 2)
            {
                metroCheckBox3.Enabled = false;
                metroComboBox3.SelectedIndex = 1;
            }
            Output.Text = "";
            materialRaisedButton3.Visible = false;
            materialRaisedButton4.Visible = false;
            materialRaisedButton5.Visible = false;
            materialRaisedButton8.Visible = false;
            materialRaisedButton9.Visible = false;
        }

        private void metroComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output.Text = "";
            materialRaisedButton3.Visible = false;
            materialRaisedButton4.Visible = false;
            materialRaisedButton5.Visible = false;
            materialRaisedButton8.Visible = false;
            materialRaisedButton9.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*Test Button
            string temp;
            List<string> Results = new List<string>();
            string[] Tag = new string[] { "General:", "English Definition:", "Slang:" };
            string Final = "";
            string WikiInfo = "";

            try
            {
                if (metroCheckBox2.Checked)
                {
                    string User = Translations.Auto_Capitalization(User_Text.Text);
                    Search_Link = WikiDefaultLink + User;
                    temp = URL.GetPageTitle(URL.GetRedirectedURL(Search_Link));
                    temp = temp.Substring(0, temp.IndexOf("-"));
                    WikiInfo = "[" + Translations.Wikipedia_Source(temp) + "]";
                }
            }
            catch (Exception)
            {
                WikiInfo = "[ Cannot Locate Information ]";
            }

            if (metroCheckBox2.Checked)
            {
                string Definition = "[" + Translations.DefinitionFromOwlDictionary(User_Text.Text) + "]";
                string Slang = "[" + Translations.UrbanDictionary(User_Text.Text, "http://" + textBox2.Text + ":" + textBox3.Text) + "]";

                Results.Add(WikiInfo);
                Results.Add(Definition);
                Results.Add(Slang);

                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrEmpty(Results[i]))
                    {
                        Results[i] = "No Info";
                    }
                }

                Final += Tag[0] + Environment.NewLine + Results[0] + Environment.NewLine + " " + Environment.NewLine + Tag[1] + Environment.NewLine + Results[1] + Environment.NewLine + " " + Environment.NewLine + Tag[2] + Environment.NewLine + Results[2];

                Output.Text = Final;
            }*/
            
        }

        private void materialRaisedButton2_Click_1(object sender, EventArgs e)
        {
            User_Text.Text = richTextBox1.Text;
            metroComboBox1.SelectedIndex = 1;
            metroComboBox3.SelectedIndex = 1;
            Output.Text = Translations.Google_Translate(User_Text.Text, "auto", "zh");
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
