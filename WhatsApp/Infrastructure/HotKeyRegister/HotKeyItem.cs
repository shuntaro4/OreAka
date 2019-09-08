using System;
using System.Windows.Input;

namespace WhatsApp.Infrastructure.HotKeyRegister
{
    public class HotKeyItem
    {
        public ModifierKeys ModifierKeys { get; }

        public Key Key { get; }

        public EventHandler EventHandler { get; }

        public HotKeyItem(ModifierKeys modifierKeys, Key key, EventHandler eventHandler)
        {
            ModifierKeys = modifierKeys;
            Key = key;
            EventHandler = eventHandler;
        }
    }
}
