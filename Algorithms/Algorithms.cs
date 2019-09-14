using System;
using System.Linq;
using Algorithms.Exceptions;

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

        /// <summary>
        /// Compute the difference in minutes between 2 dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetDiffMinutes(DateTime startDate, DateTime endDate)
        {
            if (startDate < endDate)
            {
                var diff = endDate.AddTicks((-1) * startDate.Ticks).Ticks;
                return (int)TimeSpan.FromTicks(diff).TotalMinutes;
            }
            else
            {
                throw new CoreDateDiffException();
            }
        }
    }
}
