﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectfitness
{
    public partial class RegisterAmbilFoto : Form
    {
        public RegisterAmbilFoto()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
    }
}
