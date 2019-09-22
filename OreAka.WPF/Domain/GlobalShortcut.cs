using System.Runtime.Serialization;
using System.Windows.Input;

namespace OreAka.WPF.Domain
{
    [DataContract]
    public class GlobalShortcut
    {
        [DataMember]
        public ModifierKeys ModifierKeys { get; private set; }

        [DataMember]
        public Key Key { get; private set; }

        public GlobalShortcut(ModifierKeys modifierKeys, Key key)
        {
            ModifierKeys = modifierKeys;
            Key = key;
        }
    }
}
