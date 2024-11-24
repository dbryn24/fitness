using System;
using System.Drawing;
using System.Windows.Forms;

namespace projectfitness
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BringToFront();

            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BringToFront();

            label3.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BringToFront();

            // Inisialisasi placeholder untuk email dan password TextBox
            InitializePlaceholders();

        }

        private void InitializePlaceholders()
        {
            // Set placeholder awal untuk email dan password
            labelemail.Text = "Enter your email";
            labelemail.ForeColor = Color.Gray;

            labelpassword.Text = "Enter your password";
            labelpassword.ForeColor = Color.Gray;

            // Tambahkan event handler untuk mengatur placeholder saat masuk dan keluar dari TextBox
            labelemail.GotFocus += RemovePlaceholder;
            labelemail.LostFocus += SetPlaceholder;

            labelpassword.GotFocus += RemovePlaceholder;
            labelpassword.LostFocus += SetPlaceholder;
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = textBox == labelemail ? "Enter your email" : "Enter your password";
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Enter your email" || textBox.Text == "Enter your password")
            {
                textBox.ForeColor = Color.Black;
                textBox.Text = "";
            }
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
                this.Hide();
            }
            else
            {
                // Jika tidak valid, tampilkan pesan kesalahan
                MessageBox.Show("Username atau password salah, silakan coba lagi.");
            }
        }

        // Fungsi sederhana untuk validasi login
        private bool IsLoginValid(string username, string password)
        {
            // Anda dapat mengganti verifikasi ini dengan validasi yang lebih kompleks (misalnya database)
            return username == "email" && password == "password";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler kosong, jika tidak diperlukan bisa dihapus
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Event handler kosong, jika tidak diperlukan bisa dihapus
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Event handler kosong, jika tidak diperlukan bisa dihapus
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Event handler kosong, jika tidak diperlukan bisa dihapus
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Event handler kosong, jika tidak diperlukan bisa dihapus
        }
        private void email_TextChanged(object sender, EventArgs e)
        {
            // Optional: Isi jika Anda membutuhkan fungsionalitas
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            // Optional: Isi jika Anda membutuhkan fungsionalitas
        }

    }
}
