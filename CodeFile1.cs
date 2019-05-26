using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


public class program
{
    public static int[] FindPatterns(string pattern, string text)
    {
        int[] P = PreparePTab(pattern);
        List<int> resTab = new List<int>();
        for (int i = 0, j = 0; i < text.Length; i += Math.Max(1, j - P[j]))
        {
            for (j = P[j]; j < pattern.Length && pattern[j] == text[j + i]; ++j) ;
            if (j == pattern.Length) resTab.Add(i);
        }
        return resTab.ToArray();

        //-----------------help_func:
        int[] PreparePTab(string _pattern)
        {
            int[] _P = new int[_pattern.Length + 1];
            int _t = 0;
            for(int _i = 2; _i <= _pattern.Length; _i++)
            {
                while (_t > 0 && _pattern[_t] != _pattern[_i - 1])
                    _t = _P[_t];
                if (_pattern[_t] == pattern[_i- 1]) ++_t;
                _P[_i] = _t;
            }
            return _P;
        }
    }
    public static void Main()
    {
        string pattern = "aabaabaaabab";
        string text = "aabaabaaababasdfsadfsfaabaabaaabab";
        int[] tab = FindPatterns(pattern, text);
        foreach(int i in tab)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
    }
}