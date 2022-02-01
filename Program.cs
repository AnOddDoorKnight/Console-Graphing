using System.Collections.Generic;
using System.Linq;
using System;
static class Master
{
	static BarGraph graph = new(new int[] { });
	static void Main()
	{
		Random Random = new Random();
		graph.HeightLength = 9;
		int ii = Random.Next(2, 15);
		for(int i = 0; i != ii; i++) graph.Add(Random.Next(2, 32));
		
		Console.WriteLine($"{graph}{graph.BaseString()}");
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
	public override string ToString() 
	{
		string output = "", line = "line-{0}";
		for (uint i = HeightLength; i > 0; i--) 
		{
			output += $"{line.Replace("{0}", i.ToString())}) ";
			for (int ii = 0; ii < Data.Count; ii++)
			{
				output += $"-{(Data[ii].Length >= i ? "#" : "-")}-";
			}
			output += "\n";
		}
		return output;
	}
	public string BaseString() => base.ToString();
}
public abstract class Graph
{
	public List<Unnamed> Data = new();
	private uint _heightL;
	public uint HeightLength { get => _heightL; set { _heightL = value; Update(); } }
	// Constructors
	public Graph(uint height = 10) { _heightL = height; }
	public Graph(List<int> data, uint height = 10)
	{
		_heightL = height;
		foreach (int i in data) Data.Add(new Unnamed(i, null));
		Update();
	}
	public Graph(int[] data, uint height = 10) : this(data.ToList(), height) { }
	public void Add(int value)
	{
		Data.Add(new Unnamed(value, null));
		Update();
	}
	public virtual Unnamed this[int index] => Data[index];
	// Methods
	public void Update()
	{
		if (Data.Count == 0) return;
		Sort();
		UpdateLengths();
	}
	protected void UpdateLengths()
	{
		if (Data.Count == 0) return;
		double largest = Data[^1].Value, 
			smallest = Data[0].Value, 
			height = largest - smallest;
		Data[^1] = new Unnamed((int)largest, HeightLength);
		Data[0] = new Unnamed((int)smallest, 0);
		double percentagePerPoint = 1d / height;
		// It starts at smallest instead of zero, hence height
		for (int i = 1; i < Data.Count - 1; i++)
		{
			Data[i] = new Unnamed(Data[i].Value, (byte)Math.Truncate((Data[i].Value / (double)height) * HeightLength));
			if (Data[i].Length > HeightLength) throw new IndexOutOfRangeException($"Number is too high: {Data[i].Length} > {HeightLength}, index of {i} out of {Data.Count}. {smallest} as lowest, {largest} as highest, {height} as cap");
		}
		
	}
	protected void Sort()
	{
		double[] values = new double[Data.Count];
		for (int i = 0; i < values.Length; i++) values[i] = Data[i].Value;
		Array.Sort<double>(values);
		for (int i = 0; i < values.Length; i++) Data[i] = new Unnamed(values[i], null);
	}
	public override string ToString()
	{
		string output = "Using Default String...\n";
		foreach (Unnamed i in Data) output += $"{i.ToString()}\n";
		return output;
	}
	public abstract object Convert<T>() where T : Graph;
	protected static T Convert<T>(bool True) where T : Graph
	{
		throw new NotImplementedException();	
	}
}
public struct Unnamed
{
	public double Value;
	public uint? Length;
	public Unnamed(double value, uint? length)
	{
		Value = value;
		Length = length;
	}
	public override string ToString() => $"Value: {Value}, Length: {(Length == null ? "Null" : Length)}";
}
