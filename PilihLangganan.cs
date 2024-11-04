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

        }
        private void PilihLangganan_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
