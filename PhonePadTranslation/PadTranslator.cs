using System.ComponentModel;

namespace PhonePadTranslation
{
    public class PadTranslator
    {
        private readonly InputValidator inputValidator;

        public PadTranslator(InputValidator inputValidator)
        {
            this.inputValidator = inputValidator;
        }

        public String OldPhonePad(String input)
        {
            inputValidator.ValidatePadInput(input);
            
            return "C";
        }

        private void ValidateInput(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty");
            }

            if (!input.EndsWith("#"))
            {
                throw new ArgumentException("Input must end with #");
            }
        }
    }
}
