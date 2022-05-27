namespace Graphing;

using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Graph
{
	public EventList<double> data = new();
	protected List<int> lengths = new();

	private int windowHeight = 10;
	public int WindowHeight 
	{ 
		get => windowHeight; 
		set { windowHeight = value; UpdateLengths(); }
	}
	
	private Graph()
	{
		data.ModifiedItem += (sender, args) => { UpdateLengths(); };
		data.AddedItem += (sender, args) => { UpdateLengths(); };
		data.RemovedAtItem += (sender, args) => { UpdateLengths(); };
	}
	public Graph(params double[] data) : this()
	{
		foreach (double i in data)
			this.data.Add(i);
	}

	public void UpdateLengths()
	{
		lengths.Clear();
		data.Sort();
		double difference = (data[^1] - data[0]) / windowHeight,
			min = data[0];
		for (int i = 0; i < data.Count; i++)
		{
			double value = data[i] - min;
			lengths.Add((int)(value / difference));
		}
	}


	public abstract void DisplayContents();
	public override string ToString()
	{
		return base.ToString();
	}
}