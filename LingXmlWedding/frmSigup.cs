using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LinqXmlWedding
{
    public partial class frmSigup : Form
    {
        //public String ForlderName;

        public  string loginFile=Directory.GetCurrentDirectory()+"\\Information\\loginfile.xml";
        
        public frmSigup()
        {
            InitializeComponent();
            
        }

        public bool checkID(string path, string element, string text)
        {
            if (File.Exists(loginFile))
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
            }
            return false;
        }
       

        private bool checkPassword()
        {
            if (txtPassword.Text != string.Empty && txtConfirmPassword.Text != string.Empty && txtConfirmPassword.Text.Equals(txtPassword.Text))
                return true;
            return false;

        }

        private bool checkEmpty()
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text) || string.IsNullOrEmpty(txtPassword.Text))
                return false;
            else
                return true;
        }
        private bool checkAll()
        {
            if (checkPassword() == true && checkEmpty() == true)
                return true;
            else
                return false;
        }

        private string getGender()
        {
            if (rdoFemale.Checked == true)
            {
                return rdoFemale.Text;
            }
            else if (rdoMale.Checked == true)
            {
                return rdoMale.Text;
            }
            else
            {
                return "Null";
            }
        }
      
       

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            //FrmLogin1 f = new FrmLogin1();
            //f.Show();
            string Gender = getGender();
            if (checkAll())
            {
                if (!File.Exists(loginFile))
                {

                    XDocument doc = new XDocument(
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Users",
                        new XElement("User",// new XAttribute("ID", 1),
                            new XElement("Username", txtUsername.Text.Trim()),
                            new XElement("Gender", Gender),
                            new XElement("Email", txtEmail.Text),
                            new XElement("DateOfBirth", dateTimePicker1.Value.ToShortDateString()),
                            new XElement("DateSignup", DateTime.Now.ToShortDateString()),
                            new XElement("Password", txtPassword.Text.Trim())
                            )));
                    doc.Save(loginFile);
                    MessageBox.Show("Successfull");
                    this.Hide();
                    FrmLogin1 f = new FrmLogin1();
                    f.Show();
                }
                else
                {
                    AddRecords();     

                }
                
            }
            else
            {
                MessageBox.Show("Fill Information!!");
            }



        }

        private void AddRecords()
        {    
            XDocument doc = XDocument.Load(loginFile);
            //int count = doc.Descendants("Username").Count();   //10
           // int pickId = GiveID(count);
            bool checkUsername=checkID(this.loginFile, "Username", txtUsername.Text.Trim());
            if (!checkUsername)
            {

                doc.Element("Users").Add(
                    new XElement("User",//new XAttribute("ID",count+1),
                        new XElement("Username", txtUsername.Text),
                        new XElement("Gender", getGender()),
                        new XElement("Email", txtEmail.Text),
                        new XElement("DateOfBirth", dateTimePicker1.Value.ToShortDateString()),
                        new XElement("DateSignup", DateTime.Now.ToShortDateString()),
                        new XElement("Password", txtPassword.Text.Trim())

                        ));
                doc.Save(loginFile);
                MessageBox.Show("Successfull");
                this.Hide();
                FrmLogin1 f = new FrmLogin1();
                f.Show();

            }
            else
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
                MessageBox.Show("Try New Name");
                return;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                    Char.IsSeparator(e.KeyChar) ||
                    Char.IsSymbol(e.KeyChar);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 4)
            {
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Your name must be between 4 and 8words");
                txtUsername.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }


       

      
    }
}
