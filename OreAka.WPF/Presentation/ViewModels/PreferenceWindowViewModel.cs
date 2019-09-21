using Prism.Mvvm;
using Reactive.Bindings;
using System.Windows.Input;

namespace OreAka.WPF.Presentation.ViewModels
{
    public class PreferenceWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("Preference");

        public ReactiveProperty<string> Delimiter { get; } = new ReactiveProperty<string>(",");

        public ReactiveCommand DelimiterDefaultCommand { get; }

        public ReactiveCommand SaveCommand { get; }

        public ReactiveCollection<ModifierKeys> ModifierKeys1 { get; }

        public ReactiveCollection<ModifierKeys> ModifierKeys2 { get; }

        public ReactiveCollection<Key> Keys { get; }

        public PreferenceWindowViewModel()
        {
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
