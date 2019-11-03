namespace Chess
{
    partial class Form2
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
            this.rdb_kale = new System.Windows.Forms.RadioButton();
            this.rdb_fil = new System.Windows.Forms.RadioButton();
            this.rdb_at = new System.Windows.Forms.RadioButton();
            this.rdb_vezir = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdb_kale
            // 
            this.rdb_kale.AutoSize = true;
            this.rdb_kale.Location = new System.Drawing.Point(72, 117);
            this.rdb_kale.Name = "rdb_kale";
            this.rdb_kale.Size = new System.Drawing.Size(46, 17);
            this.rdb_kale.TabIndex = 0;
            this.rdb_kale.TabStop = true;
            this.rdb_kale.Text = "Kale";
            this.rdb_kale.UseVisualStyleBackColor = true;
            this.rdb_kale.CheckedChanged += new System.EventHandler(this.rdb_kale_CheckedChanged);
            // 
            // rdb_fil
            // 
            this.rdb_fil.AutoSize = true;
            this.rdb_fil.Location = new System.Drawing.Point(150, 75);
            this.rdb_fil.Name = "rdb_fil";
            this.rdb_fil.Size = new System.Drawing.Size(35, 17);
            this.rdb_fil.TabIndex = 1;
            this.rdb_fil.TabStop = true;
            this.rdb_fil.Text = "Fil";
            this.rdb_fil.UseVisualStyleBackColor = true;
            this.rdb_fil.CheckedChanged += new System.EventHandler(this.rdb_fil_CheckedChanged);
            // 
            // rdb_at
            // 
            this.rdb_at.AutoSize = true;
            this.rdb_at.Location = new System.Drawing.Point(150, 117);
            this.rdb_at.Name = "rdb_at";
            this.rdb_at.Size = new System.Drawing.Size(35, 17);
            this.rdb_at.TabIndex = 2;
            this.rdb_at.TabStop = true;
            this.rdb_at.Text = "At";
            this.rdb_at.UseVisualStyleBackColor = true;
            this.rdb_at.CheckedChanged += new System.EventHandler(this.rdb_at_CheckedChanged);
            // 
            // rdb_vezir
            // 
            this.rdb_vezir.AutoSize = true;
            this.rdb_vezir.Location = new System.Drawing.Point(72, 75);
            this.rdb_vezir.Name = "rdb_vezir";
            this.rdb_vezir.Size = new System.Drawing.Size(48, 17);
            this.rdb_vezir.TabIndex = 3;
            this.rdb_vezir.TabStop = true;
            this.rdb_vezir.Text = "Vezir";
            this.rdb_vezir.UseVisualStyleBackColor = true;
            this.rdb_vezir.CheckedChanged += new System.EventHandler(this.rdb_vezir_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Piyonunuzu Çevirmek İstediğiniz Taş Türünü Seçin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdb_vezir);
            this.Controls.Add(this.rdb_at);
            this.Controls.Add(this.rdb_fil);
            this.Controls.Add(this.rdb_kale);
            this.Name = "Form2";
            this.Text = "Piyon Değişimi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_kale;
        private System.Windows.Forms.RadioButton rdb_fil;
        private System.Windows.Forms.RadioButton rdb_at;
        private System.Windows.Forms.RadioButton rdb_vezir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}