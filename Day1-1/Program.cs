namespace Day1
{
    class Program
    {
        // I'm literally just starting out .NET and C# for the first time
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input");

            int total = 0;

            foreach (string line in lines)
            {
                int lo = 0;
                int hi = line.Length - 1;
                int a = -1, b = -1;

                try {
                    while (!Char.IsDigit(line[lo])) lo++;
                    a = line[lo] - '0';
                    while (!Char.IsDigit(line[hi])) hi--;
                    b = line[hi] - '0';
                } catch (IndexOutOfRangeException) {
                    Console.Error.WriteLine("ligne fautive : " + line);
                }

                total += a * 10 + b;
            }

            Console.WriteLine(total);

        }
    }
}