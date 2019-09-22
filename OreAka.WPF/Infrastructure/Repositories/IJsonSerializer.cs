namespace OreAka.WPF.Infrastructure.Repositories
{
    public interface IJsonSerializer
    {
        string Serialize(object target);

        T Desirialize<T>(string json);
    }
}
