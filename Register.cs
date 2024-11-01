﻿using System;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            label1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label1.BringToFront();

            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        private void Formdashboardregister_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Register formRegister = new Register();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterAmbilFoto formRegister = new RegisterAmbilFoto();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            FormDashboard back = new FormDashboard();
            back.Show();
            this.Hide();
        }
    }
}
