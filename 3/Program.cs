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

        // if the specified item is a special character (indicated by $) then the character is 
        if (representation(grid[y][x]) == '$')
        {
            int startx = -1, endx = -1;
            //top row.
            if (y > 0)
            {
                for (int i = (x - 1); i < (x + 1); i++)
                {
                    if (representation(grid[y - 1][i]) == '1')
                    {
                        if (startx == -1) startx = i;
                        if (endx == -1) endx = i;

                        int tempx = startx;
                        while (true)
                        {
                            if (representation(grid[y - 1][tempx]) != '1' || tempx == 0)
                            {
                                startx = tempx;
                                break;
                            }

                            startx = tempx--;
                        }
                        tempx = i;
                        while (true)
                        {
                            if (tempx == grid[0].Length)
                            {
                                endx--;
                                break;
                            }
                            if (representation(grid[y - 1][tempx]) != '1') break;
                            endx = tempx++;
                        }

                        string digit = grid[y - 1][startx..(endx + 1)];
                        if ((int)digit[0] is not > 47 and < 58) digit = digit[1..];
                        int converted = int.Parse(digit);
                        if (digit != "") toBeAdded += int.Parse(digit);
                    }

                }
            }

            startx = -1;
            endx = -1;

            if (x != 0)
            {
                for (int i = (x - 1); i < (x + 1); i++)
                {
                    if (representation(grid[y][i]) == '1')
                    {
                        if (startx == -1) startx = i;
                        if (endx == -1) endx = i;

                        int tempx = startx;
                        while (true)
                        {
                            if (representation(grid[y][tempx]) != '1' || tempx == 0) break;
                            startx = tempx--;
                        }


                        string digit = grid[y - 1][startx..x];
                        int converted = int.Parse(digit);
                        if (digit != "") toBeAdded += int.Parse(digit);
                    }
                }
            }

            startx = -1;
            endx = -1;

            if (y < (grid.Length - 1))
            {
                for (int i = (x - 1); i < (x + 1); i++)
                {
                    if (representation(grid[y + 1][i]) == '1')
                    {
                        if (startx == -1) startx = i;
                        if (endx == -1) endx = i;

                        int tempx = startx;
                        while (true)
                        {
                            if (representation(grid[y + 1][tempx]) != '1' || tempx == 0) break;
                            startx = tempx--;
                        }
                        tempx = i;
                        while (true)
                        {
                            if (tempx == grid[0].Length)
                            {
                                endx--;
                                break;
                            }
                            if (representation(grid[y + 1][tempx]) != '1') break;
                            endx = tempx++;
                        }

                        string digit = grid[y + 1][startx..(endx + 1)];
                        int converted = int.Parse(digit);
                        if (digit != "") toBeAdded += int.Parse(digit);
                    }

                }
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
}
