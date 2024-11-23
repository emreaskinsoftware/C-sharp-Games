namespace AdamAsmaca
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSehir = new System.Windows.Forms.Label();
            this.labelSonuc = new System.Windows.Forms.Label();
            this.labelKafa = new System.Windows.Forms.Label();
            this.buttonTahmin = new System.Windows.Forms.Button();
            this.textBoxTahmin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSolKol = new System.Windows.Forms.Label();
            this.labelSagBacak = new System.Windows.Forms.Label();
            this.labelSolBacak = new System.Windows.Forms.Label();
            this.labelSagKol = new System.Windows.Forms.Label();
            this.labelGovde = new System.Windows.Forms.Label();
            this.buttonYeniOyun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSehir
            // 
            this.labelSehir.AutoSize = true;
            this.labelSehir.Location = new System.Drawing.Point(72, 78);
            this.labelSehir.MaximumSize = new System.Drawing.Size(110, 100);
            this.labelSehir.Name = "labelSehir";
            this.labelSehir.Size = new System.Drawing.Size(31, 13);
            this.labelSehir.TabIndex = 0;
            this.labelSehir.Text = "Sehir";
            // 
            // labelSonuc
            // 
            this.labelSonuc.AutoSize = true;
            this.labelSonuc.Location = new System.Drawing.Point(72, 20);
            this.labelSonuc.Name = "labelSonuc";
            this.labelSonuc.Size = new System.Drawing.Size(35, 13);
            this.labelSonuc.TabIndex = 1;
            this.labelSonuc.Text = "label2";
            // 
            // labelKafa
            // 
            this.labelKafa.AutoSize = true;
            this.labelKafa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKafa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelKafa.Location = new System.Drawing.Point(403, 56);
            this.labelKafa.Name = "labelKafa";
            this.labelKafa.Size = new System.Drawing.Size(22, 20);
            this.labelKafa.TabIndex = 2;
            this.labelKafa.Text = "O";
            this.labelKafa.Visible = false;
            // 
            // buttonTahmin
            // 
            this.buttonTahmin.Location = new System.Drawing.Point(188, 134);
            this.buttonTahmin.Name = "buttonTahmin";
            this.buttonTahmin.Size = new System.Drawing.Size(75, 23);
            this.buttonTahmin.TabIndex = 3;
            this.buttonTahmin.Text = "Tahmin Et";
            this.buttonTahmin.UseVisualStyleBackColor = true;
            this.buttonTahmin.Click += new System.EventHandler(this.buttonTahmin_Click);
            // 
            // textBoxTahmin
            // 
            this.textBoxTahmin.Location = new System.Drawing.Point(71, 134);
            this.textBoxTahmin.Name = "textBoxTahmin";
            this.textBoxTahmin.Size = new System.Drawing.Size(100, 20);
            this.textBoxTahmin.TabIndex = 4;
            this.textBoxTahmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTahmin_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Harf Giriniz";
            // 
            // labelSolKol
            // 
            this.labelSolKol.AutoSize = true;
            this.labelSolKol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSolKol.Location = new System.Drawing.Point(384, 95);
            this.labelSolKol.Name = "labelSolKol";
            this.labelSolKol.Size = new System.Drawing.Size(14, 20);
            this.labelSolKol.TabIndex = 6;
            this.labelSolKol.Text = "/";
            this.labelSolKol.Visible = false;
            // 
            // labelSagBacak
            // 
            this.labelSagBacak.AutoSize = true;
            this.labelSagBacak.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSagBacak.Location = new System.Drawing.Point(425, 128);
            this.labelSagBacak.Name = "labelSagBacak";
            this.labelSagBacak.Size = new System.Drawing.Size(19, 25);
            this.labelSagBacak.TabIndex = 7;
            this.labelSagBacak.Text = "\\";
            this.labelSagBacak.Visible = false;
            // 
            // labelSolBacak
            // 
            this.labelSolBacak.AutoSize = true;
            this.labelSolBacak.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSolBacak.Location = new System.Drawing.Point(383, 127);
            this.labelSolBacak.Name = "labelSolBacak";
            this.labelSolBacak.Size = new System.Drawing.Size(19, 25);
            this.labelSolBacak.TabIndex = 8;
            this.labelSolBacak.Text = "/";
            this.labelSolBacak.Visible = false;
            // 
            // labelSagKol
            // 
            this.labelSagKol.AutoSize = true;
            this.labelSagKol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSagKol.Location = new System.Drawing.Point(430, 95);
            this.labelSagKol.Name = "labelSagKol";
            this.labelSagKol.Size = new System.Drawing.Size(14, 20);
            this.labelSagKol.TabIndex = 9;
            this.labelSagKol.Text = "\\";
            this.labelSagKol.Visible = false;
            // 
            // labelGovde
            // 
            this.labelGovde.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGovde.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelGovde.Location = new System.Drawing.Point(400, 79);
            this.labelGovde.Name = "labelGovde";
            this.labelGovde.Size = new System.Drawing.Size(35, 49);
            this.labelGovde.TabIndex = 10;
            this.labelGovde.Text = "|";
            this.labelGovde.Visible = false;
            // 
            // buttonYeniOyun
            // 
            this.buttonYeniOyun.Location = new System.Drawing.Point(212, 263);
            this.buttonYeniOyun.Name = "buttonYeniOyun";
            this.buttonYeniOyun.Size = new System.Drawing.Size(75, 23);
            this.buttonYeniOyun.TabIndex = 11;
            this.buttonYeniOyun.Text = "Yeni Oyun";
            this.buttonYeniOyun.UseVisualStyleBackColor = true;
            this.buttonYeniOyun.Visible = false;
            this.buttonYeniOyun.Click += new System.EventHandler(this.buttonYeniOyun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 389);
            this.Controls.Add(this.buttonYeniOyun);
            this.Controls.Add(this.labelGovde);
            this.Controls.Add(this.labelSagKol);
            this.Controls.Add(this.labelSolBacak);
            this.Controls.Add(this.labelSagBacak);
            this.Controls.Add(this.labelSolKol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTahmin);
            this.Controls.Add(this.buttonTahmin);
            this.Controls.Add(this.labelKafa);
            this.Controls.Add(this.labelSonuc);
            this.Controls.Add(this.labelSehir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSehir;
        private System.Windows.Forms.Label labelSonuc;
        private System.Windows.Forms.Label labelKafa;
        private System.Windows.Forms.Button buttonTahmin;
        private System.Windows.Forms.TextBox textBoxTahmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSolKol;
        private System.Windows.Forms.Label labelSagBacak;
        private System.Windows.Forms.Label labelSolBacak;
        private System.Windows.Forms.Label labelSagKol;
        private System.Windows.Forms.Label labelGovde;
        private System.Windows.Forms.Button buttonYeniOyun;
    }
}

