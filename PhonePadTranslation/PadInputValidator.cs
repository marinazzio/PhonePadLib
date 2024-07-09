namespace PhonePadTranslation
{
    /// <summary>
    /// Validates pad input.
    /// </summary>
    public class PadInputValidator : IPadInputValidator
    {
        private static readonly HashSet<char> permittedChars =
        [
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '#', ' ', '*'
        ];

        /// <summary>
        /// Main validation method.
        /// 
        /// It validates input for emptyness, ending and bad symbols.
        ///
        /// It raises exceptions in case of incorrect input.
        /// </summary>
        /// <param name="input">Pad input string to validate.</param>
        public void ValidatePadInput(string input)
        {
            validateEmpty(input);
            validateEnding(input);
            validateBadSymbols(input);
        }

        private void validateEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty");
            }
        }

        private void validateEnding(string input)
        {
            if (!input.EndsWith("#"))
            {
                throw new ArgumentException("Input must end with #");
            }
        }

        private void validateBadSymbols(string input)
        {
            foreach (char c in input)
            {
                if (!permittedChars.Contains(c))
                {
                    throw new ArgumentException($"Invalid character: {c}");
                }
            }
        }
    }
}
