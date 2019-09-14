using System;
using System.Collections.Generic;
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

        /// <summary>
        /// reverse a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string GetReverseString(string text)
        {
            char[] charArray = text.ToArray();
            char[] result = new char[text.Count()];
            for (int i = (charArray.Length - 1); i >= 0; i--)
            {
                result[(charArray.Length - 1) - i] = charArray[i];
            }
            return string.Concat(result);
        }

        /// <summary>
        /// Get a list of numbers 1 to 200, every number divisible by 3 gets 'fizz',
        /// every number divisible by 5 gets 'buzz'
        /// every number divisible by 3 and 5 gets 'fizzbuzz'
        /// </summary>
        /// <returns></returns>
        public List<string> GetFizzBuzzList()
        {
            List<string> fizzBuzzList = new List<string>();
            int maxNumber = 200;
            int index = 1;
            do
            {
                string fizzBuzzString = index.ToString();
                if (index % 3 == 0)
                    fizzBuzzString = "fizz";
                if (index % 5 == 0)
                    fizzBuzzString = "buzz";
                if (index % 3 == 0 && index % 5 == 0)
                    fizzBuzzString = "fizzbuzz";
                fizzBuzzList.Add(fizzBuzzString);
                index++;
            } while (index <= maxNumber);
            return fizzBuzzList;
        }
    }
}
