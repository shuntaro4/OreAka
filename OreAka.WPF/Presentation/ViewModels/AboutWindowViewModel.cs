using Prism.Mvvm;
using Reactive.Bindings;
using System.Reflection;

namespace OreAka.WPF.Presentation.ViewModels
{
    public class AboutWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("OreAka - About");

        public ReactiveProperty<string> Version { get; } = new ReactiveProperty<string>("");

        public AboutWindowViewModel()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Version.Value = $"Version {assembly.GetName().Version}";
        }
    }
}
