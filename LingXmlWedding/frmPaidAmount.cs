using ClosedXML.Excel;
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
using Excel = Microsoft.Office.Interop.Excel;
namespace LinqXmlWedding
{
    public partial class frmPaidAmount : Form
    {
        public static string  SavePath;
        ArrayList s = new ArrayList();
        public frmPaidAmount()
        {
            InitializeComponent();
            btnWrite.Enabled = false;
            txtPaidType.TextChanged += RefreshButton;
            txtPaidKhmer.TextChanged += RefreshButton;
            txtPaidUSA.TextChanged += RefreshButton;
            this.BindingCombox();            

            
        }
        private void RefreshButton(object sender,EventArgs e)
        {
            
             if(!string.IsNullOrEmpty(txtPaidKhmer.Text)&&(!string.IsNullOrEmpty(cboHomony.Text))&&!string.IsNullOrEmpty(txtPaidType.Text)){ btnWrite.Enabled=true;}
             else if(!(string.IsNullOrEmpty(txtPaidUSA.Text))&&!(string.IsNullOrEmpty(cboHomony.Text))&&!string.IsNullOrEmpty(txtPaidType.Text)) btnWrite.Enabled=true;
             else 
                 btnWrite.Enabled=false;


        }

        private void PaidAmount_Load(object sender, EventArgs e)
        {
            cboHomony.Focus();
            SavePath = FrmLogin1.UserFolderName + "//" + cboHomony.Text + "//" + cboHomony.Text + "_Paid.xml";
               
           btnRefresh.PerformClick();
                
            
        }

       //Work With write xml 
        private void getZeroValue()
        {
            if (string.IsNullOrEmpty(txtPaidUSA.Text)) txtPaidUSA.Text = "0";
            if (string.IsNullOrEmpty(txtPaidKhmer.Text)) txtPaidKhmer.Text = "0";
            if (string.IsNullOrEmpty(txtPaidContact.Text)) txtPaidContact.Text = "null";
            
        }
        private string getSelectRadio()
        {
            if (rdoAlready.Checked) return rdoAlready.Text;
            else if (rdoUnready.Checked) return rdoUnready.Text;
            else return "មិនបានបញ្ជាក់";
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            cboHomony.Focus();
            getZeroValue();

            if (!File.Exists(SavePath))
            {

                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Paid for "+cboHomony.Text),
                    new XElement("Paids",
                    new XElement("Paid",// new XAttribute("ID", 1),
                        new XElement("ID",1),
                        new XElement("PaidType", txtPaidType.Text),
                        new XElement("PaidKhmer", txtPaidKhmer.Text),
                        new XElement("PaidUSA", txtPaidUSA.Text.Trim()),
                        new XElement("PaidDate", dateTimePicker1.Value.ToShortDateString()),
                        new XElement("PaidContact", txtPaidContact.Text.Trim()),
                        new XElement("PaidVerify", getSelectRadio())
                        )));
                doc.Save(SavePath);

                ResetControl();
                MessageBox.Show("Success");
            }
            else
            {
                AddRecords();
                MessageBox.Show("Successfull");
                btnRefresh.PerformClick();
                
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
        private void AddRecords()
        {
            getZeroValue();
            XDocument doc = XDocument.Load(SavePath);

            int count = doc.Descendants("PaidType").Count();   //10
            int pickId = GiveID(count);

            doc.Element("Paids").Add(
               new XElement("Paid",// new XAttribute("ID", 1),
                        new XElement("ID", pickId),
                        new XElement("PaidType", txtPaidType.Text),
                        new XElement("PaidKhmer", txtPaidKhmer.Text),
                        new XElement("PaidUSA", txtPaidUSA.Text.Trim()),
                        new XElement("PaidDate", dateTimePicker1.Value.ToShortDateString()),
                        new XElement("PaidContact", txtPaidContact.Text.Trim()),
                        new XElement("PaidVerify", getSelectRadio())
                        ));
            doc.Save(SavePath);

        }
        void ResetControl()
        {
            //cboHomony.SelectedIndex=-1;
            txtPaidContact.Clear();
            txtPaidKhmer.Clear();
            txtPaidType.Clear();
            txtPaidUSA.Clear();
        }

        //End Work

        //Work With ComboBox
        private void cboHomony_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //dataGridView1.Refresh();
            SavePath = FrmLogin1.UserFolderName + "//" + cboHomony.Text + "//" + cboHomony.Text + "_Paid.xml";
            if (File.Exists(SavePath))
            {
                dataGridView1.Visible = true;
                this.BindingDataXmlGrideView(SavePath);
            }
            else if(!File.Exists(SavePath))
            {
                dataGridView1.Visible = false;
                MessageBox.Show("No Data");
                
            }
          
            
         }

