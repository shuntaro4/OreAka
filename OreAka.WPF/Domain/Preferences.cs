using System.Runtime.Serialization;
using System.Windows.Input;

namespace OreAka.WPF.Domain
{
    [DataContract]
    public class Preferences
    {
        private readonly int nowVersion = 1;

        [DataMember]
        public int Version { get; private set; }

        [DataMember]
        public string Delimiter { get; private set; }

        [DataMember]
        public GlobalShortcut ShowHideShortcut { get; private set; }

        public Preferences(string delimiter, GlobalShortcut showHideShorcut)
        {
            Version = nowVersion;
            Delimiter = delimiter;
            ShowHideShortcut = showHideShorcut;
        }

        public static Preferences GenerateDefault()
        {
            var result = new Preferences(",", new GlobalShortcut(ModifierKeys.Control | ModifierKeys.Shift, Key.Space));
            return result;
        }
    }
}
