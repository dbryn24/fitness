using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projectfitness
{
    public partial class PilihLangganan : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public PilihLangganan()
        {
            alamat = "server=localhost; database=db_fitness; username=root; password=262311Ak.";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox2; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RadioVisitor.Checked || RadioMingguan.Checked || RadioBulanan.Checked)
            {
                try
                {
                    koneksi.Open();

                    // Fetch the last inserted member ID
                    query = "SELECT Id FROM member ORDER BY Id DESC LIMIT 1";
                    perintah = new MySqlCommand(query, koneksi);
                    object result = perintah.ExecuteScalar();
                    if (result != null && long.TryParse(result.ToString(), out long Id))
                    {
                        // Lanjutkan dengan Id yang valid
                    }
                    else
                    {
                        MessageBox.Show("Tidak dapat mengambil ID member terakhir.");
                        return; // Menghentikan proses jika ID tidak valid
                    }

                    // Tentukan jenis keanggotaan, durasi, tanggal berakhir, dan harga
                    string jenisKeanggotaan;
                    int durasi;
                    DateTime tglMulai = DateTime.Now;
                    DateTime tglBerakhir;
                    decimal harga;

                    if (RadioVisitor.Checked)
                    {
                        jenisKeanggotaan = "Pengunjung";
                        durasi = 1; // 1 hari
                        tglBerakhir = tglMulai.AddDays(durasi);
                        harga = 25000;
                    }
                    else if (RadioMingguan.Checked)
                    {
                        jenisKeanggotaan = "Mingguan";
                        durasi = 7; // 1 minggu
                        tglBerakhir = tglMulai.AddDays(durasi);
                        harga = 125000;
                    }
                    else
                    {
                        jenisKeanggotaan = "Bulanan";
                        durasi = 30; // 1 bulan
                        tglBerakhir = tglMulai.AddDays(durasi);
                        harga = 400000; // misal Rp400.000
                    }

                    // Query untuk mengupdate jenis keanggotaan, durasi, tanggal berakhir, dan harga di tabel membership
                    query = "UPDATE membership SET Jenis_keanggotaan = @jenisKeanggotaan, Durasi = @durasi, Tgl_Berakhir = @tglBerakhir, Harga = @harga WHERE Id = @Id";
                    perintah = new MySqlCommand(query, koneksi);
                    perintah.Parameters.AddWithValue("@jenisKeanggotaan", jenisKeanggotaan);
                    perintah.Parameters.AddWithValue("@durasi", durasi);
                    perintah.Parameters.AddWithValue("@tglBerakhir", tglBerakhir);
                    perintah.Parameters.AddWithValue("@harga", harga);
                    perintah.Parameters.AddWithValue("@Id", Id);

                    int res = perintah.ExecuteNonQuery();

                    if (res == 1)
                    {
                        // Update Tanggal_Kedaluarsa di tabel member dengan Tgl_Berakhir di tabel membership
                        query = "UPDATE member SET Tanggal_Kedaluarsa = @tglBerakhir WHERE Id = @Id";
                        MySqlCommand updateMemberCmd = new MySqlCommand(query, koneksi);
                        updateMemberCmd.Parameters.AddWithValue("@tglBerakhir", tglBerakhir);
                        updateMemberCmd.Parameters.AddWithValue("@Id", Id);
                        updateMemberCmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil disimpan.");
                        Pembayaran formRegister = new Pembayaran();
                        formRegister.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data, tidak ada baris yang terpengaruh.");
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
                MessageBox.Show("Data Tidak Lengkap! Pilih lagi.");
            }
        }
        private void UpdateMemberStatus()
        {
            try
            {
                koneksi.Open();

                // Memicu trigger dengan melakukan update pada kolom Tanggal_Kedaluarsa untuk memastikan trigger berjalan
                string query = "UPDATE member SET Tanggal_Kedaluarsa = Tanggal_Kedaluarsa WHERE Tanggal_Kedaluarsa < CURDATE() AND Status != 'Expired'";
                MySqlCommand command = new MySqlCommand(query, koneksi);
                command.ExecuteNonQuery();
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

        private void RadioVisitor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PilihLangganan_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
