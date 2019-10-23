using System;

namespace OreAka.WPF.Infrastructure.RunRegister
{
    public interface IRunRegister : IDisposable
    {
        void RegistKey(bool autoLaunch);
    }
}
