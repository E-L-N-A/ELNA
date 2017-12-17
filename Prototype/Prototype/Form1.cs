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
    public partial class Form1 : MaterialForm
    {
        string path;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex=0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
        }


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
    }
}
