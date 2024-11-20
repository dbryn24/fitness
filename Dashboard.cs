using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectfitness
{
    public partial class FormDashboard : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        private string connectionString = "server=localhost;user id=root;password=262311Ak.;database=db_fitness";


        public FormDashboard()
        {
            alamat = "server=localhost; database=db_fitness; username=root; password=262311Ak.";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;


            linkLabel2.BackColor = Color.Transparent;
            linkLabel2.Parent = pictureBox1;
            linkLabel2.BringToFront();

            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BringToFront();

            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BringToFront();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login formRegister = new Login();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Register formRegister = new Register();
            formRegister.ShowDialog();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Statistic FormRegister = new Statistic();
            FormRegister.ShowDialog();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Statistic formRegister = new Statistic();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDashboard formRegister = new FormDashboard();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            FormDashboard back = new FormDashboard();
            back.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
        }


        private void buttonCR_Click(object sender, EventArgs e)
        {
            Formpengguna formpengguna = new Formpengguna();
            formpengguna.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadBookingData();
            AdjustDataGridViewSize();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            msg formmsg = new msg();
            formmsg.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AdjustDataGridViewSize()
        {
            // Mengatur DataGridView untuk memenuhi lebar yang tersedia tanpa scroll horizontal
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Menyesuaikan tinggi setiap baris secara otomatis
            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            // Atur ulang header agar terlihat rapi
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void SetDataGridViewColumns(DataGridView dataGridView)
        {
            // Mengatur lebar kolom dan header text
            dataGridView4.Columns[0].Width = 20;
            dataGridView4.Columns[0].HeaderText = "Nama";

            dataGridView4.Columns[1].Width = 20;
            dataGridView4.Columns[1].HeaderText = "Jenis Kelamin";

            dataGridView4.Columns[2].Width = 20;
            dataGridView4.Columns[2].HeaderText = "Nomor Telepon";

            dataGridView4.Columns[3].Width = 20;
            dataGridView4.Columns[3].HeaderText = "Tanggal Pendaftaran";

            dataGridView4.Columns[4].Width = 20;
            dataGridView4.Columns[4].HeaderText = "Tanggal Kadaluarsa";

        }
        private void LoadBookingData()
        {
            string query = @"
            SELECT 
            Nama, 
            Jenis_Kelamin, 
            Nomor_Telepon, 
            IFNULL(Tanggal_Pendaftaran, '0000-00-00') AS 'Tanggal Pendaftaran', 
            IFNULL(Tanggal_Kedaluarsa, '0000-00-00') AS 'Tanggal Kedaluarsa' 
            FROM member";
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

    }
}
