using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SavasLibrary.Enum;
using SavasLibrary.Interface;

namespace SavasLibrary.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer {Interval = 1000};
        private readonly Timer _hareketTimer = new Timer {Interval = 100};
        private readonly Timer _ucakOlusturmaTimer = new Timer {Interval = 2000};
        private TimeSpan _gecenSure;
        private readonly Panel _ucakSavarPanel;
        private readonly Panel _savasAlani;
        private Ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();

        #endregion
        #region Olaylar

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;
                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Metotlar
        public Oyun(Panel ucakSavarPanel, Panel savasAlaniPanel)
        {
            _ucakSavarPanel = ucakSavarPanel;
            _savasAlani = savasAlaniPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakOlusturmaTimer.Tick += UcakOlusturmaTimer_Tick;
            
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
        }

        private void UcakOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            UcakOlustur();
        }

        private void MermileriHareketEttir()
        {
            for (int i = _mermiler.Count - 1; i >= 0; i--)
            {
                var mermi = _mermiler[i];
                var carptiMi = mermi.HareketEttir(Yon.Yukari);
                if (carptiMi)
                {
                    _mermiler.Remove(mermi);
                    _savasAlani.Controls.Remove(mermi);
                }
            }
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;
            DevamEdiyorMu = true;

            UcaksavarOlustur();
            UcakOlustur();
            ZamanlayicilariBaslat();

        }

        private void UcakOlustur()
        {
            var ucak = new Ucak(_savasAlani.Size);
            _ucaklar.Add(ucak);
            _savasAlani.Controls.Add(ucak);
        }

        private void ZamanlayicilariBaslat()
        {
            _hareketTimer.Start();
            _gecenSureTimer.Start();
            _ucakOlusturmaTimer.Start();
        }

        private void UcaksavarOlustur()
        {
            _ucaksavar = new Ucaksavar(_ucakSavarPanel.Width, _ucakSavarPanel.Size);
     
            _ucakSavarPanel.Controls.Add(_ucaksavar);

        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanlayicilariDurdur();
        }

        private void ZamanlayicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _ucakOlusturmaTimer.Stop();
        }

        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;

            var mermi = new Mermi(_savasAlani.Size, _ucaksavar.Center);
            _mermiler.Add(mermi);
            _savasAlani.Controls.Add(mermi);
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return;
            _ucaksavar.HareketEttir(yon);
        }
        #endregion
    }
}
