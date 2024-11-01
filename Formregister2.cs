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
            this.Size = new Size(1280, 720);
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
            formRegister.Show();
            this.Hide();

            // Alternatively, if you don't want it to be a modal dialog, you can use:
            // formRegister.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formregister formRegister = new Formregister();
            formRegister.Show();
            this.Hide();
        }
    }
}
