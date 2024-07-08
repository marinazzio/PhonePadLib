namespace PhonePadTranslation
{
    public interface IPreprocessor
    {
        public string Preprocess();
        public string Preprocess(string inputString);
    }
}
