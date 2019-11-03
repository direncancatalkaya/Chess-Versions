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
            this.lbx_gamelist = new System.Windows.Forms.ListBox();
            this.btn_newgame = new System.Windows.Forms.Button();
            this.btn_Alone = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbx_gamelist
            // 
            this.lbx_gamelist.FormattingEnabled = true;
            this.lbx_gamelist.Location = new System.Drawing.Point(24, 49);
            this.lbx_gamelist.Name = "lbx_gamelist";
            this.lbx_gamelist.Size = new System.Drawing.Size(609, 173);
            this.lbx_gamelist.TabIndex = 0;
            this.lbx_gamelist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // btn_newgame
            // 
            this.btn_newgame.Location = new System.Drawing.Point(669, 49);
            this.btn_newgame.Name = "btn_newgame";
            this.btn_newgame.Size = new System.Drawing.Size(75, 51);
            this.btn_newgame.TabIndex = 1;
            this.btn_newgame.Text = "Yeni Oyun";
            this.btn_newgame.UseVisualStyleBackColor = true;
            this.btn_newgame.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Alone
            // 
            this.btn_Alone.Location = new System.Drawing.Point(669, 171);
            this.btn_Alone.Name = "btn_Alone";
            this.btn_Alone.Size = new System.Drawing.Size(75, 51);
            this.btn_Alone.TabIndex = 2;
            this.btn_Alone.Text = "Tek Pc\'den Oyna";
            this.btn_Alone.UseVisualStyleBackColor = true;
            this.btn_Alone.Click += new System.EventHandler(this.btn_Alone_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(669, 110);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 51);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Listeyi Yenile";
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Oyunlar :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 260);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_Alone);
            this.Controls.Add(this.btn_newgame);
            this.Controls.Add(this.lbx_gamelist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chess v0.6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_gamelist;
        private System.Windows.Forms.Button btn_newgame;
        private System.Windows.Forms.Button btn_Alone;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label label1;
    }
}