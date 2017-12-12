using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;
using System.IO;
namespace Prototype
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex=0;
        }


        private void materialCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            if (materialCheckBox1.Checked)
            {
                //form.AutoSize = true;
                materialRaisedButton2.Visible = true;
                materialLabel1.Visible = true;
                textBox1.Visible = true;
                this.ClientSize = new Size(580,540);
            }
            else
            {
                materialRaisedButton2.Visible = false;
                materialLabel1.Visible = false;
                textBox1.Visible = false;
                //form.AutoSize = true;
                this.ClientSize = new Size(287, 541);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
