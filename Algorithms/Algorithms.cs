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

        /// <summary>
        /// Get an array of characters repeated between 2 strings
        /// </summary>
        /// <param name="textA"></param>
        /// <param name="textB"></param>
        /// <returns></returns>
        public char[] GetCharacterArrayRepeated(string textA, string textB)
        {
            List<char> characterRepeatedList = new List<char>();
            if (textA != textB)
            {
                char[] textee = textA.Distinct().ToArray();
                char[] textbB = textB.Distinct().ToArray();
                for (int index1 = 0; index1 < textee.Length; index1++)
                {
                    for (int index2 = 0; index2 < textbB.Length; index2++)
                    {
                        if (textee[index1] == textbB[index2])
                        {
                            characterRepeatedList.Add(textee[index1]);
                        }
                    }
                }

            }
            return characterRepeatedList.ToArray();
        }

        /// <summary>
        /// Compute PI
        /// </summary>
        /// <returns></returns>
        public double ComputePiValue()
        {
            int limit = 1000000;
            int start = 1;
            double result = 0;
            for (int iteration = start; iteration <= limit; iteration++)
            {
                double numerator = Math.Pow(-1, (iteration + 1));
                double denominator = (2 * iteration) - 1;
                result += (numerator / denominator);
            }
            result *= 4;
            return result;
        }

        /// <summary>
        /// Compress an string. e.g "aabcccccaaa" would become "a2b1c5a3"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string CompressString(string text)
        {
            char[] charArray = text.ToArray();
            int count = 1;
            string output = "";
            for (int index = 0; index < charArray.Length; index++)// c in charArray)
            {
                if (index < charArray.Length - 1 && charArray[index] == charArray[index + 1])
                {
                    count++;
                }
                else
                {
                    output += $"{charArray[index]}{count}";
                    count = 1;
                }
            }
            return output.Count() < text.Count() ? output : text;
        }
    }
}
