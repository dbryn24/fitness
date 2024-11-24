using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectfitness
{
    public partial class Statistic : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        private string connectionString = "server=localhost;user id=root;password=262311Ak.;database=db_fitness";
        public Statistic()
        {
            alamat = "server=localhost; database=db_fitness; username=root; password=262311Ak.";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistic formRegister = new Statistic();
            formRegister.Show();
            this.Hide();
        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDashboard formRegister = new FormDashboard();
            formRegister.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login formRegister = new Login();
            formRegister.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Statistic formRegister = new Statistic();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            FormDashboard back = new FormDashboard();
            back.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
        }
        private void FormStatistic_Load(object sender, EventArgs e)
        {
            LoadBookingData();
            AdjustDataGridViewSize();
        }
        private void AdjustDataGridViewSize()
        {
            // Mengatur DataGridView untuk memenuhi lebar yang tersedia tanpa scroll horizontal
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Menyesuaikan tinggi setiap baris secara otomatis
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Atur ulang header agar terlihat rapi
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void SetDataGridViewColumns(DataGridView dataGridView)
        {
            // Mengatur lebar kolom dan header text
            dataGridView1.Columns[0].Width = 20;
            dataGridView1.Columns[0].HeaderText = "Nama";

            dataGridView1.Columns[1].Width = 20;
            dataGridView1.Columns[1].HeaderText = "Jenis Langganan";

            dataGridView1.Columns[2].Width = 20;
            dataGridView1.Columns[2].HeaderText = "Harga";

            dataGridView1.Columns[3].Width = 20;
            dataGridView1.Columns[3].HeaderText = "Jenis Pembayaran";

        }
        private void LoadBookingData()
        {
            string query = @"
            SELECT m.Nama, mb.Jenis_Keanggotaan, mb.Harga, mb.Jenis_Pembayaran 
            FROM membership mb
            JOIN member m ON mb.Id = m.Id";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Mengisi data ke dalam DataTable
                    adapter.Fill(dataTable);

                    // Menampilkan data di DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
