using System;
namespace Graphing;
public sealed class BarGraph : Graph
{
	public BarGraph(uint height = 10) : base(height) { }
	public BarGraph(int[] values) : base(values) { }
	public override object Convert<T>()
	{
		Type type = typeof(T);
		if (type == typeof(BarGraph)) return this;
		// Add more types here
		else throw new InvalidCastException();
	}
	public override string ToString()
	{
		string output = "", lineReadonly = "line-{0}) ", line;
		for (uint i = HeightLength; i > 0; i--)
		{
			byte heightLengthLength = (byte)(HeightLength.ToString().Length + lineReadonly.Replace("{0}", "").Length);
			line = lineReadonly.Replace("{0}", i.ToString());
			while (line.Length < heightLengthLength)
				line += " "; // This line may not work, due to it being a single string instead of a line
			for (int ii = 0; ii < Data.Count; ii++)
			{
				line += $"-{(Data[ii].Length >= i ? "#" : "-")}-";
			}
			output += $"{line}\n";
		}
		return output;
	}
	public string BaseString() => base.ToString();
}