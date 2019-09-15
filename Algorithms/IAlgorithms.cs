using System;
using System.Collections.Generic;

namespace Algorithms
{
    public interface IAlgorithms
    {
        int GetVowelsCount(string text);
        int GetDiffMinutes(DateTime startDate, DateTime endDate);
        string GetReverseString(string text);
        List<string> GetFizzBuzzList();
        char[] GetCharacterArrayRepeated(string textA, string textB);
        double ComputePiValue();
        string CompressString(string text);
    }
}
