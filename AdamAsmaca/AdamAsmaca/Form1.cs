using System;
using System.Linq;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        private string[] cities = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan",
                                    "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis",
                                    "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce",
                                    "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
                                    "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük",
                                    "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis",
                                    "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş",
                                    "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop",
                                    "Sivas", "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van",
                                    "Yalova", "Yozgat", "Zonguldak" };

        private string selectedCity;  // Seçilen şehir
        private char[] displayChars;  // Oyuncunun göreceği şehir adı (_ ile gösterilecek)
        private int lives = 6;        // Kalan tahmin hakkı
        private bool gameOver = false; // Oyunun bitip bitmediği durumu

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            // Rastgele bir şehir seç
            Random random = new Random();
            selectedCity = cities[random.Next(cities.Length)].ToUpper();

            // Şehri gizleyerek başlat (_ ile gösterilecek)
            displayChars = new string('_', selectedCity.Length).ToCharArray();
            UpdateDisplayWord();

            // Başlangıç ayarlarını sıfırla
            lives = 6;
            gameOver = false;
            ResetHangmanDrawing();
            labelSonuc.Text = "";

            textBoxTahmin.Enabled = true;
            buttonTahmin.Enabled = true;
            buttonYeniOyun.Visible = false;
        }

        private void UpdateDisplayWord()
        {
            // Harfler arasına boşluk ekleyerek ekranda göster
            labelSehir.Text = string.Join(" ", displayChars);
        }

        private void ResetHangmanDrawing()
        {
            // Adam asmaca resmini sıfırla (tüm parçaları görünmez yap)
            labelKafa.Visible = false;
            labelGovde.Visible = false;
            labelSagKol.Visible = false;
            labelSolKol.Visible = false;
            labelSagBacak.Visible = false;
            labelSolBacak.Visible = false;
        }

        private void buttonTahmin_Click(object sender, EventArgs e)
        {
            if (gameOver) return; // Oyun bittiyse işlemleri durdur

            if (textBoxTahmin.Text.Length > 0)
            {
                char guess = textBoxTahmin.Text.ToUpper()[0]; // İlk karakteri al
                textBoxTahmin.Clear();

                if (selectedCity.Contains(guess))
                {
                    // Doğru harfi ekle
                    for (int i = 0; i < selectedCity.Length; i++)
                    {
                        if (selectedCity[i] == guess)
                        {
                            displayChars[i] = guess;
                        }
                    }

                    UpdateDisplayWord();

                    // Tüm harfler bulunmuşsa oyunu kazandınız
                    if (!displayChars.Contains('_'))
                    {
                        labelSonuc.Text = "Tebrikler, kazandınız!";
                        EndGame();
                        buttonYeniOyun.Visible = true;
                    }
                }
                else
                {
                    // Yanlış tahmin, bir hayat eksilt
                    lives--;
                    DrawNextHangmanPart();

                    if (lives == 0)
                    {
                        labelSonuc.Text = "Kaybettiniz! Şehir: " + selectedCity;
                        EndGame();
                    }
                }
            }
        }

        private void EndGame()
        {
            gameOver = true;
            textBoxTahmin.Enabled = false;
            buttonTahmin.Enabled = false;
        }

        private void DrawNextHangmanPart()
        {
            // Kalan cana göre adam asmaca çizimlerini göster
            switch (lives)
            {
                case 5:
                    labelKafa.Visible = true;
                    break;
                case 4:
                    labelGovde.Visible = true;
                    break;
                case 3:
                    labelSagKol.Visible = true;
                    break;
                case 2:
                    labelSolKol.Visible = true;
                    break;
                case 1:
                    labelSagBacak.Visible = true;
                    break;
                case 0:
                    labelSolBacak.Visible = true;
                    buttonYeniOyun.Visible = true;
                    break;
            }
        }

        

        private void textBoxTahmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece harflerin girilmesine izin ver
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Eğer zaten bir harf varsa başka girişe izin verme
            if (textBoxTahmin.Text.Length >= 1 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonYeniOyun_Click(object sender, EventArgs e)
        {
            StartGame(); // Yeniden başlatma butonu için
        }
    }
}
