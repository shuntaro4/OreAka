using Prism.Mvvm;
using Reactive.Bindings;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;

namespace WhatsApp.WPF.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("What's App");

        public ReactiveProperty<string> Answer { get; set; } = new ReactiveProperty<string>("");

        public ReactiveCommand SaveCommand { get; }

        public MainWindowViewModel()
        {
            SaveCommand = new[] { Answer }.CombineLatest(x => x.All(y => !string.IsNullOrWhiteSpace(y))).ToReactiveCommand();
            SaveCommand.Subscribe(SaveAction);
        }

        public void SaveAction()
        {
            Trace.WriteLine("Save Action");
        }
    }
}
