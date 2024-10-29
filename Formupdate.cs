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
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formupdate2 formRegister = new Formupdate2();
            formRegister.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("apakah anda yakin?\nUser yang dihapus akan hilang secara permanen", "Hapus User", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formRegister = new Form1();
            formRegister.ShowDialog();
        }
    }
}
