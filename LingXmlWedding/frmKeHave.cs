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
    public partial class frmKeHave : Form
    {
        public string SavePath;
       // public static string savePathInvister;
        public frmKeHave()
        {
            InitializeComponent();
        }
        private void frmKeHave_Load(object sender, EventArgs e)
        {
            SavePath = FrmLogin1.UserFolderName+"\\Invister.xml";
            grbWrite.Visible = true;
            grbShow.Visible = false;
        }

        private string  getmyType()
        {
            if (radioButton1.Checked) return radioButton1.Text;
            else if (radioButton2.Checked) return radioButton2.Text;
            else if (radioButton3.Checked) return radioButton3.Text;
            else if (radioButton4.Checked) return radioButton4.Text;
            else if (radioButton5.Checked) return radioButton5.Text;
            else
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getZeroValue();

            if (!File.Exists(SavePath))
            {

                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Inviters",
                    new XElement("Inviter",// new XAttribute("ID", 1),
                        new XElement("ID", 1),
                        new XElement("MInviter", txtKehaveMale.Text),
                        new XElement("FInviter", txtKehaveFemale.Text),                     
                        new XElement("USACurrency", txtUsaCurrency.Text.Trim()),
                        new XElement("KhmerCurrency", txtKhmerCurrency.Text.Trim()),
                        new XElement("Date",dateTimePicker1.Value.ToString()),
                        new XElement("Type",getmyType()),
                        new XElement("Description", txtDescription.Text.Trim())
                       
                        )));
                doc.Save(SavePath);

                ResetControl();
                MessageBox.Show("Success");
            }
            else
            {
                AddRecords();
                MessageBox.Show("Successfull");
               // txtIDsearch.Clear();
            }
            ResetControl();
        }
        private void AddRecords()
        {
            getZeroValue();
            XDocument doc = XDocument.Load(SavePath);

            int count = doc.Descendants("KhmerCurrency").Count();   //10
            int pickId = GiveID(count);

            doc.Element("Inviters").Add(
                new XElement("Inviter",//new XAttribute("ID",count+1),
                    new XElement("ID", pickId),
                   
                        new XElement("MInviter", txtKehaveMale.Text),
                        new XElement("FInviter", txtKehaveFemale.Text),
                        new XElement("USACurrency", txtUsaCurrency.Text.Trim()),
                        new XElement("KhmerCurrency", txtKhmerCurrency.Text.Trim()),
                        new XElement("Date", dateTimePicker1.Value.ToString()),
                        new XElement("Type", getmyType()),
                        new XElement("Description", txtDescription.Text.Trim())

                    ));
            doc.Save(SavePath);

        }
        private void getZeroValue()
        {
            if (string.IsNullOrEmpty(txtKhmerCurrency.Text)) txtKhmerCurrency.Text = "0";

            if (string.IsNullOrEmpty(txtUsaCurrency.Text)) txtUsaCurrency.Text = "0";
            if (string.IsNullOrEmpty(txtKehaveMale.Text)) txtKehaveMale.Text = "null";
            if (string.IsNullOrEmpty(txtKehaveFemale.Text)) txtKehaveFemale.Text = "null";
            if (string.IsNullOrEmpty(txtDescription.Text)) txtDescription.Text = "null";
            if (string.IsNullOrEmpty(txtContact.Text)) txtContact.Text = "null";
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
                return id + 1;
            }
            if (max > id)
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
       
        void ResetControl()
        {
            txtKehaveMale.Text = "";
            txtKehaveFemale.Text = "";

            txtDescription.Text = "";
            txtContact.Text = "";
            txtKhmerCurrency.Text = "";
            txtUsaCurrency.Text = "";
        }
        private void BindingGunaGridView()
        {
            
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(SavePath);

                guna2DataGridView1.DataSource = dataSet.Tables[0];
               

                guna2DataGridView1.Columns["ID"].ReadOnly = true;
                guna2DataGridView1.Columns[0].Width = 50;
               
            }
            catch 
            {
                MessageBox.Show("អ្នកមិនទាន់មានបានបញ្ចូល អោយមានទិន្នន័យទេ");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BindingGunaGridView();
            grbWrite.Visible = false;
            grbShow.Visible = true;
        }

        private void txtKhmerCurrency_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtKhmerCurrency.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
                txtKhmerCurrency.Text = txtKhmerCurrency.Text.Remove(txtKhmerCurrency.Text.Length - 1);
            }

        }

        private void txtUsaCurrency_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUsaCurrency.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
                txtUsaCurrency.Text = txtUsaCurrency.Text.Remove(txtUsaCurrency.Text.Length - 1);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
               Search("ID");
            if (rdoIDSearch.Checked == true)
            {

                Search("ID");
            }
            else if (rdoHnameMale.Checked == true)
            {
                Search("MInviter");
            }
            else if (rdoFemale.Checked == true)
            {
                Search("FInviter");
            }
            else
                return;
        
        }
        
        List<InviterSearch> lSearch = new List<InviterSearch>();
        private void Search(string ElementName)
        {

            lSearch.Clear();
            string search = txtIDsearch.Text.Trim();
            try
            {
                using (var reader = new XmlTextReader(SavePath))
                {
                    XElement xelement = XElement.Load(reader);
                    var name = from nm in xelement.Elements("Inviter")
                               where ((string)nm.Element(ElementName).Value).Contains(search)
                               select nm;

                    foreach (XElement xEle in name)
                    {

                        // string str = xEle.Element("ID").Value + "\t\t" + xEle.Element("Hname").Value + "\t" + xEle.Element("Wname").Value + "\t\t" + xEle.Element("Address").Value + "\t\t" + xEle.Element("KhmerCurrency").Value + "\t\t\t" + xEle.Element("USACurrency").Value + "\t\t" + xEle.Element("Description").Value;
                        // richTextBox1.Text += str + Environment.NewLine;
                        lSearch.Add(new InviterSearch(xEle.Element("ID").Value, xEle.Element("MInviter").Value, xEle.Element("FInviter").Value, xEle.Element("USACurrency").Value, xEle.Element("KhmerCurrency").Value, xEle.Element("Date").Value, xEle.Element("Type").Value,xEle.Element("Description").Value));

                    }

                    BindingSource binding = new BindingSource();
                    binding.DataSource = lSearch;
                    guna2DataGridView1.DataSource = binding;



                }
                ////https://www.dotnetcurry.com/linq/564/linq-to-xml-tutorials-examples
                int a = CountByElements(ElementName);

                labelResult.Text = "Not Found (" + a + ")";

            }
            catch 
            {
                MessageBox.Show("Error");
            }

        }
        private int CountByElements(string ElementName)
        {

            XElement xelement = XElement.Load(SavePath);
            var stCnt = from address in xelement.Elements("MInviter")
                        where ((string)address.Element(ElementName).Value) ==txtIDsearch.Text
                        select address;
            //Console.WriteLine("No of Employees living in CA State are {0}", stCnt.Count());
            int a = stCnt.Count();
            return a;

        }


       
        
    }
}
