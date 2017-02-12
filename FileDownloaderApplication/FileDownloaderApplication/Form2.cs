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
    public partial class Form2 : Form
    {
        public List<string> result = new List<string>();
        public string files;


        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = $"There are the following {files}: ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
