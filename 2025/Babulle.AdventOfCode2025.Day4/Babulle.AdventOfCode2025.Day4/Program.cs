using System.Text;

var lines = File.ReadAllLines("input.txt");

var lineCount = lines.Length;
var lineSize = lines[0].Length;

var result = 0;
var iterationResult = 1;

while (iterationResult != 0)
{
    iterationResult = 0;
    var table = new int[lineCount, lineSize];

    for (var i = 0; i < lineCount; ++i)
    {
        for (var j = 0; j < lineSize; ++j)
        {
            if (lines[i][j] == '@')
            {
                if (i > 0 && j > 0)
                {
                    ++table[i - 1, j - 1];
                }

                if (i > 0)
                {
                    ++table[i - 1, j];
                }

                if (i > 0 && j < lineSize - 1)
                {
                    ++table[i - 1, j + 1];
                }

                if (j > 0)
                {
                    ++table[i, j - 1];
                }

                if (j < lineSize - 1)
                {
                    ++table[i, j + 1];
                }

                if (i < lineCount - 1 && j > 0)
                {
                    ++table[i + 1, j - 1];
                }

                if (i < lineCount - 1)
                {
                    ++table[i + 1, j];
                }

                if (i < lineCount - 1 && j < lineSize - 1)
                {
                    ++table[i + 1, j + 1];
                }
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
        //Console.WriteLine();
        lines[i] = stringBuilder.ToString();
    }
    
    result += iterationResult;
}

Console.WriteLine(result);