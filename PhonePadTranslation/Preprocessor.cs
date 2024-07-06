using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    public class Preprocessor : IPreprocessor
    {
        private readonly char TERMINATOR = '#';

        public string Preprocess(string input)
        {
            validateInput(input);

            var result = compactSpaces(input);

            var terminatorIndex = result.IndexOf(TERMINATOR);

            if (terminatorIndex >= 0)
            {
                result = result.Substring(0, terminatorIndex + 1);
            }

            return result;
        }

        private void validateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new System.ArgumentException("Input cannot be empty");
            }
        }

        private string compactSpaces(string input)
        {
            bool endsWithTerminator = input.EndsWith(TERMINATOR);

            var result = input.TrimEnd(TERMINATOR).Trim();

            result = Regex.Replace(result, @"\s+", " ");

            if (endsWithTerminator)
            {
                result = result + TERMINATOR;
            }

            return result;
        }
    }
}
