namespace PhonePadTranslation
{
    public class PadTranslator
    {
        private readonly IPreprocessor preprocessor;
        private readonly IPadValidator inputValidator;
        private readonly IParser parser;

        public PadTranslator(IPreprocessor preprocessor, IPadValidator inputValidator, IParser parser)
        {
            this.preprocessor = preprocessor;
            this.inputValidator = inputValidator;
            this.parser = parser;
        }

        public String OldPhonePad(String input)
        {
            var prerpocessedInput = preprocessor.Preprocess(input);
            inputValidator.ValidatePadInput(prerpocessedInput);

            var parsedInput = parser.Parse(prerpocessedInput);

            return "C";
        }
    }
}
