namespace _2;

internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"../../aoc2_input.txt");
        int validGames = 0;
        foreach (string line in lines)
        {
            int id = int.Parse(line.Split(": ")[0].Split("me ")[1]);
            validGames += isGameValid(line);
        }

    }


    static int isGameValid(string inputline)
    {
        string line = inputline.Split(": ")[1];

        List<string> splitted = [.. line.Split(';')];
        //Used in output;
        int r = 0, g = 0, b = 0;
        for (int i = 0; i<splitted.Count; i++)
        {
            string s = splitted[i];
            var segmented = splitted[i].Split(", ");
            

            foreach (string inputCube in segmented)
            {
                string cube = inputCube.Trim();

                int amount = int.Parse(cube.Split(' ')[0]);
                
                char color = cube.Split(' ')[1][0];

                switch (color)
                {
                    case 'r':
                        if (amount > r) r = amount;

                        //if (amount > 12) return false;
                        break;
                    case 'g':
                        if (amount > g) g = amount;
                        //if (amount > 13) return false;
                        break;
                    case 'b':
                        if (amount > b) b = amount;
                        //if (amount > 14) return false;
                        break;

                    default:
                        throw new Exception("fuck this");

                }
            }

            
        }

        if (r * g * b == 0) return 0;
        return r * g * b;
    }
}
