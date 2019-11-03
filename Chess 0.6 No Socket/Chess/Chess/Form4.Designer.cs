namespace Chess
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.cmb_renk = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_tastipi = new System.Windows.Forms.ComboBox();
            this.txt_tahta_y = new System.Windows.Forms.TextBox();
            this.txt_tahta_x = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cmb_renk);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmb_tastipi);
            this.panel1.Controls.Add(this.txt_tahta_y);
            this.panel1.Controls.Add(this.txt_tahta_x);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(713, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 290);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sol taraftan Kare Seçip Ekleme Yapabilirsiniz ..";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(223, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Yeni Oyun Başlat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmb_renk
            // 
            this.cmb_renk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_renk.FormattingEnabled = true;
            this.cmb_renk.Items.AddRange(new object[] {
            "Siyah",
            "Beyaz"});
            this.cmb_renk.Location = new System.Drawing.Point(121, 158);
            this.cmb_renk.Name = "cmb_renk";
            this.cmb_renk.Size = new System.Drawing.Size(121, 21);
            this.cmb_renk.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Renk";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Taş Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cmb_tastipi
            // 
            this.cmb_tastipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tastipi.FormattingEnabled = true;
            this.cmb_tastipi.Location = new System.Drawing.Point(121, 124);
            this.cmb_tastipi.Name = "cmb_tastipi";
            this.cmb_tastipi.Size = new System.Drawing.Size(121, 21);
            this.cmb_tastipi.TabIndex = 5;
            // 
            // txt_tahta_y
            // 
            this.txt_tahta_y.Location = new System.Drawing.Point(121, 85);
            this.txt_tahta_y.Name = "txt_tahta_y";
            this.txt_tahta_y.Size = new System.Drawing.Size(121, 20);
            this.txt_tahta_y.TabIndex = 4;
            this.txt_tahta_y.Text = "0";
            // 
            // txt_tahta_x
            // 
            this.txt_tahta_x.Location = new System.Drawing.Point(121, 51);
            this.txt_tahta_x.Name = "txt_tahta_x";
            this.txt_tahta_x.Size = new System.Drawing.Size(121, 20);
            this.txt_tahta_x.TabIndex = 3;
            this.txt_tahta_x.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Taş Tipi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_tastipi;
        private System.Windows.Forms.TextBox txt_tahta_y;
        private System.Windows.Forms.TextBox txt_tahta_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_renk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
    }
}

