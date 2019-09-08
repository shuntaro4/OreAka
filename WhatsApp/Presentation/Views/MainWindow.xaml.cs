using System;
using System.Windows;
using System.Windows.Input;
using WhatsApp.Infrastructure.HotKeyRegister;

namespace WhatsApp.Presentation.Views
{
    public partial class MainWindow : Window
    {
        private IHotKeyRegister hotKeyRegister;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            hotKeyRegister = new HotKeyRegister(this);
            hotKeyRegister.RegistKey(ModifierKeys.Control | ModifierKeys.Shift, Key.Space, (_, __) =>
            {
                // todo
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            hotKeyRegister.UnRegistAllKeys();
        }
    }
}
