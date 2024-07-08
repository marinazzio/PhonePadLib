using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonePadTranslation
{
    public class InputValidator : IPadValidator
    {
        private static readonly HashSet<char> permittedChars = new HashSet<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '#', ' ', '*'
        };

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
