using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqXmlWedding
{
    public partial class frmHome : Form
    {
        public static string XcommentString="";

        public string  UserFolder { get; set; }

        public static string UserForlderPath{get;set;}

        public string user;
        
        //private string UserForlderPath;
        public frmHome()
        {
            
            InitializeComponent();
           
        }
        private void CreateDirectory()
        {
            //string root = "..\\Demo";
            //string subdir = "..\\Demo\\Yellow";
            // If directory does not exist, create it. 
            if (!Directory.Exists(this.UserFolder))
            {
                Directory.CreateDirectory(UserFolder);
            }
            //debug\\Username
        }
        private void CreateDirectory(string Homony)
        {

            if (!Directory.Exists(this.UserFolder))
            {
                Directory.CreateDirectory(UserFolder);
            }
            
            // Create a sub directory
            string path = UserFolder + "\\" + Homony + "[" + DateTime.Today.ToShortDateString().Replace("/","")+ "]";
            if (!Directory.Exists(path))
            {
                UserForlderPath = path;
                Directory.CreateDirectory(path);
                MessageBox.Show("Ready");
            }
            else
            {
                UserForlderPath=path;
                
            }
        }
        Dictionary<string, string> thisUser = new Dictionary<string, string>();

        private void BindingCombox()
        {

            try
            {

                string currentPath = UserFolder;
                string[] folder = Directory.GetDirectories(currentPath);
                foreach (string f in folder)
                {
                    //richTextBox1.Text += f.Replace(currentPath+@"\","")+ " ";
                    thisUser[f.Replace(currentPath + @"\", "")] = f;
                }
                /*
                foreach (KeyValuePair<string, string> a in thisUser)
                {
                    richTextBox1.Text += a.Key + " : " + a.Value + Environment.NewLine;
                }*/
                

            }
            catch 
            {
                MessageBox.Show("dfsfs");
            }
            comboBox1.DataSource = thisUser.ToList();
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

            
        }
      
        private void frmHome_Load(object sender, EventArgs e)
        {

            clearHomePanel();
            UserFolder = FrmLogin1.UserFolderName;
            user = UserFolder.Replace(Directory.GetCurrentDirectory() + @"\", "");
            CreateDirectory();
            label6.Text += "["+DateTime.Today.ToShortDateString()+@"]  ដែលខ្ទង់ទីដំបូងជាខែ ខ្ទង់ទី២ជាថ្ងៃ និង៤ខ្ទង់ក្រោយជាឆ្នាំ";
            label7.Text = @"អ្នកប្រើប្រាស់អាចបញ្ចូលជាអក្សរខ្មែរក៏បាន អង់គ្លេសក៏បានចំពោះឈ្មោះកម្មវិធី ប៉ុន្តែមិនអាច";// @"បញ្ចូលជានិមិត្តសញ្ញាពិសេសបានទេ[*,/,#,^,...]";
            lbUser.Text = user;
            
            /*
            string imagePath=@"D:\CSD-Year3\Icon\user_gear_thin_icon_171443.png";
           
            Task<Image>.Factory.StartNew(() =>
            {
                return Bitmap.FromFile(imagePath);
            }).ContinueWith(t =>
            {
                //this.BackgroundImage = t.Result;
                //this.pictureBox1.Image = t.Result;
                

            }, TaskScheduler.FromCurrentSynchronizationContext());
           
            */


        }
   

        public string getDetailWedding()
        {

            return grbTxtBroom.Text.Trim() + " , " + grbTxtGroom.Text.Trim() + " , " + TxtDate.Text.Trim();
        }
        public string getDetailBon()
        {
            return grbTxtMale.Text.Trim()+" : "+grbTxtMaleAge.Text.Trim()+"  ,  "+grbTxtFemale.Text.Trim()+" : "+ grbTxtFemaleAge.Text.Trim()+ "   Date : "+TxtDate.Text.Trim();
        }

        
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (rdoWedding.Checked == true)
            {
                XcommentString = getDetailWedding();
            }
            else if (rdoBon.Checked == true)
            {
                XcommentString = getDetailBon();
            }






            this.panelHome.Controls.Clear();

            CreateDirectory(txtNameHomony.Text.Trim());

            frmCreate myForm = new frmCreate();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            this.panelHome.Controls.Add(myForm);
            myForm.Show();
            panelCreate.Visible = false;

            
        }

        private void btnSettingAutoCom_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSetting f = new frmSetting();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin1 f = new FrmLogin1();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public string loginFile = Directory.GetCurrentDirectory()+"\\Information\\loginfile.xml";
      
        private void button5_Click(object sender, EventArgs e)
        {
            var xdoc = new XDocument();
           xdoc = XDocument.Load(loginFile);
                    var tgt = xdoc.Root.Descendants("User").FirstOrDefault(x => x.Element("Username").Value == user);
                    tgt.Remove();
                    xdoc.Save(loginFile);
                    try
                    {
                        
                        Directory.Delete(UserFolder,true);
                        MessageBox.Show("Aready");
                        FrmLogin1 f = new FrmLogin1();
                        f.Show();

                        this.Close();
                        
                        
                    }
                    catch 
                    {
                        MessageBox.Show("Can't find directory");
                    }
                    
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserForlderPath = UserFolder +"\\" + comboBox1.Text;
               // richTextBox1.Text = UserForlderPath;


                
            panelShowData.Visible = false;  
                frmShow myForm = new frmShow();
                myForm.TopLevel = false;
                this.panelHome.Controls.Add(myForm);
                 myForm.AutoScroll = true;
                myForm.Dock = DockStyle.Fill;
                myForm.Show();
                

                
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label6.Text = comboBox1.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelHome.Controls.Add(panelCreate);
            panelHome.Enabled = true;
        }
        List<PictureBox> lp = new List<PictureBox>();
        private void getAllPicture()
        {
            lp.Add(pictureBoxWrite);
            lp.Add(pictureBoxInviter);
            lp.Add(pictureBoxPaid);
            lp.Add(pictureBoxReport);
            lp.Add(pictureBoxSetting);
            lp.Add(pictureBoxShow);
        }
        private void doTranspant(PictureBox p)
        {
            lp.Remove(p);
            foreach (PictureBox x in lp)
            {
                x.BackColor = Color.Transparent;
            }
        }

        private bool ignoreEvents = false;
        private void makeLikeRadio(object sender, EventArgs e)
        {
            if (!ignoreEvents)
            {
                ignoreEvents = true; // otherwise the other checkboxes would react when i set the state programmatically
                CheckBox current = sender as CheckBox;
               
                if (current == checkBox1)
                {
                    clearHomePanel();//Make sure that all panel is Clear
                    lp.Clear();
                    getAllPicture();
                    this.doTranspant(pictureBoxWrite);
                    pictureBoxWrite.BackColor = Color.AntiqueWhite;
                    checkBox1.Enabled = false;
                    
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                    checkBox5.Enabled = true;
                    checkBox6.Enabled = true;

                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    panelHome.Controls.Add(panelCreate);
                    
                    panelCreate.Visible = true;
                    panelCreate.Focus();
                    panelShowData.Visible = false;

                 
                  
                }
                else if (current == checkBox2)
                {
                    lp.Clear();
                    getAllPicture();
                    this.doTranspant(pictureBoxShow);
                    pictureBoxShow.BackColor = Color.AntiqueWhite;
               
                    
                    clearHomePanel();

                    checkBox2.Enabled = false;
                    
                    checkBox1.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                    checkBox5.Enabled = true;
                    checkBox6.Enabled = true;

                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    BindingCombox();
                    
                    panelHome.Controls.Add(panelShowData);
                    panelCreate.Visible = false;
                    panelShowData.Visible = true;
                    if (comboBox1.Text.Equals(""))
                    {
                        btnWatch.Enabled = false;
                    }
                    else
                    {
                        btnWatch.Enabled = true;
                    }
                }
                else if (current == checkBox3)
                {
                    clearHomePanel();
                    lp.Clear();
                    getAllPicture();
                    this.doTranspant(pictureBoxPaid);
                    pictureBoxPaid.BackColor = Color.AntiqueWhite;

                    checkBox3.Enabled = false;

                    checkBox2.Enabled = true;
                    checkBox1.Enabled = true;
                    checkBox4.Enabled = true;
                    checkBox5.Enabled = true;
                    checkBox6.Enabled = true;

                    checkBox2.Checked = false;
                    checkBox1.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;

                    //pictureBoxPaid.BackColor=
                    frmPaidAmount f = new frmPaidAmount();
                    f.TopLevel = false;
                    f.AutoScroll = false;
                   this.panelHome.Controls.Add(f);
                   f.Show();




                }
                else if (current == checkBox4)
                {
                    clearHomePanel();
                    lp.Clear();
                    getAllPicture();
                    this.doTranspant(pictureBoxSetting);
                    pictureBoxSetting.BackColor = Color.AntiqueWhite;
                    

                    checkBox4.Enabled = false;

                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox1.Enabled = true;
                    checkBox5.Enabled = true;
                    checkBox6.Enabled = true;

                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox1.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                  

                    frmSetting myForm = new frmSetting();                    
                    myForm.TopLevel = false;
                    myForm.AutoScroll = false;
                    this.panelHome.Controls.Add(myForm);
                    myForm.Show();

                    panelCreate.Visible = false;
                    panelShowData.Visible = false;
                }
                else if (current == checkBox5)
                {
                    clearHomePanel();

                    lp.Clear();
                    getAllPicture();
                    this.doTranspant(pictureBoxInviter);
                    pictureBoxInviter.BackColor = Color.AntiqueWhite;

                    checkBox5.Enabled = false;

                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                    checkBox1.Enabled = true;
                    checkBox6.Enabled = true;

                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox1.Checked = false;
                    checkBox6.Checked = false;

                    frmKeHave myForm =new frmKeHave();
                    myForm.TopLevel = false;
                    myForm.AutoScroll = false;
                    this.panelHome.Controls.Add(myForm);
                    myForm.Show();
                    panelCreate.Visible = false;



                }
                else
                {
                    clearHomePanel();
                    
                    lp.Clear();
                    getAllPicture();
                    this.doTranspant(pictureBoxReport);
                    pictureBoxReport.BackColor = Color.AntiqueWhite;
                    checkBox6.Enabled = false;

                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                    checkBox5.Enabled = true;
                    checkBox1.Enabled = true;

                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox1.Checked = false;
                }
                ignoreEvents = false;
            }
        }

        private void clearHomePanel()
        {

            this.panelHome.Controls.Clear();

        }
        private void keyDown(CheckBox cb)
        {
            cb.Checked = true;
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = true;
                
            }
            else
            {
                checkBox1.Checked = false;
            }
        }
       
        static int i = 0;
        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            i++;
            if (i % 2 == 1)
            {
                groupBox1.Visible = true;

            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdoWedding_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWedding.Checked == true)
            {
                TxtDate.Visible = true;
                grbCreateWedding.Visible = true;
            }
            else
            {
                TxtDate.Visible = false;
                grbCreateWedding.Visible = false;
            }
        }

        private void rdoBon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBon.Checked == true)
            {
                TxtDate.Visible = true;
                grbCreateBon.Visible = true;
                grbCreateBon.Location = new Point(284, 115);
            }
            else
            {
                TxtDate.Visible = false;
                grbCreateBon.Visible = false;
            }
        }
        private void rdoBirthday_CheckedChanged(object sender, EventArgs e)
        {
            TxtDate.Visible = false;
            if (rdoBirthday.Checked)
            {
                grbCreateEmpty.Visible = true;
                grbCreateEmpty.Location = new Point(284, 115);
            }
            else
            {
                grbCreateEmpty.Visible = false;
            }
            
            
        }
        private void rdoHome_CheckedChanged(object sender, EventArgs e)
        {
            TxtDate.Visible = false;
            if (rdoHome.Checked)
            {
                grbCreateEmpty.Visible = true;
                grbCreateEmpty.Location = new Point(284, 115);
            }
            else
            {
                grbCreateEmpty.Visible = false;
            }
        }

        private void rdoAny_CheckedChanged(object sender, EventArgs e)
        {
            TxtDate.Visible = false;
            if (rdoAny.Checked)
            {
                grbCreateEmpty.Visible = true;
                grbCreateEmpty.Location = new Point(284, 115);
            }
            else
            {
                grbCreateEmpty.Visible = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Validate(TextBox textBox1)
        {
            Regex rx = new Regex("[^A-Z|^a-z|^ |^\t]");
            if (rx.IsMatch(textBox1.Text))
            {
                MessageBox.Show("សូមបញ្ចូលជាអក្សរ");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.Select(textBox1.Text.Length, 0);
                //textBox1.Clear();
            }
            
        }

        private void txtNameHomony_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                    Char.IsSeparator(e.KeyChar) ||
                    Char.IsSymbol(e.KeyChar);
        }

      

        
        
    }
}
