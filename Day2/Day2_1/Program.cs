var lines = File.ReadAllLines("../input");

var MAX_VALUES = new Dictionary<string, int> {
    {"red", 12},
    {"green", 13},
    {"blue", 14}
};

// triangular number : n + n-1 + n-2 + ... + 1
int total = lines.Length * (lines.Length + 1) / 2;

for (int i = 0; i < lines.Length; i++)
{
    // this is gonna be a umm... i forgot the name of this type of algorithms
    bool dropped = false;

    // Game 1: [.....; .......; .....; ......]
    // => ([x ..., y ...], [x ..., y ...])
    var drops = lines[i].Split(':')[1].Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    for (int j = 0; !dropped && j < drops.Length; j++)
    {
        // => [x ...], [y ...]
        var colors = drops[j].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        for (int k = 0; !dropped && k < colors.Length; k++)
        {
            // => ([x], [...])
            var amountAndColor = colors[k].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (MAX_VALUES[amountAndColor[1]] < int.Parse(amountAndColor[0]))
            {
                // we can just skip to the next line
                dropped = true;

                // instead of adding the IDs that are good, we substract the IDs that aren't
                total -= i + 1;
            }
        }
    }
}

Console.WriteLine(total);