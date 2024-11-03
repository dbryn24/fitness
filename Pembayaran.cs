using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace projectfitness
{
    public partial class Pembayaran : Form
    {
        // Variabel koneksi dan perintah SQL
        private MySqlConnection koneksi;
        private MySqlCommand perintah;
        private string alamat, query;

        public Pembayaran()
        {
            // Inisialisasi koneksi ke database MySQL
            alamat = "server=localhost; database=db_fitness; username=root; password=262311Ak.";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();

            // Mengatur ukuran dan posisi form
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        // Event handler untuk tombol submit pembayaran
        private void button3_Click(object sender, EventArgs e)
        {
        
        }

        // Event handler untuk radio button PembayaranCash
        private void PembayaranCash_CheckedChanged(object sender, EventArgs e)
        {
            if (PembayaranCash.Checked)
            {
                PembayaranTransfer.Checked = false;
            }
        }

        // Event handler untuk radio button PembayaranTransfer
        private void PembayaranTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (PembayaranTransfer.Checked)
            {
                PembayaranCash.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Kosong, bisa diisi jika ada fungsi tambahan untuk label
        }
    }
}
