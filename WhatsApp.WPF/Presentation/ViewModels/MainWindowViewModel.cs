using Prism.Mvvm;
using Reactive.Bindings;
using System.Linq;
using System.Reactive.Linq;
using Unity.Attributes;
using WhatsApp.WPF.ApplicationService;

namespace WhatsApp.WPF.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("What's App");

        public ReactiveProperty<string> Answer { get; set; } = new ReactiveProperty<string>("");

        public ReactiveCommand SaveCommand { get; }

        [Dependency]
        public IWorkTaskService WorkTaskService { get; set; }

        public MainWindowViewModel()
        {
            SaveCommand = new[] { Answer }.CombineLatest(x => x.All(y => !string.IsNullOrWhiteSpace(y))).ToReactiveCommand();
            SaveCommand.Subscribe(SaveAction);
        }

        public async void SaveAction()
        {
            // todo : by pressing the Enter key

            var result = await WorkTaskService.RegistWorkTaskAsync(Answer.Value);
            if (result)
            {
                Answer.Value = string.Empty;
            }

            // todo : add message.
        }
    }
}
