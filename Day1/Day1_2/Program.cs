var lines = File.ReadLines("../input");
int total = 0;
foreach (string line in lines) {
    int[] lowestIdx = Enumerable.Repeat(int.MaxValue, 10).ToArray();
    int[] highestIdx = Enumerable.Repeat(-1, 10).ToArray();
    string[] digitToStr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    for (int i = 0; i < 10; i++) {
        int lowestDig = line.Contains(i.ToString()) ? line.IndexOf(i.ToString()) : int.MaxValue;
        int lowestStr = line.Contains(digitToStr[i]) ? line.IndexOf(digitToStr[i]) : int.MaxValue;
        int highestDig = line.Contains(i.ToString()) ? line.LastIndexOf(i.ToString()) : -1;
        int highestStr = line.Contains(digitToStr[i]) ? line.LastIndexOf(digitToStr[i]) : -1;
        lowestIdx[i] = Math.Min(Math.Min(lowestIdx[i], lowestDig), lowestStr);
        highestIdx[i] = Math.Max(Math.Max(highestIdx[i], highestDig), highestStr);
    }
    int a = Array.IndexOf(lowestIdx, lowestIdx.Min());
    int b = Array.IndexOf(highestIdx, highestIdx.Max());
    total += a * 10 + b;
}
Console.WriteLine(total);