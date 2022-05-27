namespace Graphing.Console;

internal static class ConsoleEntry
{
	static void Main()
	{
		Graph graph = new BarGraph(5, 2, 1, 6, 7);
		graph.DisplayContents();
	}
}