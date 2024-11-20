using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectfitness
{
    public partial class yakinkah : Form
    {
        public string NamaMember { get; set; }

        public yakinkah()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Jika tombol "Tidak" diklik, tutup form
            this.Hide();
        }

        private void yakinkah_Load(object sender, EventArgs e)
        {
            // Anda bisa menambahkan kode inisialisasi di sini jika diperlukan
        }

        private void ya_Click(object sender, EventArgs e)
        {
            // Memastikan NamaMember tidak kosong sebelum melakukan penghapusan
            if (string.IsNullOrEmpty(NamaMember))
            {
                MessageBox.Show("Nama tidak valid atau tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Koneksi ke database MySQL
            string connectionString = "Server=localhost;Database=db_fitness;User ID=root;Password=262311Ak.;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Membuka koneksi
                    conn.Open();

                    // Membuat query untuk menghapus data dari tabel payment dan membership berdasarkan nama
                    string deletePaymentQuery = "DELETE FROM payment WHERE Id = (SELECT Id FROM member WHERE Nama = @nama)";
                    string deleteMembershipQuery = "DELETE FROM membership WHERE Id = (SELECT Id FROM member WHERE Nama = @nama)";
                    string deleteMemberQuery = "DELETE FROM member WHERE Nama = @nama";

                    using (MySqlCommand cmd = new MySqlCommand(deletePaymentQuery, conn))
                    {
                        // Menggunakan parameter untuk mencegah SQL Injection
                        cmd.Parameters.AddWithValue("@nama", NamaMember);
                        cmd.ExecuteNonQuery(); // Menghapus data dari tabel payment
                    }

                    using (MySqlCommand cmd = new MySqlCommand(deleteMembershipQuery, conn))
                    {
                        // Menggunakan parameter untuk mencegah SQL Injection
                        cmd.Parameters.AddWithValue("@nama", NamaMember);
                        cmd.ExecuteNonQuery(); // Menghapus data dari tabel membership
                    }

                    using (MySqlCommand cmd = new MySqlCommand(deleteMemberQuery, conn))
                    {
                        // Menggunakan parameter untuk mencegah SQL Injection
                        cmd.Parameters.AddWithValue("@nama", NamaMember);
                        int rowsAffected = cmd.ExecuteNonQuery(); // Menghapus data dari tabel member

                        // Mengecek apakah ada data yang dihapus
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan atau sudah dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Menampilkan pesan error jika terjadi kesalahan
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Menutup koneksi database
                    conn.Close();
                }
            }

            // Menutup form setelah penghapusan
            this.Hide();
        }
    }
}
