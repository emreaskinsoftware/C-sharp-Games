using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private int boyut; // Seçilen ızgara boyutu
        private int kazanmaUzunlugu; // Kaç hücre yan yana gerekiyor
        private string oyuncu; // Oyuncu: "X" veya "O"
        private int hamleSayisi; // Toplam hamle sayısı
        private Button[,] butonlar; // Dinamik oluşturulan butonlar
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            // Seçilen boyut
            string secim = cmbBoyutSecimi.SelectedItem?.ToString();
            if (secim == null)
            {
                MessageBox.Show("Lütfen bir boyut seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (secim == "3x3")
            {
                boyut = 3;
                kazanmaUzunlugu = 3; // 3x3 oyun için kazanma uzunluğu
            }
            else if (secim == "5x5" || secim == "7x7")
            {
                boyut = secim == "5x5" ? 5 : 7;
                kazanmaUzunlugu = 3; // Daha büyük tahtalar için yine 3
            }

            OyunuBaslat();
        }
        // Dinamik olarak oyunu başlatır
        private void OyunuBaslat()
        {
            this.Controls.Clear(); // Önceki kontrol öğelerini temizle
            oyuncu = "X"; // İlk oyuncu X
            hamleSayisi = 0;
            butonlar = new Button[boyut, boyut];

            int buttonSize = 50; // Her butonun boyutu
            int offsetX = 10; // Başlangıç X konumu
            int offsetY = 10; // Başlangıç Y konumu

            // Dinamik olarak butonları oluştur
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    Button btn = new Button
                    {
                        Name = $"btn_{i}_{j}",
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(offsetX + (j * buttonSize), offsetY + (i * buttonSize)),
                        Font = new Font("Arial", 16, FontStyle.Bold)
                    };

                    btn.Click += Btn_Click;
                    this.Controls.Add(btn);
                    butonlar[i, j] = btn;
                }
            }

            // Oyuncu durumu göstermek için bir Label ekleyin
            Label lblDurum = new Label
            {
                Name = "lblDurum",
                Text = "Sıradaki: X",
                Location = new Point(offsetX, offsetY + boyut * buttonSize + 10),
                AutoSize = true
            };
            this.Controls.Add(lblDurum);
        }

        // Butona tıklama işlemi
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && string.IsNullOrEmpty(btn.Text))
            {
                btn.Text = oyuncu;
                hamleSayisi++;

                // Kazanan kontrolü
                if (KazananVarMi())
                {
                    MessageBox.Show($"{oyuncu} Kazandı!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OyunuBaslat();
                    return;
                }

                // Beraberlik kontrolü
                if (hamleSayisi == boyut * boyut)
                {
                    MessageBox.Show("Beraberlik!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OyunuBaslat();
                    return;
                }

                // Oyuncu değiştir
                oyuncu = (oyuncu == "X") ? "O" : "X";
                var lblDurum = this.Controls["lblDurum"] as Label;
                if (lblDurum != null) lblDurum.Text = $"Sıradaki: {oyuncu}";
            }
        }

        // Kazanan kontrolü
        private bool KazananVarMi()
        {
            // Tüm yönlerde kazanma kontrolü yap
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (!string.IsNullOrEmpty(butonlar[i, j].Text) &&
                        (KontrolYonu(i, j, 1, 0) || // Yatay
                         KontrolYonu(i, j, 0, 1) || // Dikey
                         KontrolYonu(i, j, 1, 1) || // Çapraz sağ aşağı
                         KontrolYonu(i, j, 1, -1))) // Çapraz sağ yukarı
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Belirtilen yönde kazanma kontrolü
        private bool KontrolYonu(int startX, int startY, int stepX, int stepY)
        {
            string text = butonlar[startX, startY].Text;

            for (int k = 1; k < kazanmaUzunlugu; k++)
            {
                int yeniX = startX + k * stepX;
                int yeniY = startY + k * stepY;

                // Sınırları aşarsa veya eşleşme yoksa false
                if (yeniX < 0 || yeniX >= boyut || yeniY < 0 || yeniY >= boyut ||
                    butonlar[yeniX, yeniY].Text != text)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
