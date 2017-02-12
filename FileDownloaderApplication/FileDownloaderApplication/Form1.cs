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
            MessageBox.Show("Scanning of " + InputUrl.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
