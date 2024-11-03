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
    public partial class PilihLangganan : Form
    {
        public PilihLangganan()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistrasiBerhasil formRegister = new RegistrasiBerhasil();
            formRegister.ShowDialog();
            this.Hide();
        }
    }
}
