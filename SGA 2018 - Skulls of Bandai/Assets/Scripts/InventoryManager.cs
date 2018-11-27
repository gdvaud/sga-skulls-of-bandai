using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Manager {

    [SerializeField] private int maxSize = 2;
    [SerializeField] private List<Item> items;

    private void Start() {
        items = new List<Item>(maxSize);
    }

    public bool AddItem(Item item) {
        if (IsFull()) return false;
        items.Add(item);
        return true;
    }

    public bool IsFull() {
        return items.Count == maxSize;
    }
}
