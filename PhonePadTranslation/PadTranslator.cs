using System.Text;

namespace PhonePadTranslation
{
    public class PadTranslator
    {
        private readonly IPreprocessor preprocessor;
        private readonly IPadValidator inputValidator;
        private readonly IParser parser;
        private readonly IDictionary dictionary;

        public PadTranslator(IPreprocessor preprocessor, IPadValidator inputValidator, IParser parser, IDictionary dictionary)
        {
            this.preprocessor = preprocessor;
            this.inputValidator = inputValidator;
            this.parser = parser;
            this.dictionary = dictionary;
        }

        public String OldPhonePad(String input)
        {
            StringBuilder result = new StringBuilder();

            var prerpocessedInput = preprocessor.Preprocess(input);
            inputValidator.ValidatePadInput(prerpocessedInput);

            var parsedInput = parser.Parse(prerpocessedInput);

            parsedInput.ForEach(tuple =>
            {
                result.Append(dictionary.Translate(tuple.Item1, tuple.Item2));
            });

            return result.ToString();
        }
    }
}
