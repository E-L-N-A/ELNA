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
    public partial class Form3 : MaterialForm
    {
        string path;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
            materialRaisedButton1.Visible = false;
            materialRaisedButton2.Visible = false;
            materialRaisedButton3.Visible = false;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialRaisedButton1.Visible = true;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            materialRaisedButton1.Visible = false;
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
            materialRaisedButton1.Visible = true;
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            materialRaisedButton3.Visible = false;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton2.Visible = true;
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton2.Visible = true;
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton2.Visible = true;
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton2.Visible = true;
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton2.Visible = true;
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton3.Visible = true;
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton3.Visible = true;
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            materialRaisedButton3.Visible = true;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            materialRaisedButton2.Visible = false;
        }
    }
}
