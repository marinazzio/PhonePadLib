namespace PhonePadTranslation
{
    /// <summary>
    /// Dictionary for translating input sequences into characters.
    /// </summary>
    public class PadDictionary : IPadDictionary
    {
        private static readonly Dictionary<char, char[]> charsMatrix = new Dictionary<char, char[]>
            {
                { '1', new char[] { '&', '\'', '(' } },
                { '2', new char[] { 'A', 'B', 'C' } },
                { '3', new char[] { 'D', 'E', 'F' } },
                { '4', new char[] { 'G', 'H', 'I' } },
                { '5', new char[] { 'J', 'K', 'L' } },
                { '6', new char[] { 'M', 'N', 'O' } },
                { '7', new char[] { 'P', 'Q', 'R', 'S' } },
                { '8', new char[] { 'T', 'U', 'V' } },
                { '9', new char[] { 'W', 'X', 'Y', 'Z' } },
                { '0', new char[] { ' ' } }
            };

        /// <summary>
        /// Translates a given digit and position into a corresponding character.
        /// </summary>
        /// <param name="digit">Pad digit where required symbol is located.</param>
        /// <param name="position">Position of the character in the translation matrix.</param>
        /// <returns>Translated character.</returns>
        public char Translate(char digit, int position)
        {
            return charsMatrix[digit][position - 1];
        }
    }
}
