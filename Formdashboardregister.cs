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
    public partial class Formdashboardregister : Form
    {
        public Formdashboardregister()
        {
            InitializeComponent();
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
            Formdashboardregister formRegister = new Formdashboardregister();
            formRegister.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the FormDashboardRegister
            Formregister formRegister = new Formregister();

            // Show the FormDashboardRegister as a modal dialog
            formRegister.ShowDialog();
            this.Hide();
        }
    }
}
