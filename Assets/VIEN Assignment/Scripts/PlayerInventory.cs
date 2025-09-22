using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private readonly HashSet<string> _items = new();
    
    public event Action<string> OnItemAdded;

    public void AddItem(string item)
    {
        _items.Add(item);
        Debug.Log(item + " added to inventory.");
        OnItemAdded?.Invoke(item);
    }
    
    public bool HasItem(string item)
    {
        return _items.Contains(item);
    }
}
