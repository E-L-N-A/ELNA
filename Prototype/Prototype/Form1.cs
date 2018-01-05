﻿using System;
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
                    string translation =Translations.Google_Translate(User_Text.Text, "auto", "en");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 1)
                {
                    string translation = Translations.Google_Translate(User_Text.Text, "auto", "zh");
                    string definition = Translations.Youdao_Dictionary(User_Text.Text);
                    Output.Text = translation+"\r\n"+definition;
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
                    string translation = Translations.Google_Translate(User_Text.Text, "auto", "ko");
                    Output.Text = translation;
                }
                if (metroComboBox3.SelectedIndex == 6)
                {
                    string translation = Translations.Google_Translate(User_Text.Text, "auto", "ja");
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
                    //webBrowser1.Navigate(Search_Link);
                    temp =URL.GetPageTitle(URL.GetRedirectedURL(Search_Link));
                    temp = temp.Substring(0, temp.IndexOf("-"));
                    //temp = temp.Replace(" ", "_");
                    Output.Text = Translations.Wikipedia_Source(temp);
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
        

        private void Output_TextChanged(object sender, EventArgs e)
        {

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
