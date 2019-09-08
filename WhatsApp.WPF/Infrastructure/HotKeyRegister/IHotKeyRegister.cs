using System;
using System.Windows.Input;

namespace WhatsApp.WPF.Infrastructure.HotKeyRegister
{
    public interface IHotKeyRegister : IDisposable
    {
        bool RegistKey(ModifierKeys modifierKeys, Key key, EventHandler eventHandler);

        bool UnRegistAllKeys();
    }
}
