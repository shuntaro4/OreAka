using OreAka.WPF.ApplicationService;
using OreAka.WPF.Domain;
using OreAka.WPF.Infrastructure.Repositories;
using OreAka.WPF.Infrastructure.RunRegister;
using OreAka.WPF.Presentation.Views;
using Prism.Ioc;
using System;
using System.Threading;
using System.Windows;

namespace OreAka.WPF
{
    public partial class App
    {
        private static readonly string mutexName = "OreAka";

        private static Mutex mutex = new Mutex(false, mutexName);

        private static bool hasHandle = false;

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // ApplicationServices
            containerRegistry.Register<IAppThemeService, AppThemeService>();
            containerRegistry.Register<ILogService, LogService>();
            containerRegistry.Register<IPreferencesService, PreferencesService>();
            containerRegistry.Register<IWorkTaskService, WorkTaskService>();

            // Domain
            containerRegistry.RegisterInstance(typeof(AppFolder), new AppFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));

            // Repository
            containerRegistry.Register<IWorkTaskRepository, WorkTaskRepository>();
            containerRegistry.Register<IPreferencesRepository, PreferencesRepository>();
            containerRegistry.Register<IJsonSerializer, JsonSerializer>();
            containerRegistry.Register<IRunRegister, RunRegister>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            hasHandle = mutex.WaitOne(0, false);
            if (!hasHandle)
            {
                Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (hasHandle)
            {
                mutex.ReleaseMutex();
            }
            mutex.Close();
        }
    }
}
