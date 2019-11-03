namespace Chess
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_pcname = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_CreateGame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Remoteip = new System.Windows.Forms.TextBox();
            this.btn_JoinGame = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bilgisayar Adı :";
            // 
            // lbl_pcname
            // 
            this.lbl_pcname.AutoSize = true;
            this.lbl_pcname.Location = new System.Drawing.Point(100, 16);
            this.lbl_pcname.Name = "lbl_pcname";
            this.lbl_pcname.Size = new System.Drawing.Size(35, 13);
            this.lbl_pcname.TabIndex = 1;
            this.lbl_pcname.Text = "label2";
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(100, 45);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(35, 13);
            this.lbl_ip.TabIndex = 3;
            this.lbl_ip.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "İp adresi        :";
            // 
            // btn_CreateGame
            // 
            this.btn_CreateGame.Location = new System.Drawing.Point(11, 80);
            this.btn_CreateGame.Name = "btn_CreateGame";
            this.btn_CreateGame.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateGame.TabIndex = 4;
            this.btn_CreateGame.Text = "Oyun Kur";
            this.btn_CreateGame.UseVisualStyleBackColor = true;
            this.btn_CreateGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_CreateGame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_pcname);
            this.panel1.Controls.Add(this.lbl_ip);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 118);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_Remoteip);
            this.panel2.Controls.Add(this.btn_JoinGame);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 118);
            this.panel2.TabIndex = 7;
            // 
            // txt_Remoteip
            // 
            this.txt_Remoteip.Location = new System.Drawing.Point(88, 18);
            this.txt_Remoteip.Name = "txt_Remoteip";
            this.txt_Remoteip.Size = new System.Drawing.Size(100, 20);
            this.txt_Remoteip.TabIndex = 5;
            // 
            // btn_JoinGame
            // 
            this.btn_JoinGame.Location = new System.Drawing.Point(10, 55);
            this.btn_JoinGame.Name = "btn_JoinGame";
            this.btn_JoinGame.Size = new System.Drawing.Size(75, 23);
            this.btn_JoinGame.TabIndex = 4;
            this.btn_JoinGame.Text = "Oyuna Katıl";
            this.btn_JoinGame.UseVisualStyleBackColor = true;
            this.btn_JoinGame.Click += new System.EventHandler(this.btn_JoinGame_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "İp adresi        :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 295);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chess v0.6 Multiplayer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_pcname;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CreateGame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_Remoteip;
        private System.Windows.Forms.Button btn_JoinGame;
        private System.Windows.Forms.Label label6;
    }
}