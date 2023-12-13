namespace _3;

internal class Program
{
    static void Main(string[] args)
    {
        string[] inputLines = File.ReadAllLines(@"../../aoc3_test.txt");
        //string[] inputLines = File.ReadAllLines(@"../../aoc3_input.txt");


        int sum = 0;

        //Two dimensional array with current structure.
        //item at coordinates x and y relate to inputLines[y][x]

        //if this doesn't work => check input to see if there are parts connected to multiple special characters. 
        sum += TraverseSchematic(0,0,inputLines);
    }

    static int TraverseSchematic(int x, int y, string[] grid)
    {
        //Wraps around if x is beyond the grid
        if (x == grid[0].Length)
        {
            Console.WriteLine("");
            return TraverseSchematic(0, y + 1, grid);
        }
        //Returns 0 if y is beyond the grid. 
        if (y == grid.Length) return 0;

        Console.Write(grid[y][x]);

        //If there shouldn't be added something this iteration - then toBeAdded will remain zero. 
        int toBeAdded = 0;

        // if the specified item is a special character (indicated by $) then we search around it. 
        if (representation(grid[y][x]) == '$')
        {

            //Top row of numbers
            if (y > 0)
            {
                List<int> digits = [0];
                if (x > 0) digits.Add(findDigit(grid[y - 1], x - 1));

                digits.Add(findDigit(grid[y - 1], x));

                if (x + 1 != grid[y].Length) digits.Add(findDigit(grid[y - 1], x + 1));
                //returns unique numbers of this row. 
                toBeAdded += digits.ToHashSet().Sum();
            }
            Console.WriteLine("");

            //middle row
            if (x > 0) Console.Write(representation(grid[y][x - 1]));
            Console.Write(representation(grid[y][x]));
            if (x + 1 != grid[y].Length) Console.Write(representation(grid[y][x + 1]));

            Console.WriteLine("");
            //bottom row
            if (y + 1 != grid.Length)
            {
                if (x > 0)
                    Console.Write(representation(grid[y+1][x - 1]));

                Console.Write(representation(grid[y+1][x]));

                if (x + 1 != grid[y].Length)
                    Console.Write(representation(grid[y+1][x + 1]));
            }





            
            
            
            

        }
        return toBeAdded + TraverseSchematic(x + 1, y, grid);
    }
    public static char representation(char c) => (int)c switch
    {
        46 => '.',

        >47 and (<58) => '1',

        _ => '$'
    };

    public static int findDigit(string row, int start)
    {
        if (representation(row[start]) != '1') return 0;

        int startx=start, endx=start;
        while (startx!=0)
        {
            if (representation(row[--startx]) != '1')
            {
                startx++;
                break;
            }
            
        }
        while (endx != row.Length)
        {
            if (representation(row[++endx]) != '1') break;
        }

        string digit = row[startx..endx];

        return int.Parse(digit);
    }
}
