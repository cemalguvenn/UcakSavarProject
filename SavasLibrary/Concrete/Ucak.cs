using SavasLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SavasLibrary.Concrete
{
    internal class Ucak : Cisim
    {
        private static readonly Random Random = new Random();
        public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            HareketMesafesi = (int)(Height * .1d);
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
        }

        public Mermi VurulduMu(List<Mermi> mermiler)
        {
            foreach (var mermi in mermiler)
            {
                var vurulduMu = mermi.Top < Bottom && mermi.Right > Left && mermi.Left < Right;
                if (vurulduMu)
                {
                    return mermi;
                }
            }
            return null;
        }
    }
}
