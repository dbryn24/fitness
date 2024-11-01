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
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistic formRegister = new Statistic();
            formRegister.Show();
            this.Hide();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            StatisticsUpdateDelete formRegister = new StatisticsUpdateDelete();
            formRegister.Show();
            this.Hide();
        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDashboard formRegister = new FormDashboard();
            formRegister.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Verification formRegister = new Verification();
            formRegister.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login formRegister = new Login();
            formRegister.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Statistic formRegister = new Statistic();
            formRegister.ShowDialog();
            this.Hide();
        }
    }
}