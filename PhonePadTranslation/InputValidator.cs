using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonePadTranslation
{
    public class InputValidator : IPadValidator
    {
        public void ValidatePadInput(String input)
        {
            validateEmpty(input);
            validateEnding(input);
        }

        private void validateEmpty(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty");
            }
        }

        private void validateEnding(String input)
        {
            if (!input.EndsWith("#"))
            {
                throw new ArgumentException("Input must end with #");
            }
        }
    }
}
