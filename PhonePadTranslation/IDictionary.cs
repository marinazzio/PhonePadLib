using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonePadTranslation
{
    public interface IDictionary
    {
        public char Translate(char digit, int position);
    }
}
