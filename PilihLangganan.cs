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
    public partial class PilihLangganan : Form
    {
        public PilihLangganan()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
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
    }
}
