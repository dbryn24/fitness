using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace projectfitness
{
    public partial class msg : Form
    {
        public msg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Mengambil nama dari TextBox `search`
            string namaPencarian = search.Text.Trim();

            // Memastikan nama tidak kosong sebelum melakukan penghapusan
            if (string.IsNullOrEmpty(namaPencarian))
            {
                MessageBox.Show("Masukkan nama yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Membuka form `yakinkah`
            yakinkah formYakinkah = new yakinkah();

            // Mengirimkan nama yang akan dihapus melalui properti `NamaMember`
            formYakinkah.NamaMember = namaPencarian;

            // Menampilkan form `yakinkah` sebagai dialog
            formYakinkah.ShowDialog();
            this.Hide();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Mengambil nilai dari TextBox search_Text
            string namaPencarian = search.Text.Trim();

            // Memastikan input tidak kosong
            if (string.IsNullOrEmpty(namaPencarian))
            {
                MessageBox.Show("Masukkan nama yang ingin dicari!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    // Membuat query untuk mencari data berdasarkan nama
                    string query = "SELECT Nama, Nomor_Telepon, Tanggal_Kedaluarsa FROM member WHERE Nama = @nama";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Mengambil nilai dari TextBox search_Text sebagai parameter
                        cmd.Parameters.AddWithValue("@nama", namaPencarian);

                        // Membaca hasil query
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Menampilkan hasil pencarian di TextBox
                                nama.Text = reader["Nama"].ToString();
                                noTelepon.Text = reader["Nomor_Telepon"].ToString();
                                try
                                {
                                    // Mencoba konversi Tanggal_Kedaluarsa
                                    DateTime tanggalKedaluarsa = Convert.ToDateTime(reader["Tanggal_Kedaluarsa"]);
                                    alamat.Text = tanggalKedaluarsa.ToString("yyyy-MM-dd");
                                }
                                catch
                                {
                                    // Jika gagal konversi, tampilkan teks kosong atau pesan
                                    alamat.Text = "Tanggal tidak valid";
                                }
                            }
                            else
                            {
                                // Menampilkan pesan jika data tidak ditemukan
                                MessageBox.Show("Data tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // Mengosongkan TextBox jika data tidak ditemukan
                                nama.Text = "";
                                noTelepon.Text = "";
                                alamat.Text = "";
                            }
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
        }



        private void nama_TextChanged(object sender, EventArgs e)
        {

        }

        private void noTelepon_TextChanged(object sender, EventArgs e)
        {

        }

        private void alamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            // Mengambil nilai dari TextBox
            string namaPencarian = search.Text.Trim();
            string namaBaru = nama.Text.Trim();
            string nomorTeleponBaru = noTelepon.Text.Trim();
            string tanggalKedaluarsaBaru = alamat.Text.Trim();

            // Memastikan input tidak kosong
            if (string.IsNullOrEmpty(namaPencarian))
            {
                MessageBox.Show("Masukkan nama yang ingin diupdate!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Memastikan nilai baru tidak kosong
            if (string.IsNullOrEmpty(namaBaru) || string.IsNullOrEmpty(nomorTeleponBaru) || string.IsNullOrEmpty(tanggalKedaluarsaBaru))
            {
                MessageBox.Show("Pastikan semua data telah diisi dengan benar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    // Membuat query untuk mendapatkan data saat ini dari database
                    string selectQuery = "SELECT Nama, Nomor_Telepon, Tanggal_Kedaluarsa FROM member WHERE Nama = @namaPencarian";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@namaPencarian", namaPencarian);

                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Membaca data dari database
                                string namaLama = reader["Nama"].ToString();
                                string nomorTeleponLama = reader["Nomor_Telepon"].ToString();
                                string tanggalKedaluarsaLama = Convert.ToDateTime(reader["Tanggal_Kedaluarsa"]).ToString("yyyy-MM-dd");

                                // Mengecek apakah ada perubahan data
                                bool isNamaChanged = !namaBaru.Equals(namaLama);
                                bool isNoTeleponChanged = !nomorTeleponBaru.Equals(nomorTeleponLama);
                                bool isTanggalKedaluarsaChanged = !tanggalKedaluarsaBaru.Equals(tanggalKedaluarsaLama);

                                if (!isNamaChanged && !isNoTeleponChanged && !isTanggalKedaluarsaChanged)
                                {
                                    MessageBox.Show("Tidak ada data yang diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Membuat query untuk meng-update data berdasarkan nama yang dicari
                    string updateQuery = "UPDATE member SET Nama = @namaBaru, Nomor_Telepon = @nomorTeleponBaru, Tanggal_Kedaluarsa = @tanggalKedaluarsaBaru WHERE Nama = @namaPencarian";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        // Menggunakan parameter untuk mencegah SQL Injection
                        updateCmd.Parameters.AddWithValue("@namaBaru", namaBaru);
                        updateCmd.Parameters.AddWithValue("@nomorTeleponBaru", nomorTeleponBaru);

                        // Konversi tanggal kedaluwarsa dengan aman
                        DateTime tanggal;
                        if (DateTime.TryParse(tanggalKedaluarsaBaru, out tanggal))
                        {
                            updateCmd.Parameters.AddWithValue("@tanggalKedaluarsaBaru", tanggal.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            MessageBox.Show("Format tanggal tidak valid! Gunakan format yyyy-MM-dd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        updateCmd.Parameters.AddWithValue("@namaPencarian", namaPencarian);

                        // Menjalankan perintah UPDATE
                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        // Mengecek apakah data berhasil diperbarui
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan atau tidak ada perubahan yang disimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
    }
}
