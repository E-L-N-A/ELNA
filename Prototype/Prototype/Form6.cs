﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;

namespace Prototype
{
    public partial class Form6 : MaterialForm
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.Search_Link;
            webBrowser1.Navigate(textBox1.Text);
            textBox1.Text= Form1.GetPageTitle(textBox1.Text);
            textBox2.Text = GetRedirectedURL(Form1.Search_Link);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static string GetRedirectedURL(string url)
        {
            HttpWebRequest WebR = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse WebP = (HttpWebResponse)WebR.GetResponse();
            if (WebR.RequestUri != WebR.Address)
            {
                return WebR.Address.ToString();
            }
            else
            {
                return WebR.RequestUri.ToString();
            }
        }

    }
}
