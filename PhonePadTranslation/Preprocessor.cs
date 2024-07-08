using System.Text;
using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    public class Preprocessor : IPreprocessor
    {
        private readonly char TERMINATOR = '#';

        private string inputString;
        private StringBuilder result;

        public Preprocessor()
        {
            result = new StringBuilder();
        }

        public string Preprocess(string input)
        {
            this.inputString = input;

            validateInput();
            compactSpaces();
            trimByTerminator();

            return result.ToString();
        }

        private void validateInput()
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new System.ArgumentException("Input cannot be empty");
            }
        }

        private void compactSpaces()
        {
            bool endsWithTerminator = inputString.EndsWith(TERMINATOR);

            result.Append(
                Regex.Replace(
                    inputString.TrimEnd(TERMINATOR).Trim(),
                    @"\s+", " "
                )
            );

            if (endsWithTerminator)
            {
                result.Append(TERMINATOR);
            }
        }

        private void trimByTerminator()
        {
            var terminatorIndex = inputString.IndexOf(TERMINATOR);

            result.Append(
                terminatorIndex >= 0 ?
                    inputString.Substring(0, terminatorIndex - 1) :
                    inputString
             );
        }
    }
}
