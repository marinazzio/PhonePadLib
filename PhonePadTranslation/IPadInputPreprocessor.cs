namespace PhonePadTranslation
{
    public interface IPadInputPreprocessor
    {
        public string Preprocess();
        public string Preprocess(string inputString);
    }
}
