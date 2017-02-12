using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloaderApplication
{
    public partial class FileDownloader : Form
    {

        string all = string.Empty;
        string htmlCode = string.Empty;
        string path1 = string.Empty;
        string filename = string.Empty;


        public FileDownloader()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!Uri.IsWellFormedUriString(textBox1.Text, UriKind.RelativeOrAbsolute))
                MessageBox.Show("Please enter valid URL!!!");
            else if (!textBox1.Text.Contains("http") || !textBox1.Text.Contains("https"))
                MessageBox.Show("Please enter valid URL!!!");
            else MessageBox.Show("Scanning of " + textBox1.Text);



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
                         
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
