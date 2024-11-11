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
        public FormDashboard()
        {
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

        }
    }
}
