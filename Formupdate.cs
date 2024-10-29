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
    public partial class Formupdate : Form
    {
        public Formupdate()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formupdate2 formRegister = new Formupdate2();
            formRegister.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Formhapususer formRegister = new Formhapususer();
            formRegister.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formRegister = new Form1();
            formRegister.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDashboard formRegister = new FormDashboard();
            formRegister.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormVerification2 formRegister = new FormVerification2();
            formRegister.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formstatistic formRegister = new Formstatistic();
            formRegister.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDashboard formReggister = new FormDashboard();
            formReggister.ShowDialog();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerification2 formRegister = new FormVerification2();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formstatistic formRegister = new Formstatistic();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 formRegister = new Form1();
            formRegister.ShowDialog();
            this.Hide();
        }
    }
}
