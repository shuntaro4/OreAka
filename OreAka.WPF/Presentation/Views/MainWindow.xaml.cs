using OreAka.WPF.ApplicationService;
using OreAka.WPF.Infrastructure.HotKeyRegister;
using System;
using System.Windows;
using System.Windows.Input;
using Unity.Attributes;

namespace OreAka.WPF.Presentation.Views
{
    public partial class MainWindow : WindowEx
    {
        [Dependency]
        public IPreferencesService PreferencesService { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            HotKeyRegister.GenerateInstance(this);
            RegistHotKey();
            AnswerText.Focus();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            HotKeyRegister.Instance.UnRegistAllKeys();
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

        private void SwichMode_Click(object sender, RoutedEventArgs e)
        {
            AnswerText.Focus();
        }

        private void RegistHotKey()
        {
            HotKeyRegister.Instance.UnRegistAllKeys();

            var preferences = PreferencesService.GetPreferences();
            HotKeyRegister.Instance.RegistKey(preferences.ShowHideShortcut.ModifierKeys, preferences.ShowHideShortcut.Key, (_, __) =>
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
        }
    }
}
