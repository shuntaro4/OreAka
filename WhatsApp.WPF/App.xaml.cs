using Prism.Ioc;
using System.Windows;
using WhatsApp.WPF.Presentation.Views;

namespace WhatsApp.WPF
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
