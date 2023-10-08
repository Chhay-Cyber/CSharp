namespace LinqXmlWedding
{
    partial class frmPaidAmount
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaidType = new System.Windows.Forms.TextBox();
            this.txtPaidKhmer = new System.Windows.Forms.TextBox();
            this.txtPaidUSA = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaidContact = new System.Windows.Forms.TextBox();
            this.cboHomony = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUnready = new System.Windows.Forms.RadioButton();
            this.rdoAlready = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labelTotalKhmer = new System.Windows.Forms.Label();
            this.labelTotalUSA = new System.Windows.Forms.Label();
            this.btnTotal = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrintExel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(543, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(667, 680);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ជ្រើសរើសកម្មវិធី";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ឈ្មោះមុខចំណាយ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "ប្រាក់ចំណាយរៀល";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "ប្រាក់ចំណាយដូល្លារ";
            // 
            // txtPaidType
            // 
            this.txtPaidType.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidType.Location = new System.Drawing.Point(185, 147);
            this.txtPaidType.MaxLength = 60;
            this.txtPaidType.Name = "txtPaidType";
            this.txtPaidType.Size = new System.Drawing.Size(305, 33);
            this.txtPaidType.TabIndex = 1;
            this.txtPaidType.Leave += new System.EventHandler(this.txtPaidType_Leave);
            // 
            // txtPaidKhmer
            // 
            this.txtPaidKhmer.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidKhmer.Location = new System.Drawing.Point(185, 205);
            this.txtPaidKhmer.MaxLength = 60;
            this.txtPaidKhmer.Name = "txtPaidKhmer";
            this.txtPaidKhmer.Size = new System.Drawing.Size(305, 33);
            this.txtPaidKhmer.TabIndex = 2;
            this.txtPaidKhmer.TextChanged += new System.EventHandler(this.txtPaidKhmer_TextChanged);
            this.txtPaidKhmer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputNumber);
            // 
            // txtPaidUSA
            // 
            this.txtPaidUSA.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidUSA.Location = new System.Drawing.Point(185, 263);
            this.txtPaidUSA.MaxLength = 60;
            this.txtPaidUSA.Name = "txtPaidUSA";
            this.txtPaidUSA.Size = new System.Drawing.Size(305, 33);
            this.txtPaidUSA.TabIndex = 3;
            this.txtPaidUSA.TextChanged += new System.EventHandler(this.txtPaidUSA_TextChanged);
            this.txtPaidUSA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputNumber);
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrite.Location = new System.Drawing.Point(187, 473);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(167, 30);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "សរសេរចូល";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "ថ្ងៃបង់បា្រក់";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "លេខទូរសព្ទអ្នកទទួល";
            // 
            // txtPaidContact
            // 
            this.txtPaidContact.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidContact.Location = new System.Drawing.Point(187, 368);
            this.txtPaidContact.MaxLength = 100;
            this.txtPaidContact.Name = "txtPaidContact";
            this.txtPaidContact.Size = new System.Drawing.Size(305, 33);
            this.txtPaidContact.TabIndex = 5;
            // 
            // cboHomony
            // 
            this.cboHomony.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHomony.Font = new System.Drawing.Font("Hanuman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHomony.FormattingEnabled = true;
            this.cboHomony.Location = new System.Drawing.Point(185, 89);
            this.cboHomony.Name = "cboHomony";
            this.cboHomony.Size = new System.Drawing.Size(305, 30);
            this.cboHomony.TabIndex = 0;
            this.cboHomony.SelectedIndexChanged += new System.EventHandler(this.cboHomony_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(187, 321);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(305, 24);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUnready);
            this.groupBox1.Controls.Add(this.rdoAlready);
            this.groupBox1.Location = new System.Drawing.Point(40, 408);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rdoUnready
            // 
            this.rdoUnready.AutoSize = true;
            this.rdoUnready.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoUnready.Location = new System.Drawing.Point(257, 15);
            this.rdoUnready.Name = "rdoUnready";
            this.rdoUnready.Size = new System.Drawing.Size(104, 29);
            this.rdoUnready.TabIndex = 1;
            this.rdoUnready.Text = "មិនទាន់បង់";
            this.rdoUnready.UseVisualStyleBackColor = true;
            // 
            // rdoAlready
            // 
            this.rdoAlready.AutoSize = true;
            this.rdoAlready.Checked = true;
            this.rdoAlready.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAlready.Location = new System.Drawing.Point(32, 15);
            this.rdoAlready.Name = "rdoAlready";
            this.rdoAlready.Size = new System.Drawing.Size(97, 29);
            this.rdoAlready.TabIndex = 0;
            this.rdoAlready.TabStop = true;
            this.rdoAlready.Text = "បង់រួចរាល់";
            this.rdoAlready.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(419, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(71, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelTotalKhmer
            // 
            this.labelTotalKhmer.AutoSize = true;
            this.labelTotalKhmer.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalKhmer.Location = new System.Drawing.Point(229, 527);
            this.labelTotalKhmer.Name = "labelTotalKhmer";
            this.labelTotalKhmer.Size = new System.Drawing.Size(21, 25);
            this.labelTotalKhmer.TabIndex = 11;
            this.labelTotalKhmer.Text = "0";
            // 
            // labelTotalUSA
            // 
            this.labelTotalUSA.AutoSize = true;
            this.labelTotalUSA.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalUSA.Location = new System.Drawing.Point(229, 560);
            this.labelTotalUSA.Name = "labelTotalUSA";
            this.labelTotalUSA.Size = new System.Drawing.Size(21, 25);
            this.labelTotalUSA.TabIndex = 11;
            this.labelTotalUSA.Text = "0";
            // 
            // btnTotal
            // 
            this.btnTotal.Font = new System.Drawing.Font("Hanuman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotal.Location = new System.Drawing.Point(36, 527);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(75, 34);
            this.btnTotal.TabIndex = 12;
            this.btnTotal.Text = "សរុប";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kh Boeung", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 27);
            this.label7.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kh Boeung", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 27);
            this.label8.TabIndex = 14;
            // 
            // btnPrintExel
            // 
            this.btnPrintExel.Location = new System.Drawing.Point(419, 12);
            this.btnPrintExel.Name = "btnPrintExel";
            this.btnPrintExel.Size = new System.Drawing.Size(75, 23);
            this.btnPrintExel.TabIndex = 15;
            this.btnPrintExel.Text = "PrintExcel";
            this.btnPrintExel.UseVisualStyleBackColor = true;
            this.btnPrintExel.Click += new System.EventHandler(this.btnPrintExel_Click);
            // 
            // frmPaidAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1215, 690);
            this.Controls.Add(this.btnPrintExel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.labelTotalUSA);
            this.Controls.Add(this.labelTotalKhmer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cboHomony);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtPaidContact);
            this.Controls.Add(this.txtPaidUSA);
            this.Controls.Add(this.txtPaidKhmer);
            this.Controls.Add(this.txtPaidType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPaidAmount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaidAmount";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PaidAmount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaidType;
        private System.Windows.Forms.TextBox txtPaidKhmer;
        private System.Windows.Forms.TextBox txtPaidUSA;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaidContact;
        private System.Windows.Forms.ComboBox cboHomony;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUnready;
        private System.Windows.Forms.RadioButton rdoAlready;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label labelTotalKhmer;
        private System.Windows.Forms.Label labelTotalUSA;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrintExel;
    }
}