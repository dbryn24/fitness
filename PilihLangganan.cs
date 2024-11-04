using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectfitness
{
    public partial class PilihLangganan : Form
    {
        public PilihLangganan()
        {
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
            Pembayaran formRegister = new Pembayaran();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void PilihLangganan_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
