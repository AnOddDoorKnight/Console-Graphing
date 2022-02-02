using System.Collections.Generic;
using System.Linq;
using System;
namespace Graphing;
static class Master
{
	static BarGraph graph = new();
	static Master()
	{
		Console.WindowWidth += 50;
		Console.WindowHeight += 10;
	}
	static void Main()
	{
		Random Random = new();
		graph.HeightLength = 15;
		int ii = Random.Next(2, 15);
		for (int i = 0; i != ii; i++) graph.Add(Random.Next(2, 32));

		Console.WriteLine($"{graph}{graph.BaseString()}");

	}
}
