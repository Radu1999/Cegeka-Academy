using System;
using System.Text;

public class Set<T>
{
	private HashSet<T> set;
    public Set()
    {
        set = new HashSet<T>();
    }
	public void Insert(T item)
    {
        int len = set.Count;
        set.Add(item);
        if(len == set.Count)
        {
            throw new InvalidOperationException("Element already in Set");
        }
    }
    public void Remove(T item)
    {
        set.Remove(item);
    }

    public bool Containts(T item)
    {
        return set.Contains(item);
    }
    public Set<T> Merge(Set<T> other)
    {
        Set<T> result = new Set<T>();
        foreach (T item in other.set)
        {
            result.Insert(item);
        }

        foreach (T item in set)
        {
            if(!result.Containts(item))
            {
                result.Insert(item);
            }
        }

        return result;
    }

    public Set<T> Filter(Func<T, bool> filter)
    {
        Set<T> result = new Set<T>();
        foreach (T item in set)
        {
            if(filter(item))
            {
                result.Insert(item);
            }
        }
        return result;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (T item in set)
        {
            if(item != null)
            sb.Append(item.ToString()).Append(' ');
        }
        return sb.ToString();
    }
}
