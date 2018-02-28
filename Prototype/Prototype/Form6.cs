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
using System.Threading;

namespace Prototype
{
    public partial class Form6 : MaterialForm
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            TargetLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ELNA_Temp";
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sour = "";
            string tar = "";
            if (string.IsNullOrWhiteSpace(SourceFile.Text) || string.IsNullOrWhiteSpace(TargetLocation.Text))
            {
                MessageBox.Show("No Blank is Allowed");

            }
            else
            {
                sour = SourceFile.Text;
                tar = TargetLocation.Text;
                AdvanceFeatures.FileToFileTranslationVer2(sour,tar,"en","zh");
                MessageBox.Show("File has been successfully generated");
            }
            /*
             * Multiple Threading
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                // run your code here 
                MessageBox.Show("Multiple Threading");
            }).Start();*/

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                SourceFile.Text = od.FileName;
            }
        }
    }
}
