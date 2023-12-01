// I'm literally just starting out .NET and C# for the first time

var lines = File.ReadLines("../input");

int total = 0;

foreach (string line in lines)
{ // this is in O(2n) * m where n = lineSize and m = number of lines
    int lo = 0;
    int hi = line.Length - 1;
    int a = -1, b = -1;

    // find the first digit
    while (!Char.IsDigit(line[lo])) lo++;
    a = line[lo] - '0'; // funny char manipulation

    // find the last digit
    while (!Char.IsDigit(line[hi])) hi--;
    b = line[hi] - '0';

    // finding out the number
    total += a * 10 + b;
}

Console.WriteLine(total);