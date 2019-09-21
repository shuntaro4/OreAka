namespace OreAka.WPF.Domain
{
    public class TypeParse
    {
        public static int ToInt(string target)
        {
            if (int.TryParse(target, out var result))
            {
                return result;
            }
            return 0;
        }
    }
}
