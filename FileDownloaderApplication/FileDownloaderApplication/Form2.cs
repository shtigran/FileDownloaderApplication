using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloaderApplication
{
    public partial class Form2 : Form
    {
        public List<string> result = new List<string>();
        public string files = string.Empty;


        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = $"The are the following {files}: \r\n\r\n";
            int count = 0;
            foreach (string  str in result)
            {
                count++;
                textBox1.AppendText($"File{count}: {str} \r\n");

                
            }
            textBox1.AppendText($"\r\nThere are {count} files. \r\n");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // For download direction
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string filename = string.Empty;
        int count = 0;

        private void button2_Click(object sender, EventArgs e)
        {


            if (!Directory.Exists(dir + "\\TextFiles"))
                Directory.CreateDirectory(dir + "\\TextFiles");

            using (WebClient client = new WebClient())
                foreach (var item in result)
                {
                    count++;
                    Uri uri = new Uri(item);
                    string[] split1 = item.Split(new Char[] { '/' });
                    filename = split1[split1.Length - 1];
                    client.DownloadFile(uri, $"{dir}\\TextFiles\\{count}_{filename}");

                }

            textBox1.AppendText($"\r\n\r\nThe program downloaded all files...\r\n****************************************");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {



        }
    }
}
