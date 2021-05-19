using SavasLibrary.Enum;
using System.Drawing;

namespace SavasLibrary.Interface
{
    internal interface IHareketEden
    {

        Size HareketAlaniBoyutlari { get; }

        int HareketMesafesi { get; }
        /// <summary>
        /// Cismi istenilen yönde hareket ettirir.
        /// </summary>
        /// <param name="yon">Hangi yöne hareket edileceği</param>
        /// <returns>Cismin duvara çarparsa true döndürür.</returns>
        bool HareketEttir(Yon yon);
    }
}
