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
    public partial class Formregister2 : Form
    {
        public Formregister2()
        {
            InitializeComponent();
            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox2; // Mengatur parent dari label1 menjadi pictureBox1 agar transparan
            label7.BringToFront();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the FormDashboardRegister
            Formregisterberhasil formRegister = new Formregisterberhasil();

            // Show the FormDashboardRegister as a modal dialog
            formRegister.ShowDialog();
            this.Hide();

            // Alternatively, if you don't want it to be a modal dialog, you can use:
            // formRegister.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
