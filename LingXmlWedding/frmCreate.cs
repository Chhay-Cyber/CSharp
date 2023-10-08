using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LinqXmlWedding
{
    public partial class frmCreate : Form
    {
        public  string FileName=null;
        public static string SavePath;

        public frmCreate()
        {
            InitializeComponent();
            
        }
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecription.Text)) txtDecription.Text = "null";
            getZeroValue();
            
            if (!File.Exists(SavePath))
            {
                
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment(frmHome.XcommentString),
                    new XElement("Guests",
                    new XElement("Guest",// new XAttribute("ID", 1),
                        new XElement("ID",1),
                        new XElement("Hname", txtHname.Text),
                        new XElement("Wname", txtWname.Text),
                        new XElement("Address",txtAddress.Text.Trim()),
                        new XElement("KhmerCurrency",txtKCurrency.Text.Trim()),
                        new XElement("USACurrency",txtUCurrency.Text.Trim()),
                        new XElement("Description",txtDecription.Text.Trim()) ,
                        new XElement("RegisterDate", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
                        )));
                doc.Save(SavePath);
                
                ResetControl();
                MessageBox.Show("Success");
            }
            else
            {
                AddRecords();
                MessageBox.Show("Successfull");
                txtIDsearch.Clear();
            }
            ResetControl();
        }
        private bool checkID(string id)
        {
            XmlDocument advDoc = new XmlDocument();
            using (var reader = new XmlTextReader(SavePath))
            {
                advDoc.Load(reader);
                XmlNodeList _ngroups = advDoc.GetElementsByTagName("ID");
                foreach (XmlNode nd in _ngroups)
                {
                    if (nd.InnerText.ToString().Contains(id))
                        return true;
                }

            }
            return false;
        }

        private int GiveID(int id)
        {
            
            ArrayList arrID = new ArrayList();
            
            XDocument doc = XDocument.Load(SavePath);
            //int count = doc.Descendants("Hname").Count();
            XmlDocument advDoc = new XmlDocument();
            using (var reader = new XmlTextReader(SavePath))
            {
                advDoc.Load(reader);
                XmlNodeList _ngroups = advDoc.GetElementsByTagName("ID");
                foreach (XmlNode nd in _ngroups)
                {
                    arrID.Add(int.Parse(nd.InnerText.ToString()));
                    //arID.Add(int.Parse(nd.InnerText.ToString()));
                    
                }

            }
            //Get largest id
            var max = 0; var temp = 0;
            foreach (int value in arrID)
            {
                temp = value;
                if (max < temp)
                {
                    max = temp;
                }
            }

            //int lastID=int.Parse(arrID[arrID.Count-1].ToString());

            if (max == id)
            {
                return id+1;
            }
            if(max>id)
            {
                int newId = 0;
                for (int i = 1; i < max; i++)
                {
                    ++newId;
                    if (!arrID.Contains(i)) break;
                }
                return newId;
            }
            return 0;
           

        }
        private void AddRecords()
        {
            getZeroValue();
            XDocument doc = XDocument.Load(SavePath);
            
            int count = doc.Descendants("Hname").Count();   //10
            int pickId=GiveID(count);

            doc.Element("Guests").Add(
                new XElement("Guest",//new XAttribute("ID",count+1),
                    new XElement("ID",pickId),
                    new XElement("Hname", txtHname.Text),
                    new XElement("Wname", txtWname.Text),
                    new XElement("Address", txtAddress.Text.Trim()),
                    new XElement("KhmerCurrency", txtKCurrency.Text.Trim()),
                    new XElement("USACurrency", txtUCurrency.Text.Trim()),
                    new XElement("Description", txtDecription.Text.Trim()) ,
                    new XElement("RegisterDate",DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString())
                    
                    ));
            doc.Save(SavePath);
            
       }
        void ResetControl()
        {
            panelShow.Visible = false;
            txtHname.Clear();
            txtWname.Clear();
            txtAddress.Clear();
            txtKCurrency.Clear();
            txtUCurrency.Clear();
            txtDecription.Clear();
            txtHname.Focus();
        }


        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetControl();
            FileName = frmHome.UserForlderPath;
            SavePath = FileName + "\\Guest.xml";
            linkLabel1.Text= frmHome.UserForlderPath.Replace(FrmLogin1.UserFolderName + "\\", "");
            AutoCom_Adddress_xml();
            AutoCom_KCurrency_xml();
            AutoCom_UCurrency_xml();
            checkNullTextbox();
        }

        private void AutoCom_Adddress_xml()
        {
            try
            {
                string AutoCom = Directory.GetCurrentDirectory()+"\\AutoSuggest\\Address.xml";
                if (File.Exists(AutoCom))
                {
                    XDocument doc = XDocument.Load(AutoCom);
                    var source = new AutoCompleteStringCollection();

                    IEnumerable<string> names = from addresss in doc.Descendants("Address")
                                                select addresss.Element("name").Value;
                    int i = names.Count();
                    foreach (string str in names.Reverse())
                    {
                        source.Add(str);
                    }

                    txtAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtAddress.AutoCompleteCustomSource = source;

                }
                else
                {
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Eror Address");
            }
            
        }
        
        private void AutoCom_KCurrency_xml()
        {
            try
            {
                string AutoCom = Directory.GetCurrentDirectory() + "\\AutoSuggest\\KhmerCurrency.xml";

                if (File.Exists(AutoCom))
                {
                    XDocument doc = XDocument.Load(AutoCom);
                    var source = new AutoCompleteStringCollection();
                    IEnumerable<string> names = from addresss in doc.Descendants("Kcurrency")
                                                select addresss.Element("kprice").Value;
                    int i = names.Count();
                    foreach (string str in names.Reverse())
                    {
                        source.Add(str);
                    }

                    txtKCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtKCurrency.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtKCurrency.AutoCompleteCustomSource = source;

                }
                else
                {
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Error KhmerCurrency");
            }
        }
        private void AutoCom_UCurrency_xml()
        {
            try
            {
                string AutoCom = Directory.GetCurrentDirectory() + "\\AutoSuggest\\USACurrency.xml";
                if (File.Exists(AutoCom))
                {
                    var source = new AutoCompleteStringCollection();
                    XDocument doc = XDocument.Load(AutoCom);
                    IEnumerable<string> names = from addresss in doc.Descendants("Ucurrency")
                                                select addresss.Element("uprice").Value;
                    int i = names.Count();
                    foreach (string str in names.Reverse())
                    {
                        source.Add(str);
                    }

                    txtUCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtUCurrency.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtUCurrency.AutoCompleteCustomSource = source;

                }
                else
                {
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Error");
            }
        }



        /// <summary>
        /// //ប្រើButtonសម្រាប់បង្ហាញ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            frmShow f = new frmShow();
            
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            this.panelShow.Visible = true;
            this.panelShow.Controls.Add(f);
            f.Show();
            
           
            
            
        }

        private void checkNullTextbox()
        {
            if (string.IsNullOrEmpty(txtHname.Text) && string.IsNullOrEmpty(txtWname.Text))
            {
                button1.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtKCurrency.Text) && string.IsNullOrEmpty(txtUCurrency.Text))
            {
                button1.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtHname.Text) && string.IsNullOrEmpty(txtWname.Text) && string.IsNullOrEmpty(txtKCurrency.Text))
            {
                button1.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtHname.Text) && string.IsNullOrEmpty(txtWname.Text) && string.IsNullOrEmpty(txtUCurrency.Text))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void txtHname_TextChanged(object sender, EventArgs e)
        {
            checkNullTextbox();
        }

        private void txtWname_TextChanged(object sender, EventArgs e)
        {
            checkNullTextbox();
        }

        private void txtKCurrency_TextChanged(object sender, EventArgs e)
        {
            checkNullTextbox();
            if (System.Text.RegularExpressions.Regex.IsMatch(txtKCurrency.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
                txtKCurrency.Text = txtKCurrency.Text.Remove(txtKCurrency.Text.Length - 1);
            }
            else
            {
                if (string.IsNullOrEmpty(txtKCurrency.Text))
                {
                    label11.Text = "( )រៀល";
                    return;
                }

                if (txtKCurrency.Text != null)
                {
                    AcceptOnlyNumber(txtKCurrency);
                    label11.Text = "( " + NumberToWords(int.Parse(txtKCurrency.Text)) + " ) រៀល";
                }
            }


        }
        private void AcceptOnlyNumber(TextBox textBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }
        }

        private void txtUCurrency_TextChanged(object sender, EventArgs e)
        {

            checkNullTextbox();
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUCurrency.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
                txtUCurrency.Text = txtUCurrency.Text.Remove(txtUCurrency.Text.Length - 1);
            }
            else
            {
                if (string.IsNullOrEmpty(txtUCurrency.Text))
                {
                    label17.Text = "( )ដុល្លារ";
                    return;
                }
                if (txtUCurrency.Text != null)
                {
                    AcceptOnlyNumber(txtUCurrency);
                    label17.Text = "( " + NumberToWords(int.Parse(txtUCurrency.Text)) + " ) ដុល្លារ";
                }
            }
        }

        private void inputNumber(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch))
            {
                e.Handled = true;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = false;
            }

        }

        private void EnterKey(object sender, KeyEventArgs e)
        {
            checkNullTextbox();
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void getZeroValue()
        {
            if (string.IsNullOrEmpty(txtKCurrency.Text)) txtKCurrency.Text = "0";
            if (string.IsNullOrEmpty(txtUCurrency.Text)) txtUCurrency.Text = "0";
            if (string.IsNullOrEmpty(txtHname.Text)) txtHname.Text = "null";
            if (string.IsNullOrEmpty(txtWname.Text)) txtWname.Text = "null";
            if (string.IsNullOrEmpty(txtDecription.Text)) txtDecription.Text = "null";
        }

        private void Search(string ElementName)
        {
            ResetControl();

            string search = txtIDsearch.Text.Trim();
            
            try
            {
                using (var reader = new XmlTextReader(SavePath))
                {
                    XElement xelement = XElement.Load(reader);
                    var name = from nm in xelement.Elements("Guest")
                               where (string)nm.Element(ElementName) == search
                               select nm;

                    foreach (XElement xEle in name)
                    {
                        
                        string id=xEle.Element("ID").Value;
                        txtHname.Text = xEle.Element("Hname").Value;
                        txtWname.Text =  xEle.Element("Wname").Value ;
                        txtAddress.Text = xEle.Element("Address").Value;
                        txtKCurrency.Text = xEle.Element("KhmerCurrency").Value;
                        txtUCurrency.Text = xEle.Element("USACurrency").Value;
                        txtDecription.Text=xEle.Element("Description").Value;
                            

                    }
                    txtIDsearch.Focus();
                }
                ////https://www.dotnetcurry.com/linq/564/linq-to-xml-tutorials-examples
                
            }
            catch 
            {
                MessageBox.Show("មិនទាន់មានទិន្នន័យសូមបញ្ចូល");
            }
        }
        private bool checkID()
        {
            try
            {
                XmlDocument advDoc = new XmlDocument();

                using (var reader = new XmlTextReader(SavePath))
                {
                    advDoc.Load(reader);
                    XmlNodeList _ngroups = advDoc.GetElementsByTagName("ID");
                    foreach (XmlNode nd in _ngroups)
                    {
                        if (nd.InnerText.ToString() == txtIDsearch.Text)
                            return true;
                    }

                }
            }
            catch
            {
                MessageBox.Show("ពុំទាន់មានទិន្នន័យក្នុងហ្នឹងទេសូមបន្ថែម");
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update(textBox1.Text);
            button4.PerformClick();
        }
        private void Update(string ID)
        {
            

            if (File.Exists(SavePath))
            {

                    var xdoc = XDocument.Load(SavePath);
                    var tgt = xdoc.Root.Descendants("Guest").FirstOrDefault(x => x.Element("ID").Value == ID);

                    var Hname = tgt.Descendants("Hname").FirstOrDefault();
                    var Wname = tgt.Descendants("Wname").FirstOrDefault();
                    var Address = tgt.Descendants("Address").FirstOrDefault();
                    var Kcurrency = tgt.Descendants("KhmerCurrency").FirstOrDefault();
                    var Ucurrency = tgt.Descendants("USACurrency").FirstOrDefault();
                    var Description = tgt.Descendants("Description").FirstOrDefault();

                    Hname.Value = txtHname.Text;
                    Wname.Value = txtWname.Text;
                    Address.Value = txtAddress.Text;
                    Kcurrency.Value = txtKCurrency.Text;
                    Ucurrency.Value = txtUCurrency.Text;
                    Description.Value = txtDecription.Text;
                
                    

                    xdoc.Save(SavePath);
                    MessageBox.Show("Data Update!!");
                    txtIDsearch.Clear();
                    txtHname.Focus();
            }
            else
            {
                MessageBox.Show("NO Data");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkID() == true)
            {
                Search("ID");
                txtIDsearch.Focus();
                label8.Text = "រកឃើញ";
                textBox1.Text = txtIDsearch.Text;
                button1.Enabled = false;
            }
            else
            {
                txtHname.Clear();
                txtWname.Clear();
                txtAddress.Clear();
                txtKCurrency.Clear();
                txtUCurrency.Clear();
                txtDecription.Clear();
                label8.Text = "មិនឃើញ";
                txtIDsearch.Focus();
                textBox1.Text = "";
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //txtIDsearch.Clear();
        }

        private void txtIDsearch_TextChanged(object sender, EventArgs e)
        {
            //Search("ID");
            //textBox1.Text = txtIDsearch.Text;
            button4.PerformClick();

        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "សូន្យ";

            //if (number < 0)
            //  return "ដក " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " លាន ";
                number %= 1000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 10000) + " ម៉ឺន ";
                number %= 10000;
            }

            if ((number / 10000) > 0)
            {
                words += NumberToWords(number / 10000) + "ម៉ឺន";
                number %= 10000;
            }


            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " ពាន់ ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " រយ ";
                number %= 100;
            }

            if (number > 0)
            {
                // if (words != "")
                //   words += "and ";

                var unitsMap = new[] { "សូន្យ", "មួយ", "ពីរ", "បី", "បួន", "ប្រាំ", "ប្រាំមួយ", "ប្រាំពីរ", "ប្រាំបី", "ប្រាំបួន"/*, "ដប់"*/ };
                var tensMap = new[] { "សូន្យ", "ដប់", "ម្ភៃ", "សាមសិប", "សែសិប", "ហាសិប", "ហុកសិប", "ចិតសិប", "ប៉ែតសិប", "កៅសិប" };

                if (number < 10)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        }


    }
}
