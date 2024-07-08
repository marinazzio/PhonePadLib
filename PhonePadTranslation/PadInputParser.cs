using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    public class PadInputParser : IPadInputParser
    {
        private readonly string SPLIT_REGEX = @"([\w*])\1*|\s+";

        private List<(char, int)> result;

        public PadInputParser()
        {
            result = new List<(char, int)>();
        }

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
