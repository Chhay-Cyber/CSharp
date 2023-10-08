namespace LinqXmlWedding
{
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUCurrency = new System.Windows.Forms.RadioButton();
            this.rdoKCurrency = new System.Windows.Forms.RadioButton();
            this.rdoAddress = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInstruction = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khmerCurrencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSACurrencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUCurrency);
            this.groupBox1.Controls.Add(this.rdoKCurrency);
            this.groupBox1.Controls.Add(this.rdoAddress);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataInput";
            // 
            // rdoUCurrency
            // 
            this.rdoUCurrency.AutoSize = true;
            this.rdoUCurrency.Location = new System.Drawing.Point(292, 19);
            this.rdoUCurrency.Name = "rdoUCurrency";
            this.rdoUCurrency.Size = new System.Drawing.Size(114, 21);
            this.rdoUCurrency.TabIndex = 2;
            this.rdoUCurrency.TabStop = true;
            this.rdoUCurrency.Text = "USACurrency";
            this.rdoUCurrency.UseVisualStyleBackColor = true;
            this.rdoUCurrency.CheckedChanged += new System.EventHandler(this.rdoUCurrency_CheckedChanged);
            // 
            // rdoKCurrency
            // 
            this.rdoKCurrency.AutoSize = true;
            this.rdoKCurrency.Location = new System.Drawing.Point(140, 20);
            this.rdoKCurrency.Name = "rdoKCurrency";
            this.rdoKCurrency.Size = new System.Drawing.Size(127, 21);
            this.rdoKCurrency.TabIndex = 1;
            this.rdoKCurrency.TabStop = true;
            this.rdoKCurrency.Text = "KhmerCurrency";
            this.rdoKCurrency.UseVisualStyleBackColor = true;
            this.rdoKCurrency.CheckedChanged += new System.EventHandler(this.rdoKCurrency_CheckedChanged);
            // 
            // rdoAddress
            // 
            this.rdoAddress.AutoSize = true;
            this.rdoAddress.Location = new System.Drawing.Point(0, 21);
            this.rdoAddress.Name = "rdoAddress";
            this.rdoAddress.Size = new System.Drawing.Size(81, 21);
            this.rdoAddress.TabIndex = 0;
            this.rdoAddress.TabStop = true;
            this.rdoAddress.Text = "Address";
            this.rdoAddress.UseVisualStyleBackColor = true;
            this.rdoAddress.CheckedChanged += new System.EventHandler(this.rdoAddress_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(422, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(163, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(497, 426);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Location = new System.Drawing.Point(15, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(163, 39);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.Text = "បន្ថែមទិន្នន័យគម្រូ";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtInstruction);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(15, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 135);
            this.panel1.TabIndex = 5;
            // 
            // txtInstruction
            // 
            this.txtInstruction.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstruction.Location = new System.Drawing.Point(511, 7);
            this.txtInstruction.Multiline = true;
            this.txtInstruction.Name = "txtInstruction";
            this.txtInstruction.Size = new System.Drawing.Size(226, 112);
            this.txtInstruction.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(12, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 429);
            this.panel2.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressToolStripMenuItem,
            this.khmerCurrencyToolStripMenuItem,
            this.uSACurrencyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addressToolStripMenuItem
            // 
            this.addressToolStripMenuItem.Name = "addressToolStripMenuItem";
            this.addressToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.addressToolStripMenuItem.Text = "Address";
            this.addressToolStripMenuItem.Click += new System.EventHandler(this.addressToolStripMenuItem_Click);
            // 
            // khmerCurrencyToolStripMenuItem
            // 
            this.khmerCurrencyToolStripMenuItem.Name = "khmerCurrencyToolStripMenuItem";
            this.khmerCurrencyToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.khmerCurrencyToolStripMenuItem.Text = "KhmerCurrency";
            this.khmerCurrencyToolStripMenuItem.Click += new System.EventHandler(this.khmerCurrencyToolStripMenuItem_Click);
            // 
            // uSACurrencyToolStripMenuItem
            // 
            this.uSACurrencyToolStripMenuItem.Name = "uSACurrencyToolStripMenuItem";
            this.uSACurrencyToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.uSACurrencyToolStripMenuItem.Text = "USACurrency";
            this.uSACurrencyToolStripMenuItem.Click += new System.EventHandler(this.uSACurrencyToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(605, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "សម្គាល់៖ ចំពោះការបញ្ចូលទិន្នន័យគំរូដែលមានស្រាប់";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(540, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(593, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "១.ជ្រើសយក Address រួចវាយ\"ក\"ក្នុងប្រអប់ ដោយពុំដកឃ្លា រួចចុចEnter ឬ ប៊ូតុងAddក៏បាន";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(667, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "ថែមទាំងអាចបញ្ចូលទឹកប្រាក់គម្រូដែលអ្នកគិតថា ប្រើច្រើនដង";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "មើលទិន្នន័យគម្រូដែលមានស្រាប់";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(540, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "ឧទាហរណ៍៖ តាមរយៈអាសយដ្ឋានដែលភ្ញៀវរស់នៅភាគច្រើនឈ្មោះ \"ក\" ហើយម៉្យាងទៀតចំណងដៃភាគច្រើន" +
    "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(623, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "គឺ 50000រៀល ។";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(540, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(589, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "២.ជ្រើសយកKhmerCurrency រួចវាយជាលេខបារាំងក្នុងប្រអប់ ដោយពុំដកឃ្លា រួចចុចEnter ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(667, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "អ្នកអាចបញ្ចូលអាស័យដ្ឋានដែលមានការប្រើប្រាស់ញឹកញាប់";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1215, 690);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.Opacity = 0.25D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUCurrency;
        private System.Windows.Forms.RadioButton rdoKCurrency;
        private System.Windows.Forms.RadioButton rdoAddress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khmerCurrencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSACurrencyToolStripMenuItem;
        private System.Windows.Forms.TextBox txtInstruction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}