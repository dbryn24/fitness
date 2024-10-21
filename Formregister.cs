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
    public partial class Formregister : Form
    {
        public Formregister()
        {
            InitializeComponent();
            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox1; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the FormDashboardRegister
            Formregister2 formRegister = new Formregister2();

            // Show the FormDashboardRegister as a modal dialog
            formRegister.ShowDialog();
            this.Hide();
            // Alternatively, if you don't want it to be a modal dialog, you can use:
            // formRegister.Show();
        }
    }
}
