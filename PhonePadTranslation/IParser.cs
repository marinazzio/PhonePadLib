namespace PhonePadTranslation
{
    public interface IParser
    {
        public List<(char, int)> Parse(String input);
    }
}
