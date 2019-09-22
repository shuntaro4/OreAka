
using OreAka.WPF.ApplicationService;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Windows.Input;
using Unity.Attributes;

namespace OreAka.WPF.Presentation.ViewModels
{
    public class PreferencesWindowViewModel : BindableBase
    {
        [Dependency]
        public IPreferencesService PreferencesService { get; set; }

        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("Preference");

        public ReactiveProperty<string> Delimiter { get; set; } = new ReactiveProperty<string>(",");

        public ReactiveCommand LoadedCommand { get; }

        public ReactiveCommand DelimiterDefaultCommand { get; }

        public ReactiveCommand SaveCommand { get; }

        public ReactiveCollection<ModifierKeys> ModifierKeys1 { get; set; }

        public ReactiveCollection<ModifierKeys> ModifierKeys2 { get; set; }

        public ReactiveCollection<Key> Keys { get; set; }

        public PreferencesWindowViewModel()
        {
            LoadedCommand = new ReactiveCommand();
            LoadedCommand.Subscribe(LoadedAction);

            DelimiterDefaultCommand = new ReactiveCommand();
            DelimiterDefaultCommand.Subscribe(DelimiterDefaultAction);

            SaveCommand = new ReactiveCommand();
            SaveCommand.Subscribe(SaveAction);

            ModifierKeys1 = new ReactiveCollection<ModifierKeys>
            {
                ModifierKeys.None,
                ModifierKeys.Alt,
                ModifierKeys.Control,
                ModifierKeys.Shift
            };

            ModifierKeys2 = new ReactiveCollection<ModifierKeys>
            {
                ModifierKeys.None,
                ModifierKeys.Alt,
                ModifierKeys.Control,
                ModifierKeys.Shift
            };

            Keys = new ReactiveCollection<Key>()
            {
                Key.Space
            };
        }

        private void LoadedAction()
        {
            var preferences = PreferencesService.GetPreferences();
            Delimiter.Value = preferences.Delimiter;
            // todo combobox value set.
        }

        public void DelimiterDefaultAction()
        {
            Delimiter.Value = ","; // todo
        }

        public void SaveAction()
        {
            // todo 
        }
    }
}
