using OreAka.WPF.Domain;
using System.IO;
using Unity.Attributes;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public class PreferencesRepository : IPreferencesRepository
    {
        [Dependency]
        public IJsonSerializer JsonSerializer { get; set; }

        [Dependency]
        public IRunRegister RunRegister { get; set; }

        private string preferencesPath;

        [InjectionConstructor]
        public PreferencesRepository()
        {
            this.preferencesPath = "preferences.json";
        }

        public PreferencesRepository(string preferencesPath)
        {
            // Used in testing
            this.preferencesPath = preferencesPath;
        }

        public Preferences All()
        {
            using (var fileStream = new StreamReader(preferencesPath))
            {
                var jsonString = fileStream.ReadToEnd();
                var preferences = JsonSerializer.Desirialize<Preferences>(jsonString);
                return preferences;
            }
        }

        public bool Exists()
        {
            return File.Exists(preferencesPath);
        }

        public void New()
        {
            var preferences = Preferences.GenerateDefault();
            var jsonString = JsonSerializer.Serialize(preferences);
            using (var stream = new StreamWriter(preferencesPath, false))
            {
                stream.WriteLine(jsonString);
            }
        }

        public void Save(Preferences preferences)
        {
            var jsonString = JsonSerializer.Serialize(preferences);
            using (var stream = new StreamWriter(preferencesPath, false))
            {
                stream.WriteLine(jsonString);
            }

            RunRegister.RegistKey(preferences.AutoLaunch);
        }
    }
}
