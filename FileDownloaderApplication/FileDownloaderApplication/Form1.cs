using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloaderApplication
{
    public partial class FileDownloader : Form
    {
        string path = string.Empty;
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
            else
            {
                MessageBox.Show("Scanning of " + textBox1.Text);
                path = textBox1.Text;
                textBox2.Visible = true;                  
            
                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable 
                {
                    // Downoload the HTML code of URL
                    htmlCode = client.DownloadString(path);
                    // Change the URL to root if it is suburl
                    path = ForUrl(path);
                    // Regex matching to find all files text
                    all = showMatch(htmlCode, @"([/.%@_a-zA-Z0-9\-]+?)\.(jpg|svg|png|gif|mp3|wav|txt|doc|docx|pdf|3gp|avi|mp4|flv|mov|rar|iso|exe)");                   
                    // Recieving the lines of each file
                    string[] split = all.Split(new Char[] { '\n' });
                    if (path == "https://mail.ru/") split[21] = split[8]; // Bug finded                 
                    textBox2.Text = "There are the following files: ";


                }
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        // Method For correct url if it is Suburl
        private static string ForUrl(string path)
        {
            string[] list = path.Split('/');
            foreach (var item in list)
            {
                if (item.Contains(".com") || item.Contains(".ru") || item.Contains(".net") || item.Contains(".ge") || item.Contains(".am") || item.Contains(".fm"))
                    path = list[0] + "//" + item + '/';
            }

            return path;
        }

        // Method For Regex Matching
        private static string showMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            string result = "";
            foreach (Match m in mc)
            {
                result += m.ToString() + "\n";
            }
            return result;
        }
    }

}
