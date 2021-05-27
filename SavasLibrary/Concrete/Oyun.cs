using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        private readonly Panel _bilgiPanel;
        private Ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();
        private int _puan;
        private int _kazanilacakPuan;
        private string _zorlukSeviyesi;
        private bool _duraklat;
        private string _bilgiLabel;

        #endregion
        #region Olaylar

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu
        {
            get => _duraklat;
            set => _duraklat = value;
        }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;
                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        public int Puan
        {
            get => _puan;
            private set => _puan += value;
        }
        public string Seviye
        {
            get => _zorlukSeviyesi;
            private set => _zorlukSeviyesi = value;
        }

        public void ZorlukDegistir(int zorluk)
        {
            switch (zorluk)
            {
                case 2:
                    _hareketTimer.Enabled = false;
                    _hareketTimer.Interval = 20;
                    _ucakOlusturmaTimer.Interval = 1500;
                    _hareketTimer.Enabled = true;
                    _kazanilacakPuan = 20;
                    Seviye = "2";
                    break;

                case 3:
                    _hareketTimer.Enabled = false;
                    _hareketTimer.Interval = 15;
                    _hareketTimer.Enabled = true;
                    _ucakOlusturmaTimer.Enabled = false;
                    _ucakOlusturmaTimer.Interval = 1500;
                    _ucakOlusturmaTimer.Enabled = true;
                    _kazanilacakPuan = 50;
                    Seviye = "3";
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region Metotlar
        public Oyun(Panel ucakSavarPanel, Panel savasAlaniPanel, Panel bilgiPanel, string zorlukSeviyesi)
        {
            _ucakSavarPanel = ucakSavarPanel;
            _savasAlani = savasAlaniPanel;
            _bilgiPanel = bilgiPanel;
            _zorlukSeviyesi = zorlukSeviyesi;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakOlusturmaTimer.Tick += UcakOlusturmaTimer_Tick;
            _kazanilacakPuan = 10;
            
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            if (!DevamEdiyorMu) return;

            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            if (!DevamEdiyorMu) return;
          
            MermileriHareketEttir();
            UcaklariHareketEttir();
            VurulanUcaklariCikar();
        }

        public void Duraklat()
        {
            if (DevamEdiyorMu == false)
            {

                DevamEdiyorMu = true;
            }
            else
            {
                DevamEdiyorMu = false;
            }
        }

        private void VurulanUcaklariCikar()
        {
            for (int i = _ucaklar.Count -1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];
                var vuranMermi = ucak.VurulduMu(_mermiler);
                if (vuranMermi is null) continue;

                _ucaklar.Remove(ucak);
                _mermiler.Remove(vuranMermi);
                _savasAlani.Controls.Remove(ucak);
                _savasAlani.Controls.Remove(vuranMermi);

                Puan = _kazanilacakPuan;
                PuanArttir();
            }
        }

        private void PuanArttir()
        {
            var puanLabel = _bilgiPanel.Controls.Find("puanLabel", true).FirstOrDefault();
            puanLabel.Text = Puan.ToString();
        }

        private void UcaklariHareketEttir()
        {
            foreach (var ucak in _ucaklar)
            {
               var carptiMi = ucak.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                Bitir();
                break;
            }
        }

        private void UcakOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            if (!DevamEdiyorMu) return;
  

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

            var _bilgiLabel = _bilgiPanel.Controls.Find("bilgiLabel", true).FirstOrDefault();
            _bilgiLabel.Text = "Duraklatmak ve Devam etmek için P'ye basınız.";
            UcaksavarOlustur();
            UcakOlustur();
            ZamanlayicilariBaslat();
            

        }

        private void UcakOlustur()
        {
            if (!DevamEdiyorMu) return;
  
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
            SkorListesiGuncelle();
      
            
        }

        private void SkorListesiGuncelle()
        {
            string fileLocation = @"skor.txt";

            if (!File.Exists(fileLocation))
            {
                FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("0\n0\n0\n0\n0");
                sw.Flush();
                sw.Close();
                fs.Close();
            }

            string[] skorlar = File.ReadAllLines(fileLocation, Encoding.UTF8);

            List<int> yeniSkorlar = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                yeniSkorlar.Add(Convert.ToInt32(skorlar[i]));
            }

            yeniSkorlar.Sort();

            for (int i = 0; i < 5; i++)
            {
                if (Puan > Convert.ToInt32(skorlar[i]))
                {
                    yeniSkorlar[0] = Puan;

                    yeniSkorlar.Sort();

                    String lastScores = yeniSkorlar[4].ToString() + "\n" +
                                    yeniSkorlar[3].ToString() + "\n" +
                                    yeniSkorlar[2].ToString() + "\n" +
                                    yeniSkorlar[1].ToString() + "\n" +
                                    yeniSkorlar[0].ToString() + "\n";


                    File.WriteAllText(fileLocation, lastScores);

                    break;
                }
            }

            MessageBox.Show(yeniSkorlar[4].ToString() + "\n" +
                  yeniSkorlar[3].ToString() + "\n" +
                  yeniSkorlar[2].ToString() + "\n" +
                  yeniSkorlar[1].ToString() + "\n" +
                  yeniSkorlar[0].ToString() + "\n",
                  "En İyi 5 Listesi");

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
