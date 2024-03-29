﻿using OreAka.WPF.Domain;
using Xunit;

namespace OreAka.WPF.Test.Domain
{
    public class PreferencesTest
    {
        private readonly int nowVersion = 1;

        [Fact(DisplayName = "正：コンストラクタ")]
        [Trait("Preferences", "Preferences")]
        public void PreferencesTrue1()
        {
            var globalShortcut = new GlobalShortcut(System.Windows.Input.ModifierKeys.None, System.Windows.Input.Key.A);
            var actual = new Preferences(",", globalShortcut, AppTheme.GenerateDefault().ThemeName, true);

            Assert.NotNull(actual);
            Assert.Equal(nowVersion, actual.Version);
            Assert.Equal(",", actual.Delimiter);
            Assert.Equal(globalShortcut, actual.ShowHideShortcut);
            Assert.Equal("Dark.Steel", actual.ThemeName);
            Assert.True(actual.AutoLaunch);
        }


        [Fact(DisplayName = "正：デフォルト値が取得できること")]
        [Trait("Preferences", "GenerateDefault")]
        public void GenerateDefaultTrue1()
        {
            var globalShortcut = new GlobalShortcut(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Shift, System.Windows.Input.Key.Space);
            var actual = Preferences.GenerateDefault();
            Assert.NotNull(actual);
            Assert.Equal(nowVersion, actual.Version);
            Assert.Equal(",", actual.Delimiter);
            Assert.Equal(globalShortcut.ModifierKeys, actual.ShowHideShortcut.ModifierKeys);
            Assert.Equal(globalShortcut.Key, actual.ShowHideShortcut.Key);
            Assert.Equal("Dark.Steel", actual.ThemeName);
            Assert.False(actual.AutoLaunch);
        }
    }
}
