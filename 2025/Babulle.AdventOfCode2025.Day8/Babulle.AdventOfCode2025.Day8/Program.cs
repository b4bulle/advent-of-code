using System.Numerics;
using Babulle.AdventOfCode2025.Day8;

var lines = File.ReadAllLines("input.txt");
const int n = 1000;
var l = lines.Length;

var positions = lines.Select(line => line.Split(',')).Select(coordinates => new Vector3(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2]))).ToList();

var nodes = new List<Node>();

var groups = new List<List<int>>();

for (var i = 0; i < l; ++i)
{
    for (var j = i + 1; j < l; ++j)
    {
        var distance = Vector3.Distance(positions[i], positions[j]);
        nodes.Add(new Node(i, j, distance));
    }
}

nodes = nodes.OrderBy(node => node.Distance).ToList();

var k = 0;
var result1 = 0;
var node = new Node(0, 0, 0);

while (!(groups.Count == 1 && groups[0].Count == l))
{
    if (k == n)
    {
        result1 = groups.OrderByDescending(group => group.Count)
            .Select(group => group.Count)
            .Take(3)
            .Aggregate((a, b) => a * b);
    }
    
    node = nodes[k];
    
    var iGroup = groups.FirstOrDefault(group => group.Contains(node.I));
    var jGroup = groups.FirstOrDefault(group => group.Contains(node.J));

    if (iGroup == null && jGroup == null)
    {
        List<int> group = [node.I, node.J];
        groups.Add(group);
    }
    else if (iGroup != null && jGroup == null)
    {
        iGroup.Add(node.J);
    }
    else if (iGroup == null && jGroup != null)
    {
        jGroup.Add(node.I);
    }
    else if (iGroup != null && jGroup != null && iGroup != jGroup)
    {
        groups.Remove(jGroup);
        iGroup.AddRange(jGroup);
    }

    ++k;
}

Console.WriteLine(result1);
Console.WriteLine((int) positions[node.I].X * (int) positions[node.J].X);