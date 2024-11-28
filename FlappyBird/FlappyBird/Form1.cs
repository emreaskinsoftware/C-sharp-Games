using System;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class flapybird : Form
    {
        int pipeSpeed = 3; // Boruların hızını düşürerek oyunu yavaşlatın
        int gravity = 5; // Kuşun düşme hızını düşürün
        int score = 0; // Skor takibi
        int gap = 150; // İki boru arasındaki boşluk

        Random rnd = new Random();

        public flapybird()
        {
            InitializeComponent();

            // Timer ayarları
            gameTimer.Interval = 35; // Oyun hızını yavaşlatmak için intervali artırdık
            gameTimer.Tick += new EventHandler(timer1_Tick);

            // Klavye olaylarını form ile ilişkilendir
            this.KeyDown += new KeyEventHandler(flapybird_KeyDown);
            this.KeyUp += new KeyEventHandler(flapybird_KeyUp);

            gameReset(); // Oyunu başlat
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void gameReset()
        {
            gravity = 5; // Yerçekimini ayarla
            score = 0;

            // Kuşun başlangıç pozisyonu
            flappyBird.Top = 150;

            // Boruların başlangıç konumlarını ayarlayın
            pipeTop.Left = 400;
            pipeBottom.Left = 400;

            AdjustPipePosition();

            gameTimer.Start();
        }

        private void endGame()
        {
            gameTimer.Stop();
            MessageBox.Show("Oyun bitti! Skor: " + score);
            gameReset(); // Oyun bitince yeniden başlat
        }

        private void AdjustPipePosition()
        {
            // Üst borunun rastgele bir yüksekliğini belirle ve en üst kısma yapıştır
            int offset = rnd.Next(50, zemin.Top - gap - 50); // Üst boru zemin ile gap olacak şekilde ayarlandı

            // Üst borunun konumu ve yüksekliği
            pipeTop.Top = 0;
            pipeTop.Height = offset;

            // Alt boru, üst boru ile zemin arasında 'gap' olacak şekilde konumlandırıldı
            pipeBottom.Top = offset + gap;
            pipeBottom.Height = zemin.Top - pipeBottom.Top;
        }

        private void flapybird_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5; // Kuş yukarı zıplar (yavaşlatılmış hız)
            }
        }

        private void flapybird_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5; // Kuş tekrar düşmeye başlar (yavaşlatılmış hız)
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Kuşun düşmesi
            flappyBird.Top += gravity;

            // Boruların sola hareket etmesi
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;

            scoreLabel.Text = $"Skor: {score}";

            // Borular ekranın soluna ulaştığında yeniden başlatılır ve rastgele yükseklik ayarlanır
            if (pipeTop.Left < -pipeTop.Width)
            {
                // Boruları ekranın sağından yeniden getir
                pipeTop.Left = this.ClientSize.Width;
                pipeBottom.Left = this.ClientSize.Width;

                // Rastgele boru yüksekliğini ayarla
                AdjustPipePosition();

                score++; // Skoru arttır
            }

            // Kuşun borulara, zemine veya ekranın üst kısmına çarpma durumunu kontrol et
            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(zemin.Bounds) || // Zemin ile çarpışma kontrolü
                flappyBird.Top <= 0) // Ekranın üstüne çarpma kontrolü
            {
                endGame(); // Çarpma durumunda oyunu bitir
            }
        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
