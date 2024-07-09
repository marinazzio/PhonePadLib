using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    /// <summary>
    /// Parser for the validated input string.
    ///
    /// It uses spaces or symbol change in sequence to split the input string into a list of tuples.
    /// </summary>
    public class PadInputParser : IPadInputParser
    {
        private readonly string SPLIT_REGEX = @"([\w*])\1*|\s+";

        private readonly List<(char, int)> result;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PadInputParser()
        {
            result = [];
        }

        /// <summary>
        /// Main parsing method.
        /// </summary>
        /// <param name="input">Validated input string.</param>
        /// <returns>List of tuples for further using with the dictionary.</returns>
        public List<(char, int)> Parse(string input)
        {
            var matches = Regex.Matches(input, SPLIT_REGEX);

            matches.ToList().ForEach(match =>
            {
                var value = match.Value;
                var count = value.Length;

                if (value == "*")
                {
                    backspace();
                }
                else if (value != " ")
                {
                    result.Add((value[0], count));
                }
            });

            return result;
        }

        private void backspace()
        {
            if (result.Count > 0)
            {
                result.RemoveAt(result.Count - 1);
            }
        }
    }
}
