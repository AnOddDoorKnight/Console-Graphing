namespace Graphing;

using System;
using System.Text;

public sealed class BarGraph : Graph
{
	public BarGraph(params double[] data) : base(data)
	{

	}
	public override void DisplayContents()
	{
		int columnLength = (int)((float)Console.BufferWidth / (float)data.Count);
		if (columnLength < 1)
			throw new Exception($"{nameof(columnLength)} is less than 1 due to" +
			$"Console Width of {Console.BufferWidth} is smaller than data" + 
			$"count of {data.Count}");
		int leftSideLength = (int)((float)columnLength / 2),
			rightSideLength = columnLength - leftSideLength;
		const char active = '@', inactive = '_', background = '.';
		StringBuilder output = new();
		for (int i = WindowHeight; i > 0; i--)
		{
			for (int ii = 0; i < data.Count; ii++)
			{
				output.Append(new string(background, leftSideLength));
				output.Append(lengths[ii] <= i ? active : inactive);
				output.Append(new string(background, rightSideLength));
			}
			output.Append('\n');
		}
		Console.WriteLine(output.ToString());
	}
}