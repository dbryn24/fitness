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
    public partial class Formverificationberhasil : Form
    {
        public Formverificationberhasil()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBox1; 
            label2.BringToFront();

            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1; 
            label1.BringToFront();

            label3.BackColor = Color.Transparent;
            label3.Parent = pictureBox1; 
            label3.BringToFront();

            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Parent = pictureBox1; 
            linkLabel1.BringToFront();


        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formRegister = new Form1();
            formRegister.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 formRegister = new Form1();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDashboard formReggister = new FormDashboard();
            formReggister.ShowDialog();
            this.Hide();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerification2 formRegister = new FormVerification2();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formstatistic formRegister = new Formstatistic();
            formRegister.ShowDialog();
            this.Hide();
        }
    }
}
