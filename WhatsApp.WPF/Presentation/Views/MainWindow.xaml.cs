using System;
using System.Windows;
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
                if (Visibility == Visibility.Collapsed)
                {
                    Visibility = Visibility.Visible;
                    AnswerText.Focus();
                    return;
                }

                if (Visibility == Visibility.Visible)
                {
                    Visibility = Visibility.Collapsed;
                    return;
                }
            });

            AnswerText.Focus();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            hotKeyRegister.UnRegistAllKeys();
        }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState != MouseButtonState.Pressed)
            {
                return;
            }
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Preference_Click(object sender, RoutedEventArgs e)
        {
            var preferenceWindow = new PreferenceWindow();
            preferenceWindow.ShowDialog();
        }
    }
}
