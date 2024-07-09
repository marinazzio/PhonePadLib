using System.Text;
using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    /// <summary>
    /// Prepares the input string for further processing.
    ///
    /// Removes extra spaces and trims the string by the terminator.
    /// </summary>
    public class PadInputPreprocessor : IPadInputPreprocessor
    {
        private readonly char TERMINATOR = '#';

        private string inputString;
        private readonly StringBuilder result;

        /// <summary>
        /// Creates a new PadInputPreprocessor instance with an empty input string.
        /// </summary>
        public PadInputPreprocessor() : this(String.Empty) { }

        /// <summary>
        /// Creates a new PadInputPreprocessor instance.
        /// </summary>
        /// <param name="inputString">string value to be prepared for parser</param>
        public PadInputPreprocessor(string inputString)
        {
            this.inputString = inputString;
            this.result = new StringBuilder();
        }

        /// <summary>
        /// Checks the input string for presence, removes extra spaces and trims the string by the terminator.
        ///
        /// It doesn't actually checks the string for correctness, only prepares it for further processing.
        /// </summary>
        /// <param name="inputString">string value to be prepared for parser</param>
        /// <returns></returns>
        public string Preprocess(string inputString)
        {
            this.inputString = inputString;
            return Preprocess();
        }

        /// <summary>
        /// Checks the input string for presence, removes extra spaces and trims the string by the terminator.
        ///
        /// It doesn't actually checks the string for correctness, only prepares it for further processing.
        /// </summary>
        /// <returns>Preprocessed string; it could match the initial string</returns>
        public string Preprocess()
        {
            validateInput();
            compactSpaces();
            trimByTerminator();

            return result.ToString();
        }

        private void validateInput()
        {
            if (String.IsNullOrEmpty(inputString))
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
            int terminatorIndex = result.ToString().IndexOf(TERMINATOR);

            if (terminatorIndex >= 0)
            {
                result.Remove(terminatorIndex + 1, result.Length - terminatorIndex - 1);
            }
        }
    }
}
