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
    public partial class msg : Form
    {
        public msg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            yakinkah  formRegister = new yakinkah();
            formRegister.ShowDialog();
            this.Hide();
        }
    }
}
