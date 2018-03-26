using System;
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

namespace Prototype
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.Search_Link;
            webBrowser1.Navigate(textBox1.Text);
            textBox1.Text= URL.GetPageTitle(textBox1.Text);
            textBox2.Text = Form1.Search_Link;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBox1.Text;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox2.Text = webBrowser1.Url.AbsoluteUri;
        }
    }
}
