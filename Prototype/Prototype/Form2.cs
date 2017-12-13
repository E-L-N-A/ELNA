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
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string User_Info = File.ReadAllLines(@"D:\.Default\.ClientInformation.txt")[0];
            Directory.Delete(User_Info);
            Directory.Delete(@"D:\.Default\",true);
            MessageBox.Show("You have to restart the application in order to apply changes");
            Application.Exit();
        }
    }
}
