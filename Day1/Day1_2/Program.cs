var lines = File.ReadLines("../input");

int total = 0;
foreach (string line in lines)
{
    // only ten possible digits to find, no need to do a map
    // will store the lowest index of each digit
    int[] lowestIdx = Enumerable.Repeat(int.MaxValue, 10).ToArray();
    int[] highestIdx = Enumerable.Repeat(-1, 10).ToArray();

    // just a translation map
    string[] digitToStr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    // we'll go look for each digit.
    for (int i = 0; i < 10; i++)
    {
        // get the first appearance of "i" both as a digit and as a string
        int lowestDig = line.Contains(i.ToString()) ? line.IndexOf(i.ToString()) : int.MaxValue;
        int lowestStr = line.Contains(digitToStr[i]) ? line.IndexOf(digitToStr[i]) : int.MaxValue;

        // then its latest appearance
        int highestDig = line.Contains(i.ToString()) ? line.LastIndexOf(i.ToString()) : -1;
        int highestStr = line.Contains(digitToStr[i]) ? line.LastIndexOf(digitToStr[i]) : -1;

        // and then we set in our array whichever is the low/highest, the digit or the string
        lowestIdx[i] = Math.Min(lowestDig, lowestStr);
        highestIdx[i] = Math.Max(highestDig, highestStr);
    }

    // we find which digit appeared first/last
    int a = Array.IndexOf(lowestIdx, lowestIdx.Min());
    int b = Array.IndexOf(highestIdx, highestIdx.Max());

    // and we compute the actual number
    total += a * 10 + b;
}
Console.WriteLine(total);