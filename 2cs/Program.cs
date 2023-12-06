namespace _2;

internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"../../aoc2_test.txt");

        foreach(string line in lines)
        {
            isGameValid(line);
        }

    }


    static bool isGameValid(string line)
    {
        line = line.Split(':')[1];

        List<string> splitted = [.. line.Split(';')];

        for(int i = 0; i<splitted.Count; i++)
        {
            string s = splitted[i];

            if (s.Contains("red")) s = s.Replace("red ", "r");
            else s = "r0" + s;

            if (s.Contains("green")) s = s.Replace("green ", "g");
            else if (s.Contains("red")) s = s.Insert(s.IndexOf(", ") + 1, "g0");
            
        }

        return true;
    }
}
