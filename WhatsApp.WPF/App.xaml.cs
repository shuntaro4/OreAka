using Prism.Ioc;
using System.Windows;
using WhatsApp.WPF.ApplicationService;
using WhatsApp.WPF.Infrastructure.Repositories;
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
            containerRegistry.Register<IWorkTaskService, WorkTaskService>();
            containerRegistry.Register<IWorkTaskRepository, WorkTaskRepository>();
            containerRegistry.Register<ILogService, LogService>();
        }
    }
}
