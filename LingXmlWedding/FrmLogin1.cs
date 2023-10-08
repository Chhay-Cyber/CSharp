using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LinqXmlWedding
{
    public partial class FrmLogin1 : Form
    {
        public static string UserFolderName;


        public string Path = Directory.GetCurrentDirectory() + "\\Information\\loginfile.xml";
        
        public string FolderName;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


        public FrmLogin1()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 6, 6));
       
            LoadCredentials();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SaveCredentials();
            bool name = checkID(Path, "Username", txtUsername.Text);
            bool pass = checkID(Path, "Password", txtPassword.Text);

            if (name && pass)
            {

                this.Hide();
                FolderName = txtUsername.Text;
                UserFolderName = Directory.GetCurrentDirectory()+"\\"+FolderName;
                frmHome f = new frmHome();              
                f.Show();
                //backgroundWorker1.RunWorkerAsync();
                /*
                Task<Form>.Factory.StartNew(()=>
                    {
                        return new frm;
                    }).ContinueWith(t=>
                        {
                            f=t.Result;
                        }*/
               
            }
            else
            {
                MessageBox.Show("Not Have Acount!!Create New Account??");

            }
        }

        public  bool checkID(string path, string element, string text)
        {
            XmlDocument advDoc = new XmlDocument();
            using (var reader = new XmlTextReader(path))
            {
                advDoc.Load(reader);
                XmlNodeList _ngroups = advDoc.GetElementsByTagName(element);
                foreach (XmlNode nd in _ngroups)
                {
                    if (nd.InnerText.ToString().Equals(text))
                        return true;
                }
            }
            return false;
        }
        void SaveCredentials()
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Username = txtUsername.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }

        }
        void LoadCredentials()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
                checkBox1.Checked = true;
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmSigup f = new frmSigup();
            f.Show();


        }

        private void FrmLogin1_Load(object sender, EventArgs e)
        {
            Task<Image>.Factory.StartNew(() =>
            {
                return Bitmap.FromFile(@"D:\CSD-Year3\New folder\LinqXmlWedding\bin\Debug\icon\goldgradient (2).jpg");
            }).ContinueWith(t =>
            {
                this.BackgroundImage = t.Result;
                // this.BackgroundImageLayout=
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
