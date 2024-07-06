using System.ComponentModel;

namespace PhonePadTranslation
{
    public class PadTranslator
    {
        private readonly IPreprocessor preprocessor;
        private readonly IPadValidator inputValidator;

        public PadTranslator(IPreprocessor preprocessor, IPadValidator inputValidator)
        {
            this.preprocessor = preprocessor;
            this.inputValidator = inputValidator;
        }

        public String OldPhonePad(String input)
        {
            var prerpocessedInput = preprocessor.Preprocess(input);
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
