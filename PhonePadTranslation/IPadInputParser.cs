namespace PhonePadTranslation
{
    public interface IPadInputParser
    {
        public List<(char, int)> Parse(string input);
    }
}
