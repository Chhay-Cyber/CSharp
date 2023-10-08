
using ClosedXML.Excel;
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
using Excel = Microsoft.Office.Interop.Excel;
namespace LinqXmlWedding
{
    public partial class frmShow : Form
    {
        public static string savefilepath;
        public frmShow()
        {
         
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           BindingGunaGridView();

        }
 
        private void BindingGunaGridView()
        {
            //http://csharp.net-informations.com/xml/how-to-read-xml.htm
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(savefilepath);
               
                guna2DataGridView1.DataSource = dataSet.Tables[0];
                this.guna2DataGridView1.Columns[4].DefaultCellStyle.Format = "c";

                guna2DataGridView1.Columns["ID"].ReadOnly = true;
                guna2DataGridView1.Columns[0].Width = 70;
                guna2DataGridView1.Columns[1].HeaderText = "ឈ្មោះប្ដី";
                guna2DataGridView1.Columns[2].HeaderText = "ឈ្មោះប្រពន្ធ";
                guna2DataGridView1.Columns[3].HeaderText = "អាស័យដ្ឋាន";
                guna2DataGridView1.Columns[4].HeaderText = "លុយខ្មែរ";
                guna2DataGridView1.Columns[5].HeaderText = "លុយដុល្លារ";
                guna2DataGridView1.Columns[6].HeaderText = "បរិយាយ";
                guna2DataGridView1.Columns[7].HeaderText = "ម៉ោងកត់ត្រា";
                /*
                guna2DataGridView1.Columns[1].Width = 170;
                guna2DataGridView1.Columns[2].Width = 170;
                guna2DataGridView1.Columns[3].Width = 250;
                guna2DataGridView1.Columns[4].Width = 170;
                guna2DataGridView1.Columns[5].Width = 170;
                //guna2DataGridView1.Columns[6].Width = 170;
                guna2DataGridView1.Columns[6].Visible = false;
                //guna2DataGridView1.Columns[7].Visible = false;
                 */

                guna2DataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                /*
                using (var reader = new XmlTextReader("..\\Guest.xml"))
                {
                    XmlDataDocument xmldoc = new XmlDataDocument();
                    XmlNodeList xmlnode;
                    int i = 0;
                    xmldoc.Load(reader);
                    xmlnode = xmldoc.GetElementsByTagName("Guest");
                    richTextBox1.Text = header;
                    string STR = null;
                    for (i = 0; i <= xmlnode.Count - 1; i++)
                    {

                        STR = String.Format("{0,2}{1,25}{2,25}{3,25}{4,25}{5,25}{6,25}", xmlnode[i].ChildNodes.Item(0).InnerText.Trim(), xmlnode[i].ChildNodes.Item(1).InnerText.Trim(), xmlnode[i].ChildNodes.Item(2).InnerText.Trim(),
                              xmlnode[i].ChildNodes.Item(3).InnerText.Trim(), xmlnode[i].ChildNodes.Item(4).InnerText.Trim(),
                              xmlnode[i].ChildNodes.Item(5).InnerText.Trim(), xmlnode[i].ChildNodes.Item(6).InnerText.Trim());

                        richTextBox1.Text += STR + Environment.NewLine;
                    }
                };*/
            }
            catch
            {
                MessageBox.Show("អ្នកមិនទាន់មានបានបញ្ចូល អោយមានទិន្នន័យទេ");
            }

        }

