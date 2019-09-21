using System.Windows;
using System.Windows.Input;

namespace OreAka.WPF.Presentation.Views
{
    public partial class PreferenceWindow : WindowEx
    {
        public PreferenceWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
    }
}
