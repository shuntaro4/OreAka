﻿using OreAka.WPF.ApplicationService;
using Prism.Mvvm;
using Reactive.Bindings;
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

        [Dependency]
        public IWorkTaskService WorkTaskService { get; set; }

        public MainWindowViewModel()
        {
            SaveCommand = new[] { Answer }.CombineLatest(x => x.All(y => !string.IsNullOrWhiteSpace(y))).ToReactiveCommand();
            SaveCommand.Subscribe(SaveAction);
        }

        public async void SaveAction()
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
    }
}