using System;
using System.Windows.Forms;
using SavasLibrary.Enum;
using SavasLibrary.Interface;

namespace SavasLibrary.Concrete
{
    public class Oyun : IOyun
    {
        public bool DevamEdiyorMu { get; private set; }
        public TimeSpan GecenSure { get; }
        public void Baslat()
        {
            if (DevamEdiyorMu) return;
            MessageBox.Show("Oyun başladı!");
              DevamEdiyorMu = true;
        }

        private void Bitiy()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
        }

        public void AtesEt()
        {
            throw new NotImplementedException();
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            throw new NotImplementedException();
        }
    }
}
