using System.Collections.Generic;
using System.Linq;
using System;
namespace Graphing;
static class Master
{
	static BarGraph graph = new() {HeightLength = 12};
	static Master()
	{
		Console.WindowWidth += 50;
		Console.WindowHeight += 10;
	}
	static void Main()
	{
		Dictionary<string, int> counted = new() { ["posters"] = 5, ["boards"] = 5, ["papers"] = 17, ["curtains"] = 4, ["tables"] = 8, ["childrenChairs"] = 16 };
		
	}
	static string SetRandom()
	{
		Random Random = new();
		graph.HeightLength = 15;
		int ii = Random.Next(2, 15);
		graph.Data = new();
		for (int i = 0; i != ii; i++) graph.Add(Random.Next(2, 32));
		return graph.ToString();
	}
}