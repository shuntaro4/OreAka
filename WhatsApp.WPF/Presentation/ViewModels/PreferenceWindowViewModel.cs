using Prism.Mvvm;
using Reactive.Bindings;

namespace WhatsApp.WPF.Presentation.ViewModels
{
    public class PreferenceWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("Preference");

        public ReactiveProperty<string> Delimiter { get; } = new ReactiveProperty<string>(",");

        public ReactiveCommand DelimiterDefaultCommand { get; }

        public ReactiveCommand SaveCommand { get; }

        public PreferenceWindowViewModel()
        {
            DelimiterDefaultCommand = new ReactiveCommand();
            DelimiterDefaultCommand.Subscribe(DelimiterDefaultAction);

            SaveCommand = new ReactiveCommand();
            SaveCommand.Subscribe(SaveAction);
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
