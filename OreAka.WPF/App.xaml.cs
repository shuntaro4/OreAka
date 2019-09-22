using OreAka.WPF.ApplicationService;
using OreAka.WPF.Infrastructure.Repositories;
using OreAka.WPF.Presentation.Views;
using Prism.Ioc;
using System.Windows;

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
            containerRegistry.Register<IPreferencesService, PreferencesService>();
            containerRegistry.Register<IWorkTaskRepository, WorkTaskRepository>();
            containerRegistry.Register<IPreferencesRepository, PreferencesRepository>();
            containerRegistry.Register<ILogService, LogService>();
            containerRegistry.Register<IJsonSerializer, JsonSerializer>();
        }
    }
}
