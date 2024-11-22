using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        private const int GridSize = 20; // 20x20 grid
        private const int ButtonSize = 30; // Buton boyutu (30x30 px)
        private Button[,] buttons = new Button[GridSize, GridSize]; // 20x20 butonlar
        private bool[,] mines = new bool[GridSize, GridSize]; // Mayınların yerleri
        private bool[,] revealed = new bool[GridSize, GridSize]; // Açılmış yerler
        private Random random = new Random();
        private int totalMines; // Toplam mayın sayısı
        private int revealedCount = 0; // Açılan hücre sayısı
        public Form1()
        {
            InitializeComponent();
            CreateGrid();
            PlaceMines();
        }

        // 20x20 buton ızgarası oluştur
        private void CreateGrid()
        {
            this.ClientSize = new Size(GridSize * ButtonSize, GridSize * ButtonSize); // Form boyutu

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button button = new Button
                    {
                        Size = new Size(ButtonSize, ButtonSize),
                        Location = new Point(i * ButtonSize, j * ButtonSize),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Tag = new Point(i, j) // Tag içine butonun koordinatlarını koyuyoruz
                    };
                    button.MouseUp += Button_MouseUp; // Sağ ve sol tıklamayı yakalamak için MouseUp eventini bağla
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }

        // Rastgele mayınları yerleştir
        private void PlaceMines()
        {
            totalMines = (int)(GridSize * GridSize * 0.10); // %10 kadar mayın
            int placedMines = 0;

            while (placedMines < totalMines)
            {
                int x = random.Next(0, GridSize);
                int y = random.Next(0, GridSize);

                if (!mines[x, y]) // Eğer zaten mayın yoksa
                {
                    mines[x, y] = true;
                    placedMines++;
                }
            }
        }

        // Butona tıklama
        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            Point location = (Point)button.Tag; // Butonun koordinatlarını al
            int x = location.X;
            int y = location.Y;

            if (e.Button == MouseButtons.Right) // Sağ tık: Bayrak ekle/kaldır
            {
                if (button.Text == "") // Bayrak yoksa bayrak ekle
                {
                    button.Text = "🚩";
                    button.ForeColor = Color.Red;
                }
                else if (button.Text == "🚩") // Bayrak varsa bayrağı kaldır
                {
                    button.Text = "";
                }
            }
            else if (e.Button == MouseButtons.Left) // Sol tık: Hücreyi aç
            {
                if (button.Text == "🚩") return; // Bayraklı yere tıklanamaz

                if (mines[x, y]) // Eğer mayın varsa
                {
                    button.BackColor = Color.Red;
                    MessageBox.Show("Mayına bastınız! Oyun bitti.");
                    RevealAllMines();
                }
                else
                {
                    RevealCell(x, y);
                    CheckWinCondition();
                }
            }
        }

        // Hücreyi aç
        private void RevealCell(int x, int y)
        {
            if (x < 0 || x >= GridSize || y < 0 || y >= GridSize || revealed[x, y]) return;

            int nearbyMines = CountNearbyMines(x, y);
            Button button = buttons[x, y];

            button.Text = nearbyMines > 0 ? nearbyMines.ToString() : "";
            button.Enabled = false;
            button.BackColor = Color.LightGray;
            revealed[x, y] = true;
            revealedCount++;

            if (nearbyMines == 0) // Çevresinde mayın yoksa çevresini otomatik aç
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        RevealCell(x + i, y + j);
                    }
                }
            }
        }

        // Çevresindeki mayınları say
        private int CountNearbyMines(int x, int y)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (newX >= 0 && newX < GridSize && newY >= 0 && newY < GridSize && mines[newX, newY])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        // Tüm mayınları göster
        private void RevealAllMines()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (mines[i, j])
                    {
                        buttons[i, j].BackColor = Color.Red;
                        buttons[i, j].Text = "M";
                    }
                }
            }
        }

        // Kazanma koşulunu kontrol et
        private void CheckWinCondition()
        {
            if (revealedCount == GridSize * GridSize - totalMines)
            {
                MessageBox.Show("Tebrikler! Tüm mayınsız yerleri açtınız, oyunu kazandınız!");
                RevealAllMines();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
