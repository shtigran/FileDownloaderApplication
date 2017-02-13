# File Downloader Application
# C#6.0  .NET FRAMEWORK 4.6

----

# Screen
![alt text](https://github.com/shtigran/FileDownloaderApplication/blob/master/Downloader.jpg "File Downloader Application")

----

### Test and Result

![gif source](https://github.com/shtigran/FileDownloaderApplication/blob/master/File%20Downloader.gif)

----

### Purpose
This program allow You only with URl of website Download already all types files from that Website. You can Download Pictures, Music, Videos, Textfiles, Archiev files and programs. The program supports jpg, svg, png, gif, mp3, wav, txt, doc, docx, pdf, 3gp, avi, mp4, flv, mov, rar, iso, exe formats. The program show all files by types and their counts, then You choose which types of file You want to see. After that program open in new window the list of Your chosen files. Then You can download any types on Your Desktop.

----

### The FileDownloader class implementation

```c#
public partial class FileDownloader : Form
    {   
        // Variables for string data
        string path = string.Empty;
        string all = string.Empty;
        string htmlCode = string.Empty;
        string path1 = string.Empty;
        string filename = string.Empty;

        // Lists for any types
        List<string> TextFiles = new List<string>();
        List<string> Pictures = new List<string>();
        List<string> Music = new List<string>();
        List<string> Videos = new List<string>();
        List<string> Archives = new List<string>();
        List<string> Programs = new List<string>();


        public FileDownloader()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextFiles.Clear();
            Pictures.Clear();
            Music.Clear();
            Videos.Clear();
            Archives.Clear();
            Programs.Clear();

            if (!Uri.IsWellFormedUriString(textBox1.Text, UriKind.RelativeOrAbsolute))
                MessageBox.Show("Please enter valid URL!!!");
            else if (!textBox1.Text.Contains("http") )
                MessageBox.Show("Please enter valid URL!!!");
            else
            {
                MessageBox.Show("Scanning of " + textBox1.Text+ "\r\nClick OK to continue...");
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
                    textBox2.Text = "**************************************";

                    string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // For download direction

                    // Counters for any type
                    int countText = 0;
                    int countPictures = 0;
                    int countMusic = 0;
                    int countVideos = 0;
                    int countArchives = 0;
                    int countPrograms = 0;

                    foreach (var item in split)
                    {
                        path1 = path + item;
                       

                        if (item.Contains(".com") || item.Contains(".ru") || item.Contains(".net") || item.Contains(".ge") || item.Contains(".am") || item.Contains(".fm"))

                        {
                            if (path.Contains("http"))
                                path1 = "http:" + item;
                            if (path.Contains("https"))
                                path1 = "https:" + item;
                            
                        }

                        #region TextFiles
                        if (item.Contains(".txt") || item.Contains(".doc") || item.Contains(".docx") || item.Contains(".pdf "))
                        {
                         
                            try
                            {
                                TextFiles.Add(path1);
                                countText++;                                
                            }
                            catch (FileNotFoundException) { textBox2.Text = "This file not found!"; }
                        }

                        #endregion

                        #region Pictures
                        if (item.Contains(".jpg") || item.Contains(".png") || item.Contains(".svg") || item.Contains(".gif") || item.Contains(".jpeg"))
                        {
                          

                            try
                            {
                                Pictures.Add(path1);
                                countPictures++;                               
                            }
                            catch (FileNotFoundException) { textBox2.Text = "This file not found!"; }
                        }
                        #endregion

                        #region Music
                        if (item.Contains(".mp3") || item.Contains(".wav"))
                        {
                         

                            try
                            {
                                Music.Add(path1);
                                countMusic++;                               
                            }
                            catch (FileNotFoundException) { textBox2.Text = "This file not found!"; }
                        }

                        #endregion

                        #region Videos
                        if (item.Contains(".3gp") || item.Contains(".avi") || item.Contains(".mp4") || item.Contains(".flv") || item.Contains(".mov"))
                        {
                            


                            try
                            {
                                Videos.Add(path1);
                                countVideos++;                               
                            }
                            catch (FileNotFoundException) { textBox2.Text = "This file not found!"; }
                        }

                        #endregion

                        #region Archives
                        if (item.Contains(".rar") || item.Contains(".iso"))
                        {
                           

                            try
                            {
                                Archives.Add(path1);
                                countArchives++;                               
                            }
                            catch (FileNotFoundException) { textBox2.Text = "This file not found!"; }
                        }

                        #endregion

                        #region Programs
                        if (item.Contains(".exe"))
                        {
                            

                            try
                            {
                                Programs.Add(path1);
                                countPrograms++;                                
                            }
                            catch (FileNotFoundException) { textBox2.Text = "This file not found!"; }
                        }

                        #endregion

                    }
                    textBox2.AppendText($"\r\nThere are {TextFiles.Count + Pictures.Count + Music.Count + Videos.Count + Archives.Count + Programs.Count} files in {path}");
                    textBox2.AppendText($"\r\nIncluding:\r\n\r\nText Files: {TextFiles.Count}\r\nPictures Files: {Pictures.Count}\r\nMusic Files: {Music.Count}\r\nVideo Files: {Videos.Count}\r\nArchives Files: {Archives.Count}\r\nProgram Files: {Programs.Count}");
                    textBox2.AppendText("\r\n**************************************");
                    button6.Visible = true;
                    button7.Visible = true;
                    button8.Visible = true;
                    button9.Visible = true;
                    button10.Visible = true;
                    button11.Visible = true;
                    label2.Visible = true;
                    groupBox2.Visible = true;
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

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

 

        private void button8_Click(object sender, EventArgs e)
        {
            if (Archives.Count == 0)
                MessageBox.Show("No Files of this type!!!");
            else
            {
                Form2 f2 = new Form2();
                f2.result = Archives;
                f2.files = "Archives";
                f2.ShowDialog();
            }
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (TextFiles.Count == 0)
                MessageBox.Show("No Files of this type!!!");
            else
            {
                Form2 f2 = new Form2();
                f2.result = TextFiles;
                f2.files = "TextFiles";
                f2.ShowDialog();
            }
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (Pictures.Count == 0)
                MessageBox.Show("No Files of this type!!!");
            else
            {
                Form2 f2 = new Form2();
                f2.result = Pictures;
                f2.files = "Pictures";
                f2.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Music.Count == 0)
                MessageBox.Show("No Files of this type!!!");
            else
            {
                Form2 f2 = new Form2();
                f2.result = Music;
                f2.files = "Music";
                f2.ShowDialog();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Videos.Count == 0)
                MessageBox.Show("No Files of this type!!!");
            else
            {
                Form2 f2 = new Form2();
                f2.result = Videos;
                f2.files = "Video";
                f2.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Programs.Count == 0)
                MessageBox.Show("No Files of this type!!!");
            else
            {
                Form2 f2 = new Form2();
                f2.result = Programs;
                f2.files = "Programs";
                f2.ShowDialog();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome To The File Downloader\r\n\r\nPlease enter valid URL and click Scan.\r\nAfter You can see all files by types:\r\nTextFiles, Pictures, Music, Video, Archives and Programs.\r\nThen You will be able to download Your preferred types.\r\n..........................................................................\r\n Contacts: shakhbekyantigran@gmail.com");
        }
    }
```
----

### The Form2 class implementation

```c#
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

            textBox1.Text = $"***********************************************\r\nThe are the following {files}: \r\n\r\n";
            int count = 0;
            foreach (string  str in result)
            {
                count++;
                textBox1.AppendText($"File{count}: {str} \r\n");

                
            }
            textBox1.AppendText($"\r\nThere are {count} files. \r\n");
            textBox1.AppendText($"***********************************************");
            button2.Visible = true;
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
           if (!Directory.Exists($"{dir}\\{files}"))
                Directory.CreateDirectory($"{dir}\\{files}");

            using (WebClient client = new WebClient())
                foreach (var item in result)
                {
                    count++;
                    Uri uri = new Uri(item);
                    string[] split1 = item.Split(new Char[] { '/' });
                    filename = split1[split1.Length - 1];
                    client.DownloadFile(uri, $"{dir}\\{files}\\{count}_{filename}");

                }

            textBox1.AppendText($"\r\n\r\nThe program downloaded all files...\r\n****************************************");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Opacity = 50;
        }
    }
```

----
### Use this useful program !!!
----

