using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savas
{
    public partial class PuanListesi : Form
    {
        public PuanListesi()
        {
            InitializeComponent();
            string fileLocation = @"skor.txt";
            if (!File.Exists(fileLocation))
            {
                skorlarLabel.Text = "Henüz görüntülenecek bir skor mevcut değil.";
            }
            else
            {
                string butunSkorlar = File.ReadAllText(fileLocation, Encoding.UTF8);
                skorlarLabel.Text = butunSkorlar;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GirisEkranForm girisEkranForm = new GirisEkranForm();
            this.Hide();
            girisEkranForm.Show();
        }
    }
}
