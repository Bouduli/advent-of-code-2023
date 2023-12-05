using System.Reflection;

namespace aoc_1_cs;


internal class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("../../aoc1-1_input.txt");

        List<int> digits = [];

        for(int j = 0; j < input.Length; j++)
        {
            string s = input[j];
            replacewithnumbers(ref s);
            int left = 0, right = 0;
            int OutInt;
            for(int i = 0; i<s.Length; i++)
            {
                //Find integer at index. 
                int d = (int)s[i] switch
                {
                    (> 48) and (< 58) => int.Parse(s[i].ToString()),
                    _ => 0
                };
                if (d != 0)
                {
                    if(left ==0) left= d;

                    right = d;
                    continue;
                }
                




            }
            OutInt = (int)(left * 10 + right);
            digits.Add(OutInt);
        }

        int val = digits.Sum();
    }

    public static int findInString(string s)
    {
        int length = s.Length;

        if (length < 3) return 0;

        int digit = length switch {

            3 => s[..3] switch
            {
                "one" => 1,
                "two" => 2,
                "six" => 6,
                _ => 0
            },
            4 => s[..4] switch
            {
                "one" => 1,
                "two" => 2,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "nine" => 9,
                _ => 0
            },
            5 or >5 => s[..5] switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => 0
            },
            
        };
        

        return digit;
    }

    public static void replacewithnumbers(ref string s)
    {
        s=s.Replace("one", "one1one");
        s=s.Replace("two", "two2two");
        s=s.Replace("three", "three3three");
        s=s.Replace("four", "four4four");
        s=s.Replace("five", "five5five");
        s=s.Replace("six", "six6six");
        s=s.Replace("seven", "seven7seven");
        s=s.Replace("eight", "eight8eight");
        s=s.Replace("nine", "nine9nine");
        

    }
}



