using OreAka.WPF.Domain;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public interface IPreferencesRepository
    {
        bool Exists();

        void New();

        Preferences All();

        void Save(Preferences preferences);
    }
}
