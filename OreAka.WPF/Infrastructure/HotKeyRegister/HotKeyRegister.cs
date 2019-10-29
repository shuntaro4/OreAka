using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace OreAka.WPF.Infrastructure.HotKeyRegister
{
    public class HotKeyRegister : IHotKeyRegister
    {
        public static HotKeyRegister Instance { get; private set; }

        private IntPtr hWnd;

        private Dictionary<int, HotKeyItem> hotKeys = new Dictionary<int, HotKeyItem>();

        private int nowHotkeyId;

        private const int WM_HOTKEY = 0x312;

        private const int MAX_HOTKEY_ID = 0xC000;

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        public static void GenerateInstance(Window window)
        {
            Instance = new HotKeyRegister(window);
        }

        private HotKeyRegister(Window window)
        {
            var host = new WindowInteropHelper(window);
            hWnd = host.Handle;
            ComponentDispatcher.ThreadPreprocessMessage += ComponentDispatcher_ThreadPreprocessMessage;
        }

        private void ComponentDispatcher_ThreadPreprocessMessage(ref MSG msg, ref bool handled)
        {
            if (msg.message != WM_HOTKEY)
            {
                return;
            }

            var id = msg.wParam.ToInt32();
            var hotkey = hotKeys[id];

            hotkey?.EventHandler?.Invoke(this, EventArgs.Empty);
        }

        public bool RegistKey(ModifierKeys modifierKeys, Key key, EventHandler eventHandler)
        {
            var fsModifiers = (int)modifierKeys;
            var vk = KeyInterop.VirtualKeyFromKey(key);

            while (nowHotkeyId < MAX_HOTKEY_ID)
            {
                var result = RegisterHotKey(hWnd, nowHotkeyId, fsModifiers, vk);
                if (result == 0)
                {
                    // failed to regist a hotkey.
                    nowHotkeyId++;
                    continue;
                }

                var hotKey = new HotKeyItem(modifierKeys, key, eventHandler);
                hotKeys.Add(nowHotkeyId, hotKey);
                nowHotkeyId++;
                return true;
            }

            return false;
        }

        public bool UpdateFirstKey(ModifierKeys modifierKeys, Key key)
        {
            // todo :(

            if (hotKeys.Count < 1)
            {
                return false;
            }
            var hotKey = hotKeys.FirstOrDefault();

            UnRegistKeyById(hotKey.Key);

            RegistKey(modifierKeys, key, hotKey.Value.EventHandler);

            return true;
        }

        public bool UnRegistKeyById(int id)
        {
            var result = UnregisterHotKey(hWnd, id);
            if (result == 0)
            {
                // failed to unregist a hotkey.
                return false;
            }

            hotKeys.Remove(id);

            return true;
        }

        public bool UnRegistAllKeys()
        {
            var result = hotKeys.All(x => UnRegistKeyById(x.Key));
            return result;
        }

        public void Dispose()
        {
            UnRegistAllKeys();
            GC.SuppressFinalize(this);
        }
    }
}
