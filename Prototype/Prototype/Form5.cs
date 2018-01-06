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
namespace Prototype
{
    public partial class Form5 : MaterialForm
    {
        string path;
        string DefaultPath= @"D:\.Default\.ClientInformation.txt";
        string LanguagePreference;
        public Form5()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Your Language");
            comboBox1.Items.Add("English");
            comboBox1.Items.Add("Chinese");
            if (File.Exists(DefaultPath))
            {
                Step1_Panel.Controls.Clear();
                panel3.Controls.Clear();
                Notification_Label.Text = "You have exsiting Record";
                Done.Visible = false;
                MAINPAGE.Visible = true;
                MAINPAGE.Location = new Point(274, 97);
                
            }

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            LanguagePreference = comboBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text!= "Your Language" && comboBox1.Text != "")
            {
                LanguageConfirmatio.Enabled = true;
            }
            else
            {
                label2.Text = "";
            }
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbs = new FolderBrowserDialog();
            fbs.ShowDialog();
            path = fbs.SelectedPath;
            textBox1.Text = path;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != ""&&comboBox1.Text!=""&&comboBox1.Text!="Your Language")
            {
                Done.Enabled = true;
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Language Preference has been set to "+comboBox1.Text+Environment.NewLine+"File Location has been set to "+textBox1.Text+Environment.NewLine+"(You can change Those setting later in Setting Section )");
            path = path + "ELNA";
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(@"D:\.Default\");
            using (StreamWriter sw = File.CreateText(DefaultPath))
            {
                sw.WriteLine(path);
                sw.WriteLine(LanguagePreference);
            }
            Form4 f2 = new Form4();
            this.Hide();
            f2.FormClosed += (s, args) => this.Close();
            f2.Show();
            f2.Focus();

        }

        private void MAINPAGE_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4();
            this.Hide();
            f2.FormClosed += (s, args) => this.Close();
            f2.Show();
            f2.Focus();
        }
    }
}
