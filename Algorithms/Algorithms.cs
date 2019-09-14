using System;
using System.Linq;

namespace Algorithms
{
    public class Algorithms : IAlgorithms
    {
        /// <summary>
        /// Count vowels in string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetVowelsCount(string text)
        {
            return text.Count(x => char.IsLetter(x) && ("aeiou").Contains(x));
        }
    }
}
