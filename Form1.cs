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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label1.BringToFront();

            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label2.BringToFront();

            label3.BackColor = Color.Transparent;
            label3.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label3.BringToFront();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mendapatkan input usernama dan password dari user
            string username = labelemail.Text;
            string password = labelpassword.Text;

            // Verifikasi sederhana username dan password
            if (IsLoginValid(username, password))
            {
                // Jika valid, buka form baru
                FormDashboard form2 = new FormDashboard();
                form2.Show();
                this.Hide(); // Sembunyikan form login
            }
            else
            {
                // Jika tidak valid, tampilkan pesan kesalahan
                MessageBox.Show("username atau password salah, silakan coba lagi.");
            }
        }

        // Fungsi sederhana untuk validasi login
        private bool IsLoginValid(string username, string password)
        {
            // Anda dapat mengganti verifikasi ini dengan validasi yang lebih kompleks (misalnya database)
            return username == "email" && password == "password";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
