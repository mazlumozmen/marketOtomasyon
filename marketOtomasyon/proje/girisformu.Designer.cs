namespace proje
{
    partial class girisformu
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
            this.buttonGirisYap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKulAdi = new System.Windows.Forms.TextBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.buttonSifreUnuttum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGirisYap
            // 
            this.buttonGirisYap.BackColor = System.Drawing.Color.White;
            this.buttonGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGirisYap.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonGirisYap.FlatAppearance.BorderSize = 2;
            this.buttonGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGirisYap.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGirisYap.Location = new System.Drawing.Point(145, 110);
            this.buttonGirisYap.Name = "buttonGirisYap";
            this.buttonGirisYap.Size = new System.Drawing.Size(150, 36);
            this.buttonGirisYap.TabIndex = 0;
            this.buttonGirisYap.Text = "Giriş Yap";
            this.buttonGirisYap.UseVisualStyleBackColor = false;
            this.buttonGirisYap.Click += new System.EventHandler(this.buttonGirisYap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(87, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre:";
            // 
            // textBoxKulAdi
            // 
            this.textBoxKulAdi.Location = new System.Drawing.Point(145, 55);
            this.textBoxKulAdi.Name = "textBoxKulAdi";
            this.textBoxKulAdi.Size = new System.Drawing.Size(150, 19);
            this.textBoxKulAdi.TabIndex = 3;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Location = new System.Drawing.Point(145, 80);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.PasswordChar = '*';
            this.textBoxSifre.Size = new System.Drawing.Size(150, 19);
            this.textBoxSifre.TabIndex = 4;
            // 
            // buttonSifreUnuttum
            // 
            this.buttonSifreUnuttum.BackColor = System.Drawing.Color.DarkCyan;
            this.buttonSifreUnuttum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSifreUnuttum.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSifreUnuttum.FlatAppearance.BorderSize = 2;
            this.buttonSifreUnuttum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSifreUnuttum.ForeColor = System.Drawing.Color.White;
            this.buttonSifreUnuttum.Location = new System.Drawing.Point(26, 112);
            this.buttonSifreUnuttum.Name = "buttonSifreUnuttum";
            this.buttonSifreUnuttum.Size = new System.Drawing.Size(113, 34);
            this.buttonSifreUnuttum.TabIndex = 5;
            this.buttonSifreUnuttum.Text = "Şifremi Unuttum";
            this.buttonSifreUnuttum.UseVisualStyleBackColor = false;
            this.buttonSifreUnuttum.Click += new System.EventHandler(this.buttonSifreUnuttum_Click);
            // 
            // girisformu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 215);
            this.Controls.Add(this.buttonSifreUnuttum);
            this.Controls.Add(this.textBoxSifre);
            this.Controls.Add(this.textBoxKulAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGirisYap);
            this.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "girisformu";
            this.Text = "EKOMİNİ";
            this.Load += new System.EventHandler(this.girisformu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGirisYap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSifreUnuttum;
        public System.Windows.Forms.TextBox textBoxKulAdi;
        public System.Windows.Forms.TextBox textBoxSifre;
    }
}