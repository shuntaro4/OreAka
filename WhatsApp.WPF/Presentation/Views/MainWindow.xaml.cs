﻿using System;
using System.Windows.Input;
using WhatsApp.WPF.Infrastructure.HotKeyRegister;

namespace WhatsApp.WPF.Presentation.Views
{
    public partial class MainWindow : WindowEx
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
