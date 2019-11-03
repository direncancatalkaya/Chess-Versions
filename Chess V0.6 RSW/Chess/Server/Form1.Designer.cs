namespace Server
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
            this.lbx_Logs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbx_Userlist = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbx_Logs
            // 
            this.lbx_Logs.FormattingEnabled = true;
            this.lbx_Logs.Location = new System.Drawing.Point(12, 51);
            this.lbx_Logs.Name = "lbx_Logs";
            this.lbx_Logs.Size = new System.Drawing.Size(524, 277);
            this.lbx_Logs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log Listesi :";
            // 
            // lbx_Userlist
            // 
            this.lbx_Userlist.FormattingEnabled = true;
            this.lbx_Userlist.Location = new System.Drawing.Point(584, 51);
            this.lbx_Userlist.Name = "lbx_Userlist";
            this.lbx_Userlist.Size = new System.Drawing.Size(194, 277);
            this.lbx_Userlist.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bağlı Kullanıcılar :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbx_Userlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbx_Logs);
            this.Name = "Form1";
            this.Text = "Chess Server v0.6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_Logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbx_Userlist;
        private System.Windows.Forms.Label label2;
    }
}

