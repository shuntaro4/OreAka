﻿
using OreAka.WPF.ApplicationService;
using OreAka.WPF.Domain;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Unity.Attributes;

namespace OreAka.WPF.Presentation.ViewModels
{
    public class PreferencesWindowViewModel : BindableBase
    {
        [Dependency]
        public IPreferencesService PreferencesService { get; set; }

        [Dependency]
        public IAppThemeService AppThemeService { get; set; }

        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("OreAka - Preference");

        public ReactiveProperty<string> Delimiter { get; set; } = new ReactiveProperty<string>(",");

        public ReactiveProperty<string> Message { get; set; } = new ReactiveProperty<string>("");

        public ReactiveProperty<Brush> MessageColor { get; set; } = new ReactiveProperty<Brush>(Brushes.GreenYellow);

        public ReactiveCommand LoadedCommand { get; }

        public ReactiveCommand DelimiterDefaultCommand { get; }

        public ReactiveCommand SaveCommand { get; }

        public ReactiveCommand SelectionChangedCommand { get; }

        public ReactiveCommand ClosedCommand { get; }

        public ReactiveCollection<ModifierKeys> ModifierKey1 { get; set; }

        public ReactiveProperty<ModifierKeys> SelectedModifierKey1 { get; set; } = new ReactiveProperty<ModifierKeys>(ModifierKeys.None);

        public ReactiveCollection<ModifierKeys> ModifierKey2 { get; set; }

        public ReactiveProperty<ModifierKeys> SelectedModifierKey2 { get; set; } = new ReactiveProperty<ModifierKeys>(ModifierKeys.None);

        public ReactiveCollection<Key> Keys { get; set; }

        public ReactiveProperty<Key> SelectedKey { get; set; } = new ReactiveProperty<Key>(Key.None);

        public ReactiveCollection<string> ThemeNames { get; set; }

        public ReactiveProperty<string> SelectedTheme { get; set; } = new ReactiveProperty<string>(AppTheme.GenerateDefault().ThemeName);

        public ReactiveProperty<bool> AutoLaunch { get; set; } = new ReactiveProperty<bool>(false);

        public PreferencesWindowViewModel()
        {
            LoadedCommand = new ReactiveCommand();
            LoadedCommand.Subscribe(LoadedAction);

            DelimiterDefaultCommand = new ReactiveCommand();
            DelimiterDefaultCommand.Subscribe(DelimiterDefaultAction);

            SaveCommand = new ReactiveCommand();
            SaveCommand.Subscribe(SaveAction);

            SelectionChangedCommand = new ReactiveCommand();
            SelectionChangedCommand.Subscribe(SelectionChangedAction);

            ClosedCommand = new ReactiveCommand();
            ClosedCommand.Subscribe(ClosedAction);

            ModifierKey1 = new ReactiveCollection<ModifierKeys>
            {
                ModifierKeys.None,
                ModifierKeys.Alt,
                ModifierKeys.Control,
                ModifierKeys.Shift
            };

            ModifierKey2 = new ReactiveCollection<ModifierKeys>
            {
                ModifierKeys.None,
                ModifierKeys.Alt,
                ModifierKeys.Control,
                ModifierKeys.Shift
            };

            Keys = new ReactiveCollection<Key>()
            {
                Key.None,
                Key.Space
            };

            ThemeNames = new ReactiveCollection<string>
            {
                AppTheme.GenerateDarkTheme().ThemeName,
                AppTheme.GenerateLightTheme().ThemeName
            };
        }

        private void ClosedAction(object obj)
        {
            AppThemeService.LoadTheme();
        }

        private void SelectionChangedAction(object obj)
        {
            AppThemeService.ChangeTheme(SelectedTheme.Value);
        }

        private void LoadedAction()
        {
            var preferences = PreferencesService.GetPreferences();
            Delimiter.Value = preferences.Delimiter;

            var count = 1;
            foreach (var modifierKey in ModifierKey1.Where(x => x != ModifierKeys.None && preferences.ShowHideShortcut.ModifierKeys.HasFlag(x)))
            {
                if (count == 1)
                {
                    var modifierKeyIndex = ModifierKey1.IndexOf(modifierKey);
                    SelectedModifierKey1.Value = modifierKeyIndex < 0 ? ModifierKeys.None : ModifierKey1[modifierKeyIndex];
                }
                if (count == 2)
                {
                    var modifierKeyIndex = ModifierKey2.IndexOf(modifierKey);
                    SelectedModifierKey2.Value = modifierKeyIndex < 0 ? ModifierKeys.None : ModifierKey2[modifierKeyIndex];
                    break;
                }
                count++;
            }

            var keyIndex = Keys.IndexOf(preferences.ShowHideShortcut.Key);
            SelectedKey.Value = keyIndex < 0 ? Key.None : Keys[keyIndex];

            Delimiter.Subscribe(_ => ClearMessage());
            SelectedModifierKey1.Subscribe(_ => ClearMessage());
            SelectedModifierKey2.Subscribe(_ => ClearMessage());
            SelectedKey.Subscribe(_ => ClearMessage());
            SelectedTheme.Subscribe(_ => ClearMessage());
            AutoLaunch.Subscribe(_ => ClearMessage());

            var themeIndex = ThemeNames.IndexOf(preferences.ThemeName);
            SelectedTheme.Value = themeIndex < 0 ? AppTheme.GenerateDefault().ThemeName : ThemeNames[themeIndex];

            AutoLaunch.Value = preferences.AutoLaunch;
        }

        public void DelimiterDefaultAction()
        {
            var defaultPreferences = PreferencesService.GetDefaultPreferences();
            Delimiter.Value = defaultPreferences.Delimiter;
        }

        public void SaveAction()
        {
            PreferencesService.SavePreferences(
                Delimiter.Value,
                SelectedModifierKey1.Value | SelectedModifierKey2.Value, SelectedKey.Value,
                SelectedTheme.Value,
                AutoLaunch.Value);

            Message.Value = "Save Completed :)";
            MessageColor.Value = AppThemeService.GetCurrentTheme().IsDarkTheme ? Brushes.GreenYellow : Brushes.Green;
        }

        public void ClearMessage()
        {
            Message.Value = "";
        }
    }
}
