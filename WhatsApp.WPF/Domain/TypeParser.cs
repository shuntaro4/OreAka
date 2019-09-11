namespace WhatsApp.WPF.Domain
{
    public class TypeParser
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
