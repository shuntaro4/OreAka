using Prism.Ioc;
using System.Windows;
using OreAka.WPF.ApplicationService;
using OreAka.WPF.Infrastructure.Repositories;
using OreAka.WPF.Presentation.Views;

namespace OreAka.WPF
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
            containerRegistry.Register<IJsonSerializer, JsonSerializer>();
        }
    }
}
