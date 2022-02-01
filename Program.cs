using System.Collections.Generic;
using System.Linq;
using System;
static class Master
{
	static BarGraph graph = new(new int[] { 9, 5, 2, 6 });
	static void Main()
	{
		Console.WriteLine($"9526");
		foreach (Unnamed i in graph.Data.ToArray()) Console.Write(i.Value);
	}
}
//public sealed class PointGraph : Graph
//{
//
//}
public sealed class BarGraph : Graph
{
	public BarGraph(int[] values) : base(values) { }
	public override object Convert<T>()
	{
		Type type = typeof(T);
		if (type == typeof(BarGraph)) return this;
		// Add more types here
		else throw new InvalidCastException();
	}
	public override string ToString() => throw new NotImplementedException();
}
public abstract class Graph
{
	public Graph(List<int> data)
	{
		foreach (int i in data) Data.Add(new Unnamed(i, null));
		Update();
	}
	public Graph(int[] data) : this(data.ToList()) { }
	// Data Argument Transfer
	public List<Unnamed> Data = new();
	public void Add(int value)
	{
		Data.Add(new Unnamed(value, null));
		Update();
	}
	public virtual Unnamed this[int index] => Data[index];
	// Methods
	public void Update()
	{
		Sort();
		UpdateLengths();
	}
	protected void UpdateLengths()
	{
		//Take the array of values in Data, and spread them as a byte ranging from 1-10
	}
	protected void Sort()
	{
		for (int i = 0; i > Data.Count; i++)
			if (Data[i].Value > Data[i + 1].Value)
			{
				int[] tempVars = {Data[i].Value, Data[i++].Value };
				Data[i] = new Unnamed(tempVars[0], null);
				Data[i++] = new Unnamed(tempVars[1], null);
				i = -1;
			}
	}
	public override abstract string ToString();
	public abstract object Convert<T>() where T : Graph;

}
public struct Unnamed
{
	public int Value;
	public byte? Length;
	public Unnamed(int value, byte? length)
	{
		Value = value;
		Length = length;
	}
}
