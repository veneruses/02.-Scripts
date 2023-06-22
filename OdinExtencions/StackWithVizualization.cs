using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class StackWithVizualization<T>
{
    private Stack<T> stack = new Stack<T>();

    // This is a property that Odin can show in the inspector
    [ShowInInspector]
    private List<T> StackAsList
    {
        get
        {
            return new List<T>(stack);
        }
    }

    public void Push(T item)
    {
        stack.Push(item);
    }

    public T Pop()
    {
        return stack.Count > 0 ? stack.Pop() : default;
    }

    public T Peek()
    {
        return stack.Count > 0 ? stack.Peek() : default;
    }

    public int Count => stack.Count;

    public bool Contains(T item)
    {
        return stack.Contains(item);
    }

    // You may want to implement additional Stack<T> methods here...
}