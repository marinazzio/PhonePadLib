using System.Text;

namespace PhonePadTranslation
{
    public class PadTranslator
    {
        private readonly IPadInputPreprocessor preprocessor;
        private readonly IPadInputValidator inputValidator;
        private readonly IPadInputParser parser;
        private readonly IPadDictionary dictionary;

        public PadTranslator()
        {
            preprocessor = new PadInputPreprocessor();
            inputValidator = new PadInputValidator();
            parser = new PadInputParser();
            dictionary = new PadDictionary();
        }

        public PadTranslator(IPadInputPreprocessor preprocessor, IPadInputValidator inputValidator, IPadInputParser parser, IPadDictionary dictionary)
        {
            this.preprocessor = preprocessor;
            this.inputValidator = inputValidator;
            this.parser = parser;
            this.dictionary = dictionary;
        }

        public string OldPhonePad(string input)
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
