using System.Linq;

namespace _6;

internal class Program
{
    static void Main(string[] args)
    {

        string[] lines = File.ReadAllLines("../../aoc6_input.txt");

        string temp = "";

        //find times
        List<double> times = [];
        
        foreach (string t in lines[0].Split(": ")[1].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)) )
        {
            temp += t;
        }
        times.Add(double.Parse(temp));
        temp = "";

        //find race lengths (stage length)
        List<double> race_lengths = [];
        foreach (string t in lines[1].Split(": ")[1].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)))
        {

            temp += t;
        }
        
        race_lengths.Add(double.Parse(temp));

        temp = "";

        //calculate distances depending on initial acceleration
        List<double>[] distance = new List<double>[times.Count];
        
        for(int j = 0; j<times.Count; j++)
        {
            distance[j] = [];
            double time = times[j];

            for(int i = 0; i<time; i++)
            {
                distance[j].Add((time - i) * (i));
            }
        }

        int output = 1;

        for(int i = 0; i<distance.Length; i++)
        {
            var d = distance[i];
            int count = distance[i].Where(d => d > race_lengths[i]).Count();
            if (count>0) output *= count;
        }


        Console.WriteLine(output);
    }
}
