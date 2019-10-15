using OreAka.WPF.ApplicationService;
using OreAka.WPF.Domain;
using OreAka.WPF.Presentation.Views;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using Unity.Attributes;

namespace OreAka.WPF.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("OreAka");

        public ReactiveProperty<bool> IsBusy { get; private set; } = new ReactiveProperty<bool>(false);

        public ReactiveProperty<string> Answer { get; set; } = new ReactiveProperty<string>("");

        public ReactiveCollection<string> Histories { get; set; }

        public ReactiveCommand SaveCommand { get; }

        public ReactiveCommand ShowPreferencesCommand { get; }

        public ReactiveCommand ShowAboutCommand { get; }

        public ReactiveCommand OpenFolderCommand { get; }

        public ReactiveCommand SwitchThemeCommand { get; }

        public ReactiveCommand LoadedCommand { get; }

        [Dependency]
        public IWorkTaskService WorkTaskService { get; set; }

        [Dependency]
        public AppFolder AppFolder { get; set; }

        [Dependency]
        public IAppThemeService AppThemeService { get; set; }

        [Dependency]
        public IPreferencesService PreferencesService { get; set; }

        public MainWindowViewModel()
        {
            SaveCommand = new[] { Answer }.CombineLatest(x => x.All(y => !string.IsNullOrWhiteSpace(y))).ToReactiveCommand();
            SaveCommand.Subscribe(SaveAction);

            ShowPreferencesCommand = new ReactiveCommand();
            ShowPreferencesCommand.Subscribe(ShowPreferencesAction);

            ShowAboutCommand = new ReactiveCommand();
            ShowAboutCommand.Subscribe(ShowAboutAction);

            OpenFolderCommand = new ReactiveCommand();
            OpenFolderCommand.Subscribe(OpenFolderAction);

            SwitchThemeCommand = new ReactiveCommand();
            SwitchThemeCommand.Subscribe(SwitchThemeAction);

            LoadedCommand = new ReactiveCommand();
            LoadedCommand.Subscribe(LoadedAction);

            Histories = new ReactiveCollection<string>();
        }

        private async void LoadedAction()
        {
            AppThemeService.LoadTheme();

            var histories = await WorkTaskService.GetWorkTaskHistoriesAsync();
            foreach (var history in histories)
            {
                Histories.AddOnScheduler(history);
            }
        }

        private async void SaveAction()
        {
            IsBusy.Value = true;

            var result = await WorkTaskService.RegistWorkTaskAsync(Answer.Value);
            if (result != null)
            {
                Answer.Value = string.Empty;
                Histories.Remove(result.Title);
                Histories.Insert(0, result.Title);
            }

            IsBusy.Value = false;
        }

        private void ShowPreferencesAction()
        {
            var preferencesWindow = new PreferencesWindow();
            preferencesWindow.ShowDialog();
        }

        private void ShowAboutAction()
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void OpenFolderAction()
        {
            Process.Start("EXPLORER.EXE", AppFolder.OutputFolder);
        }

        private void SwitchThemeAction()
        {
            var currentTheme = AppThemeService.SwitchTheme();
            PreferencesService.SaveTheme(currentTheme.ThemeName);
        }
    }
}
