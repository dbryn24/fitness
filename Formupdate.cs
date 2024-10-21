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
    }
}
