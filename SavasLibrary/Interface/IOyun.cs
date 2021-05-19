using System;
using SavasLibrary.Enum;

namespace SavasLibrary.Interface
{
    internal interface IOyun
    {
        event EventHandler GecenSureDegisti;
        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }
        void Baslat();
        void AtesEt();
        void UcaksavariHareketEttir(Yon yon);

    }
}
