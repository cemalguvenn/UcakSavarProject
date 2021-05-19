using System.Drawing;
using System.Windows.Forms;
using SavasLibrary.Abstract;

namespace SavasLibrary.Concrete
{
    internal class Ucaksavar : Cisim
    {
        public Ucaksavar(int panelGenisligi, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Center = panelGenisligi / 2;
            SizeMode = PictureBoxSizeMode.AutoSize;
            HareketMesafesi = Width;
        }
    }
}
