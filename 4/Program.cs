namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] input = File.ReadAllLines("../../aoc4_input.txt");

            List<string> scratchcards = [.. File.ReadAllLines("../../aoc4_test.txt")];
            //List<string> scratchcards = [.. File.ReadAllLines("../../aoc4_input.txt")];
            //scratchcards = scratchcards[..3];
            int score = scratchcards.Count;
            int counter=0;
            for (int idx = 0; idx < scratchcards.Count; idx++)
            {
                int amountToAdd = findScore(scratchcards[idx]);
                counter++;
                score += amountToAdd;
                for (int i = idx; i < amountToAdd ; i++)
                {
                    scratchcards.Insert(idx, scratchcards[idx + i]);
                }
                Console.WriteLine(idx);
            }
            //foreach (string s in scratchcards) {

            //    int amountToAdd = findScore(s);
            //    score += amountToAdd;
            //    for(int i = 0; i<amountToAdd;i++) scratchcards.Add(s);
            //}

        }
        static int findScore(string s)
        {
            int scoreOfCard = 0;

            string trimmed = s.Substring(s.IndexOf(":"))[2..];

            string winning = trimmed.Split('|')[0];
            string your = trimmed.Split('|')[1][1..];



            List<string> winningNumbers = [.. winning.Split(' ').Where((stuff)=>!string.IsNullOrWhiteSpace(stuff))];
            List<string> yourNumbers = [.. your.Split(' ').Where((stuff) => !string.IsNullOrWhiteSpace(stuff))];

            int AmountOfWinning = 0;
            
            foreach (string num in yourNumbers)
            {
                if (winningNumbers.Contains(num))
                {
                    AmountOfWinning++;
                    continue;
                }
            }

            return AmountOfWinning;

            return (int)Math.Pow(2, AmountOfWinning - 1);
        }
    }
}
