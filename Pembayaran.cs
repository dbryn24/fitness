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
            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox2; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        // Event handler untuk tombol submit pembayaran
        private void button3_Click(object sender, EventArgs e)
        {
            // Memeriksa apakah metode pembayaran dipilih
            if (PembayaranCash.Checked || PembayaranTransfer.Checked)
            {
                try
                {
                    koneksi.Open();
                    query = "SELECT Id FROM member ORDER BY Id DESC LIMIT 1";
                    perintah = new MySqlCommand(query, koneksi);
                    object result = perintah.ExecuteScalar();
                    if (result != null && long.TryParse(result.ToString(), out long Id))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Tidak dapat mengambil ID member terakhir.");
                        return; // Menghentikan proses jika ID tidak valid
                    }

                    // Tentukan jenis pembayaran berdasarkan pilihan pengguna
                    string pembayaran;

                    if (PembayaranCash.Checked)
                    {
                        pembayaran = "Cash";
                    }
                    else
                    {
                        pembayaran = "Transfer";
                    }

                    // Query untuk memperbarui data jenis pembayaran dan tanggal pembayaran
                    query = "UPDATE membership SET Jenis_Pembayaran = @pembayaran WHERE Id = @Id";
                    perintah = new MySqlCommand(query, koneksi);
                    perintah.Parameters.AddWithValue("@pembayaran", pembayaran);
                    perintah.Parameters.AddWithValue("@Id", Id);

                    int res = perintah.ExecuteNonQuery();

                    if (res == 1)
                    {
                        // Jangan mengubah Id lagi, cukup lanjutkan proses insert

                        // Query untuk menambahkan data ke tabel payment dengan Tanggal_Masuk sekarang
                        string membershipQuery = "INSERT INTO payment (Id, Tgl_Pembayaran, Jenis_Pembayaran) VALUES (@Id, NOW(), @pembayaran)";
                        MySqlCommand membershipCommand = new MySqlCommand(membershipQuery, koneksi);
                        membershipCommand.Parameters.AddWithValue("@Id", Id); // Pastikan Id di sini valid
                        membershipCommand.Parameters.AddWithValue("@pembayaran", pembayaran);
                        membershipCommand.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil disimpan.");
                        RegistrasiBerhasil formRegister = new RegistrasiBerhasil();
                        formRegister.ShowDialog();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Gagal menyimpan data, tidak ada baris yang terpengaruh.");
                        // Debugging tambahan jika tidak ada baris yang terpengaruh
                        MessageBox.Show("Pastikan ID ini ada di tabel payment: " + Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    koneksi.Close();
                }
            }
            else
            {
                MessageBox.Show("Data Tidak Lengkap! Pilih metode pembayaran.");
            }
        }

        // Event handler untuk radio button PembayaranCash
        private void PembayaranCash_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Event handler untuk radio button PembayaranTransfer
        private void PembayaranTransfer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Kosong, bisa diisi jika ada fungsi tambahan untuk label
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
