using System;
using System.Windows.Input;

namespace OreAka.WPF.Infrastructure.HotKeyRegister
{
    public interface IHotKeyRegister : IDisposable
    {
        bool RegistKey(ModifierKeys modifierKeys, Key key, EventHandler eventHandler);

        bool UpdateFirstKey(ModifierKeys modifierKeys, Key key);

        bool UnRegistAllKeys();
    }
}
