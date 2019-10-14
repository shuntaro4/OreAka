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

        public ReactiveCommand SaveCommand { get; }

        public ReactiveCommand ShowPreferencesCommand { get; }

        public ReactiveCommand ShowAboutCommand { get; }

        public ReactiveCommand OpenFolderCommand { get; }

        [Dependency]
        public IWorkTaskService WorkTaskService { get; set; }

        [Dependency]
        public AppFolder AppFolder { get; set; }

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
        }

        private async void SaveAction()
        {
            IsBusy.Value = true;

            var result = await WorkTaskService.RegistWorkTaskAsync(Answer.Value);
            if (result)
            {
                Answer.Value = string.Empty;
            }

            // todo : add message.

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
    }
}
