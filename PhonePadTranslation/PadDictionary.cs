using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonePadTranslation
{
    public class PadDictionary : IDictionary
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

        public char Translate(char digit, int position)
        {
            return charsMatrix[digit][position - 1];
        }
    }
}
