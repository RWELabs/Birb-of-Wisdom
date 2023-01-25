using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Birb_of_Wisdom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "v" + Properties.Settings.Default.Version;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CheckUpdate(object sender, EventArgs e)
        {
            linkLabel1.Text = "Checking for Updates...";
            XmlDocument document = new XmlDocument();
            document.Load("https://www.ryanwalpole.com/h/wisdombirb/updatecheck.xml");
            string allText = document.InnerText;
            if (allText.Contains(Properties.Settings.Default.Version))
            {
                linkLabel1.Text = "Updates Available!";
                DialogResult dr = MessageBox.Show("There is an update available for the Birb of Wisdom. Would you like to update now?", "Birb of Wisdom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (WebClient wc = new WebClient())
                    {
                        string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                        string updatelocation = Path.Combine(dataPath, "wisdombirblatest.exe");
                        progressBar1.Visible = true;
                        linkLabel1.Text = "Downloading Updates...";

                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri("https://www.ryanwalpole.com/h/wisdombirb/latest.exe"),
                            // Param2 = Path to save
                            updatelocation
                        );
                        this.BringToFront();
                    }
                }
            }
            else if (!allText.Contains(Properties.Settings.Default.Version))
            {
                linkLabel1.Text = "No updates available :)";
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            long FileSize = e.TotalBytesToReceive / 1024;
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";
            //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + e.TotalBytesToReceive.ToString() + " bytes";

            if (progressBar1.Value == 100)
            {
                this.BringToFront();
                progressBar1.Value = 100;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string updatelocation = Path.Combine(dataPath, "wisdombirblatest.exe");

            Process.Start(updatelocation);
        }

        private void Question_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Do something
                e.Handled = true;
                Query.PerformClick();
            }
        }

        private void Query_Click(object sender, EventArgs e)
        {
            //List
            //1 - Yes
            //2 - No
            //3 - I believe so
            //4 - Unfortunately Yes
            //5 - You already know
            //6 - If you have to ask, no
            //7 - Definitely not.
            //8 - Be careful what you ask for
            //9 - Ask again later
            //10 - Why of course
            //11 - I shan't answer that
            //12 - Not a chance
            //13 - Your query disturbs me but the answer is yes
            //14 - Absolutely
            //15 - No
            //16 - Most likely not
            //17 - I cannot determine

            if (Question.Text == string.Empty)
            {
                //do nothing
            }
            else
            {
                Random rnd = new Random();
                //string[] secOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                int randomNumber = rnd.Next(1, 17);
                //MessageBox.Show(randomNumber.ToString());
                Query.Text = "Ask Again";

                switch (randomNumber)
                {
                    case 1:
                        Answer.Image = new Bitmap(Properties.Resources.Answer1);
                        break;
                    case 2:
                        Answer.Image = new Bitmap(Properties.Resources.Answer2);
                        break;
                    case 3:
                        Answer.Image = new Bitmap(Properties.Resources.Answer3);
                        break;
                    case 4:
                        Answer.Image = new Bitmap(Properties.Resources.Answer4);
                        break;
                    case 5:
                        Answer.Image = new Bitmap(Properties.Resources.Answer5);
                        break;
                    case 6:
                        Answer.Image = new Bitmap(Properties.Resources.Answer6);
                        break;
                    case 7:
                        Answer.Image = new Bitmap(Properties.Resources.Answer7);
                        break;
                    case 8:
                        Answer.Image = new Bitmap(Properties.Resources.Answer8);
                        break;
                    case 9:
                        Answer.Image = new Bitmap(Properties.Resources.Answer9);
                        break;
                    case 10:
                        Answer.Image = new Bitmap(Properties.Resources.Answer10);
                        break;
                    case 11:
                        Answer.Image = new Bitmap(Properties.Resources.Answer11);
                        break;
                    case 12:
                        Answer.Image = new Bitmap(Properties.Resources.Answer12);
                        break;
                    case 13:
                        Answer.Image = new Bitmap(Properties.Resources.Answer13);
                        break;
                    case 14:
                        Answer.Image = new Bitmap(Properties.Resources.Answer14);
                        break;
                    case 15:
                        Answer.Image = new Bitmap(Properties.Resources.Answer15);
                        break;
                    case 16:
                        Answer.Image = new Bitmap(Properties.Resources.Answer16);
                        break;
                    case 17:
                        Answer.Image = new Bitmap(Properties.Resources.Answer17);
                        break;
                }
            }
        }

        private void Question_TextChanged(object sender, EventArgs e)
        {
            if(Query.Text == "Query the Birb")
            {
                //do nothing
            }
            else
            {
                Query.Text = "Query the Birb";
            }
        }

        private void Question_Click(object sender, EventArgs e)
        {
            Question.SelectAll();
        }
    }
}
