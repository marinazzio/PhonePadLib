namespace PhonePadTranslation
{
    public class Preprocessor : IPreprocessor
    {
        private readonly char TERMINATOR = '#';

        public string Preprocess(string input)
        {
            var result = input;

            if (string.IsNullOrEmpty(input))
			{
				throw new System.ArgumentException("Input cannot be empty");
			}

            var terminatorIndex = input.IndexOf(TERMINATOR);

            if (terminatorIndex >= 0)
			{
				result = input.Substring(0, terminatorIndex + 1);
			}

			return result;
        }
    }
}
