using System.Runtime.Serialization;
using System.Windows.Input;

namespace OreAka.WPF.Domain
{
    [DataContract]
    public class Preferences
    {
        [DataMember]
        public int Version { get; private set; }

        [DataMember]
        public string Delimiter { get; private set; }

        [DataMember]
        public GlobalShortcut ShowHideShortcut { get; private set; }

        public Preferences(int version, string delimiter, GlobalShortcut showHideShorcut)
        {
            Version = version;
            Delimiter = delimiter;
            ShowHideShortcut = showHideShorcut;
        }

        public static Preferences GenerateDefault()
        {
            var result = new Preferences(1, ",", new GlobalShortcut(ModifierKeys.Control | ModifierKeys.Shift, Key.Space));
            return result;
        }
    }
}
