using System.Text.RegularExpressions;

namespace PhonePadTranslation
{
    public class Parser : IParser
    {
        private readonly string SPLIT_REGEX = @"(\w)\1*|\s+";

        public List<Tuple<char, int>> Parse(string input)
        {
            var result = new List<Tuple<char, int>>();

            var matches = Regex.Matches(input, SPLIT_REGEX);

            matches.ToList().ForEach(match =>
            {
                var value = match.Value;
                var count = value.Length;

                if (value != " ")
                {
                    result.Add(new Tuple<char, int>(value[0], count));
                }
            });

            return result;
        }
    }
}
