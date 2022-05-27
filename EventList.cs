namespace Graphing;

using System;
using System.Collections.Generic;

public class EventList<T> : List<T>
{
    public new T this[int index]
    {
        get => base[index];
        set
        {
            base[index] = value;
            ModifiedItem?.Invoke(this, (value, index));
        }
    }
    public event EventHandler<(T, int)>? ModifiedItem;

    public new void Add(T item)
    {
        base.Add(item);
        AddedItem?.Invoke(this, (item, Count - 1));
    }
    public event EventHandler<(T, int)>? AddedItem;

    public new void RemoveAt(int index)
    {
        T removedItem = this[index];
        base.RemoveAt(index);
        RemovedAtItem?.Invoke(this, (removedItem, index));
    }
    public event EventHandler<(T, int)>? RemovedAtItem;
}