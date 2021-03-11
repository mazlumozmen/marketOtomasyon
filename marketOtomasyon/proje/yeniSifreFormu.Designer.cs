namespace proje
{
    partial class yeniSifreFormu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHata = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSoru = new System.Windows.Forms.ComboBox();
            this.textBoxYeniSifre2 = new System.Windows.Forms.TextBox();
            this.textBoxYeniSifre = new System.Windows.Forms.TextBox();
            this.textBoxCevap = new System.Windows.Forms.TextBox();
            this.textBoxKulAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelHata);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBoxSoru);
            this.panel1.Controls.Add(this.textBoxYeniSifre2);
            this.panel1.Controls.Add(this.textBoxYeniSifre);
            this.panel1.Controls.Add(this.textBoxCevap);
            this.panel1.Controls.Add(this.textBoxKulAdi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 237);
            this.panel1.TabIndex = 12;
            // 
            // labelHata
            // 
            this.labelHata.AutoSize = true;
            this.labelHata.ForeColor = System.Drawing.Color.DarkRed;
            this.labelHata.Location = new System.Drawing.Point(18, 197);
            this.labelHata.Name = "labelHata";
            this.labelHata.Size = new System.Drawing.Size(0, 13);
            this.labelHata.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(67, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 22);
            this.label6.TabIndex = 23;
            this.label6.Text = "YENİ ŞİFRE OLUŞTUR";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(112, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 39);
            this.button1.TabIndex = 22;
            this.button1.Text = "Yeni şifre oluştur";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSoru
            // 
            this.comboBoxSoru.FormattingEnabled = true;
            this.comboBoxSoru.Items.AddRange(new object[] {
            "İlk okulunuzun adı nedir?",
            "İlk evcil hayvanınızın adı nedir?",
            "İlk aracınızın modeli nedir?",
            "Hangi şehirde doğdunuz?",
            "Babanızın ortanca ismi nedir?",
            "Çocukluk lakabınız nedir?"});
            this.comboBoxSoru.Location = new System.Drawing.Point(112, 74);
            this.comboBoxSoru.Name = "comboBoxSoru";
            this.comboBoxSoru.Size = new System.Drawing.Size(162, 21);
            this.comboBoxSoru.TabIndex = 21;
            // 
            // textBoxYeniSifre2
            // 
            this.textBoxYeniSifre2.Location = new System.Drawing.Point(112, 157);
            this.textBoxYeniSifre2.Name = "textBoxYeniSifre2";
            this.textBoxYeniSifre2.Size = new System.Drawing.Size(162, 20);
            this.textBoxYeniSifre2.TabIndex = 20;
            this.textBoxYeniSifre2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxYeniSifre2_KeyUp);
            // 
            // textBoxYeniSifre
            // 
            this.textBoxYeniSifre.Location = new System.Drawing.Point(112, 129);
            this.textBoxYeniSifre.Name = "textBoxYeniSifre";
            this.textBoxYeniSifre.Size = new System.Drawing.Size(162, 20);
            this.textBoxYeniSifre.TabIndex = 19;
            this.textBoxYeniSifre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxYeniSifre_KeyUp);
            // 
            // textBoxCevap
            // 
            this.textBoxCevap.Location = new System.Drawing.Point(112, 101);
            this.textBoxCevap.Name = "textBoxCevap";
            this.textBoxCevap.Size = new System.Drawing.Size(162, 20);
            this.textBoxCevap.TabIndex = 18;
            // 
            // textBoxKulAdi
            // 
            this.textBoxKulAdi.Location = new System.Drawing.Point(112, 47);
            this.textBoxKulAdi.Name = "textBoxKulAdi";
            this.textBoxKulAdi.Size = new System.Drawing.Size(162, 20);
            this.textBoxKulAdi.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Yeni Şifre(tekrar):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Yeni Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cevap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Gizli Soru:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // yeniSifreFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(330, 261);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "yeniSifreFormu";
            this.Text = "YENİ ŞİFRE";
            this.Load += new System.EventHandler(this.yeniSifreFormu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxSoru;
        private System.Windows.Forms.TextBox textBoxYeniSifre2;
        private System.Windows.Forms.TextBox textBoxYeniSifre;
        private System.Windows.Forms.TextBox textBoxCevap;
        private System.Windows.Forms.TextBox textBoxKulAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHata;
    }
}