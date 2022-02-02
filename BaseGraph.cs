using System;
using System.Collections.Generic;
using System.Linq;
namespace Graphing;
public abstract class Graph
{
	public List<GraphLine> Data = new();
	private uint _heightL;
	public uint HeightLength { get => _heightL; set { _heightL = value; Update(); } }
	// Constructors
	public Graph(uint height = 10) { _heightL = height; }
	public Graph(List<int> data, uint height = 10)
	{
		_heightL = height;
		foreach (int i in data) Data.Add(new GraphLine(i, null));
		Update();
	}
	public Graph(int[] data, uint height = 10) : this(data.ToList(), height) { }
	public void Add(int value)
	{
		Data.Add(new GraphLine(value, null));
		Update();
	}
	public virtual GraphLine this[int index] => Data[index];
	// Methods
	public void Update()
	{
		if (Data.Count == 0) return;
		Sort();
		UpdateLengths();
	}
	protected void UpdateLengths()
	{
		if (Data.Count < 2) return;
		double largest = Data[^1].Value,
			smallest = Data[0].Value,
			height = largest - smallest;
		Data[0] = new GraphLine(smallest, 0);
		Data[^1] = new GraphLine(largest, HeightLength);
		List<double> accountedValues = new();
		foreach (GraphLine i in Data) accountedValues.Add(i.Value - smallest);
		double[] lengthsPerValue = new double[Data.Count];
		lengthsPerValue[0] = 0;
		lengthsPerValue[^1] = HeightLength - smallest;
		double percentagePerPoint = 1d / height;
		// It starts at smallest instead of zero, hence height
		for (int i = 1; i < Data.Count - 1; i++)
			Data[i] = new GraphLine(Data[i].Value, (uint)Math.Truncate((accountedValues[i] / (double)height) * HeightLength));
	}
	protected void Sort()
	{
		double[] values = new double[Data.Count];
		for (int i = 0; i < values.Length; i++) values[i] = Data[i].Value;
		Array.Sort(values);
		for (int i = 0; i < values.Length; i++) Data[i] = new GraphLine(values[i], null);
	}
	public override string ToString()
	{
		string output = "Using Default String...\n";
		foreach (GraphLine i in Data) output += $"{i}\n";
		return output;
	}
	public abstract object Convert<T>() where T : Graph;
	protected static T Convert<T>(bool True) where T : Graph
	{
		throw new NotImplementedException();
	}
}
