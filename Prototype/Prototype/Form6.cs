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
using VideoLibrary;
using System.IO;

namespace Prototype
{
    public partial class Form6 : MaterialForm
    {
        string output;
        string[] language_Choice = new string[] {"zh","es","it","fr","ru","ja","ko" };
        public Form6()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            TargetLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ELNA_Temp";
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ELNA_Temp";
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
            else if(SourceFile.Text.Contains(".txt"))
            {
                sour = SourceFile.Text;
                tar = TargetLocation.Text;
                AdvanceFeatures.FileToFileTranslationVer2(sour,tar,"auto",language_Choice[File_To.SelectedIndex]);
                MessageBox.Show("File has been successfully generated");
                
            }else{

                sour = SourceFile.Text;
                tar = TargetLocation.Text;
                AdvanceFeatures.FileToFileTranslationPDF(sour, tar, "auto", language_Choice[File_To.SelectedIndex]);
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

        private void button8_Click(object sender, EventArgs e)
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
                AdvanceFeatures.FileToFileTranslation(sour, tar, "en", "zh");
                MessageBox.Show("File has been successfully generated");

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            YouTube you = YouTube.Default;
            Video vid = you.GetVideo(textBox4.Text);
            string input = textBox5.Text + @"\" + vid.FullName;
            output = textBox5.Text + @"\" + "Youtube" + DateTime.Now.ToString("MMddyyyy_hhmmtt") + ".wav";
            Original.Text = "Please wait while We are trying to understand your file...";
            new Thread(() =>
            {

                Thread.CurrentThread.IsBackground = true;
                AdvanceFeatures.YoutubeExtraction(input, output, vid.GetBytes());

            }).Start();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Original.Text = AdvanceFeatures.Voice_Recognition(output);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = fb.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = opf.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
           
            if (DialogResult.OK == opf.ShowDialog())
            {
                try
                {
                    textBox1.Text = opf.FileName;
                    richTextBox1.Text = AdvanceFeatures.TextInImage(opf.FileName);
                    TranslatedImageText.Text = Translations.Google_Translate(richTextBox1.Text, "en", language_Choice[Image_To.SelectedIndex]);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string defaultpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ELNA(Image)";
            Directory.CreateDirectory(defaultpath);
            defaultpath = defaultpath + @"\Image_" + DateTime.Now.ToString("MMddyyyy_hhmmtt")+".jpeg";
            if (!(string.IsNullOrEmpty(textBox3.Text)))
            {
                try
                {
                    textBox1.Text = textBox3.Text;
                    AdvanceFeatures.DownloadImage(textBox3.Text, defaultpath);
                    richTextBox1.Text = AdvanceFeatures.TextInImage(defaultpath);
                    TranslatedImageText.Text = Translations.Google_Translate(richTextBox1.Text, "en", language_Choice[Image_To.SelectedIndex]);

                }
                catch(Exception)
                {
                    MessageBox.Show("Format not Supported");
                }

            }
            else
            {

            }
        }

        private void Image_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text))
                {
                    TranslatedImageText.Text = Translations.Google_Translate(richTextBox1.Text, "en", language_Choice[Image_To.SelectedIndex]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Input Detected");
            }
        }

        private void File_To_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
