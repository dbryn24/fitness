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
    public partial class Register : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public Register()
        {
            alamat = "server=localhost; database=db_fitness; username=root; password=262311Ak.";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label1.BringToFront();

            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        private void Formdashboardregister_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Register formRegister = new Register();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TxtNama.Text != "" && NoTelp.Text != "" && (RadioLaki.Checked || RadioPerempuan.Checked))
            {
                try
                {
                    koneksi.Open();

                    // Query untuk menambahkan data ke tabel member
                    query = "INSERT INTO member (Nama, Nomor_Telepon, Jenis_Kelamin, Tanggal_Pendaftaran) VALUES (@Nama, @Nomor_Telepon, @Jenis_Kelamin, NOW())";
                    perintah = new MySqlCommand(query, koneksi);
                    perintah.Parameters.AddWithValue("@Nama", TxtNama.Text);
                    perintah.Parameters.AddWithValue("@Nomor_Telepon", NoTelp.Text);
                    string gender = RadioLaki.Checked ? "Laki-Laki" : "Perempuan";
                    perintah.Parameters.AddWithValue("@Jenis_Kelamin", gender);
                    int res = perintah.ExecuteNonQuery();

                    if (res == 1)
                    {
                        // Mendapatkan ID member yang baru saja dimasukkan
                        long Id = perintah.LastInsertedId;

                        // Query untuk menambahkan data ke tabel membership dengan Tanggal_Masuk sekarang
                        string membershipQuery = "INSERT INTO membership (Id, Tgl_Mulai) VALUES (@Id, NOW())";
                        MySqlCommand membershipCommand = new MySqlCommand(membershipQuery, koneksi);
                        membershipCommand.Parameters.AddWithValue("@Id", Id);
                        membershipCommand.ExecuteNonQuery();

                        MessageBox.Show("Insert Data Sukses.");

                        // Membuka form RegisterAmbilFoto jika data berhasil disimpan
                        RegisterAmbilFoto formRegister = new RegisterAmbilFoto();
                        formRegister.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Gagal insert Data.");
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
                MessageBox.Show("Data Tidak Lengkap!");
            }
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NoTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RadioLaki_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioPerempuan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            FormDashboard back = new FormDashboard();
            back.Show();
            this.Hide();
        }
    }
}
