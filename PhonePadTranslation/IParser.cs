namespace PhonePadTranslation
{
    public interface IParser
    {
        public List<Tuple<char, int>> Parse(String input);
    }
}
