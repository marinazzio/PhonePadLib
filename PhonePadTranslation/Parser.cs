using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    public class Parser : IParser
    {
        private readonly string SPLIT_REGEX = @"([\w*])\1*|\s+";

        private List<Tuple<char, int>> result;

        public Parser()
        {
            result = new List<Tuple<char, int>>();
        }

        public List<Tuple<char, int>> Parse(string input)
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
                    result.Add(new Tuple<char, int>(value[0], count));
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
