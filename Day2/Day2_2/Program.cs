var lines = File.ReadAllLines("../input");

int total = 0;

foreach (var line in lines)
{
    var minimumRequired = new Dictionary<string, int> {
        {"red", 0},
        {"green", 0},
        {"blue", 0}
    };

    // Game 1: [.....; .......; .....; ......]
    // => ([x ..., y ...], [x ..., y ...])
    var drops = line.Split(':')[1].Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    foreach (var drop in drops)
    {
        // => [x ...], [y ...]
        var colors = drop.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        foreach (var color in colors)
        {
            // => ([x], [...])
            var amountAndColor = color.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // simply find out the max
            minimumRequired[amountAndColor[1]] = Math.Max(minimumRequired[amountAndColor[1]], int.Parse(amountAndColor[0]));
        }
    }

    // could have used a cool lambda thing but idk lazy tbh
    total += minimumRequired["red"] * minimumRequired["green"] * minimumRequired["blue"];
}

Console.WriteLine(total);