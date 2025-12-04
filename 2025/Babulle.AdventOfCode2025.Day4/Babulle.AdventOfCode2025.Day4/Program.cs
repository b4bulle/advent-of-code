using System.Text;

var lines = File.ReadAllLines("input.txt");

var lineCount = lines.Length;
var lineSize = lines[0].Length;

var result = 0;
var iterationResult = 1;
var iterations = 0;

using (var fileStream = File.Open("output.txt", FileMode.Create))
using (var writer = new StreamWriter(fileStream))
{
    while (iterationResult != 0)
    {
        ++iterations;
        writer.WriteLine(iterations);
        iterationResult = 0;
        var table = new int[lineCount, lineSize];

        for (var i = 0; i < lineCount; ++i)
        {
            for (var j = 0; j < lineSize; ++j)
            {
                if (lines[i][j] == '@')
                {
                    IncrementSurroundings(i, j, table, lineSize, lineCount);
                }
            }
        }

        for (var i = 0; i < lineCount; ++i)
        {
            var stringBuilder = new StringBuilder(lines[i]);
            
            for (var j = 0; j < lineSize; ++j)
            {
                //Console.Write(table[i, j] + "");
                if (lines[i][j] == '@')
                {
                    if (table[i, j] < 4)
                    {
                        ++iterationResult;
                        stringBuilder[j] = '.';
                    }
                }
            }
            writer.WriteLine(lines[i]);
            lines[i] = stringBuilder.ToString();
        }
        
        result += iterationResult;
        writer.WriteLine();
    }
}

Console.WriteLine(result);
return;

void IncrementSurroundings(int i1, int i2, int[,] ints, int lineSize1, int lineCount1)
{
    if (i1 > 0 && i2 > 0)
    {
        ++ints[i1 - 1, i2 - 1];
    }

    if (i1 > 0)
    {
        ++ints[i1 - 1, i2];
    }

    if (i1 > 0 && i2 < lineSize1 - 1)
    {
        ++ints[i1 - 1, i2 + 1];
    }

    if (i2 > 0)
    {
        ++ints[i1, i2 - 1];
    }

    if (i2 < lineSize1 - 1)
    {
        ++ints[i1, i2 + 1];
    }

    if (i1 < lineCount1 - 1 && i2 > 0)
    {
        ++ints[i1 + 1, i2 - 1];
    }

    if (i1 < lineCount1 - 1)
    {
        ++ints[i1 + 1, i2];
    }

    if (i1 < lineCount1 - 1 && i2 < lineSize1 - 1)
    {
        ++ints[i1 + 1, i2 + 1];
    }
}