        private void BindingDataXmlGrideView(string pathxml)
        {
            if (File.Exists(pathxml))
            {
                
                try
                {
                    DataSet ds = new DataSet();

                    ds.ReadXml(pathxml);
                    dataGridView1.DataSource = ds.Tables[0];
                    
                }
                catch
                {
                    MessageBox.Show("Have Some Error");
                }
            }
            
                
            
            
        }


        Dictionary<string, string> thisUser = new Dictionary<string, string>();
        

        /// <summary>
        /// Load Data in ComboBox
        /// </summary>
  
        
        private void BindingCombox()
        {
            
            try
            {

                string currentPath =FrmLogin1.UserFolderName;
                string[] folder = Directory.GetDirectories(currentPath);
                foreach (string f in folder)
                {
                   
                    thisUser[f.Replace(currentPath + @"\", "")] = f;
                   
                }
                
            }
            catch 
            {
                MessageBox.Show("dfsfs");
            }
            cboHomony.DataSource =thisUser.ToList();
            cboHomony.DisplayMember = "Key";
            cboHomony.ValueMember = "Value";


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //dataGridView1.Refresh();
            SavePath = FrmLogin1.UserFolderName + "//" + cboHomony.Text + "//" + cboHomony.Text + "_Paid.xml";
            if (File.Exists(SavePath))
            {
                dataGridView1.Visible = true;
                this.BindingDataXmlGrideView(SavePath);
            }
            else if (!File.Exists(SavePath))
            {
                dataGridView1.Visible = false;
                MessageBox.Show("No Data");

            }
        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            labelTotalKhmer.Text =  Sum("PaidKhmer").ToString()+" រៀល";
            labelTotalUSA.Text = Sum("PaidUSA").ToString()+" ដូល្លារ";
        }

        List<int> li = new List<int>();
        private double Sum(String ElementName)
        {
            double sum = 0;
            try
            {

                XmlDocument advDoc = new XmlDocument();

                using (var reader = new XmlTextReader(SavePath))
                {
                    advDoc.Load(reader);
                    XmlNodeList _ngroups = advDoc.GetElementsByTagName(ElementName);
                    foreach (XmlNode nd in _ngroups)
                    {
                        //li.Add(int.Parse(nd.InnerText));
                        sum += Double.Parse(nd.InnerText);
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Have Data");
            }
            return sum;
        }
        private void InputNumber(object sender, KeyPressEventArgs e)
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
        private void AcceptOnlyNumber(TextBox textBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }
        }

        private void txtPaidKhmer_TextChanged(object sender, EventArgs e)
        {
            AcceptOnlyNumber(txtPaidKhmer);
            if (!string.IsNullOrEmpty(txtPaidKhmer.Text))
            {

                label7.Text = NumberToWords(int.Parse(txtPaidKhmer.Text)) + " រៀល";
            }
            else
                return;
        }

        private void txtPaidUSA_TextChanged(object sender, EventArgs e)
        {
            AcceptOnlyNumber(txtPaidUSA);
            if (!string.IsNullOrEmpty(txtPaidKhmer.Text))
            {
                label8.Text = NumberToWords(int.Parse(txtPaidUSA.Text)) + " $";
            }
            else
                return;
        }

        private void txtPaidType_Leave(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
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

        private void btnPrintExel_Click(object sender, EventArgs e)
        {
             if (dataGridView1.Rows.Count > 0)
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                dt = (DataTable)dataGridView1.DataSource;


                //Exporting to Excel
                string fileSave = FrmLogin1.UserFolderName + "//" + cboHomony.Text +"_ចំណាយ"+".xlsx";
        
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "ចំណាយ");

                        wb.SaveAs(fileSave);//
                        File.Copy(fileSave, @"C:\Users\User\Desktop\ចំណាយ.xlsx", true);


                        DialogResult dr = MessageBox.Show("File import to Exel Already \nDo u want to open ?", "File Import", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            openExelFile(fileSave);

                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Not import To Exel Please Delete Old file Exel");
                }
             }
        }
        private void openExelFile(string fileExcel)
        {

            Excel.Application xlapp;
            Excel.Workbook xlworkbook;
            xlapp = new Excel.Application();

            xlworkbook = xlapp.Workbooks.Open(fileExcel, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            xlapp.Visible = true;
        }

    }
}
