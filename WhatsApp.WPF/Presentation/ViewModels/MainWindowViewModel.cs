using Prism.Mvvm;
using Reactive.Bindings;

namespace WhatsApp.WPF.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("What's App");

        public MainWindowViewModel()
        {
        }
    }
}
