namespace Graphing;
public struct GraphLine
{
	public double Value;
	public uint? Length;
	public GraphLine(double value, uint? length)
	{
		Value = value;
		Length = length;
	}
	public override string ToString() => $"Value: {Value}, Length: {(Length == null ? "Null" : Length)}";
}