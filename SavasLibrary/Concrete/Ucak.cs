using SavasLibrary.Abstract;
using System;
using System.Drawing;

namespace SavasLibrary.Concrete
{
    internal class Ucak : Cisim
    {
        private static readonly Random Random = new Random();
        public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
        }
    }
}
