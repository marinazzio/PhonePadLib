using System.Text;

namespace PhonePadTranslation
{
    /// <summary>
    /// Main class for translating input to old phone pad
    /// </summary>
    public class PadTranslator
    {
        private readonly IPadInputPreprocessor preprocessor;
        private readonly IPadInputValidator inputValidator;
        private readonly IPadInputParser parser;
        private readonly IPadDictionary dictionary;

        /// <summary>
        /// Default constructor.
        ///
        /// Initializes all the components with default implementations.
        /// </summary>
        public PadTranslator()
        {
            preprocessor = new PadInputPreprocessor();
            inputValidator = new PadInputValidator();
            parser = new PadInputParser();
            dictionary = new PadDictionary();
        }

        /// <summary>
        /// Constructor with custom components.
        /// </summary>
        /// <param name="preprocessor">Tool for preparing the input string for further processing.</param>
        /// <param name="inputValidator">Validation workflow for the input string.</param>
        /// <param name="parser">Converts the input string to a list of tuples.</param>
        /// <param name="dictionary">Translation dictionary</param>
        public PadTranslator(IPadInputPreprocessor preprocessor, IPadInputValidator inputValidator, IPadInputParser parser, IPadDictionary dictionary)
        {
            this.preprocessor = preprocessor;
            this.inputValidator = inputValidator;
            this.parser = parser;
            this.dictionary = dictionary;
        }

        /// <summary>
        /// Main method for translating input to old phone pad.
        ///
        /// It raises exceptions in case of incorrect input.
        /// </summary>
        /// <param name="input">String input of required format.</param>
        /// <returns>Translated result.</returns>
        public string OldPhonePad(string input)
        {
            StringBuilder result = new();

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
