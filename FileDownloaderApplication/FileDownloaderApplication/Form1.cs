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


        

        public FileDownloader()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Please enter URL!!!");
            else if (!Uri.IsWellFormedUriString(textBox1.Text, UriKind.RelativeOrAbsolute))
                MessageBox.Show("Please enter valid URL");
            else MessageBox.Show("Scanning of " + textBox1.Text);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
