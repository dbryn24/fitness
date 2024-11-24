using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projectfitness
{

    public partial class RegisterAmbilFoto : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public RegisterAmbilFoto()
        {
            InitializeComponent(); // Simpan ID member yang diterima
            alamat = "server=localhost; database=db_fitness; username=root; password=262311Ak.";
            koneksi = new MySqlConnection(alamat);

            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox1;
            label7.BringToFront();
        }


        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;


        private void RegisterAmbilFoto_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveImageToDatabase(); // Simpan gambar ke database berdasarkan ID member
            RegisterKonfirmasiFoto formRegister = new RegisterKonfirmasiFoto();
            formRegister.ShowDialog();
            this.Hide();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Register back = new Register();
            back.Show();
            this.Hide();
        }

        private void RegisterAmbilFoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                // Menggunakan overload yang sesuai
                graphics.DrawImage(image, destRect, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }

            return destImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {
            try
            {
                // Buka dialog untuk memilih file gambar
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Tampilkan gambar di PictureBox
                    pic.Image = Image.FromFile(openFileDialog1.FileName);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat membuka gambar: {ex.Message}");
            }
        }

        private void SaveImageToDatabase()
        {
            try
            {
                koneksi.Open(); // Buka koneksi ke database

                // Query untuk mengambil ID terakhir dari tabel `member`
                query = "SELECT Id FROM member ORDER BY Id DESC LIMIT 1";
                perintah = new MySqlCommand(query, koneksi);
                object result = perintah.ExecuteScalar();

                // Periksa apakah hasil valid
                if (result == null || !int.TryParse(result.ToString(), out int memberId))
                {
                    MessageBox.Show("Tidak dapat mengambil ID member terakhir.");
                    return; // Menghentikan proses jika ID tidak valid
                }

                // Periksa apakah gambar tersedia di PictureBox
                if (pic.Image == null)
                {
                    MessageBox.Show("Tidak ada gambar yang dipilih.");
                    return;
                }

                // Konversi gambar menjadi byte array
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap image = new Bitmap(pic.Image); // Ambil gambar dari PictureBox
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Ubah format jika diperlukan
                    imageBytes = ms.ToArray();
                }

                // Query untuk memperbarui foto berdasarkan ID member
                query = "UPDATE member SET Foto = @Foto WHERE Id = @Id";
                perintah = new MySqlCommand(query, koneksi);
                perintah.Parameters.AddWithValue("@Foto", imageBytes);
                perintah.Parameters.AddWithValue("@Id", memberId);

                int rowsAffected = perintah.ExecuteNonQuery(); // Eksekusi perintah SQL

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Foto berhasil disimpan ke database!");
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan foto. Periksa ID member.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menyimpan gambar: {ex.Message}");
            }
            finally
            {
                if (koneksi.State == System.Data.ConnectionState.Open)
                {
                    koneksi.Close(); // Tutup koneksi jika terbuka
                }
            }
        }

    }
}
