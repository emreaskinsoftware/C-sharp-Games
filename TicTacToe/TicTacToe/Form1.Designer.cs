namespace TicTacToe
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
            this.cmbBoyutSecimi = new System.Windows.Forms.ComboBox();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbBoyutSecimi
            // 
            this.cmbBoyutSecimi.FormattingEnabled = true;
            this.cmbBoyutSecimi.Items.AddRange(new object[] {
            "3x3",
            "5x5",
            "7x7"});
            this.cmbBoyutSecimi.Location = new System.Drawing.Point(32, 12);
            this.cmbBoyutSecimi.Name = "cmbBoyutSecimi";
            this.cmbBoyutSecimi.Size = new System.Drawing.Size(121, 24);
            this.cmbBoyutSecimi.TabIndex = 0;
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(181, 13);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(138, 23);
            this.btnBaslat.TabIndex = 1;
            this.btnBaslat.Text = "Oyunu Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 450);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.cmbBoyutSecimi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoyutSecimi;
        private System.Windows.Forms.Button btnBaslat;
    }
}