        private void Sort(string TypeMoney, string Path)
        {
            DialogResult dr = MessageBox.Show("You Want to Sort", "Question", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {

                    using (var reader = new XmlTextReader(savefilepath))
                    {
                        XElement root = XElement.Load(savefilepath);
                        var orderedtabs = root.Elements("Guest")
                                              .OrderBy(xtab => (int)xtab.Element(TypeMoney))  //KhmerCurrency
                                              .ToArray();
                        root.RemoveAll();
                        foreach (XElement tab in orderedtabs)
                            root.Add(tab);

                        root.Save(Path);
                    }

                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(Path);
                    guna2DataGridView1.DataSource = dataSet.Tables[0];
                }
                catch 
                {
                    MessageBox.Show("....");
                }
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search("ID");
            if (chkID.Checked == true)
            {

                Search("ID");
            }
            else if (chkHname.Checked == true)
            {
                SearchLike("Hname",txtIDsearch.Text.Trim());
            }
            else if (chkWifeName.Checked == true)
            {
                SearchLike("Wname",txtIDsearch.Text.Trim());
            }
            else
                return;
        }
        //https://www.dotnetcurry.com/linq/564/linq-to-xml-tutorials-examples
        /*
        //បង្ហាញdataក្នុងxml 
         XElement xelement = XElement.Load("..\\..\\Employees.xml");
        IEnumerable<XElement> employees = xelement.Elements();
        Console.WriteLine("List of all Employee Names along with their ID:");
        foreach (var employee in employees)
        {
            Console.WriteLine("{0} has Employee ID {1}",
            employee.Element("Name").Value,
            employee.Element("EmpId").Value);
        }
         */

        List<SearchClass> lsearch = new List<SearchClass>();

        private void Search(string ElementName)
        {

            lsearch.Clear();
            string search = txtIDsearch.Text.Trim();
            try
            {
                using (var reader = new XmlTextReader(savefilepath))
                {
                    XElement xelement = XElement.Load(reader);
                    var name = from nm in xelement.Elements("Guest")
                               where ((string)nm.Element(ElementName).Value).Contains(search)
                               select nm;
                    
                    foreach (XElement xEle in name)
                    {

                        // string str = xEle.Element("ID").Value + "\t\t" + xEle.Element("Hname").Value + "\t" + xEle.Element("Wname").Value + "\t\t" + xEle.Element("Address").Value + "\t\t" + xEle.Element("KhmerCurrency").Value + "\t\t\t" + xEle.Element("USACurrency").Value + "\t\t" + xEle.Element("Description").Value;
                        // richTextBox1.Text += str + Environment.NewLine;
                        lsearch.Add(new SearchClass(xEle.Element("ID").Value, xEle.Element("Hname").Value, xEle.Element("Wname").Value, xEle.Element("Address").Value, xEle.Element("KhmerCurrency").Value, xEle.Element("USACurrency").Value, xEle.Element("Description").Value));

                    }

                    BindingSource binding = new BindingSource();
                    binding.DataSource = lsearch;
                    guna2DataGridView1.DataSource = binding;



                }
                ////https://www.dotnetcurry.com/linq/564/linq-to-xml-tutorials-examples
                int a = CountByElements(ElementName);
                if (a == 0)
                    label2.Text = "Not Found (" + a + ")";
                else
                    label2.Text = "Found (" + a + ")";

            }
            catch 
            {
                MessageBox.Show("Error");
            }
        }

        //ការរាប់តាម Count Elements
        //Find the Element Count based on a condition using LINQ to XML
        private int CountByElements(string ElementName)
        {

            XElement xelement = XElement.Load(savefilepath);
            var stCnt = from address in xelement.Elements("Guest")
                        where ((string)address.Element(ElementName).Value) == txtIDsearch.Text
                        select address;
            //Console.WriteLine("No of Employees living in CA State are {0}", stCnt.Count());
            int a = stCnt.Count();
            return a;

        }

        private bool ignoreEvents = false;
        private void CheckChangeRdo(object sender, EventArgs e)
        {
            if (!ignoreEvents)
            {
                ignoreEvents = true; // otherwise the other checkboxes would react when i set the state programmatically
                CheckBox current = sender as CheckBox;
                if (current == chkID)
                {
                    chkHname.Checked = false;
                    chkWifeName.Checked = false;
                    btnSearch.PerformClick();
                }
                else if (current == chkHname)
                {
                    chkWifeName.Checked = false;
                    chkID.Checked = false;
                    btnSearch.PerformClick();
                }
                else
                {
                    chkHname.Checked = false;
                    chkID.Checked = false;
                    btnSearch.PerformClick();
                }
                ignoreEvents = false;
            }
        }

        private void btnSortKCurrency_Click(object sender, EventArgs e)
        {
            string path = frmHome.UserForlderPath+"\\SortKhmerCurrency.xml";
            //frmHome.UserForlderPath=//debug//Username//..
            Sort("KhmerCurrency", path);

        }

        private void btnSortUCurrecy_Click(object sender, EventArgs e)
        {
            string pat = frmHome.UserForlderPath+"\\SortUSACurrency.xml";
            Sort("USACurrency", pat);

        }

        private void txtIDsearch_TextChanged(object sender, EventArgs e)
        {
            if (chkID.Checked == true)
            {
                Search("ID");
            }
            else if (chkHname.Checked == true)
            {
               // Search("Hname");
                this.SearchLike("Hname",txtIDsearch.Text.Trim());
            }
            else if (chkWifeName.Checked == true)
            {
                SearchLike("Wname",txtIDsearch.Text.Trim());
            }
            else return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var xdoc = new XDocument();
            if (File.Exists(savefilepath))
            {
                if (checkID() == true)
                {
                    xdoc = XDocument.Load(savefilepath);
                    var tgt = xdoc.Root.Descendants("Guest").FirstOrDefault(x => x.Element("ID").Value == txtIDdelete.Text);
                    tgt.Remove();
                    xdoc.Save(savefilepath);
                    MessageBox.Show("Aready");
                    txtIDdelete.Clear();
                    BindingGunaGridView();

                }
                else
                {
                    MessageBox.Show("Not Found");
                }

            }
            else
            {
                MessageBox.Show("Not Have Record");
            }


        }
        private void Delete()
        {

            var xdoc = new XDocument();
            if (File.Exists(savefilepath))
            {
                if (checkID() == true)
                {
                    xdoc = XDocument.Load(savefilepath);
                    var tgt = xdoc.Root.Descendants("Guest").FirstOrDefault(x => x.Element("ID").Value == txtIDdelete.Text);
                    tgt.Remove();
                    xdoc.Save(savefilepath);
                    MessageBox.Show("Aready");
                    txtIDdelete.Clear();


                }
                else
                {
                    MessageBox.Show("Not Found");
                }

            }
            else
            {
                MessageBox.Show("Not Have Record");
            }


        }
        private bool checkID()
        {
            XmlDocument advDoc = new XmlDocument();
            using (var reader = new XmlTextReader(savefilepath))
            {
                advDoc.Load(reader);
                XmlNodeList _ngroups = advDoc.GetElementsByTagName("ID");
                foreach (XmlNode nd in _ngroups)
                {
                    if (nd.InnerText.ToString() == txtIDdelete.Text)
                        return true;
                }

            }
            return false;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCreate f1 = new frmCreate();
            f1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            savefilepath = frmHome.UserForlderPath+"\\Guest.xml";
            label1.Text = frmHome.UserForlderPath;
            btnRefresh.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            //​​​​metroLabel1.Text = value;
            if (!string.IsNullOrEmpty(value))
            {
                Update(value);
            }
            else
            {
                MessageBox.Show("Not Have Data");
            }
        }
        private void Update(string ID)
        {


            if (File.Exists(savefilepath))
            {

                var xdoc = XDocument.Load(savefilepath);
                var tgt = xdoc.Root.Descendants("Guest").FirstOrDefault(x => x.Element("ID").Value == ID);

                var Hname = tgt.Descendants("Hname").FirstOrDefault();
                var Wname = tgt.Descendants("Wname").FirstOrDefault();
                var Address = tgt.Descendants("Address").FirstOrDefault();
                var Kcurrency = tgt.Descendants("KhmerCurrency").FirstOrDefault();
                var Ucurrency = tgt.Descendants("USACurrency").FirstOrDefault();
                var Description = tgt.Descendants("Description").FirstOrDefault();

                Hname.Value = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                Wname.Value = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                Address.Value = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
                Kcurrency.Value = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
                Ucurrency.Value = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
                Description.Value = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();

                xdoc.Save(savefilepath);
                MessageBox.Show("Data Update!!");
            }
            else
            {
                MessageBox.Show("NO Data");
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
        private void btnConvertExel_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                 dt= (DataTable)guna2DataGridView1.DataSource;
                

                //Exporting to Excel
                 string folderPath = frmHome.UserForlderPath ;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string timeSave = DateTime.Now.ToShortTimeString();
                timeSave = timeSave.Replace(':', '_');
                string name = FrmLogin1.UserFolderName;
                name=name.Replace(Directory.GetCurrentDirectory()+"\\","");

                string file = folderPath + "\\GuestExelភ្ញៀវ_"+name+ timeSave+ ".xlsx";
                try
                {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Guest");

                            wb.SaveAs(file);//
                            File.Copy(file, @"C:\Users\User\Desktop\ភ្ញៀវ_"+name+".xlsx",true);
                           

                            DialogResult dr = MessageBox.Show("File import to Exel Already \nDo u want to open ?", "File Import", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (dr == DialogResult.Yes)
                            {
                                openExelFile(file);

                            }
                        }
                   
                }
                catch
                {
                    MessageBox.Show("Not import To Exel Please Delete Old file Exel");
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            panelCreate.Visible = true;
            frmCreate f = new frmCreate();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelCreate.Controls.Add(f);           
            f.Show();
        }

        private void SearchLike(string ElementSearch,string sVal)
        {
            // LOAD XML DOCUMENT.
            lsearch.Clear();
            var xml_Doc = XDocument.Load(savefilepath);

            IEnumerable<XElement> search_date = null;
            search_date =
                (from xFi in xml_Doc.Descendants("Guest")
                 where xFi.Element(ElementSearch).Value.Contains(sVal)
                 select xFi
                );

            foreach (XElement xEle in search_date)
            {

                // string str = xEle.Element("ID").Value + "\t\t" + xEle.Element("Hname").Value + "\t" + xEle.Element("Wname").Value + "\t\t" + xEle.Element("Address").Value + "\t\t" + xEle.Element("KhmerCurrency").Value + "\t\t\t" + xEle.Element("USACurrency").Value + "\t\t" + xEle.Element("Description").Value;
                // richTextBox1.Text += str + Environment.NewLine;
                lsearch.Add(new SearchClass(xEle.Element("ID").Value, xEle.Element("Hname").Value, xEle.Element("Wname").Value, xEle.Element("Address").Value, xEle.Element("KhmerCurrency").Value, xEle.Element("USACurrency").Value, xEle.Element("Description").Value));

            }
            
            BindingSource binding = new BindingSource();
            binding.DataSource = lsearch;
            guna2DataGridView1.DataSource = binding;

            int a = lsearch.Count;
            if (a == 0)
                label2.Text = "Not Found";
            else
                label2.Text = "Found (" + a + ")";

        }

        private void txtIDdelete_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnTotal_Click(object sender, EventArgs e)
        {
            labelKhmerTotal.Text = Sum("KhmerCurrency").ToString() + " រៀល";
            labelUSATotal.Text = Sum("USACurrency").ToString() + " ដូល្លារ";
        }
        List<int> li = new List<int>();
        private double Sum(String ElementName)
        {
            double sum = 0;
            try
            {

                XmlDocument advDoc = new XmlDocument();

                using (var reader = new XmlTextReader(savefilepath))
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

    }



    
}
