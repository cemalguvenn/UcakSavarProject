using System;
using SavasLibrary.Concrete;
using System.Windows.Forms;
using SavasLibrary.Enum;

namespace Savas
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun;
        private int Seviye { get; set; }
        private int SonSeviye = 3;
        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(ucakSavarPanel, savasAlani, bilgiPanel, "1");
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
            Seviye = 1;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    _oyun.Baslat();
                    break;
                case Keys.Right:
                    _oyun.UcaksavariHareketEttir(Yon.Saga);
                    break;
                case Keys.Left:
                    _oyun.UcaksavariHareketEttir(Yon.Sola);
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
                case Keys.P:
                    _oyun.Duraklat();
                    break;
            }
        }


        int tempSure = 0;
        int _sure;
        private void Oyun_GecenSureDegisti(object sender, EventArgs e)
        {
            sureLabel.Text = _oyun.GecenSure.ToString(@"m\:ss");

            tempSure += 1;


            if (tempSure - _sure == 30)
            {
                if (Seviye > SonSeviye) return;

                Seviye += 1;
                _oyun.ZorlukDegistir(Seviye);
                _sure += 30;
            }
        }
    }
}
