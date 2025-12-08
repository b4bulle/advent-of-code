var lines = File.ReadAllLines("input.txt");

var result1 = 0;
var newState = new bool[lines[0].Length];

for (var i = 0; i < lines[0].Length; ++i)
{ 
    newState[i] = lines[0][i] == 'S';
}

foreach (var line in lines[1..])
{
    var currentState = newState;
    newState = new bool[line.Length];
    
    for (var i = 0; i < line.Length; ++i)
    {
        if (currentState[i])
        {
            if (line[i] == '^')
            {
                newState[i - 1] = true;
                newState[i + 1] = true;
                ++result1;
            }
            else
            {
                newState[i] = true;
            }
        }
    }
}

Console.WriteLine(result1);

var timelines = new long[lines[0].Length];

for (var i = 0; i < lines[0].Length; ++i)
{
    timelines[i] = 1;
}

foreach (var line in lines[1..^1].Reverse())
{
    var buffer = new long[line.Length];
    
    for (var i = 0; i < line.Length; ++i)
    {
        if (i > 0 && line[i - 1] == '^')
        {
            buffer[i - 1] += timelines[i];
        }

        if (i < line.Length - 1 && line[i + 1] == '^')
        {
            buffer[i + 1] += timelines[i];
        }

        if (line[i] != '^' )
        {
            buffer[i] += timelines[i];
        }
    }

    timelines = buffer;
}

Console.WriteLine(timelines[lines[0].IndexOf('S')]);