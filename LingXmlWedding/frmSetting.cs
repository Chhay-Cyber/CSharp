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
using System.Xml.Linq;

namespace LinqXmlWedding
{
    public partial class frmSetting : Form
    {
      
        string AutoComA = Directory.GetCurrentDirectory()+"\\AutoSuggest\\Address.xml";
        string AutoComK = Directory.GetCurrentDirectory()+"\\AutoSuggest\\KhmerCurrency.xml";
        string AutoComU = Directory.GetCurrentDirectory()+"\\AutoSuggest\\USACurrency.xml";

        public frmSetting()
        {
            InitializeComponent();
            txtInstruction.ReadOnly = true;
            richTextBox1.ReadOnly = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (rdoAddress.Checked == true)
            {
                CreateAddressXml();
                
                addressToolStripMenuItem.PerformClick();

            }
            else if (rdoKCurrency.Checked == true)
            {
                CreateKCurrencyXml();
                khmerCurrencyToolStripMenuItem.PerformClick();
            }
            else if (rdoUCurrency.Checked == true)
            {
                CreateUCurrencyXml();
                uSACurrencyToolStripMenuItem.PerformClick();
            }
            else
            {
                return;
            }
            ResetControl();

        }
        /// <summary>
        /// Create Adress Xml
        /// </summary>
        private void CreateAddressXml()
        {
            if (!File.Exists(AutoComA))
            {
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("AddressS",
                    new XElement("Address",
                        new XElement("name", "PhnomPenh")
                    )));
                doc.Save(AutoComA);
            }
            else
            {
                XDocument doc = XDocument.Load(AutoComA);
                int count = doc.Descendants("name").Count();
                doc.Element("AddressS").Add(
                    new XElement("Address",
                        new XElement("name", textBox1.Text)
                ));
                doc.Save(AutoComA);
                MessageBox.Show("Successfull");

            }

        }  
        private void CreateUCurrencyXml()
        {
            if (!File.Exists(AutoComU))
            {
                XDocument doc3 = new XDocument(
                 new XDeclaration("1.0", "utf-8", "yes"),
                 new XElement("UCurrencys",
                 new XElement("Ucurrency",
                     new XElement("uprice", "0")
                 )));
                doc3.Save(AutoComU);
            }
            else
            {
                XDocument doc = XDocument.Load(AutoComU);
                int count = doc.Descendants("UCurrencys").Count();
                doc.Element("UCurrencys").Add(
                    new XElement("Ucurrency",
                        new XElement("uprice", textBox1.Text)
                ));
                doc.Save(AutoComU);
                MessageBox.Show("Successfull");
            }
        }
        private void CreateKCurrencyXml()
        {
            if (!File.Exists(AutoComK))
            {
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("KCurrencys",
                    new XElement("Kcurrency",
                        new XElement("kprice", "0")
                    )));
                doc.Save(AutoComK);
            }
            else
            {
                XDocument doc = XDocument.Load(AutoComK);
               // int count = doc.Descendants("KCurrencys").Count();
                doc.Element("KCurrencys").Add(
                    new XElement("Kcurrency",
                        new XElement("kprice", textBox1.Text)
                ));
                doc.Save(AutoComK);
                MessageBox.Show("Successfull");

            }
        }

        private void ResetControl()
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        /// <summary>
        /// Create 3 file xml Address KhmerCurrency USACurrency
        /// </summary>
        private void CreateFileXml()
        {
            if (!File.Exists(AutoComA))
            {
                XDocument doc1 = new XDocument(
                   new XDeclaration("1.0", "utf-8", "yes"),
                   new XElement("AddressS",
                   new XElement("Address",
                       new XElement("name", "PhnomPenh")
                   )));
                doc1.Save(AutoComA);
            }

            if (!File.Exists(AutoComK))
            {
                XDocument doc2 = new XDocument(
                 new XDeclaration("1.0", "utf-8", "yes"),
                 new XElement("KCurrencys",
                 new XElement("Kcurrency",
                     new XElement("kprice", "0")
                 )));
                doc2.Save(AutoComK);
            }
            if (!File.Exists(AutoComU)) 
            {
                XDocument doc3 = new XDocument(
                 new XDeclaration("1.0", "utf-8", "yes"),
                 new XElement("UCurrencys",
                 new XElement("Ucurrency",
                     new XElement("uprice", "0")
                 )));
                doc3.Save(AutoComU);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            DialogResult dr=MessageBox.Show("Create New File Setting? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                panel1.Enabled = true ;
                rdoAddress.Checked = true;
                CreateFileXml();
           }
            else
            {
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*
            Task<Image>.Factory.StartNew(() =>
            {
                return Bitmap.FromFile(@"D:\CSD-Year3\New folder\LinqXmlWedding\Resources\393_242px_150pi.png");
            }).ContinueWith(t =>
            {
                this.BackgroundImage = t.Result;
                // this.BackgroundImageLayout=
            }, TaskScheduler.FromCurrentSynchronizationContext());
            panel1.Enabled = false;
             */
            panel1.Enabled = false;
            this.BackColor = Color.AntiqueWhite;

        }
             

        //RadioButton CheckedChanged
        private void rdoAddress_CheckedChanged(object sender, EventArgs e)
        {
            txtInstruction.Clear();
            txtInstruction.Text = "សូមជួយបំពេញទីកន្លែង ម្ដងមួយៗ រួចចុចEnter ឬក៏ចុចប៊ូតុងAdd ក៏បាន";

        }
        private void rdoUCurrency_CheckedChanged(object sender, EventArgs e)
        {
            txtInstruction.Clear();
            txtInstruction.Text = "សូមជួយបំពេញលុយដុល្លារ ម្ដងមួយៗ រួចចុចEnter ឬក៏ចុចប៊ូតុងAdd ក៏បាន";
        }
        private void rdoKCurrency_CheckedChanged(object sender, EventArgs e)
        {
            txtInstruction.Clear();
            txtInstruction.Text = "សូមជួយបំពេញលុយខ្មែរ ម្ដងមួយៗ រួចចុចEnter ឬក៏ចុចប៊ូតុងAdd ក៏បាន";
        }

        //Key Enter
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private void ReadComplete(string Path,string descend,string elemen)
        {
            try
            {
                XDocument doc = XDocument.Load(Path);
                if (File.Exists(Path))
                {
                    IEnumerable<string> names = from addresss in doc.Descendants(descend)
                                                select addresss.Element(elemen).Value;
                    int i = names.Count();
                    foreach (string str in names.Reverse())
                    {
                        richTextBox1.Text += " " + i + "\t" + str + Environment.NewLine; i--;
                    }
                }
                else
                {
                    MessageBox.Show("No Data");
                }
            }
            catch 
            {
                MessageBox.Show("Error");
            }
        }

        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            ReadComplete(AutoComA, "Address", "name");
        }
        private void khmerCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            ReadComplete(AutoComK, "Kcurrency", "kprice");
        }
        private void uSACurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            ReadComplete(AutoComU,"Ucurrency","uprice");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (rdoKCurrency.Checked == true||rdoUCurrency.Checked==true)
            {
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
